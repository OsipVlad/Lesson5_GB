using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lesson_5_GB
{
    internal class Program
    {

        public static string ChekAnnogram(string str_1, string str_2)
        {
            
            if(str_1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(str_2.Select(Char.ToUpper).OrderBy(x => x)))
            {
                return $"Строка {str_1} является перестановкой строки {str_2}";
            };
            return $"Строка {str_1} НЕ является перестановкой строки {str_2}";
        }
        public static string RegulChekLogin(string login)
        {
            Regex login_regex = new Regex("^[a-zA-Zа][a-zA-Zа0-9]{2,9}$");
            string source = login;
 
            if (login_regex.Match(source).Success) 
            {
                return "Login is correct";// если совпадение удачно
            }
            else
            {
                return "Login is incorrect";// если совпадение НЕ удачно
            }
        }

/// <summary>
/// Проверка логина.
/// 1. Логин должен быть больше 2 и меньше 11 символов
/// 2. Первый символ НЕ должен быть числом
/// 3. Логин содержит только латинские буквы или цифры
/// </summary>
/// <param name="login"></param>
/// <returns>Информация об ошибке или правильном вводе логина</returns>
public static string CheckLogin(string login)
        {
            if (2 > login.Length || login.Length > 11)
                return "Логин неверной длинны!";

            if (char.GetUnicodeCategory(login[0]) == UnicodeCategory.DecimalDigitNumber)
                return "Логин не должен начинаться на цифру";
            bool latin = false;
            foreach (char ch in login)
            {
                if (((int)ch >= 97 && (int)ch <= 122) == latin) return "Логин должен содержать только Латиницу.";
            }

            return "Вы ввели правильный логин!";
        }


        static void Main(string[] args)
        {
            //Console.Write("Введите логин: ");
            //string login = Console.ReadLine();

            //Console.WriteLine(CheckLogin(login));

            //Console.ReadLine();

            Console.WriteLine("Проверка через регулярные выражения");
            Console.Write("Введите логин: ");
            string regular_login = Console.ReadLine();

            Console.WriteLine(RegulChekLogin(regular_login));

            Console.ReadLine();

            //Console.Write("Введите первое слово: ");
            //string str_1 = Console.ReadLine();
            //Console.Write("Введите второе слово: ");
            //string str_2 = Console.ReadLine();
            //Console.WriteLine(ChekAnnogram(str_1, str_2));

            //Console.ReadLine();

        }
    }
}
