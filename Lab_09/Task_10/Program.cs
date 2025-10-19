using System;

class CustomList<T> where T : IComparable<T>
{
    private T[] items;
    private int count;

    public CustomList()
    {
        items = new T[4];
        count = 0;
    }

    public void Add(T element)
    {
        EnsureCapacity();
        items[count++] = element;
    }

    public T Remove(int index)
    {
        T removed = items[index];
        for (int i = index; i < count - 1; i++)
            items[i] = items[i + 1];
        count--;
        return removed;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].CompareTo(element) == 0)
                return true;
        }
        return false;
    }

    public void Swap(int index1, int index2)
    {
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;
        for (int i = 0; i < count; i++)
        {
            if (items[i].CompareTo(element) > 0)
                counter++;
        }
        return counter;
    }

    public T Max()
    {
        T max = items[0];
        for (int i = 1; i < count; i++)
        {
            if (items[i].CompareTo(max) > 0)
                max = items[i];
        }
        return max;
    }

    public T Min()
    {
        T min = items[0];
        for (int i = 1; i < count; i++)
        {
            if (items[i].CompareTo(min) < 0)
                min = items[i];
        }
        return min;
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }

    private void EnsureCapacity()
    {
        if (count == items.Length)
        {
            T[] newItems = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
                newItems[i] = items[i];
            items = newItems;
        }
    }

    public T[] GetItems()
    {
        T[] result = new T[count];
        for (int i = 0; i < count; i++)
            result[i] = items[i];
        return result;
    }

    public void SetItems(T[] sorted)
    {
        for (int i = 0; i < count; i++)
            items[i] = sorted[i];
    }
}


class Sorter
{
    public static void Sort<T>(CustomList<T> list) where T : IComparable<T>
    {
        T[] array = list.GetItems();

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    T temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        list.SetItems(array);
    }
}


class Program
{
    static void Main()
    {
        CustomList<string> list = new CustomList<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split(' ', 2);
            string command = parts[0];

            switch (command)
            {
                case "Add":
                    list.Add(parts[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(parts[1]));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(parts[1]));
                    break;
                case "Swap":
                    string[] indexes = parts[1].Split();
                    list.Swap(int.Parse(indexes[0]), int.Parse(indexes[1]));
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(parts[1]));
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Print":
                    list.Print();
                    break;
                case "Sort":
                    Sorter.Sort(list);
                    break;
            }
        }
    }
}
