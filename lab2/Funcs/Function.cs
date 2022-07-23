using System;
using System.Linq;

namespace lab2.Funcs
{
    public class Function
    {
        public enum Modification
        {
            Min = 0,
            Production = 1
        }

        public enum Combination
        {
            Max = 0,
            Sum = 1
        }

        public enum Scalarization
        {
            WieghtCenter = 0,
            MaxValue = 1
        }

        protected Func<double, double> Func;
        protected double From { get; set; }
        protected double To { get; set; }
        private double ScalarValue { get; set; }
        public string Name { get; protected set; }

        protected Function(string name, Func<double, double> func, double from, double to)
        {
            Func = func;
            From = from;
            To = to;
            Name = name;
        }

        public virtual double Calculate(double x) => Func(x);

        static double Normalize(double x) =>
            x switch
            {
                < 0 => 0,
                > 1 => 1,
                _ => x
            };

        public static Function Superposition(Combination method, params Function[] funcs)
        {
            var from = funcs.Select(func => func.From).Min();
            var to = funcs.Select(func => func.To).Max();
            Func<double, double> super;

            return method switch
            {
                Combination.Max => new Function("SuperPosition",
                    x => funcs.Max(f => f.Calculate(x)),
                    from, to),
                Combination.Sum => new Function("SuperPosition",
                    x => funcs.Sum(f => f.Calculate(x)),
                    from, to),
                _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
            };
        }

        public Function Modify(Modification method, double value) =>
            method switch
            {
                Modification.Min => new Function(Name, x =>
                {
                    double calc = Func(x);
                    return calc > value ? value : calc;
                }, From, To),
                Modification.Production => new Function(Name, x => value * Func(x), From, To),
                _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
            };

        public double Scalarize(Scalarization method)
        {
            ScalarValue = method switch
            {
                Scalarization.WieghtCenter => GetWeightCenter(),
                Scalarization.MaxValue => GetMaxValue(),
                _ => ScalarValue
            };

            return ScalarValue;
        }

        private double GetWeightCenter()
        {
            var n = 1000;
            double len = To - From;
            double dx = len / n;
            double sum1 = 0;
            double sum2 = 0;

            for (double x = From; x < To; x += dx)
            {
                double value = Func(x);
                sum1 += value;
                sum2 += value * x;
            }

            return sum2 / sum1;
        }

        private double GetMaxValue()
        {
            var n = 1000;
            var len = To - From;
            var dx = len / n;
            double maxValue = Func(From);
            double xMax = From;
            for (double x = From; x < To; x += dx)
            {
                var value = Func(x);
                if (maxValue < value)
                {
                    maxValue = value;
                    xMax = x;
                }
            }

            return xMax;
        }

        public static Function operator +(Function first, Function second)
        {
            var from = Math.Min(first.From, second.From);
            var to = Math.Max(first.To, second.To);
            return new Function($"({first.Name} или {second.Name})", (x) => Math.Max(first.Func(x), second.Func(x)), from, to);
        }

        public static Function operator *(Function first, Function second)
        {
            var from = Math.Min(first.From, second.From);
            var to = Math.Max(first.To, second.To);
            return new Function($"({first.Name} и {second.Name})", (x) => Math.Min(first.Func(x), second.Func(x)), from, to);
        }
    }
}