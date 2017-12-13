namespace timenone
{
    partial class FirstCustomControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.add = new System.Windows.Forms.Button();
            this.timenow = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(377, 288);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(115, 34);
            this.add.TabIndex = 4;
            this.add.Text = "เพิ่มการแจ้งเตือน";
            this.add.UseVisualStyleBackColor = true;
            // 
            // timenow
            // 
            this.timenow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timenow.AutoSize = true;
            this.timenow.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.timenow.Location = new System.Drawing.Point(325, 100);
            this.timenow.Name = "timenow";
            this.timenow.Size = new System.Drawing.Size(158, 55);
            this.timenow.TabIndex = 3;
            this.timenow.Text = "label1";
            this.timenow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FirstCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.add);
            this.Controls.Add(this.timenow);
            this.Name = "FirstCustomControl";
            this.Size = new System.Drawing.Size(817, 423);
            this.Load += new System.EventHandler(this.FirstCustomControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label timenow;
        private System.Windows.Forms.Timer timer1;
    }
}
