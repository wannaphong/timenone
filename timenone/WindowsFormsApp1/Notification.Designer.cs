namespace WindowsFormsApp1
{
    partial class Notification
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
            this.event_time = new System.Windows.Forms.Label();
            this.time_this = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // event_time
            // 
            this.event_time.AutoSize = true;
            this.event_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.event_time.Location = new System.Drawing.Point(77, 61);
            this.event_time.Name = "event_time";
            this.event_time.Size = new System.Drawing.Size(60, 24);
            this.event_time.TabIndex = 0;
            this.event_time.Text = "label1";
            // 
            // time_this
            // 
            this.time_this.AutoSize = true;
            this.time_this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.time_this.Location = new System.Drawing.Point(77, 110);
            this.time_this.Name = "time_this";
            this.time_this.Size = new System.Drawing.Size(60, 24);
            this.time_this.TabIndex = 1;
            this.time_this.Text = "label1";
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.time_this);
            this.Controls.Add(this.event_time);
            this.Name = "Notification";
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.Notification_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label event_time;
        private System.Windows.Forms.Label time_this;
    }
}