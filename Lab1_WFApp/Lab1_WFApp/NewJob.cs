using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab1_WFApp
{
    public partial class NewJob : Form
    {
        MainForm main;
        public NewJob(MainForm mainForm)
			{
            InitializeComponent();
            main = mainForm;
            statementListBox.Items.AddRange(main.Statements.ToArray());
			}

        private void addButton_Click(object sender, EventArgs e)
			{
			var statements = statementListBox.CheckedItems.Cast<Statement>().ToList();
			if ( incomeBox.Text == "" ||
				nameBox.Text == "" ||
				statements.Count == 0
				)
				{
				MessageBox.Show("Поля не могут быть пустыми!");
				return;
				}
			
			int income;
			bool isInt = int.TryParse(incomeBox.Text, out income);
			if (!isInt)
				{
				MessageBox.Show("Зарплата имеет неверный формат");
				return;
				}

			Job newJob = new Job(nameBox.Text, statements, income);

			if ( main.Jobs.Contains(newJob) )
				MessageBox.Show("Такая работа уже существует!");
			else
				{
				List<Job> localJobs = JSONClassConverter.GetJobs(main.Statements);

				localJobs.Add(newJob);
				main.Jobs.Add(newJob);

				JSONClassConverter.WriteJobs(localJobs);
				this.Close();
				}
			}

        private void cancelButton_Click(object sender, EventArgs e)
			{
            this.Close();
			}
    }
}
