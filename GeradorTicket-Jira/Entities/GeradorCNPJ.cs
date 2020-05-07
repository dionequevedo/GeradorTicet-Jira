using System;
using System.Collections.Generic;

namespace GeradorTicket_Jira.Entities
{
    class GeradorCNPJ
    {

        public int Numero { get; private set; }

        public GeradorCNPJ()
        {
        }

        public string GeraCNPJ()
        {
            Random CNPJ = new Random();
            List<int> digCNPJ = new List<int>();
            List<int> multCNPJ = new List<int> {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<int> primeiroResultCNPJ = new List<int>();
            List<int> segundoResultCNPJ = new List<int>();
            int segundoDigito = 0;
            string numCNPJ = "";
            for(int i = 0; i < 12; i++)
            {
                int primeiroDigito = 0;
                int primeiraSoma = 0;

                if(i < 12)
                    digCNPJ.Add(CNPJ.Next(0, 9));     /* Adiciona os primeiros 9 dígitos aleatórios */

                if (i == 11)          /* Valida se já possui os 9 primeiros dígitos */
                {
                    for(int y = 0; y < 12; y++)
                    {
                        primeiroResultCNPJ.Add(digCNPJ[y] * multCNPJ[y+1]);
                        if(y == 11)
                        {
                            foreach (int valor in primeiroResultCNPJ)
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

                    digCNPJ.Add(primeiroDigito);
                }

                int segundaSoma = 0;
                if (digCNPJ.Count == 13)  /* Valida se já possui os 10 primeiros dígitos */
                {                    
                    for (int t = 0; t < 13; t++)
                    {                        
                        segundoResultCNPJ.Add(digCNPJ[t] * multCNPJ[t]);
                        if (t == 12) 
                        {
                            foreach (int valor in segundoResultCNPJ)
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

            digCNPJ.Add(segundoDigito);

            foreach(int num in digCNPJ)
            {
                numCNPJ += num.ToString();
            }
            
            
            return numCNPJ;
        }
    }
}
