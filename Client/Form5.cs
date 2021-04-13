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
    public partial class Form5 : Form
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

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
