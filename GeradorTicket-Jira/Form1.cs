﻿using System;
using System.Windows.Forms;
using System.Globalization;
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

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void descriçãoDeProblemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbProblemas;
            tbProblemas.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            if (tbEscolhas.SelectedTab.Equals(tbProblemas))
            {
                tbCliente.Enabled = true;
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
                                        + " - "
                                        + cbArquitetura.Text
                                        + "{color}* - *Resolução:* {color:blue} *"
                                        + cbResolucao.Text
                                        + "*"
                                        + "\n*Registro de Testes em:*"
                                        + "\n*Observações:* {color: red}*"
                                        + tbObsLiberacao.Text
                                        + "*{color}"
                                        + "\n{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITQualidade))
            {
                string reproduzido = "{panel:title=*Registro de Análise de Qualidade - "
                                        + cbBateriaTesteRIT.Text
                                        + " BATERIA DE TESTES*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}{panel}"
                                        + "{panel:title=*TESTES REALIZADOS EM*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                                        + "*Testes Realizados na Versão:* *{color:#d04437}[VERSÃO{"
                                        + tbVersao.Text
                                        + "}]{color}* de *{color:#d04437}[DATA COMPILAÇÃO{"
                                        + dataVersaoRIT.Text
                                        + "}]{color}* as *{color:#d04437}[HORA COMPILAÇÃO{"
                                        + horaCompilacaoRIT.Text
                                        + "}]{color}*"
                                        + "*Ambiente:* *{color:blue}[SISTEMA OPERACIONAL{"
                                        + cbSO.Text
                                        + " - "
                                        + cbArquitetura.Text
                                        + "}]{color}* - *Resolução:* *{color:blue}[Resolucao{"
                                        + cbResolucao.Text
                                        + "}]{color}* { panel}"
                                        + "{panel:title=*BASE ONDE O PROBLEMA FOI REPRODUZIDO - DBCONF:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                                        + "h2.USUÁRIO: *{color:#0747A6}[USUÁRIO:{"
                                        + tbUsuarioRIT.Text
                                        + "}]{color}* - Senha: *{color:#0747A6}[SENHA:{"
                                        + tbSenhaRIT.Text
                                        + "}]{color}* [COLAR O DBCONF] {panel}"
                                        + "{panel:title=*CARACTERÍSTICAS DO USUÁRIO SE PRECISAR:*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                                        + "Ocorre para todos os usuário ? *{"
                                        + "color:#0747A6}[OCORRE PARA TODOS OS USUÁRIOS]{color}*  -  Tipo de Usuário? *{color:#0747A6}[TIPO DO USUÁRIO É PRESTADOR OU FUNCIONARIO]{color}*  -  ADM no sistema?: *{color:#0747A6}[ADM NO SISTEMA]{color}*"
                                        + "{panel}";
                if (cbRIT01.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT01.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT01.Text
                        + "\n{panel}";
                }

                if (cbRIT02.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT02.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT02.Text
                        + "\n{panel}";
                }

                if (cbRIT03.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT03.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT03.Text
                        + "\n{panel}";
                }

                if (cbRIT04.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT04.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT04.Text
                        + "\n{panel}";
                }

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRAResumido))
            {
                string solicitacao = tbSolicitacaoCliente.Text;
                string justificativa = tbJustificativaCliente.Text;
                string requisitos = tbRequisitosImplementacao.Text;
                string resultado = tbResultadosEsperados.Text;
                string reproduzido = "{panel:title=*REGISTRO DE ANÁLISE - RA RESUMIDO*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#8b3a62|bgColor=#fff0f5|titleColor=white}"
                + "\n*RESUMO DA SOLICITAÇÃO DO CLIENTE:*\n"
                + solicitacao
                + "\n\n*JUSTIFICATIVA DA SOLICITAÇÃO DO CLIENTE:*\n"
                + justificativa
                + "\n\n*REQUISITOS PARA IMPLEMENTAÇÃO:*\n"
                + requisitos
                + "\n\n*RESULTADO:*\n"
                + resultado
                + "\n{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbReview))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbWorkshop))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbGeraDoc))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbOrientacao))
            {
                string orientacao = "{panel:title=INFORMAÇÕES DIVERSAS|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#2E8B57|bgColor=WHITE|titleColor=#c1c7d0}"
                + "\nDescrição: "
                + tbOrientacoes.Text
                + "{panel}";

                Clipboard.SetText(orientacao);
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
                tbCliente.Enabled = true;
                tbCliente.ReadOnly = false;
                tbCliente.Focus();

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
                MessageBox.Show("Desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                        + " - "
                                        + cbArquitetura.Text
                                        + "{color}* - *Resolução:* {color:blue} *"
                                        + cbResolucao.Text
                                        + "*"
                                        + "\n*Registro de Testes em:*"
                                        + "\n*Observações:* {color: red}*"
                                        + tbObsLiberacao.Text
                                        + "*{color}"
                                        + "\n{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRITQualidade))
            {
                string reproduzido = "{panel:title=*Registro de Análise de Qualidade - "
                                        + cbBateriaTesteRIT.Text
                                        + " BATERIA DE TESTES*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}{panel}"
                                        + "{panel:title=*TESTES REALIZADOS EM*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                                        + "*Testes Realizados na Versão:* *{color:#d04437}"
                                        + tbVersao.Text
                                        + "{color}* de *{color:#d04437}"
                                        + dataVersaoRIT.Text
                                        + "{color}* as *{color:#d04437}"
                                        + horaCompilacaoRIT.Text
                                        + "{color}* *Local Testado:* *{color:blue}"
                                        + tbHostnameRIT.Text
                                        + " - "
                                        + tbDatabaseRIT.Text
                                        + " - "
                                        + tbPortaRIT.Text
                                        + "{color}* \n*Usuário:* *{color:blue}"
                                        + tbUsuarioRIT.Text
                                        + "{color}* - *Senha:* *{color:blue}"
                                        + tbSenhaRIT.Text
                                        + "{color}*"
                                        + "\n*Ambiente:* *{color:blue}"
                                        + cbSO.Text
                                        + "{color}* - *Resolução:* *{color:blue}"
                                        + cbResolucao.Text
                                        + "{color}*"
                                        + "{panel}";
                if(cbRIT01.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT01.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT01.Text
                        + "\n{panel}";
                }

                if (cbRIT02.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT02.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT02.Text
                        + "\n{panel}";
                }

                if (cbRIT03.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT03.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT03.Text
                        + "\n{panel}";
                }

                if (cbRIT04.Checked)
                {
                    reproduzido = reproduzido
                        + "\n{panel:title=*RIT - "
                        + tbRIT04.Text
                        + "*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#607B8B|bgColor=#C6E2FF|titleColor=white}"
                        + "*DESCRIÇÃO:* "
                        + textBoxRIT04.Text
                        + "\n{panel}";
                }

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbRAResumido))
            {
                string solicitacao = tbSolicitacaoCliente.Text;
                string justificativa = tbJustificativaCliente.Text;
                string requisitos = tbRequisitosImplementacao.Text;
                string resultado = tbResultadosEsperados.Text;
                string reproduzido = "{panel:title=*REGISTRO DE ANÁLISE - RA RESUMIDO*|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#8b3a62|bgColor=#fff0f5|titleColor=white}"
                + "\n*RESUMO DA SOLICITAÇÃO DO CLIENTE:*\n"
                + solicitacao
                + "\n\n*JUSTIFICATIVA DA SOLICITAÇÃO DO CLIENTE:*\n"
                + justificativa
                + "\n\n*REQUISITOS PARA IMPLEMENTAÇÃO:*\n"
                + requisitos
                + "\n\n*RESULTADO:*\n"
                + resultado
                + "\n{panel}";

                Clipboard.SetText(reproduzido);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbReview))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbWorkshop))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbGeraDoc))
            {
                MessageBox.Show("desculpe os transtornos, porém esta funcionalidade ainda não foi implementada, aguarde novas liberações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbEscolhas.SelectedTab.Equals(tbOrientacao))
            {
                string orientacao = "{panel:title=INFORMAÇÕES DIVERSAS|borderStyle=solid|borderColor=#1c1c1c|titleBGColor=#2E8B57|bgColor=WHITE|titleColor=#c1c7d0}"
                + "\nh2.*Descrição:* "
                + tbOrientacoes.Text
                + "{panel}";

                Clipboard.SetText(orientacao);
            }
        }

        private void limparF10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbCaminhos.Text = tbCliente.Text = tbFuncionamento.Text =  tbParecer.Text = tbPassoAPasso.Text = tbResumo.Text = "";
            rbAnexoSim.Checked = true;
            rbProducao.Checked = true;
            tbPassword.Text = "1";
            tbPorta.Text = "6000";
            tbHostname.Text = "192.168.232.252";
            tbUsuario.Text = "QA.FUNCIONARIO";
            cbAplicacao.Text = "SIGH";
            cbArea.Text = "NÃO INFORMADO";
            tbDatabase.Text = "bd0000";
            tbVersao.Text = "5.79.36";
            tbCliente.Text = "2213";
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
            tbCaminhos.Text = tbCliente.Text = tbFuncionamento.Text = tbParecer.Text = tbPassoAPasso.Text = tbResumo.Text = "";
            rbAnexoSim.Checked = true;
            rbProducao.Checked = true;
            tbPassword.Text = "1";
            tbPorta.Text = "6000";
            tbHostname.Text = "192.168.232.252";
            tbUsuario.Text = "QA.FUNCIONARIO";
            cbAplicacao.Text = "SIGH";
            cbArea.Text = "NÃO INFORMADO";
            tbDatabase.Text = "bd0000";
            tbVersao.Text = "5.79.36";
            tbCliente.Text = "2213";
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
            dataVersaoRIT.Text = DateTime.Now.ToString();
            horaCompilacaoRIT.Text = DateTime.Now.ToLocalTime().ToString();
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

        private void préTesteSemRITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbRITPreteste;
            tbRITPreteste.Focus();
        }

        private void liberaçãoTesteUnitárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = rbTesteUnit;
            rbTesteUnit.Focus();
        }

        private void liberaçãoTesteIngradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbTesteIntegrado;
            tbTesteIntegrado.Focus();
        }

        private void liberaçãoDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
                tbEscolhas.SelectedTab = tbLiberacaoTeste;
                tbLiberacaoTeste.Focus();
        }

        private void rITDeQualidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbRITQualidade;
            tbRITQualidade.Focus();
        }

        private void modeloRAResumidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbRAResumido;
            tbRAResumido.Focus();
        }

        private void reviewRealizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbReview;
            tbReview.Focus();
        }

        private void workShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbWorkshop;
            tbWorkshop.Focus();
        }

        private void sprintDevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbGeraDoc;
            tbGeraDoc.Focus();
        }

        private void orientaçãoDoDesenvolvedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbEscolhas.SelectedTab = tbOrientacao;
            tbOrientacao.Focus();
        }

        private void tbEscolhas_Enter(object sender, EventArgs e)
        {
            dtDataLiberacao.CustomFormat = "dd/MM/yyyy";
            dtDataLiberacao.Text = DateTime.Now.ToString();
            dtHoraLiberacao.CustomFormat = "HH:mm:ss";
            dtHoraLiberacao.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void tbProblemas_Enter(object sender, EventArgs e)
        {
            tbCliente.ReadOnly = false;
            tbCliente.Text = "2213";
            tbCliente.Enabled = true;
        }

        private void btnGeraCPF_Click(object sender, EventArgs e)
        {
            GeradorCPF CPF = new GeradorCPF();
            tbGeraCPF.Text = CPF.GeraCPF();
        }

        private void btnCopiaCPF_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbGeraCPF.Text);
        }

        private void btnGeraCNPJ_Click(object sender, EventArgs e)
        {
            GeradorCNPJ CNPJ = new GeradorCNPJ();
            tbGeraCNPJ.Text = CNPJ.GeraCNPJ();
        }

        private void btnCopiaCNPJ_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbGeraCNPJ.Text);
        }

        private void btnGeraCNS_Click(object sender, EventArgs e)
        {
            GeradorCNS CNS = new GeradorCNS();
            tbGeraCNS.Text = CNS.GeraCNS();
            Clipboard.SetText(tbGeraCNS.Text);
        }
    }
}
