namespace WindowsFormsApp1
{
    partial class set_time_countdown
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m = new System.Windows.Forms.TextBox();
            this.s = new System.Windows.Forms.TextBox();
            this.buOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "นาที";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "วินาที";
            // 
            // m
            // 
            this.m.Location = new System.Drawing.Point(98, 59);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(100, 20);
            this.m.TabIndex = 2;
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(98, 112);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(100, 20);
            this.s.TabIndex = 3;
            // 
            // buOK
            // 
            this.buOK.Location = new System.Drawing.Point(81, 205);
            this.buOK.Name = "buOK";
            this.buOK.Size = new System.Drawing.Size(75, 23);
            this.buOK.TabIndex = 6;
            this.buOK.Text = "OK";
            this.buOK.UseVisualStyleBackColor = true;
            this.buOK.Click += new System.EventHandler(this.buOK_Click);
            // 
            // set_time_countdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buOK);
            this.Controls.Add(this.s);
            this.Controls.Add(this.m);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "set_time_countdown";
            this.Text = "set_time_countdown";
            this.Load += new System.EventHandler(this.set_time_countdown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m;
        private System.Windows.Forms.TextBox s;
        private System.Windows.Forms.Button buOK;
    }
}