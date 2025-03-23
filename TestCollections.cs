using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLibrary;

namespace LAB11
{
    public class TestCollections
    {
        public List<SmartWatch> ListTValue { get; set; }
        public List<string> ListString { get; set; }
        public SortedSet<Watch> SortedSetTKey { get; set; }
        public SortedSet<string> SortedSetString { get; set; }

        public TestCollections(int count)
        {
            ListTValue = new List<SmartWatch>();
            ListString = new List<string>();
            SortedSetTKey = new SortedSet<Watch>();
            SortedSetString = new SortedSet<string>();

            // Генерация элементов
            for (int i = 0; i < count; i++)
            {
                SmartWatch watch = new SmartWatch($"Бренд {i}", 2000 + i, "LCD", $"ОС{i}", i % 2 == 0);

                ListTValue.Add(watch);
                ListString.Add(watch.ToString());
                SortedSetTKey.Add(watch.BaseWatch);
                SortedSetString.Add(watch.BaseWatch.ToString());
            }
        }

        public void MeasureSearchTime()
        {
            // Элементы для поиска
            var firstElement = ListTValue[0];
            var middleElement = ListTValue[ListTValue.Count / 2];
            var lastElement = ListTValue[ListTValue.Count - 1];
            var nonExistingElement = new SmartWatch("Несуществующий", 2025,"LOOOOL", "ОС9999", false);

            // Измерение времени поиска
            MeasureTime("Первый элемент", firstElement);
            MeasureTime("Средний элемент", middleElement);
            MeasureTime("Последний элемент", lastElement);
            MeasureTime("Несуществующий элемент", nonExistingElement);

            MeasureTime("Первый элемент", firstElement);
            MeasureTime("Средний элемент", middleElement);
            MeasureTime("Последний элемент", lastElement);
            MeasureTime("Несуществующий элемент", nonExistingElement);
        }

        private void MeasureTime(string description, SmartWatch element)
        {
            Console.WriteLine($"Поиск: {description}");

            // Поиск в List<SmartWatch>
            MeasureTime(() => ListTValue.Contains(element), "List<SmartWatch>");

            // Поиск в List<string>
            MeasureTime(() => ListString.Contains(element.ToString()), "List<string>");

            // Поиск в SortedSet<Watch>
            MeasureTime(() => SortedSetTKey.Contains(element.BaseWatch), "SortedSet<Watch>");

            // Поиск в SortedSet<string>
            MeasureTime(() => SortedSetString.Contains(element.BaseWatch.ToString()), "SortedSet<string>");

            Console.WriteLine();
        }

        private void MeasureTime(Action action, string collectionName)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            action();
            watch.Stop();
            Console.WriteLine($"{collectionName}: {watch.ElapsedTicks} тиков");
        }
    }
}
