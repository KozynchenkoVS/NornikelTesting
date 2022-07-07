using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Duel
    {
        Character paricipantFirst;
        Character paricipantSecond;
        public Duel(Character paricipantFirst, Character paricipantSecond, int turns)
        {
            this.paricipantFirst = paricipantFirst;
            this.paricipantSecond = paricipantSecond;
            this.turns = turns;
        }
        int turns;

        public int BeginDuel()
        {
            int i = turns;
            while(i > 0 & (this.paricipantFirst.health > 0 || this.paricipantSecond.health > 0))
            {
                this.paricipantFirst.Attack(paricipantSecond);
                if (paricipantSecond.health <= 0) break;
                this.paricipantSecond.Attack(paricipantFirst);
                i--;
            }
            if (this.paricipantFirst.health > this.paricipantSecond.health) { return this.paricipantFirst.health; }
            else { return this.paricipantSecond.health; }
        }
    }
}
