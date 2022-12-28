using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadoxoDeMontyHall
{
    public class Program
    {
        static void Main(string[] args)
        {
            new ParadoxoDeMontyHall().SimulacaoParadoxoDeMontyHall();
            //string leitura = Console.ReadLine();
        }

    }

    public class ParadoxoDeMontyHall{
        public void SimulacaoParadoxoDeMontyHall()
        {
            Random r = new Random();

            Console.WriteLine("Iniciando simulação/prova real do Paradoxo de Monty Hall...");

            string textoSaida = "";

            int quantidadeDeVezes = 2000;
            int quantidadeAcertosComTrocaDePalpite = 0;
            int quantidadeAcertosSemTrocaDePalpite = 0;

            List<string> Caixas = ListaCaixas();

            int CaixaEscolhida = 0;
            int CaixaCorreta = 0;
            string CaixaErradaDasNaoEscolhidas = "";
            string CaixaNovoPalpite = "";

            //Trocando de caixa, toda vez.
            textoSaida += "Pessoa A, que trocará de caixa após palpite inicial: \n";
            for (int cont = 1; cont <= quantidadeDeVezes; cont++)
            {

                Console.WriteLine("Rodante teste " + cont);


                CaixaEscolhida = 0;
                CaixaCorreta = 0;
                CaixaErradaDasNaoEscolhidas = "";
                CaixaNovoPalpite = "";

                CaixaCorreta = r.Next(0, 3);
                CaixaEscolhida = r.Next(0, 3);

                int EscolherEntreAsDuasCaixasNaoEscolhidas = r.Next(0, 2);
                List<string> CaixasRestantes = Caixas.Where(c => c != Caixas[CaixaEscolhida]).ToList();

                do
                {
                    if(CaixasRestantes[EscolherEntreAsDuasCaixasNaoEscolhidas] != Caixas[CaixaCorreta])
                    {
                        CaixaErradaDasNaoEscolhidas = CaixasRestantes[EscolherEntreAsDuasCaixasNaoEscolhidas];
                    }
                    else
                    {
                        if(EscolherEntreAsDuasCaixasNaoEscolhidas == 0) EscolherEntreAsDuasCaixasNaoEscolhidas = 1;
                        else EscolherEntreAsDuasCaixasNaoEscolhidas = 0;
                    }

                } while (CaixaErradaDasNaoEscolhidas == "");
                
                //Trocar palpite para a caixa que não foi escolhida e ainda está fechada
                CaixaNovoPalpite = Caixas.Where(c => c != Caixas[CaixaEscolhida] && c != CaixaErradaDasNaoEscolhidas).SingleOrDefault();

                textoSaida += "\n\nRodada " + cont + ":";
                textoSaida += "\nCaixa escolhida: " + Caixas[CaixaEscolhida].ToString();
                textoSaida += "\nCaixas restantes: " + CaixasRestantes[0].ToString() + ", " + CaixasRestantes[1];
                textoSaida += "\nCaixa correta: " + Caixas[CaixaCorreta].ToString();
                textoSaida += "\nCaixa revelada que está errada: " + CaixaErradaDasNaoEscolhidas;
                textoSaida += "\nNovo palpite: " + CaixaNovoPalpite;
                textoSaida += "\nPessoa acertou: " + (Caixas[CaixaCorreta].ToString() == CaixaNovoPalpite ? "SIM" : "NÃO");

                if(Caixas[CaixaCorreta].ToString() == CaixaNovoPalpite)
                {
                    quantidadeAcertosComTrocaDePalpite++;
                }

            }

            textoSaida += "\n\nPessoa B, que PERMANECERÁ com a caixa após palpite inicial: \n";

            for (int cont = 1; cont <= quantidadeDeVezes; cont++)
            {
                CaixaEscolhida = 0;
                CaixaCorreta = 0;
                CaixaErradaDasNaoEscolhidas = "";
                
                CaixaCorreta = r.Next(0, 3);
                CaixaEscolhida = r.Next(0, 3);

                int EscolherEntreAsDuasCaixasNaoEscolhidas = r.Next(0, 2);
                List<string> CaixasRestantes = Caixas.Where(c => c != Caixas[CaixaEscolhida]).ToList();

                do
                {
                    if (CaixasRestantes[EscolherEntreAsDuasCaixasNaoEscolhidas] != Caixas[CaixaCorreta])
                    {
                        CaixaErradaDasNaoEscolhidas = CaixasRestantes[EscolherEntreAsDuasCaixasNaoEscolhidas];
                    }
                    else
                    {
                        if (EscolherEntreAsDuasCaixasNaoEscolhidas == 0) EscolherEntreAsDuasCaixasNaoEscolhidas = 1;
                        else EscolherEntreAsDuasCaixasNaoEscolhidas = 0;
                    }

                } while (CaixaErradaDasNaoEscolhidas == "");


                textoSaida += "\n\nRodada " + cont + ":";
                textoSaida += "\nCaixa escolhida: " + Caixas[CaixaEscolhida].ToString();
                textoSaida += "\nCaixas restantes: " + CaixasRestantes[0].ToString() + ", " + CaixasRestantes[1];
                textoSaida += "\nCaixa correta: " + Caixas[CaixaCorreta].ToString();
                textoSaida += "\nCaixa revelada que está errada: " + CaixaErradaDasNaoEscolhidas;
                textoSaida += "\nPalpite final (o mesmo do escolhido): " + Caixas[CaixaEscolhida].ToString();
                textoSaida += "\nPessoa acertou: " + (Caixas[CaixaCorreta].ToString() == Caixas[CaixaEscolhida] ? "SIM" : "NÃO");

                if (Caixas[CaixaCorreta].ToString() == Caixas[CaixaEscolhida].ToString())
                {
                    quantidadeAcertosSemTrocaDePalpite++;
                }

            }

            textoSaida += "\n\n\nResultado final\n\nAcertos de quem TROCOU o palpite: " + quantidadeAcertosComTrocaDePalpite + 
                "\n\nAcertos de quem CONTINUOU com o palpite inicial: " + quantidadeAcertosSemTrocaDePalpite +
                "\n\n";

            Console.WriteLine(textoSaida);

            string leitura = Console.ReadLine();
        }
         

        public string EscolheCaixa()
        {
            ListaCaixas();
            return "";
        }

        public List<string> ListaCaixas()
        {
            List<string> Caixas = new List<string>();
            Caixas.Add("A");
            Caixas.Add("B");
            Caixas.Add("C");
            return Caixas;
        }
    }


}
