<%@ Page Title="" Language="C#" MasterPageFile="~/Super.Master" AutoEventWireup="true" CodeBehind="criar_conta.aspx.cs" Inherits="agencia_viagens.criar_conta1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hero-wrap .slider-text .bread {
            color: #fff !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/aviao.jpg');">
        <div class="container">

            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="mb-0 bread">Criar Conta</h1>
                    <!--  <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span></p> -->
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row justify-content-center">
        <div class="col-xl-8 ftco-animate fadeInUp ftco-animated">
            <div class="row align-items-end">
                <div class="col-md-6">
                    <label>Nome:</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_nome" ErrorMessage="Preencha o nome" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox class="form-control" ID="tb_nome" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label>Email:</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="Preencha o email" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:TextBox class="form-control" ID="tb_email" runat="server"></asp:TextBox>
                </div>
                <div class="w-100"></div>
                <br />
                <div class="col-md-6">
                    <label>Morada:</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_address" ErrorMessage="Preencha a morada" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:TextBox class="form-control" ID="tb_address" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                        <label>Telefone:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_phone" ErrorMessage="Preencha o telefone" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox class="form-control" ID="tb_phone" runat="server"></asp:TextBox>
                </div>
                <div class="w-100"></div>
                <br />
                <div class="col-md-6">
                        <label>Palavra-passe:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_pass" ErrorMessage="Preencha a password" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox class="form-control" ID="tb_pass" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label>Confirme a palavra-passe:</label> <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_repass" ErrorMessage="Confirme a password" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tb_pass" ControlToValidate="tb_repass" ErrorMessage="As passwords não são iguais" ForeColor="Red"></asp:CompareValidator>
                    <asp:TextBox class="form-control" ID="tb_repass" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div>
                <br />
                    <asp:Button class='btn btn-danger' ID="btn_inserir_sp" OnClick="btn_inserir_sp_Click" runat="server" Text="Criar" /> 
                    <span style="margin-left: 10px;">Já tem uma conta? <a href="http://localhost:60849/login.aspx">Faça Login </a></span>
            </div>
            <br />
            <asp:Label ID="lbl_mensagem" runat="server" ForeColor="Red"></asp:Label>
        </div>
        </div>
</asp:Content>
