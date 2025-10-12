namespace ScreenStreamerServer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            rtbLog = new RichTextBox();
            panel1 = new Panel();
            panel3 = new Panel();
            btnSaveConfig = new Button();
            label4 = new Label();
            btnLoadConfig = new Button();
            panel2 = new Panel();
            rbV1 = new RadioButton();
            rbV2 = new RadioButton();
            label1 = new Label();
            chkCompression = new CheckBox();
            tbxIpAddress = new TextBox();
            label3 = new Label();
            label2 = new Label();
            tbxInterval = new TextBox();
            tbxFilePath = new TextBox();
            btnClearLog = new Button();
            btnStop = new Button();
            btnStart = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(rtbLog, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1050, 704);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // rtbLog
            // 
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Location = new Point(528, 3);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(519, 698);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(btnClearLog);
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(btnStart);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(519, 698);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSaveConfig);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(btnLoadConfig);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(chkCompression);
            panel3.Controls.Add(tbxIpAddress);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(tbxInterval);
            panel3.Controls.Add(tbxFilePath);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(513, 224);
            panel3.TabIndex = 14;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.Location = new Point(136, 6);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new Size(130, 23);
            btnSaveConfig.TabIndex = 1;
            btnSaveConfig.Text = "Save Configuration";
            btnSaveConfig.UseVisualStyleBackColor = true;
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 153);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 13;
            label4.Text = "Version";
            // 
            // btnLoadConfig
            // 
            btnLoadConfig.Location = new Point(6, 6);
            btnLoadConfig.Name = "btnLoadConfig";
            btnLoadConfig.Size = new Size(124, 23);
            btnLoadConfig.TabIndex = 0;
            btnLoadConfig.Text = "Load Configuration";
            btnLoadConfig.UseVisualStyleBackColor = true;
            btnLoadConfig.Click += btnLoadConfig_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(rbV1);
            panel2.Controls.Add(rbV2);
            panel2.Location = new Point(136, 153);
            panel2.Name = "panel2";
            panel2.Size = new Size(76, 54);
            panel2.TabIndex = 12;
            // 
            // rbV1
            // 
            rbV1.AutoSize = true;
            rbV1.Checked = true;
            rbV1.Location = new Point(3, 3);
            rbV1.Name = "rbV1";
            rbV1.Size = new Size(38, 19);
            rbV1.TabIndex = 10;
            rbV1.TabStop = true;
            rbV1.Text = "V1";
            rbV1.UseVisualStyleBackColor = true;
            // 
            // rbV2
            // 
            rbV2.AutoSize = true;
            rbV2.Location = new Point(3, 28);
            rbV2.Name = "rbV2";
            rbV2.Size = new Size(38, 19);
            rbV2.TabIndex = 11;
            rbV2.Text = "V2";
            rbV2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 44);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 1;
            label1.Text = "Client IP Address";
            // 
            // chkCompression
            // 
            chkCompression.AutoSize = true;
            chkCompression.Location = new Point(136, 128);
            chkCompression.Name = "chkCompression";
            chkCompression.Size = new Size(130, 19);
            chkCompression.TabIndex = 9;
            chkCompression.Text = "Apply Compression";
            chkCompression.UseVisualStyleBackColor = true;
            // 
            // tbxIpAddress
            // 
            tbxIpAddress.Location = new Point(136, 41);
            tbxIpAddress.Name = "tbxIpAddress";
            tbxIpAddress.Size = new Size(242, 23);
            tbxIpAddress.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 102);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 8;
            label3.Text = "Internal (milliseconds)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 73);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "File Path";
            // 
            // tbxInterval
            // 
            tbxInterval.Location = new Point(136, 99);
            tbxInterval.Name = "tbxInterval";
            tbxInterval.Size = new Size(55, 23);
            tbxInterval.TabIndex = 7;
            tbxInterval.Text = "10000";
            // 
            // tbxFilePath
            // 
            tbxFilePath.Location = new Point(136, 70);
            tbxFilePath.Name = "tbxFilePath";
            tbxFilePath.Size = new Size(242, 23);
            tbxFilePath.TabIndex = 2;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(139, 318);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(75, 23);
            btnClearLog.TabIndex = 6;
            btnClearLog.Text = "Clear Log";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(220, 289);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 5;
            btnStop.Text = "Stop Server";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(139, 289);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 255, 234);
            ClientSize = new Size(1050, 704);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            ShowIcon = false;
            Text = "Screen Streamer Server";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox rtbLog;
        private Panel panel1;
        private Label label1;
        private TextBox tbxIpAddress;
        private Button btnStop;
        private Button btnStart;
        private Label label2;
        private TextBox tbxFilePath;
        private Button btnClearLog;
        private Label label3;
        private TextBox tbxInterval;
        private CheckBox chkCompression;
        private Panel panel2;
        private RadioButton rbV1;
        private RadioButton rbV2;
        private Label label4;
        private Panel panel3;
        private Button btnSaveConfig;
        private Button btnLoadConfig;
    }
}
