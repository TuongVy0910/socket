using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // connect toi server
            Form2 form2 = new Form2();

            Application.Run(form2);
            if (form2.getAdmin() == false)
            {
                Form4 form4 = new Form4();
                form4.setSocket(form2.getSocket(), form2.getIPAddress(), form2.getPort(), form2.getUser());
                form4.ShowDialog();
            }
            else
            {
                Form5 form5 = new Form5();
                form5.setSocket(form2.getSocket(), form2.getIPAddress(), form2.getPort(), form2.getUser());
                form5.ShowDialog();
            }
                
            
            // dang nhap

            // client / admin

            // truy van toi server

            // ket thuc chuong trinh
        }
    }


    public partial class Client : Form
    {
        public Client()
        {
                
        }
    }
}

/* test console
using System;
using System.Net;

 * public class GFG
{

    static public void Main()
    {

        // Get the Background and foreground 
        // color of Console Using BackgroundColor
        // and ForegroundColor property of Console
        IPAddress[] IPs = Dns.GetHostAddresses("172.16.1.48");
        Console.WriteLine("haha\n {0}",IPs[1]);
        Console.WriteLine("haha\n {0}", Dns.GetHostAddresses("172.16.1.48"));


     
    }
}*/