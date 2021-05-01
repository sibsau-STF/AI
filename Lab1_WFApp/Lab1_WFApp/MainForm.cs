using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_WFApp
{
    public partial class MainForm : Form
    {
        private List<Rule> ruleList;
        private List<Book> bookList;
        private List<string> tagList;

        /*текущий стэк и текущее правило*/
        protected List<string> ruleStack;
        private Rule currentRule;

        private int askCount = 0;
        private bool bookFound = false;

        internal List<Rule> RuleList { get => ruleList; set => ruleList = value; }
        internal List<Book> BookList { get => bookList; set => bookList = value; }
        public List<string> TagList { get => tagList; set => tagList = value; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ruleStack = new List<string>();
            loadRuleArrayList();
            loadBookArrayList();
            loadTagArrayList();

            currentRule = RuleList[0];
            askCount = 1;
            ruleStack.Add("Начало");

            //установка текста в label
            label.Text = currentRule.Ask;
        }


        /**
        * Данный метод выполняет загрузку правил из JSON-файла
        * в список ruleList
        */
        public void loadRuleArrayList()
        {
            try
            {
                using (StreamReader fs = new StreamReader(@"rules.json"))
                {
                    string json = fs.ReadToEnd();
                    RuleList = JsonConvert.DeserializeObject<List<Rule>>(json);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /**
         * Данный метод выполняет загрузку книг из JSON-файла
         * в список bookList
         */
        public void loadBookArrayList()
        {
            try
            {
                using (StreamReader fs = new StreamReader(@"books.json"))
                {
                    string json = fs.ReadToEnd();
                    BookList = JsonConvert.DeserializeObject<List<Book>>(json);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /**
         * Данный метод выполняет загрузку тегов из JSON-файла
         * в список tagList
         */
        public void loadTagArrayList()
        {
            try
            {
                using (StreamReader fs = new StreamReader(@"tags.json"))
                {
                    string json = fs.ReadToEnd();
                    TagList = JsonConvert.DeserializeObject<List<String>>(json);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /**
    * Данный метод производит поиск следующего правила.
    * Сперва наиболее подходящего, потом любое возможное.
    * Также выводит результат, если количество задаванных вопросов
    * превышает 5
    */
        public void findNextRule()
        {

            //если количество вопросов меньше 5,
            //то ищем следующий подходящий вопрос
            if (askCount <= 5)
            {
                //поиск подходящего правила по тегам
                currentRule = RuleList
                    .Find(r => r.Antecedent.Contains(ruleStack[ruleStack.Count - 1]));
                //если нашли правило, то пишем текст
                if (currentRule != null)
                {
                    label.Text = currentRule.Ask;
                }
                //иначе
                else
                {
                    //ищем все подходящие вопросы
                    foreach (String tag in ruleStack)
                    {
                        currentRule = RuleList.Find(r=>r.Antecedent.Contains(tag));
                        if (currentRule != null)
                        {
                            label.Text = currentRule.Ask;
                            break;
                        }
                    }
                    if (RuleList == null)
                    {
                        label.Text = "Извините, не получилось подобрать вам подходящий вариант :(\nПопробуйте еще раз";
                        yesButton.Visible = false;
                        noButton.Visible = false;
                    }
                }
            }
            else
            {
                Book book = Book.findBook(ruleStack, BookList);
                if (book != null)
                {
                    label.Text = "Возможно вам понравится:\n" + book.Name +
                            "\nАвтор: " + book.Author + "\nГод: " + book.Year + "\nВас устраивает такой вариант?:)";
                    BookList.Remove(book);
                    bookFound = true;
                }
                else
                {
                    label.Text = "Извините, не получилось подобрать вам подходящий вариант :(\nПопробуйте еще раз";
                    yesButton.Visible=false;
                    noButton.Visible=false;
                }
            }
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            if (!bookFound)
            {
                ruleStack.Add(currentRule.Consequent);

                if (currentRule.Consequent.Equals("Печатный вариант"))
                    RuleList.Remove(RuleList.Find(rule=>rule.Consequent.Equals("Конец")));
                RuleList.Remove(currentRule);
                findNextRule();
                askCount++;
            }
            else
            {
                //onClick_RepeatButton(actionEvent);
                bookFound = false;
                label.Text = "Рады были помочь!:)";
                yesButton.Visible = false;
                noButton.Visible = false;
            }
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            if (!bookFound)
            {
                RuleList.Remove(currentRule);
                if (currentRule.Consequent.Equals("Конец")) RuleList.Clear();

                findNextRule();
                askCount++;
            }
            else
            {
                askCount = 1;
                bookFound = false;
                findNextRule();

            }
        }

        private void repeatButton_Click(object sender, EventArgs e)
        {
            ruleStack.Clear();
            askCount = 1;
            bookFound = false;

            loadRuleArrayList();
            loadBookArrayList();
            currentRule = RuleList[0];
            label.Text = currentRule.Ask;

            yesButton.Visible = true;
            noButton.Visible = true;
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            TagForm tagForm = new TagForm(this);
            tagForm.Show();
        }

        private void addRuleButton_Click(object sender, EventArgs e)
        {
            RuleForm ruleForm = new RuleForm(this);
            ruleForm.Show();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(this);
            bookForm.Show();
        }
    }
}
