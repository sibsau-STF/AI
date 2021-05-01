using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_WFApp
{
    class Book
    {
        private string name;        //Название
        private string author;      //автор
        private string year;           //год
        private List<string> tags;  //теги: жанр, особенности (греческая мифология, славянский фольклор, вов и пр.)

        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Year { get => year; set => year = value; }
        public List<string> Tags { get => tags; set => tags = value; }

        public Book(string name, string author, string year, List<string> tags)
        {
            this.Name = name;
            this.Author = author;
            this.Year = year;
            this.Tags = tags;
        }
        public Book(Book book)
        {
            this.Name = book.Name;
            this.Author = book.Author;
            this.Year = book.Year;
            this.Tags = new List<string>(book.Tags);
        }
        public Book()
        {
            this.Name = "";
            this.Author = "";
            this.Year = "";
            this.Tags = null;
        }

      

        //метод определения и возврата степени "схожести" книги по имеющимся в стеке тегам от 0 до 1
        public float getSimilarDegree(List<string> stack)
        {
            float degree = 0;


            //получаем количество совпадений и вычисляем коэффициент
            List<string> similars = new List<string>(Tags);
            var sim = from t in Tags
                      where stack.Contains(t)
                      select t;
            degree = (float)sim.Count()/ (float)Tags.Count;

            return degree;
        }
        //поиск наиболее подходящей книги
        public static Book findBook(List<string> stack, List<Book> books)
        {
            float max = 0;
            Book book = null;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].getSimilarDegree(stack) > max)
                {
                    max = books[i].getSimilarDegree(stack);
                    book = books[i];
                }
            }
            /*for(Book b: books) {
               if(b.getSimilarDegree(stack) > max){
                   max = b.getSimilarDegree(stack);
                   book = b;
               }
            }*/

            return book;
        }

        public static List<string> tostringArray(List<Book> books)
        {
            List<string> bookList = new List<string>();
            foreach (Book b in books)
            {
                bookList.Add(b.Name + "\n\t" + b.Author + "\t\n\t" + b.Year);
            }
            return bookList;
        }
        public bool isContained(List<Book> books)
        {
            bool flag = false;

            foreach (Book b in books)
            {
                if (b.getSimilarDegree(this.Tags) == 1 &&
                    b.Name.Equals(this.Name) &&
                    b.Author.Equals(this.Author) &&
                    b.Year.Equals(this.Year)
                )
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }
    }
}
