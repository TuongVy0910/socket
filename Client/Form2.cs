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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Data.Common;

namespace Client
{
    public partial class Form2 : Form
    {
        public Socket client = null;

        public Form2()
        {
            InitializeComponent();
        }

        public string serverIP = "";
        public string port = "";
        public bool b_admin = false;
        public bool cancel = false;

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
            port = form1.getPort();
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
            Send(1, "|" + textBox_user.Text + "|" + textBox_password.Text);

            // receive
            string ans = "";
            ans = Receive();

            if (ans.StartsWith("1"))          // dang nhap thanh cong
            {
                string message = "Welcome !";
                string title = "Message Box";
                MessageBox.Show(message, title);
                this.Hide();
            }
            else if (ans.StartsWith("0"))           // dang nhap that bai
            {
                string message = "Username or Password wrong !";
                label_warn.Text = message;
            }
            else
            {
                string message = "Receive none !";
                label_warn.Text = message;
            }
        }

        string Receive()
        {
            try
            {
                //while(true)
                //{
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    // adding

                    return message;
                //}
            }
            catch
            {
                // ???

            }

            return "";
        }

        void Send(int x, string str)
        {
            
            client.Send(Serialize(x.ToString() + str));
        
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
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

            Send(2, "|" + textBox_user.Text + "|" + textBox_password.Text);

            // receive
            string ans = "";
            ans = Receive();

            if (ans.StartsWith("1"))          // dang ky thanh cong
            {
                string message = "Registered successfully !";
                string title = "Message Box";
                MessageBox.Show(message, title);
            }
            else if (ans.StartsWith("0"))           // dang ky that bai
            {
                string message = "Username existed !";
                label_warn.Text = message;
            }
            else
            {
                string message = "Receive none !";
                label_warn.Text = message;
            }
        }

        private void textBox_user_TextChanged(object sender, EventArgs e)
        {
            //if (textBox_user.Text == "" || textBox_password.Text == "")
            //{
            //    button_Admin.Enabled = false;
            //    button_ok.Enabled = false;
            //    button_register.Enabled = false;
            //}
            //else
            //{
            //    button_Admin.Enabled = true;
            //    button_ok.Enabled = true;
            //    button_register.Enabled = true;
            //}
        }

        private void button_Admin_Click(object sender, EventArgs e)
        {
            Send(0, "|" + textBox_user.Text + "|" + textBox_password.Text);

            // receive
            string ans = "";
            ans = Receive();

            if (ans.StartsWith("1"))          // dang nhap thanh cong
            {
                string message = "Entered admin mode !";
                string title = "Message Box";
                MessageBox.Show(message, title);
                b_admin = true;
                this.Hide();
            }
            else if (ans.StartsWith("0"))           // dang nhap that bai
            {
                string message = "Username or Password wrong !";
                label_warn.Text = message;
            }
            else
            {
                string message = "Receive none !";
                label_warn.Text = message;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            // send close to server
            Send(3, "|disconnect");
            cancel = true;
            client.Close();
            this.Close();
        }
    }
}
