using System;
using System.Threading;

namespace AsyncDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.threadButton = new System.Windows.Forms.Button();
            this.taskButton = new System.Windows.Forms.Button();
            this.asyncButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.boomButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // threadButton
            // 
            this.threadButton.Location = new System.Drawing.Point(12, 12);
            this.threadButton.Name = "threadButton";
            this.threadButton.Size = new System.Drawing.Size(75, 23);
            this.threadButton.TabIndex = 0;
            this.threadButton.Text = "Thread";
            this.threadButton.UseVisualStyleBackColor = true;
            // 
            // taskButton
            // 
            this.taskButton.Location = new System.Drawing.Point(12, 41);
            this.taskButton.Name = "taskButton";
            this.taskButton.Size = new System.Drawing.Size(75, 23);
            this.taskButton.TabIndex = 1;
            this.taskButton.Text = "Task";
            this.taskButton.UseVisualStyleBackColor = true;
            // 
            // asyncButton
            // 
            this.asyncButton.Location = new System.Drawing.Point(12, 70);
            this.asyncButton.Name = "asyncButton";
            this.asyncButton.Size = new System.Drawing.Size(75, 23);
            this.asyncButton.TabIndex = 2;
            this.asyncButton.Text = "Async";
            this.asyncButton.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 119);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(349, 23);
            this.progressBar.TabIndex = 3;
            // 
            // boomButton
            // 
            this.boomButton.Location = new System.Drawing.Point(262, 41);
            this.boomButton.Name = "boomButton";
            this.boomButton.Size = new System.Drawing.Size(75, 23);
            this.boomButton.TabIndex = 4;
            this.boomButton.Text = "BOOM!";
            this.boomButton.UseVisualStyleBackColor = true;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultLabel.Location = new System.Drawing.Point(0, 106);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(58, 13);
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "resultLabel";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(262, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 142);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.boomButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.asyncButton);
            this.Controls.Add(this.taskButton);
            this.Controls.Add(this.threadButton);
            this.Name = "Form1";
            this.Text = "AsyncDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button threadButton;
        private System.Windows.Forms.Button taskButton;
        private System.Windows.Forms.Button asyncButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button boomButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}

