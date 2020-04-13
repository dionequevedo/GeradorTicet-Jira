namespace GeradorTicket_Jira.Entities
{
    class TextosPadroes
    {
        public string Caminhos { get; set; }
        public string Resumo { get; set; }
        public string Funcionamento { get; set; }
        public string Reproduzido { get; set; }
        public string PassoAPasso { get; set; }
        public string Parecer { get; set; }


        public TextosPadroes(string caminhos, string resumo, string funcionamento, string reproduzido, string passoAPasso, string parecer)
        {
            Caminhos = "{panel:title=*CAMINHOS PARA ACESSO AS TELAS:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}1. " + caminhos.ToUpper() + "{panel}";
            Resumo = "\n{panel:title=*RESUMO DO PROBLEMA DO CLIENTE:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}" + resumo + "{panel}";
            Funcionamento = "\n{panel:title=*FUNCIONAMENTO CORRETO NA VISÃO DO CLIENTE:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}" + funcionamento + "{panel}";
            Reproduzido = "\n" + reproduzido + "{panel}";
            PassoAPasso = "\n{panel:title=*SIGA ESTES PASSOS PARA REPRODUZIR O PROBLEMA:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}" + passoAPasso + "{panel}";
            Parecer = "\n{panel:title=*PARECER DO ANALISTA DE SUPORTE:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}" + parecer + "{panel}";
        }

        public override string ToString()
        {
            return Caminhos + Resumo + Funcionamento + Reproduzido + PassoAPasso + Parecer;
        }
    }
}
