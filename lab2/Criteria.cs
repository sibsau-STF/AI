using System.Collections.Generic;
using System.Linq;
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
            List<double> results = funcs.Select(func => func.Calculate(x)).ToList();
            double maxVal = results.Max();
            int index = results.IndexOf(maxVal);
            Function accepted = funcs[index];
            return new CriteriaResult(accepted, maxVal);
        }
    }
}