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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        //public static Socket client;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void f1_ipAddress_textBox_TextChanged(object sender, EventArgs e)
        {
            if (f1_ipAddress_textBox.Text != "" && f1_port_textBox.Text != "")
                f1_connect.Enabled = true;
            else
                f1_connect.Enabled = false;
        }

        private void f1_port_textBox_TextChanged(object sender, EventArgs e)
        {
            if (f1_port_textBox.Text != "" && f1_ipAddress_textBox.Text != "")
                f1_connect.Enabled = true;
            else
                f1_connect.Enabled = false;
        }

        IPEndPoint ipe;
        //Thread ketnoi;
        public Socket client = null;


        public Socket getSocket()
        {
            return client;
        }

        public string getIPAddress()
        {
            return f1_ipAddress_textBox.Text;
        }
        public string getPort()
        {
            return f1_port_textBox.Text;
        }

        public bool KetNoiDenServer()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(f1_ipAddress_textBox.Text);
                Int32 port = Int32.Parse(f1_port_textBox.Text);
                ipe = new IPEndPoint(ipAddress, port);

                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                client.Connect(ipe);
            }
            catch (SocketException e)
            {
                return false;
            }


            return true;
        }

        private void f1_connect_Click(object sender, EventArgs e)
        {
            /*
            ketnoi = new Thread(new ThreadStart(KetNoiDenServer));
            ketnoi.IsBackground = true;
            ketnoi.Start();
            */

            if (!KetNoiDenServer())
            {
                string message = "Cannot connect to server";
                string title = "Message Box";
                MessageBox.Show(message, title);
            }
            else
                this.Hide();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
