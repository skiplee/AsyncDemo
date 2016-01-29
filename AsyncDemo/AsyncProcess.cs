using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    public class AsyncProcess : IProcess
    {
        private CancellationTokenSource _cancellationSource;
        private bool _goBoom;

        public async Task<string> ExecuteAsync(Progress<int> progress)
        {
            _cancellationSource = new CancellationTokenSource();
            return await Task.Run(async () => await DoSomeWork(progress, _cancellationSource.Token)).ConfigureAwait(false);
        }
        
        private async Task<string> DoSomeWork(IProgress<int> progress, CancellationToken token)
        {
            try
            {
                for (var i = 0; i < 100; i++)
                {
                    progress.Report(i);
                    await Task.Delay(TimeSpan.FromMilliseconds(Setting.UpdateSpeed), token).ConfigureAwait(false);
                    if (_goBoom)
                        throw new BoomException();
                }
                progress.Report(100);
                return "Done";
            }
            catch (TaskCanceledException)
            {
                progress.Report(0);
                return "Cancelled";
            }
        }

        public void Cancel()
        {
            _cancellationSource.Cancel();
        }

        public void GoBoom()
        {
            _goBoom = true;
        }
    }
}