using System;
using System.Collections.Generic;

namespace GeradorTicket_Jira.Entities
{
    class GeradorCNS
    {

        public int Numero { get; private set; }

        public GeradorCNS()
        {
        }

        public string GeraCNS()
        {
            Random CNS = new Random();
            List<int> digCNS = new List<int>();
            List<int> multCNS1 = new List<int> { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6 };
            List<int> multCNS2 = new List<int> { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<int> primeiroResultCNS = new List<int>();
            List<int> segundoResultCNS = new List<int>();
            int primeiroDigito = 0, segundoDigito = 0, primeiraSoma = 0, segundaSoma = 0;
            string numCNS = "";
            for(int i = 0; i < 11; i++)
            {

                if(i < 10)
                    digCNS.Add(CNS.Next(0, 9));     /* Adiciona os primeiros 9 dígitos aleatórios */

                if (i == 10)          /* Valida se já possui os 9 primeiros dígitos */
                {
                    for(int y = 0; y < 10; y++)
                    {
                        primeiroResultCNS.Add(digCNS[y] * multCNS1[y]);
                        if(y == 10)
                        {
                            foreach (int valor in primeiroResultCNS)
                            {
                                primeiraSoma += valor;
                            };

                            int v = primeiraSoma % 11;
                            primeiraSoma = v;    /* Calcula o resto da divisão da soma da primeira etapa por 11 */

                            if (primeiraSoma < 2)
                            {
                                primeiroDigito = 0;
                            }
                            else if (primeiraSoma >= 2 && primeiraSoma < 11)
                            {
                                primeiroDigito = 11 - primeiraSoma;
                            }
                        }
                    }

                    digCNS.Add(primeiroDigito);
                }
                
                if (digCNS.Count == 11)  /* Valida se já possui os 10 primeiros dígitos */
                {
                    for (int j = 0; j < 3; j++)
                    {
                        digCNS.Add(CNS.Next(0, 9)); /* Gera os três dígits adicionais  */
                    }

                    for (int t = 0; t < 14; t++)
                    {
                        segundoResultCNS.Add(digCNS[t] * multCNS2[t]);
                        if (t == 13) 
                        {
                            foreach (int valor in segundoResultCNS)
                            {
                                segundaSoma += valor;
                            };

                            int x = segundaSoma % 11;
                            segundaSoma = x;    /* Calcula o resto da divisão da soma da segunda etapa por 11 */

                            if (segundaSoma < 2)
                            {
                                segundoDigito = 0;
                            }
                            else if (segundaSoma >= 2 && segundaSoma < 11)
                            {
                                segundoDigito = 11 - segundaSoma;
                            }
                        }
                    }                    
                }
            }

            digCNS.Add(segundoDigito);

            foreach(int num in digCNS)
            {
                numCNS += num.ToString();
            }
                        
            return numCNS;
        }
    }
}
