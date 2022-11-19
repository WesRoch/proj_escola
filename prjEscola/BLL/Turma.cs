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
        public int IdInstrutor { get; set; }
        public int IdCurso { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_fim { get; set; }
        public int Carga_horaria { get; set; }
        public string nome_turma { get; set; }

        public void Inserir()
        {
            string meuSQL = "INSERT INTO TBTURMA(DATA_INICIO, DATA_FIM,CARGA_HORARIA,IDINSTRUTOR,IDCURSO,NOME_TURMA) VALUES " +
                            "('" + Data_inicio + "' ,'" + Data_fim + "', " + Carga_horaria + ", " + IdInstrutor
                            + ", " + IdCurso + ",'" + nome_turma.Trim() + "', )";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }

        public void Alterar(Int32 CODIGO)
        {
            string meuSQL = " UPDATE TBTURMA SET " +
                            " DATA_INICIO='" + Data_inicio + "'," +
                            " DATA_FIM='" + Data_fim + "'," +
                            " CARGA_HORARIA=" + Carga_horaria + "," +
                            " IDINSTRUTOR=" + IdInstrutor + "," +
                            " IDCURSO=" + IdCurso + "," +
                            " NOME_TURMA='" + nome_turma + "'," +
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
    }
}