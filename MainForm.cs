using System.Diagnostics;
using System.Text.RegularExpressions;

namespace USBFormatter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshUSBList();
            PopulateFileSystems();
        }

        private void RefreshUSBList()
        {
            string output = GetDiskList("list disk");
            var disks = ParseDiskInfo(output);

            comboBoxDisks.Items.Clear();
            foreach (var disk in disks)
            {
                comboBoxDisks.Items.Add(disk);
                // Set dynamic width
                int width = TextRenderer.MeasureText(disk, comboBoxDisks.Font).Width;
                comboBoxDisks.Width = Math.Max(comboBoxDisks.Width, width + SystemInformation.VerticalScrollBarWidth);
            }

            if (comboBoxDisks.Items.Count > 0)
            {
                comboBoxDisks.SelectedIndex = 0;
            }
            else
            {
                comboBoxDisks.Text = "No disks found";
            }
        }

        private void PopulateFileSystems()
        {
            comboBoxFileSystem.Items.Clear();
            comboBoxFileSystem.Items.Add("NTFS");
            comboBoxFileSystem.Items.Add("FAT32");
            comboBoxFileSystem.Items.Add("exFAT");
            comboBoxFileSystem.SelectedItem = "FAT32";
        }

        private string ExecuteDiskPartCommand(string command1, string command2, string command3, string command4, string command5, string command6, string command7)
        {
            Process process = new Process();
            process.StartInfo.FileName = "diskpart.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            process.StandardInput.WriteLine(command1);
            process.StandardInput.WriteLine(command2);
            process.StandardInput.WriteLine(command3);
            process.StandardInput.WriteLine(command4);
            process.StandardInput.WriteLine(command5);
            process.StandardInput.WriteLine(command6);
            process.StandardInput.WriteLine(command7);

            process.StandardInput.WriteLine("exit");
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        private string GetDiskList(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "diskpart.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output;
        }

        private string GetDiskNumber()
        {
            string pattern = @"Disk (\d+)";
            string diskInfo = comboBoxDisks.SelectedItem?.ToString() ?? "";
            Match match = Regex.Match(diskInfo, pattern);

            if (match.Success)
            {
                textBoxConsole.AppendText("Disk: " + diskInfo + Environment.NewLine);
                textBoxConsole.AppendText("Disk number: " + match.Groups[1].Value + Environment.NewLine);
                return match.Groups[1].Value;
            }
            else
            {
                textBoxConsole.AppendText("Disk: " + diskInfo + Environment.NewLine);
                textBoxConsole.AppendText("No disk number found." + Environment.NewLine);
                return "";
            }
        }

        private List<string> ParseDiskInfo(string output)
        {
            var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var disks = new List<string>();
            foreach (var line in lines)
            {
                if (line.Contains("Disk") && line.Contains("Online"))
                {
                    disks.Add(line);
                }
            }
            return disks;
        }

        private void buttonFormat_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar.Style = ProgressBarStyle.Marquee; // Set progress bar to indeterminate mode
                backgroundWorker1.RunWorkerAsync();
                buttonRefresh.Enabled = false; // Disable the refresh button
                 buttonFormat.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object? sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (comboBoxDisks.SelectedItem == null || comboBoxFileSystem.SelectedItem == null)
            {
                MessageBox.Show("Please select a disk and a file system to format.");
                return;
            }

            string fileSystem = comboBoxFileSystem.SelectedItem?.ToString() ?? "";

            string output = ExecuteDiskPartCommand("list disk", "select disk " + GetDiskNumber(), "clean", "create partition primary", "select partition 1", "assign", $"format fs={fileSystem} quick");
            textBoxConsole.Invoke((MethodInvoker)delegate
            {
                textBoxConsole.AppendText(output + Environment.NewLine);
            });
        }

        private void backgroundWorker1_RunWorkerCompleted(object? sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Blocks; // Set progress bar back to determinate mode
            progressBar.Value = 100;
            progressBar.ForeColor = Color.Green;
            MessageBox.Show("Format completed!");
            buttonRefresh.Enabled = true; 
            buttonFormat.Enabled = true;
        
        }

        private void buttonRefresh_Click(object? sender, EventArgs e)
        {
            RefreshUSBList();
            // Clear textBoxConsole text
            textBoxConsole.Text = "";
        }
    }
}
