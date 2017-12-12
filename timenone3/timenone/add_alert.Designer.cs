namespace timenone
{
    partial class add_alert
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
            this.label3 = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.clean = new System.Windows.Forms.Button();
            this.h = new System.Windows.Forms.ComboBox();
            this.m = new System.Windows.Forms.ComboBox();
            this.days = new System.Windows.Forms.CheckedListBox();
            this.Enable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชั่วโมง";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "นาที";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "บันทึก";
            // 
            // note
            // 
            this.note.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.note.Location = new System.Drawing.Point(100, 150);
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(121, 26);
            this.note.TabIndex = 5;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(32, 344);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 6;
            this.save.Text = "บันทึก";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(193, 344);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(75, 23);
            this.clean.TabIndex = 7;
            this.clean.Text = "ล้าง";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // h
            // 
            this.h.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.h.FormattingEnabled = true;
            this.h.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.h.Location = new System.Drawing.Point(100, 58);
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(121, 28);
            this.h.TabIndex = 8;
            // 
            // m
            // 
            this.m.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.m.FormattingEnabled = true;
            this.m.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.m.Location = new System.Drawing.Point(100, 100);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(121, 28);
            this.m.TabIndex = 9;
            // 
            // days
            // 
            this.days.FormattingEnabled = true;
            this.days.HorizontalScrollbar = true;
            this.days.Items.AddRange(new object[] {
            "วันอาทิตย์",
            "วันจันทร์",
            "วันอังคาร",
            "วันพุธ",
            "วันพฤหัสบดี",
            "วันศุกร์",
            "วันเสาร์"});
            this.days.Location = new System.Drawing.Point(83, 192);
            this.days.Name = "days";
            this.days.Size = new System.Drawing.Size(134, 109);
            this.days.TabIndex = 12;
            // 
            // Enable
            // 
            this.Enable.AutoSize = true;
            this.Enable.Location = new System.Drawing.Point(110, 308);
            this.Enable.Name = "Enable";
            this.Enable.Size = new System.Drawing.Size(57, 17);
            this.Enable.TabIndex = 13;
            this.Enable.Text = "ใช้งาน";
            this.Enable.UseVisualStyleBackColor = true;
            // 
            // add_alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 379);
            this.Controls.Add(this.Enable);
            this.Controls.Add(this.days);
            this.Controls.Add(this.m);
            this.Controls.Add(this.h);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.save);
            this.Controls.Add(this.note);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "add_alert";
            this.Text = "เพิ่มการแจ้งเตือน";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.add_alert_FormClosing);
            this.Load += new System.EventHandler(this.add_alert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.ComboBox h;
        private System.Windows.Forms.ComboBox m;
        private System.Windows.Forms.CheckedListBox days;
        private System.Windows.Forms.CheckBox Enable;
    }
}