namespace Client
{
    partial class Form5
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
            this.label_port = new System.Windows.Forms.Label();
            this.label_ip = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.richTextBox_message = new System.Windows.Forms.RichTextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.richTextBox_struct = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(22, 35);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(34, 17);
            this.label_port.TabIndex = 26;
            this.label_port.Text = "Port";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(22, 18);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(76, 17);
            this.label_ip.TabIndex = 25;
            this.label_ip.Text = "Server\'s IP";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(25, 52);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(73, 17);
            this.label_username.TabIndex = 27;
            this.label_username.Text = "Username";
            // 
            // richTextBox_message
            // 
            this.richTextBox_message.Location = new System.Drawing.Point(24, 89);
            this.richTextBox_message.Name = "richTextBox_message";
            this.richTextBox_message.Size = new System.Drawing.Size(665, 331);
            this.richTextBox_message.TabIndex = 28;
            this.richTextBox_message.Text = "";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(614, 442);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 29;
            this.button_send.Text = "SEND";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(614, 46);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 30;
            this.button_exit.Text = "EXIT";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(24, 442);
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.Size = new System.Drawing.Size(571, 22);
            this.textBox_send.TabIndex = 31;
            // 
            // richTextBox_struct
            // 
            this.richTextBox_struct.Location = new System.Drawing.Point(708, 18);
            this.richTextBox_struct.Name = "richTextBox_struct";
            this.richTextBox_struct.ReadOnly = true;
            this.richTextBox_struct.Size = new System.Drawing.Size(242, 446);
            this.richTextBox_struct.TabIndex = 32;
            this.richTextBox_struct.Text = "";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 489);
            this.Controls.Add(this.richTextBox_struct);
            this.Controls.Add(this.textBox_send);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.richTextBox_message);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.label_ip);
            this.Name = "Form5";
            this.Text = "WEATHER FORECAST - ADMIN";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.RichTextBox richTextBox_message;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.RichTextBox richTextBox_struct;
    }
}