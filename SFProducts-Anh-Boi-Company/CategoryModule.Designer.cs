namespace SFProducts_Anh_Boi_Company
{
    partial class CategoryModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryModule));
            this.pnlhead = new System.Windows.Forms.Panel();
            this.btnCloseCategory = new System.Windows.Forms.Button();
            this.lblhead = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveCat = new System.Windows.Forms.Button();
            this.btnUpdateCat = new System.Windows.Forms.Button();
            this.btnClearCat = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.pnlhead.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlhead
            // 
            this.pnlhead.BackColor = System.Drawing.Color.Salmon;
            this.pnlhead.Controls.Add(this.btnCloseCategory);
            this.pnlhead.Controls.Add(this.lblhead);
            this.pnlhead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlhead.Location = new System.Drawing.Point(0, 0);
            this.pnlhead.Margin = new System.Windows.Forms.Padding(4);
            this.pnlhead.Name = "pnlhead";
            this.pnlhead.Size = new System.Drawing.Size(413, 36);
            this.pnlhead.TabIndex = 3;
            // 
            // btnCloseCategory
            // 
            this.btnCloseCategory.FlatAppearance.BorderSize = 0;
            this.btnCloseCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseCategory.Image")));
            this.btnCloseCategory.Location = new System.Drawing.Point(375, 3);
            this.btnCloseCategory.Name = "btnCloseCategory";
            this.btnCloseCategory.Size = new System.Drawing.Size(20, 20);
            this.btnCloseCategory.TabIndex = 3;
            this.btnCloseCategory.UseVisualStyleBackColor = true;
            this.btnCloseCategory.Click += new System.EventHandler(this.btnCloseCategory_Click);
            // 
            // lblhead
            // 
            this.lblhead.AutoSize = true;
            this.lblhead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhead.ForeColor = System.Drawing.Color.White;
            this.lblhead.Location = new System.Drawing.Point(4, 7);
            this.lblhead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhead.Name = "lblhead";
            this.lblhead.Size = new System.Drawing.Size(150, 20);
            this.lblhead.TabIndex = 2;
            this.lblhead.Text = "Manage Category";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(110, 61);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(245, 20);
            this.txtCategoryName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Category Name:";
            // 
            // btnSaveCat
            // 
            this.btnSaveCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSaveCat.FlatAppearance.BorderSize = 0;
            this.btnSaveCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCat.Location = new System.Drawing.Point(110, 113);
            this.btnSaveCat.Name = "btnSaveCat";
            this.btnSaveCat.Size = new System.Drawing.Size(70, 27);
            this.btnSaveCat.TabIndex = 6;
            this.btnSaveCat.Text = "Save";
            this.btnSaveCat.UseVisualStyleBackColor = false;
            this.btnSaveCat.Click += new System.EventHandler(this.btnSaveCat_Click);
            // 
            // btnUpdateCat
            // 
            this.btnUpdateCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnUpdateCat.FlatAppearance.BorderSize = 0;
            this.btnUpdateCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCat.Location = new System.Drawing.Point(198, 113);
            this.btnUpdateCat.Name = "btnUpdateCat";
            this.btnUpdateCat.Size = new System.Drawing.Size(70, 27);
            this.btnUpdateCat.TabIndex = 7;
            this.btnUpdateCat.Text = "Update";
            this.btnUpdateCat.UseVisualStyleBackColor = false;
            this.btnUpdateCat.Click += new System.EventHandler(this.btnUpdateCat_Click);
            // 
            // btnClearCat
            // 
            this.btnClearCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClearCat.FlatAppearance.BorderSize = 0;
            this.btnClearCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCat.Location = new System.Drawing.Point(285, 113);
            this.btnClearCat.Name = "btnClearCat";
            this.btnClearCat.Size = new System.Drawing.Size(70, 27);
            this.btnClearCat.TabIndex = 8;
            this.btnClearCat.Text = "Clear";
            this.btnClearCat.UseVisualStyleBackColor = false;
            this.btnClearCat.Click += new System.EventHandler(this.btnClearCat_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 127);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 9;
            this.lblID.Text = "ID";
            this.lblID.Visible = false;
            // 
            // CategoryModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 152);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnClearCat);
            this.Controls.Add(this.btnUpdateCat);
            this.Controls.Add(this.btnSaveCat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.pnlhead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoryModule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryModule";
            this.pnlhead.ResumeLayout(false);
            this.pnlhead.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlhead;
        private System.Windows.Forms.Button btnCloseCategory;
        private System.Windows.Forms.Label lblhead;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSaveCat;
        public System.Windows.Forms.Button btnUpdateCat;
        public System.Windows.Forms.Button btnClearCat;
        public System.Windows.Forms.Label lblID;
        public System.Windows.Forms.TextBox txtCategoryName;
    }
}