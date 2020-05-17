<%@ Page Title="" Language="C#" MasterPageFile="~/Super.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="agencia_viagens.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-dark ftco-navbar-light" id="ftco-navbar">
        <div class="container">
            <a class="navbar-brand" href="home.aspx">Gold Excursões</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#ftco-nav" aria-controls="ftco-nav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="oi oi-menu"></span>Menu
	     
            </button>

            <div class="collapse navbar-collapse" id="ftco-nav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item"><a href="sobre_nos.aspx" class="nav-link">Sobre Nós</a></li>
                    <li class="nav-item"><a href="listagem_viagens_front.aspx" class="nav-link">Viagens</a></li>
                    <li class="nav-item"><a href="galeria.aspx" class="nav-link">Galeria</a></li>
                    <li class="nav-item"><a href="contactos.aspx" class="nav-link">Contactos</a></li>
                    <li class="nav-item"><a href="backoffice.aspx" runat="server" id="back" class="nav-link">Backoffice</a></li>

                    <li class="nav-item cta cta-colored"><a href="cart.html" class="nav-link"><span class="icon-shopping_cart"></span>[0]</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="hero-wrap js-fullheight" style="background-image: url('images/banner.jpeg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text js-fullheight align-items-center justify-content-center">
                <h3 class="v">Modist - Time to get dress</h3>
                <h3 class="vr">Since - 1985</h3>
                <div class="col-md-11 ftco-animate text-center">
                    <h1>Le Stylist</h1>
                    <h2><span>Wear Your Dress</span></h2>
                </div>
                <div class="mouse">
                    <a href="#" class="mouse-icon">
                        <div class="mouse-wheel"><span class="ion-ios-arrow-down"></span></div>
                    </a>
                </div>
            </div>
        </div>
    </div>

    <div class="goto-here"></div>
    <div class="container">
        Home
    </div>


</asp:Content>

