using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextRPG
{
    public class User
    {
        public User()
        {

        }
        public User(string name, string password, List<Character>? list)
        {
            Name = name;
            Password = password;
            this.Characters = list;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Character>? Characters { get; set;}

        public User CreateCharacter(string a, string c, RPGContext b)
        {
            //Console.WriteLine("Enter name of Character");
            //var a = Console.ReadLine();
            //Console.WriteLine("Enter gender : 1 - male, 0 - female");
            //var c = Console.ReadLine();

            if (Convert.ToInt32(c) != 1 & Convert.ToInt32(c) != 0)
            {
                throw new ArgumentException();
            }
            
                var temp = new Character(a, Convert.ToBoolean(Convert.ToInt32(c)));
                b.Characters.Add(temp);
                this.Characters.Add(temp);
            //b.Users.Update(this);
            //b.SaveChanges();
            Console.WriteLine($"Created character {a}");
            return this;
        }
    }
}
