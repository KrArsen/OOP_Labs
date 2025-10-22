using System;

class Pet
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Kind { get; private set; }

    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}

class Clinic
{
    private string name;
    private Pet[] rooms;

    public Clinic(string name, int roomCount)
    {
        if (roomCount % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        this.name = name;
        this.rooms = new Pet[roomCount];
    }

    public bool Add(Pet pet)
    {
        int center = this.rooms.Length / 2;

        for (int i = 0; i < this.rooms.Length; i++)
        {
            int index = i % 2 == 0
                ? center - i / 2
                : center + (i + 1) / 2;

            if (index >= 0 && index < this.rooms.Length && this.rooms[index] == null)
            {
                this.rooms[index] = pet;
                return true;
            }
        }

        return false;
    }

    public bool Release()
    {
        int center = this.rooms.Length / 2;
        
        for (int i = center; i < this.rooms.Length; i++)
        {
            if (this.rooms[i] != null)
            {
                this.rooms[i] = null;
                return true;
            }
        }
        
        for (int i = 0; i < center; i++)
        {
            if (this.rooms[i] != null)
            {
                this.rooms[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        foreach (var room in this.rooms)
        {
            if (room == null) return true;
        }
        return false;
    }

    public void Print()
    {
        for (int i = 0; i < this.rooms.Length; i++)
        {
            if (this.rooms[i] == null)
                Console.WriteLine("Room empty");
            else
                Console.WriteLine(this.rooms[i]);
        }
    }

    public void Print(int roomNumber)
    {
        Pet room = this.rooms[roomNumber - 1];
        if (room == null)
            Console.WriteLine("Room empty");
        else
            Console.WriteLine(room);
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
            string[] parts = Console.ReadLine().Split(' ');
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
                                if (clinics[c] != null && clinics[c].GetType().Name == "Clinic" && clinics[c].ToString() != null && clinics[c].ToString() != "")
                                    if (clinics[c].GetType().GetField("name", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(clinics[c]).ToString() == clinicName)
                                        clinic = clinics[c];

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
                            {
                                var field = clinics[c].GetType().GetField("name", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                                if (field.GetValue(clinics[c]).ToString() == clinicName)
                                    clinic = clinics[c];
                            }

                            Console.WriteLine(clinic.Release());
                        }
                        break;

                    case "HasEmptyRooms":
                        {
                            string clinicName = parts[1];
                            Clinic clinic = null;

                            for (int c = 0; c < clinicCount; c++)
                            {
                                var field = clinics[c].GetType().GetField("name", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                                if (field.GetValue(clinics[c]).ToString() == clinicName)
                                    clinic = clinics[c];
                            }

                            Console.WriteLine(clinic.HasEmptyRooms());
                        }
                        break;

                    case "Print":
                        {
                            string clinicName = parts[1];
                            Clinic clinic = null;

                            for (int c = 0; c < clinicCount; c++)
                            {
                                var field = clinics[c].GetType().GetField("name", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                                if (field.GetValue(clinics[c]).ToString() == clinicName)
                                    clinic = clinics[c];
                            }

                            if (parts.Length == 2)
                            {
                                clinic.Print();
                            }
                            else
                            {
                                int room = int.Parse(parts[2]);
                                clinic.Print(room);
                            }
                        }
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
