using System.ComponentModel;

Dictionary<string, Dictionary<string, List<int>>> alunos = new Dictionary<string, Dictionary<string, List<int>>>();




void ExibirLogo() {
    Console.WriteLine(@"
█▀▀ █▀ █▀▀ █▀█ █░░ ▄▀█   █▀▄ █▀▀   █▀█ █▀█ █▀█ █▀▀ █▀█ ▄▀█ █▀▄▀█ ▄▀█ █▀▀ ▄▀█ █▀█
██▄ ▄█ █▄▄ █▄█ █▄▄ █▀█   █▄▀ ██▄   █▀▀ █▀▄ █▄█ █▄█ █▀▄ █▀█ █░▀░█ █▀█ █▄▄ █▀█ █▄█");
    
    Console.WriteLine("\nBem Vindo a Escola de Programação");
}

void Menu()
{
    Console.Clear();   
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um aluno");
    Console.WriteLine("Digite 2 para avaliar um aluno");
    Console.WriteLine("Digite 3 para mostrar os alunos");
    Console.WriteLine("Digite 4 para exibir a média de um aluno");
    Console.WriteLine("Digite 0 para sair");
    
    Console.WriteLine("\nDigite sua opção: ");
    string opcao = Console.ReadLine()!;
    int opcaoNum = int.Parse(opcao);

    switch (opcaoNum)
    {
        case 1: RegistrarAluno();
            break;

        case 2: AvaliarAluno();
            break;

        case 3: MostrarAluno();
            break;

        case 4: ExibirMedia();
            break;

    }
}

void RegistrarAluno()
{
    confTitulo("Registro de Alunos");
    Console.Write("\nDigite o nome do Aluno que deseja registrar: ");
    string aluno = Console.ReadLine()!;

    if (!alunos.ContainsKey(aluno))
    {
        alunos[aluno] = new Dictionary<string, List<int>>();
        Console.WriteLine("\nDeseja inserir mais algum aluno?\nDigite 1 para inserir ou 0 para voltar ao menu inicial.");
        switch (int.Parse(Console.ReadLine()!))
        {
            case 1:
                RegistrarAluno();
                break;
            case 0:
                Menu();
                break;
        }
    }
    else { Console.WriteLine($"{aluno} já está registrado no sistema, digite o nome de outro aluno.");
           Thread.Sleep(5000);
           RegistrarAluno();
    }
}

void MostrarAluno()
{
    confTitulo("Alunos");
    foreach (var aluno in alunos)
    {
        Console.WriteLine($"Aluno:{aluno.Key}");

        foreach(var materia in aluno.Value)
        {
            Console.WriteLine($"Matéria:{materia.Key}");

            foreach(var nota in materia.Value)
            {
                Console.WriteLine($"Nota:{nota}\n");

            }
        }
    }
}

void AvaliarAluno()
{
    confTitulo("Avaliar Alunos");
    Console.WriteLine("Digite o nome do aluno que deseja avaliar:");
    string aluno = Console.ReadLine()!; 
    if (alunos.ContainsKey(aluno))
    {
        Console.WriteLine("Digite para qual matéria deseja incluir a nota:");
        string materia = Console.ReadLine()!;
        if (!alunos[aluno].ContainsKey(materia)) 
        {
            alunos[aluno][materia] = new List<int>();
            Console.WriteLine($"Digite a nota da matéria {materia} do aluno {aluno}: ");
            int nota = int.Parse(Console.ReadLine()!);
            alunos[aluno][materia].Add(nota);
            Menu(); 
        }
    }
}

void ExibirMedia()
{
    confTitulo("Média dos Alunos");
    Console.WriteLine("Digite o nome do aluno que deseja saber a média:");
    string aluno = Console.ReadLine()!;
    if (alunos.ContainsKey(aluno))
    {
        var notas = new List<int>();
        foreach (var materia in alunos[aluno])
        {
            notas.AddRange(materia.Value);
        }
            if (notas.Count > 0)
            {
                int soma = 0;
                foreach(int nota in notas)
                {
                    soma += nota;
                }
                double media = (double)soma/notas.Count;
                Console.WriteLine($"A média do aluno {aluno} é:{media}");
            }
        

    }else { Console.WriteLine("Aluno não cadastrado!");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu inicial.");
        Console.ReadKey();
        Menu(); 
    }

}


void confTitulo(string titulo)
{
    Console.Clear();
    int quantLetras = titulo.Length;
    string margem = string.Empty.PadLeft(quantLetras, '*');
    Console.WriteLine(margem);
    Console.WriteLine(titulo);
    Console.WriteLine(margem);
}

Menu();