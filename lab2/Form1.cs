using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Function = lab2.Funcs.Function;
using lab2.Funcs;

namespace lab2
{
    public struct CriteriaResult
    {
        public string Name;
        public double Value;
        public Function Func;

        public CriteriaResult(Function func, double value)
        {
            Name = func.Name;
            Value = value;
            Func = func;
        }
    }

    public partial class Form1 : Form
    {
        public double Visit { get { return 10 * (double)meetingBar.Value; } }
        public double Tasks { get { return 10 * (double)exersizesBar.Value; } }
        public double Labs { get { return (double)labNumeric.Value; } }
        public double Knowledge { get { return 10 * (double)knowledgeBar.Value; } }
        public double CanRead { get { return 10 * (double)canReadBar.Value; } }

        static Linear visitLow = new Linear("плохо посещал", 30, 40, 0, 100, true);
        static Trapecidal visitNorm = new Trapecidal("нормально посещал", 30, 40, 70, 80, 0, 100);
        static Linear visitGood = new Linear("хорошо посещал", 70, 80, 0, 100, false);
        Criteria visit = new Criteria(new Function[] { visitLow, visitNorm, visitGood });
        CriteriaResult visitResult;

        static Linear fewTasks = new Linear("не достаточно сдал", 80, 90, 0, 100, true);
        static Linear allTasks = new Linear("достаточно сдал", 90, 100, 0, 100, false);
        Criteria tasks = new Criteria(new Function[] { fewTasks, allTasks });
        CriteriaResult tasksResult;

        static Linear fewLabs = new Linear("мало защитил", 5, 6, 0, 12, true);
        static Trapecidal normLabs = new Trapecidal("средне защитил", 5, 7, 11, 12, 0, 12);
        static Linear allLabs = new Linear("всё защитил", 11, 12, 0, 12, false);
        Criteria labs = new Criteria(new Function[] { fewLabs, normLabs, allLabs });
        CriteriaResult labsResult;

        static Linear dontKnow = new Linear("не знает ничего", 35, 42, 0, 100, true);
        static Trapecidal knowSchool = new Trapecidal("знает школьную программу", 35, 50, 80, 85, 0, 100);
        static Linear knowSaveliev = new Linear("знает по Савельеву", 80, 90, 0, 100, false);
        Criteria knowledge = new Criteria(new Function[] { dontKnow, knowSchool, knowSaveliev });
        CriteriaResult knowledgeResult;

        static Linear cantRead = new Linear("не умеет читать!", 70, 80, 0, 100, true);
        static Linear canRead = new Linear("может прочесть", 70, 80, 0, 100, false);
        Criteria reading = new Criteria(new Function[] { cantRead, canRead });
        CriteriaResult readingResult;

        static Linear twoMark = new Linear("иди на пересдачу", 20, 30, 0, 100, true);
        static Trapecidal threeMark = new Trapecidal("получай 3", 25, 30, 50, 55, 0, 100);
        static Trapecidal fourMark = new Trapecidal("ну ты даёшь.. 4", 50, 55, 80, 90, 0, 100);
        static Linear fiveMark = new Linear("... 5", 80, 90, 0, 100, false);
        Criteria mark = new Criteria(new Function[] { twoMark, threeMark, fourMark, fiveMark });
        CriteriaResult markResult;


		//
		// Функции определяющие принадлежность к какой-либо оценке
		//
		//////////////////////

		/// <summary>
		/// не плохо знает предмет или умеет читать или средне защитил лабы
		/// </summary>
		static double goodKnowledge (double labs, double knowledge, double read) =>
			OR(( -dontKnow ).Calculate(knowledge), 
				canRead.Calculate(read), 
				normLabs.Calculate(labs));


		/// <summary>
		/// знает по савельеву и умеет читать и не плохо сдал лабы
		/// </summary>
		static double advancedKnowledge (double visiting, double labs, double knowledge, double read) =>
			AND(visitGood.Calculate(visiting), 
				knowSaveliev.Calculate(knowledge), 
				canRead.Calculate(read), 
				( -fewLabs ).Calculate(labs));

		/// <summary>
		/// не ходил или не сдал задачи => 2
		/// </summary>
		static double toTwoMark(double visit, double tasks) => OR(visitLow.Calculate(visit), fewTasks.Calculate(tasks));

		/// <summary>
		/// ходил не плохо и сдал все задачи и мало сдал лаб и не показал себя хорошо => 3
		/// </summary>
		static double toThreeMark(double visiting, double tasks, double labs, double knowledge, double read)
        {
			// посредственная работа в семестре
			var visitAndTasks = AND(( -visitLow ).Calculate(visiting), allTasks.Calculate(tasks));
			// не показал себя хорошо
			var badKnowledge = 1 - goodKnowledge(labs, knowledge, read);
            return AND(visitAndTasks, fewLabs.Calculate(labs), badKnowledge);
        }

