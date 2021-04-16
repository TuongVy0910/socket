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


        string Receive() // unfixed
        {
            

            try
            {

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
                while(true)
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

        bool checkValidity(string date)
        {
            string year = date.Substring(0, 4);
            string month = date.Substring(5, 2);
            string day = date.Substring(8, 4);
            if (year.Length == 4 && month.Length == 2 && day.Length == 2
                && year.All(char.IsDigit) && month.All(char.IsDigit) && day.All(char.IsDigit))
                return true;
            else return false;
        }

        void warnWrongQueryMessage()
        {
            // thong bao messageBox sai query struct
            string message = "Wrong query statement !";
            string title = "Message Box";
            MessageBox.Show(message, title);
        }

        private void button1_Click(object sender, EventArgs e) // button send
        {
            string s = textBox1.Text; // chuoi duoc nhap
            string result = ""; // chuoi duoc ma hoa de gui den server
            int code = 0; // = 0 temporary


            if (s.ToLower().StartsWith("list all")) // list all
            {

                // ktr 8 ky tu dau la "list all" => ktr date valid 
                string date = s.Substring("list all".Length + 2);

                if (!checkValidity(date))
                {
                    warnWrongQueryMessage();
                    return;
                }

                code = 4;
                result = date + "|list all";
            }
            else if (s.Substring(0,3).All(char.IsDigit) && s.Substring(s.IndexOf(' ') + 1).All(char.IsLetter)) // city_id
            {
                // ktr 3 ky tu dau la so => ktr city name la alphabet
                code = 5;

                // doi space -> |
                int x = s.IndexOf(' ');
                result = s.Substring(0, x) + "|";
                x = s.IndexOf(' ', x + 1);
                result += s.Substring(x + 1);
            }
            else // invalid query struct
            {
                warnWrongQueryMessage();
                return;
            }

            // cu phap send to server
            Send(code, result);

            // hien ra man hinh cau lenh cua client
            richTextBox1.Text += "User: " + s + "\n";

            // hien ra man hinh response cua server
            // receive the hien vao richTextBox1 full string
            // lam ham addMessage if neccessary
            richTextBox1.Text += "=====================\n";
            richTextBox1.Text += Receive() + "\n";
            richTextBox1.Text += "=====================\n";

            textBox1.Clear();
        }

        private void button1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e) // query struct
        {
            if (client == null)
                this.Close();

            label1.Text = "Username: " + user;
            label4.Text = "Port: " + port;
            label3.Text = "Server's IP: " + serverIP;

            // load query struct to textBox_queryStruct
            textBox_queryStruct.Text = "Query Cities' List: [list all yyyy-mm-dd]\n" +
                "Query City's forecast: [city_id city_name]\n";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // button exist/close
        {
            // send close to server
            Send(3, "disconnect");

            client.Close();
        }
    }
}
