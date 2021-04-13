using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Socket client = null;
        public string serverIP = "";
        public string port = "";
        public bool b_admin = false;

        public string getIPAddress()
        {
            return serverIP;
        }

        public string getPort()
        {
            return port;
        }

        public Socket getSocket()
        {
            return client;
        }

        public bool getAdmin()
        {
            return b_admin;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            client = form1.getSocket();

            if (client == null)
                this.Close();

            serverIP = form1.getIPAddress();
            label_ip.Text = "Server's IP: " + serverIP;
            label_port.Text = "Port: " + port;
        }

        public string getUser()
        {
            return textBox_user.Text;
        }

        private void button_ok_Click(object sender, EventArgs e) // client button
        {
            // gui id pw den server
            // nhan ket qua cua server

            string s1 = textBox_user.Text;
            string s2 = textBox_password.Text;
            byte[] msg = Encoding.UTF8.GetBytes(1.ToString() + "|" + s1 + "|" + s2);
            byte[] bytes = new byte[256];
            string reply = "";


            /*
            if (SendReceiveAccount(1))          // dang nhap thanh cong
            {
                string message = "Welcom !";
                string title = "Message Box";
                MessageBox.Show(message, title);
            }
            else            // dang nhap that bai
            {
                string message = "Username or Password wrong !";
                label_warn.Text = message;
            }
            */

            int i = client.Send(msg);

            // Get reply from the server.
            i = client.Receive(bytes);
            reply = (Encoding.UTF8.GetString(bytes));

        }

        public bool SendReceiveAccount(int x)
        {
            string s1 = textBox_user.Text;
            string s2 = textBox_password.Text;
            byte[] msg = Encoding.UTF8.GetBytes(x.ToString() + "|" + s1 + "|" + s2);
            byte[] bytes = new byte[256];
            string reply = "";

            try
            {
                // Blocks until send returns.
                int i = client.Send(msg);

                // Get reply from the server.
                i = client.Receive(bytes);
                reply = (Encoding.UTF8.GetString(bytes));

                if (reply == "SUCCESS") // server response
                    return true;
                else
                    return false;
            }
            catch (SocketException e)
            {
                //Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                //return false;
            }


            //byte[] buffer = new byte[1024];
            //int iRx = soc.Receive(buffer);
            //char[] chars = new char[iRx];

            //System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
            //int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
            //System.String recv = new System.String(chars);

            return false;
        }

        private void checkBox_password_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_password.Checked)
                textBox_password.UseSystemPasswordChar = false;
            else
                textBox_password.UseSystemPasswordChar = true;
        }

        private void label_ip_Click(object sender, EventArgs e)
        {

        }

        private void button_register_Click(object sender, EventArgs e)
        { 
            // gui id pw den server
            // nhan ket qua cua server
            if (SendReceiveAccount(2))          // dang ky thanh cong
            {
                string message = "Entered admin mode !";
                string title = "Message Box";
                MessageBox.Show(message, title);

                b_admin = true;
            }
            else            // dang ky that bai
            {
                string message = "Username existed !";
                label_warn.Text = message;
            }
            
        }

        private void textBox_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Admin_Click(object sender, EventArgs e)
        {
            // gui id pw den server
            // nhan ket qua cua server
            if (SendReceiveAccount(0))          // dang nhap admin-mode thanh cong
            {
                string message = "Registered successfully !";
                string title = "Message Box";
                MessageBox.Show(message, title);
            }
            else            // dang nhap that bai
            {
                string message = "Username or password wrong !";
                label_warn.Text = message;
            }
        }
    }
}
