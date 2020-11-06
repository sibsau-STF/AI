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
    public partial class BookForm : Form
    {
        MainForm main;
        public BookForm(MainForm mainForm)
        {
            InitializeComponent();
            main = mainForm;

            tagListBox.Items.AddRange(main.TagList.ToArray());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (authorTextBox.Text == "" ||
                tagListBox.CheckedItems.Count == 0 ||
                yearTextBox.Text == "" ||
                nameTextBox.Text == "") MessageBox.Show("Поля не могут быть пустыми!");
            else
            {
                Book nBook = new Book(nameTextBox.Text, authorTextBox.Text, yearTextBox.Text, new List<string>(tagListBox.CheckedItems.Cast<string>().ToArray()));
                if (main.BookList.Contains(nBook)) MessageBox.Show( "Такая книга уже существует!");
                else
                {
                    //перезапись
                    List<Book> bookList;
                    using (StreamReader fs = new StreamReader(@"books.json"))
                    {
                        string json = fs.ReadToEnd();
                        bookList = JsonConvert.DeserializeObject<List<Book>>(json);
                    }
                    bookList.Add(nBook);
                    main.BookList.Add(nBook);
                    using (StreamWriter fs = new StreamWriter(@"books.json"))
                    {
                        string json = JsonConvert.SerializeObject(bookList);
                        fs.Write(json);
                    }
                    this.Close();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
