namespace Lab1_WFApp
{
    partial class NewJob
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
			this.nameBox = new System.Windows.Forms.RichTextBox();
			this.addButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.incomeBox = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.statementListBox = new System.Windows.Forms.CheckedListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Название:";
			// 
			// nameBox
			// 
			this.nameBox.Font = new System.Drawing.Font("Microsoft Himalaya", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nameBox.Location = new System.Drawing.Point(24, 29);
			this.nameBox.Name = "nameBox";
			this.nameBox.Size = new System.Drawing.Size(274, 29);
			this.nameBox.TabIndex = 1;
			this.nameBox.Text = "";
			// 
			// addButton
			// 
			this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.addButton.Location = new System.Drawing.Point(24, 238);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(87, 33);
			this.addButton.TabIndex = 2;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(153, 238);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(87, 33);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Отменить";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// incomeBox
			// 
			this.incomeBox.Font = new System.Drawing.Font("Microsoft Himalaya", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.incomeBox.Location = new System.Drawing.Point(24, 81);
			this.incomeBox.Name = "incomeBox";
			this.incomeBox.Size = new System.Drawing.Size(274, 29);
			this.incomeBox.TabIndex = 5;
			this.incomeBox.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Зарплата";
			// 
			// statementListBox
			// 
			this.statementListBox.FormattingEnabled = true;
			this.statementListBox.Location = new System.Drawing.Point(314, 29);
			this.statementListBox.Name = "statementListBox";
			this.statementListBox.Size = new System.Drawing.Size(185, 242);
			this.statementListBox.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(311, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "Утверждения";
			// 
			// NewJob
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(515, 283);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.statementListBox);
			this.Controls.Add(this.incomeBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.nameBox);
			this.Controls.Add(this.label1);
			this.Name = "NewJob";
			this.Text = "Добавить работу";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox nameBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RichTextBox incomeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox statementListBox;
        private System.Windows.Forms.Label label4;
    }
}