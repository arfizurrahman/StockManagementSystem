namespace StockManagementSystem.UI
{
    partial class SetupItemUI
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
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.companyComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.reorderTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.la = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesAndSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vIewSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category:";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(143, 30);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(165, 24);
            this.categoryComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company name:";
            // 
            // companyComboBox
            // 
            this.companyComboBox.FormattingEnabled = true;
            this.companyComboBox.Location = new System.Drawing.Point(143, 62);
            this.companyComboBox.Name = "companyComboBox";
            this.companyComboBox.Size = new System.Drawing.Size(165, 24);
            this.companyComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item name:";
            // 
            // itemTextBox
            // 
            this.itemTextBox.Location = new System.Drawing.Point(143, 94);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(165, 22);
            this.itemTextBox.TabIndex = 5;
            this.itemTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reorder level:";
            // 
            // reorderTextBox
            // 
            this.reorderTextBox.Location = new System.Drawing.Point(143, 126);
            this.reorderTextBox.Name = "reorderTextBox";
            this.reorderTextBox.Size = new System.Drawing.Size(165, 22);
            this.reorderTextBox.TabIndex = 7;
            this.reorderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(205, 160);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(103, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.messageLabel);
            this.groupBox1.Controls.Add(this.companyComboBox);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.reorderTextBox);
            this.groupBox1.Controls.Add(this.categoryComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.itemTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(53, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 239);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Setup";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(140, 207);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 16);
            this.messageLabel.TabIndex = 9;
            // 
            // la
            // 
            this.la.AutoSize = true;
            this.la.Location = new System.Drawing.Point(277, 49);
            this.la.Name = "la";
            this.la.Size = new System.Drawing.Size(32, 13);
            this.la.TabIndex = 10;
            this.la.Text = "User:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(319, 49);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(0, 13);
            this.userNameLabel.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.salesAndSummaryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(425, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupCategoryToolStripMenuItem,
            this.setupCompanyToolStripMenuItem,
            this.setupItemToolStripMenuItem});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // setupCategoryToolStripMenuItem
            // 
            this.setupCategoryToolStripMenuItem.Name = "setupCategoryToolStripMenuItem";
            this.setupCategoryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.setupCategoryToolStripMenuItem.Text = "Setup Category";
            this.setupCategoryToolStripMenuItem.Click += new System.EventHandler(this.setupCategoryToolStripMenuItem_Click);
            // 
            // setupCompanyToolStripMenuItem
            // 
            this.setupCompanyToolStripMenuItem.Name = "setupCompanyToolStripMenuItem";
            this.setupCompanyToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.setupCompanyToolStripMenuItem.Text = "Setup Company";
            this.setupCompanyToolStripMenuItem.Click += new System.EventHandler(this.setupCompanyToolStripMenuItem_Click);
            // 
            // setupItemToolStripMenuItem
            // 
            this.setupItemToolStripMenuItem.Name = "setupItemToolStripMenuItem";
            this.setupItemToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.setupItemToolStripMenuItem.Text = "Setup Item";
            this.setupItemToolStripMenuItem.Click += new System.EventHandler(this.setupItemToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockInToolStripMenuItem,
            this.stockOutToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.stockToolStripMenuItem.Text = "Stock";
            // 
            // stockInToolStripMenuItem
            // 
            this.stockInToolStripMenuItem.Name = "stockInToolStripMenuItem";
            this.stockInToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.stockInToolStripMenuItem.Text = "Stock In";
            this.stockInToolStripMenuItem.Click += new System.EventHandler(this.stockInToolStripMenuItem_Click);
            // 
            // stockOutToolStripMenuItem
            // 
            this.stockOutToolStripMenuItem.Name = "stockOutToolStripMenuItem";
            this.stockOutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.stockOutToolStripMenuItem.Text = "Stock Out";
            this.stockOutToolStripMenuItem.Click += new System.EventHandler(this.stockOutToolStripMenuItem_Click);
            // 
            // salesAndSummaryToolStripMenuItem
            // 
            this.salesAndSummaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSummaryToolStripMenuItem,
            this.vIewSalesToolStripMenuItem});
            this.salesAndSummaryToolStripMenuItem.Name = "salesAndSummaryToolStripMenuItem";
            this.salesAndSummaryToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.salesAndSummaryToolStripMenuItem.Text = "Sales And Summary";
            // 
            // itemSummaryToolStripMenuItem
            // 
            this.itemSummaryToolStripMenuItem.Name = "itemSummaryToolStripMenuItem";
            this.itemSummaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.itemSummaryToolStripMenuItem.Text = "Item Summary";
            this.itemSummaryToolStripMenuItem.Click += new System.EventHandler(this.itemSummaryToolStripMenuItem_Click);
            // 
            // vIewSalesToolStripMenuItem
            // 
            this.vIewSalesToolStripMenuItem.Name = "vIewSalesToolStripMenuItem";
            this.vIewSalesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vIewSalesToolStripMenuItem.Text = "VIew Sales";
            this.vIewSalesToolStripMenuItem.Click += new System.EventHandler(this.vIewSalesToolStripMenuItem_Click);
            // 
            // SetupItemUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 329);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.la);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SetupItemUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup Item UI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox companyComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox reorderTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label la;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesAndSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vIewSalesToolStripMenuItem;
    }
}