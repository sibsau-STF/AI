using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Funcs
	{
	public class Function
		{
		public enum ModifyMethod
			{
			Minimum = 0,
			Production = 1
			}

		public enum CombinationType
			{
			MaxCombination = 0,
			SumCombination = 1
			}

		public enum ScalarMethod
			{
			WieghtCenter = 0,
			MaxValue = 1
			}

		protected Func<double, double> _func;
		public double From { get; protected set; }
		public double To { get; protected set; }
		public double ScalarValue { get; protected set; }
		public string Name { get; protected set; }

		public Function (string name, Func<double, double> func, double from, double to)
			{
			_func = func;
			From = from;
			To = to;
			Name = name;
			}

		public virtual double Calculate (double x) => _func(x);

		static double Normalize (double x)
			{
			if ( x < 0 )
				return 0;
			if ( x > 1 )
				return 1;
			return x;
			}

		public static Function Superposition (CombinationType method, params Function[] funcs)
			{
			var from = funcs.Select(func => func.From).Min();
			var to = funcs.Select(func => func.To).Max();
			Func<double, double> super;
			switch ( method )
				{
				case CombinationType.MaxCombination:
				super = x => funcs.Select(func => func.Calculate(x)).Max();
				break;
				case CombinationType.SumCombination:
				super = funcs.Aggregate<Function, Func<double, double>>(z => 0,
					(acc, func) => y => acc(y) + func.Calculate(y));
				break;
				default:
				return null;
				}
			return new Function("SuperPosition", super, from, to);
			}

		public Function Modify (ModifyMethod method, double value)
			{
			switch ( method )
				{
				case ModifyMethod.Minimum:
				return new Function(Name, x =>
				{
					var calc = _func(x);
					return calc > value ? value : calc;
				}, From, To);

				case ModifyMethod.Production:
				return new Function(Name, x => value * _func(x), From, To);
				default:
				return null;
				}
			}

		public double Scalarize (ScalarMethod method)
			{
			switch ( method )
				{
				case ScalarMethod.WieghtCenter:
				ScalarValue = getWeightCenter();
				break;
				case ScalarMethod.MaxValue:
				ScalarValue = getMaxValue();
				break;
				default:
				break;
				}
			return ScalarValue;
			}

		double getWeightCenter ()
			{
			var n = 1000;
			var len = To - From;
			var dx = len / n;
			double sum1 = 0;
			double sum2 = 0;

			for ( double x = From; x < To; x += dx )
				{
				var value = _func(x);
				sum1 += value;
				sum2 += value * x;
				}
			return sum2 / sum1;
			}

		double getMaxValue ()
			{
			var n = 1000;
			var len = To - From;
			var dx = len / n;
			double maxValue = _func(From);
			double xMax = From;
			for ( double x = From; x < To; x += dx )
				{
				var value = _func(x);
				if ( maxValue < value )
					{
					maxValue = value;
					xMax = x;
					}
				}
			return xMax;
			}

		public static Function operator+(Function first, Function second)
			{
			var from = Math.Min(first.From, second.From);
			var to = Math.Max(first.To, second.To);
			return new Function($"({first.Name} или {second.Name})", (x) => Math.Max(first._func(x), second._func(x)), from, to);
			}

		public static Function operator*(Function first, Function second)
			{
			var from = Math.Min(first.From, second.From);
			var to = Math.Max(first.To, second.To);
			return new Function($"({first.Name} и {second.Name})", (x) => Math.Min(first._func(x), second._func(x)), from, to);
			}

		}
	}
