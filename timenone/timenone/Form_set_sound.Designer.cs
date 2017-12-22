namespace timenone
{
    partial class Form_set_sound
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
            this.select_file = new System.Windows.Forms.Button();
            this.save_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // select_file
            // 
            this.select_file.Location = new System.Drawing.Point(78, 63);
            this.select_file.Name = "select_file";
            this.select_file.Size = new System.Drawing.Size(124, 49);
            this.select_file.TabIndex = 0;
            this.select_file.Text = "เลือกไฟล์";
            this.select_file.UseVisualStyleBackColor = true;
            this.select_file.Click += new System.EventHandler(this.select_file_Click);
            // 
            // save_file
            // 
            this.save_file.Location = new System.Drawing.Point(88, 196);
            this.save_file.Name = "save_file";
            this.save_file.Size = new System.Drawing.Size(103, 29);
            this.save_file.TabIndex = 1;
            this.save_file.Text = "เลือกไฟล์";
            this.save_file.UseVisualStyleBackColor = true;
            this.save_file.Click += new System.EventHandler(this.save_file_Click);
            // 
            // Form_set_sound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.save_file);
            this.Controls.Add(this.select_file);
            this.Name = "Form_set_sound";
            this.Text = "Form_set_sound";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button select_file;
        private System.Windows.Forms.Button save_file;
    }
}