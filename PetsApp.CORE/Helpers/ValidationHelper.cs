using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsApp.CORE.Helpers
{
    public static class ValidationHelper
    {
        public static string SetData(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException($"{nameof(value)} this field cannot be empty!");
            else
                return value;
        }

        public static DateTime BirthDateCheck(DateTime birthDate)
        {
            if (birthDate < DateTime.Now)
                return birthDate;
            else
                throw new Exception("Birthday Incorrect Please Enter a Date Before Today!!!");
        }
        public static DateTime AppointmentCheck(DateTime appointmentDate)
        {
            if (appointmentDate > DateTime.Now)
                return appointmentDate;
            else
                throw new Exception("The Appointment Date is Incorrect Please Enter a Date After Today!!!");
        }
        public static double SetWeight(double weight)
        {
            if (weight <= 0 || weight >= 50)
                throw new ArgumentOutOfRangeException($"{nameof(weight)} WARNING: WEIGHT PROBLEM DETECTED!!!");
            else
                return weight;
        }

        public static int DistanceOrTimeCheck(int distanceOrTime)
        {
            if (distanceOrTime <= 200 || distanceOrTime >= 1000)
                throw new ArgumentOutOfRangeException($"{nameof(distanceOrTime)} UYARI: HAREKETSİZLİK TESPİT EDİLDİ!!!");
            else
                return distanceOrTime;
        }

        public static double TemperatureCheck(double temperature)
        {
            if (temperature < 38 || temperature > 39)
                throw new ArgumentOutOfRangeException($"{nameof(temperature)} WARNING: INACTIVITY DETECTED!!!");
            else
                return temperature;
        }
    }
}
