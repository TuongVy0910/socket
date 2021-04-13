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
    public partial class Form4 : Form
    {
        public Socket client = null;
        public string serverIP = "";
        public string port = "";
        public string user = "";
        public void setSocket(Socket socket, string sip, string p, string u)
        {
            client = socket;
            serverIP = sip;
            port = p;
            user = u;
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            int n = 4;
            byte[] msg = Encoding.UTF8.GetBytes(n.ToString() + "|" + s); // cu phap
            byte[] bytes = new byte[256];
            string reply = "";

            try
            {
                // Blocks until send returns.
                int i = client.Send(msg);

                // Get reply from the server.
                i = client.Receive(bytes);
                reply = (Encoding.UTF8.GetString(bytes));

                // xu ly chuoi
            }
            catch (SocketException x)
            {
                //Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode);
                //return false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (client == null)
                this.Close();

            label1.Text = "Username: " + user;
            label4.Text = "Port: " + port;
            label3.Text = "Server's IP: " + serverIP;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Close();
        }
    }
}
