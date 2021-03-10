using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace ToDoApp
{
    /// <summary>
    /// Провайдер для сохранения задач в файл и их загрузки из файла
    /// </summary>
    public class FileProvider
    {
        private readonly string filePath;

        public FileProvider(string path)
        {
            this.filePath = path;
        }

        /// <summary>
        /// Сохранение списка в файл json
        /// </summary>
        /// <param name="value"></param>
        public void Save(List<TodoItem> value)
        {
            var json = JsonSerializer.Serialize(value);
            File.WriteAllText(filePath, json);
        }
        /// <summary>
        /// Загрузка списка из json файла
        /// </summary>
        /// <returns></returns>
        public List<TodoItem> Load()
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<TodoItem>>(json);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                return null;
            }
        }
    }
}
