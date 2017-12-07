namespace WindowsFormsApp1
{
    partial class alert
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
            this.timeok = new System.Windows.Forms.Label();
            this.n = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(73, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ขณะนี้เป็นเวลา";
            // 
            // timeok
            // 
            this.timeok.AutoSize = true;
            this.timeok.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.timeok.Location = new System.Drawing.Point(92, 100);
            this.timeok.Name = "timeok";
            this.timeok.Size = new System.Drawing.Size(76, 29);
            this.timeok.TabIndex = 1;
            this.timeok.Text = "06:00";
            // 
            // n
            // 
            this.n.AutoSize = true;
            this.n.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.n.Location = new System.Drawing.Point(92, 161);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(74, 25);
            this.n.TabIndex = 2;
            this.n.Text = "ตื่นนอน";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(91, 226);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.n);
            this.Controls.Add(this.timeok);
            this.Controls.Add(this.label1);
            this.Name = "alert";
            this.Text = "alert";
            this.Load += new System.EventHandler(this.alert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeok;
        private System.Windows.Forms.Label n;
        private System.Windows.Forms.Button OK;
    }
}