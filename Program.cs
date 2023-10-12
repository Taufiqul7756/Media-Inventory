using System;
using System.Collections.Generic;
using System.Linq;

// Define a generic class for Media
public class Media<T>
{
    public string Title { get; set; }
    public T Info { get; set; }
    public int ReleaseYear
    {
        get; set;
    }

    public Media(string title, T info, int releaseYear)
    {
        Title = title;
        Info = info;
        ReleaseYear = releaseYear;
    }
}

// Implement separate classes for Books, CDs, and DVDs
public class Book : Media<string>
{
    public Book(string title, string author, int releaseYear) : base(title, author, releaseYear) { }
}

public class CD : Media<string>
{
    public CD(string title, string artist, int releaseYear) : base(title, artist, releaseYear) { }
}

public class DVD : Media<string>
{
    public DVD(string title, string director, int releaseYear) : base(title, director, releaseYear) { }
}

public class MediaInventory
{
    public List<Media<string>> Books { get; set; }
    public List<Media<string>> CDs { get; set; }
    public List<Media<string>> DVDs
    {
        get; set;
    }

    public MediaInventory()
    {
        Books = new List<Media<string>>();
        CDs = new List<Media<string>>();
        DVDs = new List<Media<string>>();
    }

    public void AddMedia<T>(List<Media<T>> inventory, Media<T> item)
    {
        inventory.Add(item);
    }

    public void RemoveMedia<T>(List<Media<T>> inventory, Predicate<Media<T>> criteria)
{
    inventory.RemoveAll(criteria);
}


