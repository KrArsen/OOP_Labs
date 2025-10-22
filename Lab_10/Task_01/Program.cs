using System;

class ListyIterator<T>
{
    private T[] items;
    private int index;

    public ListyIterator(params T[] elements)
    {
        items = elements;
        index = 0;
    }

    public bool Move()
    {
        if (HasNext())
        {
            index++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return index + 1 < items.Length;
    }

    public void Print()
    {
        if (items.Length == 0)
            throw new InvalidOperationException("Invalid Operation!");
        Console.WriteLine(items[index]);
    }
}

class Program
{
    static void Main()
    {
        ListyIterator<string> iterator = null;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
                break;

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        if (parts.Length > 1)
                        {
                            string[] elements = new string[parts.Length - 1];
                            for (int i = 1; i < parts.Length; i++)
                                elements[i - 1] = parts[i];
                            iterator = new ListyIterator<string>(elements);
                        }
                        else
                        {
                            iterator = new ListyIterator<string>();
                        }
                        break;

                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "Print":
                        iterator.Print();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
