using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zebrano.B2B.Entity;

namespace Zebrano.B2B
{
    public partial class LoginPage : Form
    {
        VEN_ERPEntities db = new VEN_ERPEntities();

        public LoginPage()
        {
            InitializeComponent();
        }

        

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Init_Data()
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    txtUsername.Text = Properties.Settings.Default.Username;
                    chxbxRememberMe.Checked = true;
                }
                else
                {
                    txtUsername.Text = Properties.Settings.Default.Username;
                }
            }
        }
        private void Save_Data()
        {
            if (chxbxRememberMe.Checked)
            {
                Properties.Settings.Default.Username = txtUsername.Text.Trim();
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginvalue = db.VN_002_B2BUSERS.Where(x => x.LOGINNAME == txtUsername.Text && x.PASSWORD == txtPassword.Text).FirstOrDefault();
            if (loginvalue != null)
            {
                Save_Data();
                this.Hide();
                MainForm loginSuccess;
                loginSuccess = new MainForm();
                loginSuccess.customerid = int.Parse(loginvalue.CUSTOMERID.ToString());
                loginSuccess.Show();

            }
            else
            {
                MessageBox.Show("Bilgileriniz Yanlış");
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            Init_Data();


        }

        private void pbFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/zebranom/");
        }

        private void pbInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/zebranom/");
        }

        private void pbTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/zebranom");
        
        }

        private void pBYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/zebranomobilya");
        }

        }
    }

