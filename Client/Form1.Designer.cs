namespace Client
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
            this.f1_connect = new System.Windows.Forms.Button();
            this.f1_ipAddress = new System.Windows.Forms.Label();
            this.f1_port = new System.Windows.Forms.Label();
            this.f1_ipAddress_textBox = new System.Windows.Forms.TextBox();
            this.f1_port_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // f1_connect
            // 
            this.f1_connect.Location = new System.Drawing.Point(417, 60);
            this.f1_connect.Name = "f1_connect";
            this.f1_connect.Size = new System.Drawing.Size(78, 23);
            this.f1_connect.TabIndex = 0;
            this.f1_connect.Text = "Connect";
            this.f1_connect.UseVisualStyleBackColor = true;
            this.f1_connect.Click += new System.EventHandler(this.f1_connect_Click);
            // 
            // f1_ipAddress
            // 
            this.f1_ipAddress.AutoSize = true;
            this.f1_ipAddress.Location = new System.Drawing.Point(28, 27);
            this.f1_ipAddress.Name = "f1_ipAddress";
            this.f1_ipAddress.Size = new System.Drawing.Size(76, 17);
            this.f1_ipAddress.TabIndex = 1;
            this.f1_ipAddress.Text = "IP Address";
            // 
            // f1_port
            // 
            this.f1_port.AutoSize = true;
            this.f1_port.Location = new System.Drawing.Point(273, 27);
            this.f1_port.Name = "f1_port";
            this.f1_port.Size = new System.Drawing.Size(34, 17);
            this.f1_port.TabIndex = 2;
            this.f1_port.Text = "Port";
            // 
            // f1_ipAddress_textBox
            // 
            this.f1_ipAddress_textBox.Location = new System.Drawing.Point(31, 60);
            this.f1_ipAddress_textBox.Name = "f1_ipAddress_textBox";
            this.f1_ipAddress_textBox.Size = new System.Drawing.Size(201, 22);
            this.f1_ipAddress_textBox.TabIndex = 3;
            this.f1_ipAddress_textBox.TextChanged += new System.EventHandler(this.f1_ipAddress_textBox_TextChanged);
            // 
            // f1_port_textBox
            // 
            this.f1_port_textBox.Location = new System.Drawing.Point(276, 60);
            this.f1_port_textBox.Name = "f1_port_textBox";
            this.f1_port_textBox.Size = new System.Drawing.Size(100, 22);
            this.f1_port_textBox.TabIndex = 4;
            this.f1_port_textBox.TextChanged += new System.EventHandler(this.f1_port_textBox_TextChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.f1_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 117);
            this.Controls.Add(this.f1_port_textBox);
            this.Controls.Add(this.f1_ipAddress_textBox);
            this.Controls.Add(this.f1_port);
            this.Controls.Add(this.f1_ipAddress);
            this.Controls.Add(this.f1_connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button f1_connect;
        private System.Windows.Forms.Label f1_ipAddress;
        private System.Windows.Forms.Label f1_port;
        private System.Windows.Forms.TextBox f1_ipAddress_textBox;
        private System.Windows.Forms.TextBox f1_port_textBox;
    }
}