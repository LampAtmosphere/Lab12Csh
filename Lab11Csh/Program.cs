using Lab11Csh;

namespace Lab11Csh
{
// интерфейс Издательство
    public interface IZdatelstvo
    {
        string GetBookTitle();
        string GetAuthor();
    }
// интерфейс Юзер
    public interface IUser
    {
        string GetLogin();
        string GetPassword();
    }
// интерфейс Товар
    public interface ITovar
    {
        void BuyByUser(User user);
    }

    public interface IKniga : IZdatelstvo
    {
        DateTime GetPublicationDate();
        int GetNumberOfPages();
    }
}

public class Book(string title, string author, DateTime publicationDate, int numberOfPages) : IKniga
{
    private string title = title;
    private string author = author;
    private DateTime publicationDate = publicationDate;
    private int numberOfPages = numberOfPages;

    public string GetBookTitle()
    {
        return title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public DateTime GetPublicationDate()
    {
        return publicationDate;
    }

    public int GetNumberOfPages()
    {
        return numberOfPages;
    }
}


public class User(string login, string password) : IUser
{
    private string login = login;
    private string password = password;

    public string GetLogin()
    {
        return login;
    }

    public string GetPassword()
    {
        return password;
    }
}

// Продукт реализ. Товар и Юзер
public class Product : ITovar, IUser
{
    private string productName;
    private string productDescription;

    public Product(string productName, string productDescription)
    {
        this.productName = productName;
        this.productDescription = productDescription;
    }

    public string GetLogin()
    {
        return "Яблоки бананы яблоки бананы"; // Пример значения
    }

    public string GetPassword()
    {
        return "1234"; // Пример значения
    }

    public void BuyByUser(User user)
    {
        Console.WriteLine($"{user.GetLogin()} купил {productName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var book1 = new Book("ПУПИ", "Я", new DateTime(2020, 1, 1), 300);
        var book2 = new Book("НФВЫДР", "Другой Я", new DateTime(2022, 5, 2), 400);

        var user1 = new User("LampAt", "1drowssap");
        var user2 = new User("MEl", "wordpass2");

        var product = new Product("Пельмени", "Вкусные");

        product.BuyByUser(user1);
        product.BuyByUser(user2);

        Console.WriteLine(book1.GetBookTitle());
        Console.WriteLine(book2.GetBookTitle());
    }
}
