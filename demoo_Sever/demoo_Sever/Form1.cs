using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demoo_Sever
{
    public partial class Form1 : Form
    {
        private int size = 2000;
        private byte[] data = new byte[2000];
        Socket Server;
        Socket Client_C;
        string Global_Dir = "D:\\EDUCATION\\Collage\\level 4\\2\\Network programming\\download for NP/";

        public Form1()
        {
            InitializeComponent();
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Server.Bind(ie);
            Server.Listen(10);
            Server.BeginAccept(new AsyncCallback(Accept_call), Server);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void Accept_call(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            Socket client = server.EndAccept(ar);
            Client_C = client;
            Invoke((MethodInvoker)delegate
            {
                if (client != null)
                {
                    Connection.ForeColor = Color.Green;
                    Connection.Text = "Connection is Success";
                }
            });

            string Welcome = "Welcome to My Server ";
            byte[] Welcome_B = Encoding.UTF8.GetBytes(Welcome);

            client.BeginSend(Welcome_B, 0, Welcome_B.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }

        void Send_call(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            int se = server.EndSend(ar);
            server.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(Recieve_call), server);
        }

        void Recieve_call(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            int rec = server.EndReceive(ar);
            if (rec == 0)
            {
                server.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(Recieve_call), server);
            }
            else
            {
                string message = Encoding.UTF8.GetString(data, 0, rec);
                if (message[0] == '*')
                {
                    string s = message.Substring(1);
                    InfoShow(s, server);
                }
                else if (message[0] == '#')
                {
                    string s = message.Substring(1);
                    File_Send(s, server);
                }
                else if (message[0] == '@')
                {
                    string s = message.Substring(1);
                    Image_Send(s, server);
                }
                else if (message[0] == '!')
                {
                    string s = message.Substring(1);
                    Image_Show(s, server);
                }
                else if (message[0] == '^')
                {
                    string s = message.Substring(1);
                    File_Show(s, server);
                }
                else if (message[0] == '+')
                {
                    string s = message.Substring(1);
                    Compress_File(s, server);
                }
                else if (message[0] == '-')
                {
                    string s = message.Substring(1);
                    DeCompress_File(s, server);
                }
                else if (message[0] == '=')
                {
                    string s = message.Substring(1);
                    Compress_Image(s, server);
                }
                else if (message[0] == '|')
                {
                    string s = message.Substring(1);
                    DeCompress_Image(s, server);
                }
                else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add(message);
                    });
                    byte[] M = Encoding.UTF8.GetBytes(message);
                    server.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(Recieve_call), server);
                }
            }
        }

        private void Send_B_Click(object sender, EventArgs e)
        {
            string msg = "Server : " + Text_Send.Text;
            byte[] msg_B = Encoding.UTF8.GetBytes(msg);

            Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add(msg);
            });
            Text_Send.Clear();
            Client_C.BeginSend(msg_B, 0, msg_B.Length, SocketFlags.None, new AsyncCallback(Send_call), Client_C);
        }

        void InfoShow(string s, Socket client)
        {
            DirectoryInfo dir = new DirectoryInfo(s);
            FileInfo[] fieles = dir.GetFiles();
            DirectoryInfo[] d = dir.GetDirectories();

            if (!dir.Exists)
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes("$Directory does not exist.");
                client.BeginSend(errorBytes, 0, errorBytes.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Files: ");
            for (int i = 0; i < fieles.Length; i++)
            {
                sb.AppendLine(fieles[i].Name);
            }

            sb.AppendLine(" ");
            sb.AppendLine("Directories: ");
            for (int i = 0; i < d.Length; i++)
            {
                sb.AppendLine(d[i].Name);
            }
            string Dir_Files = "$" + sb.ToString();
            byte[] Dir_Files_B = Encoding.UTF8.GetBytes(Dir_Files);
            client.BeginSend(Dir_Files_B, 0, Dir_Files_B.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }

        void File_Send(string s, Socket client)
        {
            string A = Global_Dir;
            using ( Stream  From = new FileStream(s , FileMode.Open )) {
                string FileName = Path.GetFileName(s);
                A = A + FileName;
                using (Stream To = new FileStream(A, FileMode.Create))
                {
                    int size = 50;
                    int offset = 0;
                    byte[] data = new byte[From.Length];

                    do
                    {
                        int FF = From.Read(data, offset, Math.Min(size, (int)From.Length - offset));
                        To.Write(data, offset, FF);
                        offset += FF;
                    } while (offset < From.Length);
                }
            }
            string ss = '#'+A;
            byte[] fileData = Encoding.UTF8.GetBytes(ss);
            client.BeginSend(fileData, 0, fileData.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }
       

        void Image_Send(string s, Socket client)
        {
            string IM = Global_Dir;
            IM = IM + Path.GetFileName(s);
          
            using (FileStream Image_From = new FileStream(s, FileMode.Open, FileAccess.Read))
            {
                // Open or create the destination image file for writing as a FileStream
                using (FileStream Image_To = new FileStream(IM, FileMode.Create, FileAccess.Write))
                {
                    // Create a buffer to hold the bytes read from the source image
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Read bytes from the source image and write them to the destination image until no more bytes are read
                    while ((bytesRead = Image_From.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Image_To.Write(buffer, 0, bytesRead);
                    }
                }
            }
            string IMG = '@' + IM;
            byte[] ImageData =  Encoding.UTF8.GetBytes(IMG);
            client.BeginSend(ImageData, 0, ImageData.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }

        void Image_Show(string s, Socket client)
        {
            string IM = Global_Dir;
            IM = IM + Path.GetFileName(s);

            using (FileStream Image_From = new FileStream(s, FileMode.Open, FileAccess.Read))
            {
                // Open or create the destination image file for writing as a FileStream
                using (FileStream Image_To = new FileStream(IM, FileMode.Create, FileAccess.Write))
                {
                    // Create a buffer to hold the bytes read from the source image
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Read bytes from the source image and write them to the destination image until no more bytes are read
                    while ((bytesRead = Image_From.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Image_To.Write(buffer, 0, bytesRead);
                    }
                }
            }
            string IMG = '!' + IM;
            byte[] ImageData = Encoding.UTF8.GetBytes(IMG);
            client.BeginSend(ImageData, 0, ImageData.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }


        void File_Show(string s, Socket client)
        {
            string A = Global_Dir;
            using (Stream From = new FileStream(s, FileMode.Open))
            {
                string FileName = Path.GetFileName(s);
                A = A + FileName;
                using (Stream To = new FileStream(A, FileMode.Create))
                {
                    int size = 50;
                    int offset = 0;
                    byte[] data = new byte[From.Length];

                    do
                    {
                        int FF = From.Read(data, offset, Math.Min(size, (int)From.Length - offset));
                        To.Write(data, offset, FF);
                        offset += FF;
                    } while (offset < From.Length);
                }
            }
            string ss = '^' + A;
            byte[] fileData = Encoding.UTF8.GetBytes(ss);
            client.BeginSend(fileData, 0, fileData.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }

        void Compress_File(string s, Socket client)
        {
            string A = Global_Dir;


            GZipStream gz = new GZipStream(new FileStream(A +Path.GetFileName(s) + ".QZip.Compressed", FileMode.Create, FileAccess.Write), CompressionMode.Compress);

            FileStream FileCompress = new FileStream(s, FileMode.Open, FileAccess.Read);
            string SizeBefore = FileCompress.Length.ToString();

            Invoke((MethodInvoker)delegate
            {

            listBox1.Items.Add("Size Before Compress is : " + SizeBefore);
            
            });

            StreamWriter sw = new StreamWriter(gz);
            sw.Write(new StreamReader(FileCompress).ReadToEnd());
            sw.Flush(); sw.Close();
            //////////////////
            string SizeAfter = new FileStream(A + Path.GetFileName(s) + ".QZip.Compressed", FileMode.Open, FileAccess.Read).Length.ToString();
            Invoke((MethodInvoker)delegate
            {
            listBox1.Items.Add("Size after Compress is : " + SizeAfter);
            });

            string ss = '+' + A;
            byte[] fileData = Encoding.UTF8.GetBytes(ss);
            client.BeginSend(fileData, 0, fileData.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }
        void DeCompress_File(string s, Socket client)
        {
        
            using (FileStream CompressedFile = new FileStream(s, FileMode.Open, FileAccess.Read))
            {
                using (GZipStream Decompressed_File = new GZipStream(CompressedFile, CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(Decompressed_File))
                    {
                        string line;
                        string ss = "-";
                        while ((line = reader.ReadLine()) != null)
                        {
                            ss += line+"\n";
                        }
                            byte[] fileData = Encoding.UTF8.GetBytes(ss);
                            client.BeginSend(fileData, 0, fileData.Length, SocketFlags.None, new AsyncCallback(Send_call), client); }
                }
            }
         }
        void Compress_Image(string s, Socket client)
        {
            string A = Global_Dir;

            FileStream CompressIMage = new FileStream(A + Path.GetFileName(s) + ".QZip.BCompressed", FileMode.Create, FileAccess.Write);
            GZipStream gz = new GZipStream(CompressIMage, CompressionMode.Compress);
           
            BinaryWriter BR = new BinaryWriter(gz);
            FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read);
            string sizebefore = fs.Length.ToString();
            Invoke((MethodInvoker)delegate
            {
            listBox1.Items.Add("The Image before Compress : " + sizebefore);
            });

            BinaryReader dd = new BinaryReader(fs);

            byte[] _da = dd.ReadBytes((int)dd.BaseStream.Length);

            BR.Write(_da); BR.Flush(); BR.Close();

            string Image_after = new FileStream(A + Path.GetFileName(s) + ".QZip.BCompressed", FileMode.Open, FileAccess.Read).Length.ToString();
            Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add("The Image After Compress : " + Image_after);
            });
            
            string ss = '=' + A;
            byte[] fileData = Encoding.UTF8.GetBytes(ss);
            client.BeginSend(fileData, 0, fileData.Length, SocketFlags.None, new AsyncCallback(Send_call), client);
        }

        void DeCompress_Image(string s, Socket client)
        {
            string De = s.Substring(0, s.Length - 17); 
            string DDecompress = "D:\\EDUCATION\\Collage\\level 4\\2\\Network programming\\Lectures\\";
            string decompressedFilePath = DDecompress + Path.GetFileName(De);

           
            using (FileStream compressedImageStream = new FileStream(s, FileMode.Open, FileAccess.Read))
            {
                using (FileStream decompressedFileStream = new FileStream(decompressedFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (GZipStream gz = new GZipStream(compressedImageStream, CompressionMode.Decompress))
                    {
                        gz.CopyTo(decompressedFileStream);
                    }
                }
            }

           
            string ss = '|' + decompressedFilePath;
            byte[] fileData = Encoding.UTF8.GetBytes(ss);
            client.BeginSend(fileData, 0, fileData.Length, SocketFlags.None, new AsyncCallback(Send_call), client);

        }



    }
}
