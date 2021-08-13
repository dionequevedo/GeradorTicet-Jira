using System;
using System.Collections.Generic;

namespace GeradorTicket_Jira.Entities
{
    class GeradorTelefone
    {


        public int Numero { get; private set; }

        public GeradorTelefone()
        {
        }

        public string GeraTelefone(int op)
        {
            string numTelefone = "";
            Random aleatorio = new Random();
            List<string> dddCel = new List<string> { "51 9", "31 9", "11 9", "21 9", "41 9", "53 9", "91 9" };
            List<string> dddFix = new List<string> { "51 3", "31 3", "11 3", "21 3", "41 3", "53 3", "91 3" };

            if (op == 1)
            {
                numTelefone = dddCel[aleatorio.Next(0, 6)];
                for (int i = 0; i < 8; i++)
                {
                    numTelefone += aleatorio.Next(0, 9);
                    if (i == 3)
                        numTelefone += "-";
                }
            }
            else
            {
                numTelefone = dddFix[aleatorio.Next(0, 6)];
                for (int i = 0; i < 7; i++)
                {
                    numTelefone += aleatorio.Next(0, 9);
                    if (i == 2)
                        numTelefone += "-";
                }
            }

            return numTelefone;
        }
    }
}
