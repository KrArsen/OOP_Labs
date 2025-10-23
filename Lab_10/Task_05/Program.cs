using System;

class Pet
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Kind { get; private set; }

    public Pet(string name, int age, string kind)
    {
        Name = name;
        Age = age;
        Kind = kind;
    }

    public override string ToString()
    {
        return $"{Name} {Age} {Kind}";
    }
}

class Clinic
{
    public string Name { get; private set; }  
    private Pet[] rooms;

    public Clinic(string name, int roomCount)
    {
        if (roomCount % 2 == 0)
            throw new InvalidOperationException("Invalid Operation!");

        Name = name;
        rooms = new Pet[roomCount];
    }

    public bool Add(Pet pet)
    {
        int center = rooms.Length / 2;

        for (int i = 0; i < rooms.Length; i++)
        {
            int index = i % 2 == 0 ? center - i / 2 : center + (i + 1) / 2;

            if (index >= 0 && index < rooms.Length && rooms[index] == null)
            {
                rooms[index] = pet;
                return true;
            }
        }

        return false;
    }

    public bool Release()
    {
        int center = rooms.Length / 2;

        for (int i = center; i < rooms.Length; i++)
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }

        for (int i = 0; i < center; i++)
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }

        return false;
    }

    public bool HasEmptyRooms()
    {
        foreach (var room in rooms)
            if (room == null) return true;
        return false;
    }

    public void Print()
    {
        for (int i = 0; i < rooms.Length; i++)
            Console.WriteLine(rooms[i] == null ? "Room empty" : rooms[i].ToString());
    }

    public void Print(int roomNumber)
    {
        Pet room = rooms[roomNumber - 1];
        Console.WriteLine(room == null ? "Room empty" : room.ToString());
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Pet[] pets = new Pet[n];
        Clinic[] clinics = new Clinic[n];
        int petCount = 0;
        int clinicCount = 0;

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        if (parts[1] == "Pet")
                        {
                            string name = parts[2];
                            int age = int.Parse(parts[3]);
                            string kind = parts[4];
                            pets[petCount++] = new Pet(name, age, kind);
                        }
                        else if (parts[1] == "Clinic")
                        {
                            string name = parts[2];
                            int rooms = int.Parse(parts[3]);
                            clinics[clinicCount++] = new Clinic(name, rooms);
                        }
                        break;

                    case "Add":
                        {
                            string petName = parts[1];
                            string clinicName = parts[2];

                            Pet pet = null;
                            Clinic clinic = null;

                            for (int p = 0; p < petCount; p++)
                                if (pets[p].Name == petName) pet = pets[p];

                            for (int c = 0; c < clinicCount; c++)
                                if (clinics[c].Name == clinicName) clinic = clinics[c];

                            if (pet == null || clinic == null)
                                throw new InvalidOperationException();

                            Console.WriteLine(clinic.Add(pet));
                        }
                        break;

                    case "Release":
                        {
                            string clinicName = parts[1];
                            Clinic clinic = null;

                            for (int c = 0; c < clinicCount; c++)
                                if (clinics[c].Name == clinicName) clinic = clinics[c];

                            Console.WriteLine(clinic.Release());
                        }
                        break;

                    case "HasEmptyRooms":
                        {
                            string clinicName = parts[1];
                            Clinic clinic = null;

                            for (int c = 0; c < clinicCount; c++)
                                if (clinics[c].Name == clinicName) clinic = clinics[c];

                            Console.WriteLine(clinic.HasEmptyRooms());
                        }
                        break;

                    case "Print":
                        {
                            string clinicName = parts[1];
                            Clinic clinic = null;

                            for (int c = 0; c < clinicCount; c++)
                                if (clinics[c].Name == clinicName) clinic = clinics[c];

                            if (parts.Length == 2)
                                clinic.Print();
                            else
                            {
                                int room = int.Parse(parts[2]);
                                clinic.Print(room);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Operation!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
