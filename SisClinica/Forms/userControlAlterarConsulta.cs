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
    public partial class userControlAlterarConsulta : UserControl
    {
        public userControlAlterarConsulta()
        {
            InitializeComponent();
        }

        private Cliente objCliente;
        private Sessoes objSessao = new Sessoes();
        private Sessoes objSessaoSalvar;
        private Consultorio objConsultorio;
        private Medico objMedico;
        private string turno;
        private bool editable = false;
        private void AtivaDesativaControles()
        {
            editable = !editable;
            btnAlterar.Enabled = !btnAlterar.Enabled;
            btnSalvar.Visible = !btnSalvar.Visible;
            btnCancelar.Visible = !btnCancelar.Visible;
            gbPesquisa.Visible = !gbPesquisa.Visible;
            dtpData.Enabled = !dtpData.Enabled;
            cbMedicos.Enabled = !cbMedicos.Enabled;
            cbConsultorios.Enabled = !cbConsultorios.Enabled;
            rdbManha.Enabled = !rdbManha.Enabled;
            rdbTarde.Enabled = !rdbTarde.Enabled;
            cbHorarioFinal.Enabled = !cbHorarioFinal.Enabled;
            cbHorarioInicial.Enabled = !cbHorarioInicial.Enabled;
            btnExcluir.Visible = !btnExcluir.Visible;
        }        
        public userControlAlterarConsulta Preencher(Sessoes objSess)
        {
            userControlAlterarConsulta uc = new userControlAlterarConsulta();
            uc.lblTipoSessao.Text = objSess.tipoDeSessao;
            uc.lblSituacao.Text = objSess.situacao;
            uc.txtbNomeCliente.Text = objSess.objCliente.nome;
            uc.dtpData.Value = objSess.dataSessao;
            uc.cbMedicos.Text = objSess.medicoResponsavel.nome;
            uc.cbConsultorios.Text = objSess.objConsultorio.nomeConsultorio;
            if (objSess.horaFim.TimeOfDay<=Convert.ToDateTime("12:00").TimeOfDay)
            {
                rdbManha.Checked = true;
            }
            else
            {
                rdbTarde.Checked = true;
            }
            uc.cbHorarioInicial.Text = objSess.horaInicio.TimeOfDay.ToString(); 
            uc.cbHorarioFinal.Text = objSess.horaFim.TimeOfDay.ToString();
            uc.objSessao = objSess;
            return uc;
        }

        private void ChecaTurno()
        {
            if (rdbManha.Checked)
            {
                turno = "Manhã";
            }
            else
            {
                turno = "Tarde";
            }
            if (objMedico == null || objConsultorio == null)
            {

            }
            else
            {
                SetHora();
            }

        }
        private void SetHora()
        {
            cbHorarioInicial.DataSource = new Sessoes().GerarListaDeHorariosIniciais(dtpData.Value, new Medico().Pesquisar(Convert.ToInt32(cbMedicos.SelectedValue)), new Consultorio().Pesquisar(Convert.ToInt32(cbConsultorios.SelectedValue)), turno,objSessao);
        }
        private void SetConsultorio()
        {
            if (objMedico == null)
            {
                objConsultorio = new Consultorio().Pesquisar(Convert.ToInt32(cbConsultorios.SelectedValue));                
            }
            else
            {
                objConsultorio = new Consultorio().Pesquisar(Convert.ToInt32(cbConsultorios.SelectedValue));               
            }
        }
        private void SetMedico()
        {
            if (objConsultorio == null)
            {
                objMedico = new Medico().Pesquisar(Convert.ToInt32(cbMedicos.SelectedValue));
                
            }
            else
            {
                objMedico = new Medico().Pesquisar(Convert.ToInt32(cbMedicos.SelectedValue));                
                SetHora();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ChecaTurno();
            cbConsultorios.DataSource = new Consultorio().Pesquisar();
            cbMedicos.DataSource = new Medico().Pesquisar();
            SetConsultorio();
            SetMedico();
            SetHora();
            cbConsultorios.SelectedIndex = cbConsultorios.FindString(objSessao.objConsultorio.nomeConsultorio);
            cbMedicos.SelectedIndex = cbMedicos.FindString(objSessao.medicoResponsavel.nome);
            cbHorarioInicial.SelectedIndex = cbHorarioInicial.FindString(objSessao.horaInicio.TimeOfDay.ToString());
            cbHorarioFinal.SelectedIndex = cbHorarioFinal.FindString(objSessao.horaFim.TimeOfDay.ToString());
            AtivaDesativaControles();
            objSessaoSalvar = objSessao; 
        }

        private void cbHorarioInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHorarioFinal.DataSource = new Sessoes().GerarListaDeHorariosFinais(objSessao.medicoResponsavel, objSessao.objConsultorio, Convert.ToDateTime(cbHorarioInicial.SelectedValue), turno, objSessao);
        }

        private void btnDtgPesq_Click(object sender, EventArgs e)
        {
            dtgClientes.DataSource = new Cliente().PesquisarPorNome(txtbNomePesquisa.Text);
        }

        private void dtgClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            objSessaoSalvar.objCliente = new Cliente().PesquisarPorId(Convert.ToInt32(dtgClientes.CurrentRow.Cells["id"].Value));
            txtbNomeCliente.Text = objSessaoSalvar.objCliente.nome;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (editable==true)
            {
                ChecaTurno();
                objSessaoSalvar.dataSessao = dtpData.Value;
                objSessaoSalvar.medicoResponsavel = new Medico().Pesquisar(Convert.ToInt32(cbMedicos.SelectedValue));
                objSessaoSalvar.objConsultorio = new Consultorio().Pesquisar(Convert.ToInt32(cbConsultorios.SelectedValue));
                objSessaoSalvar.horaFim = Convert.ToDateTime(cbHorarioFinal.SelectedValue);
                objSessaoSalvar.horaInicio = Convert.ToDateTime(cbHorarioInicial.SelectedValue);
                objSessao = objSessaoSalvar;
                objSessao.AlterarSessao();
                MessageBox.Show("Sessão alterada!");
                AtivaDesativaControles();
            }                        
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            if (editable==true)
            {
                ChecaTurno();
                SetHora();
            }
        }

        private void cbMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editable==true)
            {
                SetHora();
            }
        }

        private void cbConsultorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editable==true)
            {
                SetHora();
            }
        }

        private void rdbManha_CheckedChanged(object sender, EventArgs e)
        {
            if (editable==true)
            {
                ChecaTurno();
                SetHora();
            }
        }

        private void rdbTarde_CheckedChanged(object sender, EventArgs e)
        {
            if (editable==true)
            {
                ChecaTurno();
                SetHora();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            userControlAlterarConsulta alterCon = new userControlAlterarConsulta().Preencher(objSessao);
            Controls.Clear();
            Controls.Add(alterCon);            
            alterCon.Show();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            objSessao.Excluir();
            MessageBox.Show("Sessão excluída!");
            Controls.Clear();
            UserControl pesqSessoes = new userControlPesquisarSessoes();
            Controls.Add(pesqSessoes);
            pesqSessoes.Show();

            //Controls.Clear();
            //userControlPesquisarSessoes pesqSess = new userControlPesquisarSessoes();
            //Controls.Add(pesqSess);
            //pesqSess.Show();
        }
    }
}
