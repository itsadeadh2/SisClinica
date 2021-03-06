﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisClinica.DAO;
using System.Data;

namespace SisClinica.Classes
{
    public class Cliente:Pessoa
    {
        //-Propriedades
        public string adicionalInfo { get; set; }
        public Responsavel objResponsavel { get; set; }
        public string situacao { get; set; }
       
        //-Métodos                
        public void Excluir(int id)
        {
            IList<Sessoes> lista = new Sessoes().BuscaPorCliente(this);
            if (lista==null)
            {
                new ClienteDAO().Excluir(this);                
            }
            else
            {
                new ClienteDAO().ExcluirComSessao(this);
            }
        }        
        public Cliente PesquisarPorCpf(string cpf)
        {
            return new ClienteDAO().Pesquisar(cpf);
           
        }
        public DataTable PesquisarPorResponsavel(Responsavel objResponsavel)
        {
            IList<Cliente> lista = new ClienteDAO().PesquisarPorResponsavel(objResponsavel);

            DataTable dt = new DataTable();
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("CPF", typeof(string));
            if (lista!=null)
            {
                foreach (Cliente c in lista)
                {
                    dt.Rows.Add(c.nome, c.cpf);
                }
            }
            else
            {
                dt = null;
            }
            return dt;
        }
        public Cliente PesquisarPorId(int id)
        {
            return new ClienteDAO().Pesquisar(id);
        }
        /// <summary>
        /// Determina se o cliente possui um responsável e caso tenha, vincula-o ao cliente. Caso não tenha, apenas registra o cliente.
        /// </summary>
        public void Registrar()
        {
            if (objResponsavel!=null)
            {
                new ClienteDAO().RegistrarComResponsavel(this);
            }
            else
            {
                new ClienteDAO().Registrar(this);
            }                
        }
        public void Alterar()
        {
            new ClienteDAO().Alterar(this);
        }
        /// <summary>
        /// Retorna uma data table com alguns dados essenciais do cliente.
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <returns> DataTable com: ID, Nome, CPF, Nome Responsavel, CPF Responsavel</returns>
        public IList<Cliente> iListPesquisarPorNome(string nome)
        {
            return new ClienteDAO().PesquisarPorNome(nome);
        }
        public DataTable PesquisarPorNome(string nome)
        {
            IList<Cliente> listadeClientes = new List<Cliente>();
            listadeClientes = new ClienteDAO().PesquisarPorNome(nome);

            DataTable dt = new DataTable();
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("CPF", typeof(string));
            dt.Columns.Add("Nome Responsavel", typeof(string));
            dt.Columns.Add("CPF Responsavel", typeof(string));
            dt.Columns.Add("Id", typeof(int));
            if (listadeClientes!=null)
            {

                foreach (Cliente objCliente in listadeClientes)
                {
                    if (objCliente.objResponsavel != null)
                    {
                        dt.Rows.Add(objCliente.nome, objCliente.cpf, objCliente.objResponsavel.nome, objCliente.objResponsavel.cpf, objCliente.id);
                    }
                    else
                    {
                        dt.Rows.Add(objCliente.nome, objCliente.cpf, "-", "-", objCliente.id);
                    }
                }
            }
            else
            {
                dt = null;
                
            }
            return dt;
        }
    }
}
