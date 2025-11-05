using System;
using System.Collections.Generic;

namespace KingsGambit
{
    
    public delegate void KingAttackEventHandler(object sender, EventArgs e);

    
    public class King
    {
        private string name;
        public event KingAttackEventHandler KingAttacked;

        public King(string name)
        {
            this.name = name;
        }

        public void OnAttack()
        {
            Console.WriteLine("King " + name + " is under attack!");
            if (KingAttacked != null)
            {
                KingAttacked(this, EventArgs.Empty);
            }
        }
    }

    
    public abstract class Subordinate
    {
        protected string name;
        protected Subordinate(string name)
        {
            this.name = name;
        }

        public abstract void Respond(object sender, EventArgs e);
    }

    
    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name) : base(name) { }

        public override void Respond(object sender, EventArgs e)
        {
            Console.WriteLine("Royal Guard " + name + " is defending!");
        }
    }

    
    public class Footman : Subordinate
    {
        public Footman(string name) : base(name) { }

        public override void Respond(object sender, EventArgs e)
        {
            Console.WriteLine("Footman " + name + " is panicking!");
        }
    }

    
    public class Program
    {
        public static void Main()
        {
            string kingName = Console.ReadLine();
            King king = new King(kingName);

            string[] guards = Console.ReadLine().Split(' ');
            string[] footmen = Console.ReadLine().Split(' ');

            Dictionary<string, Subordinate> army = new Dictionary<string, Subordinate>();

            
            for (int i = 0; i < guards.Length; i++)
            {
                RoyalGuard guard = new RoyalGuard(guards[i]);
                army[guards[i]] = guard;
                king.KingAttacked += guard.Respond;
            }

            
            for (int i = 0; i < footmen.Length; i++)
            {
                Footman footman = new Footman(footmen[i]);
                army[footmen[i]] = footman;
                king.KingAttacked += footman.Respond;
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] parts = command.Split(' ');

                if (parts[0] == "Attack" && parts[1] == "King")
                {
                    king.OnAttack();
                }
                else if (parts[0] == "Kill")
                {
                    string name = parts[1];
                    Subordinate soldier = army[name];

                    
                    king.KingAttacked -= soldier.Respond;
                    army.Remove(name);
                }

                command = Console.ReadLine();
            }
        }
    }
}
