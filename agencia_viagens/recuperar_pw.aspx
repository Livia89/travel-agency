<%@ Page Title="" Language="C#" MasterPageFile="~/Super.Master" AutoEventWireup="true" CodeBehind="recuperar_pw.aspx.cs" Inherits="agencia_viagens.recuperar_pw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="hero-wrap hero-bread" style="background-image: url('images/2.jpg');">
        <div class="container">

            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="mb-0 bread">Recuperar Palavra-passe</h1>
                    <!--  <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span></p> -->
                </div>
            </div>
        </div>
    </div>

    <br />
    <div class="container">
        Insira o email:
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="Preencha o email" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="tb_email" CssClass="form-control" runat="server"></asp:TextBox>
        
        <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Text=""></asp:Label><br />
        
        <asp:Button ID="send" runat="server" Text="Send" class="btn btn-danger" OnClick="send_Click" />
        &nbsp;
        <asp:HyperLink ID="hl_create" runat="server" NavigateUrl="~/login.aspx">Login?</asp:HyperLink>
              
        </div>

</asp:Content>
