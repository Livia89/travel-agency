<%@ Page Title="" Language="C#" MasterPageFile="~/Super.Master" AutoEventWireup="true" CodeBehind="validar_conta.aspx.cs" Inherits="agencia_viagens.validar_conta" %>

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
                    <h1 class="mb-0 bread">Validação da conta</h1>
                   <!--  <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span></p> -->
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div id="containerSucesso" runat="server">
            <h1>A sua conta foi validada com sucesso!</h1>
            <p>Faça <a href="http://localhost:60849/login.aspx">Validação da conta</a></p>
        </div>
        <div id="containerErro" runat="server">
            <h1>Erro na validação da conta!</h1>
            <p>
                <p>Fazer <a href="http://localhost:60849/login.aspx">Login?</a></p>
                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server">Reenviar email?</asp:LinkButton>
                <div id="show" runat="server">
                    <input type="text" runat="server" name="email" id="email" />
                    <asp:Button ID="Button1" class="btn tbn-danger" runat="server" OnClick="Button1_Click" Text="Enviar" />
                    <br />
                    <br />
                    <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>
                    <p runat="server" id="criar_conta">Criar <a href="http://localhost:60849/criar_conta.aspx">Conta</a></p>
                </div>

            </p>
        </div>
    </div>
</asp:Content>
