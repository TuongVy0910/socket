﻿using System;
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
using System.Data;



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
            string mes = @"1|yioccho|12345";
            AddMessage(mes);
            string[] split = mes.Split('|');
            foreach (string s in split)
            {
                AddMessage(s);
            }


        }
        void AddMessage(string mes)
        {
            svMess.Items.Add(mes + @"\n");

        }
       //private SqlConnection con;
        


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
              AddMessage(mes );
              string nameClient = "";
              string svRep = HandleClientRequest(mes,client,nameClient);
                    //xử lí mes
                    AddMessage(svRep );
                    if (client.Connected)
                    {
                        Send(client, svRep);
                    }
          
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

        void connectSQL(SqlConnection con)
        {
            String conString = @"Data Source=MAYCHU\SQLEXPRESS;Initial Catalog=WEATHER_FORECAST;Integrated Security=True";
            try
            {
                SqlConnection conn = new SqlConnection(conString);
                // con.Open();
                con = conn;
                MessageBox.Show("Kết nối SQL thành công", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không Kết nối tới CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //error:Username or password is not correct!You can create new account.
        bool checkLogIn(string user, string pw, string type)
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
                    {
                        // Đóng kết nối.
                        con.Close();
                        // Hủy đối tượng, giải phóng tài nguyên.
                        con.Dispose();
                        return true;
                    }

                    else
                    {
                        // Đóng kết nối.
                        con.Close();
                        // Hủy đối tượng, giải phóng tài nguyên.
                        con.Dispose();
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        bool checkSignUp(string user, string pw)
        {
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            try
            {
                string sql = "SELECT * FROM ACCOUNT WHERE _username = '" + user;
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand();

                // Liên hợp Command với Connection.
                cmd.Connection = con;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Đóng kết nối.
                        con.Close();
                        // Hủy đối tượng, giải phóng tài nguyên.
                        con.Dispose();
                        return true;
                    }

                    else
                    {
                        // Đóng kết nối.
                        con.Close();
                        // Hủy đối tượng, giải phóng tài nguyên.
                        con.Dispose();
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        void SignUpClient(string user, string pw)
        {
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            try
            {

                string sql = "insert into ACCOUNT values (@username,@password,@type)";
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@password", pw);
                cmd.Parameters.AddWithValue("@type", 0);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                con.Close();
                AddMessage(i + " Row(s) Inserted ");
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                // Đóng kết nối.
                con.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                con.Dispose();
            }

        }

        void Disconnect(ref Socket client)
        {
            clientList.Remove(client);
            client.Close();
        }

        string list_all(string date)
        {
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            string result = "";
            try
            {
                string sql = @"SELECT C._ID,C._NAME,CI.WEATHER_DATE,CI.TEMPERATURE,CI.WIND,CI.PRESSURE FROM CITY C JOIN CITY_INFO CI ON C._ID = CI.CITY_ID  WHERE CI.WEATHER_DATE = '"
                    + @date + @"'";
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand();

                // Liên hợp Command với Connection.
                cmd.Connection = con;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {


                            string ID = reader["_ID"].ToString();
                            string name = reader["_NAME"].ToString();
                            string d = reader["WEATHER_DATE"].ToString();
                            string temperature = reader["TEMPERATURE"].ToString();
                            string wind = reader["WIND"].ToString();
                            string pressure = reader["PRESSURE"].ToString();
                            result += ID + "," + name + "," + d + "," + temperature + "," + wind + "," + pressure + "|";
                        }
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result += "ERROR";
            }
            finally
            {
                // Đóng kết nối.
                con.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                con.Dispose();
            }
            return result;
        }

        string queryCity(string id,string name)
        {
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            string result = "";
            try
            {
                string sql = @"SELECT C._ID,C._NAME,CI.WEATHER_DATE,CI.TEMPERATURE,CI.WIND,CI.PRESSURE FROM CITY C JOIN CITY_INFO CI ON C._ID = CI.CITY_ID  WHERE CI._ID = '"
                    + @id + @"' and C._NAME = '" + @name + @"'";
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand();

                // Liên hợp Command với Connection.
                cmd.Connection = con;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ID = reader["_ID"].ToString();
                            string CityName = reader["_NAME"].ToString();
                            string d = reader["WEATHER_DATE"].ToString();
                            string temperature = reader["TEMPERATURE"].ToString();
                            string wind = reader["WIND"].ToString();
                            string pressure = reader["PRESSURE"].ToString();
                            result += ID + "," + CityName + "," + d + "," + temperature + "," + wind + "," + pressure + "|";
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result += "ERROR";
            }
            finally
            {
                // Đóng kết nối.
                con.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                con.Dispose();
            }
            return result;
        }
        bool checkCityID(string id)
        {
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            try
            {
                string sql = @"SELECT * FROM CITY C JOIN CITY_INFO CI ON C._ID = CI.CITY_ID  WHERE CI._ID = '"
                    + @id + @"'";
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand();

                // Liên hợp Command với Connection.
                cmd.Connection = con;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Đóng kết nối.
                        con.Close();
                        // Hủy đối tượng, giải phóng tài nguyên.
                        con.Dispose();
                        return true;
                    }

                    else
                    {
                        // Đóng kết nối.
                        con.Close();
                        // Hủy đối tượng, giải phóng tài nguyên.
                        con.Dispose();
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void AddCity(string id, string name)
        {
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            try
            {

                string sql = "insert into CITY values (@ID,@CityName,@type)";
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@CityName", name);
               
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                con.Close();
                AddMessage(i + " Row(s) Inserted ");
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                // Đóng kết nối.
                con.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                con.Dispose();
            }

        }

        void AddCurrentWeather(string row, int i)
        {

            string[] info = { "" };
            int j = 0;
            string[] split = row.Split(',');
            foreach (string s in split)
            {

                if (s.Trim() != "")
                {

                    info[j] = s;
                    j++;
                }


            }
            SqlConnection con = new SqlConnection();
            connectSQL(con);
            con.Open();
            try
            {

                string sql = @"insert into CITY_INFO values (@ID,GETDATE()+"+i.ToString()+@",@temper,@wind,@pressure)";
                // Tạo một đối tượng Command.
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", info[0]);
               
                cmd.Parameters.Add("@temper", SqlDbType.Float).Value = float.Parse(info[1]);
                cmd.Parameters.Add("@wind", SqlDbType.Float).Value = float.Parse(info[2]);
                cmd.Parameters.Add("@pressure", SqlDbType.Float).Value = float.Parse(info[3]);

                cmd.CommandType = CommandType.Text;
                int rowUp = cmd.ExecuteNonQuery();
                con.Close();
                AddMessage(rowUp + " Row(s) Inserted ");
            }
            catch
            {
                MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                // Đóng kết nối.
                con.Close();
                // Hủy đối tượng, giải phóng tài nguyên.
                con.Dispose();
            }

        }

        void Add7daysWeather(string[] rows)
        {
            int i = 1;
            foreach(string s in rows)
            {
                AddCurrentWeather(s, i);
                i++;
            }
        }
        
        string HandleClientRequest(string mes,Socket client,string name)
        {
            string[] split = mes.Split('|');
            
            string request = "";
            switch (int.Parse(split[0]))
            {
                case 0:
                    {
                        if (checkLogIn(split[1], split[2],"0"))
                        {
                            name = split[1];
                            request = "1|Admin Log in successfully";
                        }
                        else
                            request = "0|Admin Log in unsuccessfully";
                        break;
                    }
                case 1:
                    {
                        if (checkLogIn(split[1], split[2], "1"))
                        {
                            name = split[1];
                            request = "1|Client Log in successfully";
                        }
                        else
                            request = "0|Client Log in unsuccessfully";
                        break;
                    }
                case 2:
                    {
                        if (checkSignUp(split[1], split[2]))
                        {
                            SignUpClient(split[1], split[2]);
                            request = "1|Sign up successfully";
                        }
                        else request = "0|Sign up unsuccessfully";
                        break;
                    }
                case 3:
                    {
                        Disconnect(ref client);
                        request = name + " disconnect!";
                        break;
                    }
                case 4:
                    {
                        
                        request = list_all(split[1]);
                        break;
                    }
                case 5:
                    {
                        request = queryCity(split[1], split[2]);
                        break;
                    }
                case 6:
                    {
                        if (checkCityID(split[1]))
                        {
                            AddCity(split[1], split[2]);
                            request = "Added city successfully!";
                        }
                        else
                            request = "Added city unsuccessfully!";
                        break;
                    }
                case 7:
                    {
                        if (checkCityID(split[1]))
                        {
                            AddCurrentWeather(split[2],0);
                            request = "Added current weather forecast successfully!";
                        }
                        else
                            request = "Added current weather forecast unsuccessfully!";
                        break;
                    }
                case 8:
                    {
                        if (checkCityID(split[1]))
                        {
                            string[] rows = split[2].Split('-');
                            Add7daysWeather(rows);
                            request = "Added 6 days forecast successfully!";
                        }
                        else
                            request = "Added 6 days weather forecast unsuccessfully!";
                        break;
                    }
                default:
                    {
                        request = "ERROR!!!";
                        break;
                    }
                    

            }
            return request;
        }




        //string list_all(string date)
        //{
        //    SqlConnection con = new SqlConnection();
        //    connectSQL(con);
        //    con.Open();
        //    string result = "";
        //    try
        //    {
        //        string sql = @"SELECT C._ID,C._NAME,CI.WEATHER_DATE,CI.TEMPERATURE,CI.WIND,CI.PRESSURE FROM CITY C JOIN CITY_INFO CI ON C._ID = CI.CITY_ID  WHERE CI.WEATHER_DATE = '"
        //            + @date +@"'";
        //        // Tạo một đối tượng Command.
        //        SqlCommand cmd = new SqlCommand();

        //        // Liên hợp Command với Connection.
        //        cmd.Connection = con;
        //        cmd.CommandText = sql;
        //        using (DbDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    result += reader.GetString("_ID");
        //                }
        //            }

                    
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Không truy van toi CSDL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
        //    }
        //    finally
        //    {
        //        // Đóng kết nối.
        //        con.Close();
        //        // Hủy đối tượng, giải phóng tài nguyên.
        //        con.Dispose();
        //    }
        //}

        byte[] Serialize(object obj)
        {
        MemoryStream stream = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, obj);
        return stream.ToArray();
        }
        object Deserialize(byte[] data)
        {
        MemoryStream stream = new MemoryStream(data);
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