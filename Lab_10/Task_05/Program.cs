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
        {
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < center; i++)
        {
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
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
        if (roomNumber < 1 || roomNumber > rooms.Length)
        {
            Console.WriteLine("Invalid Operation!");
            return;
        }

        Pet room = rooms[roomNumber - 1];
        Console.WriteLine(room == null ? "Room empty" : room.ToString());
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Pet> pets = new Dictionary<string, Pet>();
        Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();

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
                            pets[name] = new Pet(name, age, kind);
                        }
                        else if (parts[1] == "Clinic")
                        {
                            string name = parts[2];
                            int rooms = int.Parse(parts[3]);
                            clinics[name] = new Clinic(name, rooms);
                        }
                        break;

                    case "Add":
                        {
                            string petName = parts[1];
                            string clinicName = parts[2];

                            if (!pets.ContainsKey(petName) || !clinics.ContainsKey(clinicName))
                                throw new InvalidOperationException();

                            bool result = clinics[clinicName].Add(pets[petName]);
                            Console.WriteLine(result);
                        }
                        break;

                    case "Release":
                        {
                            string clinicName = parts[1];
                            if (!clinics.ContainsKey(clinicName))
                                throw new InvalidOperationException();

                            bool result = clinics[clinicName].Release();
                            Console.WriteLine(result);
                        }
                        break;

                    case "HasEmptyRooms":
                        {
                            string clinicName = parts[1];
                            if (!clinics.ContainsKey(clinicName))
                                throw new InvalidOperationException();

                            bool result = clinics[clinicName].HasEmptyRooms();
                            Console.WriteLine(result);
                        }
                        break;

                    case "Print":
                        {
                            string clinicName = parts[1];
                            if (!clinics.ContainsKey(clinicName))
                                throw new InvalidOperationException();

                            if (parts.Length == 2)
                                clinics[clinicName].Print();
                            else
                            {
                                int room = int.Parse(parts[2]);
                                clinics[clinicName].Print(room);
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
