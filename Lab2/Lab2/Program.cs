using System.Dynamic;

class Program
{
    static void Main()
    {
        int exit = 1;
        while (exit == 1)
        {
            Console.WriteLine("== Menu ==");
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Выход");
            Console.Write("Введите номер пункта:");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Введите НОМЕР пункта. Пожалуйста:");
            }
            string exitChoice;
            switch (choice)
            {
                case 1:
                    Console.WriteLine(choice);
                    const double Pi = Math.PI;

                    Console.Write("число a:");
                    double a;
                    while (!double.TryParse(Console.ReadLine(), out a) ||Math.Sin(a)+1==0)
                    {
                        
                        Console.Write("Введите ЧИСЛО. Пожалуйста:");
                    }
                   
                   


                    Console.Write("число b:");
                    double b;
                    while (!double.TryParse(Console.ReadLine(), out b))
                    {
                       
                        Console.Write("Введите ЧИСЛО. Пожалуйста:");
                        
                    }

                    double f = Pi * ((Math.Log10(Math.Pow(b, 5))) / Math.Sin(a) + 1);
                    double answer=0;
                    f = Math.Round(f,2);
                    Console.Write("Сколько вам надо попыток?:");
                    double tryes;
                    while (!double.TryParse(Console.ReadLine(), out tryes))
                    {

                        Console.Write("Введите ЧИСЛО. Пожалуйста:");
                        
                    }
                    
                    int i=0;
                    int j = 0;
                    while (i < tryes && j==0)
                    {
                        Console.WriteLine("Введите предпологаемый ответ.Осталось попыток - " + (tryes - i));
                        while (!double.TryParse(Console.ReadLine(), out answer))
                        {

                            Console.Write("Введите ЧИСЛО. Пожалуйста:");

                        }
                        if (f == answer)
                        {
                            Console.WriteLine("Поздравляем, вы победили");
                            j++;
                        }
                        else if (i == tryes-1)
                            Console.WriteLine("Вы програли. Правильный ответ: {0:f2} ", f);
                        i++;
                    }

                        
                    break;
                    
                    

                    Console.WriteLine("{0:f2}", f);
                    break;
                case 2:
                    Console.WriteLine("Баймишев Тимур Ильясовичю ИВТ 6 группа");
                    break;
                case 3:
                    Console.WriteLine("Подтвердите выход. Введите 'Да' или 'Нет'");
                    exitChoice = Console.ReadLine();
                    while (exitChoice != "Да" && exitChoice != "Нет")
                    {
                        Console.WriteLine("Ошибка.Попробйуте ещё раз. Введите 'Да' или 'Нет'");
                        exitChoice= Console.ReadLine();
                    }
                    
                    
                    switch (exitChoice)
                    {
                        case "Да":
                            exit += 1;
                            break;
                        case "Нет":
                            break;
                    }
                    break;
                          
                       
                default:
                    Console.WriteLine("Пункта с таким номером нет");
                    break;
            }

        }
       
        
    }
}