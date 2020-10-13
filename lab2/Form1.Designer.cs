namespace lab2
	{
	partial class Form1
		{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose (bool disposing)
			{
			if ( disposing && ( components != null ) )
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
		private void InitializeComponent ()
			{
			this.meetingBar = new System.Windows.Forms.TrackBar();
			this.labNumeric = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.exersizesBar = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.knowledgeBar = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.canReadBar = new System.Windows.Forms.TrackBar();
			this.markLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.visitLabel = new System.Windows.Forms.Label();
			this.taskLabel = new System.Windows.Forms.Label();
			this.labsLabel = new System.Windows.Forms.Label();
			this.knowLabel = new System.Windows.Forms.Label();
			this.readLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.meetingBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.labNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exersizesBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.knowledgeBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.canReadBar)).BeginInit();
			this.SuspendLayout();
			// 
			// meetingBar
			// 
			this.meetingBar.LargeChange = 1;
			this.meetingBar.Location = new System.Drawing.Point(205, 65);
			this.meetingBar.Name = "meetingBar";
			this.meetingBar.Size = new System.Drawing.Size(140, 56);
			this.meetingBar.TabIndex = 0;
			this.meetingBar.TabStop = false;
			this.meetingBar.Value = 5;
			this.meetingBar.ValueChanged += new System.EventHandler(this.meetingBar_ValueChanged);
			// 
			// labNumeric
			// 
			this.labNumeric.Location = new System.Drawing.Point(205, 186);
			this.labNumeric.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.labNumeric.Name = "labNumeric";
			this.labNumeric.Size = new System.Drawing.Size(120, 22);
			this.labNumeric.TabIndex = 1;
			this.labNumeric.ValueChanged += new System.EventHandler(this.labNumeric_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(67, 65);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Ходил на занятия";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Сдал все задачи и лабы";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(89, 188);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Защитил лабы";
			// 
			// exersizesBar
			// 
			this.exersizesBar.LargeChange = 1;
			this.exersizesBar.Location = new System.Drawing.Point(205, 124);
			this.exersizesBar.Name = "exersizesBar";
			this.exersizesBar.Size = new System.Drawing.Size(140, 56);
			this.exersizesBar.TabIndex = 5;
			this.exersizesBar.TabStop = false;
			this.exersizesBar.Value = 5;
			this.exersizesBar.ValueChanged += new System.EventHandler(this.exersizesBar_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(86, 241);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Знает предмет";
			// 
			// knowledgeBar
			// 
			this.knowledgeBar.LargeChange = 1;
			this.knowledgeBar.Location = new System.Drawing.Point(205, 241);
			this.knowledgeBar.Name = "knowledgeBar";
			this.knowledgeBar.Size = new System.Drawing.Size(140, 56);
			this.knowledgeBar.TabIndex = 7;
			this.knowledgeBar.TabStop = false;
			this.knowledgeBar.Value = 5;
			this.knowledgeBar.ValueChanged += new System.EventHandler(this.knowledgeBar_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(96, 303);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 17);
			this.label5.TabIndex = 8;
			this.label5.Text = "Умеет читать";
			// 
			// canReadBar
			// 
			this.canReadBar.LargeChange = 1;
			this.canReadBar.Location = new System.Drawing.Point(205, 303);
			this.canReadBar.Name = "canReadBar";
			this.canReadBar.Size = new System.Drawing.Size(140, 56);
			this.canReadBar.TabIndex = 9;
			this.canReadBar.TabStop = false;
			this.canReadBar.Value = 5;
			this.canReadBar.ValueChanged += new System.EventHandler(this.canReadBar_ValueChanged);
			// 
			// markLabel
			// 
			this.markLabel.AutoSize = true;
			this.markLabel.Location = new System.Drawing.Point(602, 104);
			this.markLabel.Name = "markLabel";
			this.markLabel.Size = new System.Drawing.Size(58, 17);
			this.markLabel.TabIndex = 10;
			this.markLabel.Text = "Оценка";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(605, 59);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "Вычислить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(215, 90);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(16, 17);
			this.label7.TabIndex = 13;
			this.label7.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(215, 149);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(16, 17);
			this.label8.TabIndex = 14;
			this.label8.Text = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(215, 267);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 17);
			this.label9.TabIndex = 15;
			this.label9.Text = "0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(215, 327);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(16, 17);
			this.label10.TabIndex = 16;
			this.label10.Text = "0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(318, 149);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(32, 17);
			this.label11.TabIndex = 17;
			this.label11.Text = "100";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(318, 91);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(32, 17);
			this.label12.TabIndex = 18;
			this.label12.Text = "100";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(318, 267);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(32, 17);
			this.label13.TabIndex = 19;
			this.label13.Text = "100";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(318, 327);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(32, 17);
			this.label14.TabIndex = 20;
			this.label14.Text = "100";
			// 
			// visitLabel
			// 
			this.visitLabel.AutoSize = true;
			this.visitLabel.Location = new System.Drawing.Point(351, 65);
			this.visitLabel.Name = "visitLabel";
			this.visitLabel.Size = new System.Drawing.Size(0, 17);
			this.visitLabel.TabIndex = 21;
			// 
			// taskLabel
			// 
			this.taskLabel.AutoSize = true;
			this.taskLabel.Location = new System.Drawing.Point(351, 124);
			this.taskLabel.Name = "taskLabel";
			this.taskLabel.Size = new System.Drawing.Size(0, 17);
			this.taskLabel.TabIndex = 22;
			// 
			// labsLabel
			// 
			this.labsLabel.AutoSize = true;
			this.labsLabel.Location = new System.Drawing.Point(351, 188);
			this.labsLabel.Name = "labsLabel";
			this.labsLabel.Size = new System.Drawing.Size(0, 17);
			this.labsLabel.TabIndex = 23;
			// 
			// knowLabel
			// 
			this.knowLabel.AutoSize = true;
			this.knowLabel.Location = new System.Drawing.Point(351, 241);
			this.knowLabel.Name = "knowLabel";
			this.knowLabel.Size = new System.Drawing.Size(0, 17);
			this.knowLabel.TabIndex = 24;
			// 
			// readLabel
			// 
			this.readLabel.AutoSize = true;
			this.readLabel.Location = new System.Drawing.Point(351, 310);
			this.readLabel.Name = "readLabel";
			this.readLabel.Size = new System.Drawing.Size(0, 17);
			this.readLabel.TabIndex = 25;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(751, 353);
			this.Controls.Add(this.readLabel);
			this.Controls.Add(this.knowLabel);
			this.Controls.Add(this.labsLabel);
			this.Controls.Add(this.taskLabel);
			this.Controls.Add(this.visitLabel);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.markLabel);
			this.Controls.Add(this.canReadBar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.knowledgeBar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.exersizesBar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labNumeric);
			this.Controls.Add(this.meetingBar);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.meetingBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.labNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exersizesBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.knowledgeBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.canReadBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.TrackBar meetingBar;
		private System.Windows.Forms.NumericUpDown labNumeric;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar exersizesBar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar knowledgeBar;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar canReadBar;
		private System.Windows.Forms.Label markLabel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label visitLabel;
		private System.Windows.Forms.Label taskLabel;
		private System.Windows.Forms.Label labsLabel;
		private System.Windows.Forms.Label knowLabel;
		private System.Windows.Forms.Label readLabel;
		}
	}

