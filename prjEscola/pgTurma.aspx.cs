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
                PreencherGridTurma();
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
                turma.IdTurma = Convert.ToInt32(gvTurmas.DataKeys[gvTurmas.SelectedIndex].Values[0]);
                turma.Alterar(turma.IdTurma);
            }
            LimparCampos();
        }

        void LimparCampos()
        {
            cboCurso.SelectedIndex = 0;
            cboInstrutor.SelectedIndex = 0;
            txtNomeTurma.Text = "";
            txtDataFim.Text = "";
            txtDataInicio.Text = "";
            txtCargaHoraria.Text = "";
            cmdConfirmar.Text = "Incluir";
            Formatar_Grid();
        }

        void MostrarDados(Int32 cod_turma)
        {
            Turma turma = new Turma();
            turma.MostrarDados_Turma(cod_turma);
            // codigo_aluno = aluno.Id_aluno; //variavel que recebe o id_aluno
            cboCurso.SelectedValue = Convert.ToString(turma.IdTurma);
            cboInstrutor.SelectedValue = Convert.ToString(turma.IdInstrutor);
            txtDataInicio.Text = Convert.ToString(turma.Data_inicio);
            txtDataFim.Text = Convert.ToString(turma.Data_fim);
            txtCargaHoraria.Text = Convert.ToString(turma.Carga_horaria);
            txtNomeTurma.Text = Convert.ToString(turma.nome_turma);


        }
        protected void cmdConfirmar_Click(object sender, EventArgs e)
        {
            AdicionarTurma();
        }

        protected void cmdExluir_Click(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            turma.Excluir(Convert.ToInt32(gvTurmas.DataKeys[gvTurmas.SelectedIndex].Values[0]));
            PreencherGridTurma();
        }
        void PreencherGridTurma()
        {
            gvTurmas.DataSource = Turma.PreencheGridTurma();
            gvTurmas.DataBind();
        }
        void Formatar_Grid()
        {
            if (!(gvTurmas.HeaderRow is null))
            {
                gvTurmas.UseAccessibleHeader = true;
                gvTurmas.HeaderRow.TableSection = TableRowSection.TableHeader;
                AplicarDataTableGridView();
            }
        }
        public void AplicarDataTableGridView()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "minhaFuncao", "aplicarDataTable()", true);
        }

        protected void gvTurmas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var parametros = e.CommandArgument.ToString().Split('|');

            MostrarDados(Convert.ToInt32(parametros[0]));
            int indiceLinha = Convert.ToInt32(parametros[1]);
            gvTurmas.SelectedIndex = indiceLinha;
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;
        }

        protected void gvTurmas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdConfirmar.Text = "Alterar";
        }
    }
}