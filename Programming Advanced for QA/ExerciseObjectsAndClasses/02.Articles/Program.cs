using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _02.Articles
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string autor)
        {
            this.Title = title;
            this.Content = content;
            this.Author = autor;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            int n = int.Parse(Console.ReadLine());

            string title = input[0];
            string content = input[1];
            string author = input[2];
            Article book = new Article(title, content, author); 
            
            for (int i = 0; i < n; i++) 
            {
                string [] inputCommand = Console.ReadLine().Split(": ").ToArray();                
                string command = inputCommand[0];
                string changes = inputCommand[1];
                
                switch (command)
                {
                    case "Edit":
                        book.Edit(changes);
                        break;

                    case "ChangeAuthor":
                        book.ChangeAuthor(changes);
                        break;

                    case "Rename":
                        book.Rename(changes);
                        break;
                }
            }

            Console.WriteLine(book);

        }
    }
}