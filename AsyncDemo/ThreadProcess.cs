using System;
using System.Threading;

namespace AsyncDemo
{
    public class ThreadProcess : IProcess
    {
        private bool _cancel;
        private bool _throwException;
        public int Progress { get; set; }
        public event EventHandler ProgressChanged;
        public event EventHandler Complete;
        public event ThreadExceptionEventHandler Exception;

        public void Execute(object data)
        {
            var state = (ProcessState) data;
            try
            {
                DoSomeWork(state);
            }
            catch (Exception ex)
            {
                OnException(new ThreadExceptionEventArgs(ex));
            }
            OnComplete();
        }

        private void DoSomeWork(ProcessState state)
        {
            for (var i = 0; i < 100; i++)
            {
                UpdateProgress(i);
                Thread.Sleep(TimeSpan.FromMilliseconds(Setting.UpdateSpeed));
                if (_cancel)
                {
                    UpdateProgress(0);
                    state.Result = "Cancelled";
                    return;
                }
                if (_throwException)
                    throw new BoomException();
            }
            UpdateProgress(100);
            state.Result = "Done";
        }

        private void UpdateProgress(int i)
        {
            Progress = i;
            OnProgressChanged();
        }

        protected virtual void OnProgressChanged()
        {
            ProgressChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnComplete()
        {
            Complete?.Invoke(this, EventArgs.Empty);
        }

        public void Cancel()
        {
            _cancel = true;
        }

        public void GoBoom()
        {
            _throwException = true;
        }

        protected virtual void OnException(ThreadExceptionEventArgs e)
        {
            Exception?.Invoke(this, e);
        }
    }
}