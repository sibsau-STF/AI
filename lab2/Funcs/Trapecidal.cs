using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Funcs
	{
	public class Trapecidal : Function
		{
		private double _A;
		private double _B;
		private double _Max1;
		private double _Max2;
		private bool _inverse;
		private Linear side1;
		private Linear side2;

		/// <summary>
		/// Трапецидальная функция принадлежности
		/// </summary>
		/// <param name="name">Название функции принадлежности</param>
		/// <param name="a">точка подъема на основание трапеции</param>
		/// <param name="max1">левая точка на основания трапеции</param>
		/// <param name="max2">правая точка на основании трапеции</param>
		/// <param name="b">точка спуска с основания трапеции</param>
		/// <param name="Dfrom">Начало множества определения функции</param>
		/// <param name="Dto">Конец множества определения функции</param>
		/// <param name="inverse">Инверсия значений функции принадлежности</param>
		public Trapecidal (string name, double a, double max1, double max2, double b, double Dfrom, double Dto, bool inverse = false) : base(name, x => 0, Dfrom, Dto)
			{
			_A = a;
			_B = b;
			_Max1 = max1;
			_Max2 = max2;
			_func = Calculate;
			side1 = new Linear("", a, max1, a, max1, inverse);
			side2 = new Linear("", max2, b, max2, b, !inverse);
			}

		public override double Calculate (double x)
			{
			double outside = _inverse ? 1 : 0;
			double inside = _inverse ? 0 : 1;

			if ( x < _A || x > _B )
				return outside;

			if ( _Max1 <= x && x <= _Max2)
				return inside;

			if ( _A < x && x < _Max1 )
				return side1.Calculate(x);
			else
				return side2.Calculate(x);
			}

		public static Trapecidal operator - (Trapecidal first)
			{
			return new Trapecidal("не " + first.Name, 
								first._A, 
								first._Max1, 
								first._Max2,
								first._B,
								first.From,
								first.To,
								!first._inverse);
			}
		}
	}
