using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MulitList_Starter
{
    public class Program
    {
      
        static void Main(string[] args)
        {
            (new UserLogin()).RunProgram();
            

            // Or, you could go with the more traditional:
            // UserInterface ui = new UserInterface();
            // ui.RunProgram();
        }
    }
     
    // Bit of a hack, but still an interesting idea....
    enum MenuOptions
    {
        // DO NOT USE ZERO!
        // (TryParse will set choice to zero if a non-number string is typed,
        // and we don't want to accidentally set nChoice to be a member of this enum!)
        QUIT = 1,
        ADD_BOOK=2,
        PRINT_BY_AUTHOR=3,
        PRINT_BY_TITLE=4,
        REMOVE_BOOK=5,
        RETURN_lOGIN=6
    }
    enum LoginOptions
    {
        // DO NOT USE ZERO!
        // (TryParse will set choice to zero if a non-number string is typed,
        // and we don't want to accidentally set nChoice to be a member of this enum!)
        QUIT = 1,
        ADD_USER = 2,
        LOGIN_BOOKS_SYSTEM = 3
    }
    class UserInterface
    {
        MultiLinkedListOfBooks theList;
        public void RunProgram(string username)
        {
            int nChoice;
            theList = new MultiLinkedListOfBooks();

            do // main loop
            {
                Console.WriteLine("Your options:");
                Console.WriteLine("{0} : End the program", (int)MenuOptions.QUIT);
                Console.WriteLine("{0} : Add a book", (int)MenuOptions.ADD_BOOK);
                Console.WriteLine("{0} : Print all books by author", (int)MenuOptions.PRINT_BY_AUTHOR);
                Console.WriteLine("{0} : Print all author by book", (int)MenuOptions.PRINT_BY_TITLE);
                Console.WriteLine("{0} : Remove a Book", (int)MenuOptions.REMOVE_BOOK);
                Console.WriteLine("{0} : Return Login", (int)MenuOptions.RETURN_lOGIN);
                if (!Int32.TryParse(Console.ReadLine(), out nChoice))
                {
                    Console.WriteLine("You need to type in a valid, whole number!");
                    continue;
                }
                switch ((MenuOptions)nChoice)
                {
                    case MenuOptions.QUIT:
                        Console.WriteLine("Thank you for using the multi-list program!");
                        break;
                    case MenuOptions.ADD_BOOK:
                        this.AddBook(username);
                        break;
                    case MenuOptions.PRINT_BY_AUTHOR:
                        theList.PrintByAuthor(username);
                        break;
                    case MenuOptions.PRINT_BY_TITLE:
                        theList.PrintByTitle(username);
                        break;
                    case MenuOptions.REMOVE_BOOK:
                        this.RemoveBook(username);
                        break;
                    case MenuOptions.RETURN_lOGIN:
                        UserLogin tester = new UserLogin();
                        tester.ReturnUser();
                        break;
                    default:
                        Console.WriteLine("I'm sorry, but that wasn't a valid menu option");
                        break;

                }
            } while (nChoice != (int)MenuOptions.QUIT);
        }

        public void AddBook(string username)
        {
            Console.WriteLine("ADD A BOOK!");

            Console.WriteLine("Author name?");
            string author = Console.ReadLine();

            Console.WriteLine("Title?");
            string title = Console.ReadLine();

            double price = -1;
            while (price < 0)
            {
                Console.WriteLine("Price?");
                if (!Double.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("I'm sorry, but that's not a number!");
                    price = -1;
                }
                else if (price < 0)
                {
                    Console.WriteLine("I'm sorry, but the number must be zero, or greater!!");
                }
            }

            ErrorCode ec = theList.Add(author, title, price, username);

            // STUDENTS: YOUR ERROR-CHECKING CODE SHOULD GO HERE!
        }

        public void RemoveBook(string username)
        {
            Console.WriteLine("REMOVE A BOOK!");

            Console.WriteLine("Author name?");
            string author = Console.ReadLine();

            Console.WriteLine("Title?");
            string title = Console.ReadLine();

            ErrorCode ec = theList.Remove(author, title, username);

            // STUDENTS: YOUR ERROR-CHECKING CODE SHOULD GO HERE!
        }
    }
    public class UserLogin
    {
       public static SingleCycle singleCycle=new SingleCycle();
        public void RunProgram()
        {
            int nChoice;
            do // main loop
            {
                Console.WriteLine("Your options:");
                Console.WriteLine("{0} : End the program", (int)LoginOptions.QUIT);
                Console.WriteLine("{0} : Add a user", (int)LoginOptions.ADD_USER);
                Console.WriteLine("{0} : Login in Books system", (int)LoginOptions.LOGIN_BOOKS_SYSTEM);
                if (!Int32.TryParse(Console.ReadLine(), out nChoice))
                {
                    Console.WriteLine("You need to type in a valid, whole number!");
                    continue;
                }
                switch ((LoginOptions)nChoice)
                {
                    case LoginOptions.QUIT:
                        Console.WriteLine("Thank you for using the multi-list program!");
                        break;
                    case LoginOptions.ADD_USER:
                        this.AddUser();
                        break;
                    case LoginOptions.LOGIN_BOOKS_SYSTEM:
                        this.LoginBooksSystem();
                        break;
                    default:
                        Console.WriteLine("I'm sorry, but that wasn't a valid menu option");
                        break;

                }
            } while (nChoice != (int)LoginOptions.QUIT);
        }
        public void ReturnUser()
        {
            (new UserLogin()).RunProgram();
        }
        public void AddUser()
        {
            Console.WriteLine("Please enter the user name you want to add:");
            string username = Console.ReadLine();
            BookInfo info=new BookInfo();
            info.title = "";
            info.author = "";
            info.price = -1;
            singleCycle.Append(new userInfo() { username = username,userflag = true,bookInfo = info });
        }

        public void LoginBooksSystem()
        {
             Console.WriteLine("Please enter the login user name:");
             string username = Console.ReadLine();
             bool flag = false;
             //output
             Node c = singleCycle.Head.Next;
             while (c != singleCycle.Head)
             {
                 if (c.Element.username == username)
                 {
                    flag = true;
                 }
                c = c.Next;
             }

             if (flag)
             {
                 (new UserInterface()).RunProgram(username);
             }
             else
             {
                 Console.WriteLine("User name input error, please try again:");
                (new UserLogin()).RunProgram();
             }

             
        }
      
    }
    public enum ErrorCode
    {
        OK,
        DuplicateBook,
        BookNotFound
    }
    public enum SortCode
    {
        OrderByAuthor,
        OrderByTitle
    }
    public class userInfo
    {
        public string username { get; set; }
        public bool userflag { get; set; }
        public BookInfo bookInfo { get; set; }
    }

    public class BookInfo
    {
        public string author { get; set; }
        public string title { get; set; }
        public double price { get; set; }
    }
    

    public class Node
    {
        private userInfo element; 
        private Node next; 

      
        public userInfo Element { get => element; set => element = value; }
       
        internal Node Next { get => next; set => next = value; }

        
        public Node(userInfo val, Node p)
        {
            Element = val;
            Next = p;
        }

      
        public Node(Node p)
        {
            Next = p;
        }

       
        public Node(userInfo val)
        {
            Element = val;
        }

       
        public Node()
        {
            Element = default(userInfo);
            Next = null;
        }
    }
    
   
    public class SingleCycle
    {
        Node head;   

        
        public Node Head { get => head; set => head = value; }

       
        public SingleCycle()
        {
            head = new Node();
            head.Next = head;
        }

      
        public void Append(userInfo item)
        {
            Node p = new Node(item);
            Node c = head;

           
            if (IsEmpty())
            {
                head.Next = p;
                p.Next = head;
                return;
            }

           
            while (c.Next != head)
            {
                c = c.Next;
            }

          
            c.Next = p;
            p.Next = head;
        }

     
        public void Clear()
        {
            head.Next = head;
        }

       
        public void Delete(int i)
        {
            
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("list is empty");
                return;
            }

            
            if (i == 1)
            {
                head.Next = head.Next.Next;
                return;
            }

          
            Node c = head.Next; 
            Node p = new Node(); 
            int j = 1;
            while (c.Next != head && j < i)
            {
               
                p = c;

                c = c.Next;
                ++j;
            }
           
            if (j == i)
            {
                Console.WriteLine(j);
                Console.WriteLine(p.Next.Element);
                
                p.Next = p.Next.Next;
                Console.WriteLine("remove success!!");
            }
           
            else
            {
                Console.WriteLine("localtion is not found");
            }
        }

     
        public userInfo GetElem(int i)
        {
           
            if (IsEmpty())
            {
                Console.WriteLine();
                return default(userInfo);
            }

          
            if (i == 1)
            {
                return head.Element;
            }

          
            Node c = head.Next;
            int j = 1;
            while (c.Next != head && j < i)
            {
                c = c.Next;
                ++j;
            }
           
            if (j == i)
            {
                return c.Element;
            }
            else
            {
                Console.WriteLine("error");
            }
            return default(userInfo);
        }

        public int GetLength()
        {
            if (IsEmpty())
            {
                return 0;
            }

            Node c = head.Next;
            int i = 1;
            while (c.Next != head)
            {
                c = c.Next;
                ++i;
            }
            return i;

        }

       
        public void Insert(userInfo item, int i)
        {
            if (IsEmpty() || i < 1)
            {
                Console.WriteLine("list is empty");
            }

            
            if (i == 1)
            {
                Node c = head.Next; 
                head.Next = new Node(item); 
                head.Next.Next = c; 
                return;
            }

          
            Node c1 = head.Next;
            Node p = new Node();
            int j = 1;
            while (c1.Next != head && j < i)
            {
                p = c1;
                c1 = c1.Next;
                ++j;
            }
         
            if (j == i)
            {
                p.Next = new Node(item);
                p.Next.Next = c1;
            }
            else
            {
                Console.WriteLine("localtion is not found");
            }
        }

       
        public bool IsEmpty()
        {
            return head.Next == head;
        }

       
        public int Locate(userInfo value)
        {
            int i = 1;
            Node c = head.Next;
            while (c != head && !c.Element.userflag.Equals(value.userflag) && !c.Element.username.Equals(value.username))
            {
                c = c.Next;
                ++i;
            }

            if (c == head)
            {
                Console.WriteLine("not found node");
                return -1;
            }
            else
            {
                return i;
            }
        }
      
        public int Locate1(userInfo value)
        {
            int i = 1;
            Node c = head.Next;
            while (c != head && !c.Element.bookInfo.title.Equals(value.bookInfo.title) && !c.Element.bookInfo.author.Equals(value.bookInfo.author) && !c.Element.username.Equals(value.username))
            {
                c = c.Next;
                ++i;
            }

            if (c == head)
            {
                Console.WriteLine("node is not found");
                return -1;
            }
            else
            {
                return i;
            }
        }


    }

    public class MultiLinkedListOfBooks
    {
        public class Book
        {
          
            // This compares 'this' book to the other book's author and title.
            // This version FIRST compares by author, and if they're the same THEN compares by title
            public int CompareAuthorTHENTitle(string otherBooksAuthor, string otherBooksTitle)
            {
                return 0;
            }

            // This compares 'this' book to the other book's author and title.
            // This version FIRST compares by title, and if they're the same THEN compares by author
            public int CompareTitleTHENAuthor(string otherBooksAuthor, string otherBooksTitle)
            {   // You may (or may not) need this method
                return 0;
            }

            // Print out the book info (author, title, price).
            public void Print(string username,SortCode code)
            {
                if (code == SortCode.OrderByAuthor)
                {
                   
                    bool flag = false;
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        Node node = UserLogin.singleCycle.Head.Next;
                        while (node != UserLogin.singleCycle.Head)
                        {
                            if (node.Element.username == username)
                            {
                                if (node.Element.userflag != true)
                                {
                                    if (node.Element.bookInfo.author.Substring(0, 1).ToLower() == i.ToString())
                                    {
                                        Console.WriteLine("---------------");
                                        Console.WriteLine(" Book Author:" + node.Element.bookInfo.author);
                                        Console.WriteLine(" Book Title:" + node.Element.bookInfo.title);
                                        Console.WriteLine(" Price:$" + node.Element.bookInfo.price);
                                        Console.WriteLine("---------------");
                                        flag = true;
                                    }
                                }
                            }
                            node = node.Next;
                        }
                    }

                    if (!flag)
                    {
                        Console.WriteLine("Books list is empty!!!");
                    }
                }
                else
                {
                   
                    bool flag = false;
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        Node node = UserLogin.singleCycle.Head.Next;
                        while (node != UserLogin.singleCycle.Head)
                        {
                            if (node.Element.username == username)
                            {
                                if (node.Element.userflag != true)
                                {
                                    if (node.Element.bookInfo.title.Substring(0, 1).ToLower() == i.ToString())
                                    {
                                        Console.WriteLine("---------------");
                                        Console.WriteLine(" Book Author:" + node.Element.bookInfo.author);
                                        Console.WriteLine(" Book Title:" + node.Element.bookInfo.title);
                                        Console.WriteLine(" Price:$" + node.Element.bookInfo.price);
                                        Console.WriteLine("---------------");
                                        flag = true;
                                    }
                                }
                            }
                            node = node.Next;
                        }
                    }

                    if (!flag)
                    {
                        Console.WriteLine("Books list is empty!!!");
                    }
                }
            }
        }

        public ErrorCode Add(string author, string title, double price,string username)
        {
            // If the book is already in the list (author, title), then
            // do the following:
            Node node = UserLogin.singleCycle.Head.Next;
            bool flag = false;
            while (node != UserLogin.singleCycle.Head)
            {
                if (node.Element.username == username&& node.Element.bookInfo.author==author&& node.Element.bookInfo.title==title)
                {
                    flag=true;
                    break;
                }
                node = node.Next;
            }

            if (flag == true)
            {
                return ErrorCode.DuplicateBook;
            }
            // having multiple books with the same author, but different titles, or 
            // multiple books with the same title, but different authors, is fine.

            // two books with the same author & title should be identified as duplicates,
            // even if the prices are different.
           
            userInfo user = new userInfo();
            BookInfo bookInfo = new BookInfo();
            bookInfo.author = author;
            bookInfo.title = title;
            bookInfo.price = price;
            user.bookInfo = bookInfo;
            user.username = username;
            user.userflag = false;
            UserLogin.singleCycle.Append(user);
            //}
            return ErrorCode.OK;
        }
        public void PrintByAuthor(string username)
        {
            // if there are no books, then print out a message saying that the list is empty
            Console.WriteLine("Books owned by the user:");
            Book book = new Book();
            book.Print(username, SortCode.OrderByAuthor);
        }
        public void PrintByTitle(string username)
        {
            Console.WriteLine("Books owned by the user:");
            Book book = new Book();
            book.Print(username, SortCode.OrderByTitle);
        }
        public ErrorCode Remove(string author, string title,string username)
        {
            // if there isn't an exact match, then do the following:
            Node node = UserLogin.singleCycle.Head.Next;
            bool flag = false;
            while (node != UserLogin.singleCycle.Head)
            {
                if (node.Element.username == username)
                {
                    if (node.Element.bookInfo != null)
                    {
                        if (node.Element.bookInfo.author==author&& node.Element.bookInfo.title == title)
                        {
                            node.Element.userflag = true;
                            UserLogin.singleCycle.Delete(UserLogin.singleCycle.Locate1(node.Element)+1);
                            flag = true;
                        }
                    }
                }
                node = node.Next;
            }
            

            if (!flag)
            {
                Console.WriteLine("there isn't an exact match!!!");
                return ErrorCode.BookNotFound;
            }
            else
            {
                return ErrorCode.OK;
            }
            // (this includes finding a book by the given author, but with a different title,
            // or a book with the given title, but a different author)
        }
    }
}
