namespace ScreenStreamer.Server
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
            panel1 = new Panel();
            tbxIpAddress = new TextBox();
            label7 = new Label();
            tbxInterval = new TextBox();
            label6 = new Label();
            btnHidePreview = new Button();
            lblByteSent = new Label();
            label5 = new Label();
            btnShowPreview = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnStop = new Button();
            tbxY2 = new TextBox();
            tbxX2 = new TextBox();
            tbxY1 = new TextBox();
            tbxX1 = new TextBox();
            btnStart = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            pbPreview = new PictureBox();
            rtbLogs = new RichTextBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1125, 730);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(tbxIpAddress);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(tbxInterval);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnHidePreview);
            panel1.Controls.Add(lblByteSent);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnShowPreview);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(tbxY2);
            panel1.Controls.Add(tbxX2);
            panel1.Controls.Add(tbxY1);
            panel1.Controls.Add(tbxX1);
            panel1.Controls.Add(btnStart);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(106, 724);
            panel1.TabIndex = 2;
            // 
            // tbxIpAddress
            // 
            tbxIpAddress.Location = new Point(3, 141);
            tbxIpAddress.Name = "tbxIpAddress";
            tbxIpAddress.Size = new Size(100, 23);
            tbxIpAddress.TabIndex = 18;
            tbxIpAddress.Text = "127.0.0.1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 123);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 17;
            label7.Text = "IP Address";
            // 
            // tbxInterval
            // 
            tbxInterval.Location = new Point(2, 86);
            tbxInterval.Name = "tbxInterval";
            tbxInterval.Size = new Size(56, 23);
            tbxInterval.TabIndex = 16;
            tbxInterval.Text = "250";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 68);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 15;
            label6.Text = "Interval";
            // 
            // btnHidePreview
            // 
            btnHidePreview.Location = new Point(2, 32);
            btnHidePreview.Name = "btnHidePreview";
            btnHidePreview.Size = new Size(100, 23);
            btnHidePreview.TabIndex = 14;
            btnHidePreview.Text = "Hide Preview";
            btnHidePreview.UseVisualStyleBackColor = true;
            btnHidePreview.Click += btnHidePreview_Click;
            // 
            // lblByteSent
            // 
            lblByteSent.AutoSize = true;
            lblByteSent.Location = new Point(9, 359);
            lblByteSent.Name = "lblByteSent";
            lblByteSent.Size = new Size(13, 15);
            lblByteSent.TabIndex = 13;
            lblByteSent.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 344);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 12;
            label5.Text = "Sent";
            // 
            // btnShowPreview
            // 
            btnShowPreview.Location = new Point(2, 3);
            btnShowPreview.Name = "btnShowPreview";
            btnShowPreview.Size = new Size(101, 23);
            btnShowPreview.TabIndex = 11;
            btnShowPreview.Text = "Show Preview";
            btnShowPreview.UseVisualStyleBackColor = true;
            btnShowPreview.Click += btnShowPreview_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 298);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 10;
            label4.Text = "Y2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 269);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 9;
            label3.Text = "X2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 240);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 8;
            label2.Text = "Y1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 211);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 7;
            label1.Text = "X1";
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(3, 445);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(101, 23);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop Streaming";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // tbxY2
            // 
            tbxY2.Location = new Point(29, 295);
            tbxY2.Name = "tbxY2";
            tbxY2.Size = new Size(29, 23);
            tbxY2.TabIndex = 5;
            tbxY2.Text = "500";
            // 
            // tbxX2
            // 
            tbxX2.Location = new Point(29, 266);
            tbxX2.Name = "tbxX2";
            tbxX2.Size = new Size(29, 23);
            tbxX2.TabIndex = 4;
            tbxX2.Text = "500";
            // 
            // tbxY1
            // 
            tbxY1.Location = new Point(29, 237);
            tbxY1.Name = "tbxY1";
            tbxY1.Size = new Size(29, 23);
            tbxY1.TabIndex = 3;
            tbxY1.Text = "0";
            // 
            // tbxX1
            // 
            tbxX1.Location = new Point(29, 208);
            tbxX1.Name = "tbxX1";
            tbxX1.Size = new Size(29, 23);
            tbxX1.TabIndex = 2;
            tbxX1.Text = "0";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(2, 416);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(101, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start Streaming";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(pbPreview, 0, 0);
            tableLayoutPanel2.Controls.Add(rtbLogs, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(115, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.Size = new Size(1007, 724);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // pbPreview
            // 
            pbPreview.BorderStyle = BorderStyle.Fixed3D;
            pbPreview.Dock = DockStyle.Fill;
            pbPreview.Location = new Point(3, 3);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(1001, 618);
            pbPreview.TabIndex = 0;
            pbPreview.TabStop = false;
            // 
            // rtbLogs
            // 
            rtbLogs.Dock = DockStyle.Fill;
            rtbLogs.Location = new Point(3, 627);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.Size = new Size(1001, 94);
            rtbLogs.TabIndex = 1;
            rtbLogs.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 730);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            ShowIcon = false;
            Text = "Screen Streamer";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TextBox tbxY2;
        private TextBox tbxX2;
        private TextBox tbxY1;
        private TextBox tbxX1;
        private Button btnStart;
        private PictureBox pbPreview;
        private Button btnStop;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnShowPreview;
        private Button btnHidePreview;
        private Label lblByteSent;
        private Label label5;
        private TextBox tbxInterval;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel2;
        private RichTextBox rtbLogs;
        private TextBox tbxIpAddress;
        private Label label7;
    }
}
