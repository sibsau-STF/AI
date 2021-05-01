package Controllers;

import Classes.Book;
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

public class AddConsequentController implements Initializable {

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
    public FlowPane add_area_pane;
    @FXML
    public Button add_antecedent_button;
    @FXML
    public Button add_rule_button;
    @FXML
    public Button add_consequent_button;
    @FXML
    public TextField bookNameTextBox;
    @FXML
    public TextField yearTextBox;
    @FXML
    public TextField authorTextBox;
    @FXML
    public Button add_button;
    @FXML
    public ComboBox<ComboBoxItemWrap<String>> tag_choice_box;
    //endregion
    List<String> tagList;
    Gson gson;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        gson = new Gson();
        String json = null;
        try {
            json = new String(Files.readAllBytes(Paths.get("src/Data/tags.json")));
            tagList = gson.fromJson(json, new TypeToken<List<String>>(){}.getType());

        } catch (IOException e) {
            e.printStackTrace();
        }
        //делаем список тегов для чойсбокса
        ObservableList<ComboBoxItemWrap<String>> options = FXCollections.observableArrayList();
        for (String t: tagList) {
            options.add(new ComboBoxItemWrap<>(t));
        }

        tag_choice_box.setCellFactory( c -> {
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
                tag_choice_box.getItems().filtered( f-> f!=null).filtered( f-> f.getCheck()).forEach( p -> {
                    sb.append("; "+p.getItem());
                });
                final String string = sb.toString();
                tag_choice_box.setPromptText(string.substring(Integer.min(2, string.length())));
            });

            return cell;
        });
        tag_choice_box.setItems(options);
    }

    public void onClick_AddAntecedentButton(ActionEvent actionEvent) {
        //смена макета интерфейса на главный
        try {
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_antecedent_layout.fxml"));
            add_antecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void onClick_AddRuleButton(ActionEvent actionEvent) {
        try {
            //смена макета интерфейса
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_rule_layout.fxml"));
            add_antecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void onClick_AddConsequentButton(ActionEvent actionEvent) {
        //смена макета интерфейса на главный
        try {
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/main_layout.fxml"));
            add_antecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void onClick_AddButton(ActionEvent actionEvent) {

        if((bookNameTextBox.getText()!=null && !bookNameTextBox.getText().equals("") && !Pattern.matches("\\s*", bookNameTextBox.getText()))
        || (yearTextBox.getText()!=null && !yearTextBox.getText().equals("") && !Pattern.matches("\\s*", yearTextBox.getText())
        || (authorTextBox.getText()!=null && !authorTextBox.getText().equals("") && !Pattern.matches("\\s*", authorTextBox.getText())))){
            gson = new Gson();
            try {
                //экземпляр новой книги
                Book book = new Book(
                        "\""+bookNameTextBox.getText()+"\"",
                        authorTextBox.getText(),
                        yearTextBox.getText(),
                        Arrays.asList(tag_choice_box.getPromptText().split("; "))
                );
                //возьмем все книги из файла
                String json = new String(Files.readAllBytes(Paths.get("src/Data/books.json")));
                List<Book> bookList = gson.fromJson(json, new TypeToken<List<Book>>(){}.getType());
                //если нет дубликатов
                if (!book.isContained(bookList)) {
                    //добавим и запишем в файл
                    bookList.add(book);
                    json = gson.toJson(bookList);
                    Files.writeString(Paths.get("src/Data/books.json"),json);
                    Parent root = FXMLLoader.load(getClass().getResource("../Layouts/main_layout.fxml"));
                    add_antecedent_button.getScene().setRoot(root);
                }
                else {
                    JOptionPane.showMessageDialog(new JFrame("Ошибка"),"Такая книга уже существует!","Ошибка", JOptionPane.ERROR_MESSAGE);
                }
            } catch (Exception e) {
                JOptionPane.showMessageDialog(new JFrame("Ошибка"),e.getMessage(),"Ошибка", JOptionPane.ERROR_MESSAGE);
            }
        }
        else{
            JOptionPane.showMessageDialog(new JFrame("Ошибка"),"Поля книги не могут быть пустыми!","Ошибка", JOptionPane.ERROR_MESSAGE);
        }
    }

}
