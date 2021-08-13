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
            List<string> dddCel = new List<string> { "519", "319", "119", "219", "419", "539", "919" };
            List<string> dddFix = new List<string> { "513", "313", "113", "213", "413", "533", "913" };

            if (op == 1)
            {
                numTelefone = dddCel[aleatorio.Next(0, 6)];
                numTelefone += " ";
                for (int i = 0; i < 9; i++)
                {
                    numTelefone += aleatorio.Next(0, 9);
                    if (i == 4)
                        numTelefone += "-";
                }
            }
            else
            {
                numTelefone = dddFix[aleatorio.Next(0, 6)];
                numTelefone += " ";
                for (int i = 0; i < 8; i++)
                {
                    numTelefone += aleatorio.Next(0, 9);
                    if (i == 3)
                        numTelefone += "-";
                }
            }

            return numTelefone;
        }
    }
}
