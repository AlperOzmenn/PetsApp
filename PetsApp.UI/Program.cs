using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using PetsApp.CORE.Enums;
using PetsApp.CORE.Models;
using PetsApp.REPO.Contexts;
using PetsApp.REPO.UnitOfWorks;
using PetsApp.SERVICE.Concretes;
using PetsApp.SERVICE.Contracts;

namespace PetsApp.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PetsAppDbContext context = new PetsAppDbContext();
            IManagerRepo manager = new ManagerRepo(context);
            IPetOwnerService petOwnerService = new PetOwnerService(manager);
            IPetService petService = new PetService(manager);
            IHealthRecordService healthRecordService = new HealthRecordService(manager);
            ITrackerDeviceService trackerDeviceService = new TrackerDeviceService(manager);
            IActivityLogService activityLogService = new ActivityLogService(manager);
            IVetAppointmentService vetAppointmentService = new VetAppointmentService(manager);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MainUI(petOwnerService, petService, healthRecordService, trackerDeviceService, activityLogService, vetAppointmentService);
        }

        private static void MainUI(IPetOwnerService petOwnerService, IPetService petService, IHealthRecordService healthRecordService, ITrackerDeviceService trackerDeviceService, IActivityLogService activityLogService, IVetAppointmentService vetAppointmentService)
        {
            bool exit = true;
            string result;

            Console.WriteLine("\t\tWELCOME TO PETSAPP 🐮\n");

            while (exit)
            {
                Console.WriteLine("1-Pet Owner 🐱\n2-Pet 🐶\n3-Tracker Device 🐰\n4-Activity Log 🐼\n5-Health Record 🦁\n6-Vet Appointment 🐦\n7-Exit 🐟\nSelect the item you want to process.[1-7]");
                result = Console.ReadLine();

                switch (result)
                {

                    case "1":
                        PetOwnerUI(petOwnerService);
                        break;
                    case "2":
                        PetUI(petService);
                        break;
                    case "3":
                        TrackerDeviceUI(trackerDeviceService);
                        break;
                    case "4":
                        ActivityLogUI(activityLogService);
                        break;
                    case "5":
                        HealthRecord(healthRecordService);
                        break;
                    case "6":
                        VetAppointment(vetAppointmentService);
                        break;
                    case "7":
                        Console.WriteLine("Exit is in progress...");
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("You logged in incorrectly, try again!!!");
                        break;
                }
            }
        }


        static void PetOwnerUI(IPetOwnerService petOwnerService)
        {
            
            string firstName, lastName, result;
            int id;
            PetOwner petOwner;

            MethodInfo[] methodInfo = typeof(IPetOwnerService).GetMethods();
            for (int i = 0; i < methodInfo.Length; i++)
            {
                Console.WriteLine((i + 1) + "-" + methodInfo[i].Name);
            }
            Console.WriteLine("9-Back");
            Console.WriteLine("🐱 Please select the action you want to take.[1-9]");
            result = Console.ReadLine();


            switch (result)
            {
                case "1":
                    Console.WriteLine("🐱 Enter the name of the pet owner you want to add.");
                    firstName = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the surname of the pet owner you want to add.");
                    lastName = Console.ReadLine();
                    petOwnerService.Add(firstName, lastName);
                    break;
                case "2":
                    Console.Write("🐱 Pet Owner Id: ");
                    id = int.Parse(Console.ReadLine());
                    petOwner = petOwnerService.Get(id);
                    Console.WriteLine("🐱 Enter the name of the pet owner you want to update.");
                    firstName = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the surname of the pet owner you want to update.");
                    lastName = Console.ReadLine();
                    petOwnerService.Update(id, firstName, lastName);
                    break;
                case "3":
                    Console.Write("🐱 Pet Owner Id: ");
                    id = int.Parse(Console.ReadLine());
                    petOwner = petOwnerService.Get(id);
                    petOwnerService.Delete(id);
                    break;
                case "4":
                    Console.Write("🐱 Pet Owner Id: ");
                    id = int.Parse(Console.ReadLine());
                    petOwner = petOwnerService.Get(id);
                    petOwnerService.SoftDelete(id);
                    break;
                case "5":
                    Console.Write("🐱 Pet Owner Id: ");
                    id = int.Parse(Console.ReadLine());
                    petOwner = petOwnerService.Get(id);
                    Console.WriteLine(petOwner);
                    break;
                case "6":
                    var petOwners = petOwnerService.GetAllTrack();
                    foreach (var item in petOwners)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "7":
                    var petOwners1 = petOwnerService.GetAllNoTrack();
                    foreach (var item in petOwners1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "8":
                    Console.Write("🐱 Pet Owner Name: ");
                    var petOwners2 = petOwnerService.GetByName(Console.ReadLine());
                    foreach (var item in petOwners2)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "9":
                    break;
                default:
                    Console.WriteLine("🐱 Warning: You logged in incorrectly!!!");
                    break;
            }



        }

        static void PetUI(IPetService petService)
        {
            string name, type, breed, result;
            int id;
            DateTime birthDate;
            Pet pet;

            MethodInfo[] methodInfo1 = typeof(IPetService).GetMethods();
            for (int i = 0; i < methodInfo1.Length; i++)
            {
                Console.WriteLine((i + 1) + "-" + methodInfo1[i].Name);
            }
            Console.WriteLine("9-Back");
            Console.WriteLine("🐱 Please select the action you want to take.[1-9]");
            result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("🐱 Enter the name of the pet you want to add.");
                    name = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the type of the pet you want to add.");
                    type = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the breed of the pet you want to add.");
                    breed = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the birth date of the pet you want to add.");
                    birthDate = Convert.ToDateTime(Console.ReadLine());
                    petService.Add(name, type, breed, birthDate);
                    break;
                case "2":
                    Console.Write("🐱 Pet Id: ");
                    id = int.Parse(Console.ReadLine());
                    pet = petService.Get(id);
                    Console.WriteLine("🐱 Enter the name of the pet you want to update.");
                    name = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the type of the pet you want to update.");
                    type = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the breed of the pet you want to update.");
                    breed = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the birth date of the pet you want to update.");
                    birthDate = Convert.ToDateTime(Console.ReadLine());
                    petService.Update(id, name, type, breed, birthDate);
                    break;
                case "3":
                    Console.Write("🐱 Pet Id: ");
                    id = int.Parse(Console.ReadLine());
                    pet = petService.Get(id);
                    petService.Delete(id);
                    break;
                case "4":
                    Console.Write("🐱 Pet Id: ");
                    id = int.Parse(Console.ReadLine());
                    pet = petService.Get(id);
                    petService.SoftDelete(id);
                    break;
                case "5":
                    Console.Write("🐱 Pet Id: ");
                    id = int.Parse(Console.ReadLine());
                    pet = petService.Get(id);
                    Console.WriteLine(pet);
                    break;
                case "6":
                    var pets = petService.GetAllTrack();
                    foreach (var item in pets)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "7":
                    var pets1 = petService.GetAllNoTrack();
                    foreach (var item in pets1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "8":
                    Console.Write("🐱 Pet Name: ");
                    var pets2 = petService.GetByName(Console.ReadLine());
                    foreach (var item in pets2)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "9":
                    break;
                default:
                    Console.WriteLine("🐱 Warning: You logged in incorrectly!!!");
                    break;
            }
        }

        static void TrackerDeviceUI(ITrackerDeviceService trackerDeviceService)
        {
            string result;
            int id;

            MethodInfo[] methodInfo2 = typeof(ITrackerDeviceService).GetMethods();
            for (int i = 0; i < methodInfo2.Length; i++)
            {
                Console.WriteLine((i + 1) + "-" + methodInfo2[i].Name);
            }
            Console.WriteLine("8-Back");
            Console.WriteLine("🐱 Please select the action you want to take.[1-8]");
            result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("🐱 Enter the Petid of the tracker device you want to add.");
                    int petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the GpsLocation of the tracker device you want to add.");
                    GpsLocation gpsLocation = (GpsLocation)Enum.Parse(typeof(GpsLocation), Console.ReadLine(), ignoreCase: true);
                    trackerDeviceService.Add(petId, gpsLocation);
                    break;
                case "2":
                    Console.Write("🐱 Tracker Device Id: ");
                    id = int.Parse(Console.ReadLine());
                    var trackerDevice = trackerDeviceService.Get(id);
                    Console.WriteLine("🐱 Enter the Petid of the tracker device you want to update.");
                    petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the GpsLocation of the tracker device you want to update.");
                    gpsLocation = (GpsLocation)Enum.Parse(typeof(GpsLocation), Console.ReadLine(), ignoreCase: true);
                    trackerDeviceService.Update(id, petId, gpsLocation);
                    break;
                case "3":
                    Console.Write("🐱 Tracker Device Id: ");
                    id = int.Parse(Console.ReadLine());
                    trackerDevice = trackerDeviceService.Get(id);
                    trackerDeviceService.Delete(id);
                    break;
                case "4":
                    Console.Write("🐱 Tracker Device Id: ");
                    id = int.Parse(Console.ReadLine());
                    trackerDevice = trackerDeviceService.Get(id);
                    trackerDeviceService.SoftDelete(id);
                    break;
                case "5":
                    Console.Write("🐱 Tracker Device Id: ");
                    id = int.Parse(Console.ReadLine());
                    trackerDevice = trackerDeviceService.Get(id);
                    Console.WriteLine(trackerDevice);
                    break;
                case "6":
                    var trackerDevices = trackerDeviceService.GetAllTrack();
                    foreach (var item in trackerDevices)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "7":
                    var trackerDevices1 = trackerDeviceService.GetAllNoTrack();
                    foreach (var item in trackerDevices1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "8":
                    break;
                default:
                    Console.WriteLine("🐱 Warning: You logged in incorrectly!!!");
                    break;
            }
        }

        static void ActivityLogUI(IActivityLogService activityLogService)
        {
            string result;
            int id;

            MethodInfo[] methodInfo3 = typeof(IActivityLogService).GetMethods();
            for (int i = 0; i < methodInfo3.Length; i++)
            {
                Console.WriteLine((i + 1) + "-" + methodInfo3[i].Name);
            }
            Console.WriteLine("8-Back");
            Console.WriteLine("🐱 Please select the action you want to take.[1-8]");
            result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("🐱 Enter the tempature of the activity log you want to add.");
                    double tempature = double.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the trackerDeviceId of the activity log you want to add.");
                    int trackerDeviceId = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the distanceTraveledInMeters of the activity log you want to add.");
                    int distanceTraveledInMeters = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the minutesOfWalking of the activity log you want to add.");
                    int minutesOfWalking = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the minutesOfSleeping of the activity log you want to add.");
                    int minutesOfSleeping = int.Parse(Console.ReadLine());
                    activityLogService.Add(tempature, trackerDeviceId, distanceTraveledInMeters, minutesOfWalking, minutesOfSleeping);
                    break;
                case "2":
                    Console.Write("🐱 Activity Log Id: ");
                    id = int.Parse(Console.ReadLine());
                    var activityLog = activityLogService.Get(id);
                    Console.WriteLine("🐱 Enter the tempature of the activity log you want to add.");
                    tempature = double.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the trackerDeviceId of the activity log you want to add.");
                    trackerDeviceId = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the distanceTraveledInMeters of the activity log you want to add.");
                    distanceTraveledInMeters = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the minutesOfWalking of the activity log you want to add.");
                    minutesOfWalking = int.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the minutesOfSleeping of the activity log you want to add.");
                    minutesOfSleeping = int.Parse(Console.ReadLine());
                    activityLogService.Update(id, tempature, trackerDeviceId, distanceTraveledInMeters, minutesOfWalking, minutesOfSleeping);
                    break;
                case "3":
                    Console.Write("🐱 Activity Log Id: ");
                    id = int.Parse(Console.ReadLine());
                    activityLog = activityLogService.Get(id);
                    activityLogService.Delete(id);
                    break;
                case "4":
                    Console.Write("🐱 Activity Log Id: ");
                    id = int.Parse(Console.ReadLine());
                    activityLog = activityLogService.Get(id);
                    activityLogService.SoftDelete(id);
                    break;
                case "5":
                    Console.Write("🐱 Activity Log Id: ");
                    id = int.Parse(Console.ReadLine());
                    activityLog = activityLogService.Get(id);
                    Console.WriteLine(activityLog);
                    break;
                case "6":
                    var activityLogs = activityLogService.GetAllTrack();
                    foreach (var item in activityLogs)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "7":
                    var activityLogs1 = activityLogService.GetAllNoTrack();
                    foreach (var item in activityLogs1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "8":
                    break;
                default:
                    Console.WriteLine("🐱 Warning: You logged in incorrectly!!!");
                    break;
            }
        }

        static void HealthRecord(IHealthRecordService healthRecordService)
        {
            string result;
            int id;

            MethodInfo[] methodInfo4 = typeof(IHealthRecordService).GetMethods();
            for (int i = 0; i < methodInfo4.Length; i++)
            {
                Console.WriteLine((i + 1) + "-" + methodInfo4[i].Name);
            }
            Console.WriteLine("8-Back");
            Console.WriteLine("🐱 Please select the action you want to take.[1-8]");
            result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("🐱 Enter the weight of the health record you want to add.");
                    double weight = double.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the gender of the health record you want to add.");
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), ignoreCase: true);
                    Console.WriteLine("🐱 Enter the vaccinationInfo of the health record you want to add.");
                    VaccinationInfo vaccinationInfo = (VaccinationInfo)Enum.Parse(typeof(VaccinationInfo), Console.ReadLine(), ignoreCase: true);
                    Console.WriteLine("🐱 Enter the allergies of the health record you want to add.");
                    List<Allergie> allergies = new List<Allergie>();
                    string allergieString = Console.ReadLine();
                    string[] allergieArray = allergieString.Split(',');
                    foreach (string item in allergieArray)
                    {
                        Allergie allergie = (Allergie)Enum.Parse(typeof(Allergie), item, ignoreCase: true);
                        allergies.Add(allergie);
                    }
                    healthRecordService.Add(weight, gender, vaccinationInfo, allergies);
                    break;
                case "2":
                    Console.Write("🐱 Health Record Id: ");
                    id = int.Parse(Console.ReadLine());
                    var healthRecord = healthRecordService.Get(id);
                    Console.WriteLine("🐱 Enter the weight of the health record you want to update.");
                    weight = double.Parse(Console.ReadLine());
                    Console.WriteLine("🐱 Enter the gender of the health record you want to update.");
                    gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), ignoreCase: true);
                    Console.WriteLine("🐱 Enter the vaccinationInfo of the health record you want to update.");
                    vaccinationInfo = (VaccinationInfo)Enum.Parse(typeof(VaccinationInfo), Console.ReadLine(), ignoreCase: true);
                    Console.WriteLine("🐱 Enter the allergies of the health record you want to update.");
                    allergies = new List<Allergie>();
                    allergieString = Console.ReadLine();
                    allergieArray = allergieString.Split(',');
                    foreach (string item in allergieArray)
                    {
                        Allergie allergie = (Allergie)Enum.Parse(typeof(Allergie), item, ignoreCase: true);
                        allergies.Add(allergie);
                    }
                    healthRecordService.Add(weight, gender, vaccinationInfo, allergies);
                    break;
                case "3":
                    Console.Write("🐱 Health Record Id: ");
                    id = int.Parse(Console.ReadLine());
                    healthRecord = healthRecordService.Get(id);
                    healthRecordService.SoftDelete(id);
                    break;
                case "4":
                    Console.Write("🐱 Health Record Id: ");
                    id = int.Parse(Console.ReadLine());
                    healthRecord = healthRecordService.Get(id);
                    healthRecordService.Delete(id);
                    break;
                case "5":
                    Console.Write("🐱 Health Record Id: ");
                    id = int.Parse(Console.ReadLine());
                    healthRecord = healthRecordService.Get(id);
                    Console.WriteLine(healthRecord);
                    break;
                case "6":
                    var healthRecords = healthRecordService.GetAllTrack();
                    foreach (var item in healthRecords)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "7":
                    var healthRecords1 = healthRecordService.GetAllNoTrack();
                    foreach (var item in healthRecords1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "8":
                    break;
                default:
                    Console.WriteLine("🐱 Warning: You logged in incorrectly!!!");
                    break;
            }
        }

        static void VetAppointment(IVetAppointmentService vetAppointmentService)
        {
            string result;
            int id;

            MethodInfo[] methodInfo5 = typeof(IVetAppointmentService).GetMethods();
            for (int i = 0; i < methodInfo5.Length; i++)
            {
                Console.WriteLine((i + 1) + "-" + methodInfo5[i].Name);
            }
            Console.WriteLine("8-Back");
            Console.WriteLine("🐱 Please select the action you want to take.[1-8]");
            result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("🐱 Enter the vetName of the VetAppointment you want to add.");
                    string vetName = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the description of the VetAppointment you want to add.");
                    string description = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the vetAppointmentDate of the VetAppointment you want to add.");
                    DateTime vetAppointmentDate = DateTime.Parse(Console.ReadLine());

                    vetAppointmentService.Add(vetName, description, vetAppointmentDate);
                    break;
                case "2":
                    Console.Write("🐱 VetAppointment Id: ");
                    id = int.Parse(Console.ReadLine());
                    var vetAppointment = vetAppointmentService.Get(id);
                    Console.WriteLine("🐱 Enter the vetName of the VetAppointment you want to update.");
                    vetName = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the description of the VetAppointment you want to update.");
                    description = Console.ReadLine();
                    Console.WriteLine("🐱 Enter the vetAppointmentDate of the VetAppointment you want to update.");
                    vetAppointmentDate = DateTime.Parse(Console.ReadLine());

                    vetAppointmentService.Update(id, vetName, description, vetAppointmentDate);
                    break;
                case "3":
                    Console.Write("🐱 VetAppointment Id: ");
                    id = int.Parse(Console.ReadLine());
                    vetAppointment = vetAppointmentService.Get(id);
                    vetAppointmentService.SoftDelete(id);
                    break;
                case "4":
                    Console.Write("🐱 VetAppointment Id: ");
                    id = int.Parse(Console.ReadLine());
                    vetAppointment = vetAppointmentService.Get(id);
                    vetAppointmentService.Delete(id);
                    break;
                case "5":
                    Console.Write("🐱 VetAppointment Id: ");
                    id = int.Parse(Console.ReadLine());
                    vetAppointment = vetAppointmentService.Get(id);
                    Console.WriteLine(vetAppointment);
                    break;
                case "6":
                    var vetAppointments = vetAppointmentService.GetAllTrack();
                    foreach (var item in vetAppointments)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "7":
                    var vetAppointments1 = vetAppointmentService.GetAllNoTrack();
                    foreach (var item in vetAppointments1)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "8":
                    break;
                default:
                    Console.WriteLine("🐱 Warning: You logged in incorrectly!!!");
                    break;
            }
        }

    }
}
