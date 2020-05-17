<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice.Master" AutoEventWireup="true" CodeBehind="listar_viagens.aspx.cs" Inherits="agencia_viagens.listar_viagens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand1" OnItemDataBound="Repeater1_ItemDataBound1">
            <HeaderTemplate>
                <table class='table' border="1" width="100%">
                    <thead class="thead-dark">
                        <tr style="text-align: center;">
                            <th>ID da viagem</th>
                            <th>Título</th>
                            <th>Data de Ida</th>
                            <th>Data de Volta</th>
                            <th>Preço</th>
                            <th>Operações</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_viagem" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_titulo" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_dataIda" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_dataVolta" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_preco" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center><asp:LinkButton ID="btn_edita" runat="server" ToolTip="Editar" CommandName="btn_edita"> <span class="glyphicon glyphicon-edit"></span> </asp:LinkButton>    &nbsp;
                        <asp:LinkButton ID="btn_elimina" runat="server" ToolTip="Eliminar" CommandName="btn_elimina"><span class="glyphicon glyphicon-floppy-remove"></span> </asp:LinkButton></center>
                    </td>
                </tr>

            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_viagem" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_titulo" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_dataIda" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_dataVolta" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_preco" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center><asp:LinkButton ID="btn_edita" runat="server" ToolTip="Editar" CommandName="btn_edita"> <span class="glyphicon glyphicon-edit"></span> </asp:LinkButton>    &nbsp;
                        <asp:LinkButton ID="btn_elimina" runat="server" ToolTip="Eliminar" CommandName="btn_elimina"><span class="glyphicon glyphicon-floppy-remove"></span> </asp:LinkButton></center>
                    </td>
                </tr>

            </AlternatingItemTemplate>

            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:agencia_BDConnectionString %>" SelectCommand="SELECT * FROM [viagem]"></asp:SqlDataSource>
</asp:Content>
