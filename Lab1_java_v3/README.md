# AI
## Информация:
Данный проект создан с помощью Intellij IDEA

Приложение написано на платформе JavaFX
## Структура:
* Проект включает в себя 4 макета интерфейса (/Layouts/):
  * main_layout.fxml
  * add_antecedent_layout.fxml
  * add_consequent_layout.fxml
  * add_rule_layout.fxml
* И четыре контроллера (/Controllers/) соответственно:
  * MainController.java
  * AddAntecedentController.java
  * AddConsequentController.java
  * AddRuleController.java

Main.java   - класс запуска программы
* В папке (/Data/) содержатся файлы tags.json, rules.json, books.json для хранения тэгов, правил и книг соответственно
  В этой же папке содержится пакет GSON для упрощенной работы с JSON-форматом

* Также в проекте описаны классы: Book.java и Rule.java (/Classes/)

* Внешний вид интерфейса настраивается в файлах макета и в css-файле (/Styles/)
