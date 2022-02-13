using System;
using System.Threading;
using System.Windows.Forms;
using CmlLib.Launcher;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Drawing;

namespace CmlLibSample
{
    public partial class FLauncher : Form
    {
        public FLauncher()
        {
            InitializeComponent();
        }
       public MSession OflineSession = null;
        private void Main_Load(object sender, EventArgs e)
        {
            //   MessageBox.Show(CmlLib._Test.tstr);
            



            // Check java runtime

            var java = new CmlLib.Utils.MJava(Minecraft.DefaultPath + "\\runtime");
            if (!java.CheckJavaw())
            {
                var form = new Download_Form();
                form.Show();
                bool iscom = false;

                java.DownloadProgressChanged += (s, v) =>
                {
                    form.ChangeProgress(v.ProgressPercentage);
                };
                java.UnzipCompleted += (t, w) =>
                {
                    form.Close();
                    this.Show();
                    iscom = true;
                };

                java.DownloadJavaAsync();

                while (!iscom)
                {
                    Application.DoEvents();
                }
            }

            Txt_Java.Text = Minecraft.DefaultPath + "\\runtime\\bin\\javaw.exe";


            RegistryKey readKey = Registry.CurrentUser.OpenSubKey("FLauncher");
            Cb_Version.SelectedValue = (string)readKey.GetValue("Last_Load_Version");
            Cb_Version.Text = (string)readKey.GetValue("Last_Load_Version");
        }

        bool allowOffline = true;
        MProfileInfo[] versions;
        public MSession session = Class1.mSession;
        GameLog logForm;

        private void Main_Shown(object sender, EventArgs e)
        {
            // Initialize launcher

            Path.Text = Environment.GetEnvironmentVariable("appdata") + "\\.minecraft";
            var th = new Thread(new ThreadStart(delegate
            {
                Minecraft.Initialize(Path.Text);

                versions = MProfileInfo.GetProfiles();
                Invoke((MethodInvoker)delegate
                {
                    foreach (var item in versions)
                    {
                        Cb_Version.Items.Add(item.Name);
                    }
                });

                // Try auto login

                var login = new MLogin();
                MSession result = login.TryAutoLogin();

                if (result.Result != MLoginResult.Success)
                    return;

               // MessageBox.Show("Auto Login Success!");
                session = result;
                Class1.mSession = session;
                Invoke((MethodInvoker)delegate {
                    //Btn_Login.Enabled = false;
                    //Btn_Login.Text = "Auto Login\nSuccess";
                });
            }));
            th.Start();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            // Apply

            Minecraft.Initialize(Path.Text);
            versions = MProfileInfo.GetProfiles();
            Cb_Version.Items.Clear();
            foreach (var item in versions)
            {
                Cb_Version.Items.Add(item.Name);
            }
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            // Login

            Btn_Login.Enabled = false;
            if (Txt_Pw.Text == "")
            {
                if (allowOffline)
                {
                    session = MSession.GetOfflineSession(Txt_Email.Text);
                    MessageBox.Show("Offline login Success : " + Txt_Email.Text);
                }
                else
                {
                    MessageBox.Show("Password was empty");
                    Btn_Login.Enabled = true;
                    return;
                }
            }
            else
            {
                var th = new Thread(new ThreadStart(delegate
                {
                    var login = new MLogin();
                    var result = login.Authenticate(Txt_Email.Text, Txt_Pw.Text);
                    if (result.Result == MLoginResult.Success)
                    {
                        MessageBox.Show("Login Success : " + result.Username);
                        session = result;
                    }
                    else
                    {
                        MessageBox.Show(result.Result.ToString() + "\n" + result.Message);
                        Invoke((MethodInvoker)delegate { Btn_Login.Enabled = true; });
                    }
                }));
                th.Start();
            }
        }

        private void Btn_Launch_Click(object sender, EventArgs e)
        {
            // Launch

            if (session == null)
            {
                MessageBox.Show("Login First");
                return;
            }

            if (Cb_Version.Text == "") return;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            string startVersion = Cb_Version.Text;
            string javaPath = Txt_Java.Text;


            RegistryKey readKey = Registry.CurrentUser.OpenSubKey("FLauncher");

            string xmx = (string)readKey.GetValue("Ram");
            string launcherName = Txt_LauncherName.Text;
            string serverIp = "";

            var th = new Thread(new ThreadStart(delegate
            {
                var profile = MProfile.FindProfile(versions, startVersion); // Find Profile

                DownloadGame(profile); // Download game files

                MLaunchOption option = new MLaunchOption() // Set options
                {
                    StartProfile = profile,
                    JavaPath = javaPath,
                    LauncherName = launcherName,
                    MaximumRamMb = int.Parse(xmx),
                    ServerIp = serverIp,
                    Session = session,
                    CustomJavaParameter = ""
                };

                if (Txt_ScWd.Text != "" && Txt_ScHt.Text != "")
                {
                    //option.ScreenHeight = int.Parse(Txt_ScHt.Text);
                    //option.ScreenWidth = int.Parse(Txt_ScWd.Text);
                }

                MLaunch launch = new MLaunch(option); // Start Process
                var process = launch.GetProcess();

                this.Invoke((MethodInvoker)delegate
                {
                    if (logForm != null)
                        logForm.Close();

                    //logForm = new GameLog();
                   // logForm.Show();

                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                });

                DebugProcess(process);
            }));
            th.Start();


            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey("FLauncher");
            helloKey.SetValue("Last_Load_Version", Cb_Version.Text);
        }

        private void DownloadGame(MProfile profile, bool downloadResource = true)
        {
            MDownloader downloader = new MDownloader(profile);
            downloader.ChangeFile += Downloader_ChangeFile;
            downloader.ChangeProgress += Downloader_ChangeProgress;
            downloader.DownloadAll(downloadResource);
        }

        private void Downloader_ChangeProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                progressBar2.Value = e.ProgressPercentage;
            });

        }

        private void Downloader_ChangeFile(DownloadFileChangedEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                Lv_Status.Text = e.FileKind.ToString() + " : " + e.FileName;
                progressBar1.Maximum = e.TotalFileCount;
                progressBar1.Value = e.ProgressedFileCount;
            });
        }

        #region DEBUG PROCESS

        private void DebugProcess(Process process)
        {
            Console.WriteLine("Write game args");
            File.WriteAllText("launcher.txt", process.StartInfo.Arguments);

            Console.WriteLine("Set Debug Process");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.EnableRaisingEvents = true;
            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.OutputDataReceived += Process_OutputDataReceived;

            Console.WriteLine("Start Debug Process");
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            output(e.Data);
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            output(e.Data);
        }

        void output(string msg)
        {
            Invoke(new Action(() =>
            {
                if (logForm != null)
                    logForm.AddLog(msg);
            }));
        }

        #endregion

        private void Button2_Click(object sender, EventArgs e)
        {
            var form3 = new Logout_and_Cache();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Owner = this;
            form1.Opacity = .97;
            form1.Show();
        }

        private void Txt_Ram_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Cb_Version_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
