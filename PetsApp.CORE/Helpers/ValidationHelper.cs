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
                throw new ArgumentNullException($"{nameof(value)} boş geçilemez!");
            else
                return value;
        }

        public static DateTime BirthDateCheck(DateTime birthDate)
        {
            if (birthDate < DateTime.Now)
                return birthDate;
            else
                throw new Exception("Doğum Günü Hatalı Lütfen Bugünden Önce Bir Tarih Giriniz!!!");
        }
        public static double SetWeight(double weight)
        {
            if (weight <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(weight)} 0'dan küçük olamaz!");
            else
                return weight;
        }

        public static int DistanceOrTimeCheck(int distanceOrTime)
        {
            if (distanceOrTime <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(distanceOrTime)} 0'dan küçük olamaz!");
            else
                return distanceOrTime;
        }
    }
}