    public void UpdateMedia<T>(List<Media<T>> inventory, string title, Action<Media<T>> updateAction)
    {
        var item = inventory.FirstOrDefault(m => m.Title == title);
        if (item != null)
        {
            updateAction(item);
        }
        else
        {
            Console.WriteLine("Media not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        var inventory = new MediaInventory();
        // Default Books Added
        inventory.Books.AddRange(new List<Media<string>>
        {
            new Book("C Programming", " Shuvin", 2015),
            new Book("Basic JavaScript", "Taufiqul Islam", 2022),
            new Book("C# Basic Guidelines ", "Towhidul Islam", 2023),
            new Book("OOP Basic", "Ashraful Islam", 2023),
            new Book("Book 5", "Shahida Jahan", 2023),
            
        });
        // Default CDs Added

        inventory.CDs.AddRange(new List<Media<string>>
        {
            new CD("CD for C# Programming", " Rasel Ahmed", 2015),
            new CD("Microsoft Install", "Microsoft", 2022),
            new CD("C# Basic Guidelines ", "Towhidul Islam", 2023),
            new CD("OOP Basic", "Ashraful Islam", 2023),
            new CD("Book 6", "Shahida Jahan", 2023),
            
        });
         // Default DVDs Added

        inventory.DVDs.AddRange(new List<Media<string>>
        {
            new DVD("C Programming", " Shuvin", 2015),
            new DVD("Basic JavaScript", "Taufiqul Islam", 2022),
            new DVD("C# Basic Guidelines ", "Towhidul Islam", 2023),
            new DVD("OOP Basic", "Ashraful Islam", 2023),
            new DVD("Book 7", "Shahida Jahan", 2023),
            
        });

        

        int choice; // Declare choice variable once outside the loop

        while (true)
        {
            Console.WriteLine("Media Inventory Management");
            Console.WriteLine("1. Add Media");
            Console.WriteLine("2. Remove Media");
            Console.WriteLine("3. Update Media");
            Console.WriteLine("4. All Media Items");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter media type (1. Book, 2. CD, 3. DVD): ");
                        if (int.TryParse(Console.ReadLine(), out int mediaTypeChoice))
                        {
                            switch (mediaTypeChoice)
                            {
                                case 1:
                                    Console.Write("Enter book title: ");
                                    string bookTitle = Console.ReadLine();
                                    Console.Write("Enter author: ");
                                    string author = Console.ReadLine();
                                    Console.Write("Enter release year: ");
                                        if (int.TryParse(Console.ReadLine(), out int releaseYear))
                                        {
                                            inventory.AddMedia(inventory.Books, new Book(bookTitle, author, releaseYear));
                                            Console.WriteLine("Book added successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid release year. Please enter a valid number.");
                                        }
                                         break;
                                case 2:
                                    Console.Write("Enter CD title: ");
                                    string cdTitle = Console.ReadLine();
                                    Console.Write("Enter artist: ");
                                    string artist = Console.ReadLine();
                                    Console.Write("Enter release year: ");
                                        if (int.TryParse(Console.ReadLine(), out int cdReleaseYear))
                                        {
                                            inventory.AddMedia(inventory.CDs, new CD(cdTitle, artist, cdReleaseYear));
                                            Console.WriteLine("CD added successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid release year. Please enter a valid number.");
                                        }
                                        break;
                                case 3:
                                    Console.Write("Enter DVD title: ");
                                    string dvdTitle = Console.ReadLine();
                                    Console.Write("Enter Director: ");
                                    string director = Console.ReadLine();
                                    Console.Write("Enter release year: ");
                                    if (int.TryParse(Console.ReadLine(), out int dvdReleaseYear))
                                    {
                                        inventory.AddMedia(inventory.DVDs, new DVD(dvdTitle, director, dvdReleaseYear));
                                        Console.WriteLine("DVD added successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid release year. Please enter a valid number.");
                                    }
                                    break;

                                    default:
                                        Console.WriteLine("Invalid media type choice.");
                                        break;
                            }
                        }
                                else
                                {
                                Console.WriteLine("Invalid input. Please enter a number.");
                                }
                            break;

                    // Remove media
                    case 2:
                            Console.WriteLine("Enter media type to remove (1. Book, 2. CD, 3. DVD): ");
                            if (int.TryParse(Console.ReadLine(), out int removeMediaTypeChoice))
                            {
                                switch (removeMediaTypeChoice)
                                {
                                    case 1:
                                        RemoveMediaItem(inventory.Books, "Books");
                                        break;
                                    case 2:
                                        RemoveMediaItem(inventory.CDs, "CDs");
                                        break;
                                    case 3:
                                        RemoveMediaItem(inventory.DVDs, "DVDs");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid media type choice.");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for media type choice.");
                            }
                            break;

                        // Helper method to remove media items from a list based on its title
                        void RemoveMediaItem<T>(List<Media<T>> items, string mediaType)
                        {
                            Console.WriteLine($"Enter the title of the {mediaType} you want to remove:");
                            string titleToRemove = Console.ReadLine();
                            Media<T> itemToRemove = items.FirstOrDefault(m => m.Title.Equals(titleToRemove, StringComparison.OrdinalIgnoreCase));
                            if (itemToRemove != null)
                            {
                                items.Remove(itemToRemove);
                                Console.WriteLine($"{mediaType} item '{titleToRemove}' removed successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"{mediaType} item '{titleToRemove}' not found in the inventory.");
                            }
                        }

                    // Implement Update Media functionality
                    case 3:
                        
                        Console.WriteLine("Enter media type to update (1. Book, 2. CD, 3. DVD): ");
                        if (int.TryParse(Console.ReadLine(), out int updateMediaTypeChoice))
                        {
                            switch (updateMediaTypeChoice)
                            {
                                case 1:
                                    UpdateMediaItem(inventory.Books, "Books");
                                    break;
                                case 2:
                                    UpdateMediaItem(inventory.CDs, "CDs");
                                    break;
                                case 3:
                                    UpdateMediaItem(inventory.DVDs, "DVDs");
                                    break;
                                default:
                                    Console.WriteLine("Invalid media type choice.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for media type choice.");
                        }
                        break;

                    // Helper method to update media items from a list based on its title
                    void UpdateMediaItem<T>(List<Media<T>> items, string mediaType)
                    {
                        Console.WriteLine($"Enter the title of the {mediaType} you want to update:");
                        string titleToUpdate = Console.ReadLine();
                        Media<T> itemToUpdate = items.FirstOrDefault(m => m.Title.Equals(titleToUpdate, StringComparison.OrdinalIgnoreCase));
                        if (itemToUpdate != null)
                        {
                            Console.WriteLine("Enter the new information for the media item:");
                            // You can implement logic here to update specific properties of the media item
                            // For example:
                            Console.Write("New Title: ");
                            itemToUpdate.Title = Console.ReadLine();

                            string infoType = GetInfoType(mediaType);
                            Console.Write($"{itemToUpdate.Info} is a Existing {infoType} | If you want to change ,Please add new {mediaType}'s {infoType} : ");
                            string newInfo = Console.ReadLine();
                            // itemToUpdate.Info = newInfo;
                            // Update the Info property with the new input
                            // itemToUpdate.Info = newInfo;
                            // ...

                            // For simplicity, let's assume you update only the release year in this example
                            Console.Write("New Release Year: ");
                            if (int.TryParse(Console.ReadLine(), out int newReleaseYear))
                            {
                                itemToUpdate.ReleaseYear = newReleaseYear;
                                Console.WriteLine($"{mediaType} item '{titleToUpdate}' updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for release year. Update failed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{mediaType} item '{titleToUpdate}' not found in the inventory.");
                        }
                    }

                    string GetInfoType(string mediaType)
                        {
                            switch (mediaType)
                            {
                                case "Books":
                                    return "Author";
                                case "CDs":
                                    return "Artist";
                                case "DVDs":
                                    return "Director";
                                default:
                                    return "Info";
                            }
                        }

                    // Implement Show all the Media Details
                    case 4:
                        Console.WriteLine("All Media Items:");
                        DisplayMediaItems(inventory.Books, "Books");
                        DisplayMediaItems(inventory.CDs, "CDs");
                        DisplayMediaItems(inventory.DVDs, "DVDs");
                        break;

                    // Helper method to display media items from a list
                    void DisplayMediaItems<T>(List<Media<T>> items, string mediaType)
                    {
                        Console.WriteLine($"{mediaType}:");
                        foreach (var item in items)
                        {
                            // Console.WriteLine($"Title: {item.Title}, Director: {item.Info}, Release Year: {item.ReleaseYear}");
                            string propertyValue;
                            if (mediaType == "Books")
                            {
                                propertyValue = ((Book)(object)item).Info; // Cast to Book and access Author property
                            }
                            else if (mediaType == "CDs")
                            {
                                propertyValue = ((CD)(object)item).Info; // Cast to CD and access Artist property
                            }
                            else if (mediaType == "DVDs")
                            {
                                propertyValue = ((DVD)(object)item).Info; // Cast to DVD and access Director property
                            }
                            else
                            {
                                propertyValue = "N/A";
                            }
                             string propertyType = mediaType == "Books" ? "Author" : mediaType == "CDs" ? "Artist" : "Director";
                            Console.WriteLine($"Title: {item.Title}, {propertyType}: {propertyValue}, Release Year: {item.ReleaseYear}");
                        }
                        Console.WriteLine();
                    }

                    //Exit code
                    case 5:
                        Environment.Exit(0);
                            break;
                                    default:
                                        Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}






