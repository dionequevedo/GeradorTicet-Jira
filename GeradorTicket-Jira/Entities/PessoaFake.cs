using System;
using Bogus;

namespace GeradorTicket_Jira.Entities
{
    class PessoaFake
    {
        public PessoaFake() 
        { 
        }
        public string GeraNomeFake()
        {
            Bogus.Faker pessoa = new Bogus.Faker("pt_BR");
            string nome = pessoa.Name.FullName().ToUpperInvariant();    
                

            return nome;
        }
    }
}
