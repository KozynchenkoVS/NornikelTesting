using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Menu
    {
        public User User { get; set; }
        public Character CurChar { get; set; }
        public Menu(User? user)
        {
            User = user;
            CurChar = null;
        }

        public Menu SetCharacter(Character choice)
        {
            this.CurChar = choice;
            return this;
        }
      public void Hello()
        {
            Console.WriteLine("Добрый день, зарегистрируйтесь или авторизуйтесь");
        }
      public void ShowMenu()
        {
            if (User == null)
            {
                this.ShowFirst();
            }
            else this.Show();
        }
        public void ShowFirst()
        {
            Console.WriteLine("1. Авторизация");
            Console.WriteLine("2. Регистрация");
            var c = Console.ReadLine();
            int choice;
            if (!Int32.TryParse(c, out choice))
            {
                throw new ArgumentException();
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter name");
                    var a = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    var b = Console.ReadLine();
                    this.Autherization(a, b, null); 
                    break;
                case 2:
                    Console.WriteLine("Enter name");
                    var d = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    var e = Console.ReadLine();
                    this.Registration(d, e, null);
                    break;
            }
        }
      public void Show()
        {
            Console.WriteLine(User.Name);
            Console.WriteLine(DateTime.Now.ToString());
            if (User != null & CurChar == null)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Info");
                Console.WriteLine("2. Characters");
            }
            else 
            {
                Console.WriteLine("1. Info User");
                Console.WriteLine("2. Info Character");
                Console.WriteLine("3. Duel with Shadow");
                Console.WriteLine("4. Ratings");
                Console.WriteLine("5. Training");
            }
        }
      public void SelectChar(string choice)
        {
            foreach (var b in this.User.Characters)
            {
                b.print();
            }
            if (this.User.Characters.Count() == 0) { throw new ArgumentException(); }
            else
            {
                //Console.WriteLine("Select Your Character");
                //var a = Console.ReadLine();
                if (!Int32.TryParse(choice, out var number))
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.User.Characters.ElementAt(Convert.ToInt32(choice));
                }
            }
        }
      public Menu Autherization(string name, string password, RPGContext b)
        {
            if (name.Length == 0 || password.Length == 0) { throw new ArgumentNullException(); }
            else
            {

                  var connect = b.Users.Where(x=> x.Name == name).First();
                  if (connect.Password == password)
                    {
                    Console.WriteLine("Успешная авторизация");
                        return new Menu(connect);
                    }
                  else {
                        Console.WriteLine("Неудачная попытка авторизации");
                        //this.ShowFirst();
                        return this; }
               
            }

        }
      public bool Registration(string? name, string? password, RPGContext a)
        {
            if (name.Length == 0 || password.Length == 0) { throw new ArgumentNullException(); }
            else
            {
                List<Character> chars = new List<Character>();
               
                    User user = new User(name, password, chars);
                    a.Users.Add(user);
                    ////a.SaveChanges();
                Console.WriteLine("Регистрация прошла успешно");
                //this.ShowFirst();
                return true;
            }
        }

    }
}
