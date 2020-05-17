<%@ Page Title="" Language="C#" MasterPageFile="~/Super.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="agencia_viagens.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="google-signin-client_id" content="744265030809-cvq00rel0hh0iq6t6mf1h4a33aal0r5l.apps.googleusercontent.com">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div class="hero-wrap hero-bread" style="background-image: url('images/2.jpg');">
        <div class="container">
   
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="mb-0 bread">Login</h1>
                   <!--  <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span></p> -->
                </div>
            </div>
        </div>
    </div>
     <br /><br />
    <div class="container">
        <div class="form-group">
            <label>Email&nbsp; </label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_email" ErrorMessage="Empty email" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<asp:TextBox ID="tb_email" class="form-control" type="email" runat="server"></asp:TextBox>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_email" ErrorMessage="Invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />

        </div>
        <!-- form-group// -->
        <div class="form-group">
            <label>Password</label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_pass" ErrorMessage="Empty password" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<asp:TextBox ID="tb_pass" class="form-control" placeholder="******" type="password" runat="server"></asp:TextBox>

        </div>
        <!-- form-group// -->
        <div class="form-group">
            <div class="checkbox">
                <asp:Label ID="lbl_texto" runat="server" ForeColor="Red" Visible="False">Utilizador ou password incorretos</asp:Label>
            </div>
            <!-- checkbox .// -->
        </div>
        <!-- form-group// -->
        <div class="form-group">
        </div>
        
        <center>
            <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Visible="False">Data expirada</asp:Label>
            <br />
        </center>

        <asp:Button ID="tb_enviar" class="btn tbn-primary" OnClick="tb_enviar_Click" runat="server" Text="Enviar" />
       &nbsp;&nbsp;&nbsp; <a href="criar_conta.aspx" style="color: #345565"> Criar Conta </a>
        &nbsp;&nbsp;&nbsp; <a href="recuperar_pw.aspx" style="color: #345565"> Recuperar Palavra-passe </a>

        <br /><br />
        <div class="g-signin2" data-onsuccess="onSignIn"></div>
          <br /><br />  <br /><br />
    </div>

    <script src="https://apis.google.com/js/platform.js" async defer></script>

</asp:Content>
