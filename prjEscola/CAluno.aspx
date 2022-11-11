<%@ Page Title="" Language="C#" MasterPageFile="~/templateMaster.Master" AutoEventWireup="true" CodeBehind="CAluno.aspx.cs" Inherits="prjEscola.CAluno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="featured">
        <div class="containerCentral">

            <%--<h3 style="background: #dff0d8; margin: 0; padding: 5px; border: 1px solid #387030; font-size: 12pt; color: #387030">Cadastro de Pontos</h3>--%>
            <h3 class="h3">Cadastro de Alunos</h3>
            <div style="float: left; width: 100%;">
                <fieldset>
                    <div>
                        <div class="form-group">

                            <div>
                                <label for="nome">
                                    Nome do Aluno</label>
                                <asp:TextBox ID="txtNome" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label for="nome">
                                        CPF</label>
                                    <asp:TextBox ID="txtCPF" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label for="nome">
                                        Data de Nascimento 
                                    </label>
                                    <asp:TextBox ID="txtDtNascimento" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                </div>

                                <div class="col-md-4">
                                    <label for="nome">
                                        Telefone 
                                    </label>
                                    <asp:TextBox ID="txtTelefone" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                                </div>
                            </div>
                            <div>
                            </div>
                            <div>
                                <label for="nome">
                                    e-mail</label>
                                <asp:TextBox ID="txtemail" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>

                            <div>
                            </div>
                            <div>
                                <label for="nome">
                                    Mãe
                                </label>
                                <asp:TextBox ID="txtMae" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>
                            <div>
                                <label for="nome">
                                    Pai 
                                </label>
                                <asp:TextBox ID="txtPai" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>

                            </div>

                        </div>
                    </div>

                </fieldset>
                <div class="form-group">
                    <div class="form-group row">
                        <div class="col-md-3">
                            <asp:Button ID="cmdConfirmar" runat="server" Font-Bold="True"
                                Text="Incluir" CssClass="btn btn-success" Width="100%" OnClick="cmdConfirmar_Click1" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdExluir" runat="server" Font-Bold="True"
                                Text="Excluir" CssClass="btn btn-success" Width="100%" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdLimpar" runat="server" Font-Bold="True"
                                Text="Limpar" CssClass="btn btn-success" Width="100%" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdSair" runat="server" Font-Bold="True"
                                Text="Sair" CssClass="btn btn-success" Width="100%" />
                        </div>
                    </div>
                </div>

                <fieldset>

                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Alunos Cadastrados"></asp:Label>
                        <asp:GridView ID="gvAlunos" runat="server" AutoGenerateColumns="False" DataKeyNames="idAluno" OnRowCommand="gvAlunos_RowCommand" OnSelectedIndexChanged="dgAlunos_SelectedIndexChanged" Height="36px" Width="1537px">
                            <Columns>
                                <asp:TemplateField HeaderText="CPF">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lblCPF" runat="server" CommandArgument='<%#Eval("IDALUNO").ToString()+"|"
                                                    +Container.DataItemIndex.ToString()%>'
                                            Text='<%#(Eval("CPF").ToString()) %>'>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NOME" HeaderText="NOME" />
                                <asp:BoundField DataField="EMAIL" HeaderText="E-MAIL" />
                            </Columns>
                            <SelectedRowStyle BackColor="Yellow" />
                        </asp:GridView>
                    </div>

                </fieldset>
                <div>
                        <asp:TextBox ID="txtIdAluno" runat="server" Columns="50" CssClass="form-control" Width="0%" TabIndex="1" OnTextChanged="txtIdAluno_TextChanged"></asp:TextBox>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
