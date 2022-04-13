using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lesson_5_GB
{
    static class Message
    {
        
        static string[] separators = { ",", ".", "!", "?", ";", ":", " ", "-" };

        public static void Word_Length(string message)
        {
            Console.WriteLine("а) Вывести только те слова сообщения, которые содержат не более 4 букв.\n");
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {

                if (words[i].Length <= 4)//а) Вывести только те слова сообщения, которые содержат не более n(в данном случае 4-х букв) букв.

                {
                    Console.Write(words[i] + " ");
                }
            }
        }//Вывести слова не более определнного количества букв
        
        public static void Deletion_of_Words(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.'У' \n");
            for (int i = 0; i < words.Length; i++)
            {
                if(words[i][words[i].Length - 1].ToString() != "у")//б) Удалить из сообщения все слова, которые заканчиваются на заданный("у") символ.

                {
                    Console.Write(words[i] + " ");
                }
                
            }
            Console.WriteLine();

        }//Удаление слов заканчивающихся на лпределенный символ
        
        public static string Max_Lenght(string message)
        {
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string maxLen = words[0];                                                           // объявляем переменную для поиска максимально длинного слова и инициализуем его к массиву слов
            int max = words[0].Length;                                                          // объявляем переменную для расчета длины каждого слова по буквам

            foreach (string word in words)                                                      // перебираем слова в word из words
            {
                if (word.Length > max)                                                          // условие поиска длинного слова
                {
                    max = word.Length;                                                          // отбираем слово с максимальным кол-м символов в слове
                    maxLen = word;                                                              // значит это слово самое длинное
                }
            }
            return maxLen;
        }// Самое длинное слово в строке
       
        
        /// <summary>
        /// Пунтк 'г'. Метод, формирующий строку с помощью StringBuilder из самых длинных слов сообщения.
        /// </summary>
        public static StringBuilder StringBuild(string message)
        {
            Console.WriteLine("г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.\n");
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);  // сортируем по знакам разделения

            StringBuilder result = new StringBuilder();                                         // вызываем класс StringBuilder
            int count = Max_Lenght(message).Length;                                            // объявляем переменную отвечающую за поиск всех слов с одной и той же максимальной длиной

            foreach (string word in words)
            {
                if (word.Length == count) result.Append(word + " ");
            }
            return result;
        }

    }
    internal class Program
    {


        public static string ChekRevers(string str_1, string str_2)
        {
            
            if(str_1.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(str_2.Select(Char.ToUpper).OrderBy(x => x)))
            {
                return $"Строка {str_1} является перестановкой строки {str_2}";
            };
            return $"Строка {str_1} НЕ является перестановкой строки {str_2}";
        }//Является ли строка перестановкой другой строки


        /// <summary>
        /// Проверка логина c помощью регулярных выражений
        /// 1. Логин должен быть больше 2 и меньше 11 символов
        /// 2. Первый символ НЕ должен быть числом
        /// 3. Логин содержит только латинские буквы или цифры
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Информация об ошибке или правильном вводе логина</returns>
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
            #region Tusk 1 Проверка логина а) без использования регулярных выражений;

            Console.WriteLine(@"
Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) **с использованием регулярных выражений.
");
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.WriteLine(CheckLogin(login));

            Console.ReadLine();
            #endregion

            #region Tusk 1 Проверка логина б) с использованием регулярных выражений;
            Console.WriteLine("Проверка через регулярные выражения");
            Console.Write("Введите логин: ");
            string regular_login = Console.ReadLine();

            Console.WriteLine(RegulChekLogin(regular_login));

            Console.ReadLine();
            #endregion

            #region Tusk 2 Обработка строки
            Console.WriteLine(@"
Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
");
            
            string message = "Вещи редко таковы, какими кажутся. Судя по моему личному опыту, они обычно гораздо хуже.";
            Console.WriteLine("Текст сообщения: " + message);
            Message.Word_Length(message);
            Console.ReadLine();
            Message.Deletion_of_Words(message);
            Console.ReadLine();
            Console.WriteLine("в) Найти самое длинное слово сообщения.\n");
            Console.WriteLine(Message.Max_Lenght(message));
            Console.ReadLine();
            Console.WriteLine(Message.StringBuild(message));
            Console.ReadLine();
            #endregion

            #region Tusk 3 Является лм строка перестановкой другой строки
            Console.WriteLine("Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.\n");
            Console.Write("Введите первое слово: ");
            string str_1 = Console.ReadLine();
            Console.Write("\nВведите второе слово: ");
            string str_2 = Console.ReadLine();
            Console.WriteLine(ChekRevers(str_1, str_2));
            Console.ReadLine();
            #endregion

        }
    }
}
