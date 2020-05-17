<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice.Master" AutoEventWireup="true" CodeBehind="inserir_cliente.aspx.cs" Inherits="agencia_viagens.criar_conta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
          
    <br />
    <div class="row justify-content-center">
        <div class="col-xl-8 ftco-animate fadeInUp ftco-animated">
            <h3 class="mb-4 billing-heading">Inserir Cliente</h3>
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
                    <asp:TextBox class="form-control" ID="tb_email" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <div class="w-100"></div> 
                <div class="col-md-12">
                    <label>Morada:</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_address" ErrorMessage="Empty address" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox class="form-control" ID="tb_address" runat="server"></asp:TextBox>
                </div>
                <div class="w-100"></div>
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
                <div class="w-100"></div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label>Palavra-passe:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_pass" ErrorMessage="Empty password" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox class="form-control" ID="tb_pass" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                    </div>
                </div>
                <div class="col-md-6">
                    <label>Confirme a palavra-passe:</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_repass" ErrorMessage="Empty re-password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:TextBox class="form-control" ID="tb_repass" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tb_pass" ControlToValidate="tb_repass" ErrorMessage="Passwords incorrects" ForeColor="Red"></asp:CompareValidator>
                    <br />
                </div>
            </div>
            Perfil:
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddl_perfil" ErrorMessage="Choose profile" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="ddl_perfil" runat="server">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Cliente</asp:ListItem>
            </asp:DropDownList>
            
        <div> <br />
            <asp:Button class='btn btn-danger' ID="btn_inserir_sp" runat="server" OnClick="btn_inserir_sp_Click" Text="Insert" />
        </div>
        <asp:Label ID="lbl_mensagem" runat="server" Visible="False" ForeColor="Red"></asp:Label>

        </div>
      
    </div>

</asp:Content>
