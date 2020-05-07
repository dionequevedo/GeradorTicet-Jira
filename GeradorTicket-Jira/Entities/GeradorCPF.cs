using System;
using System.Collections.Generic;

namespace GeradorTicket_Jira.Entities
{
    class GeradorCPF
    {

        public int Numero { get; private set; }

        public GeradorCPF()
        {
        }

        public string GeraCPF()
        {
            Random cpf = new Random();
            List<int> digCpf = new List<int>();
            List<int> multCpf = new List<int> { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<int> resultCpf = new List<int>();
            string numCPF = "";
            for(int i = 0; i < 9; i++)
            {
                digCpf.Add(cpf.Next(0, 9));
                if (digCpf.Count == 9) {
                    int count = 0;
                    foreach(int pos in digCpf)
                    {
                        resultCpf.Add(pos * multCpf[count+1]);
                        count++;
                    }
                }
            }
            
            
            return numCPF;
        }
    }
}
