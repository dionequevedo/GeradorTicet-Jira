using GeradorTicket_Jira.Entities.Enums;
using System;

namespace GeradorTicket_Jira.Entities
{
    class Ticket
    {
        public int CodCliente { get; set; }
        public string Area { get; set; }
        public string VersaoCliente { get; set; }
        public string SistemaOperacional { get; set; }
        public string Aplicacao { get; set; }
        public Boolean Ambiente { get; set; }
        public TipoTicket Tipo { get; set; }


        public Ticket(int codCliente, string area, string versaoCliente, string sistemaOperacional, string aplicacao, bool ambiente, TipoTicket tipo)
        {
            CodCliente = codCliente;
            Area = area;
            VersaoCliente = versaoCliente;
            SistemaOperacional = sistemaOperacional;
            Aplicacao = aplicacao;
            Ambiente = ambiente;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return "{panel:title=*RELATÓRIO DE ANÁLISE DE SUPORTE*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#7AC5DD|bgColor=#7AC5DD|titleColor=BLACK}"
                + "{panel}"
                + "{panel: title = *DADOS DA ESTAÇÃO DO CLIENTE:*| borderStyle = solid | borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}"
                + "\n*CLIENTE:* "
                + CodCliente
                + "\n*ÁREA NA INSTITUIÇÃO:* "
                + Area
                + "\n*VERSÃO:* "
                + VersaoCliente
                + "\n*SISTEMA OPERACIONAL:* "
                + SistemaOperacional
                + "\n*APLICAÇÃO ENVOLVIDA:* "
                + Aplicacao
                + "\n*AMBIENTE:* "
                + (Ambiente == true ? "PRODUÇÃO" : "HOMOLOGAÇÃO\n")
                + "{panel}\n";
        }
    }
}
