using System;

class Item
{
    public string Name { get; set; }
    public long Amount { get; set; }

    public Item(string name, long amount)
    {
        Name = name;
        Amount = amount;
    }
}

class Bag
{
    public Item[] Gold { get; set; } = new Item[1000];
    public Item[] Gems { get; set; } = new Item[1000];
    public Item[] Cash { get; set; } = new Item[1000];

    public int GoldCount { get; set; } = 0;
    public int GemCount { get; set; } = 0;
    public int CashCount { get; set; } = 0;

    public long TotalGold { get; set; } = 0;
    public long TotalGem { get; set; } = 0;
    public long TotalCash { get; set; } = 0;

    public long usedCapacity
    {
        get { return TotalGold + TotalGem + TotalCash; }
    }

    private Item FindItem(Item[] items, int count, string name)
    {
        for (int i = 0; i < count; i++)
        {
            if (items[i].Name == name)
                return items[i];
        }
        return null;
    }

    public void AddItem(string type, string name, long amount)
    {
        if (type == "Gold")
        {
            Item item = FindItem(Gold, GoldCount, name);
            if (item == null)
                Gold[GoldCount++] = new Item(name, amount);
            else
                item.Amount += amount;

            TotalGold += amount;
        }
        else if (type == "Gem")
        {
            if (TotalGold < TotalGem + amount) return;

            Item item = FindItem(Gems, GemCount, name);
            if (item == null)
                Gems[GemCount++] = new Item(name, amount);
            else
                item.Amount += amount;

            TotalGem += amount;
        }
        else if (type == "Cash")
        {
            if (TotalGem < TotalCash + amount) return;

            Item item = FindItem(Cash, CashCount, name);
            if (item == null)
                Cash[CashCount++] = new Item(name, amount);
            else
                item.Amount += amount;

            TotalCash += amount;
        }
    }

    public void Print()
    {
        TypeBag[] types = new TypeBag[3];
        int tCount = 0;
        if (TotalGold > 0) types[tCount++] = new TypeBag("Gold", TotalGold, Gold, GoldCount);
        if (TotalGem > 0) types[tCount++] = new TypeBag("Gem", TotalGem, Gems, GemCount);
        if (TotalCash > 0) types[tCount++] = new TypeBag("Cash", TotalCash, Cash, CashCount);

        
        for (int i = 0; i < tCount - 1; i++)
        {
            for (int j = i + 1; j < tCount; j++)
            {
                if (types[i].TotalAmount < types[j].TotalAmount)
                {
                    TypeBag tmp = types[i];
                    types[i] = types[j];
                    types[j] = tmp;
                }
            }
        }

        for (int i = 0; i < tCount; i++)
        {
            Console.WriteLine($"<{types[i].TypeName}> ${types[i].TotalAmount}");
            types[i].PrintItems();
        }
    }
}

class TypeBag
{
    public string TypeName { get; set; }
    public long TotalAmount { get; set; }
    public Item[] Items { get; set; }
    public int Count { get; set; }

    public TypeBag(string name, long total, Item[] items, int count)
    {
        TypeName = name;
        TotalAmount = total;
        Items = new Item[count];
        for (int i = 0; i < count; i++)
        {
            Items[i] = new Item(items[i].Name, items[i].Amount);
        }
        Count = count;
    }

    public void PrintItems()
    {
       
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = i + 1; j < Count; j++)
            {
                int cmp = string.Compare(Items[j].Name, Items[i].Name);
                if (cmp > 0 || (cmp == 0 && Items[i].Amount > Items[j].Amount))
                {
                    Item tmp = Items[i];
                    Items[i] = Items[j];
                    Items[j] = tmp;
                }
            }
        }

        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine($"##{Items[i].Name} - {Items[i].Amount}");
        }
    }
}

class Program
{
    static void Main()
    {
        long capacity = long.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split();

        Bag bag = new Bag();

        for (int i = 0; i < input.Length; i += 2)
        {
            string name = input[i];
            long amount = long.Parse(input[i + 1]);
            string type = "";

            string lowerName = name.ToLower();

            if (name.Length == 3) type = "Cash";
            else if (name.Length >= 4 && lowerName.EndsWith("gem")) type = "Gem";
            else if (lowerName == "gold") type = "Gold";
            else continue;

            if (bag.usedCapacity + amount > capacity) continue;

            bag.AddItem(type, name, amount);
        }

        bag.Print();
    }
}
