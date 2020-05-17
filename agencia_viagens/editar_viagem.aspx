<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="editar_viagem.aspx.cs" Inherits="agencia_viagens.editar_viagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="col-xl-8 ftco-animate fadeInUp ftco-animated">
            <div class="col-xl-12 ftco-animate fadeInUp ftco-animated">
                <br />
                <h3 class="mb-4 billing-heading">Editar Viagem</h3>
                <div class="row align-items-end">
                    <div class="col-md-6">
                        <div class="form-group">

                            <label>Título:</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_titulo" ErrorMessage="Preencha o título" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox class="form-control" ID="tb_titulo" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">

                            <label>Preço:</label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ex: 999.99" ControlToValidate="tb_preco" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_preco" ErrorMessage="Preencha o valor" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox class="form-control" ID="tb_preco" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Data Ida:</label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_dataIda" ErrorMessage="Insira a data de ida" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox class="form-control" ID="tb_dataIda" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Data de retorno:</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_dataVolta" ErrorMessage="Insira a data de retorno" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox class="form-control" ID="tb_dataVolta" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>

                    <div class="w-100"></div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:TextBox class="form-control" ID="tb_descricao" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>

                        <script src="ckeditor/ckeditor.js"></script>
                        <script type="text/javascript">
                            CKEDITOR.replace('<%= tb_descricao.ClientID %>', {
                                customConfig: 'custom/analiseswot_config.js'
                            });
                        </script>
                    </div>

                </div>

            </div>

            <asp:Label ID="lbl_mensagem" runat="server" Visible="False" ForeColor="Red"></asp:Label>
            <br />
            <div class="form-group">
                <div>
                    <asp:Button class='btn btn-danger' ID="btn_inserir_sp" runat="server" Text="Insert" OnClick="btn_inserir_sp_Click" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
