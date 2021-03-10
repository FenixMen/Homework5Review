using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    /// <summary>
    /// Репозиторий для работы над задачами
    /// </summary>
    public class TodoRepository
    {
        private List<TodoItem> todoList;
        private readonly FileProvider provider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Путь к файлу для хранения задач</param>
        public TodoRepository(string path)
        {
            provider = new FileProvider(path);
            todoList = provider.Load();
        }

        private void Save()
        {
            if (todoList != null)
                provider.Save(todoList);
        }

        /// <summary>
        /// Получить список задач
        /// </summary>
        /// <returns></returns>
        public TodoItem[] GetTasks()
        {
            if (todoList != null)
                return todoList.ToArray();
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Проверяет не 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => todoList == null || !todoList.Any();

        /// <summary>
        /// Добавляет задачу
        /// </summary>
        /// <param name="title">Название задачи</param>
        /// <returns>Экземпляр созданной задачи</returns>
        public TodoItem Add(string title)
        {
            if (todoList == null) todoList = new List<TodoItem>();
            var todo = new TodoItem(title);
            todoList.Add(todo);
            Save();
            return todo;
        }

        /// <summary>
        /// Обновляет статус задачи
        /// </summary>
        /// <param name="id">айдишник задачи</param>
        /// <returns></returns>
        public bool Update(int id)
        {
            if (!IsEmpty())
            {
                var todo = todoList.FirstOrDefault(o => o.Id == id);
                if (todo != null)
                {
                    todo.Done = !todo.Done;
                    Save();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Удаляет задачу
        /// </summary>
        /// <param name="id">айдишник задачи</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (!IsEmpty())
            {
                var todo = todoList.FirstOrDefault(o => o.Id == id);
                if (todo != null)
                {
                    todoList.Remove(todo);
                    Save();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Очищает список задач
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            if (!IsEmpty())
            {
                todoList.Clear();
                Save();
                return true;
            }
            return false;
        }
    }
}
