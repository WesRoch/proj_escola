using prjEscola.App_Code.BLL;
using prjEscola.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.BLL
{
    public class Instrutor
    {
        private static string connString = Funcoes.connString;
        public int IdInstrutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public double Valor_Hora { get; set; }
        public string Certificados { get; set; }
        public static DataSet PreencheGridInstrutor()
        {
            string meuSQL = "SELECT * FROM TBINSTRUTOR ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
        public void Inserir()
        {
            string meuSQL = "INSERT INTO TBINSTRUTOR(NOME,EMAIL,VALOR_HORA,CERTIFICADOSI) VALUES " +
                            " ('" + Nome.Trim() + "' ,'" + Email.Trim() + "', " + Valor_Hora.Trim() + ", '" + Certificados.Trim()
                            + "' )";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar(Int32 CODIGO)
        {
            string meuSQL = " UPDATE TBINSTRUTOR SET " +
                            " NOME='" + Nome + "'," +
                            " EMAIL='" + Email + "'," +
                            " VALOR_HORA='" + Valor_Hora + "'" +
                            " CERTIFICADOS='" + Certificados + "'" +
                            " WHERE IDINSTRUTOR = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
        public void Excluir(Int32 CODIGO)
        {
            string meuSQL = "DELETE TBINSTRUTOR WHERE IDINSTRUTOR= " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PesquisaAluno()
        {
            string meuSQL = "SELECT * FROM TBINSTRUTOR ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
        public static DataSet PreencheComboInstrutor()
        {
            string meuSQL = "SELECT * FROM TBINSTRUTOR ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
        public void MostrarDados_Instrutor(Int32 codigo)
        {
            string meuSQL = ("SELECT * FROM TBTURMA WHERE IDTURMA = " + codigo);
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                IdInstrutor = Convert.ToInt32(dr["IDINSTRUTOR"]);
                Nome = Convert.ToString(dr["NOME"]);
                Email = Convert.ToString(dr["EMAIL"]);
                Valor_Hora = Convert.ToDouble(dr["VALOR_HORA"]);
                Certificados = Convert.ToString(dr["CERTIFICADOS"]);
            }
        }
    }
}