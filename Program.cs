using System;

class ToDoListClass
{
    static List<string> toDo = new List<string>(); // Lista para armazenar as tarefas
    static void Main()
    {
        Console.WriteLine(DateTime.Now); // Exibe a data e hora atual
        Console.WriteLine("TO DO LIST\n");
        Console.WriteLine("1 - Insert your task\n2 - Show yours tasks\n3 - Delete Task\n0 - Exit");

        ConsoleKeyInfo tapUser; // Variável para armazenar a tecla pressionada pelo usuário

        do
        {
            tapUser = Console.ReadKey(true); // Captura a tecla pressionada sem exibir no console

            switch (tapUser.KeyChar) // Verifica a tecla pressionada pelo usuário
            {
                case '1':
                    Console.Clear(); 
                    InsertTask(); 
                    break;
                case '2':
                    Console.Clear(); 
                    ShowTasks(); 
                    break;
                case '0':
                    Exit();
                    break;
                default:
                    InvalidOption();
                    Main(); // Reinicia o loop principal
                    break;
            }
        }
        while (true); // Loop infinito para continuar solicitando entrada do usuário
    }
    static void InvalidOption()
    {
        Console.Clear(); 
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.WriteLine("Choose a valid option"); 
        Thread.Sleep(2000);
        Console.ResetColor(); 
        Console.Clear(); 
    }
    static void InsertTask()
    {
        string task;
        Console.Write("Insert your new task: ");
        try
        {
            task = Console.ReadLine(); // Captura a tarefa digitada pelo usuário
            if (string.IsNullOrEmpty(task))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("Field cannot be null"); 
                Thread.Sleep(2000);
                Console.ResetColor(); 
                Console.Clear();
                InsertTask(); 
            }
            else
            {
                toDo.Add(task); 
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task added"); 
                Thread.Sleep(1500); 
                Console.ResetColor(); 
                Console.Clear(); 
                Main(); 
            }
        }
        catch
        {
            InvalidOption(); // Chama a função para opção inválida
            InsertTask(); // Chama a função novamente para inserir a tarefa
        }
    }
    static void ShowTasks()
    {
        Console.WriteLine("Your tasks:\n");
        // Mostra todas as tarefas com seus números correspondentes
        for (int i = 0; i < toDo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {toDo[i]}");
        }
        Console.WriteLine("\nIf you wish to delete any task, please enter the corresponding number:");

        // Solicita ao usuário para selecionar a tarefa a ser removida
        int taskIndex = int.Parse(Console.ReadLine());
        // Verifica se o índice está dentro dos limites da lista
        if (taskIndex >= 1 && taskIndex <= toDo.Count)
        {
            // Remove a tarefa correspondente à posição fornecida pelo usuário
            toDo.RemoveAt(taskIndex - 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Task {taskIndex} removed successfully!");
            Console.ResetColor();
            Thread.Sleep(1500);
            Console.Clear();
            Main();
        }
        else
        {
            Console.WriteLine("Invalid task number!");
        }
    }
    static void Exit()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green; // Define a cor do texto para verde
        Console.WriteLine("Thanks for using my application"); 
        Console.WriteLine("Follow my LinkedIn:");
        Console.WriteLine("https://www.linkedin.com/in/gabriel-lemes-de-oliveira-b1410584/");
        Thread.Sleep(3000); 
        Environment.Exit(0); // Encerra o programa
    }
}
