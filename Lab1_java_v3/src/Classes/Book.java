package Classes;

import java.util.ArrayList;
import java.util.List;

/**
 * Класс "Книга": название, автор, год, теги
 */
public class Book {

    private String name;        //Название
    private String author;      //автор
    private String year;           //год
    private List<String> tags;  //теги: жанр, особенности (греческая мифология, славянский фольклор, вов и пр.)

    public Book(String name, String author, String year, List<String> tags) {
        this.name = name;
        this.author = author;
        this.year = year;
        this.tags = tags;
    }
    public Book(Book book) {
        this.name = book.name;
        this.author = book.author;
        this.year = book.year;
        this.tags = new ArrayList<>(book.tags);
    }
    public Book() {
        this.name = "";
        this.author = "";
        this.year = "";
        this.tags = null;
    }

    //region getters & setters
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getYear() {
        return year;
    }

    public void setYear(String year) {
        this.year = year;
    }

    public List<String> getTags() {
        return tags;
    }

    public void setTags(List<String> tags) {
        this.tags = tags;
    }
    //endregion

    //метод определения и возврата степени "схожести" книги по имеющимся в стеке тегам от 0 до 1
    public float getSimilarDegree(List<String> stack){
        float degree = 0;


        //получаем количество совпадений и вычисляем коэффициент
        List<String> similars = new ArrayList<>(tags);
        similars.retainAll(stack);
        degree = (float)similars.size() / (float)tags.size();

        return  degree;
    }
    //поиск наиболее подходящей книги
    public static Book findBook(List<String> stack, List<Book> books){
        float max = 0;
        Book book = null;
        for(int i = 0; i < books.size(); i++){
            if(books.get(i).getSimilarDegree(stack) > max){
                max = books.get(i).getSimilarDegree(stack);
                book = books.get(i);
            }
        }
        /*for(Book b: books) {
           if(b.getSimilarDegree(stack) > max){
               max = b.getSimilarDegree(stack);
               book = b;
           }
        }*/

        return  book;
    }

    public static List<String> toStringArray(List<Book> books){
        List<String> bookList = new ArrayList<String>();
        for (Book b: books) {
            bookList.add(b.getName()+"\n\t"+b.getAuthor()+"\t\n\t"+b.getYear());
        }
        return bookList;
    }
    public boolean isContained(List<Book> books){
        boolean flag = false;

        for (Book b: books) {
            if (b.getSimilarDegree(this.tags) == 1 &&
                b.getName().equals(this.name) &&
                b.getAuthor().equals(this.author) &&
                b.getYear().equals(this.year)
            ) {
                flag = true;
                break;
            }
        }

        return flag;
    }
}
