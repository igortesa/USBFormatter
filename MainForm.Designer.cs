namespace USBFormatter
{
    partial class MainForm
    {
        private System.Windows.Forms.ComboBox comboBoxDisks;
        private System.Windows.Forms.ComboBox comboBoxFileSystem;
        private System.Windows.Forms.Button buttonFormat;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.IContainer components = null;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxDisks = new System.Windows.Forms.ComboBox();
            this.comboBoxFileSystem = new System.Windows.Forms.ComboBox();
            this.buttonFormat = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

            // comboBoxDisks
            this.comboBoxDisks.FormattingEnabled = true;
            this.comboBoxDisks.Location = new System.Drawing.Point(155, 50);
            this.comboBoxDisks.Name = "comboBoxDisks";
            this.comboBoxDisks.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDisks.TabIndex = 0;

            // comboBoxFileSystem
            this.comboBoxFileSystem.FormattingEnabled = true;
            this.comboBoxFileSystem.Location = new System.Drawing.Point(155, 100);
            this.comboBoxFileSystem.Name = "comboBoxFileSystem";
            this.comboBoxFileSystem.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFileSystem.TabIndex = 1;

            // buttonFormat
            this.buttonFormat.Location = new System.Drawing.Point(150, 150);
            this.buttonFormat.Name = "buttonFormat";
            this.buttonFormat.Size = new System.Drawing.Size(75, 23);
            this.buttonFormat.TabIndex = 2;
            this.buttonFormat.Text = "Format";
            this.buttonFormat.UseVisualStyleBackColor = true;
            this.buttonFormat.Click += new System.EventHandler(this.buttonFormat_Click);

            // buttonRefresh
            this.buttonRefresh.Location = new System.Drawing.Point(50, 150);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);

            // textBoxConsole
              this.textBoxConsole.BackColor = System.Drawing.Color.Black;
            this.textBoxConsole.ForeColor = System.Drawing.Color.White;
            this.textBoxConsole.Location = new System.Drawing.Point(50, 200);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(700, 400);
            this.textBoxConsole.TabIndex = 6;

            //progressBar
            this.progressBar.Location = new System.Drawing.Point(105, 610);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(645, 20); // width 700px, height 20px
            this.progressBar.TabIndex = 7;
            this.progressBar.Value = 0;
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.ForeColor = Color.Green;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select USB Disk:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select File System:";
            
            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 610);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status:";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);  // I have increased the height to accommodate the larger console field
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonFormat);
            this.Controls.Add(this.comboBoxFileSystem);
            this.Controls.Add(this.comboBoxDisks);
            this.Controls.Add(this.progressBar); 
            this.Controls.Add(this.label3);
            this.Name = "MainForm";
            this.Text = "USB Formatter";
            this.Load += new System.EventHandler(this.MainForm_Load);
        }
    }
}
