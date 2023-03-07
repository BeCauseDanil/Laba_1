using Newtonsoft.Json;
using System;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Laba1
{
    class Program
    {
        static void FirstSentence()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Завдання №1...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String('.', 20));

            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            Console.Write("Дано список: ");

            foreach(int i in list )
            {
                Console.Write($"{i}    ");
            }

            int count = list.Count;

            Label:

            Console.Write("\n\nВведіть число: ");
            int reverseNumber = int.Parse(Console.ReadLine());

            if (reverseNumber > list.Max() || reverseNumber < list.Min() )
            {
                Console.WriteLine("Число не може бути меньше за 1 або більше за 9\n");
                goto Label;
            }


            list.Reverse(reverseNumber, count - reverseNumber);
            list.Reverse(0, reverseNumber - 1);

            Console.Write("\nРезультат: ");
            foreach (var i in list)
            {
                Console.Write($"{i}    ");
            }
            Console.WriteLine("\n\n\n");
        }

        static void SecondSentence()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Завдання №2...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String('.', 15));
            Random random = new Random();

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < 10; i++)
            {
                dic.Add(i, random.Next(0, 10));
            }

            Console.WriteLine("\nДано словник: ");
            foreach (KeyValuePair<int, int> k in dic)
            {
                Console.WriteLine($"{k.Key}  {k.Value}");
            }

            Console.Write("\nВведіть значення: ");
            int controlValue = int.Parse(Console.ReadLine());

            Console.WriteLine();

            int a = 0;

            Dictionary<int, int> resultDic = new Dictionary<int, int>();

            Console.WriteLine("Результат:");
            foreach (KeyValuePair<int, int> i in dic)
            {
                if (i.Key >= controlValue)
                {
                    resultDic.Add(i.Key, i.Value);
                    Console.WriteLine($"{i.Key}  {i.Value}");
                }
            }


            // Запись в JSON-формат...

            string json = JsonConvert.SerializeObject(resultDic);

            Console.WriteLine($"\nJSON-Формат:  {json}");


            // Десериализация...


            //Dictionary<int, int> dic2 = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);

            //foreach (KeyValuePair<int, int> i in dic2)
            //{
            //    Console.WriteLine($"{i.Key}  {i.Value}");
            //}


            //Сохранение JSON в текстовый документ...


            //string file = "C:\\1.txt";

            //StreamWriter streamWriter = new StreamWriter(file);
            //streamWriter.WriteLine(json);
            //streamWriter.Close();

            //StreamReader streamReader = new StreamReader(file);

            //string jsonRead = streamReader.ReadToEnd();
            //streamReader.Close();

            //Console.WriteLine(jsonRead);

        }

        static void ThirdSentence()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\nЗавдання №3...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String('.', 15));

        Label2:

            Console.Write("Введіть кількість елементів послідовності: ");

            int subsequence = int.Parse(Console.ReadLine());

            if (subsequence < 0 )
            {
                Console.Write("Кількість елементів послідовності повинна бути більша за -1\n\n");
                goto Label2;
            }

            Console.Write("Введіть цифру: ");
            int d = int.Parse(Console.ReadLine());

            if (d > 9)
            {
                Console.WriteLine("Йди в п'ятий клас та дізнайся, чим відрізняються числа від цифр\n\n");
                goto Label2;
            }
            else if (d < 0)
            {
                Console.WriteLine("Цифра повинна бути більша за 0\n\n");
                goto Label2;
            }

            Random random = new Random();

            List<int> list = new List<int>();

            for (int i = 0; i < subsequence; i++)
            {
                list.Add(random.Next(-50, 51));
            }

            Console.Write("\nЗгенеровано наступну послідовність чисел: ");
            foreach (int i in list)
            {
                Console.Write($"{i}    ");
            }
            Console.WriteLine();


            IEnumerable<int> list2 = list.Where(x => x > 0 && (x % 10 == d)).Reverse().Distinct().Reverse();

            Console.Write("\nРезультат:  ");
            foreach (int i in list2)
            {
                Console.Write($"{i}    ");
            }
            Console.WriteLine("\n\n");
        }


        static void Main(string[] args )
        {
            //Дано список цілих чисел і число X.
            //Не використовуючи допоміжних об'єктів і не змінюючи розміру списку,
            //переставити елементи списку наступним чином:
            //Задати Х з клавіатури
            //Нехай x = 5
            //Було: 1 2 3 4 5 6 7 8 9
            //Стало: 4 3 2 1 5 9 8 7 6

            // Дано словник.
            // Вивести тільки ті позиції словника,
            // в яких ключ більший або дорівнює заданому значенню.
            // Повернути null, якщо такого ключа не існує.
            // Записати у JSON

            // Дана цифра D(ціле однозначне число)
            // і послідовність цілих чисел A.
            // Витягти з A всі різні додатні числа, що закінчуються цифрою D(в вихідному порядку).
            // При наявності повторюваних елементів видаляти всі їх входження, крім останніх.
            // Порада: Послідовно застосувати методи Reverse, Distinct, Reverse. (2)

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            while (true )
            {
                FirstSentence();

                SecondSentence();

                ThirdSentence();

                Console.WriteLine("Чи хочете ви продовжити виконання програми? \nТак: 1       Ні: 2\n\n");
                Console.Write("Введіть число: ");
                int continueOrNo = int.Parse(Console.ReadLine());

                if (continueOrNo == 1 )
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.WriteLine("\n\nЗавершення програми...\n");
                    return;
                }
            }


        }
    }
}