using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Character
    {
        public Character(string name, bool gender)
        {
            Name = name;
            Gender = gender;
            this.strength = 10;
            this.agility = 10;
            this.intelligence = 10;
            this.health = 10;
            this.mana = 10;
            Wins = 0;
            Loses = 0;
            Skills = new HashSet<Skill>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int strength { get; set; }
        public int agility { get; set; }
        public int intelligence { get; set; }
        public int health  { get; set; }
        public int mana { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public HashSet<Skill> Skills { get; set; }

        public void print()
        {
            Console.WriteLine($"Name : {this.Name} CurrentHealth = {this.health}");
        }

        public void AddSkill(Skill skill)
        {
            this.Skills.Add(skill);
        }
        public int SwordAttack(Character target)
        {
            target.health -= 1;
            return target.health;
        }
        public int UseSpell(Character target)
        {
                Random random = new Random();
                var index = random.Next(1);
                target.health -= this.Skills.ElementAt(index).damage;
                return target.health;
        }
        public void Attack(Character enemy)
        {
            if (this.mana>0 & this.Skills.Count > 0) { this.UseSpell(enemy); }
            else { this.SwordAttack(enemy); }
        }

    }
}
