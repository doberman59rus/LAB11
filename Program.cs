using LAB11;
using System;
using System.Collections;
using WatchLibrary;

class Program
{
    // Счётчик элементов определенного типа
    static int CountByType(SortedList sortedList, Type type)
    {
        int count = 0;
        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Value.GetType() == type)
            {
                count++;
            }
        }
        return count;
    }
    
    // Печать элементов одного типа
    static void PrintByType(SortedList sortedList, Type type)
    {
        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Value.GetType() == type)
            {
                Console.WriteLine($"--- {entry.Value}");
            }
        }
    }

    // Поиск новейших часов
    static Watch FindNewest(SortedList sortedList)
    {
        Watch newest = null;
        foreach (DictionaryEntry entry in sortedList)
        {
            if (entry.Value is Watch watch)
            {
                if (newest == null || watch.YearOfManufacture > newest.YearOfManufacture)
                {
                    newest = watch;
                }
            }
        }
        return newest;
    }

    // Та же функция, но для обобщенной коллекции
    static int CountByType(HashSet<Watch> hashSet, Type type)
    {
        int count = 0;
        foreach (var item in hashSet)
        {
            if (item.GetType() == type)
            {
                count++;
            }
        }
        return count;
    }

    // Та же функция, но для обобщенной коллекции
    static void PrintByType(HashSet<Watch> hashSet, Type type)
    {
        foreach (var item in hashSet)
        {
            if (item.GetType() == type)
            {
                Console.WriteLine($"--- {item}");
            }
        }
    }

    // Та же функция, но для обобщенной коллекции
    static Watch FindNewest(HashSet<Watch> hashSet)
    {
        Watch newest = null;
        foreach (var item in hashSet)
        {
            if (newest == null || item.YearOfManufacture > newest.YearOfManufacture)
                newest = item;
        }
        return newest;
    }

    static void Main(string[] args)
    {
        //ЗАДАНИЕ 1
        Console.WriteLine("ЗАДАНИЕ 1\n");
        // Создание SortedList
        SortedList sortedList = new SortedList();

        // Добавление объектов в SortedList
        sortedList.Add("Rolex", new Watch("Rolex", 2020));
        sortedList.Add("Casio", new ElectronicWatch("Casio", 2019, "LCD"));
        sortedList.Add("Seiko", new AnalogWatch("Seiko", 2018, "Классический"));
        sortedList.Add("Apple", new SmartWatch("Apple", 2021, "OLED", "WatchOS", true));
        sortedList.Add("Samsung", new SmartWatch("Samsung", 2022, "AMOLED", "Tizen", false));

        // Добавление нового объекта
        sortedList.Add("Omega", new Watch("Omega", 2020));

        // Удаление объекта по ключу
        sortedList.Remove("Seiko");

        // Вывод всех элементов
        Console.WriteLine("Все элементы SortedList:");
        foreach (DictionaryEntry entry in sortedList)
        {
            Console.WriteLine($"--- Ключ: {entry.Key}, Значение: {entry.Value}");
        }

        // Запрос 1: Количество объектов определенного типа
        int smartWatchCount = CountByType(sortedList, typeof(SmartWatch));
        Console.WriteLine($"Количество умных часов: {smartWatchCount}");

        // Запрос 2: Печать объектов определенного типа
        Console.WriteLine("Электронные часы:");
        PrintByType(sortedList, typeof(ElectronicWatch));

        // Запрос 3: Поиск объекта с максимальным годом выпуска
        var newestWatch = FindNewest(sortedList);
        Console.WriteLine($"Самые новые часы: {newestWatch}");

        // Клонирование коллекции
        SortedList clonedSortedList = (SortedList)sortedList.Clone();
        Console.WriteLine("Клонированная SortedList:");
        foreach (DictionaryEntry entry in clonedSortedList)
        {
            Console.WriteLine($"--- Ключ: {entry.Key}, Значение: {entry.Value}");
        }
        
        // Поиск элемента по ключу
        if (sortedList.ContainsKey("Apple"))
        {
            Console.WriteLine("Элемент с ключом 'Apple' найден.");
        }
        else
        {
            Console.WriteLine("Элемент с ключом 'Apple' не найден.");
        }

        //ЗАДАНИЕ 2
        Console.WriteLine("\nЗАДАНИЕ 2\n");
        
        // Создание HashSet
        HashSet<Watch> hashSet = new HashSet<Watch>();

        // Добавление объектов в HashSet
        hashSet.Add(new Watch("Rolex", 2020));
        hashSet.Add(new ElectronicWatch("Casio", 2019, "LCD"));
        hashSet.Add(new AnalogWatch("Seiko", 2018, "Классический"));
        hashSet.Add(new SmartWatch("Apple", 2021, "OLED", "WatchOS", true));
        hashSet.Add(new SmartWatch("Samsung", 2022, "AMOLED", "Tizen", false));

        // Добавление нового объекта
        hashSet.Add(new Watch("Omega", 2020));

        // Удаление объекта
        var itemToRemove = new Watch("Rolex", 2020);
        hashSet.Remove(itemToRemove);

        // Вывод всех элементов
        Console.WriteLine("Все элементы HashSet:");
        foreach (var item in hashSet)
        {
            Console.WriteLine($"--- {item}");
        }

        // Запрос 1: Количество объектов определенного типа
        int smartWatchCountForHashSet = CountByType(hashSet, typeof(SmartWatch));
        Console.WriteLine($"Количество умных часов: {smartWatchCountForHashSet}");

        // Запрос 2: Печать объектов определенного типа
        Console.WriteLine("Электронные часы:");
        PrintByType(hashSet, typeof(ElectronicWatch));

        // Запрос 3: Поиск объекта с максимальным годом выпуска
        var newestWatchForHashSet = FindNewest(hashSet);
        Console.WriteLine($"Самые новые часы: {newestWatchForHashSet}");

        // Клонирование коллекции
        HashSet<Watch> clonedHashSet = new HashSet<Watch>(hashSet);
        Console.WriteLine("Клонированная HashSet:");
        foreach (var item in clonedHashSet)
        {
            Console.WriteLine($"--- {item}");
        }

        // Сортировка
        List<Watch> list = new List<Watch>(hashSet);
        list.Sort((x, y) => x.YearOfManufacture.CompareTo(y.YearOfManufacture));
        HashSet<Watch> sortedHashSet = new HashSet<Watch>(list);
        Console.WriteLine("Отсортированная HashSet:");
        foreach (var item in sortedHashSet)
        {
            Console.WriteLine($"--- {item}");
        }

        // Поиск элемента
        var searchItem = new Watch("Rolex", 2020);
        if (hashSet.Contains(searchItem))
            Console.WriteLine("Элемент найден.");
        else
            Console.WriteLine("Элемент не найден.");

        // ЗАДАНИЕ 3
        Console.WriteLine("\nЗАДАНИЕ 3\n");
        
        // Создание коллекций с 1000 элементов
        TestCollections testCollections = new TestCollections(1000);

        // Измерение времени поиска
        testCollections.MeasureSearchTime();

    }
}