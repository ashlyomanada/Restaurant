namespace RestaurantManagement
{
    partial class adminFoodForm
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
            this.lblcategory = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Foods";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblcategory
            // 
            this.lblcategory.AutoSize = true;
            this.lblcategory.BackColor = System.Drawing.Color.White;
            this.lblcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcategory.Location = new System.Drawing.Point(7, 132);
            this.lblcategory.Name = "lblcategory";
            this.lblcategory.Size = new System.Drawing.Size(72, 18);
            this.lblcategory.TabIndex = 2;
            this.lblcategory.Text = "Category:";
            this.lblcategory.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtFoodName
            // 
            this.txtFoodName.Location = new System.Drawing.Point(100, 70);
            this.txtFoodName.Multiline = true;
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(197, 29);
            this.txtFoodName.TabIndex = 6;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.White;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(3, 81);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(91, 18);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "Food Name:";
            this.lblname.Click += new System.EventHandler(this.lblname_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.White;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(16, 183);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(46, 18);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Price:";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(100, 126);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(190, 24);
            this.cbCategory.TabIndex = 11;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(100, 172);
            this.txtPrice.Multiline = true;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(190, 29);
            this.txtPrice.TabIndex = 10;
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.BackColor = System.Drawing.Color.White;
            this.lblDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescrip.Location = new System.Drawing.Point(7, 242);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(87, 18);
            this.lblDescrip.TabIndex = 5;
            this.lblDescrip.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 231);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(190, 29);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescrip_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Add Foods";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(26, 384);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 35);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(107, 384);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 35);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(205, 384);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 35);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.txtImage);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnUploadImage);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnDelete);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtFoodName);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnEdit);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnAdd);
            this.guna2CustomGradientPanel1.Controls.Add(this.label5);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtDescription);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblDescrip);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtPrice);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbCategory);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblPrice);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblname);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblcategory);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(328, 497);
            this.guna2CustomGradientPanel1.TabIndex = 12;
            this.guna2CustomGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2CustomGradientPanel1_Paint);
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(100, 291);
            this.txtImage.Multiline = true;
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(190, 29);
            this.txtImage.TabIndex = 16;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(10, 274);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(75, 46);
            this.btnUploadImage.TabIndex = 14;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(370, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 497);
            this.panel1.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(469, 441);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // adminFoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(855, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminFoodForm";
            this.Text = "adminFoodForm";
            this.Load += new System.EventHandler(this.adminFoodForm_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcategory;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.DataGridView dataGridView1;
    }


}