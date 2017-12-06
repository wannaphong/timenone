namespace WindowsFormsApp1
{
    partial class Timer_system
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
            this.show_time = new System.Windows.Forms.Label();
            this.bnStart = new System.Windows.Forms.Button();
            this.bnStop = new System.Windows.Forms.Button();
            this.bnP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // show_time
            // 
            this.show_time.AutoSize = true;
            this.show_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.show_time.Location = new System.Drawing.Point(88, 44);
            this.show_time.Name = "show_time";
            this.show_time.Size = new System.Drawing.Size(96, 25);
            this.show_time.TabIndex = 0;
            this.show_time.Text = "00:00:00";
            // 
            // bnStart
            // 
            this.bnStart.Location = new System.Drawing.Point(44, 95);
            this.bnStart.Name = "bnStart";
            this.bnStart.Size = new System.Drawing.Size(75, 23);
            this.bnStart.TabIndex = 1;
            this.bnStart.Text = "เริ่มใหม่";
            this.bnStart.UseVisualStyleBackColor = true;
            this.bnStart.Click += new System.EventHandler(this.bnStart_Click);
            // 
            // bnStop
            // 
            this.bnStop.Location = new System.Drawing.Point(182, 95);
            this.bnStop.Name = "bnStop";
            this.bnStop.Size = new System.Drawing.Size(75, 23);
            this.bnStop.TabIndex = 2;
            this.bnStop.Text = "หยุด";
            this.bnStop.UseVisualStyleBackColor = true;
            this.bnStop.Click += new System.EventHandler(this.bnStop_Click);
            // 
            // bnP
            // 
            this.bnP.Location = new System.Drawing.Point(101, 115);
            this.bnP.Name = "bnP";
            this.bnP.Size = new System.Drawing.Size(75, 23);
            this.bnP.TabIndex = 3;
            this.bnP.Text = "หยุดชั่วคราว";
            this.bnP.UseVisualStyleBackColor = true;
            this.bnP.Click += new System.EventHandler(this.bnP_Click);
            // 
            // Timer_system
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 150);
            this.Controls.Add(this.bnP);
            this.Controls.Add(this.bnStop);
            this.Controls.Add(this.bnStart);
            this.Controls.Add(this.show_time);
            this.Name = "Timer_system";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer_system";
            this.Load += new System.EventHandler(this.Timer_system_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label show_time;
        private System.Windows.Forms.Button bnStart;
        private System.Windows.Forms.Button bnStop;
        private System.Windows.Forms.Button bnP;
    }
}