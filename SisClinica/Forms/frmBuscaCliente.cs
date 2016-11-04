﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisClinica.Classes;
using System.Windows.Forms;

namespace SisClinica.Forms
{
    public partial class frmBuscaCliente : Form
    {
        public frmBuscaCliente()
        {
            InitializeComponent();
        }
        public Cliente objCliente { get; set; }
        //- Declaração da lista que irá conter os registros dos clientes
        private IList<Cliente> listaDeClientes = new List<Cliente>();


        //- Métodos
        /// <summary>
        /// Define Automaticamente qual deverá ser o critério utilizado na busca dos clientes
        /// </summary>
        
        /// <summary>
        /// Ativa automaticamente os campos necessários para as buscas e as suas respectivas regras.
        /// </summary>
        
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                dtgClientesBuscarCliente.DataSource = new Cliente().PesquisarPorNome(txtBoxNomeClienteBuscarCliente.Text);    
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }     

        private void dtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.objCliente = new Cliente().PesquisarPorId(Convert.ToInt32(dtgClientesBuscarCliente.CurrentRow.Cells["Id"].Value));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
