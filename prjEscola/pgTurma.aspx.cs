using prjEscola.App_Code.BLL;
using prjEscola.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjEscola
{
    public partial class pgTurma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheGridCurso();
                PreencheGridInstrutor();
            }
        }
        protected void cboCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void PreencheGridCurso()
        {
            cboCurso.DataTextField = "nome";
            cboCurso.DataValueField = "idCurso";
            cboCurso.DataSource = Curso.PreencheGridCurso();
            cboCurso.DataBind();
        }
        void PreencheGridInstrutor()
        {
            cboInstrutor.DataTextField = "nome";
            cboInstrutor.DataValueField = "idInstrutor";
            cboInstrutor.DataSource = Instrutor.PreencheGridInstrutor();
            cboInstrutor.DataBind();
        }
        private void AdicionarTurma()
        {
            Turma turma = new Turma();
            turma.Data_inicio = Convert.ToDateTime(txtDataInicio.Text);
            turma.Data_fim = Convert.ToDateTime(txtDataFim.Text);
            turma.Carga_horaria = Convert.ToInt32(txtCargaHoraria.Text);
            turma.IdCurso = Convert.ToInt32(cboCurso.SelectedItem.Value);
            turma.IdInstrutor = Convert.ToInt32(cboCurso.SelectedItem.Value);
            turma.nome_turma = Convert.ToString(txtNomeTurma.Text);

            if (cmdConfirmar.Text == "Incluir")
            {
                turma.Inserir();
            }
            else
            {
                //turma Alterar()
            }
        }
        protected void cmdConfirmar_Click(object sender, EventArgs e)
        {
            AdicionarTurma();
        }
    }
}