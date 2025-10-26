using System;

public enum WeaponType
{
    Axe,
    Sword,
    Knife
}

public enum Rarity
{
    Common = 1,
    Uncommon = 2,
    Rare = 3,
    Epic = 5
}

public enum GemType
{
    Ruby,
    Emerald,
    Amethyst
}

public enum GemQuality
{
    Chipped = 1,
    Regular = 2,
    Perfect = 5,
    Flawless = 10
}

public class Gem
{
    public int Strength { get; private set; }
    public int Agility { get; private set; }
    public int Vitality { get; private set; }

    public Gem(string fullGemName)
    {
        string[] parts = fullGemName.Split(' ');
        GemQuality quality = (GemQuality)Enum.Parse(typeof(GemQuality), parts[0]);
        GemType type = (GemType)Enum.Parse(typeof(GemType), parts[1]);

        int q = (int)quality; 

        switch (type)
        {
            case GemType.Ruby:
                Strength = 7 + q;
                Agility = 2 + q;
                Vitality = 5 + q;
                break;
            case GemType.Emerald:
                Strength = 1 + q;
                Agility = 4 + q;
                Vitality = 9 + q;
                break;
            case GemType.Amethyst:
                Strength = 2 + q;
                Agility = 8 + q;
                Vitality = 4 + q;
                break;
        }
    }
}

public class Weapon
{
    public string Name { get; private set; }
    private int baseMin;
    private int baseMax;
    private Gem[] sockets;
    private Rarity rarity;

    public Weapon(string rarityType, string weaponType, string name)
    {
        this.rarity = (Rarity)Enum.Parse(typeof(Rarity), rarityType);
        this.Name = name;

        switch ((WeaponType)Enum.Parse(typeof(WeaponType), weaponType))
        {
            case WeaponType.Axe:
                baseMin = 5;
                baseMax = 10;
                sockets = new Gem[4];
                break;
            case WeaponType.Sword:
                baseMin = 4;
                baseMax = 6;
                sockets = new Gem[3];
                break;
            case WeaponType.Knife:
                baseMin = 3;
                baseMax = 4;
                sockets = new Gem[2];
                break;
        }

        baseMin *= (int)rarity;
        baseMax *= (int)rarity;
    }

    public void AddGem(int index, Gem gem)
    {
        if (index >= 0 && index < sockets.Length)
            sockets[index] = gem;
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < sockets.Length)
            sockets[index] = null;
    }

    public override string ToString()
    {
        int totalStrength = 0;
        int totalAgility = 0;
        int totalVitality = 0;

        for (int i = 0; i < sockets.Length; i++)
        {
            if (sockets[i] != null)
            {
                totalStrength += sockets[i].Strength;
                totalAgility += sockets[i].Agility;
                totalVitality += sockets[i].Vitality;
            }
        }

        int minDamage = baseMin + totalStrength * 2 + totalAgility * 1;
        int maxDamage = baseMax + totalStrength * 3 + totalAgility * 4;

        return $"{Name}: {minDamage}-{maxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";
    }
}

public class Program
{
    public static void Main()
    {
        Weapon[] weapons = new Weapon[100];
        int weaponCount = 0;

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split(';');
            string command = parts[0];

            if (command == "Create")
            {
                string[] weaponInfo = parts[1].Split(' ');
                string rarity = weaponInfo[0];
                string type = weaponInfo[1];
                string name = parts[2];

                weapons[weaponCount++] = new Weapon(rarity, type, name);
            }
            else if (command == "Add")
            {
                string weaponName = parts[1];
                int index = int.Parse(parts[2]);
                string gemType = parts[3];

                Weapon weapon = FindWeapon(weapons, weaponCount, weaponName);
                if (weapon != null)
                {
                    Gem gem = new Gem(gemType);
                    weapon.AddGem(index, gem);
                }
            }
            else if (command == "Remove")
            {
                string weaponName = parts[1];
                int index = int.Parse(parts[2]);

                Weapon weapon = FindWeapon(weapons, weaponCount, weaponName);
                if (weapon != null)
                {
                    weapon.RemoveGem(index);
                }
            }
            else if (command == "Print")
            {
                string weaponName = parts[1];
                Weapon weapon = FindWeapon(weapons, weaponCount, weaponName);
                if (weapon != null)
                {
                    Console.WriteLine(weapon);
                }
            }
        }
    }

    private static Weapon FindWeapon(Weapon[] weapons, int count, string name)
    {
        for (int i = 0; i < count; i++)
        {
            if (weapons[i] != null && weapons[i].Name == name)
                return weapons[i];
        }
        return null;
    }
}
