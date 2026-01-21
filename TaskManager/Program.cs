using System;
using System.Diagnostics;
using TaskManager.Services;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка логирования в файл
            Trace.Listeners.Add(new TextWriterTraceListener("taskmanager.log"));
            Trace.AutoFlush = true;

            Trace.TraceInformation("[INFO] Приложение TaskManager запущено.");

            TaskService taskService = new TaskService();

            Console.WriteLine("TaskManager запущен.");
            Console.WriteLine("Доступные команды: add, remove, list, exit");

            while (true)
            {
                Console.Write("> ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "add":
                        Console.Write("Введите название задачи: ");
                        string addTitle = Console.ReadLine();
                        taskService.AddTask(addTitle);
                        break;

                    case "remove":
                        Console.Write("Введите название задачи для удаления: ");
                        string removeTitle = Console.ReadLine();
                        taskService.RemoveTask(removeTitle);
                        break;

                    case "list":
                        taskService.ListTasks();
                        break;

                    case "exit":
                        Trace.TraceInformation("[INFO] Приложение TaskManager завершает работу.");
                        return;

                    default:
                        Trace.TraceWarning("[WARN] Введена неизвестная команда.");
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }
    }
}
