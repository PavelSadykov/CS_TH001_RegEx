
using System;
using System.IO;

namespace ДЗ_001_Регулярные_выражения;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("task.txt");//считываем строки из файла и записываем в массив []

                using (StreamWriter writer = new StreamWriter("solution.txt", true))//создаем файл  «solution.txt» и  открываем поток для записи с использованием класса StreamWriter. 
                                                                                    //true" в  StreamWriter указывает, что данные в файл добавляются, если он существует.
                {
                foreach (string line in lines) //перебираем каждую строку в массиве lines
                    {
                        string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);//каждую строку разбиваем  на массив строк (parts), используя пробел в качестве разделителя
                                                                                                 //StringSplitOptions.RemoveEmptyEntries используем для удаления  пустых записей из результирующего массива.

                    if (parts.Length == 4 && double.TryParse(parts[0], out double leftOperand) && double.TryParse(parts[2], out double rightOperand))
                                                                                          // условие проверяет, можно ли парсить строку на 4 части и отдельно первую и третью части

                    {
                        switch (parts[1])// отрабатываем по 2 части строки где должен быть оператор
                            {
                                case "+":
                                    writer.WriteLine($"{line} {leftOperand + rightOperand}");//записываем в файл: строку line и результат операции
                                    break;
                                case "-":
                                    writer.WriteLine($"{line} {leftOperand - rightOperand}");
                                    break;
                                case "*":
                                    writer.WriteLine($"{line} {leftOperand * rightOperand}");
                                    break;
                                case "/":
                                    if (rightOperand == 0)
                                    {
                                        writer.WriteLine($"{line} ERROR: Деление на ноль");
                                    }
                                    else
                                    {
                                        writer.WriteLine($"{line} {leftOperand / rightOperand}");
                                    }
                                    break;
                                default:
                                    writer.WriteLine($"{line} ERROR: Недопустимый оператор");
                                    break;
                            }
                        }
                        else
                        {
                            writer.WriteLine($"{line} ERROR: Недопустимый формат");
                    }
                    }
                }

                Console.WriteLine("Задача выполнена! Нажмите клавишу ENTER.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }

