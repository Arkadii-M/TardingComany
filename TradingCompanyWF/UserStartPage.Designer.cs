namespace TradingCompanyWF
{
    partial class UserStartPage
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
            this.UserName = new System.Windows.Forms.Label();
            this.MyPageButton = new System.Windows.Forms.Button();
            this.OrderHistoryButton = new System.Windows.Forms.Button();
            this.CatalogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello,";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(70, 34);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(35, 13);
            this.UserName.TabIndex = 1;
            this.UserName.Text = "Name";
            // 
            // MyPageButton
            // 
            this.MyPageButton.Location = new System.Drawing.Point(12, 62);
            this.MyPageButton.Name = "MyPageButton";
            this.MyPageButton.Size = new System.Drawing.Size(75, 23);
            this.MyPageButton.TabIndex = 2;
            this.MyPageButton.Text = "MyPage";
            this.MyPageButton.UseVisualStyleBackColor = true;
            this.MyPageButton.Click += new System.EventHandler(this.MyPageButton_Click);
            // 
            // OrderHistoryButton
            // 
            this.OrderHistoryButton.Location = new System.Drawing.Point(213, 70);
            this.OrderHistoryButton.Name = "OrderHistoryButton";
            this.OrderHistoryButton.Size = new System.Drawing.Size(141, 23);
            this.OrderHistoryButton.TabIndex = 3;
            this.OrderHistoryButton.Text = "Order History";
            this.OrderHistoryButton.UseVisualStyleBackColor = true;
            this.OrderHistoryButton.Click += new System.EventHandler(this.OrderHistoryButton_Click);
            // 
            // CatalogButton
            // 
            this.CatalogButton.Location = new System.Drawing.Point(213, 34);
            this.CatalogButton.Name = "CatalogButton";
            this.CatalogButton.Size = new System.Drawing.Size(141, 23);
            this.CatalogButton.TabIndex = 4;
            this.CatalogButton.Text = "View Catalog";
            this.CatalogButton.UseVisualStyleBackColor = true;
            this.CatalogButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserStartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 105);
            this.Controls.Add(this.CatalogButton);
            this.Controls.Add(this.OrderHistoryButton);
            this.Controls.Add(this.MyPageButton);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label1);
            this.Name = "UserStartPage";
            this.Text = "UserStartPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Button MyPageButton;
        private System.Windows.Forms.Button OrderHistoryButton;
        private System.Windows.Forms.Button CatalogButton;
    }
}