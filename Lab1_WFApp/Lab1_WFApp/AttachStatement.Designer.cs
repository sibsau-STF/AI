namespace Lab1_WFApp
{
	partial class AttachStatement
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if ( disposing && ( components != null ) )
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
		private void InitializeComponent ()
		{
			this.trueBox = new System.Windows.Forms.CheckBox();
			this.statementsBox = new System.Windows.Forms.ComboBox();
			this.yesBtn = new System.Windows.Forms.Button();
			this.noBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// trueBox
			// 
			this.trueBox.AutoSize = true;
			this.trueBox.Checked = true;
			this.trueBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.trueBox.Location = new System.Drawing.Point(18, 34);
			this.trueBox.Name = "trueBox";
			this.trueBox.Size = new System.Drawing.Size(131, 21);
			this.trueBox.TabIndex = 0;
			this.trueBox.Text = "Удовлетворяет";
			this.trueBox.UseVisualStyleBackColor = true;
			// 
			// statementsBox
			// 
			this.statementsBox.FormattingEnabled = true;
			this.statementsBox.Location = new System.Drawing.Point(181, 31);
			this.statementsBox.Name = "statementsBox";
			this.statementsBox.Size = new System.Drawing.Size(163, 24);
			this.statementsBox.TabIndex = 2;
			// 
			// yesBtn
			// 
			this.yesBtn.Location = new System.Drawing.Point(271, 99);
			this.yesBtn.Name = "yesBtn";
			this.yesBtn.Size = new System.Drawing.Size(75, 23);
			this.yesBtn.TabIndex = 3;
			this.yesBtn.Text = "Добавить";
			this.yesBtn.UseVisualStyleBackColor = true;
			this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
			// 
			// noBtn
			// 
			this.noBtn.Location = new System.Drawing.Point(181, 99);
			this.noBtn.Name = "noBtn";
			this.noBtn.Size = new System.Drawing.Size(75, 23);
			this.noBtn.TabIndex = 4;
			this.noBtn.Text = "Отмена";
			this.noBtn.UseVisualStyleBackColor = true;
			this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
			// 
			// AttachStatement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 134);
			this.Controls.Add(this.noBtn);
			this.Controls.Add(this.yesBtn);
			this.Controls.Add(this.statementsBox);
			this.Controls.Add(this.trueBox);
			this.Name = "AttachStatement";
			this.Text = "Добавить утверждение";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox trueBox;
		private System.Windows.Forms.ComboBox statementsBox;
		private System.Windows.Forms.Button yesBtn;
		private System.Windows.Forms.Button noBtn;
	}
}