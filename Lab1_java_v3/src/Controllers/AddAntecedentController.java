package Controllers;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.layout.FlowPane;

import javax.swing.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
import java.util.regex.Pattern;

public class AddAntecedentController {


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
    public TextArea text_area;
    @FXML
    public Button flat_add_button;
    //endregion


    public void onClick_AddAntecedentButton(ActionEvent actionEvent) {
        //смена макета интерфейса на главный
        try {
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/main_layout.fxml"));
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
        //смена макета интерфейса
        try {
            Parent root = FXMLLoader.load(getClass().getResource("../Layouts/add_consequent_layout.fxml"));
            add_antecedent_button.getScene().setRoot(root);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    //добавление тэга в файл
    public void onClick_AddButton(ActionEvent actionEvent) {
        if(text_area.getText()!=null && !text_area.getText().equals("") && !Pattern.matches("\\s*",text_area.getText())){
            Gson gson = new Gson();
            try {
                //для начала возьмем все теги из файла
                String json = new String(Files.readAllBytes(Paths.get("src/Data/tags.json")));
                List<String> tagList = gson.fromJson(json, new TypeToken<List<String>>(){}.getType());
                //если нет дубликатов
                if (!tagList.contains(text_area.getText())) {
                    //добавим и запишем в файл
                    tagList.add(text_area.getText());
                    json = gson.toJson(tagList);
                    Files.writeString(Paths.get("src/Data/tags.json"),json);
                    Parent root = FXMLLoader.load(getClass().getResource("../Layouts/main_layout.fxml"));
                    add_antecedent_button.getScene().setRoot(root);
                }
                else {
                    JOptionPane.showMessageDialog(new JFrame("Ошибка"),"Такой тэг уже существует!","Ошибка", JOptionPane.ERROR_MESSAGE);
                }
            } catch (Exception e) {
                JOptionPane.showMessageDialog(new JFrame("Ошибка"),e.getMessage(),"Ошибка", JOptionPane.ERROR_MESSAGE);
            }
        }
        else{
            JOptionPane.showMessageDialog(new JFrame("Ошибка"),"Название тега не может быть пустым!","Ошибка", JOptionPane.ERROR_MESSAGE);
        }
    }

}
