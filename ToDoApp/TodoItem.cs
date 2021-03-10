using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    /// <summary>
    /// Класс описывающий 
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// ИД задачи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Заголовок задачи
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Флаг выполнения задачи
        /// </summary>
        public bool Done { get; set; }
        /// <summary>
        /// Время создания задачи
        /// </summary>
        public DateTime TimeAdd { get; set; }

        public TodoItem()
        {

        }

        public TodoItem(string title, bool done = false)
        {
            // Присваиваем айдишник по метке времени
            Id = DateTime.UtcNow.Millisecond;
            Title = title;
            Done = done;
            TimeAdd = DateTime.Now;
        }
    }
}
