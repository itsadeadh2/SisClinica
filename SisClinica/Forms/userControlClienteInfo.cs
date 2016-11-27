﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisClinica.Classes;

namespace SisClinica.Forms
{
    public partial class userControlClienteInfo : UserControl
    {
        public userControlClienteInfo()
        {
            InitializeComponent();
            linkLblNomeResp.Enabled = false;
        }

        Cliente objCliente;

        public userControlClienteInfo PreencheFormulario(Cliente objCli)
        {
            userControlClienteInfo uc = new userControlClienteInfo();
            uc.objCliente = new Cliente().PesquisarPorId(objCli.id);
            uc.lblNome.Text = uc.objCliente.nome;
            uc.lblCPF.Text = uc.objCliente.cpf;
            uc.lblDataNasc.Text = uc.objCliente.dataNascimento.Date.ToString("dd/MM/yyyy");
            uc.lblEndereco.Text = uc.objCliente.endereco;
            uc.lblEstado.Text = uc.objCliente.estado;
            uc.lblCidade.Text = uc.objCliente.cidade;
            uc.lblEmail.Text = uc.objCliente.email;
            uc.lblTelefone.Text = uc.objCliente.telefone;
            uc.rtbAdicionalInfo.Text = uc.objCliente.adicionalInfo;
            uc.dtgSessoes.DataSource = new Sessoes().DataTableBuscaPorCliente(uc.objCliente);
            if (uc.objCliente.objResponsavel!=null)
            {
                uc.linkLblNomeResp.Text = uc.objCliente.objResponsavel.nome;
                uc.linkLblNomeResp.Enabled = true;
            }
            

            return uc;
        }

        private void dtgSessoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (new Sessoes().BuscaPorId(Convert.ToInt32(dtgSessoes.CurrentRow.Cells["id"].Value)).tipoDeSessao == "Consulta")
                {
                    Controls.Clear();
                    userControlAlterarSessoes alterCon = new userControlAlterarSessoes().Preencher(new Sessoes().BuscaPorId(Convert.ToInt32(dtgSessoes.CurrentRow.Cells["id"].Value)));
                    Controls.Add(alterCon);
                    alterCon.Show();
                }
                else
                {

                }
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Controls.Clear();
            userControlResponsavelInfo ucResp = new userControlResponsavelInfo().Preencher(objCliente.objResponsavel);
            Controls.Add(ucResp);
            ucResp.Show();
        }
    }
}
