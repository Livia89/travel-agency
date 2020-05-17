<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice.Master" AutoEventWireup="true" CodeBehind="editar_utilizador.aspx.cs" Inherits="agencia_viagens.editar_utilizador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="row justify-content-center">
        <div class="col-xl-8 ftco-animate fadeInUp ftco-animated">
            <h3 class="mb-4 billing-heading">Editar Utilizador</h3>
            <div class="row align-items-end">
                <div class="col-md-6">
                    <label>Nome:</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_nome" ErrorMessage="Empty name" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox class="form-control" ID="tb_nome" runat="server"></asp:TextBox>
                    <br />
                </div>
                <div class="col-md-6">

                    <label>Email:</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="Empty email" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox class="form-control" ID="tb_email" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>

                <div class="col-md-12">
                     <div class="form-group">
                    <label>Morada:</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_address" ErrorMessage="Empty address" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox class="form-control" ID="tb_address" runat="server"></asp:TextBox>
                         </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label>Telefone:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_phone" ErrorMessage="Empty phone" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox class="form-control" ID="tb_phone" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Validade da conta:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_date" ErrorMessage="Empty date" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox class="form-control" ID="tb_date" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

            </div>
            Perfil:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddl_perfil" ErrorMessage="Choose profile" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddl_perfil" runat="server">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Cliente</asp:ListItem>
            </asp:DropDownList>

            <br />

            Revendedor:
            <asp:CheckBox ID="CheckBox1" runat="server" />

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
