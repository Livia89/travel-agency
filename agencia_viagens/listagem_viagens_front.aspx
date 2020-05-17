<%@ Page Title="" Language="C#" MasterPageFile="~/Super.Master" AutoEventWireup="true" CodeBehind="listagem_viagens_front.aspx.cs" Inherits="agencia_viagens.listagem_viagens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .descricao {
            
        }
        input{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-colorSite ftco_navbar bg-dark " id="ftco-navbar">
        <div class="container">
            <a class="navbar-brand" href="home.aspx">Gold Excursões</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#ftco-nav" aria-controls="ftco-nav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="oi oi-menu"></span>Menu
	     
            </button>

            <div class="collapse navbar-collapse" id="ftco-nav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item"><a href="sobre_nos.aspx" class="nav-link">Sobre Nós</a></li>
                    <li class="nav-item"><a href="listagem_viagens.aspx" class="nav-link">Viagens</a></li>
                    <li class="nav-item"><a href="galeria.aspx" class="nav-link">Galeria</a></li>
                    <li class="nav-item"><a href="contactos.aspx" class="nav-link">Contactos</a></li>
                    <li class="nav-item"><a href="backoffice.aspx" runat="server" id="back" class="nav-link">Backoffice</a></li>

                    <li class="nav-item cta cta-colored"><a href="listagem_viagens_front.aspx" class="nav-link"><span runat="server" id="carrinho" class="icon-shopping_cart">
                        <asp:Label ID="quantCarrinho" runat="server" Text="[0]"></asp:Label>
                                                                                                                </span></a></li>
                </ul>
            </div>

        </div>
    </nav>

    <div class="hero-wrap hero-bread" style="background-image: url('images/2.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <h1 class="mb-0 bread">Viagens</h1>
                    <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span> <span>Listagem de Viagens</span></p>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <br />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
            <HeaderTemplate>
                <table class='table' border="1" width="100%">
                    <thead class="thead-dark">
                        <tr style="text-align: center;">
                            <th></th>
                            <th>Título</th>
                            <th>Data de Ida</th>
                            <th>Data de Volta</th>
                            <th>Preço</th>
                            <th>Quantidade</th>
                            <th>Total</th>
                            <th>Adicionar</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="text-center">
                    <!-- <td class="product-remove"><a href="#"><span class="ion-ios-close"></span></a></td> -->

                    <td class="image-prod">
                        <asp:Image class="img" ID="imagem" runat="server" />
                    </td>

                    <td class="product-name">
                        <h3>
                            <asp:Label ID="titulo" runat="server" Text=""></asp:Label>
                            
                        </h3>
                        <p class="descricao">
                            <asp:Label ID="descricao" runat="server" Text=""></asp:Label>
                        </p>
                    </td>

                    <td class="image-prod">

                        <asp:Label id="data_ida" runat="server" Text=""></asp:Label>

                    </td>

                    <td class="image-prod">
                        <asp:Label id="data_volta" runat="server" Text=""></asp:Label>
                    </td>


                    <td class="price">
                        <asp:Label id="preco" runat="server" Text=""></asp:Label>
                    </td>

                    <td class="total">
                        
                            <asp:TextBox ID="quantidade" CssClass="quantity form-control input-number" runat="server"></asp:TextBox>
                        
                    </td>

                    <td class="total">
                       
                    </td>
                    <td class="total">
                       <asp:LinkButton ID="btn_add" runat="server" ToolTip="Adicionar no carrinho" CommandName="btn_add"><span class="glyphicon glyphicon-shopping-cart"></span></asp:LinkButton>
                    </td>
                </tr>
                <!-- END TR-->

            </ItemTemplate>

            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:agencia_BDConnectionString %>" SelectCommand="SELECT * FROM [viagem]"></asp:SqlDataSource>
    </div>
</asp:Content>
