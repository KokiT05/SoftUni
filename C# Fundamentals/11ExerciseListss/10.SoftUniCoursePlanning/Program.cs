namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            lessons[1] = "as";
            lessons[2] = lessons[1];

            Console.WriteLine(string.Join(' ', lessons));

            //string command = Console.ReadLine();

            //while (command != "course start")
            //{
            //    string[] cmArgs = command.Split(":").ToArray();
            //    string firstCommand = cmArgs[0];
            //    string lessonsTitle = cmArgs[1];

            //    if (firstCommand == "Add")
            //    {
            //        if (!lessons.Contains(lessonsTitle))
            //        {
            //            lessons.Add(lessonsTitle);
            //        }
            //    }
            //    else if (firstCommand == "Insert")
            //    {
            //        int index = int.Parse(cmArgs[2]);
            //        if (!lessons.Contains(lessonsTitle))
            //        {
            //            lessons.Insert(index, lessonsTitle);
            //        }
            //    }
            //    else if (firstCommand == "Remove")
            //    {
            //        if (lessons.Contains(lessonsTitle))
            //        {
            //            lessons.Remove(lessonsTitle);
            //        }
            //    }
            //    else if (firstCommand == "Swap")
            //    {

            //    }
            //    else if (firstCommand == "Exercise")
            //    {

            //    }
            //}





            //List<string> courses = Console.ReadLine()
            //                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //                            .ToList();

            //string input = Console.ReadLine();
            //while (input != "course start")
            //{
            //    string[] data = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
            //    string operation = data[0].ToLower();
            //    string lessonTitle = data[1];

            //    if (operation.ToLower() == "add" && courses.Contains(lessonTitle) == false)
            //    {
            //        courses.Add(lessonTitle);
            //    }
            //    else if (operation.ToLower() == "insert" && courses.Contains(lessonTitle) == false)
            //    {
            //        int indexx = int.Parse(data[2]);
            //        courses.Insert(indexx, lessonTitle);
            //    }
            //    else if (operation.ToLower() == "remove" && courses.Contains(lessonTitle))
            //    {
            //        for (int i = 0; i < courses.Count; i++)
            //        {
            //            if (courses[i].Contains(lessonTitle))
            //            {
            //                courses.Remove(courses[i]);
            //                i--;
            //            }
            //        }
            //        courses.Remove(lessonTitle);
            //    }
            //    else if (operation.ToLower() == "swap")
            //    {
            //        string secondLesson = data[2];
            //        if (courses.Contains(lessonTitle) && courses.Contains(secondLesson))
            //        {
            //            List<string> firstCourse = courses.Where(c => c.Contains(lessonTitle)).ToList();
            //            List<string> secondCourse = courses.Where(c => c.Contains(secondLesson)).ToList();

            //            int indexOfFirstLesson = courses.IndexOf(lessonTitle);
            //            int indexOfSecondLesson = courses.IndexOf(secondLesson);

            //            for (int i = indexOfFirstLesson; i < courses.Count; i++)
            //            {
            //                if (courses[i].Contains(lessonTitle))
            //                {
            //                    courses[i] = "!";
            //                }
            //            }

            //            courses.InsertRange(indexOfFirstLesson, secondCourse);


            //            for (int i = 0; i < courses.Count; i++)
            //            {
            //                if (courses[i] == "!")
            //                {
            //                    courses.Remove(courses[i]);
            //                    i--;
            //                }
            //            }

            //            for (int i = indexOfSecondLesson; i < courses.Count; i++)
            //            {
            //                if (courses[i].Contains(secondLesson))
            //                {
            //                    courses[i] = "!";
            //                }
            //            }

            //            int indexOfSpecialSymbol = courses.IndexOf("!");

            //            courses.InsertRange(indexOfSpecialSymbol, firstCourse);


            //            for (int i = 0; i < courses.Count; i++)
            //            {
            //                if (courses[i] == "!")
            //                {
            //                    courses.Remove(courses[i]);
            //                    i--;
            //                }
            //            }
            //        }
            //    }
            //    else if (operation.ToLower() == "exercise")
            //    {
            //        if (courses.Contains(lessonTitle) && 
            //            courses.Contains($"{lessonTitle}-Exercise") == false)
            //        {
            //            int indexOfLesson = courses.IndexOf(lessonTitle);

            //            if (indexOfLesson == courses.Count)
            //            {
            //                courses.Add($"{lessonTitle}-Exercise");
            //            }
            //            else
            //            {
            //                courses.Insert(indexOfLesson + 1, $"{lessonTitle}-Exercise");
            //            }
            //        }
            //        else if (courses.Contains(lessonTitle) == false)
            //        {
            //            courses.Add(lessonTitle);
            //            courses.Add($"{lessonTitle}-Exercise");
            //        }
            //    }

            //    input = Console.ReadLine();
            //}

            //int index = 1;
            //for (int i = 0; i < courses.Count; i++)
            //{
            //    Console.WriteLine($"{index}.{courses[i]}");
            //    index++;
            //}
        }
    }
}