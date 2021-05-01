using System.Collections.Generic;
using System.Linq;

namespace Lab1_WFApp
{
    class Rule
    {
        //условие
        public List<string> Antecedent { get; set; }
        //текст
        public string Ask { get; set; }
        //действие
        public string Consequent { get; set; }

        public Rule(List<string> Antecedent, string Ask, string Consequent)
        {
            this.Antecedent = Antecedent;
            this.Ask = Ask;
            this.Consequent = Consequent;
        }
        public Rule(Rule rule)
        {
            this.Antecedent = rule.Antecedent;
            this.Ask = rule.Ask;
            this.Consequent = rule.Consequent;
        }
        public Rule()
        {
        }


        public float getSimilarDegree(Rule rule)
        {
            float degree = 0;

            //получаем количество совпадений и вычисляем коэффициент
            List<string> similars = new List<string>(rule.Antecedent);
            //similars.retainAll(Antecedent);
            var sim = from t in rule.Antecedent
                      where Antecedent.Contains(t)
                      select t;
            degree = (float)similars.Count / (float)Antecedent.Count;

            return degree;
        }
       
        public bool isContained(List<Rule> rules)
        {
            bool flag = false;

            foreach (Rule r in rules)
            {
                if (getSimilarDegree(r) == 1 &&
                   r.Ask.Equals(Ask) &&
                   r.Consequent.Equals(Consequent))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
