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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // svListen
            // 
            this.svListen.Location = new System.Drawing.Point(432, 331);
            this.svListen.Name = "svListen";
            this.svListen.Size = new System.Drawing.Size(100, 25);
            this.svListen.TabIndex = 3;
            this.svListen.Text = "Listen";
            this.svListen.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(468, 290);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // SERVER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 368);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.svListen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SERVER";
            this.Text = "SERVER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SERVER_FormClosed);
            this.Load += new System.EventHandler(this.SERVER_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button svListen;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

