namespace Demo_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_Send = new System.Windows.Forms.TextBox();
            this.Connection = new System.Windows.Forms.TextBox();
            this.Send_B = new System.Windows.Forms.Button();
            this.Show = new System.Windows.Forms.ListBox();
            this.Path_Info = new System.Windows.Forms.TextBox();
            this.Info = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Pic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Show_Image = new System.Windows.Forms.Button();
            this.Ask_File = new System.Windows.Forms.Button();
            this.Image_C = new System.Windows.Forms.Button();
            this.ComrPress = new System.Windows.Forms.Button();
            this.DecomPress = new System.Windows.Forms.Button();
            this.Ddompress_I = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.Color.Black;
            this.Connect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Connect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Connect.Location = new System.Drawing.Point(566, 12);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(107, 141);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(548, 420);
            this.listBox1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(243, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Connection_State";
            // 
            // Text_Send
            // 
            this.Text_Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Text_Send.Location = new System.Drawing.Point(12, 446);
            this.Text_Send.Multiline = true;
            this.Text_Send.Name = "Text_Send";
            this.Text_Send.Size = new System.Drawing.Size(452, 34);
            this.Text_Send.TabIndex = 10;
            // 
            // Connection
            // 
            this.Connection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Connection.Location = new System.Drawing.Point(12, 492);
            this.Connection.Multiline = true;
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(225, 29);
            this.Connection.TabIndex = 11;
            // 
            // Send_B
            // 
            this.Send_B.BackColor = System.Drawing.Color.Black;
            this.Send_B.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Send_B.Location = new System.Drawing.Point(470, 446);
            this.Send_B.Name = "Send_B";
            this.Send_B.Size = new System.Drawing.Size(90, 34);
            this.Send_B.TabIndex = 9;
            this.Send_B.Text = "Send";
            this.Send_B.UseVisualStyleBackColor = false;
            this.Send_B.Click += new System.EventHandler(this.Send_B_Click);
            // 
            // Show
            // 
            this.Show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Show.FormattingEnabled = true;
            this.Show.ItemHeight = 16;
            this.Show.Location = new System.Drawing.Point(877, 12);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(453, 388);
            this.Show.TabIndex = 13;
            // 
            // Path_Info
            // 
            this.Path_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Path_Info.Location = new System.Drawing.Point(877, 406);
            this.Path_Info.Multiline = true;
            this.Path_Info.Name = "Path_Info";
            this.Path_Info.Size = new System.Drawing.Size(378, 34);
            this.Path_Info.TabIndex = 10;
            // 
            // Info
            // 
            this.Info.BackColor = System.Drawing.Color.Black;
            this.Info.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Info.Location = new System.Drawing.Point(1258, 406);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(72, 34);
            this.Info.TabIndex = 14;
            this.Info.Text = "Info";
            this.Info.UseVisualStyleBackColor = false;
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.Black;
            this.Clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Clear.Location = new System.Drawing.Point(879, 446);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(260, 34);
            this.Clear.TabIndex = 15;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(679, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "Send File";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pic
            // 
            this.Pic.BackColor = System.Drawing.Color.Black;
            this.Pic.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Pic.Location = new System.Drawing.Point(679, 12);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(93, 43);
            this.Pic.TabIndex = 17;
            this.Pic.Text = "Browse";
            this.Pic.UseVisualStyleBackColor = false;
            this.Pic.Click += new System.EventHandler(this.Pic_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox1.Location = new System.Drawing.Point(565, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 362);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Show_Image
            // 
            this.Show_Image.BackColor = System.Drawing.Color.Black;
            this.Show_Image.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Show_Image.Location = new System.Drawing.Point(1240, 446);
            this.Show_Image.Name = "Show_Image";
            this.Show_Image.Size = new System.Drawing.Size(90, 34);
            this.Show_Image.TabIndex = 19;
            this.Show_Image.Text = "Ask Image";
            this.Show_Image.UseVisualStyleBackColor = false;
            this.Show_Image.Click += new System.EventHandler(this.Show_Image_Click);
            // 
            // Ask_File
            // 
            this.Ask_File.BackColor = System.Drawing.Color.Black;
            this.Ask_File.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Ask_File.Location = new System.Drawing.Point(1145, 446);
            this.Ask_File.Name = "Ask_File";
            this.Ask_File.Size = new System.Drawing.Size(89, 34);
            this.Ask_File.TabIndex = 20;
            this.Ask_File.Text = "Ask File";
            this.Ask_File.UseVisualStyleBackColor = false;
            this.Ask_File.Click += new System.EventHandler(this.Ask_File_Click);
            // 
            // Image_C
            // 
            this.Image_C.BackColor = System.Drawing.Color.Black;
            this.Image_C.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Image_C.Location = new System.Drawing.Point(778, 112);
            this.Image_C.Name = "Image_C";
            this.Image_C.Size = new System.Drawing.Size(93, 43);
            this.Image_C.TabIndex = 22;
            this.Image_C.Text = "Compress Image";
            this.Image_C.UseVisualStyleBackColor = false;
            this.Image_C.Click += new System.EventHandler(this.Image_C_Click);
            // 
            // ComrPress
            // 
            this.ComrPress.BackColor = System.Drawing.Color.Black;
            this.ComrPress.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComrPress.Location = new System.Drawing.Point(778, 12);
            this.ComrPress.Name = "ComrPress";
            this.ComrPress.Size = new System.Drawing.Size(93, 43);
            this.ComrPress.TabIndex = 21;
            this.ComrPress.Text = "Comrpress Text";
            this.ComrPress.UseVisualStyleBackColor = false;
            this.ComrPress.Click += new System.EventHandler(this.ComrPress_Click);
            // 
            // DecomPress
            // 
            this.DecomPress.BackColor = System.Drawing.Color.Black;
            this.DecomPress.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DecomPress.Location = new System.Drawing.Point(778, 62);
            this.DecomPress.Name = "DecomPress";
            this.DecomPress.Size = new System.Drawing.Size(93, 43);
            this.DecomPress.TabIndex = 21;
            this.DecomPress.Text = "Decompress Text";
            this.DecomPress.UseVisualStyleBackColor = false;
            this.DecomPress.Click += new System.EventHandler(this.DecomPress_Click);
            // 
            // Ddompress_I
            // 
            this.Ddompress_I.BackColor = System.Drawing.Color.Black;
            this.Ddompress_I.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Ddompress_I.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Ddompress_I.Location = new System.Drawing.Point(679, 112);
            this.Ddompress_I.Name = "Ddompress_I";
            this.Ddompress_I.Size = new System.Drawing.Size(93, 43);
            this.Ddompress_I.TabIndex = 22;
            this.Ddompress_I.Text = "Dcompress Image";
            this.Ddompress_I.UseVisualStyleBackColor = false;
            this.Ddompress_I.Click += new System.EventHandler(this.Ddompress_I_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1334, 537);
            this.Controls.Add(this.Ddompress_I);
            this.Controls.Add(this.Image_C);
            this.Controls.Add(this.DecomPress);
            this.Controls.Add(this.ComrPress);
            this.Controls.Add(this.Ask_File);
            this.Controls.Add(this.Show_Image);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Pic);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Path_Info);
            this.Controls.Add(this.Text_Send);
            this.Controls.Add(this.Connection);
            this.Controls.Add(this.Send_B);
            this.Controls.Add(this.Connect);
            this.Name = "Form1";
            this.Text = "Demo_client";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Text_Send;
        private System.Windows.Forms.TextBox Connection;
        private System.Windows.Forms.Button Send_B;
        private System.Windows.Forms.ListBox Show;
        private System.Windows.Forms.TextBox Path_Info;
        private System.Windows.Forms.Button Info;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Pic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Show_Image;
        private System.Windows.Forms.Button Ask_File;
        private System.Windows.Forms.Button Image_C;
        private System.Windows.Forms.Button ComrPress;
        private System.Windows.Forms.Button DecomPress;
        private System.Windows.Forms.Button Ddompress_I;
    }
}

