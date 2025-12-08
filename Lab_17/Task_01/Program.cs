using System;
using Microsoft.EntityFrameworkCore;
using Task_01.Data;
using Task_01.Data.Models;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new HospitalContext();

            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Hospital Database ===");
                Console.WriteLine("1. Додати пацієнта");
                Console.WriteLine("2. Додати візит");
                Console.WriteLine("3. Додати діагноз");
                Console.WriteLine("4. Додати медикамент");
                Console.WriteLine("5. Призначити медикамент пацієнту");
                Console.WriteLine("6. Показати всіх пацієнтів");
                Console.WriteLine("7. Додати лікаря");
                Console.WriteLine("8. Показати лікарів");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddPatient(db);
                        break;
                    case "2":
                        AddVisitation(db);
                        break;
                    case "3":
                        AddDiagnose(db);
                        break;
                    case "4":
                        AddMedicament(db);
                        break;
                    case "5":
                        AddPrescription(db);
                        break;
                    case "6":
                        ShowPatients(db);
                        break;
                    case "7":
                        AddDoctor(db);
                        break;
                    case "8":
                        ShowDoctors(db);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddPatient(HospitalContext db)
        {
            Console.Write("Ім'я: ");
            string first = Console.ReadLine();

            Console.Write("Прізвище: ");
            string last = Console.ReadLine();

            Console.Write("Адреса: ");
            string address = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Є страховка? (y/n): ");
            bool insurance = Console.ReadLine().ToLower() == "y";

            var patient = new Patient
            {
                FirstName = first,
                LastName = last,
                Address = address,
                Email = email,
                HasInsurance = insurance
            };

            db.Patients.Add(patient);
            db.SaveChanges();

            Console.WriteLine("Пацієнт доданий!");
            Console.ReadKey();
        }

        static void AddVisitation(HospitalContext db)
        {
            Console.Write("ID пацієнта: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("ID лікаря: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("Коментар: ");
            string comment = Console.ReadLine();

            var visit = new Visitation
            {
                PatientId = patientId,
                DoctorId = doctorId,
                Date = DateTime.Now,
                Comments = comment
            };

            db.Visitations.Add(visit);
            db.SaveChanges();

            Console.WriteLine("Візит додано!");
            Console.ReadKey();
        }


        static void AddDiagnose(HospitalContext db)
        {
            Console.Write("ID пацієнта: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Назва діагнозу: ");
            string name = Console.ReadLine();

            Console.Write("Коментар: ");
            string comment = Console.ReadLine();

            var diagnose = new Diagnose
            {
                PatientId = id,
                Name = name,
                Comments = comment
            };

            db.Diagnoses.Add(diagnose);
            db.SaveChanges();

            Console.WriteLine("Діагноз додано!");
            Console.ReadKey();
        }

        static void AddMedicament(HospitalContext db)
        {
            Console.Write("Назва медикаменту: ");
            string name = Console.ReadLine();

            var m = new Medicament { Name = name };

            db.Medicaments.Add(m);
            db.SaveChanges();

            Console.WriteLine("Медикамент додано!");
            Console.ReadKey();
        }

        static void AddPrescription(HospitalContext db)
        {
            Console.Write("ID пацієнта: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("ID медикаменту: ");
            int medicamentId = int.Parse(Console.ReadLine());

            var pm = new PatientMedicament
            {
                PatientId = patientId,
                MedicamentId = medicamentId
            };

            db.PatientsMedicaments.Add(pm);
            db.SaveChanges();

            Console.WriteLine("Медикамент призначено!");
            Console.ReadKey();
        }

        static void ShowPatients(HospitalContext db)
        {
            Console.Clear();

            foreach (var p in db.Patients)
            {
                Console.WriteLine($"{p.PatientId}. {p.FirstName} {p.LastName} | {p.Email}");
            }

            Console.ReadKey();
        }
        static void AddDoctor(HospitalContext db)
        {
            Console.Write("Ім'я лікаря: ");
            string name = Console.ReadLine();

            Console.Write("Спеціальність: ");
            string specialty = Console.ReadLine();

            var doctor = new Doctor
            {
                Name = name,
                Specialty = specialty
            };

            db.Doctors.Add(doctor);
            db.SaveChanges();

            Console.WriteLine("Лікаря додано!");
            Console.ReadKey();
        }

        static void ShowDoctors(HospitalContext db)
        {
            Console.Clear();
            foreach (var d in db.Doctors)
            {
                Console.WriteLine($"{d.DoctorId}. {d.Name} | {d.Specialty}");
            }
            Console.ReadKey();
        }
        

    }
}
