using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }

    public Task (string titleInput, string descriptionInput, string dateInput)
    {
        Title = titleInput;
        Description = descriptionInput;
        Date = dateInput;
    }
    
}

namespace RKIS_PR7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            bool exit = true;
            while (exit != false)
            {
                Console.WriteLine("\n\t\tКОМАНДЫ:\n\t0 - Посмотреть списки задач\n\t1 - Посмотреть задачи (на сегодня, завтра, неделю)\n\t2 - Добавить задачу\n\t3 - Редактировать задачу\n\t4 - Удалить задачу\n\t5 - Выход из приложения\n");
                
                int input = int.Parse(Console.ReadLine());
                
                switch (input)
                {
                    case 0:
                        var viewingLists = ViewingLists();
                        if (viewingLists != null)
                        {
                            foreach (var item in viewingLists)
                            {
                                Console.WriteLine("---> " + item.Title);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tУ вас нет задач, отдыхайте :)");
                        }
                        break;
                    case 1:
                        ViewingTasks();
                        break;
                    case 2:
                        AddTask();
                        break;
                    case 3:
                        EditionTask();
                        break;
                    case 4:
                        Console.Write("\nВведите название задачи, которую хотите удалить: ");
                        string titleOfTaskForDelete = Console.ReadLine();
                        DeletionTask(titleOfTaskForDelete);
                        break;
                    case 5:
                        Console.WriteLine("\n\tХОРОШЕГО ДНЯ! ^_^");
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("\n\tТакой команды нет -_-");
                        break;
                        
                }
                
            }

        }

        static List<Task> ReadTaskFromJson()
        {
            string fileName = @"C:\Users\public.COPP\Desktop\КОДЫ\RKIS_PR7\AllTasks.json";
            string textJson =  File.ReadAllText(fileName);

            List<Task> listOfAllTasks = JsonConvert.DeserializeObject<List<Task>>(textJson);
            
            return listOfAllTasks;
        }

        static void SaveListOfTasks(List<Task> newListOfTasks)
        {
            string fileName = @"C:\Users\public.COPP\Desktop\КОДЫ\RKIS_PR7\AllTasks.json";

            string serializedTasks = JsonConvert.SerializeObject(newListOfTasks);

            File.WriteAllText(fileName, serializedTasks);
        }
        
        static void SaveTasks(Task newTask)
        {
            string fileName = @"C:\Users\public.COPP\Desktop\КОДЫ\RKIS_PR7\AllTasks.json";
            
            List<Task> newListOfTasks = new List<Task> {};

            if (ReadTaskFromJson() != null)
            {
                newListOfTasks = ReadTaskFromJson();
            }
            
            newListOfTasks.Add(newTask);
            
            string serializedTasks = JsonConvert.SerializeObject(newListOfTasks);

            File.WriteAllText(fileName, serializedTasks);
        }

        static string CheckExistenceTitle()
        {
            List<Task> listOfAllTasks = ReadTaskFromJson();
            string titleInput = "";
            bool checking = false;
            while (checking != true)
            {
                Console.Write("Введите название задачи: ");
                titleInput = Console.ReadLine();
                if (listOfAllTasks.Any(t => t.Title == titleInput) == true)
                {
                    Console.WriteLine("\tЗадача с таким названием уже существует :(\n");
                }
                else
                {
                    checking = true;
                }
            }

            return titleInput;
        }

        static string CheckFormatDate()
        {
            string dateInput =  "";
            bool checking = false;
            while (checking != true)
            {
                Console.Write("Введите срок выполнения задачи (дд/мм/гггг - 01/01/0001): ");
                dateInput = Console.ReadLine();
                
                CultureInfo enUs = new CultureInfo("en-US");
                if (DateTime.TryParseExact(dateInput, "dd/MM/yyyy", enUs, DateTimeStyles.None, out _) != true)
                {
                    Console.WriteLine("\tНеверный формат даты -_-\n\tПопробуйте снова");
                }
                else
                {
                    checking = true;
                }
            }
            
            return dateInput;
        }
        
        static void AddTask()
        {
            Console.WriteLine("\n\tСОЗДАНИЕ ЗАДАЧИ...");
            List<Task> listOfAllTasks = ReadTaskFromJson();
            
            string titleInput = "";
            if (ReadTaskFromJson() != null)
                titleInput = CheckExistenceTitle();
            else
            {
                Console.Write("Введите название задачи: ");
                titleInput = Console.ReadLine();
            }
            
            Console.Write("Введите описание задачи: ");
            string descriptionInput = Console.ReadLine();
            
            string dateInput = CheckFormatDate();
            
            Task newTask = new Task(titleInput, descriptionInput, dateInput);
            
            if (ReadTaskFromJson() != null)
            {
                listOfAllTasks.Add(newTask);
                SaveListOfTasks(listOfAllTasks);
            }
            else
                SaveTasks(newTask);
            
            Console.WriteLine("\tЗАДАЧА СОЗДАНА :)");
        }

        static void EditionTask()
        {
            Console.WriteLine("\n\tРЕДАКТИРОВАНИЕ ЗАДАЧИ...");
            List<Task> listOfAllTasks = ReadTaskFromJson();
            string titleInput = "";
            
            bool checkEdition = false;
            while (checkEdition != true)
            {
                Console.Write("Введите название задачи, которую хотите изменить: ");
                titleInput = Console.ReadLine();
                if (listOfAllTasks.Any(t => t.Title == titleInput) != true)
                {
                    Console.WriteLine("\tНет задачи с таким названием -_-");
                }
                else
                {
                    checkEdition = true;
                }
            }
            
            Task taskForEdition = listOfAllTasks.FirstOrDefault(t => t.Title == titleInput);
            
            checkEdition = false;
            while (checkEdition != true)
            {
                Console.WriteLine("\n\tЧто вы хотите изменить?\n\t0 - Название\n\t1 - Описание\n\t2 - Срок\n");
                int inputEdition = int.Parse(Console.ReadLine());
                
                switch (inputEdition)
                {
                    case 0:
                        string newtitle = CheckExistenceTitle();
                        taskForEdition.Title = newtitle;
                        break;
                    case 1: 
                        Console.Write("Введите описание: ");
                        string newdescription = Console.ReadLine();
                        taskForEdition.Description = newdescription;
                        break;
                    case 2:
                        string newdate = CheckFormatDate();
                        taskForEdition.Date = newdate;
                        break;
                    default:
                        Console.WriteLine("\tНет такого параметра -_-");
                        break;
                }
                
                Console.WriteLine("\n\tПродолжить редактирование задачи?\n\t0 - НЕТ\n\t1 - ДА\n");
                int inputOtherEdition = int.Parse(Console.ReadLine());
                
                switch (inputOtherEdition)
                {
                    case 0:
                        checkEdition = true;
                        break;
                    case 1:
                        break;
                    default:
                        Console.WriteLine("Не корректный ввод -_-");
                        break;
                }
                
            }
            
            SaveListOfTasks(listOfAllTasks);
            Console.WriteLine("\tИЗМЕНЕНИЯ СОХРАНЕНЫ :)");
        }
        
        static void DeletionTask(string title)
        {
            Console.WriteLine($"\n\tУДАЛЕНИЕ ЗАДАЧИ...");
            List<Task> listOfAllTasks = ReadTaskFromJson();

            Task taskForDeletion = listOfAllTasks.FirstOrDefault(t => t.Title == title);
            
            if (taskForDeletion != null)
            {
                listOfAllTasks.Remove(taskForDeletion);
                SaveListOfTasks(listOfAllTasks);
                Console.WriteLine($"\tЗАДАЧА УДАЛЕНА");
            }
            else
            {
                Console.WriteLine("\tТакой задачи нет в списке");
            }
            
        }

        static List<Task> ViewingLists()
        {
            List<Task> listOfAllTasks = ReadTaskFromJson();
            List<Task> listOfTasks = new List<Task>();
            DateTime nowTime = DateTime.Today;

            Console.WriteLine("\tПосмотреть:\n\t0 - Список всех задач\n\t1 - Список предстоящих задач\n\t2 - Список прошедших задач\n\t");
            int inputTypeOfList = int.Parse(Console.ReadLine());
            
            switch (inputTypeOfList)
            {
                case 0:
                    Console.WriteLine("\nСписок всех задач: ");
                    if (listOfAllTasks == null)
                    {
                        Console.WriteLine("\tУ вас пока нет задач");
                    }
                    else
                    {
                        foreach (var item in listOfAllTasks)
                        {
                            Console.WriteLine("---> " + item.Title);
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("\nПредстоящие задачи: ");
                    foreach (var item in listOfAllTasks)
                    {
                        if (nowTime < DateTime.ParseExact(item.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        {
                            listOfTasks.Add(item);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("\nПрошедшие задачи: ");
                    foreach (var item in listOfAllTasks)
                    {
                        if (nowTime > DateTime.ParseExact(item.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        {
                            listOfTasks.Add(item);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\tТакой команды нет -_-");
                    break;
            }

            return listOfTasks;

        }

        static void ViewingTasks()
        {
            List<Task> listOfAllTasks = ReadTaskFromJson();
            List<Task> listOfTasks = new List<Task>();
            DateTime nowTime = DateTime.Today;

            Console.WriteLine("\tПосмотреть список задач:\n\t0 - На сегодня\n\t1 - На завтра\n\t2 - На неделю\n");
            int inputTypeOfList = int.Parse(Console.ReadLine());

            switch (inputTypeOfList)
            {
                case 0:
                    Console.WriteLine("\nВаши задачи на сегодня:");
                    foreach (var item in listOfAllTasks)
                    {
                        if (nowTime.ToString("dd/MM/yyyy").Replace('.', '/') == item.Date)
                        {
                            listOfTasks.Add(item);
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("\nВаши задачи на завтра:");
                    foreach (var item in listOfAllTasks)
                    {
                        if (nowTime.AddDays(1).ToString("dd/MM/yyyy").Replace('.', '/') == item.Date)
                        {
                            listOfTasks.Add(item);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("\nВаши задачи на неделю:");
                    for (int i = 0; i < 7; i++)
                    {
                        foreach (var item in listOfAllTasks)
                        {
                            if (nowTime.AddDays(i).ToString("dd/MM/yyyy").Replace('.', '/') == item.Date)
                            {
                                listOfTasks.Add(item);
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("\nТакой команды нет -_-");
                    break;
            }
            foreach (var item in listOfTasks)
            {
                Console.WriteLine($"------> Задача: {item.Title}\n\tОписание: {item.Description}\n\tСрок: {item.Date}");
            }
            
        }
        
    }
}