using prjEscola.App_Code.BLL;
using prjEscola.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace prjEscola.App_Code.BLL
{
    public class Alunos
    {
        private static string connString = Funcoes.connString;
        private Int32 idAluno = 0;
        private string cpf = "";
        private string nome = "";
        private string email = "";
        private string telefone = "";
        private DateTime data_nascimento = DateTime.Now;
        private string nome_mae = "";
        private string nome_pai = "";

        public int IDALUNO { get => idAluno; set => idAluno = value; }
        public string CPF { get => cpf; set => cpf = value; }
        public string NOME { get => nome; set => nome = value; }
        public string EMAIL { get => email; set => email = value; }
        public string TELEFONE { get => telefone; set => telefone = value; }
        public DateTime DATA_NASCIMENTO { get => data_nascimento; set => data_nascimento = value; }
        public string NOME_MAE { get => nome_mae; set => nome_mae = value; }
        public string NOME_PAI { get => nome_pai; set => nome_pai = value; }

        public void Inserir()
        {
            string meuSQL = "INSERT INTO TBALUNO(CPF, NOME,EMAIL,TELEFONE,DATA_NASCIMENTO,NOME_MAE,NOME_PAI) VALUES " +
                            " ('" + cpf.Trim() + "' ,'" + nome.Trim() + "', '" + email.Trim() + "', '" + telefone.Trim() 
                            + "', '" + data_nascimento + "','" + nome_mae.Trim() + "', '" + nome_pai.Trim() + "' )";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar(Int32 CODIGO)
        {
            string meuSQL = " UPDATE TBALUNO SET " +
                            " CPF='" + cpf + "'," +
                            " NOME='" + nome + "'," +
                            " EMAIL='" + email + "'," +
                            " TELEFONE='" + telefone + "'," +
                            " DATA_NASCIMENTO='" + data_nascimento + "'," +
                            " NOME_MAE='" + nome_mae + "'," +
                            " NOME_PAI='" + nome_pai + "'" +
                            " WHERE IDALUNO = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Excluir(Int32 CODIGO)
        {
            string meuSQL = "DELETE ALUNOS WHERE IDALUNO= " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PesquisaAluno()
        {
            string meuSQL = "SELECT * FROM ALUNO ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }


        public static DataSet PreencheGridAluno()
        {
            string meuSQL = "SELECT IDALUNO, NOME,CPF, EMAIL FROM TBALUNO ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public void MostrarDados_Aluno(Int32 codigo)
        {
            string meuSQL = ("SELECT * from TBALUNO WHERE IDALUNO = " + codigo);
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                idAluno = Convert.ToInt32(dr["IDALUNO"]);
                nome = Convert.ToString(dr["NOME"]);
                cpf = Convert.ToString(dr["CPF"]);
                email = Convert.ToString(dr["EMAIL"]);
                data_nascimento = Convert.ToDateTime(dr["DATA_NASCIMENTO"]);
                nome_mae = Convert.ToString(dr["NOME_MAE"]);
                nome_pai = Convert.ToString(dr["NOME_PAI"]);
                telefone = Convert.ToString(dr["TELEFONE"]);
            }

        }

        internal void MostrarDados_Aluno()
        {
            throw new NotImplementedException();
        }
    }
}