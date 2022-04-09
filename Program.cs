using System;
using Criando_um_app_simples_de_cadastro_de_series_em_.NET;

public class Program 
{
    static DoramaRepository repository = new DoramaRepository();
    public static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();
        while (opcaoUsuario.ToUpper() != "X")
        {
            switch(opcaoUsuario)
            {
                case "1":
                ListarDoramas();
                break;
                case "2":
                InserirDoramas();
                break;
                case "3":
                AtualizarDoramas();
                break;
                case "4":
                ExcluirDoramas();
                break;
                case "5":
                VisualizarDoramas();
                break;
                case "C":
                Console.Clear();
                break;

                default:
                    throw new ArgumentOutOfRangeException();

            }
            opcaoUsuario = ObterOpcaoUsuario();
        }
        Console.WriteLine("Obrigada por ultilizar nossos serviços");
        Console.ReadLine();
    }

    private static void ListarDoramas()
    {
        Console.WriteLine("Listar Doramas");
         var lista = repository.Lista();
        
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum dorama cadastrado.");
            return;
        }
        foreach (var dorama in lista)
        {
            var excluido = dorama.retornaExcluido();
            Console.WriteLine("#ID {0}: - {1} {2}", dorama.retornaId(), dorama.retornaTitulo, (excluido ? "*excluido*" : ""));
        }
    }
    private static void InserirDoramas()
    {
        Console.WriteLine("Inserir novo Dorama");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o genero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo do dorama: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Inicio do dorama: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descriçao do dorama: ");
        string entradaDescricao = Console.ReadLine();
        
        Doramas novoDorama = new Doramas(Id: repository.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
        
        repository.Insere(novoDorama);
    }

    private static void ExcluirDoramas()
    {
        Console.Write("Digite o id do dorama: ");
        int indiceDorama = int.Parse(Console.ReadLine());

        repository.Exclui(indiceDorama);
    }
    private static void VisualizarDoramas()
    {
        Console.Write("Digite o id do dorama: ");
        int indiceDorama = int.Parse(Console.ReadLine());

        var dorama = repository.RetornaPorId(indiceDorama);

        Console.WriteLine(dorama);

    }


    private static void AtualizarDoramas()
    {
        Console.Write("Digite o id do dorama: ");
        int indiceDorama = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o genero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Titulo do dorama: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Inicio do dorama: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a descriçao do dorama: ");
        string entradaDescricao = Console.ReadLine();
        
        Doramas atualizaDorama = new Doramas(Id: indiceDorama,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
        
        repository.Atualiza(indiceDorama, atualizaDorama);
    }






    private static string ObterOpcaoUsuario()
    {

        Console.WriteLine();
        Console.WriteLine("Doramas a seu dispor!!!!!");
        Console.WriteLine("Informe a opção desejada: ");

        Console.WriteLine("1- Listar Doramas");
        Console.WriteLine("2- Inserir novo Dorama");
        Console.WriteLine("3- Atualizar Dorama");
        Console.WriteLine("4- Excluir Dorama");
        Console.WriteLine("5- Visualizar Dorama");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- sair");
        Console.WriteLine();
        

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;


    }

}