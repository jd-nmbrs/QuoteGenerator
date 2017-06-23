namespace QuoteGenerator
{
    partial class Form1
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
            this.constructionComboBox = new System.Windows.Forms.ComboBox();
            this.constructionButton = new System.Windows.Forms.Button();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.gussetTextBox = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.gussetLabel = new System.Windows.Forms.Label();
            this.lipLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lipTextBox = new System.Windows.Forms.TextBox();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.milLabel = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.milTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.quoteButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.saveQuotesButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // constructionComboBox
            // 
            this.constructionComboBox.FormattingEnabled = true;
            this.constructionComboBox.Items.AddRange(new object[] {
            "Bottom Seal Bag",
            "Side Gusset Bag",
            "Zipper Bag",
            "Lip & Tape Bag",
            "Tubing Roll",
            "Gusseted Tubing Roll"});
            this.constructionComboBox.Location = new System.Drawing.Point(26, 13);
            this.constructionComboBox.Name = "constructionComboBox";
            this.constructionComboBox.Size = new System.Drawing.Size(121, 21);
            this.constructionComboBox.TabIndex = 0;
            // 
            // constructionButton
            // 
            this.constructionButton.Location = new System.Drawing.Point(168, 13);
            this.constructionButton.Name = "constructionButton";
            this.constructionButton.Size = new System.Drawing.Size(75, 23);
            this.constructionButton.TabIndex = 1;
            this.constructionButton.Text = "Go!";
            this.constructionButton.UseVisualStyleBackColor = true;
            this.constructionButton.Click += new System.EventHandler(this.constructionComboBox_Click);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(26, 64);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 20);
            this.widthTextBox.TabIndex = 2;
            this.widthTextBox.Visible = false;
            // 
            // gussetTextBox
            // 
            this.gussetTextBox.Location = new System.Drawing.Point(144, 64);
            this.gussetTextBox.Name = "gussetTextBox";
            this.gussetTextBox.Size = new System.Drawing.Size(100, 20);
            this.gussetTextBox.TabIndex = 3;
            this.gussetTextBox.Visible = false;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(26, 45);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 4;
            this.widthLabel.Text = "Width";
            this.widthLabel.Visible = false;
            // 
            // gussetLabel
            // 
            this.gussetLabel.AutoSize = true;
            this.gussetLabel.Location = new System.Drawing.Point(141, 45);
            this.gussetLabel.Name = "gussetLabel";
            this.gussetLabel.Size = new System.Drawing.Size(40, 13);
            this.gussetLabel.TabIndex = 5;
            this.gussetLabel.Text = "Gusset";
            this.gussetLabel.Visible = false;
            // 
            // lipLabel
            // 
            this.lipLabel.AutoSize = true;
            this.lipLabel.Location = new System.Drawing.Point(141, 94);
            this.lipLabel.Name = "lipLabel";
            this.lipLabel.Size = new System.Drawing.Size(21, 13);
            this.lipLabel.TabIndex = 9;
            this.lipLabel.Text = "Lip";
            this.lipLabel.Visible = false;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(26, 94);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(40, 13);
            this.lengthLabel.TabIndex = 8;
            this.lengthLabel.Text = "Length";
            this.lengthLabel.Visible = false;
            // 
            // lipTextBox
            // 
            this.lipTextBox.Location = new System.Drawing.Point(144, 113);
            this.lipTextBox.Name = "lipTextBox";
            this.lipTextBox.Size = new System.Drawing.Size(100, 20);
            this.lipTextBox.TabIndex = 7;
            this.lipTextBox.Visible = false;
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(26, 113);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.lengthTextBox.TabIndex = 6;
            this.lengthTextBox.Visible = false;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(141, 143);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(46, 13);
            this.quantityLabel.TabIndex = 13;
            this.quantityLabel.Text = "Quantity";
            this.quantityLabel.Visible = false;
            // 
            // milLabel
            // 
            this.milLabel.AutoSize = true;
            this.milLabel.Location = new System.Drawing.Point(26, 143);
            this.milLabel.Name = "milLabel";
            this.milLabel.Size = new System.Drawing.Size(20, 13);
            this.milLabel.TabIndex = 12;
            this.milLabel.Text = "Mil";
            this.milLabel.Visible = false;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(144, 162);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(100, 20);
            this.quantityTextBox.TabIndex = 11;
            this.quantityTextBox.Visible = false;
            // 
            // milTextBox
            // 
            this.milTextBox.Location = new System.Drawing.Point(26, 162);
            this.milTextBox.Name = "milTextBox";
            this.milTextBox.Size = new System.Drawing.Size(100, 20);
            this.milTextBox.TabIndex = 10;
            this.milTextBox.Visible = false;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(23, 196);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(84, 13);
            this.priceLabel.TabIndex = 15;
            this.priceLabel.Text = "Price Per Pound";
            this.priceLabel.UseWaitCursor = true;
            this.priceLabel.Visible = false;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(26, 215);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(100, 20);
            this.priceTextBox.TabIndex = 14;
            this.priceTextBox.UseWaitCursor = true;
            this.priceTextBox.Visible = false;
            // 
            // quoteButton
            // 
            this.quoteButton.Location = new System.Drawing.Point(141, 212);
            this.quoteButton.Name = "quoteButton";
            this.quoteButton.Size = new System.Drawing.Size(100, 23);
            this.quoteButton.TabIndex = 16;
            this.quoteButton.Text = "Quote!";
            this.quoteButton.UseVisualStyleBackColor = true;
            this.quoteButton.Visible = false;
            this.quoteButton.Click += new System.EventHandler(this.quoteButton_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.Location = new System.Drawing.Point(274, 22);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(167, 213);
            this.outputLabel.TabIndex = 17;
            // 
            // saveQuotesButton
            // 
            this.saveQuotesButton.Location = new System.Drawing.Point(277, 325);
            this.saveQuotesButton.Name = "saveQuotesButton";
            this.saveQuotesButton.Size = new System.Drawing.Size(164, 23);
            this.saveQuotesButton.TabIndex = 18;
            this.saveQuotesButton.Text = "Save Quotes to File";
            this.saveQuotesButton.UseVisualStyleBackColor = true;
            this.saveQuotesButton.Click += new System.EventHandler(this.saveQuotesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 360);
            this.Controls.Add(this.saveQuotesButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.quoteButton);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.milLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.milTextBox);
            this.Controls.Add(this.lipLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.lipTextBox);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.gussetLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.gussetTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.constructionButton);
            this.Controls.Add(this.constructionComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox constructionComboBox;
        private System.Windows.Forms.Button constructionButton;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox gussetTextBox;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label gussetLabel;
        private System.Windows.Forms.Label lipLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TextBox lipTextBox;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label milLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox milTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Button quoteButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button saveQuotesButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

