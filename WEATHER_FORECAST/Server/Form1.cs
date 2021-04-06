using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Server
{
    public partial class SERVER : Form
    {
        public SERVER()
        {
            InitializeComponent();
           // CheckForIllegalCrossThreadCalls = false;
            //Connect();
            
        }
        IPEndPoint ipe;
        Socket server;
        List<Socket> clientList=new List<Socket>();
        Thread xuliClient;
        string myIP = "";
        int g_count = 0;
    
        private void SERVER_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }
        public void GetIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress addr in host.AddressList)
            {
                if (addr.AddressFamily.ToString() == "InterNetwork")
                    myIP = addr.ToString();
            }
            //AddMessage(myIP);
            ipe = new IPEndPoint(IPAddress.Parse(myIP), 12345);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

        }
        void close()
        {
            server.Close();
        }

        private void SERVER_Load(object sender, EventArgs e)
        {
            GetIP();

            xuliClient = new Thread(new ThreadStart(listen));
            xuliClient.IsBackground = true;
            xuliClient.Start();
        }
        public void listen()
        {
            richTextBox1.Text = "bat dau\n";

            server.Bind(ipe);
            richTextBox1.Text += "tao bind\n";

            server.Listen(10);
            richTextBox1.Text += ipe.ToString();
            richTextBox1.Text += server.ToString();

            while (true)
            {
                Socket sk= server.Accept();
                richTextBox1.Text +="sau khi accept\n";

                clientList.Add(sk);
                Thread clientProcess = new Thread(myThreadClient);
                clientProcess.IsBackground = true;
                clientProcess.Start(sk);
                clientProcess.Join();
                richTextBox1.Text += "chayy toi day r ne";
                //string s = "connected!";
                //AddMessage(s);
                richTextBox1.Text+= "connected";
            }
        }
        public void myThreadClient(object obj)
        {
            richTextBox1.Text += "chayy toi mythreadclient";
            richTextBox1.Text += g_count.ToString();
            g_count++; 

           Socket clientSK = (Socket)obj;
            //while (true)
            //{
            //    byte[] buff = new byte[1024];
            //    int recv = clientSK.Receive(buff);
            //    foreach (Socket sk in clientList)
            //    {
            //        sk.Send(buff, buff.Length, SocketFlags.None);
            //    }
            //}
        }
        //void AddMessage(string mes)
        //{
        //    lsvMess.Items.Add(new ListViewItem() { Text = mes });

        //}

        private void lsvMess_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        /*
void Connect()
{
ipe = new IPEndPoint(IPAddress.Parse("172.16.1.48"), 62000);
clientList = new List<Socket>();
server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
server.Bind(ipe);
//server.Listen(100);
//Socket client = server.Accept();
//AddMessage("Client connected!");


Thread Listen = new Thread(() => {
try
{
  while (true)
  {
      server.Listen(100);
      Socket client = server.Accept();
      clientList.Add(client);
      Thread recieve = new Thread(Recieve);
      recieve.IsBackground = true;
      recieve.Start(client);
      AddMessage("Client connected!");
  }
}
catch
{
  ipe = new IPEndPoint(IPAddress.Parse("172.16.1.48"), 62000);
  server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
}
});
Listen.IsBackground = true;
Listen.Start();

}
//void Send(Socket client )
//{

//}

void Recieve(object obj)
{
Socket client = obj as Socket;

try
{
while (true)
{
  byte[] recv = new byte[1024 * 4000];
  client.Receive(recv);
  string mes = (string)Deserialize(recv);
  AddMessage(mes);
}
}
catch
{
clientList.Remove(client);
client.Close();
}

}
byte[] Serialize(object obj)
{
MemoryStream stream = new MemoryStream();
BinaryFormatter formatter = new BinaryFormatter();
formatter.Serialize(stream, obj);
return stream.ToArray();
}
object Deserialize(byte[] data)
{
MemoryStream stream = new MemoryStream();
BinaryFormatter formatter = new BinaryFormatter();

return formatter.Deserialize(stream);

}



*/

    }
}
