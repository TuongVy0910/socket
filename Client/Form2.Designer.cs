namespace Client
{
    partial class Form2
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
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_port = new System.Windows.Forms.Label();
            this.label_ip = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.label_password = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.checkBox_password = new System.Windows.Forms.CheckBox();
            this.label_warn = new System.Windows.Forms.Label();
            this.button_register = new System.Windows.Forms.Button();
            this.button_Admin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(281, 316);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(80, 23);
            this.button_cancel.TabIndex = 25;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(22, 53);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(34, 17);
            this.label_port.TabIndex = 24;
            this.label_port.Text = "Port";
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(22, 22);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(76, 17);
            this.label_ip.TabIndex = 23;
            this.label_ip.Text = "Server\'s IP";
            this.label_ip.Click += new System.EventHandler(this.label_ip_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(208, 316);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(47, 23);
            this.button_ok.TabIndex = 22;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(22, 166);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(69, 17);
            this.label_password.TabIndex = 21;
            this.label_password.Text = "Password";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(22, 118);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(73, 17);
            this.label_user.TabIndex = 20;
            this.label_user.Text = "Username";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(118, 161);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(190, 22);
            this.textBox_password.TabIndex = 19;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(118, 113);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(190, 22);
            this.textBox_user.TabIndex = 18;
            this.textBox_user.TextChanged += new System.EventHandler(this.textBox_user_TextChanged);
            // 
            // checkBox_password
            // 
            this.checkBox_password.AutoSize = true;
            this.checkBox_password.Location = new System.Drawing.Point(49, 211);
            this.checkBox_password.Name = "checkBox_password";
            this.checkBox_password.Size = new System.Drawing.Size(128, 21);
            this.checkBox_password.TabIndex = 26;
            this.checkBox_password.Text = "Show password";
            this.checkBox_password.UseVisualStyleBackColor = true;
            this.checkBox_password.CheckedChanged += new System.EventHandler(this.checkBox_password_CheckedChanged);
            // 
            // label_warn
            // 
            this.label_warn.AutoSize = true;
            this.label_warn.ForeColor = System.Drawing.Color.Red;
            this.label_warn.Location = new System.Drawing.Point(46, 258);
            this.label_warn.Name = "label_warn";
            this.label_warn.Size = new System.Drawing.Size(0, 17);
            this.label_warn.TabIndex = 27;
            // 
            // button_register
            // 
            this.button_register.Location = new System.Drawing.Point(49, 316);
            this.button_register.Name = "button_register";
            this.button_register.Size = new System.Drawing.Size(75, 23);
            this.button_register.TabIndex = 28;
            this.button_register.Text = "Register";
            this.button_register.UseVisualStyleBackColor = true;
            this.button_register.Click += new System.EventHandler(this.button_register_Click);
            // 
            // button_Admin
            // 
            this.button_Admin.Location = new System.Drawing.Point(208, 267);
            this.button_Admin.Name = "button_Admin";
            this.button_Admin.Size = new System.Drawing.Size(75, 23);
            this.button_Admin.TabIndex = 29;
            this.button_Admin.Text = "Admin";
            this.button_Admin.UseVisualStyleBackColor = true;
            this.button_Admin.Click += new System.EventHandler(this.button_Admin_Click);
            // 
            // Form2
            // 
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(393, 366);
            this.Controls.Add(this.button_Admin);
            this.Controls.Add(this.button_register);
            this.Controls.Add(this.label_warn);
            this.Controls.Add(this.checkBox_password);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_user);
            this.Name = "Form2";
            this.Text = "WEATHER FORECAST - Log in";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.CheckBox checkBox_password;
        private System.Windows.Forms.Label label_warn;
        private System.Windows.Forms.Button button_register;
        private System.Windows.Forms.Button button_Admin;
    }
}