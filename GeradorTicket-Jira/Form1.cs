using System;
using System.Windows.Forms;
using GeradorTicket_Jira.Entities;
using GeradorTicket_Jira.Entities.Enums;

namespace GeradorTicket_Jira
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        Ticket ticket;
        
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void descriçãoDeProblemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbProblemas.Visible = true;
            tbProblemas.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            int cliente = int.Parse(tbCliente.Text);        //Armazena o código do cliente

            string anexos = rbAnexoSim.Checked == true ? "\n*Há PSR, vídeo ou outros anexos!* " : "\n*Não há PSR, vídeo ou outros anexos!* ";

            Boolean ambienteProducao = rbProducao.Checked ? true : false;   // Verifica se é um ambiente de produção (true) ou homologação (false)

            string reproduzido = " {panel:title=*REPRODUZIDO EM:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#ADD8E6|bgColor=#F0FFFF|titleColor=BLACK}" +
                "\n*HOSTNAME:* " 
                                    + tbHostname.Text 
                                    + "\n*PORTA:* "
                                    + tbPorta.Text 
                                    + "\n*DATABASE:* "
                                    + tbDatabase.Text 
                                    + "\n*USUÁRIO:* "
                                    + tbUsuario.Text 
                                    + "\n*SENHA:* "
                                    + tbPassword.Text;

            TextosPadroes textos = new TextosPadroes(caminhos: tbCaminhos.Text, resumo: tbResumo.Text + anexos, funcionamento: tbFuncionamento.Text, reproduzido: reproduzido, passoAPasso: tbPassoAPasso.Text, parecer: tbParecer.Text);

            ticket = new Ticket(cliente, cbArea.Text, tbVersao.Text, cbSO.Text, cbAplicacao.Text, ambienteProducao, tbProblemas.Focus() == true ? TipoTicket.Problema : TipoTicket.Qualidade) ;
            
            Clipboard.SetText(ticket.ToString()+textos);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta ferramenta foi desenvolvida com o intuíto de auxíliar na" +
                " rotina de registrar tickets no Jira, seja na abertura de tickets de" +
                " DEFEITO ou BUG, ou menos no registro de tickets de Implementações" +
                " Testes ou Orientação ao desenvolvedor." +
                "\nCaso identifique problemas, tenha dúvidas ou deseje sugerir melhorias, favor contactar-me no e-mail dione.quevedo@mv.com.br", "Sobre!");
        }
    }
}
