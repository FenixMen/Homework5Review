using System;
using System.IO;
using System.Text;

namespace ToDoApp
{
    class Program
    {
        private static TodoRepository repository;
        static void Main(string[] args)
        {
            repository = new TodoRepository(Path.Combine(Environment.CurrentDirectory, "todo.json"));
            ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.ResetColor();
            Console.Clear();
            PrintTaskList();

            Console.WriteLine("\r\n\r\nМеню:");
            Console.WriteLine("1 - добавить задачу");
            Console.WriteLine("2 - обновить задачу");
            Console.WriteLine("3 - удалить задачу");
            Console.WriteLine("4 - очистить задачи");
            Console.WriteLine("5 - выход");

            var input = Console.ReadLine();
            if(int.TryParse(input, out var num))
            {
                switch (num)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        UpdateTask();
                        break;
                    case 3:
                        RemoveTask();
                        break;
                    case 4:
                        ClearTasks();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                ShowError("Ошибка выбора меню");
                Console.ReadLine();
                ShowMenu();
            }
        }

        public static void ShowNextAwait()
        {
            Console.ResetColor();
            Console.WriteLine("Нажмите enter для продолжения...");
            Console.ReadLine();
        }
        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public static void AddTask()
        {
            Console.ResetColor();
            Console.Clear();

            Console.Write("Введите имя задачи: ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                var todo = repository.Add(title);
                if(todo != null)
                {
                    ShowSuccess($"Задача добавлен (id задачи - {todo.Id})");
                }
                else
                {
                    ShowError("Не удалось добавить задачу");
                }
            }
            else
            {
                ShowError("Имя задачми не может быть пустым!");
            }
            ShowNextAwait();
            ShowMenu();
        }

        public static void UpdateTask()
        {
            Console.ResetColor();

            Console.Write("Введите id задачи, что бы изменить её: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var id))
            {
                if (repository.Update(id))
                    ShowSuccess("Задача обновлена");
                else
                    ShowError("Задача не была обновлена");
            }
            else
            {
                ShowError("Ошибка ввода id задачи");
            }
            ShowNextAwait();
            ShowMenu();
        }

        public static void RemoveTask()
        {
            Console.ResetColor();

            Console.Write("Введите id задачи, что бы удалить её: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var id))
            {
                if (repository.Delete(id))
                    ShowSuccess("Задача удалена");
                else
                    ShowError("Задача не была удалена");
            }
            else
            {
                ShowError("Ошибка ввода id задачи");
            }
            ShowNextAwait();
            ShowMenu();
        }

        public static void ClearTasks()
        {
            Console.ResetColor();

            Console.Write("Очистить список задач ? [Y/N]: ");
            var input = Console.ReadKey();
            
            if(input.Key == ConsoleKey.Y)
            {
                Console.WriteLine();

                if (repository.Clear())
                    ShowSuccess("Список очищен");
                else
                    ShowError("Не удалось очистить список задач");
                ShowNextAwait();
            }
            ShowMenu();

        }

        public static void PrintTaskList()
        {
            if (!repository.IsEmpty())
                foreach (var todo in repository.GetTasks())
                    PrintTask(todo);
            else
                Console.WriteLine("Список задач пуст!");
        }

        public static void PrintTask(TodoItem value)
        {
            Console.Write("[");
            Console.ForegroundColor = value.Done ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(value.Done ? "+" : "-");
            Console.ResetColor();
            Console.Write("]\t");
            Console.Write(value.Id);
            Console.WriteLine($"\t{value.Title}");
        }
    }
}
