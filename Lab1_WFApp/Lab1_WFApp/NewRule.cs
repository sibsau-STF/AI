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

			resultBox.Items.AddRange(main.Statements.ToArray());
		}

		private void addButton_Click (object sender, EventArgs e)
		{
			var conditions = requirementList.Items.Cast<Statement>().ToList();

			if ( questionBox.Text == "" ||
			  conditions.Count == 0 ||
			  resultBox.Items.Count == 0 )
			{
				MessageBox.Show("Поля не могут быть пустыми!");
				return;
			}
			Rule nRule = new Rule(conditions,
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

		private void button1_Click (object sender, EventArgs e)
		{
			var stateForm = new AttachStatement(main.Statements);
			stateForm.ShowDialog();
			if ( stateForm.Result != null )
			{
				var newRule = stateForm.Result;
				requirementList.Items.Add(newRule);
			}
		}

		private void button2_Click (object sender, EventArgs e)
		{
			Statement rule = (Statement)requirementList.SelectedItem;
			if ( rule != null )
				requirementList.Items.Remove(rule);
		}
	}
}
