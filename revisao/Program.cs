using System;

namespace revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            aluno[] alunos = new aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("informe o nome do aluno:");
                        aluno aluno = new aluno();
                        aluno.NOME = Console.ReadLine();

                        Console.WriteLine("informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.NOTA = nota;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("valor da nota deve ser decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos)
                            if (!string.IsNullOrEmpty(a.NOME))
                        
                        {
                            Console.WriteLine($"ALUNO: {a.NOME} - NOTA: {a.NOTA}");
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nralunos = 0;

                        for(int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].NOME))
                            {
                                notaTotal = notaTotal + alunos[i].NOTA;
                                nralunos++;
                            }

                        }

                        var mediaGeral = notaTotal/ nralunos;
                        conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = conceito.B;
                        }
                        else
                        {
                            conceitoGeral = conceito.A;
                        }



                        Console.WriteLine($"MEDIA: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opçao desejada");
            Console.WriteLine("1- insira um aluno");
            Console.WriteLine("2- listar aluno");
            Console.WriteLine("3- calcular a media geral");
            Console.WriteLine("X- sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
