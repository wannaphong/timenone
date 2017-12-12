namespace timenone
{
    partial class edit_alert
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.update = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.add_alert_bn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(795, 360);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(403, 34);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(116, 34);
            this.update.TabIndex = 1;
            this.update.Text = "อัพเดตข้อมูล";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // del
            // 
            this.del.Location = new System.Drawing.Point(260, 34);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(114, 34);
            this.del.TabIndex = 2;
            this.del.Text = "ลบการแจ้งเตือน";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // add_alert_bn
            // 
            this.add_alert_bn.Location = new System.Drawing.Point(105, 34);
            this.add_alert_bn.Name = "add_alert_bn";
            this.add_alert_bn.Size = new System.Drawing.Size(128, 34);
            this.add_alert_bn.TabIndex = 3;
            this.add_alert_bn.Text = "เพิ่มการแจ้งเตือน";
            this.add_alert_bn.UseVisualStyleBackColor = true;
            this.add_alert_bn.Click += new System.EventHandler(this.add_alert_bn_Click);
            // 
            // edit_alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 437);
            this.Controls.Add(this.add_alert_bn);
            this.Controls.Add(this.del);
            this.Controls.Add(this.update);
            this.Controls.Add(this.dataGridView1);
            this.Name = "edit_alert";
            this.Text = "แก้ไขการแจ้งเตือน";
            this.Load += new System.EventHandler(this.edit_alert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button add_alert_bn;
    }
}