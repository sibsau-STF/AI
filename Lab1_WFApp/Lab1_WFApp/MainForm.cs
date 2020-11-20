using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_WFApp
{
	public partial class MainForm : Form
	{
		event Action<Job> JobFound;

		public List<Rule> Questions;
		public List<Job> Jobs;
		public List<Statement> Statements;

		public List<Job> RemainJobs;
		private List<Rule> RemainQuestions;
		private List<Statement> incomeStatements;
		private Rule currentRule;
		private Job foundJob;

		private int askCount = 0;
		private bool jobFound = false;

		public MainForm ()
		{
			InitializeComponent();
		}

		private void MainForm_Load (object sender, EventArgs e)
		{
			Statements = JSONClassConverter.GetStatements();
			Questions = JSONClassConverter.GetRules(Statements);
			Jobs = JSONClassConverter.GetJobs(Statements);

			RemainJobs = new List<Job>(Jobs);
			RemainQuestions = new List<Rule>(Questions);

			JobFound += DisplayJob;
			currentRule = RemainQuestions[0];
			askCount = 1;
			incomeStatements = new List<Statement>();
			//incomeStatements.Add(new Statement(0, ""));

			//установка текста в label
			label.Text = currentRule.Question;
		}

		private void DisplayJob (Job found)
		{
			if ( found != null )
			{
				label.Text = found.ToString() + "\r\nВас устраивает такой вариант?";
				RemainJobs.Remove(found);
				jobFound = true;
			}
			else
			{
				label.Text = "Извините, не получилось подобрать вам подходящий вариант :(\r\nПопробуйте еще раз";
				yesButton.Visible = false;
				noButton.Visible = false;
			}
		}

		public void findNextQuestion ()
		{
			foundJob = Job.findJob(incomeStatements, RemainJobs);
			if ( askCount < 3 || foundJob == null )
			{
				//поиск подходящего правила по тегам
				currentRule = RemainQuestions.Find(question => 
						Statement.FindSameMeaning(question.Statements, incomeStatements.Last()) != null);

				//если нашли правило, то пишем текст
				if ( currentRule != null )
				{
					label.Text = currentRule.Question;
				}
				//иначе
				else
				{
					//ищем все подходящие вопросы
					foreach ( var statement in incomeStatements )
					{
						currentRule = RemainQuestions.Find(question => Statement.FindSameMeaning(question.Statements, statement) != null);
						if ( currentRule != null )
						{
							label.Text = currentRule.Question;
							break;
						}
					}
					if ( currentRule == null )
					{
						label.Text = "Извините, не получилось подобрать вам подходящий вариант\r\nПопробуйте еще раз";
						yesButton.Visible = false;
						noButton.Visible = false;
					}
				}
			}
			else
			{
				
				if ( foundJob != null )
				{
					label.Text = foundJob.ToString() + "\r\nВас устраивает такой вариант?";
					simLabel.Text = foundJob.getSimilarDegree(incomeStatements).ToString();
					requireList.Items.AddRange(foundJob.Statements.ToArray());
					RemainJobs.Remove(foundJob);
					jobFound = true;
				}
				else
				{
					label.Text = "Извините, не получилось подобрать вам подходящий вариант :(\r\nПопробуйте еще раз";
					yesButton.Visible = false;
					noButton.Visible = false;
				}
			}
		}


		private void yesButton_Click (object sender, EventArgs e)
		{
			if ( !jobFound )
			{
				incomeStatements.Add(currentRule.Result);
				charactersList.Items.Add(currentRule.Result);
				RemainQuestions.Remove(currentRule);
				findNextQuestion();
				askCount++;
			}
			else
			{
				jobFound = false;
				label.Text = "Работа найдена";
				yesButton.Visible = false;
				noButton.Visible = false;
			}
		}

		private void noButton_Click (object sender, EventArgs e)
		{
			if ( !jobFound )
			{
				incomeStatements.Add(-currentRule.Result);
				charactersList.Items.Add(-currentRule.Result);
				RemainQuestions.Remove(currentRule);
				//if ( currentRule.Result.Equals("Конец") )
				//	Questions.Clear();

				findNextQuestion();
				askCount++;
			}
			else
			{
				//var temp = incomeStatements.Last();
				//incomeStatements.Remove(temp);
				//incomeStatements.Add(-temp);
				requireList.Items.Clear();
				askCount--;
				jobFound = false;
				findNextQuestion();
			}
		}

		private void repeatButton_Click (object sender, EventArgs e)
		{
			incomeStatements.Clear();
			charactersList.Items.Clear();

			askCount = 1;
			jobFound = false;

			RemainJobs = new List<Job>(Jobs);
			RemainQuestions = new List<Rule>(Questions);

			requireList.Items.Clear();

			currentRule = RemainQuestions[0];
			label.Text = currentRule.Question;

			yesButton.Visible = true;
			noButton.Visible = true;
		}

		private void addStatemtnt_Click (object sender, EventArgs e)
		{
			new NewStatement(this).Show();
		}

		private void addRuleButton_Click (object sender, EventArgs e)
		{
			new NewRule(this).Show();
		}

		private void addJobButton_Click (object sender, EventArgs e)
		{
			new NewJob(this).Show();
		}

		private void MainForm_FormClosing (object sender, FormClosingEventArgs e)
		{
			JSONClassConverter.WriteJobs(Jobs);
			JSONClassConverter.WriteRules(Questions);
			JSONClassConverter.WriteStatements(Statements);
		}
	}
}
