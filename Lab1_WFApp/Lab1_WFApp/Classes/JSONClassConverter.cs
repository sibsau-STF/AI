using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab1_WFApp
{
	public static class JSONClassConverter
	{

		static JsonSerializerSettings settings = new JsonSerializerSettings()
		{
			Formatting = Formatting.Indented,
			NullValueHandling = NullValueHandling.Include
		};

		public static List<Job> GetJobs (List<Statement> statements)
		{
			List<Job> Jobs;
			using ( StreamReader fs = new StreamReader(@"jobs.json") )
			{
				string json = fs.ReadToEnd();
				Jobs = JsonConvert.DeserializeObject<List<Job>>(json, settings)
					.Select(j => j.mapToStatements(statements)).ToList();
				Jobs.Sort((one, two) => one.Id.CompareTo(two.Id));
			}
			return Jobs;
		}

		public static void WriteJobs (List<Job> jobs)
		{
			using ( StreamWriter fs = new StreamWriter(@"jobs.json") )
			{
				string json = JsonConvert.SerializeObject(jobs, settings);
				fs.Write(json);
			}
		}

		public static List<Rule> GetRules (List<Statement> statements)
		{
			List<Rule> rules;
			using ( StreamReader fs = new StreamReader(@"rules.json") )
			{
				string json = fs.ReadToEnd();
				rules = JsonConvert.DeserializeObject<List<Rule>>(json, settings)
					.Select(j => j.mapToStatements(statements)).ToList();
				rules.Sort((one, two) => one.Id.CompareTo(two.Id));
			}
			return rules;
		}

		public static void WriteRules (List<Rule> rules)
		{
			using ( StreamWriter fs = new StreamWriter(@"rules.json") )
			{
				string json = JsonConvert.SerializeObject(rules, settings);
				fs.Write(json);
			}
		}

		public static List<Statement> GetStatements ()
		{
			List<Statement> states;
			using ( StreamReader fs = new StreamReader(@"statements.json") )
			{
				string json = fs.ReadToEnd();
				states = JsonConvert.DeserializeObject<List<Statement>>(json, settings).ToList();
				states.Sort((one, two) => one.Id.CompareTo(two.Id));
			}
			return states;
		}

		public static void WriteStatements (List<Statement> states)
		{
			using ( StreamWriter fs = new StreamWriter(@"statements.json") )
			{
				string json = JsonConvert.SerializeObject(states, settings);
				fs.Write(json);
			}
		}

	}
}
