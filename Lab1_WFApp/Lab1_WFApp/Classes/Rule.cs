using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Lab1_WFApp
{
	public class Rule
	{
		[JsonProperty("id")]
		public int Id;

		[JsonIgnore]
		public List<Statement> Statements { get; set; }

		[JsonIgnore]
		public Statement Result { get; set; }

		[JsonProperty("question")]
		public string Question { get; set; }

		[JsonProperty("conditions")]
		List<string> statementRefs = new List<string>();

		[JsonProperty("statement_id")]
		int resultId;

		[JsonIgnore]
		List<int> statementIds = new List<int>();

		[JsonIgnore]
		List<bool> trueRef = new List<bool>();


		private static int maxId = 0;

		public Rule ()
		{
			Id = maxId;
			maxId++;
			Statements = new List<Statement>();
		}

		[JsonConstructor]
		public Rule (int id, List<string> conditions, string question, int statement_id)
		{
			Id = id;
			maxId = Id > maxId ? Id : maxId;
			statementRefs = conditions;
			resultId = statement_id;
			Question = question;

			var args = statementRefs
				.Select(stRef => stRef.Split(' ')).ToList();
			foreach ( var arg in args )
			{
				if ( arg.Length > 1 )
				{
					trueRef.Add(arg.First() != "not");
					statementIds.Add(int.Parse(arg.Last()));
				}
				else
				{
					if ( arg[0] != "" )
					{
						trueRef.Add(true);
						statementIds.Add(int.Parse(arg.Last()));
					}
				}
			}
		}

		public Rule (List<Statement> conditions, string question, Statement result)
		{
			maxId++;
			Id = maxId;

			this.Statements = conditions;
			this.Question = question;
			this.Result = result;
			statementRefs = conditions.Select(cond => cond.ToString()).ToList();
		}

		public Rule mapToStatements (List<Statement> allStatements)
		{
			var required = new List<int>(statementIds);

			if ( !required.Contains(resultId) )
				required.Add(resultId);

			var passed = allStatements.FindAll(st => required.Contains(st.Id));
			if ( passed.Count != required.Count )
				throw new System.Exception("Not all statements provided");

			var refs = trueRef.GetEnumerator();
			Statements = required
				.Select(required_id => passed.Find(p => p.Id == required_id)) // form ordered sequence
				.Select(state => { refs.MoveNext(); return refs.Current ? state : -state; }) // apply refference
				.ToList();
			Result = passed.Find(p => p.Id == resultId);
			return this;
		}

		public float getSimilarDegree (Rule rule)
		{
			var similars = Statements.Intersect(rule.Statements);
			var misses = similars.Where(state =>
				!Statement.SameMeaning(state,
					Statement.FindSame(Statements, state)));
			return (float)( similars.Count() - misses.Count() ) / Statements.Count;
		}

		public override string ToString ()
		{
			return Question;
		}

	}
}
