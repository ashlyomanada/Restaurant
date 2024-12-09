namespace RestaurantManagement
{
    partial class StatusForm
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
            this.appetizerGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appetizerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appetizerGridView
            // 
            this.appetizerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appetizerGridView.Location = new System.Drawing.Point(12, 85);
            this.appetizerGridView.Name = "appetizerGridView";
            this.appetizerGridView.Size = new System.Drawing.Size(604, 233);
            this.appetizerGridView.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Order Status";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 439);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.appetizerGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatusForm";
            this.Text = "StatusForm";
            this.Load += new System.EventHandler(this.StatusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appetizerGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView appetizerGridView;
        private System.Windows.Forms.Label label5;
    }
}