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
        public static DataSet PreencheGridInstrutor()
        {
            string meuSQL = "SELECT * FROM TBINSTRUTOR ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;
        }
    }
}