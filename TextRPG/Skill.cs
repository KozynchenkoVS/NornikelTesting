using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Skill
    {

        public Skill(string name, string description, int cost, int damage)        {
            Name = name;
            Description = description;
            this.cost = cost;
            this.damage = damage;

       }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int cost { get; set; }
        public int damage { get; set; }

    }
}
