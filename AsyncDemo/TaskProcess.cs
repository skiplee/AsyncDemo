using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    public class TaskProcess : IProcess
    {
        private CancellationTokenSource _cancellationSource;
        private bool _goBoom;

        public Task<string> Execute(Progress<int> progress)
        {
            _cancellationSource = new CancellationTokenSource();
            return Task.Run(() => DoSomeWork(progress, _cancellationSource.Token));
        }

        private string DoSomeWork(IProgress<int> progress, CancellationToken token)
        {
            for (var i = 0; i < 100; i++)
            {
                progress.Report(i);
                Thread.Sleep(TimeSpan.FromMilliseconds(Setting.UpdateSpeed));
                if (token.IsCancellationRequested)
                {
                    progress.Report(0);
                    return "Cancelled";
                }
                if (_goBoom)
                    throw new BoomException();
            }
            progress.Report(100);
            return "Done";
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
