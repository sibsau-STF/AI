using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Funcs
	{
	public class Linear : Function
		{
		private double _A;
		private double _B;
		private bool _inverse;

		public Linear (string name, double a, double b, double Dfrom, double Dto, bool inverse) : base(name, x => 0, Dfrom, Dto)
			{
			_A = a;
			_B = b;
			_inverse = inverse;
			_func = this.Calculate;
			}

		public override double Calculate (double x)
			{
			var len = ( _B - _A) * ( _inverse ? -1 : 1 );
			var max = _inverse ? 1 : 0;
			var min = _inverse ? 0 : 1;
			var start = _inverse ? _B : _A;
			var end = _inverse ? _A : _B;
			return ( x < _A ) ? max : ( x > _B) ? min : ( x - start) / len;
			}

		public static Linear operator - (Linear first)
			{
			return new Linear("не " + first.Name,
							first._A,
							first._B,
							first.From,
							first.To,
							!first._inverse);
			}
		}
	}
