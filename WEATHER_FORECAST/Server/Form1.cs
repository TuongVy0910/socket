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
            Connect();
            
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
           

           
        }
        /*
        public void listen()
        {
            AddMessage("bat dau\n");

            server.Bind(ipe);
            svMess.Text += "tao bind\n";

            server.Listen(10);
            svMess.Text += ipe.ToString();
            svMess.Text += server.ToString();

            while (true)
            {
                Socket sk= server.Accept();
                svMess.Text +="sau khi accept\n";

                clientList.Add(sk);
                Thread clientProcess = new Thread(myThreadClient);
                clientProcess.IsBackground = true;
                clientProcess.Start(sk);
                
                svMess.Text += "chayy toi day r ne";
                //string s = "connected!";
                //AddMessage(s);
                svMess.Text+= "connected";
            }
        }
        public void myThreadClient(object obj)
        {
            svMess.Text += "chayy toi mythreadclient";
            svMess.Text += g_count.ToString();
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
        */
        void AddMessage(string mes)
        {
            svMess.Items.Add(mes);

        }






        
    void Connect()
    {
                GetIP();
    //ipe = new IPEndPoint(IPAddress.Parse("172.16.1.48"), 62000);
    clientList = new List<Socket>();
    //server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
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
          Thread recieve = new Thread(Recieve());
          recieve.IsBackground = true;
          recieve.Start(client);
          AddMessage("Client connected!");
      }
    }
    catch
    {
            GetIP();
    }
    });
    Listen.IsBackground = true;
    Listen.Start();

    }
//void Send(Socket client )
//{

//}

        string Recieve(object obj)
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
                    return mes;
        }
        }
        catch
        {
        clientList.Remove(client);
        client.Close();
                return "exists";
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
            }
}
