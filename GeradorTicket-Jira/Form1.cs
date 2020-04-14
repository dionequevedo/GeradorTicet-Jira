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
            if (tbEscolhas.SelectedTab.Equals(tbProblemas))
            {
                tbCliente.ReadOnly = false;

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

                ticket = new Ticket(cliente, cbArea.Text, tbVersao.Text, cbSO.Text, cbAplicacao.Text, ambienteProducao, tbProblemas.Focus() == true ? TipoTicket.Problema : TipoTicket.Qualidade);

                Clipboard.SetText(ticket.ToString() + textos);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITPreteste))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(rbTesteUnit))
            {
                tbCliente.ReadOnly = true;


                string reproduzido = "{panel:title=*TESTE UNITÁRIO REALIZADO PELO SETOR DE QUALIDADE*|borderStyle=solid|borderColor=#0000FF|titleBGColor=#EE7600|bgColor=#ee7600}"
                                        + "\n*Testes Realizados na Versão:* *{color:#0000FF}"
                                        + tbVersao.Text
                                        + "{color}* *Local Testado:* *{color:#0000FF}"
                                        + tbHostnameUnitario.Text
                                        + " - "
                                        + tbDatabaseUnitario.Text
                                        + " - "
                                        + tbPortaUnitario.Text
                                        + "{color}* - *Usuário:* *{color:#0000FF}"
                                        + tbUsuarioUnitario.Text
                                        + "{color}* - *Senha:* *{color:#0000FF}"
                                        + tbSenhaUnitario.Text
                                        + "{color}* \n*Registro de Testes em:*\n*Observações:**{color:#0000FF} TICKET BLOQUEADO, AGUARDANDO TESTE DE INTEGRAÇÃO!{color}*"
                                        + "{panel}";
  


                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbTesteIntegrado))
            {
                tbCliente.ReadOnly = true;


                string reproduzido = "{panel:title=*TESTE INTEGRADO REALIZADO PELO SETOR DE QUALIDADE*|borderStyle=solid|borderColor=#0000FF|titleBGColor=#eec900|bgColor=#eec900}"
                                        + "\n*Testes Realizados na Versão:* *{color:#0000FF}"
                                        + tbVersao.Text
                                        + "{color}* *Local Testado:* *{color:#0000FF}"
                                        + tbHostnameIntegrado.Text
                                        + " - "
                                        + tbDatabaseIntegrado.Text
                                        + " - "
                                        + tbPortaIntegrado.Text
                                        + "{color}* - *Usuário:* *{color:#0000FF}"
                                        + tbUsuarioIntegrado.Text
                                        + "{color}* - *Senha:* *{color:#0000FF}"
                                        + tbSenhaIntegrado.Text
                                        + "{color}* \n*Registro de Testes em:*\n*Observações:**{color:#0000FF} TICKET BLOQUEADO, AGUARDANDO HOMOLOGAÇÃO!{color}*"
                                        + "{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbLiberacaoTeste))
            {
                tbCliente.ReadOnly = true;


                string reproduzido = "{panel:title=*TESTES REALIZADOS PELO SETOR DE QUALIDADE*|borderStyle=solid|borderColor=#43cd80|titleBGColor=#9AFF9A|bgColor=#43cd80}"
                                        + "\n*SOLICITAÇÃO ATENDIDA*"
                                        + "\n *Testes Realizados na Versão:* *{color:#d04437}"
                                        + tbVersao.Text
                                        + "{color}* de *{color:#d04437}"
                                        + dtDataLiberacao.Text
                                        + "{color}* as *{color:#d04437}"
                                        + dtHoraLiberacao.Text
                                        + "{color}*"
                                        + " *Local Testado:* *{color: blue}"
                                        + tbHostnameLiberacao.Text
                                        + " - "
                                        + tbDatabaseLiberacao.Text
                                        + " - "
                                        + tbPortaLiberacao.Text
                                        + "{color}* - *Usuário:* *{color:blue}"
                                        + tbUsuarioLiberacao.Text
                                        + "{color}* - *Senha:* *{color:blue}"
                                        + tbSenhaLiberacao.Text
                                        + "{color}* - *Ambiente:* *{color:blue}"
                                        + cbSO.Text
                                        + "{color}* - *Resolução:* {color:blue} *1366 x 768*"
                                        + "\n*Registro de Testes em:*"
                                        + "\n*Observações:* {color: red}*"
                                        + tbObsLiberacao.Text
                                        + "*{color}"
                                        + "\n{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITQualidade))
            {
                string reproduzido = "{panel:title=*Registro de Análise de Qualidade - 1º BATERIA DE TESTES*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}{panel}"
                                        + "{ panel: title = *TESTES REALIZADOS EM*| borderStyle = solid | borderColor =#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                                        + "*Testes Realizados na Versão: **{color:#d04437}"
                                        + tbVersao.Text
                                        + "{color}* *Local Testado:* *{color:#0000FF}"
                                        + tbHostname.Text
                                        + " - "
                                        + tbDatabase.Text
                                        + " - "
                                        + tbPorta.Text
                                        + "{color}* - *Usuário:* *{color:#0000FF}"
                                        + tbUsuario.Text
                                        + "{color}* - *Senha:* *{color:#0000FF}"
                                        + tbPassword.Text
                                        + "{color}* \n*Registro de Testes em:*\n*Observações:**{color:#0000FF} TICKET BLOQUEADO, AGUARDANDO HOMOLOGAÇÃO!{color}*"
                                        + "{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRAResumido))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbReview))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbWorkshop))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbSprint))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbOrientacao))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta ferramenta foi desenvolvida com o intuíto de auxíliar na" +
                " rotina de registrar tickets no Jira, seja na abertura de tickets de" +
                " DEFEITO ou BUG, ou mesmo no registro de tickets de Implementações, " +
                " Testes ou Orientação ao desenvolvedor." +
                "\nCaso identifique problemas, tenha dúvidas ou deseje sugerir melhorias, favor contactar-me no e-mail dione.quevedo@mv.com.br", "Sobre!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void copiarF11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbEscolhas.SelectedTab.Equals(tbProblemas))
            {
                tbCliente.ReadOnly = false;

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

                ticket = new Ticket(cliente, cbArea.Text, tbVersao.Text, cbSO.Text, cbAplicacao.Text, ambienteProducao, tbProblemas.Focus() == true ? TipoTicket.Problema : TipoTicket.Qualidade);

                Clipboard.SetText(ticket.ToString() + textos);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITPreteste))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(rbTesteUnit))
            {
                tbCliente.ReadOnly = true;


                string reproduzido = "{panel:title=*TESTE UNITÁRIO REALIZADO PELO SETOR DE QUALIDADE*|borderStyle=solid|borderColor=#0000FF|titleBGColor=#EE7600|bgColor=#ee7600}"
                                        + "\n*Testes Realizados na Versão:* *{color:#0000FF}"
                                        + tbVersao.Text
                                        + "{color}* *Local Testado:* *{color:#0000FF}"
                                        + tbHostnameUnitario.Text
                                        + " - "
                                        + tbDatabaseUnitario.Text
                                        + " - "
                                        + tbPortaUnitario.Text
                                        + "{color}* - *Usuário:* *{color:#0000FF}"
                                        + tbUsuarioUnitario.Text
                                        + "{color}* - *Senha:* *{color:#0000FF}"
                                        + tbSenhaUnitario.Text
                                        + "{color}* \n*Registro de Testes em:*\n*Observações:**{color:#0000FF} TICKET BLOQUEADO, AGUARDANDO TESTE DE INTEGRAÇÃO!{color}*"
                                        + "{panel}";



                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbTesteIntegrado))
            {
                int cliente = int.Parse(tbCliente.Text);        //Armazena o código do cliente


                string reproduzido = "{panel:title=*TESTE INTEGRADO REALIZADO PELO SETOR DE QUALIDADE*|borderStyle=solid|borderColor=#0000FF|titleBGColor=#eec900|bgColor=#eec900}"
                                        + "\n*Testes Realizados na Versão:* *{color:#0000FF}"
                                        + tbVersao.Text
                                        + "{color}* *Local Testado:* *{color:#0000FF}"
                                        + tbHostnameIntegrado.Text
                                        + " - "
                                        + tbDatabaseIntegrado.Text
                                        + " - "
                                        + tbPortaIntegrado.Text
                                        + "{color}* - *Usuário:* *{color:#0000FF}"
                                        + tbUsuarioIntegrado.Text
                                        + "{color}* - *Senha:* *{color:#0000FF}"
                                        + tbSenhaIntegrado.Text
                                        + "{color}* \n*Registro de Testes em:*\n*Observações:**{color:#0000FF} TICKET BLOQUEADO, AGUARDANDO HOMOLOGAÇÃO!{color}*"
                                        + "{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbLiberacaoTeste))
            {
                tbCliente.ReadOnly = true;


                string reproduzido = "{panel:title=*TESTES REALIZADOS PELO SETOR DE QUALIDADE*|borderStyle=solid|borderColor=#43cd80|titleBGColor=#9AFF9A|bgColor=#43cd80}"
                                        + "\n*SOLICITAÇÃO ATENDIDA*"
                                        + "\n *Testes Realizados na Versão:* *{color:#d04437}"
                                        + tbVersao.Text
                                        + "{color}* de *{color:#d04437}"
                                        + dtDataLiberacao.Text
                                        + "{color}* as *{color:#d04437}"
                                        + dtHoraLiberacao.Text
                                        + "{color}*"
                                        + " *Local Testado:* *{color: blue}"
                                        + tbHostnameLiberacao.Text
                                        + " - "
                                        + tbDatabaseLiberacao.Text
                                        + " - "
                                        + tbPortaLiberacao.Text
                                        + "{color}* - *Usuário:* *{color:blue}"
                                        + tbUsuarioLiberacao.Text
                                        + "{color}* - *Senha:* *{color:blue}"
                                        + tbSenhaLiberacao.Text
                                        + "{color}* - *Ambiente:* *{color:blue}"
                                        + cbSO.Text
                                        + "{color}* - *Resolução:* {color:blue} *1366 x 768*"
                                        + "\n*Registro de Testes em:*"
                                        + "\n*Observações:* {color: red}*"
                                        + tbObsLiberacao.Text
                                        + "*{color}"
                                        + "\n{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITQualidade))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRAResumido))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbReview))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbWorkshop))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbSprint))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbOrientacao))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limparF10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbCaminhos.Text = tbCliente.Text = tbFuncionamento.Text = tbOrientacao.Text = tbParecer.Text = tbPassoAPasso.Text = tbResumo.Text = "";
            rbAnexoSim.Checked = true;
            rbProducao.Checked = true;
            tbPassword.Text = "1";
            tbPorta.Text = "5430";
            tbHostname.Text = "192.168.0.0";
            tbUsuario.Text = "QA.FUNCIONARIO";
            cbAplicacao.Text = "SIGH";
            cbArea.Text = "NÃO INFORMADO";
            tbDatabase.Text = "bd0000";
            tbVersao.Text = "5.74.00";
            tbCliente.Text = "0000";
            tbPassword.Text = "1";
            if (tbCliente.ReadOnly == false)
            {
                tbCliente.Focus();
            }
            else
            {
                tbVersao.Focus();
            }
            
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            tbCaminhos.Text = tbCliente.Text = tbFuncionamento.Text = tbOrientacao.Text = tbParecer.Text = tbPassoAPasso.Text = tbResumo.Text = "";
            rbAnexoSim.Checked = true;
            rbProducao.Checked = true;
            tbPassword.Text = "1";
            tbPorta.Text = "5430";
            tbHostname.Text = "192.168.0.0";
            tbUsuario.Text = "QA.FUNCIONARIO";
            cbAplicacao.Text = "SIGH";
            cbArea.Text = "NÃO INFORMADO";
            tbDatabase.Text = "bd0000";
            tbVersao.Text = "5.74.00";
            tbCliente.Text = "0000";
            tbPassword.Text = "1";
            if (tbCliente.ReadOnly == false)
            {
                tbCliente.Focus();
            }
            else
            {
                tbVersao.Focus();
            }
        }

        private void tbRITQualidade_Enter(object sender, EventArgs e)
        {
            dataVersao.Text = DateTime.Now.ToString();
            horaCompilacao.Text = DateTime.Now.ToLocalTime().ToString();
            cbRIT01.Checked = true;
            tbRIT01.Enabled = true;
            textBoxRIT01.Enabled = true;
            tbCliente.Enabled = false;
            tbCliente.ReadOnly = true;
        }

        private void cbRIT01_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRIT01.Checked) {
                cbRIT01.Checked = true;
                tbRIT01.Enabled = true;
                textBoxRIT01.Enabled = true;
            }else
            {
                cbRIT01.Checked = false;
                tbRIT01.Enabled = false;
                textBoxRIT01.Enabled = false;
            }
        }

        private void cbRIT02_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRIT02.Checked)
            {
                cbRIT02.Checked = true;
                tbRIT02.Enabled = true;
                textBoxRIT02.Enabled = true;
            }
            else
            {
                cbRIT02.Checked = false;
                tbRIT02.Enabled = false;
                textBoxRIT02.Enabled = false;
            }
        }

        private void cbRIT03_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRIT03.Checked)
            {
                cbRIT03.Checked = true;
                tbRIT03.Enabled = true;
                textBoxRIT03.Enabled = true;
            }
            else
            {
                cbRIT03.Checked = false;
                tbRIT03.Enabled = false;
                textBoxRIT03.Enabled = false;
            }
        }

        private void cbRIT04_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRIT04.Checked)
            {
                cbRIT04.Checked = true;
                tbRIT04.Enabled = true;
                textBoxRIT04.Enabled = true;
            }
            else
            {
                cbRIT04.Checked = false;
                tbRIT04.Enabled = false;
                textBoxRIT04.Enabled = false;
            }
        }

        private void tbRIT01_DoubleClick(object sender, EventArgs e)
        {
            int valor_atual = int.Parse(tbRIT01.Text);
            valor_atual += 1;
            tbRIT01.Text = valor_atual.ToString();
        }

        private void tbRIT02_DoubleClick(object sender, EventArgs e)
        {
            int valor_atual = int.Parse(tbRIT02.Text);
            valor_atual += 1;
            tbRIT02.Text = valor_atual.ToString();
        }

        private void tbRIT03_DoubleClick(object sender, EventArgs e)
        {
            int valor_atual = int.Parse(tbRIT03.Text);
            valor_atual += 1;
            tbRIT03.Text = valor_atual.ToString();
        }

        private void tbRIT04_DoubleClick(object sender, EventArgs e)
        {
            int valor_atual = int.Parse(tbRIT04.Text);
            valor_atual += 1;
            tbRIT04.Text = valor_atual.ToString();
        }

        private void tbRIT01_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                int valor_atual = int.Parse(tbRIT01.Text);
                valor_atual = Math.Abs(valor_atual);
                if (valor_atual >= 2)
                {
                    valor_atual -= 1;
                    tbRIT01.Text = valor_atual.ToString();
                }
                else
                {
                    MessageBox.Show("Não é possível reduzir o valor deste campo para menos de 1!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }    
        }
    }
}
