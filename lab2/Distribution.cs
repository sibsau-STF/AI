using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    /// <summary>
    /// Набор генераторов функций принадлежности
    /// </summary>
    public class Distribution
    {
        public static Func<double, double> Logistic(double mu, double s, double dx = 0, bool inverse = false)
        {
            double sign = inverse ? -1 : 1;
            return x => 1 / (1 + Math.Exp(-(x - mu) * sign / s) + dx);
        }

        public static Func<double, double> Exponential(double lambda, double dx = 0)
        {
            return x => lambda * Math.Exp(-lambda * x + dx);
        }

        /// <summary>
        /// Функция вида Z
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="inverse"></param>
        /// <returns></returns>
        public static Func<double, double> Linear(double from, double to, bool inverse = false)
        {
            // обращаю переход значений
            var len = (to - from) * (inverse ? -1 : 1);
            var start = inverse ? 1 : 0;
            var end = inverse ? 0 : 1;
            return (x) => (x < from) ? start : (x > to) ? end : (x - from) / len;
        }

        public static Func<double, double> Triangular(double from, double peak, double to)
        {
            return x =>
            {
                if (x < from || x > to)
                    return 0;
                if (from < x && x < peak)
                    return Linear(from, peak, false)(x);
                else
                    return Linear(peak, to, true)(x);
            };
        }

        public static Func<double, double> Trapecidal(double from, double max1, double max2, double to)
        {
            return x =>
            {
                if (x < from || x > to)
                    return 0;

                if (max1 <= x && x <= max2)
                    return 1;

                if (from < x && x < max1)
                    return Linear(from, max1, false)(x);
                else
                    return Linear(max2, to, true)(x);
            };
        }
    }
}