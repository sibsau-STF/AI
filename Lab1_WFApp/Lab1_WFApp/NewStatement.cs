using System;
using System.Windows.Forms;

namespace Lab1_WFApp
	{
	public partial class NewStatement : Form
		{
		MainForm main;
		public NewStatement (MainForm mainForm)
			{
			InitializeComponent();
			main = mainForm;
			}

		private void addButton_Click (object sender, EventArgs e)
			{
			if ( richTextBox1.Text == "" )
				{
				MessageBox.Show("Поле не может быть пустым");
				return;
				}

			var newState = new Statement(richTextBox1.Text, false);

			if ( main.Statements.Contains(newState) )
				{
				MessageBox.Show("Такое утверждение уже создано");
				return;
				}

			var localStatements = JSONClassConverter.GetStatements();
			localStatements.Add(newState);
			main.Statements.Add(newState);
			JSONClassConverter.WriteStatements(localStatements);
			this.Close();
			}

		private void cancelButton_Click (object sender, EventArgs e)
			{
			this.Close();
			}
		}
	}
