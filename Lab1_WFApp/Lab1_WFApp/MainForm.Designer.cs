namespace Lab1_WFApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.addStatementButton = new System.Windows.Forms.Button();
			this.addRuleButton = new System.Windows.Forms.Button();
			this.addBookButton = new System.Windows.Forms.Button();
			this.label = new System.Windows.Forms.Label();
			this.yesButton = new System.Windows.Forms.Button();
			this.noButton = new System.Windows.Forms.Button();
			this.repeatButton = new System.Windows.Forms.Button();
			this.charactersList = new System.Windows.Forms.ListBox();
			this.requireList = new System.Windows.Forms.ListBox();
			this.simLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// addStatementButton
			// 
			this.addStatementButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.addStatementButton.Location = new System.Drawing.Point(577, 322);
			this.addStatementButton.Margin = new System.Windows.Forms.Padding(3, 3, 320, 3);
			this.addStatementButton.Name = "addStatementButton";
			this.addStatementButton.Size = new System.Drawing.Size(198, 30);
			this.addStatementButton.TabIndex = 0;
			this.addStatementButton.Text = "Добавить предпочтение";
			this.addStatementButton.UseVisualStyleBackColor = true;
			this.addStatementButton.Click += new System.EventHandler(this.addStatemtnt_Click);
			// 
			// addRuleButton
			// 
			this.addRuleButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.addRuleButton.Location = new System.Drawing.Point(577, 367);
			this.addRuleButton.Name = "addRuleButton";
			this.addRuleButton.Size = new System.Drawing.Size(198, 30);
			this.addRuleButton.TabIndex = 1;
			this.addRuleButton.Text = "Добавить правило";
			this.addRuleButton.UseVisualStyleBackColor = true;
			this.addRuleButton.Click += new System.EventHandler(this.addRuleButton_Click);
			// 
			// addBookButton
			// 
			this.addBookButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.addBookButton.Location = new System.Drawing.Point(577, 412);
			this.addBookButton.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
			this.addBookButton.Name = "addBookButton";
			this.addBookButton.Size = new System.Drawing.Size(198, 30);
			this.addBookButton.TabIndex = 2;
			this.addBookButton.Text = "Добавить работу";
			this.addBookButton.UseVisualStyleBackColor = true;
			this.addBookButton.Click += new System.EventHandler(this.addJobButton_Click);
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.Transparent;
			this.label.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label.Location = new System.Drawing.Point(75, 33);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(650, 96);
			this.label.TabIndex = 3;
			this.label.Text = "label1";
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// yesButton
			// 
			this.yesButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.yesButton.Font = new System.Drawing.Font("Microsoft Himalaya", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.yesButton.Location = new System.Drawing.Point(232, 143);
			this.yesButton.Margin = new System.Windows.Forms.Padding(3, 3, 320, 3);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new System.Drawing.Size(115, 45);
			this.yesButton.TabIndex = 4;
			this.yesButton.Text = "Да";
			this.yesButton.UseVisualStyleBackColor = true;
			this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
			// 
			// noButton
			// 
			this.noButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.noButton.Font = new System.Drawing.Font("Microsoft Himalaya", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.noButton.Location = new System.Drawing.Point(452, 143);
			this.noButton.Margin = new System.Windows.Forms.Padding(3, 3, 320, 3);
			this.noButton.Name = "noButton";
			this.noButton.Size = new System.Drawing.Size(115, 45);
			this.noButton.TabIndex = 5;
			this.noButton.Text = "Нет";
			this.noButton.UseVisualStyleBackColor = true;
			this.noButton.Click += new System.EventHandler(this.noButton_Click);
			// 
			// repeatButton
			// 
			this.repeatButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.repeatButton.Font = new System.Drawing.Font("Microsoft Himalaya", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.repeatButton.Location = new System.Drawing.Point(10, 393);
			this.repeatButton.Margin = new System.Windows.Forms.Padding(3, 3, 320, 3);
			this.repeatButton.Name = "repeatButton";
			this.repeatButton.Size = new System.Drawing.Size(115, 45);
			this.repeatButton.TabIndex = 6;
			this.repeatButton.Text = "Заново";
			this.repeatButton.UseVisualStyleBackColor = true;
			this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
			// 
			// charactersList
			// 
			this.charactersList.FormattingEnabled = true;
			this.charactersList.ItemHeight = 16;
			this.charactersList.Location = new System.Drawing.Point(142, 242);
			this.charactersList.Name = "charactersList";
			this.charactersList.Size = new System.Drawing.Size(169, 196);
			this.charactersList.TabIndex = 7;
			// 
			// requireList
			// 
			this.requireList.FormattingEnabled = true;
			this.requireList.ItemHeight = 16;
			this.requireList.Location = new System.Drawing.Point(376, 242);
			this.requireList.Name = "requireList";
			this.requireList.Size = new System.Drawing.Size(169, 196);
			this.requireList.TabIndex = 8;
			// 
			// simLabel
			// 
			this.simLabel.AutoSize = true;
			this.simLabel.Location = new System.Drawing.Point(376, 219);
			this.simLabel.Name = "simLabel";
			this.simLabel.Size = new System.Drawing.Size(65, 17);
			this.simLabel.TabIndex = 9;
			this.simLabel.Text = "simillarity";
			this.simLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 450);
			this.Controls.Add(this.simLabel);
			this.Controls.Add(this.requireList);
			this.Controls.Add(this.charactersList);
			this.Controls.Add(this.repeatButton);
			this.Controls.Add(this.noButton);
			this.Controls.Add(this.yesButton);
			this.Controls.Add(this.label);
			this.Controls.Add(this.addBookButton);
			this.Controls.Add(this.addRuleButton);
			this.Controls.Add(this.addStatementButton);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
			this.Text = "Main Form";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStatementButton;
        private System.Windows.Forms.Button addRuleButton;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button repeatButton;
		private System.Windows.Forms.ListBox charactersList;
		private System.Windows.Forms.ListBox requireList;
		private System.Windows.Forms.Label simLabel;
	}
}

