using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;

using System.Text;
using System.Data.SqlClient;
using System.IO;
using prjEscola.App_Code.BLL;
////Este item tem sempre que ser atualizado par o nome do pimporojeto original
namespace prjEscola.App_Code.BLL
{

    public class Funcoes
    {
        private static string _connString = "Initial Catalog=BDESCOLA;Data Source=AN0101625NS20Y9\\SQLEXPRESS2019;user id=userbdEscola;password=senha;";
        
        public static string connString
        {
            get { return _connString; }

            set { }
        }
        public static string DateToDB(System.DateTime TheDate)
        {
            //Return TheDate.Month.ToString() + "/" + TheDate.Day.ToString() + "/" + TheDate.Year.ToString() + " " + TheDate.ToLongTimeString()
            return TheDate.Year.ToString() + "/" + TheDate.Month.ToString() + "/" + TheDate.Day.ToString() + " " + TheDate.ToLongTimeString();
        }
       

    }


}
