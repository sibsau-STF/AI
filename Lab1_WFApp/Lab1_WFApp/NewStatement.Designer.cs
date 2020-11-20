namespace Lab1_WFApp
{
    partial class NewStatement
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.addButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(42, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Введите утверждение";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.Location = new System.Drawing.Point(45, 71);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(274, 52);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// addButton
			// 
			this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.addButton.Location = new System.Drawing.Point(45, 156);
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
			this.cancelButton.Location = new System.Drawing.Point(232, 156);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(87, 33);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Отменить";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// NewStatement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(368, 216);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label1);
			this.Name = "NewStatement";
			this.Text = "AddTagForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
    }
}