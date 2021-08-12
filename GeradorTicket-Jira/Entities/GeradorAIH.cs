using System;
using System.Collections.Generic;

namespace GeradorTicket_Jira.Entities
{
    class GeradorAIH
    {

        public int Numero { get; private set; }

        public GeradorAIH()
        {
        }

        public string GeraAIH()
        {            
            List<int> primParDigAIH = new List<int> { 11, 12, 13, 14, 15, 16, 17, 21, 22, 23, 24, 25, 26, 27, 28, 29, 31, 32, 33, 35, 41, 42, 43, 50, 51, 52, 53, 99 };
            int segParDigAIH = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2));
            Random tipoCodigoAIH = new Random();
            Random aleatorio = new Random();
            string numeroDefinitivo = "";

            for (int i = 0; i < 5; i++)
            {
                numeroDefinitivo = primParDigAIH[aleatorio.Next(0, 27)].ToString();     /*  Adiciona os primeiros 2 dígitos referente ao estado ou a 99 que é CNRAC
                                                                                         *  (Central Nacional de regulação de Alta Complexidade)                            */
                numeroDefinitivo += segParDigAIH.ToString();                            /*  Adiciona os dois dígitos referente ao ano atual                                 */
                numeroDefinitivo += tipoCodigoAIH.Next(1, 5);                           /*  Adiciona o código referente ao tipo de AIH                                      */

                for(int x = 0; x < 7; x++)
                {
                    numeroDefinitivo += aleatorio.Next(0, 9).ToString();
                }
            }

            int valorOriginal = Convert.ToInt32(numeroDefinitivo);
            string digitoVerificador = (valorOriginal % 11).ToString().Substring(-1);
            numeroDefinitivo += digitoVerificador;
            
            return numeroDefinitivo;
        }
    }
}
