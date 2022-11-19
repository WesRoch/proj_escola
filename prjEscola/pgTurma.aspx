<%@ Page Title="" Language="C#" MasterPageFile="~/templateMaster.Master" AutoEventWireup="true" CodeBehind="pgTurma.aspx.cs" Inherits="prjEscola.pgTurma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card efeito-painel-2">
                <div class="card-header bg-dark text-white">
                    Cadastro de Turmas
                </div>
                <div class="card-body">
                    <div>
                        <asp:Label ID="lblNome" runat="server" Text="Nome Turma"></asp:Label>
                        <asp:TextBox ID="txtNomeTurma" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblCurso" runat="server" Text="Curso"></asp:Label>
                        <asp:DropDownList ID="cboCurso" runat="server" CssClass="form-control" OnSelectedIndexChanged="cboCurso_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblInstrutor" runat="server" Text="Instrutor"></asp:Label>
                        <asp:DropDownList ID="cboInstrutor" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label for="lblDataInicio">
                                Data Inicio</label>
                            <asp:TextBox ID="txtDataInicio" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label for="lblTermino">
                                Data Término
                            </label>
                            <asp:TextBox ID="txtDataFim" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label for="lblCargaHoraria">
                                Carga Horaria
                            </label>
                            <asp:TextBox ID="txtCargaHoraria" runat="server" Columns="50" CssClass="form-control" MaxLength="50" Width="100%" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <fieldset>
                        <div>
                            <asp:Label ID="lblTurmasCadastradas" runat="server" Text="Turmas Cadastradas"></asp:Label>
                            <asp:GridView ID="gvTurmas" runat="server" AutoGenerateColumns="False" DataKeyNames="idTurma"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="NOME TURMA">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblTurma" runat="server" CommandArgument='<%#Eval("IDTURMA").ToString()+"|"+Container.DataItemIndex.ToString()%>'
                                                Text='<%#(Eval("NOME_TURMA").ToString()) %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DATA_INICIO" HeaderText="DATA_INICIO" />
                                    <asp:BoundField DataField="DATA_FIM" HeaderText="DATA_FIM" />
                                    <asp:BoundField DataField="CARGA_HORARIA" HeaderText="CARGA_HORARIA" />
                                </Columns>
                                <SelectedRowStyle BackColor="Yellow" />
                            </asp:GridView>
                        </div>
                    </fieldset>
                </div>
                <div class="card-footer">
                    <div class="form-group row">
                        <div class="col-md-3">
                            <asp:Button ID="cmdConfirmar" runat="server" Font-Bold="True"
                                Text="Incluir" CssClass="btn btn-dark" Width="100%" OnClick="cmdConfirmar_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdExluir" runat="server" Font-Bold="True"
                                Text="Excluir" CssClass="btn btn-dark" Width="100%" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdLimpar" runat="server" Font-Bold="True"
                                Text="Limpar" CssClass="btn btn-dark" Width="100%" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdSair" runat="server" Font-Bold="True"
                                Text="Sair" CssClass="btn btn-dark" Width="100%" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
