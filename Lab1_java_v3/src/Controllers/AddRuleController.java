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
import javafx.scene.control.*;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.FlowPane;

import javax.swing.*;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.List;
import java.util.ResourceBundle;
import java.util.regex.Pattern;

/**
 * Контроллер макета добавления правила
 */
public class AddRuleController implements Initializable {


    /**
     * Класс "элемент combobox + checkbox"
     */
    static class ComboBoxItemWrap<T> {

        private BooleanProperty check = new SimpleBooleanProperty(false);
        private ObjectProperty<T> item = new SimpleObjectProperty<>();

        ComboBoxItemWrap() {
        }

        ComboBoxItemWrap(T item) {
            this.item.set(item);
        }

        ComboBoxItemWrap(T item, Boolean check) {
            this.item.set(item);
            this.check.set(check);
        }

        public BooleanProperty checkProperty() {
            return check;
        }

        public Boolean getCheck() {
            return check.getValue();
        }

        public void setCheck(Boolean value) {
            check.set(value);
        }

        public ObjectProperty<T> itemProperty() {
            return item;
        }

        public T getItem() {
            return item.getValue();
        }

        public void setItem(T value) {
            item.setValue(value);
        }

        @Override
        public String toString() {
            return item.getValue().toString();
        }
    }

    //region Элементы управления
    @FXML
    public FlowPane root_pane;
    @FXML
    public Button flat_addAntecedent_button;
    @FXML
    public Button flat_addRule_button;
    @FXML
    public Button flat__addConsequent_button;
    @FXML
    public ComboBox<ComboBoxItemWrap<String>> antecedent_choice_box;
    @FXML
    public TextArea flat_text_area;
    @FXML
    public ComboBox consequent_choice_box;
    @FXML
    public Label antecedent_list_text;
    @FXML
    public Label consequent_list_text;
    @FXML
    public Button add_button;
    //endregion

    List<String> tagList;
    List<Book> bookList;
    Gson gson;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        gson = new Gson();
        String json = null;
        try {
            json = new String(Files.readAllBytes(Paths.get("src/Data/tags.json")));
            tagList = gson.fromJson(json, new TypeToken<List<String>>(){}.getType());
            json = new String(Files.readAllBytes(Paths.get("src/Data/books.json")));
            bookList = gson.fromJson(json, new TypeToken<List<Book>>(){}.getType());
        } catch (IOException e) {
            e.printStackTrace();
        }
        //делаем список тегов для чойсбокса
        ObservableList<ComboBoxItemWrap<String>> options = FXCollections.observableArrayList();
        for (String t: tagList) {
            options.add(new ComboBoxItemWrap<>(t));
        }

        antecedent_choice_box.setCellFactory( c -> {
            ListCell<ComboBoxItemWrap<String>> cell = new ListCell<>(){
                @Override
                protected void updateItem(ComboBoxItemWrap<String> item, boolean empty) {
                    super.updateItem(item, empty);
                    if (!empty) {
                        final CheckBox cb = new CheckBox(item.toString());
                        cb.selectedProperty().bind(item.checkProperty());
                        setGraphic(cb);
                    }
                }
            };

            cell.addEventFilter(MouseEvent.MOUSE_RELEASED, event -> {
                cell.getItem().checkProperty().set(!cell.getItem().checkProperty().get());
                StringBuilder sb = new StringBuilder();
                antecedent_choice_box.getItems().filtered( f-> f!=null).filtered( f-> f.getCheck()).forEach( p -> {
                    sb.append("\n"+p.getItem());
                });
                final String string = sb.toString();
                antecedent_choice_box.setPromptText(string.substring(Integer.min(2, string.length())));
                antecedent_list_text.setText(string);
            });

            return cell;
        });
        antecedent_choice_box.setItems(options);
        consequent_choice_box.setItems(FXCollections.observableList(tagList));
    }


    public void onClick_buttonAddAntecedent(ActionEvent actionEvent) {
        //смена макета интерфейса на главный
        try {
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_antecedent_layout.fxml"));
            flat_addAntecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void onClick_buttonAddRule(ActionEvent actionEvent) {
        try {
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/main_layout.fxml"));
            flat_addRule_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void onClick_buttonAddConsequent(ActionEvent actionEvent) {
        try {
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_consequent_layout.fxml"));
            flat__addConsequent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Метод добавления правила в файл
     */
    public void onClick_buttonAdd(ActionEvent actionEvent) {
        if((antecedent_list_text.getText()!=null && !antecedent_list_text.getText().equals("") && !Pattern.matches("\\s*", antecedent_list_text.getText()))
                || (flat_text_area.getText()!=null && !flat_text_area.getText().equals("") && !Pattern.matches("\\s*", flat_text_area.getText())
                || (consequent_choice_box.getPromptText()!=null && !consequent_choice_box.getPromptText().equals("") && !Pattern.matches("\\s*", consequent_choice_box.getPromptText())))){
            gson = new Gson();
            try {
                //экземпляр новой книги
                Rule rule = new Rule(
                        Arrays.asList(antecedent_list_text.getText().split("\n")),
                        flat_text_area.getText(),
                        consequent_choice_box.getPromptText()
                );
                //возьмем все книги из файла
                String json = new String(Files.readAllBytes(Paths.get("src/Data/rules.json")));
                List<Rule> ruleList = gson.fromJson(json, new TypeToken<List<Rule>>(){}.getType());
                //если нет дубликатов
                if (!rule.isContained(ruleList)) {
                    //добавим и запишем в файл
                    ruleList.add(rule);
                    json = gson.toJson(ruleList);
                    Files.writeString(Paths.get("src/Data/rules.json"),json);
                    Parent root = FXMLLoader.load(getClass().getResource("../Layouts/main_layout.fxml"));
                    add_button.getScene().setRoot(root);
                }
                else {
                    JOptionPane.showMessageDialog(new JFrame("Ошибка"),"Такое правило уже существует!","Ошибка", JOptionPane.ERROR_MESSAGE);
                }
            } catch (Exception e) {
                JOptionPane.showMessageDialog(new JFrame("Ошибка"),e.getMessage(),"Ошибка", JOptionPane.ERROR_MESSAGE);
            }
        }
        else{
            JOptionPane.showMessageDialog(new JFrame("Ошибка"),"Поля правила не могут быть пустыми!","Ошибка", JOptionPane.ERROR_MESSAGE);
        }

    }

}
