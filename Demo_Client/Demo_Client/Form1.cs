using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Demo_Client
{
    public partial class Form1 : Form
    {
        private int size = 2000;
        private byte[] data = new byte[2000];
        Socket Client;
        Socket Server;

        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Client.BeginConnect(ie, new AsyncCallback(Connect_Call), Client);
        }

        private void Connect_Call(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            try
            {
                client.EndConnect(ar);
                Invoke((MethodInvoker)delegate
                {
                    Connection.Text = "Connect Successfully";
                    Connection.ForeColor = Color.Green;
                });

                client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(Recieve_Call), client);
            }
            catch (SocketException)
            {
                Invoke((MethodInvoker)delegate
                {
                    Connection.Text = "Failed";
                    Connection.ForeColor = Color.Red;
                });
            }
        }

        private void Recieve_Call(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            int rec = client.EndReceive(ar);
            if (rec == 0)
            {
                client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(Recieve_Call), client);
            }
            else
            {
                string SS = Encoding.UTF8.GetString(data, 0, rec);
                if (SS[0] == '$')
                {
                    string S = SS.Substring(1);
                    string[] lines = S.Split(new[] { "\n" }, StringSplitOptions.None);
                    Invoke((MethodInvoker)delegate
                    {
                        Show.Items.Clear();
                        foreach (string line in lines)
                        {
                            Show.Items.Add(line);
                        }
                    });
                }
                else if (SS[0] == '#')
                {
                    string F = SS.Substring(1);  
                    Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add("File received saved to: " + F);
                    });
                }
                else if (SS[0] == '+')
                {
                    string F = SS.Substring(1);
                    Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add("File Compressed saved to: " + F);
                    });
                }
                else if (SS[0] == '=')
                {
                    string F = SS.Substring(1);
                    Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add("Image Compressed saved to: " + F);
                    });
                }
                else if (SS[0] == '-')
                {
                    string F = SS.Substring(1);
                    string[] lines = F.Split(new[] { "\n" }, StringSplitOptions.None);
                    Invoke((MethodInvoker)delegate
                    {
                        Show.Items.Clear();
                        foreach (string line in lines)
                        {
                            Show.Items.Add(line);
                        }
                    });
                }
                else if (SS[0] == '@')
                { 
                    string IImage = SS.Substring(1);
                   Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add("Image received saved to: " + IImage);
                    });
                }
                else if (SS[0] == '!')
                {

                    string IImage = SS.Substring(1);
                    Invoke((MethodInvoker)delegate
                    {
                     pictureBox1.Image=Image.FromFile(IImage);
                    });

                   
                }
                else if (SS[0] == '|')
                {
                    // Extract the image bytes
                    string File_I = SS.Substring(1);

                    
                    Invoke((MethodInvoker)delegate
                    {
                       
                            pictureBox1.Image = Image.FromFile(File_I);
                        
                    });


                }
                else if (SS[0] == '^')
                {

                    string File_P = SS.Substring(1);
                   

                    using (Stream FF = new FileStream(File_P, FileMode.Open))
                    {
                        int x;
                        String S = "";
                        do
                        {
                            x = FF.ReadByte();
                            S += (char)x;
                        } while (x > -1);
                        string[] lines = S.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        Invoke((MethodInvoker)delegate
                        {
                            Show.Items.Clear();
                            foreach (string line in lines)
                            {
                                Show.Items.Add(line);
                            }
                        });
                        

                    }


                }
                else
                {
                    Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Add(SS);
                    });
                    client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(Recieve_Call), client);
                }
            }
        }

        private void Send_Call(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            int rec = client.EndSend(ar);
            client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(Recieve_Call), client);
        }

        private void Send_B_Click(object sender, EventArgs e)
        {
            string Massage = "Client : " + Text_Send.Text;
            byte[] Massage_B = Encoding.UTF8.GetBytes(Massage);

            Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add(Massage);
            });
            Text_Send.Clear();
            Client.BeginSend(Massage_B, 0, Massage_B.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
        }

        private void Info_Click(object sender, EventArgs e)
        {
            Show.Items.Clear();
            if (Path_Info.Text != "")
            {
                string Slash = @"\";
                string fileName = "*" + Path_Info.Text + Slash;
                byte[] fileName_B = Encoding.UTF8.GetBytes(fileName);
                Client.BeginSend(fileName_B, 0, fileName_B.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
            else
            {
                MessageBox.Show("Error the path is empty  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
   
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Show.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string FilePath = "#"+openFileDialog.FileName;
              
                byte[] File_Byte = Encoding.UTF8.GetBytes(FilePath);
                Client.BeginSend(File_Byte, 0, File_Byte.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
        }
     

        private void Pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            { 
                string  PicPath =  "@"+openFileDialog.FileName;
               byte[] Pic_Byte = Encoding.UTF8.GetBytes(PicPath); 
                Client.BeginSend(Pic_Byte, 0, Pic_Byte.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Show_Image_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            if (Path_Info.Text!="")
            {
            string Image_Path = '!' + Path_Info.Text;
            byte[] Image_Byte = Encoding.UTF8.GetBytes(Image_Path);
            Client.BeginSend(Image_Byte, 0, Image_Byte.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
            else
            {
                MessageBox.Show("Error the path is empty  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ask_File_Click(object sender, EventArgs e)
        {
            Show.Items.Clear();
            if (Path_Info.Text != "")
            {
                string File_Path = '^' + Path_Info.Text;
                byte[] File_B = Encoding.UTF8.GetBytes(File_Path);
                Client.BeginSend(File_B, 0, File_B.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
            else
            {
                MessageBox.Show("Error the path is empty  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComrPress_Click(object sender, EventArgs e)
        {
            string C = Path_Info.Text;
            if (C != "")
            {
                string Compress_Path = "+" + C;
                byte[] File_C = Encoding.UTF8.GetBytes(Compress_Path);
                Client.BeginSend(File_C, 0, File_C.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
            else
            {
                MessageBox.Show("Error the path is empty  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecomPress_Click(object sender, EventArgs e)
        {
            string C = Path_Info.Text;
            if (C != "")
            {
                string DECompress_Path = "-" + C;
                byte[] File_C = Encoding.UTF8.GetBytes(DECompress_Path);
                Client.BeginSend(File_C, 0, File_C.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
            else
            {
                MessageBox.Show("Error the path is empty  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Image_C_Click(object sender, EventArgs e)
        {
            string C = Path_Info.Text;
            if (C != "")
            {
                string DECompress_Path = "=" + C;
                byte[] File_C = Encoding.UTF8.GetBytes(DECompress_Path);
                Client.BeginSend(File_C, 0, File_C.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
            else
            {
                MessageBox.Show("Error the path is empty  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ddompress_I_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            string C = Path_Info.Text;
            if (C != "")
            {
                string DECompress_Path = "|" + C;
                byte[] File_C = Encoding.UTF8.GetBytes(DECompress_Path);
                Client.BeginSend(File_C, 0, File_C.Length, SocketFlags.None, new AsyncCallback(Send_Call), Client);
            }
            else
            {
                MessageBox.Show("Error the path is empty  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
