using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab1_WFApp
{
	public class Job
	{
		[JsonProperty("id")]
		public int Id;

		[JsonProperty("name")]
		public string Name;

		[JsonProperty("statements")]
		List<int> statementIds;

		[JsonIgnore]
		public List<Statement> Statements;

		[JsonProperty("income")]
		public int Income;

		public static int maxId;

		[JsonConstructor]
		public Job (int id, string name, List<int> statement_ids, int income)
		{
			Id = id;
			maxId = Id > maxId ? Id : maxId;
			Name = name;
			statementIds = statement_ids;
			Income = income;
		}

		public Job (string name, List<Statement> statements, int income)
		{
			maxId++;
			Id = maxId;
			Name = name;
			Statements = statements;
			statementIds = Statements.Select(st => st.Id).ToList();
			Income = income;
		}

		public Job mapToStatements (List<Statement> allStatements)
		{
			var required = new List<int>(statementIds);

			var passed = allStatements.FindAll(st => required.Contains(st.Id));
			if ( passed.Count != required.Count )
				throw new Exception("Not all statements provided");

			Statements = required.Select(reqId => passed.Find(p => p.Id == reqId)).ToList();
			return this;
		}

		/*
		public Job(string name, List<Statement> statements, int income)
        {
            this.Name = name;
            this.Statements = statements;
            this.Income = income;
        }

        public Job()
			{
            this.Name = "";
            this.Income = 0;
			this.Statements = new List<Statement>();
			}
		*/

		//метод определения и возврата степени "схожести" книги по имеющимся в стеке тегам от 0 до 1
		public float getSimilarDegree (List<Statement> states)
		{
			var notIncluded = Statements.Except(states);
			var sim = states.Intersect(Statements);
			var misses = sim.Where(state => 
				!Statement.SameMeaning(state, 
					Statement.FindSame(Statements, state)));

			return notIncluded.Count() > 0 ? 0 : (float)( sim.Count() - misses.Count() ) / states.Count();
		}

		//поиск наиболее подходящей книги
		public static Job findJob (List<Statement> states, List<Job> jobs)
		{
			float max = 0;
			Job found = null;
			for ( int i = 0; i < jobs.Count; i++ )
				if ( jobs[i].getSimilarDegree(states) > max )
				{
					max = jobs[i].getSimilarDegree(states);
					found = jobs[i];
				}
			return found;
		}

		public override string ToString () => $"{Name} [{Income}₽]";
	}
}
