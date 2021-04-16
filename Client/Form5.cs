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

        private void button_send_TextChanged(object sender, EventArgs e)
        {
            if (textBox_send.Text == "")
                textBox_send.Enabled = false;
            else
                textBox_send.Enabled = true;
        }


        private void Form5_Load(object sender, EventArgs e) //undone
        {
            if (client == null)
                this.Close();

            label_username.Text = "Username: " + user;
            label_port.Text = "Port: " + port;
            label_ip.Text = "Server's IP: " + serverIP;

            richTextBox_struct.Text = "Add city:\n" + "add city_id city_name\n"
                + "Add info for city:\n" + "add_info city_id degree,wind,pressure\n"
                + "Add info in 7 days for city:\n" + "add_7d city_id degree,wind,pressure degree,wind,pressure ...\n";
            
        }


        string Receive() // unfixed
        {
            //server gui thong bao ngung ket noi den client ??? => Tao thread ???

            try
            {
                while (true) { 
                byte[] data = new byte[1024 * 5000];
                client.Receive(data);
                
                string message = (string)Deserialize(data);

                if (message == "Server disconnected")
                {
                    client.Close();
                    this.Close();
                }

                // adding

                return message;
                }
            }
            catch
            {
                string message = "Receive none !";
                string title = "Message Box";
                MessageBox.Show(message, title);
            }

            return "";
        }

        void Send(int x, string str)
        {
            try
            {
                while (true)
                    client.Send(Serialize(x.ToString() + "|" + str));

            }
            catch
            {
                string message = "Cannot send to server !";
                string title = "Message Box";
                MessageBox.Show(message, title);
            }

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

        void warnWrongQueryMessage()
        {
            // thong bao messageBox sai query struct
            string message = "Wrong query statement !";
            string title = "Message Box";
            MessageBox.Show(message, title);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_send.Text == "")
                return;

            string s = textBox_send.Text;
            string result = ""; // chuoi duoc ma hoa de gui den server
            int code = 0; // = 0 temporary

            // extract add
            int pos = 0;
            int delim = s.IndexOf(' ', pos);
            string temp = s.Substring(pos, delim);

            if (temp == "add_7d")
            {
                code = 8;

                pos = delim + 1;
                delim = s.IndexOf(' ', pos);
                result = s.Substring(pos, delim - pos) + "|";

                while (delim != -1)
                {
                    pos = delim + 1;
                    delim = s.IndexOf(' ', pos);

                    if (delim == -1)
                        result = s.Substring(pos);
                    else
                        result = s.Substring(pos, delim - pos) + "-";
                }
            }
            else if (temp == "add_info" || temp == "add")
            {
                if (temp == "add_info")
                    code = 7;
                if (temp == "add")
                    code = 6;

                while (delim != -1)
                {
                    pos = delim + 1;
                    delim = s.IndexOf(' ', pos);

                    if (delim == -1)
                        result = s.Substring(pos);
                    else
                        result = s.Substring(pos, delim - pos) + "-";
                }
            }
            else
            {
                warnWrongQueryMessage();
                return;
            }


            // cu phap send to server
            Send(code, result);

            // hien ra man hinh cau lenh cua client
            richTextBox_message.Text += "User: " + s + "\n";

            // hien ra man hinh response cua server
            // receive the hien vao richTextBox1 full string
            // lam ham addMessage if neccessary
            richTextBox_message.Text += "=====================\n";
            richTextBox_message.Text += Receive() + "\n";
            richTextBox_message.Text += "=====================\n";

            textBox_send.Clear();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            // send close to server
            Send(3, "disconnect");

            client.Close();
        }
    }
}
