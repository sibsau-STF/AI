using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Funcs;
using Function = lab2.Funcs.Function;

namespace lab2
{
    public class Criteria
    {
        List<Function> funcs;

        public Criteria(IEnumerable<Function> ownFunctions)
        {
            funcs = ownFunctions.ToList();
        }

        public CriteriaResult Calculate(double x)
        {
            var results = funcs.Select(func => func.Calculate(x)).ToList();
            var maxVal = results.Max();
            int index = results.IndexOf(maxVal);
            var accepted = funcs[index];
            return new CriteriaResult(accepted, maxVal);
        }
    }
}