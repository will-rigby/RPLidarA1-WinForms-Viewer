namespace LIDARCOntroller
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
            this.serialPortBox = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.scanButton = new System.Windows.Forms.Button();
            this.statusButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rayTraceKeepCheckBox = new System.Windows.Forms.CheckBox();
            this.rayTraceCheckBox = new System.Windows.Forms.CheckBox();
            this.clearEachScan = new System.Windows.Forms.CheckBox();
            this.setScaleButton = new System.Windows.Forms.Button();
            this.scaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPortBox
            // 
            this.serialPortBox.FormattingEnabled = true;
            this.serialPortBox.Location = new System.Drawing.Point(87, 19);
            this.serialPortBox.Name = "serialPortBox";
            this.serialPortBox.Size = new System.Drawing.Size(121, 21);
            this.serialPortBox.TabIndex = 0;
            this.serialPortBox.Text = "COM20";
            this.serialPortBox.SelectedIndexChanged += new System.EventHandler(this.SerialPortBox_SelectedIndexChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(214, 19);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(6, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(6, 19);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 4;
            this.scanButton.Text = "Scan Ports";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // statusButton
            // 
            this.statusButton.Location = new System.Drawing.Point(87, 20);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(75, 23);
            this.statusButton.TabIndex = 5;
            this.statusButton.Text = "Get Status";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(163, 22);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(79, 20);
            this.statusBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scanButton);
            this.groupBox1.Controls.Add(this.serialPortBox);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 49);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Controls.Add(this.statusButton);
            this.groupBox2.Controls.Add(this.statusBox);
            this.groupBox2.Location = new System.Drawing.Point(313, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RPLIDAR Control";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rayTraceKeepCheckBox);
            this.groupBox3.Controls.Add(this.rayTraceCheckBox);
            this.groupBox3.Controls.Add(this.clearEachScan);
            this.groupBox3.Controls.Add(this.setScaleButton);
            this.groupBox3.Controls.Add(this.scaleUpDown);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(570, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 94);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display";
            // 
            // rayTraceKeepCheckBox
            // 
            this.rayTraceKeepCheckBox.AutoSize = true;
            this.rayTraceKeepCheckBox.Location = new System.Drawing.Point(90, 71);
            this.rayTraceKeepCheckBox.Name = "rayTraceKeepCheckBox";
            this.rayTraceKeepCheckBox.Size = new System.Drawing.Size(51, 17);
            this.rayTraceKeepCheckBox.TabIndex = 14;
            this.rayTraceKeepCheckBox.Text = "Keep";
            this.rayTraceKeepCheckBox.UseVisualStyleBackColor = true;
            // 
            // rayTraceCheckBox
            // 
            this.rayTraceCheckBox.AutoSize = true;
            this.rayTraceCheckBox.Location = new System.Drawing.Point(6, 71);
            this.rayTraceCheckBox.Name = "rayTraceCheckBox";
            this.rayTraceCheckBox.Size = new System.Drawing.Size(76, 17);
            this.rayTraceCheckBox.TabIndex = 13;
            this.rayTraceCheckBox.Text = "Ray Trace";
            this.rayTraceCheckBox.UseVisualStyleBackColor = true;
            this.rayTraceCheckBox.CheckedChanged += new System.EventHandler(this.rayTraceCheckBox_CheckedChanged);
            // 
            // clearEachScan
            // 
            this.clearEachScan.AutoSize = true;
            this.clearEachScan.Location = new System.Drawing.Point(6, 50);
            this.clearEachScan.Name = "clearEachScan";
            this.clearEachScan.Size = new System.Drawing.Size(88, 17);
            this.clearEachScan.TabIndex = 12;
            this.clearEachScan.Text = "Clear on Rev";
            this.clearEachScan.UseVisualStyleBackColor = true;
            // 
            // setScaleButton
            // 
            this.setScaleButton.Location = new System.Drawing.Point(113, 16);
            this.setScaleButton.Name = "setScaleButton";
            this.setScaleButton.Size = new System.Drawing.Size(75, 23);
            this.setScaleButton.TabIndex = 11;
            this.setScaleButton.Text = "Set";
            this.setScaleButton.UseVisualStyleBackColor = true;
            this.setScaleButton.Click += new System.EventHandler(this.setScaleButton_Click);
            // 
            // scaleUpDown
            // 
            this.scaleUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleUpDown.Location = new System.Drawing.Point(6, 19);
            this.scaleUpDown.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            this.scaleUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleUpDown.Name = "scaleUpDown";
            this.scaleUpDown.Size = new System.Drawing.Size(94, 20);
            this.scaleUpDown.TabIndex = 1;
            this.scaleUpDown.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.scaleUpDown.ValueChanged += new System.EventHandler(this.scaleUpDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(12, 718);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(770, 119);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Controls";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 849);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "RP LIDAR Mapper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox serialPortBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button setScaleButton;
        private System.Windows.Forms.NumericUpDown scaleUpDown;
        private System.Windows.Forms.CheckBox clearEachScan;
        private System.Windows.Forms.CheckBox rayTraceCheckBox;
        private System.Windows.Forms.CheckBox rayTraceKeepCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

