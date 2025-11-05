using System;
    
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);


    public class NameChangeEventArgs : EventArgs
    {
        private string name;

        public NameChangeEventArgs(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }

    
    public class Dispatcher
    {
        private string name;

        
        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnNameChange(new NameChangeEventArgs(value));
                }
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            if (NameChange != null)
            {
                NameChange(this, args);
            }
        }
    }


    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine("Dispatcher's name changed to " + args.Name + ".");
        }
    }


    public class Program
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();
            
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input = Console.ReadLine();
            while (input != "End")
            {
                dispatcher.Name = input;
                input = Console.ReadLine();
            }
        }
    }
