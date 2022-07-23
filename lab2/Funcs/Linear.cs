using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Funcs
	{
	public class Linear : Function
		{
		private readonly double _a;
		private readonly double _b;
		private readonly bool _inverse;

		public Linear (string name, double a, double b, double x1, double x2, bool inverse) : base(name, x => 0, x1, x2)
			{
			_a = a;
			_b = b;
			_inverse = inverse;
			Func = this.Calculate;
			}

		public override double Calculate (double x)
			{
			double len = ( _b - _a) * ( _inverse ? -1 : 1 );
			int max = _inverse ? 1 : 0;
			int min = _inverse ? 0 : 1;
			double start = _inverse ? _b : _a;
			double end = _inverse ? _a : _b;
			return ( x < _a ) ? max : ( x > _b) ? min : ( x - start) / len;
			}

		public static Linear operator - (Linear first)
			{
			return new Linear("не " + first.Name,
							first._a,
							first._b,
							first.From,
							first.To,
							!first._inverse);
			}
		}
	}
