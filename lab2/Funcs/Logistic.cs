using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function = lab2.Funcs.Function;

namespace lab2.Funcs
	{
	public class Logistic: Function
		{
		private double _Mu;
		private double _S;
		private bool _inverse;

		public Logistic (string name, double mu, double s, double Dfrom, double Dto, bool inverse) : base(name, x => 0, Dfrom, Dto)
			{
			_Mu = mu;
			_S = s;
			_inverse = inverse;
			_func = this.Calculate;
			}

		public override double Calculate (double x)
			{
			double sign = _inverse ? -1 : 1;
			return 1 / ( 1 + Math.Exp(-( x - _Mu ) * sign / _S));
			}

		public static Logistic operator -(Logistic first)
			{
			return new Logistic("не " + first.Name,
							first._Mu,
							first._S,
							first.From,
							first.To,
							!first._inverse);
			}
		}
	}
