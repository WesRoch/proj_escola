using prjEscola.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEscola.App_Code.BLL
{
    public class Turma
    {
        private static string connString = Funcoes.connString;
        public int IdTurma { get; set; }
        public int IdInstrutor { get; set; }
        public int IdCurso { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }
        public int Carga_horaria { get; set; }
        public string nome_turma { get; set; }

        public void Inserir()
        {
            string meuSQL = "INSERT INTO TBTURMA(DATA_INICIO, DATA_FIM,CARGA_HORARIA," +
                "IDINSTRUTOR,IDCURSO,NOME_TURMA) VALUES " +
                            "('" + Data_inicio + "' ,'" + Data_fim + "', " + Carga_horaria + ", " + IdInstrutor
                            + ", " + IdCurso + ",'" + nome_turma.Trim() + "', )";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar(Int32 CODIGO)
        {
            string meuSQL = " UPDATE TBTURMA SET " +
                            " DATA_INICIO='" + Data_inicio + "', " +
                            " DATA_FIM='" + Data_fim + "' ," +
                            " CARGA_HORARIA=" + Carga_horaria + ", " +
                            " IDINSTRUTOR=" + IdInstrutor + ", " +
                            " IDCURSO=" + IdCurso + ", " +
                            " NOME_TURMA='" + nome_turma + "', " +
                            " WHERE IDTURMA = " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Excluir(Int32 CODIGO)
        {
            string meuSQL = "DELETE TBTURMA WHERE IDTURMA= " + CODIGO;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public static DataSet PreencheGridTurma()
        {
            string meuSQL = "SELECT T.idTurma, T.idInstrutor, T.idCurso, C.nome as nome_curso, I.nome as nome_instrutor\r\n" + 
                "FROM tbCurso C\r\nINNER JOIN tbTurma T\r\nON C.idCurso = T.idCurso\r\n" +
                "INNER JOIN tbInstrutor I\r\nON T.idInstrutor = I.idInstrutor ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }

        public void MostrarDados_Turma(Int32 codigo)
        {
            string meuSQL = ("SELECT * FROM TBTURMA WHERE IDTURMA = " + codigo);
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                IdTurma = Convert.ToInt32(dr["IDTURMA"]);
                IdInstrutor = Convert.ToInt32(dr["IDINSTRUTOR"]);
                IdCurso = Convert.ToInt32(dr["IDCURSO"]);
                nome_turma = Convert.ToString(dr["NOME_TURMA"]);
                Data_inicio = Convert.ToDateTime(dr["DATA_INICIO"]);
                Data_fim = Convert.ToDateTime(dr["DATA_FIM"]);
                Carga_horaria = Convert.ToInt32(dr["CARGA_HORARIA"]);
            }
        }
    }
}