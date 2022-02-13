using System;
using System.Threading;
using System.Windows.Forms;
using CmlLib.Launcher;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace CmlLibSample
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        bool allowOffline = true;
        MProfileInfo[] versions;
        MSession session;
        GameLog logForm;


        private void Btn_Login_Click(object sender, EventArgs e)
        {


           


            Btn_Login.Enabled = false;
            if (Txt_Pw.Text == "")
            {
                if (allowOffline)
                {
                    session = MSession.GetOfflineSession(Txt_Email.Text);
                    MessageBox.Show("Offline login Success : " + Txt_Email.Text);


                    Class1.mSession = session;



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

                        Class1.mSession = session;

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

        private void Form1_Load(object sender, EventArgs e)
        {

            RegistryKey readKey = Registry.CurrentUser.OpenSubKey("FLauncher");

            Txt_Ram.Text = (string)readKey.GetValue("Ram");


            var login = new MLogin();
            MSession result = login.TryAutoLogin();

            if (result.Result != MLoginResult.Success)
                return;

           // MessageBox.Show("Auto Login Success!");
            session = result;
            Class1.mSession = session;
            Invoke((MethodInvoker)delegate {
                Btn_Login.Enabled = false;
                Btn_Login.Text = "Auto Login\nSuccess";
              
            });
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            // Apply

            Minecraft.Initialize(Path.Text);
            versions = MProfileInfo.GetProfiles();
           
            foreach (var item in versions)
            {
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey("FLauncher");
            helloKey.SetValue("Ram", Txt_Ram.Text);
        }

        private void Btn_loginOption_Click(object sender, EventArgs e)
        {
            var form3 = new Logout_and_Cache();
            form3.Show();
        }
    }
}
