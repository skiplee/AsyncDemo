using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        private IProcess _process;

        public Form1()
        {
            InitializeComponent();

            resultLabel.Text = null;

            threadButton.Click += HandleThreadButtonClick;
            taskButton.Click += HandleTaskButtonClick;
            asyncButton.Click += HandleAsyncButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            boomButton.Click += HandleBoomButtonClick;
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            _process?.Cancel();
        }

        private void HandleBoomButtonClick(object sender, EventArgs e)
        {
            _process?.GoBoom();
        }

        private void HandleThreadButtonClick(object sender, EventArgs e)
        {
            resultLabel.Text = "Running...";

            var process = CreateProcess<ThreadProcess>();
            var processState = new ProcessState();
            process.ProgressChanged += (s, args) => Invoke(new Action(() => progressBar.Value = process.Progress));
            process.Complete += (s, args) => Invoke(new Action(() =>
            {
                resultLabel.Text = processState.Result;
                SetControlsInProcess(false);
            }));
            process.Exception += (s, args) => Invoke(new Action(() =>
            {
                MessageBox.Show($"Boom!\n\n{args.Exception}");
                resultLabel.Text = "Boom!";
                SetControlsInProcess(false);
            }));

            SetControlsInProcess(true);
            var thread = new Thread(process.Execute);
            thread.Start(processState);
        }

        private void HandleTaskButtonClick(object sender, EventArgs e)
        {
            SetControlsInProcess(true);
            resultLabel.Text = "Running...";
            var progress = new Progress<int>(x => progressBar.Value = x);
            var process = CreateProcess<TaskProcess>();
            Task.Run(() => process.Execute(progress))
                .ContinueWith(t => Invoke(new Action(() =>
                {
                    if (t.IsFaulted)
                    {
                        MessageBox.Show($"Boom!\n\n{t.Exception}");
                        resultLabel.Text = "Boom!";
                    }
                    else
                    {
                        resultLabel.Text = t.Result;
                    }
                    SetControlsInProcess(false);
                })));
        }

        private async void HandleAsyncButtonClick(object sender, EventArgs e)
        {
            await DoAsync();
        }

        private async Task DoAsync()
        {
            SetControlsInProcess(true);
            var progress = new Progress<int>(x => progressBar.Value = x);
            resultLabel.Text = "Running...";
            var process = CreateProcess<AsyncProcess>();
            try
            {
                var result = await process.ExecuteAsync(progress);
                resultLabel.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Boom!\n\n{ex}");
                resultLabel.Text = "Boom!";
            }
            finally
            {
                SetControlsInProcess(false);
            }
        }

        private T CreateProcess<T>() where T: IProcess, new()
        {
            var process = new T();
            _process = process;
            return process;
        }

        private void SetControlsInProcess(bool inProcess)
        {
            threadButton.Enabled = !inProcess;
            taskButton.Enabled = !inProcess;
            asyncButton.Enabled = !inProcess;
            cancelButton.Enabled = inProcess;
            boomButton.Enabled = inProcess;
        }
    }
}
