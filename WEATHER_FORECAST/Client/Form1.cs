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
        Socket client;
        Thread ketnoi;
        public void KetNoiDenServer()
        {
            /*
            IP = new IPEndPoint(IPAddress.Parse("172.16.1.48"), 62000);

            

            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            */

            ipe = new IPEndPoint(IPAddress.Parse("172.16.1.48"), 12345);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            client.Connect(ipe);

            Thread langnghe = new Thread(LangNgheDuLieu);
            langnghe.IsBackground = true;
            langnghe.Start(client);



            /*
            Thread listen = new Thread(receive);
            listen.IsBackground = true;
            listen.Start();
            */
        }

        public void LangNgheDuLieu(object obj)
        {
            Socket sk = (Socket)obj;
            while (true)
            {
                byte[] buff = new byte[1024];
                int recv = client.Receive(buff);
            }
        }


        /*
        void receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)derserialize(data);
                    AddMessage(message);
                }
            }
            catch
            {
                Close();
            }
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);

        }
        */
        private void f1_connect_Click(object sender, EventArgs e)
        {
            // dieu kien ip va port
            { 
            }

            /*
            // chuyển chuỗi ký tự thành biến kiểu int
            //var serverPort = int.Parse(f1_port.Text);
            //var serverIP = long.Parse(f1_ipAddress.Text);
            var serverIP = long.Parse("172.16.1.48");
            var serverPort = 8080;

            // đây là "địa chỉ" của tiến trình server trên mạng
            // mỗi endpoint chứa ip của host và port của tiến trình
            var serverEndpoint = new IPEndPoint(serverIP, serverPort);

            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm            

            // khởi tạo object của lớp socket để sử dụng dịch vụ Tcp
            // lưu ý SocketType của Tcp là Stream 
            var client = new Socket(SocketType.Stream, ProtocolType.Tcp); // giai quyet tao bien socket toan cuc
            // tạo kết nối tới Server
            client.Connect(serverEndpoint);
            */

            /*
            IPAddress[] IPs = Dns.GetHostAddresses(f1_ipAddress.Text);
            
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);


            client.Connect(IPs[0], int.Parse(f1_port.Text));
            */
            ketnoi = new Thread(new ThreadStart(KetNoiDenServer));
            ketnoi.IsBackground = true;
            ketnoi.Start();
            /*
            // ktra ket noi den server
            bool flag = true; // flag dua tren tinh trang cua socket
            if (flag == false) // ket noi fail
            {
                string message = "Fail to connect to server !\nPlease retry.";
                string title = "Message Box";
                MessageBox.Show(message, title);
            }
            else // ket noi thanh cong
            {
                string message = "Connect to server successfully !";
                string title = "Message Box";
                MessageBox.Show(message, title);

                // chuyen den form 2
                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();

                this.Show();
            }
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
