package Classes;

import java.util.ArrayList;
import java.util.List;
/**
 * Класс "Правило": условия, текст, результат (не книга)
 */
public class Rule {

    //условие
    private List<String> antecedent;
    //текст
    private String ask;
    //действие
    private String consequent;

    public Rule(List<String> antecedent, String ask, String consequent) {
        this.antecedent = antecedent;
        this.ask = ask;
        this.consequent = consequent;
    }
    public Rule(Rule rule) {
        this.antecedent = rule.antecedent;
        this.ask = rule.ask;
        this.consequent = rule.consequent;
    }
    public Rule() {
    }

    public List<String> getAntecedent() {
        return antecedent;
    }

    public String getAsk() {
        return ask;
    }

    public String getConsequent() {
        return consequent;
    }


    public float getSimilarDegree(Rule rule){
        float degree = 0;

        //получаем количество совпадений и вычисляем коэффициент
        List<String> similars = new ArrayList<>(rule.getAntecedent());
        similars.retainAll(antecedent);
        degree = (float)similars.size() / (float)antecedent.size();

        return  degree;
    }

    public boolean isContained(List<Rule> rules){
        boolean flag = false;

        for (Rule r: rules) {
            if(getSimilarDegree(r) == 1 &&
               r.getAsk().equals(ask)&&
               r.getConsequent().equals(consequent)){
                flag = true;
                break;
            }
        }
        return flag;
    }
}
