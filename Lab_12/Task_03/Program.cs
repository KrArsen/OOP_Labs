using System;
using System.Collections.Generic;


    public interface IEmployee
    {
        string Name { get; }
        int WorkHoursPerWeek { get; }
    }

    
    public class StandardEmployee : IEmployee
    {
        private string name;
        public StandardEmployee(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }
        public int WorkHoursPerWeek { get { return 40; } }
    }

    
    public class PartTimeEmployee : IEmployee
    {
        private string name;
        public PartTimeEmployee(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }
        public int WorkHoursPerWeek { get { return 20; } }
    }

    
    public class JobEventArgs : EventArgs
    {
        private Job job;

        public JobEventArgs(Job job)
        {
            this.job = job;
        }

        public Job Job { get { return job; } }
    }

    
    public class Job
    {
        private string name;
        private int hoursRequired;
        private IEmployee employee;

        
        public event EventHandler<JobEventArgs> JobDone;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.name = name;
            this.hoursRequired = hoursRequired;
            this.employee = employee;
        }

        public string Name { get { return name; } }
        public int HoursRemaining { get { return hoursRequired; } }

        
        public void Update()
        {
            hoursRequired -= employee.WorkHoursPerWeek;

            if (hoursRequired <= 0)
            {
                Console.WriteLine("Job " + name + " done!");
                OnJobDone();
            }
        }

        
        protected virtual void OnJobDone()
        {
            if (JobDone != null)
            {
                JobDone(this, new JobEventArgs(this));
            }
        }

        public override string ToString()
        {
            return "Job: " + name + " Hours Remaining: " + hoursRequired;
        }
    }

    
    public class JobList
    {
        private List<Job> jobs = new List<Job>();

        public void AddJob(Job job)
        {
            jobs.Add(job);
            job.JobDone += OnJobDone;
        }
        
        private void OnJobDone(object sender, JobEventArgs e)
        {
            jobs.Remove(e.Job);
        }

        public void PassWeek()
        {
            List<Job> copy = new List<Job>(jobs);
            for (int i = 0; i < copy.Count; i++)
            {
                copy[i].Update();
            }
        }

        public void Status()
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                Console.WriteLine(jobs[i]);
            }
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, IEmployee> employees = new Dictionary<string, IEmployee>();
            JobList jobs = new JobList();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] parts = input.Split(' ');

                if (parts[0] == "StandardEmployee")
                {
                    StandardEmployee emp = new StandardEmployee(parts[1]);
                    employees[parts[1]] = emp;
                }
                else if (parts[0] == "PartTimeEmployee")
                {
                    PartTimeEmployee emp = new PartTimeEmployee(parts[1]);
                    employees[parts[1]] = emp;
                }
                else if (parts[0] == "Job")
                {
                    string jobName = parts[1];
                    int hours = int.Parse(parts[2]);
                    string employeeName = parts[3];

                    IEmployee emp = employees[employeeName];
                    Job job = new Job(jobName, hours, emp);
                    jobs.AddJob(job);
                }
                else if (input == "Pass Week")
                {
                    jobs.PassWeek();
                }
                else if (input == "Status")
                {
                    jobs.Status();
                }

                input = Console.ReadLine();
            }
        }
    }
