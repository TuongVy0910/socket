namespace Server
{
    partial class SERVER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SERVER));
            this.svListen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.svMess = new System.Windows.Forms.ListBox();
            this.numClient = new System.Windows.Forms.TextBox();
            this.svClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // svListen
            // 
            this.svListen.Location = new System.Drawing.Point(358, 319);
            this.svListen.Name = "svListen";
            this.svListen.Size = new System.Drawing.Size(100, 25);
            this.svListen.TabIndex = 3;
            this.svListen.Text = "Listen";
            this.svListen.UseVisualStyleBackColor = true;
            this.svListen.Click += new System.EventHandler(this.svListen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(25, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of clients can connect";
            // 
            // svMess
            // 
            this.svMess.FormattingEnabled = true;
            this.svMess.Location = new System.Drawing.Point(28, 21);
            this.svMess.Name = "svMess";
            this.svMess.Size = new System.Drawing.Size(500, 277);
            this.svMess.TabIndex = 6;
            // 
            // numClient
            // 
            this.numClient.Location = new System.Drawing.Point(198, 322);
            this.numClient.Name = "numClient";
            this.numClient.Size = new System.Drawing.Size(154, 20);
            this.numClient.TabIndex = 7;
            // 
            // svClose
            // 
            this.svClose.Location = new System.Drawing.Point(468, 319);
            this.svClose.Name = "svClose";
            this.svClose.Size = new System.Drawing.Size(75, 23);
            this.svClose.TabIndex = 8;
            this.svClose.Text = "Close";
            this.svClose.UseVisualStyleBackColor = true;
            this.svClose.Click += new System.EventHandler(this.svClose_Click);
            // 
            // SERVER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 368);
            this.Controls.Add(this.svClose);
            this.Controls.Add(this.numClient);
            this.Controls.Add(this.svMess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.svListen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SERVER";
            this.Text = "SERVER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SERVER_FormClosed);
            this.Load += new System.EventHandler(this.SERVER_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button svListen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox svMess;
        private System.Windows.Forms.TextBox numClient;
        private System.Windows.Forms.Button svClose;
    }
}

