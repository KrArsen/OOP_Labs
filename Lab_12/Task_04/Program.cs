using System;
using System.Collections.Generic;

    public class UnitDeathEventArgs : EventArgs
    {
        private Unit unit;

        public UnitDeathEventArgs(Unit unit)
        {
            this.unit = unit;
        }

        public Unit Unit { get { return unit; } }
    }

    
    public abstract class Unit
    {
        protected string name;
        protected int health;

        public event EventHandler<UnitDeathEventArgs> UnitDied;

        protected Unit(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public string Name { get { return name; } }

        public void TakeHit()
        {
            health--;
            if (health <= 0)
            {
                OnUnitDied();
            }
        }

        protected virtual void OnUnitDied()
        {
            if (UnitDied != null)
            {
                UnitDied(this, new UnitDeathEventArgs(this));
            }
        }

        public abstract void RespondToAttack();
    }

    
    public class RoyalGuard : Unit
    {
        public RoyalGuard(string name) : base(name, 3)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine("Royal Guard " + name + " is defending!");
        }
    }

    
    public class Footman : Unit
    {
        public Footman(string name) : base(name, 2)
        {
        }

        public override void RespondToAttack()
        {
            Console.WriteLine("Footman " + name + " is panicking!");
        }
    }

    
    public class King
    {
        private string name;
        private List<Unit> units;

        public King(string name)
        {
            this.name = name;
            this.units = new List<Unit>();
        }

        public string Name { get { return name; } }

        public void AddUnit(Unit unit)
        {
            units.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            units.Remove(unit);
        }

        public void RespondToAttack()
        {
            Console.WriteLine("King " + name + " is under attack!");

            
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i] is RoyalGuard)
                {
                    units[i].RespondToAttack();
                }
            }

            for (int i = 0; i < units.Count; i++)
            {
                if (units[i] is Footman)
                {
                    units[i].RespondToAttack();
                }
            }
        }

        public Unit FindUnitByName(string unitName)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Name == unitName)
                {
                    return units[i];
                }
            }
            return null;
        }
    }

    public class Program
    {
        public static void Main()
        {
            string kingName = Console.ReadLine();
            string[] guardsInput = Console.ReadLine().Split(' ');
            string[] footmenInput = Console.ReadLine().Split(' ');

            King king = new King(kingName);

            
            for (int i = 0; i < guardsInput.Length; i++)
            {
                RoyalGuard guard = new RoyalGuard(guardsInput[i]);
                guard.UnitDied += delegate (object sender, UnitDeathEventArgs e)
                {
                    king.RemoveUnit(e.Unit);
                };
                king.AddUnit(guard);
            }

            
            for (int i = 0; i < footmenInput.Length; i++)
            {
                Footman footman = new Footman(footmenInput[i]);
                footman.UnitDied += delegate (object sender, UnitDeathEventArgs e)
                {
                    king.RemoveUnit(e.Unit);
                };
                king.AddUnit(footman);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split(' ');

                if (parts[0] == "Attack" && parts[1] == "King")
                {
                    king.RespondToAttack();
                }
                else if (parts[0] == "Kill")
                {
                    string unitName = parts[1];
                    Unit unit = king.FindUnitByName(unitName);

                    if (unit != null)
                    {
                        unit.TakeHit();
                    }
                }

                input = Console.ReadLine();
            }
        }
    }

