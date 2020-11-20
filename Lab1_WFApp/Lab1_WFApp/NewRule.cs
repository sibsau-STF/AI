using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab1_WFApp
{
	public partial class NewRule : Form
	{
		MainForm main;
		public NewRule (MainForm mainForm)
		{
			InitializeComponent();
			main = mainForm;
			var statements = main.Statements.ToArray();

			requirementList.Items.AddRange(statements);
			resultBox.Items.AddRange(statements);
		}

		private void addButton_Click (object sender, EventArgs e)
		{
			var conditions = requirementList.CheckedItems.Cast<Statement>().ToList();

			if ( questionBox.Text == "" ||
			  conditions.Count == 0 ||
			  resultBox.Items.Count == 0 )
			{
				MessageBox.Show("Поля не могут быть пустыми!");
				return;
			}
			Rule nRule = new Rule(requirementList.CheckedItems.Cast<Statement>().ToList(),
							questionBox.Text,
							(Statement)resultBox.SelectedItem);
			if ( main.Questions.Contains(nRule) )
				MessageBox.Show("Такое правило уже существует!");
			else
			{

				//перезапись
				List<Rule> ruleList = JSONClassConverter.GetRules(main.Statements);
				ruleList.Add(nRule);
				main.Questions.Add(nRule);
				JSONClassConverter.WriteRules(ruleList);
				this.Close();
			}
		}

		private void cancelButton_Click (object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
