using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab1_WFApp
{
	public class Statement
	{
		[JsonProperty("id")]
		public int Id;

		[JsonProperty("name")]
		public string Name;

		[JsonIgnore]
		public string FullName => ( Negative ? "not " : "" ) + Name;

		[JsonIgnore]
		public readonly bool Negative;

		private static int maxId = 0;

		[JsonConstructor]
		public Statement (int id, string name, bool neg = false)
		{
			Id = id;
			maxId = Id > maxId ? Id : maxId;
			Name = name;
			Negative = neg;
		}

		public Statement (string name, bool neg = false)
		{
			maxId++;
			Id = maxId;
			Name = name;
			Negative = neg;
		}

		public Statement ()
		{
			maxId++;
			Id = maxId;
			Negative = false;
		}

		public static Statement operator - (Statement st)
		{
			return new Statement(st.Id, st.Name, !st.Negative);
		}

		public static Statement FindSame (List<Statement> container, 
											Statement value) => 
			container.Find(s => s.Equals(value));

		public static Statement FindSameMeaning (List<Statement> container,
											Statement value) =>
			container.Find(state => SameMeaning(state, value));

		public static bool SameMeaning(Statement one, Statement other)
		{
			return one.Name == other.Name && one.Negative == other.Negative;
		}

		public override bool Equals (object obj)
		{
			var statement = obj as Statement;
			if ( statement != null )
				return statement.Name == Name;
			return base.Equals(obj);
		}

		public override string ToString ()
		{
			return FullName;
		}

	}
}
