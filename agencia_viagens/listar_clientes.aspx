<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice.Master" AutoEventWireup="true" CodeBehind="listar_clientes.aspx.cs" Inherits="agencia_viagens.listar_clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   
    <div  class="container">
        
    <p>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table class='table' border="1" width="100%">
                    <thead class="thead-dark">
                        <tr style="text-align: center;">
                            <th>Nome</th>
                            <th>Morada</th>
                            <th>Email</th>
                            <th>Telefone</th>
                            <th>Validade da conta</th>
                            <th>Perfil</th>
                            <th>Operações</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_nome" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_morada" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_email" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_telefone" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_data" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_perfil" Text=""></asp:Label>
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
                        <center><asp:Label runat="server" ID="lbl_nome" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_morada" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center><asp:Label runat="server" ID="lbl_email" Text=""></asp:Label></center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_telefone" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_data" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <center>
                                    <asp:Label runat="server" ID="lbl_perfil" Text=""></asp:Label>
                                </center>
                    </td>
                    <td>
                        <asp:LinkButton ID="btn_edita" runat="server" ToolTip="Editar" CommandName="btn_edita"> <span class="glyphicon glyphicon-edit"></span> </asp:LinkButton>
                        <asp:LinkButton ID="btn_elimina" runat="server" ToolTip="Eliminar" CommandName="btn_elimina"><span class="glyphicon glyphicon-floppy-remove"></span> </asp:LinkButton>
                    </td>
                </tr>
                 
            </AlternatingItemTemplate>

            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>


        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:agencia_BDConnectionString %>" SelectCommand="SELECT [nome], [morada], [email], [telefone], [validade_da_conta], [perfil], [id_cliente] FROM [clientes]"></asp:SqlDataSource>
    </p>
       </div>

</asp:Content>
