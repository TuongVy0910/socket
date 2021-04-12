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
using System.Data.SqlClient;
using System.Data.Common;


namespace Server
{
    public partial class SERVER : Form
    {
        public SERVER()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
            
        }
        IPEndPoint ipe;
        Socket server;
        List<Socket> clientList=new List<Socket>();
        
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
       //private SqlConnection con;
        void connectSQL(SqlConnection con)
        {
            String conString = @"Data Source=MAYCHU\SQLEXPRESS;Initial Catalog=WEATHER_FORECAST;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(conString);
                // con.Open();
                con = conn;
                MessageBox.Show("Kết nối SQL thành công","Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không Kết nối tới CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //error:Username or password is not correct!You can create new account.
        bool checkLogIn(string user,string pw,string type)
        {
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            try
            {
                string sql = "SELECT * FROM ACCOUNT WHERE _username = '" + user + "' AND _password = '" + pw + "' AND _type = " + type;
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand();

                // Liên hợp Command với Connection.
                cmd.Connection = con;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                        return true;
                    else return false;
                }
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Đóng kết nối.
                con.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                con.Dispose();
            }
        }






        
    void Connect(int n)
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
          server.Listen(n);
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
            GetIP();
    }
    });
    Listen.IsBackground = true;
    Listen.Start();

    }
        void Send(Socket client,string mes)
        {
            client.Send(Serialize(mes));
        }

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
                    string mes1="";          //xử lí mes
          Send(client, mes1);
                    AddMessage(mes1);
                    //return mes;
                }
        }
        catch
        {
        clientList.Remove(client);
        client.Close();
               // return "exists";
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

        private void svListen_Click(object sender, EventArgs e)
        {
            int num = int.Parse(numClient.Text.ToString());
            Connect(num);

        }
    }
}
