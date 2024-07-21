namespace demoo_Sever
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_Send = new System.Windows.Forms.TextBox();
            this.Connection = new System.Windows.Forms.TextBox();
            this.Send_B = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(25, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(471, 388);
            this.listBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(260, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Connection_State";
            // 
            // Text_Send
            // 
            this.Text_Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Text_Send.Location = new System.Drawing.Point(25, 401);
            this.Text_Send.Multiline = true;
            this.Text_Send.Name = "Text_Send";
            this.Text_Send.Size = new System.Drawing.Size(375, 34);
            this.Text_Send.TabIndex = 5;
            // 
            // Connection
            // 
            this.Connection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Connection.Location = new System.Drawing.Point(25, 441);
            this.Connection.Multiline = true;
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(229, 28);
            this.Connection.TabIndex = 6;
            // 
            // Send_B
            // 
            this.Send_B.Location = new System.Drawing.Point(406, 401);
            this.Send_B.Name = "Send_B";
            this.Send_B.Size = new System.Drawing.Size(90, 34);
            this.Send_B.TabIndex = 4;
            this.Send_B.Text = "Send";
            this.Send_B.UseVisualStyleBackColor = true;
            this.Send_B.Click += new System.EventHandler(this.Send_B_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(541, 490);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text_Send);
            this.Controls.Add(this.Connection);
            this.Controls.Add(this.Send_B);
            this.Name = "Form1";
            this.Text = "Demo_Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Text_Send;
        private System.Windows.Forms.TextBox Connection;
        private System.Windows.Forms.Button Send_B;
    }
}

