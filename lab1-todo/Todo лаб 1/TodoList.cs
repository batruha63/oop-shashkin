using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TodoApp
{
    public class TodoList
    {
        private readonly List<TodoItem> _items;

        public IReadOnlyList<TodoItem> Items => _items;

        public TodoList()
        {
            _items = new List<TodoItem>();
        }

        public void AddItem(string title, DateTime? dueDate = null)
        {
            TodoItem newItem = new TodoItem(title, dueDate);
            _items.Add(newItem);
        }

        public bool RemoveItem(Guid id)
        {
            TodoItem itemToRemove = _items.Find(item => item.Id == id);
            if (itemToRemove != null)
            {
                return _items.Remove(itemToRemove);
            }
            return false;
        }

        public TodoItem FindItem(Guid id)
        {
            return _items.Find(item => item.Id == id);
        }

        public IEnumerable<TodoItem> GetFilteredAndSortedItems(string filter, string searchText = "")
        {
            IEnumerable<TodoItem> result = _items;

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                result = result.Where(item => item.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            if (filter == "Активные")
            {
                result = result.Where(item => !item.IsDone);
            }
            else if (filter == "Выполненные")
            {
                result = result.Where(item => item.IsDone);
            }

            return result.OrderBy(item => item.DueDate ?? DateTime.MaxValue);
        }

        private const string FileName = "tasks.json";

        public void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(_items, options);
                File.WriteAllText(FileName, jsonString);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(FileName)) return;

                string jsonString = File.ReadAllText(FileName);
                var deserializedItems = JsonSerializer.Deserialize<List<TodoItem>>(jsonString);

                if (deserializedItems != null)
                {
                    _items.Clear();
                    _items.AddRange(deserializedItems);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
    }
}
