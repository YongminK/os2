namespace ParallelComputingSample
{
    partial class MainForm
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
            this.tabPageParallelFor = new System.Windows.Forms.TabPage();
            this.textBoxParallelFor = new System.Windows.Forms.TextBox();
            this.btnStartParallelFor = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabPageParallelInvoke = new System.Windows.Forms.TabPage();
            this.labelParallelInvokeTimer = new System.Windows.Forms.Label();
            this.numericUpDownParallelInvokeTimer = new System.Windows.Forms.NumericUpDown();
            this.btnClearTextBoxParallelInvoke = new System.Windows.Forms.Button();
            this.checkBoxThreadPool = new System.Windows.Forms.CheckBox();
            this.textBoxParallelInvoke = new System.Windows.Forms.TextBox();
            this.tabPageASDInvoke = new System.Windows.Forms.TabPage();
            this.btnASDInvoke = new System.Windows.Forms.Button();
            this.textBoxASDInvokeLog = new System.Windows.Forms.TextBox();
            this.textBoxFinishList = new System.Windows.Forms.TextBox();
            this.tabPageThreadsDispatching = new System.Windows.Forms.TabPage();
            this.btnResetEvent = new System.Windows.Forms.Button();
            this.btnSetEvent = new System.Windows.Forms.Button();
            this.labelDispatching = new System.Windows.Forms.Label();
            this.panelEventMode = new System.Windows.Forms.Panel();
            this.radioButtonManualResetEvent = new System.Windows.Forms.RadioButton();
            this.radioButtonAutoResetEvent = new System.Windows.Forms.RadioButton();
            this.textBoxDispatchingStatistics = new System.Windows.Forms.TextBox();
            this.btnStartThreadDispatching = new System.Windows.Forms.Button();
            this.labelThreadsCount = new System.Windows.Forms.Label();
            this.labelWork = new System.Windows.Forms.Label();
            this.linkCodingCraft = new System.Windows.Forms.LinkLabel();
            this.tabPageThreadsRace = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParallelInvokeTimer)).BeginInit();
            this.tabPageThreadsRace.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageParallelFor
            // 
            this.tabPageParallelFor.Location = new System.Drawing.Point(0, 0);
            this.tabPageParallelFor.Name = "tabPageParallelFor";
            this.tabPageParallelFor.Size = new System.Drawing.Size(200, 100);
            this.tabPageParallelFor.TabIndex = 0;
            // 
            // textBoxParallelFor
            // 
            this.textBoxParallelFor.Location = new System.Drawing.Point(0, 0);
            this.textBoxParallelFor.Name = "textBoxParallelFor";
            this.textBoxParallelFor.Size = new System.Drawing.Size(100, 20);
            this.textBoxParallelFor.TabIndex = 0;
            // 
            // btnStartParallelFor
            // 
            this.btnStartParallelFor.Location = new System.Drawing.Point(0, 0);
            this.btnStartParallelFor.Name = "btnStartParallelFor";
            this.btnStartParallelFor.Size = new System.Drawing.Size(75, 23);
            this.btnStartParallelFor.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(733, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 28);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabPageParallelInvoke
            // 
            this.tabPageParallelInvoke.Location = new System.Drawing.Point(0, 0);
            this.tabPageParallelInvoke.Name = "tabPageParallelInvoke";
            this.tabPageParallelInvoke.Size = new System.Drawing.Size(200, 100);
            this.tabPageParallelInvoke.TabIndex = 0;
            // 
            // labelParallelInvokeTimer
            // 
            this.labelParallelInvokeTimer.Location = new System.Drawing.Point(0, 0);
            this.labelParallelInvokeTimer.Name = "labelParallelInvokeTimer";
            this.labelParallelInvokeTimer.Size = new System.Drawing.Size(100, 23);
            this.labelParallelInvokeTimer.TabIndex = 0;
            // 
            // numericUpDownParallelInvokeTimer
            // 
            this.numericUpDownParallelInvokeTimer.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownParallelInvokeTimer.Name = "numericUpDownParallelInvokeTimer";
            this.numericUpDownParallelInvokeTimer.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownParallelInvokeTimer.TabIndex = 0;
            // 
            // btnClearTextBoxParallelInvoke
            // 
            this.btnClearTextBoxParallelInvoke.Location = new System.Drawing.Point(0, 0);
            this.btnClearTextBoxParallelInvoke.Name = "btnClearTextBoxParallelInvoke";
            this.btnClearTextBoxParallelInvoke.Size = new System.Drawing.Size(75, 23);
            this.btnClearTextBoxParallelInvoke.TabIndex = 0;
            // 
            // checkBoxThreadPool
            // 
            this.checkBoxThreadPool.Location = new System.Drawing.Point(0, 0);
            this.checkBoxThreadPool.Name = "checkBoxThreadPool";
            this.checkBoxThreadPool.Size = new System.Drawing.Size(104, 24);
            this.checkBoxThreadPool.TabIndex = 0;
            // 
            // textBoxParallelInvoke
            // 
            this.textBoxParallelInvoke.Location = new System.Drawing.Point(0, 0);
            this.textBoxParallelInvoke.Name = "textBoxParallelInvoke";
            this.textBoxParallelInvoke.Size = new System.Drawing.Size(100, 20);
            this.textBoxParallelInvoke.TabIndex = 0;
            // 
            // tabPageASDInvoke
            // 
            this.tabPageASDInvoke.Location = new System.Drawing.Point(0, 0);
            this.tabPageASDInvoke.Name = "tabPageASDInvoke";
            this.tabPageASDInvoke.Size = new System.Drawing.Size(200, 100);
            this.tabPageASDInvoke.TabIndex = 0;
            // 
            // btnASDInvoke
            // 
            this.btnASDInvoke.Location = new System.Drawing.Point(0, 0);
            this.btnASDInvoke.Name = "btnASDInvoke";
            this.btnASDInvoke.Size = new System.Drawing.Size(75, 23);
            this.btnASDInvoke.TabIndex = 0;
            // 
            // textBoxASDInvokeLog
            // 
            this.textBoxASDInvokeLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxASDInvokeLog.Name = "textBoxASDInvokeLog";
            this.textBoxASDInvokeLog.Size = new System.Drawing.Size(100, 20);
            this.textBoxASDInvokeLog.TabIndex = 0;
            // 
            // textBoxFinishList
            // 
            this.textBoxFinishList.Location = new System.Drawing.Point(0, 0);
            this.textBoxFinishList.Name = "textBoxFinishList";
            this.textBoxFinishList.Size = new System.Drawing.Size(100, 20);
            this.textBoxFinishList.TabIndex = 0;
            // 
            // tabPageThreadsDispatching
            // 
            this.tabPageThreadsDispatching.Location = new System.Drawing.Point(0, 0);
            this.tabPageThreadsDispatching.Name = "tabPageThreadsDispatching";
            this.tabPageThreadsDispatching.Size = new System.Drawing.Size(200, 100);
            this.tabPageThreadsDispatching.TabIndex = 0;
            // 
            // btnResetEvent
            // 
            this.btnResetEvent.Location = new System.Drawing.Point(0, 0);
            this.btnResetEvent.Name = "btnResetEvent";
            this.btnResetEvent.Size = new System.Drawing.Size(75, 23);
            this.btnResetEvent.TabIndex = 0;
            // 
            // btnSetEvent
            // 
            this.btnSetEvent.Location = new System.Drawing.Point(0, 0);
            this.btnSetEvent.Name = "btnSetEvent";
            this.btnSetEvent.Size = new System.Drawing.Size(75, 23);
            this.btnSetEvent.TabIndex = 0;
            // 
            // labelDispatching
            // 
            this.labelDispatching.Location = new System.Drawing.Point(0, 0);
            this.labelDispatching.Name = "labelDispatching";
            this.labelDispatching.Size = new System.Drawing.Size(100, 23);
            this.labelDispatching.TabIndex = 0;
            // 
            // panelEventMode
            // 
            this.panelEventMode.Location = new System.Drawing.Point(0, 0);
            this.panelEventMode.Name = "panelEventMode";
            this.panelEventMode.Size = new System.Drawing.Size(200, 100);
            this.panelEventMode.TabIndex = 0;
            // 
            // radioButtonManualResetEvent
            // 
            this.radioButtonManualResetEvent.Location = new System.Drawing.Point(0, 0);
            this.radioButtonManualResetEvent.Name = "radioButtonManualResetEvent";
            this.radioButtonManualResetEvent.Size = new System.Drawing.Size(104, 24);
            this.radioButtonManualResetEvent.TabIndex = 0;
            // 
            // radioButtonAutoResetEvent
            // 
            this.radioButtonAutoResetEvent.Location = new System.Drawing.Point(0, 0);
            this.radioButtonAutoResetEvent.Name = "radioButtonAutoResetEvent";
            this.radioButtonAutoResetEvent.Size = new System.Drawing.Size(104, 24);
            this.radioButtonAutoResetEvent.TabIndex = 0;
            // 
            // textBoxDispatchingStatistics
            // 
            this.textBoxDispatchingStatistics.Location = new System.Drawing.Point(0, 0);
            this.textBoxDispatchingStatistics.Name = "textBoxDispatchingStatistics";
            this.textBoxDispatchingStatistics.Size = new System.Drawing.Size(100, 20);
            this.textBoxDispatchingStatistics.TabIndex = 0;
            // 
            // btnStartThreadDispatching
            // 
            this.btnStartThreadDispatching.Location = new System.Drawing.Point(0, 0);
            this.btnStartThreadDispatching.Name = "btnStartThreadDispatching";
            this.btnStartThreadDispatching.Size = new System.Drawing.Size(75, 23);
            this.btnStartThreadDispatching.TabIndex = 0;
            // 
            // labelThreadsCount
            // 
            this.labelThreadsCount.Location = new System.Drawing.Point(0, 0);
            this.labelThreadsCount.Name = "labelThreadsCount";
            this.labelThreadsCount.Size = new System.Drawing.Size(100, 23);
            this.labelThreadsCount.TabIndex = 2;
            // 
            // labelWork
            // 
            this.labelWork.Location = new System.Drawing.Point(0, 0);
            this.labelWork.Name = "labelWork";
            this.labelWork.Size = new System.Drawing.Size(100, 23);
            this.labelWork.TabIndex = 1;
            // 
            // linkCodingCraft
            // 
            this.linkCodingCraft.Location = new System.Drawing.Point(0, 0);
            this.linkCodingCraft.Name = "linkCodingCraft";
            this.linkCodingCraft.Size = new System.Drawing.Size(100, 23);
            this.linkCodingCraft.TabIndex = 0;
            // 
            // tabPageThreadsRace
            // 
            this.tabPageThreadsRace.Controls.Add(this.btnStart);
            this.tabPageThreadsRace.Location = new System.Drawing.Point(4, 22);
            this.tabPageThreadsRace.Name = "tabPageThreadsRace";
            this.tabPageThreadsRace.Size = new System.Drawing.Size(906, 308);
            this.tabPageThreadsRace.TabIndex = 2;
            this.tabPageThreadsRace.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageThreadsRace);
            this.tabControl.Location = new System.Drawing.Point(3, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(914, 334);
            this.tabControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 268);
            this.Controls.Add(this.linkCodingCraft);
            this.Controls.Add(this.labelWork);
            this.Controls.Add(this.labelThreadsCount);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Параллельные вычисления";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParallelInvokeTimer)).EndInit();
            this.tabPageThreadsRace.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageParallelFor;
        private System.Windows.Forms.Button btnStartParallelFor;
        private System.Windows.Forms.TextBox textBoxParallelFor;
        private System.Windows.Forms.Label labelThreadsCount;
        private System.Windows.Forms.Label labelWork;
        private System.Windows.Forms.TabPage tabPageParallelInvoke;
        private System.Windows.Forms.TextBox textBoxParallelInvoke;
        private System.Windows.Forms.CheckBox checkBoxThreadPool;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxFinishList;
        private System.Windows.Forms.TabPage tabPageThreadsDispatching;
        private System.Windows.Forms.Button btnClearTextBoxParallelInvoke;
        private System.Windows.Forms.Button btnResetEvent;
        private System.Windows.Forms.Button btnSetEvent;
        private System.Windows.Forms.Label labelDispatching;
        private System.Windows.Forms.Panel panelEventMode;
        private System.Windows.Forms.RadioButton radioButtonManualResetEvent;
        private System.Windows.Forms.RadioButton radioButtonAutoResetEvent;
        private System.Windows.Forms.TextBox textBoxDispatchingStatistics;
        private System.Windows.Forms.Button btnStartThreadDispatching;
        private System.Windows.Forms.TabPage tabPageASDInvoke;
        private System.Windows.Forms.TextBox textBoxASDInvokeLog;
        private System.Windows.Forms.Button btnASDInvoke;
        private System.Windows.Forms.Label labelParallelInvokeTimer;
        private System.Windows.Forms.NumericUpDown numericUpDownParallelInvokeTimer;
        private System.Windows.Forms.LinkLabel linkCodingCraft;
        private System.Windows.Forms.TabPage tabPageThreadsRace;
        private System.Windows.Forms.TabControl tabControl;
    }
}

