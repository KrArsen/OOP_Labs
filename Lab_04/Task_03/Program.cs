using System;

class Patient
{
    public string Name { get; set; }

    public Patient(string name)
    {
        Name = name;
    }
}
class Doctor
{
    public string Name { get; set; }
    public Patient[] Patients { get; set; } = new Patient[1000];
    public int Count { get; set; } = 0;

    public Doctor(string name)
    {
        Name = name;
    }

    public void AddPatient(string patientName)
    {
        Patients[Count++] = new Patient(patientName);
    }

    public void PrintPatients()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = i + 1; j < Count; j++)
            {
                if (string.Compare(Patients[i].Name, Patients[j].Name) > 0)
                {
                    Patient temp = Patients[i];
                    Patients[i] = Patients[j];
                    Patients[j] = temp;
                }
            }
        }

        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(Patients[i].Name);
        }
    }
}

class Room
{
    public Patient[] Beds { get; set; } = new Patient[3];
    public int Count { get; set; } = 0;

    public bool AddPatient(string name)
    {
        if (Count < 3)
        {
            Beds[Count++] = new Patient(name);
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void PrintPatientsAlphabetically()
    {
        for (int i = 0; i < Count - 1; i++)
        {
            for (int j = i + 1; j < Count; j++)
            {
                if (string.Compare(Beds[i].Name, Beds[j].Name) > 0)
                {
                    Patient temp = Beds[i];
                    Beds[i] = Beds[j];
                    Beds[j] = temp;
                }
            }
        }

        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(Beds[i].Name);
        }
    }
}

class Department
{
    public string Name { get; set; }
    public Room[] Rooms { get; set; } = new Room[20];

    public Department(string name)
    {
        Name = name;
        for (int i = 0; i < 20; i++)
        {
            Rooms[i] = new Room();
        }
    }

    public bool AddPatient(string patientName)
    {
        for (int i = 0; i < 20; i++)
        {
            if (Rooms[i].AddPatient(patientName))
            {
                return true;
            }
            
        }
        return false;
    }

    public void PrintAllPatients()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < Rooms[i].Count; j++)
            {
                Console.WriteLine(Rooms[i].Beds[j].Name);
            }
        }
    }

    public void PrintRoomPatients(int roomNumber)
    {
        if (roomNumber >= 1 && roomNumber <= 20)
        {
            Rooms[roomNumber -1].PrintPatientsAlphabetically();
        }
    }
}

class Hospital
{
    public Department[] Departments { get; set; } = new Department[100];
    public Doctor[] Doctors { get; set; } = new Doctor[100];
    public int DeptCount { get; set; } = 0;
    public int DocCount { get; set; } = 0;

    public Department GetOrAddDepartment(string name)
    {
        for (int i = 0; i < DeptCount; i++)
        {
            if (Departments[i].Name == name)
            {
                return Departments[i];
            }
        }
        Departments[DeptCount] = new Department(name);
        DeptCount++;
        return Departments[DeptCount - 1];
    }
    
    
    public Doctor GetOrAddDoctor(string name)
    {
        for (int i = 0; i < DocCount; i++)
        {
            if (Doctors[i].Name == name)
            {
                return Doctors[i];
            }
        }

        Doctors[DocCount] = new Doctor(name);
        DocCount++;
        return Doctors[DocCount - 1];
    }

    public void PrintDepartment(string name)
    {
        for (int i = 0; i < DeptCount; i++)
        {
            if (Departments[i].Name == name)
            {
                Departments[i].PrintAllPatients();
                return;
            }
        }
    }

    public void PrintDepartmentRoom(string name, int roomNumber)
    {
        for (int i = 0; i < DeptCount; i++)
        {
            if (Departments[i].Name == name)
            {
                Departments[i].PrintRoomPatients(roomNumber);
                return;
            }
        }
    }

    public void PrintDoctor(string name)
    {
        for (int i = 0; i < DocCount; i++)
        {
            if (Doctors[i].Name == name)
            {
                Doctors[i].PrintPatients();
                return;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital();
        string line;
        while ((line = Console.ReadLine()) != "Output")
        {
            string[] parts = line.Split();
            string departmentName = parts[0];
            string doctorName = parts[1] + " " + parts[2];
            string patientName = parts[3];
            
            Department dep = hospital.GetOrAddDepartment(departmentName);
            dep.AddPatient(patientName);

            Doctor doc = hospital.GetOrAddDoctor(doctorName);
            doc.AddPatient(patientName);
            
        }

        while ((line = Console.ReadLine()) != "End")
        {
            string[] parts = line.Split();
            if (parts.Length == 1)
            {
                string key = parts[0];
                hospital.PrintDepartment(key);
                hospital.PrintDoctor(key);
            } else if(parts.Length == 2)
            {
                string dep = parts[0];
                int room = int.Parse(parts[1]);
                hospital.PrintDepartmentRoom(dep, room);
            }
        }
    }
}