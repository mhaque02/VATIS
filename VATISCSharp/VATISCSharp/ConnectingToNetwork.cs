using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;//For password encryption

namespace VATIS
{
    public partial class ConnectingToNetwork : Form
    {
        public ConnectingToNetwork()
        {
            InitializeComponent();
            vatsimID.KeyPress += new KeyPressEventHandler(vatsimID_KeyPress);
            connectingPass.KeyPress += new KeyPressEventHandler(connectingPass_KeyPress);
        }

        void connectingPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                loginButton.PerformClick();
            }
        }

        void vatsimID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                loginButton.PerformClick();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (vatsimID.Text == string.Empty)
            {
                MessageBox.Show("VATSIM ID is blank! Please enter your VATSIM ID.");
            }
            else if (connectingPass.Text == string.Empty)
            {
                MessageBox.Show("Password is blank! Please enter your password.");
            }
            else
            {
                /*Password encryptor code...
                MD5CryptoServiceProvider userPass = new MD5CryptoServiceProvider();
                byte[] data = Encoding.ASCII.GetBytes(connectingPass.Text);
                data = userPass.ComputeHash(data);
                string passwordHash = Encoding.ASCII.GetString(data);
                MessageBox.Show(passwordHash);*/
                MessageBox.Show("LOGGED IN!");
                this.Close();
            }
        }

        private void vatsimID_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectingPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