		/// <summary>
		///ходил не плохо и сдал все задачи и (хорошо знает предмет или средне сдал лабы или умеет читать)
		/// и (не защитил все лабы или не показал себя отлично) => 4
		/// </summary>
		static double toFourMark(double visiting, double tasks, double labs, double knowledge, double read)
        {
            // хорошая базовая работа в семестре
            var baseWork = AND(( -visitLow ).Calculate(visiting), allTasks.Calculate(tasks));
            // средне знает предмет или умеем читать или средне сдал лабы
			var Knowledge = goodKnowledge(labs, knowledge, read);
			// не сдал все лабы
			var notAllLabs = 1 - allLabs.Calculate(labs);
			// не показал себя отлично
			var notAdvanced = 1 - advancedKnowledge(visiting, labs, knowledge, read);
			return AND(baseWork, Knowledge, notAllLabs, notAdvanced);
        }

		/// <summary>
		/// сдал все задачи и (защитил все лабы или 
		/// (хорошо ходил и хорошо знает предмет и умеет читать и не мало сдал лаб)) => 5
		/// </summary>
		static double toFiveMark(double visiting, double tasks, double labs, double knowledge, double read)
        {
            // базовая работа в семестре
            var baseWork = allTasks.Calculate(tasks);
			// хорошо знает предмет и умеем читать и средне сдал лабы
			var advanceKnowledge = advancedKnowledge(visiting, labs, knowledge, read);
			// сдал все лабы или знает предмет
			var advanceWork = OR(allLabs.Calculate(labs), advanceKnowledge);
            // хорошо работал и отлично знает предмет
            return AND(baseWork, advanceWork);
        }

        CriteriaResult calculateMark(double visiting, double tasks, double labs, double knowledge, double canRead)
        {
			// определение степени принадлежности к какой-либо оценке
            var two = toTwoMark(visiting, tasks);
            var three = toThreeMark(visiting, tasks, labs, knowledge, canRead);
			var four = toFourMark(visiting, tasks, labs, knowledge, canRead);
            var five = toFiveMark(visiting, tasks, labs, knowledge, canRead);

			// модификация функций принадлежности для оценок по методу минимума
            var twoFunc = twoMark.Modify(Function.ModifyMethod.Minimum, two);
            var threeFunc = threeMark.Modify(Function.ModifyMethod.Minimum, three);
            var fourFunc = fourMark.Modify(Function.ModifyMethod.Minimum, four);
            var fiveFunc = fiveMark.Modify(Function.ModifyMethod.Minimum, five);

			// композиция функций оценок
            var super = Function.Superposition((Function.CombinationType)superposCombo.SelectedItem, twoFunc, threeFunc, fourFunc, fiveFunc);
			
			// скаляризация результата - нахождение максимума функции
			var value = super.Scalarize((Function.ScalarMethod)scalarCombo.SelectedItem);
			
			// возвращение оценки
			return mark.Calculate(value);
        }

		static T AND<T>(params T[] values)
			{
			return values.Min();
			}

		static T OR<T> (params T[] values)
			{
			return values.Max();
			}

		public Form1()
        {
            InitializeComponent();
			superposCombo.Items.Add(Function.CombinationType.MaxCombination);
			superposCombo.Items.Add(Function.CombinationType.SumCombination);
			superposCombo.SelectedIndex = 0;

			scalarCombo.Items.Add(Function.ScalarMethod.MaxValue);
			scalarCombo.Items.Add(Function.ScalarMethod.WieghtCenter);
			scalarCombo.SelectedIndex = 0;
			}

        private void meetingBar_ValueChanged(object sender, EventArgs e)
        {
            visitResult = visit.Calculate(Visit);
            visitLabel.Text = visitResult.Name;
        }

        private void exersizesBar_ValueChanged(object sender, EventArgs e)
        {
            tasksResult = tasks.Calculate(Tasks);
            taskLabel.Text = tasksResult.Name;
        }

        private void labNumeric_ValueChanged(object sender, EventArgs e)
        {
            labsResult = labs.Calculate(Labs);
            labsLabel.Text = labsResult.Name;
        }

        private void knowledgeBar_ValueChanged(object sender, EventArgs e)
        {
            knowledgeResult = knowledge.Calculate(Knowledge);
            knowLabel.Text = knowledgeResult.Name;
        }

        private void canReadBar_ValueChanged(object sender, EventArgs e)
        {
            readingResult = reading.Calculate(CanRead);
            readLabel.Text = readingResult.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            markResult = calculateMark(Visit, Tasks, Labs, Knowledge, CanRead);
            markLabel.Text = markResult.Name;
        }
    }
}
