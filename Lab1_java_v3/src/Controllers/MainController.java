package Controllers;

import Classes.Book;
import Classes.Rule;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import javafx.beans.property.BooleanProperty;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.property.SimpleObjectProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.FlowPane;
import javafx.stage.Stage;

import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;

import static javafx.fxml.FXMLLoader.load;

/**
 * Контроллер главного макета
 */
public class MainController implements Initializable {

    //region Элементы управления
    @FXML
    public FlowPane rootPane;
    @FXML
    public Button add_antecedent_button;
    @FXML
    public Button add_rule_button;
    @FXML
    public Button add_consequent_button;
    @FXML
    public Label flat_label;
    @FXML
    public Button no_button;
    @FXML
    public Button yes_button;
    @FXML
    public Button repeat_button;
    //endregion

    protected Gson gson;
    /*набор данных*/
    private List<Rule> ruleList;
    private List<Book> bookList;
    private List<String> tagList;

    /*текущий стэк и текущее правило*/
    protected List<String> ruleStack;
    protected Rule currentRule;

    private int askCount = 0;
    private boolean bookFound = false;

    //инициализация: загрузка списка, установка текста ask из начального правила
    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        ruleStack = new ArrayList<>();
        loadRuleArrayList();
        loadBookArrayList();
        loadTagArrayList();
        currentRule = ruleList.get(0);
        askCount = 1;
        ruleStack.add("Начало");
        //установка текста в label
        flat_label.setText(currentRule.getAsk());


        repeat_button.setContentDisplay(ContentDisplay.CENTER);

    }
    /**
     * Данный метод выполняет загрузку правил из JSON-файла
     * в список ruleList
     */
    public void loadRuleArrayList() {
        gson = new Gson();
        try {
            String json = new String(Files.readAllBytes(Paths.get("src/Data/rules.json")));
            ruleList = gson.fromJson(json, new TypeToken<List<Rule>>(){}.getType());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    /**
     * Данный метод выполняет загрузку книг из JSON-файла
     * в список bookList
     */
    public void loadBookArrayList() {
        gson = new Gson();
        try {
            String json = new String(Files.readAllBytes(Paths.get("src/Data/books.json")));
            bookList = gson.fromJson(json, new TypeToken<List<Book>>(){}.getType());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    /**
     * Данный метод выполняет загрузку тегов из JSON-файла
     * в список tagList
     */
    public void loadTagArrayList() {
        gson = new Gson();
        try {
            String json = new String(Files.readAllBytes(Paths.get("src/Data/tags.json")));
            tagList = gson.fromJson(json, new TypeToken<List<String>>(){}.getType());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    /**
     * Данный метод производит поиск следующего правила.
     * Сперва наиболее подходящего, потом любое возможное.
     * Также выводит результат, если количество задаванных вопросов
     * превышает 5
     */
    public void findNextRule(){

        //если количество вопросов меньше 5,
        //то ищем следующий подходящий вопрос
        if(askCount <= 5){
            //поиск подходящего правила по тегам
            currentRule = ruleList.stream()
                    .filter(r->r.getAntecedent()
                            .contains(ruleStack.get(ruleStack.size()-1)))
                    .findFirst().orElse(null);
            //если нашли правило, то пишем текст
            if(currentRule != null) {
                flat_label.setText(currentRule.getAsk());
            }
            //иначе
            else {
                //ищем все подходящие вопросы
                for (String tag: ruleStack) {
                    currentRule = ruleList.stream().filter(r->r.getAntecedent().contains(tag)).findFirst().orElse(null);
                    if(currentRule != null){
                        flat_label.setText(currentRule.getAsk());
                        break;
                    }
                }
                if(ruleList == null ){
                    flat_label.setText("Извините, не получилось подобрать вам подходящий вариант :(\nПопробуйте еще раз");
                    yes_button.setVisible(false);
                    no_button.setVisible(false);
                }
            }
        }
        else{
            Book book = Book.findBook(ruleStack,bookList);
            if(book != null){
                flat_label.setText("Возможно вам понравится:\n"+book.getName()+
                        "\nАвтор: "+book.getAuthor()+"\nГод: "+book.getYear()+"\nВас устраивает такой вариант?:)");
                bookList.remove(book);
                bookFound = true;
            }
            else{
                flat_label.setText("Извините, не получилось подобрать вам подходящий вариант :(\nПопробуйте еще раз");
                yes_button.setVisible(false);
                no_button.setVisible(false);
            }
        }
    }

    /**
     * Данный метод меняет макет интерфейса на add_consequent_layout.fxml
     */
    public void onClick_AddConsequentButton(ActionEvent actionEvent) {
        try {
            //загрузка макета и установка в сцену
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_consequent_layout.fxml"));
            add_antecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    /**
     * Данный метод меняет макет интерфейса на add_antecedent_layout.fxml
     */
    public void onClick_AddAntecedentButton(ActionEvent actionEvent) {
        try {
            //загрузка макета и установка в сцену
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_antecedent_layout.fxml"));
            add_antecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
    /**
     * Данный метод меняет макет интерфейса на add_rule_layout.fxml
     */
    public void onClick_AddRuleButton(ActionEvent actionEvent) {
        try {
            //сзагрузка макета и установка в сцену
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_rule_layout.fxml"));
            add_antecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
    /**
     * Данный метод удаляет текущее правило из списка
     * и производит поиск следующего
     */
    public void onClick_NoButton(ActionEvent actionEvent) {
        if(!bookFound){
            ruleList.remove(currentRule);
            if(currentRule.getConsequent().equals("Конец"))  ruleList.clear();

            findNextRule();
            askCount++;
        }
        else {
            askCount=1;
            bookFound = false;

            findNextRule();

        }
    }
    /**
     * Данный метод добавляет тег в стэк тегов
     * удаляет текущее правило из списка
     * и производит поиск следующего
     *
     */
    public void onClick_YesButton(ActionEvent actionEvent) {
        if(!bookFound){
            ruleStack.add(currentRule.getConsequent());

            if(currentRule.getConsequent().equals("Печатный вариант"))
                ruleList.remove(ruleList.stream().filter(rule -> rule.getConsequent().equals("Конец")).findFirst().get());
            ruleList.remove(currentRule);
            findNextRule();
            askCount++;
        }
        else{
            //onClick_RepeatButton(actionEvent);
            bookFound = false;
            flat_label.setText("Рады были помочь!:)");
            yes_button.setVisible(false);
            no_button.setVisible(false);
        }

    }

    public void onClick_RepeatButton(ActionEvent actionEvent) {
        ruleStack.clear();
        askCount = 1;
        bookFound = false;

        loadRuleArrayList();
        currentRule = ruleList.get(0);
        flat_label.setText(currentRule.getAsk());

        yes_button.setVisible(true);
        no_button.setVisible(true);
    }


    //region геттеры и сеттеры
    public List<Rule> getRuleList() {
        return ruleList;
    }

    public void setRuleList(List<Rule> ruleList) {
        this.ruleList = ruleList;
    }

    public List<Book> getBookList() {
        return bookList;
    }

    public void setBookList(List<Book> bookList) {
        this.bookList = bookList;
    }

    public List<String> getTagList() {
        return tagList;
    }

    public void setTagList(List<String> tagList) {
        this.tagList = tagList;
    }
    //endregion
}
