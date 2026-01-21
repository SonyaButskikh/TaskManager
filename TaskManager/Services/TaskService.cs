using System;
using System.Collections.Generic;
using System.Diagnostics;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(string title)
        {
            Trace.WriteLine("[TRACE] Начало операции AddTask");

            if (string.IsNullOrWhiteSpace(title))
            {
                Trace.TraceWarning("[WARN] Пользователь ввёл пустое название. Операция add не выполнена.");
                Trace.WriteLine("[TRACE] Конец операции AddTask (ошибка)");
                return;
            }

            tasks.Add(new TaskItem(title));
            Trace.TraceInformation($"[INFO] Задача \"{title}\" успешно добавлена.");
            Trace.TraceInformation($"[INFO] Текущее количество задач: {tasks.Count}");

            Trace.WriteLine("[TRACE] Конец операции AddTask");
        }

        public void RemoveTask(string title)
        {
            Trace.WriteLine("[TRACE] Начало операции RemoveTask");

            var task = tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (task == null)
            {
                Trace.TraceError($"[ERROR] Задача \"{title}\" не найдена. Удаление невозможно.");
                Trace.WriteLine("[TRACE] Конец операции RemoveTask (ошибка)");
                return;
            }

            tasks.Remove(task);
            Trace.TraceInformation($"[INFO] Задача \"{title}\" успешно удалена.");
            Trace.TraceInformation($"[INFO] Текущее количество задач: {tasks.Count}");

            Trace.WriteLine("[TRACE] Конец операции RemoveTask");
        }

        public void ListTasks()
        {
            Trace.WriteLine("[TRACE] Начало операции ListTasks");

            if (tasks.Count == 0)
            {
                Trace.TraceInformation("[INFO] Список задач пуст.");
                Console.WriteLine("Задач нет.");
                Trace.WriteLine("[TRACE] Конец операции ListTasks");
                return;
            }

            Console.WriteLine("Список задач:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].Title}");
            }

            Trace.TraceInformation($"[INFO] Выведено задач: {tasks.Count}");
            Trace.WriteLine("[TRACE] Конец операции ListTasks");
        }
    }
}
