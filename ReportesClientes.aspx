<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportesClientes.aspx.vb" Inherits="Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="imagenes/icono.png" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reportes Clientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-sm bg-dark navbar-dark" style="margin-bottom: 40px">
                <a class="navbar-brand" href="Principal.aspx">
                    <img src="imagenes/icono.png" alt="logo" style="width: 40px" />
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="Producto.aspx">Productos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Clientes.aspx">Clientes</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Ventas.aspx">Ventas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Provincia.aspx">Provincias</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Ciudad.aspx">Ciudades</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Envios.aspx">Envios</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Reportes.aspx">Reportes</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="grupo1" ShowMessageBox="true" ShowSummary="false" HeaderText="Se han encontrado los siguientes errores: " runat="server" BorderStyle="NotSet" />
        </div>
        <div class="container ancho">
            <div class="jumbotron padding-modificado">
                <h2><strong>Listado de clientes</strong></h2>
                <br />
                <div>
                    <asp:DropDownList ID="DdlBuscar" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="TxtBuscar" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" />
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="scroll">
                            <table id="tablaCl">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <tr>
                                            <th>ID</th>
                                            <th>Nombre</th>
                                            <th>Apellido</th>
                                            <th>Direccion</th>
                                            <th>DNI</th>
                                            <th>Telefono</th>
                                            <th>ID Ciudad</th>
                                            <th>ID Provincia</th>
                                            <th>Fecha de nacimiento</th>
                                            <th>Baja</th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Container.DataItem("id") %></td>
                                            <td><%#Container.DataItem("nombre") %></td>
                                            <td><%#Container.DataItem("apellido") %></td>
                                            <td><%#Container.DataItem("direccion") %></td>
                                            <td><%#Container.DataItem("dni") %></td>
                                            <td><%#Container.DataItem("telefono") %></td>
                                            <td><%#Container.DataItem("idCiudad") %></td>
                                            <td><%#Container.DataItem("idProvincia") %></td>
                                            <td><%#CorregirFecha(Container.DataItem("fecha_nacimiento")) %></td>
                                            <td><%#Container.DataItem("baja") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
