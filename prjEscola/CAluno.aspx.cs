using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjEscola.App_Code.BLL;

namespace prjEscola
{
    public partial class CAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherGridAluno();

            }

        }

        protected void cmdSalvar_Click(object sender, EventArgs e)
        {
            AdicionarAluno();
        }

        private void AdicionarAluno()
        {
            Alunos aluno = new Alunos();
            aluno.NOME = txtNome.Text.ToString().Trim();
            aluno.CPF = txtCPF.Text.ToString().Trim();
            aluno.DATA_NASCIMENTO = Convert.ToDateTime(txtDtNascimento.Text);
            aluno.EMAIL = txtemail.Text.ToString().Trim();
            aluno.TELEFONE = txtTelefone.Text.ToString().Trim();
            aluno.NOME_MAE = txtMae.Text.ToString().Trim();
            aluno.NOME_PAI = txtPai.Text.ToString().Trim();

            if (cmdConfirmar.Text == "Incluir")
            {
                aluno.Inserir();
                LimparCampos();
            }
            else
            {
                aluno.Alterar(Convert.ToInt32(txtIdAluno.Text));
                LimparCampos();

            }

        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtDtNascimento.Text = "";
            txtemail.Text = "";
            txtTelefone.Text = "";
            txtMae.Text = "";
            txtPai.Text = "";
            cmdConfirmar.Text = "Incluir";
        }

        protected void gvAlunos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var parametros = e.CommandArgument.ToString().Split('|'); 

            MostrarDadosAlunos(Convert.ToInt32(parametros[0]));
            int indiceLinha = Convert.ToInt32(parametros[1]);
            gvAlunos.SelectedIndex = indiceLinha;
            cmdConfirmar.Text = "Alterar";
            cmdExluir.Enabled = true;
        }

        protected void cmdConfirmar_Click1(object sender, EventArgs e)
        {
            AdicionarAluno();
            PreencherGridAluno();
        }

        void PreencherGridAluno()
        {
            gvAlunos.DataSource = Alunos.PreencheGridAluno();
            gvAlunos.DataBind();

        }

        protected void dgAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdConfirmar.Text = "Alterar";
        }

        void MostrarDadosAlunos(int codigo)
        {
            Alunos aluno = new Alunos();
            aluno.MostrarDados_Aluno(codigo);
            txtIdAluno.Text = (aluno.IDALUNO).ToString();
            txtNome.Text = aluno.NOME;
            txtCPF.Text = aluno.CPF;
            txtemail.Text = aluno.EMAIL;
            txtDtNascimento.Text = Convert.ToString(aluno.DATA_NASCIMENTO);
            txtMae.Text = aluno.NOME_MAE;
            txtPai.Text = aluno.NOME_PAI;
            txtTelefone.Text = aluno.TELEFONE;

        }

        protected void txtIdAluno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}