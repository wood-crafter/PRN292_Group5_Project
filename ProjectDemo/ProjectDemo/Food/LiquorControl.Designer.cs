namespace ProjectDemo.Food
{
    partial class LiquorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiquorControl));
            this.pnResultSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnType = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnBeer = new System.Windows.Forms.Button();
            this.btnWine = new System.Windows.Forms.Button();
            this.pnType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnResultSearch
            // 
            this.pnResultSearch.AutoScroll = true;
            this.pnResultSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnResultSearch.Location = new System.Drawing.Point(317, 21);
            this.pnResultSearch.Name = "pnResultSearch";
            this.pnResultSearch.Size = new System.Drawing.Size(474, 392);
            this.pnResultSearch.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Order Liquor, delivery from 20\'...";
            // 
            // pnType
            // 
            this.pnType.BackColor = System.Drawing.Color.Transparent;
            this.pnType.Controls.Add(this.btnAll);
            this.pnType.Controls.Add(this.btnBeer);
            this.pnType.Controls.Add(this.btnWine);
            this.pnType.Location = new System.Drawing.Point(10, 134);
            this.pnType.Name = "pnType";
            this.pnType.Size = new System.Drawing.Size(289, 279);
            this.pnType.TabIndex = 9;
            // 
            // btnAll
            // 
            this.btnAll.AutoSize = true;
            this.btnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAll.Location = new System.Drawing.Point(3, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(69, 29);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(233, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 31);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(10, 71);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(224, 31);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.Text = "Please enter the liquor name.";
            // 
            // btnBeer
            // 
            this.btnBeer.AutoSize = true;
            this.btnBeer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBeer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBeer.Location = new System.Drawing.Point(78, 3);
            this.btnBeer.Name = "btnBeer";
            this.btnBeer.Size = new System.Drawing.Size(69, 29);
            this.btnBeer.TabIndex = 2;
            this.btnBeer.Text = "Beer";
            this.btnBeer.UseVisualStyleBackColor = true;
            this.btnBeer.Click += new System.EventHandler(this.btnBeer_Click);
            // 
            // btnWine
            // 
            this.btnWine.AutoSize = true;
            this.btnWine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWine.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWine.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWine.Location = new System.Drawing.Point(153, 3);
            this.btnWine.Name = "btnWine";
            this.btnWine.Size = new System.Drawing.Size(69, 29);
            this.btnWine.TabIndex = 3;
            this.btnWine.Text = "Wine";
            this.btnWine.UseVisualStyleBackColor = true;
            this.btnWine.Click += new System.EventHandler(this.btnWine_Click);
            // 
            // LiquorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.pnResultSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "LiquorControl";
            this.Size = new System.Drawing.Size(801, 435);
            this.pnType.ResumeLayout(false);
            this.pnType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnResultSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel pnType;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnBeer;
        private System.Windows.Forms.Button btnWine;
    }
}
