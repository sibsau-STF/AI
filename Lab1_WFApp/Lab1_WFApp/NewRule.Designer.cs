﻿namespace Lab1_WFApp
{
    partial class NewRule
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
			this.label4 = new System.Windows.Forms.Label();
			this.requirementList = new System.Windows.Forms.CheckedListBox();
			this.questionBox = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.resultBox = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "Условие:";
			// 
			// requirementList
			// 
			this.requirementList.FormattingEnabled = true;
			this.requirementList.Location = new System.Drawing.Point(29, 46);
			this.requirementList.Name = "requirementList";
			this.requirementList.Size = new System.Drawing.Size(185, 157);
			this.requirementList.TabIndex = 10;
			// 
			// questionBox
			// 
			this.questionBox.Font = new System.Drawing.Font("Microsoft Himalaya", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.questionBox.Location = new System.Drawing.Point(230, 46);
			this.questionBox.Name = "questionBox";
			this.questionBox.Size = new System.Drawing.Size(274, 157);
			this.questionBox.TabIndex = 13;
			this.questionBox.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(227, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "Вопрос:";
			// 
			// resultBox
			// 
			this.resultBox.FormattingEnabled = true;
			this.resultBox.ItemHeight = 16;
			this.resultBox.Location = new System.Drawing.Point(522, 46);
			this.resultBox.Name = "resultBox";
			this.resultBox.Size = new System.Drawing.Size(166, 148);
			this.resultBox.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(519, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 17);
			this.label2.TabIndex = 15;
			this.label2.Text = "Результат:";
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(417, 251);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(87, 33);
			this.cancelButton.TabIndex = 17;
			this.cancelButton.Text = "Отменить";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// addButton
			// 
			this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.addButton.Location = new System.Drawing.Point(230, 251);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(87, 33);
			this.addButton.TabIndex = 16;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// NewRule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 296);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.resultBox);
			this.Controls.Add(this.questionBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.requirementList);
			this.Name = "NewRule";
			this.Text = "RuleForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox requirementList;
        private System.Windows.Forms.RichTextBox questionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox resultBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
    }
}