using System;

interface ISoldier
{
    int Id { get; }
    string FirstName { get; }
    string LastName { get; }
}

interface IPrivate : ISoldier
{
    double Salary { get; }
}

interface ILeutenantGeneral : IPrivate
{
    IPrivate[] Privates { get; }
}

interface ISpecialisedSoldier : IPrivate
{
    string Corps { get; }
}

interface IEngineer : ISpecialisedSoldier
{
    Repair[] Repairs { get; }
}

interface ICommando : ISpecialisedSoldier
{
    Mission[] Missions { get; }
}

interface ISpy : ISoldier
{
    int CodeNumber { get; }
}

class Soldier : ISoldier
{
    public int Id { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }

    public Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return "Name: " + FirstName + " " + LastName + " Id: " + Id;
    }
}

class Private : Soldier, IPrivate
{
    public double Salary { get; protected set; }

    public Private(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + " Salary: " + Salary.ToString("F2");
    }
}

class LeutenantGeneral : Private, ILeutenantGeneral
{
    public IPrivate[] Privates { get; protected set; }

    public LeutenantGeneral(int id, string firstName, string lastName, double salary, IPrivate[] privates)
        : base(id, firstName, lastName, salary)
    {
        Privates = privates;
    }

    public override string ToString()
    {
        string result = base.ToString() + "\nPrivates:";
        for (int i = 0; i < Privates.Length; i++)
            result += "\n" + Privates[i].ToString();
        return result;
    }
}

class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public string Corps { get; protected set; }

    public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        if (corps != "Airforces" && corps != "Marines")
            return;
        Corps = corps;
    }

    public override string ToString()
    {
        return base.ToString() + "\nCorps: " + Corps;
    }
}

class Repair
{
    public string PartName { get; set; }
    public int HoursWorked { get; set; }

    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return "Part Name: " + PartName + " Hours Worked: " + HoursWorked;
    }
}

class Engineer : SpecialisedSoldier, IEngineer
{
    public Repair[] Repairs { get; protected set; }

    public Engineer(int id, string firstName, string lastName, double salary, string corps, Repair[] repairs)
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public override string ToString()
    {
        string result = base.ToString() + "\nRepairs:";
        for (int i = 0; i < Repairs.Length; i++)
            result += "\n" + Repairs[i].ToString();
        return result;
    }
}

class Mission
{
    public string CodeName { get; set; }
    public string State { get; set; }

    public Mission(string codeName, string state)
    {
        if (state != "inProgress" && state != "Finished")
            return;
        CodeName = codeName;
        State = state;
    }

    public void CompleteMission()
    {
        State = "Finished";
    }

    public override string ToString()
    {
        return "Code Name: " + CodeName + " State: " + State;
    }
}

class Commando : SpecialisedSoldier, ICommando
{
    public Mission[] Missions { get; protected set; }

    public Commando(int id, string firstName, string lastName, double salary, string corps, Mission[] missions)
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public override string ToString()
    {
        string result = base.ToString() + "\nMissions:";
        for (int i = 0; i < Missions.Length; i++)
            result += "\n" + Missions[i].ToString();
        return result;
    }
}

class Spy : Soldier, ISpy
{
    public int CodeNumber { get; protected set; }

    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return base.ToString() + "\nCode Number: " + CodeNumber;
    }
}

class Program
{
    static void Main()
    {
        string input;
        Private[] privates = new Private[100];
        int privCount = 0;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ');
            string type = parts[0];

            if (type == "Private")
            {
                int id = int.Parse(parts[1]);
                string fn = parts[2];
                string ln = parts[3];
                double salary = double.Parse(parts[4]);
                Private p = new Private(id, fn, ln, salary);
                privates[privCount++] = p;
                Console.WriteLine(p);
            }
            else if (type == "LeutenantGeneral")
            {
                int id = int.Parse(parts[1]);
                string fn = parts[2];
                string ln = parts[3];
                double salary = double.Parse(parts[4]);

                IPrivate[] subs = new IPrivate[parts.Length - 5];
                int index = 0;
                for (int i = 5; i < parts.Length; i++)
                {
                    int pid = int.Parse(parts[i]);
                    for (int j = 0; j < privCount; j++)
                    {
                        if (privates[j].Id == pid)
                            subs[index++] = privates[j];
                    }
                }

                IPrivate[] actual = new IPrivate[index];
                Array.Copy(subs, actual, index);

                LeutenantGeneral lg = new LeutenantGeneral(id, fn, ln, salary, actual);
                Console.WriteLine(lg);
            }
            else if (type == "Engineer")
            {
                int id = int.Parse(parts[1]);
                string fn = parts[2];
                string ln = parts[3];
                double salary = double.Parse(parts[4]);
                string corps = parts[5];

                int repCount = (parts.Length - 6) / 2;
                Repair[] reps = new Repair[repCount];
                for (int i = 0; i < repCount; i++)
                {
                    string part = parts[6 + i * 2];
                    int hours = int.Parse(parts[7 + i * 2]);
                    reps[i] = new Repair(part, hours);
                }

                Engineer e = new Engineer(id, fn, ln, salary, corps, reps);
                Console.WriteLine(e);
            }
            else if (type == "Commando")
            {
                int id = int.Parse(parts[1]);
                string fn = parts[2];
                string ln = parts[3];
                double salary = double.Parse(parts[4]);
                string corps = parts[5];

                int misCount = (parts.Length - 6) / 2;
                Mission[] mis = new Mission[misCount];
                int m = 0;

                for (int i = 0; i < misCount; i++)
                {
                    string code = parts[6 + i * 2];
                    string state = parts[7 + i * 2];
                    if (state == "inProgress" || state == "Finished")
                        mis[m++] = new Mission(code, state);
                }

                Mission[] actual = new Mission[m];
                Array.Copy(mis, actual, m);

                Commando c = new Commando(id, fn, ln, salary, corps, actual);
                Console.WriteLine(c);
            }
            else if (type == "Spy")
            {
                int id = int.Parse(parts[1]);
                string fn = parts[2];
                string ln = parts[3];
                int code = int.Parse(parts[4]);
                Spy s = new Spy(id, fn, ln, code);
                Console.WriteLine(s);
            }
        }
    }
}
