using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function = lab2.Funcs.Function;

namespace lab2.Funcs
{
    public class Logistic : Function
    {
        private readonly double _mu;
        private readonly double _s;
        private readonly bool _inverse;

        public Logistic(string name, double mu, double s, double x1, double x2, bool inverse) : base(name, x => 0, x1, x2)
        {
            _mu = mu;
            _s = s;
            _inverse = inverse;
            Func = this.Calculate;
        }

        public override double Calculate(double x)
        {
            double sign = _inverse ? -1 : 1;
            return 1 / (1 + Math.Exp(-(x - _mu) * sign / _s));
        }

        public static Logistic operator -(Logistic first)
        {
            return new Logistic("не " + first.Name,
                first._mu,
                first._s,
                first.From,
                first.To,
                !first._inverse);
        }
    }
}