namespace N35_HT_Task2;

public record Book
{
    public static (string title, string author, int publicationYear)
        Books = ("Sherlok Holms","jony Jekson",2003);
    string karl = Books.title;
    string kokoy = Books.author;
    int year = Books.publicationYear;
}