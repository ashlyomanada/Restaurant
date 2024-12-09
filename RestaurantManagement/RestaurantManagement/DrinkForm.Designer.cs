namespace RestaurantManagement
{
    partial class DrinkForm
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
            this.totalPrice = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.appetizerGridView = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appetizerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalPrice
            // 
            this.totalPrice.AutoSize = true;
            this.totalPrice.Location = new System.Drawing.Point(550, 361);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(28, 13);
            this.totalPrice.TabIndex = 44;
            this.totalPrice.Text = "0.00";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(550, 339);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(28, 13);
            this.total.TabIndex = 43;
            this.total.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Total Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Total Item:";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DeleteBtn.Location = new System.Drawing.Point(384, 299);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(56, 28);
            this.DeleteBtn.TabIndex = 40;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // appetizerGridView
            // 
            this.appetizerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appetizerGridView.Location = new System.Drawing.Point(381, 129);
            this.appetizerGridView.Name = "appetizerGridView";
            this.appetizerGridView.Size = new System.Drawing.Size(240, 150);
            this.appetizerGridView.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "JOHN DOE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(377, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Customer’s Name :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(364, 415);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(380, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "Drinks Menu";
            // 
            // DrinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 439);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.appetizerGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DrinkForm";
            this.Text = "DrinkForm";
            this.Load += new System.EventHandler(this.DrinkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appetizerGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.DataGridView appetizerGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
    }
}