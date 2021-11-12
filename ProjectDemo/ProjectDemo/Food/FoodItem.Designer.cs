namespace ProjectDemo.Food
{
    partial class FoodItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodItem));
            this.ptBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.lblNameFood = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptBox
            // 
            this.ptBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptBox.Image = ((System.Drawing.Image)(resources.GetObject("ptBox.Image")));
            this.ptBox.Location = new System.Drawing.Point(0, 0);
            this.ptBox.Name = "ptBox";
            this.ptBox.Size = new System.Drawing.Size(139, 102);
            this.ptBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptBox.TabIndex = 0;
            this.ptBox.TabStop = false;
            this.ptBox.Click += new System.EventHandler(this.ptBox_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Controls.Add(this.lblStoreName);
            this.panel1.Controls.Add(this.lblNameFood);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 69);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.ptBox_Click);
            // 
            // lblStoreName
            // 
            this.lblStoreName.AllowDrop = true;
            this.lblStoreName.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStoreName.Location = new System.Drawing.Point(6, 27);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(129, 20);
            this.lblStoreName.TabIndex = 1;
            this.lblStoreName.Text = "FPTU";
            // 
            // lblNameFood
            // 
            this.lblNameFood.AllowDrop = true;
            this.lblNameFood.AutoSize = true;
            this.lblNameFood.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameFood.Location = new System.Drawing.Point(6, 6);
            this.lblNameFood.Name = "lblNameFood";
            this.lblNameFood.Size = new System.Drawing.Size(80, 16);
            this.lblNameFood.TabIndex = 0;
            this.lblNameFood.Text = "Hamberger";
            // 
            // lblAddress
            // 
            this.lblAddress.AllowDrop = true;
            this.lblAddress.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddress.Location = new System.Drawing.Point(3, 49);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(129, 20);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "FPTU";
            // 
            // FoodItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "FoodItem";
            this.Size = new System.Drawing.Size(139, 171);
            ((System.ComponentModel.ISupportInitialize)(this.ptBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNameFood;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label lblAddress;
    }
}
