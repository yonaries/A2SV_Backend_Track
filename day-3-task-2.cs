using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }

    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }
}

public class Library
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public List<Book> Books { get; private set; }
    public List<MediaItem> MediaItems { get; private set; }

    public Library(string name, string address)
    {
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        MediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        MediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("Books");
        foreach (Book book in Books)
        {
            Console.WriteLine("Title: " + book.Title);
            Console.WriteLine("Author: " + book.Author);
            Console.WriteLine("ISBN: " + book.ISBN);
            Console.WriteLine("PublicationYear: " + book.PublicationYear);
            Console.WriteLine("-------");
        }

        Console.WriteLine("");
        Console.WriteLine("Media items");
        foreach (MediaItem item in MediaItems)
        {
            Console.WriteLine("Title: " + item.Title);
            Console.WriteLine("Media type: " + item.MediaType);
            Console.WriteLine("Duration: " + item.Duration);
            Console.WriteLine("-------");
        }
    }
}

public class MediaItem
{
    public string Title { get; private set; }
    public string MediaType { get; private set; }
    public int Duration { get; private set; }

    public MediaItem(string title, string mediaType, int duration)
    {
        Title = title;
        MediaType = mediaType;
        Duration = duration;
    }
}

public class Program
{
    public static string ReadLine(string prompt, Func<string, bool> condition)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        while (condition(input))
        {
            Console.WriteLine("Please enter a valid input");
            Console.Write(prompt);
            input = Console.ReadLine();
        }
        return input;
    }

    public static int ReadNumber(string prompt)
    {
        int result = 0;
        ReadLine(prompt, (input) =>
        {
            return !int.TryParse(input, out result) || result < 0;
        });
        return result;
    }

    public static void Main()
    {
        string name = ReadLine("Library name: ", (input) => string.IsNullOrWhiteSpace(input));
        string address = ReadLine("Library address: ", (input) => string.IsNullOrWhiteSpace(input));

        Library library = new Library(name, address);
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Media item");
            Console.WriteLine("3. Show Library");
            Console.WriteLine("0. Exit");

            choice = ReadNumber("Enter choice: ");
            if (choice == 1)
            {
                library.AddBook(new Book(
                    ReadLine("Title: ", (input) => string.IsNullOrWhiteSpace(input)),
                    ReadLine("Author: ", (input) => string.IsNullOrWhiteSpace(input)),
                    ReadLine("ISBN: ", (input) => string.IsNullOrWhiteSpace(input)),
                    ReadNumber("PublicationYear: ")
                ));
            }
            else if (choice == 2)
            {
                library.AddMediaItem(new MediaItem(
                    ReadLine("Title: ", (input) => string.IsNullOrWhiteSpace(input)),
                    ReadLine("MediaType: ", (input) => string.IsNullOrWhiteSpace(input)),
                    ReadNumber("Duration: ")
                ));
            }
            else if (choice == 3)
            {
                Console.WriteLine("+++++++");
                Console.WriteLine("Name: " + library.Name);
                Console.WriteLine("Address: " + library.Address);
                library.PrintCatalog();
                Console.WriteLine("+++++++");
            }
        }
    }
}
