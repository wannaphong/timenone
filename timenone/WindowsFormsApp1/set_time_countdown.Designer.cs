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
            this.h = new System.Windows.Forms.TextBox();
            this.m = new System.Windows.Forms.TextBox();
            this.s = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // h
            // 
            this.h.Location = new System.Drawing.Point(95, 36);
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(100, 20);
            this.h.TabIndex = 2;
            // 
            // m
            // 
            this.m.Location = new System.Drawing.Point(95, 89);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(100, 20);
            this.m.TabIndex = 3;
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(95, 145);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(100, 20);
            this.s.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // buOK
            // 
            this.buOK.Location = new System.Drawing.Point(81, 205);
            this.buOK.Name = "buOK";
            this.buOK.Size = new System.Drawing.Size(75, 23);
            this.buOK.TabIndex = 6;
            this.buOK.Text = "OK";
            this.buOK.UseVisualStyleBackColor = true;
            // 
            // set_time_countdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buOK);
            this.Controls.Add(this.s);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m);
            this.Controls.Add(this.h);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "set_time_countdown";
            this.Text = "set_time_countdown";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox h;
        private System.Windows.Forms.TextBox m;
        private System.Windows.Forms.TextBox s;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buOK;
    }
}