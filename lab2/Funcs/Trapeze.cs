using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Funcs
{
    public class Trapeze : Function
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _max1;
        private readonly double _max2;
        private readonly bool _inverse;
        private readonly Linear _side1;
        private readonly Linear _side2;

        /// <summary>
        /// Трапецидальная функция принадлежности
        /// </summary>
        /// <param name="name">Название функции принадлежности</param>
        /// <param name="a">точка подъема на основание трапеции</param>
        /// <param name="max1">левая точка на основани трапеции</param>
        /// <param name="max2">правая точка на основании трапеции</param>
        /// <param name="b">точка спуска с основания трапеции</param>
        /// <param name="x1">Начало множества определения функции</param>
        /// <param name="x2">Конец множества определения функции</param>
        /// <param name="inverse">Инверсия значений функции принадлежности</param>
        public Trapeze(string name, double a, double max1, double max2, double b, double x1, double x2, bool inverse = false) : base(name, null!, x1, x2)
        {
            _a = a;
            _b = b;
            _inverse = inverse;
            _max1 = max1;
            _max2 = max2;
            Func = Calculate;
            _side1 = new Linear("", a, max1, a, max1, inverse);
            _side2 = new Linear("", max2, b, max2, b, !inverse);
        }

        public override double Calculate(double x)
        {
            double outside = _inverse ? 1 : 0;
            double inside = _inverse ? 0 : 1;

            if (x < _a || x > _b)
                return outside;

            if (_max1 <= x && x <= _max2)
                return inside;

            if (_a < x && x < _max1)
                return _side1.Calculate(x);
            else
                return _side2.Calculate(x);
        }

        public static Trapeze operator -(Trapeze first)
        {
            return new Trapeze("не " + first.Name,
                first._a,
                first._max1,
                first._max2,
                first._b,
                first.From,
                first.To,
                !first._inverse);
        }
    }
}