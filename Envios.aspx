<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Envios.aspx.vb" Inherits="Envios" %>

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
    <title>Envios</title>
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
        <div class="container ancho">
            <div class="row">
                <div class="col-md-4">
                    <div class="jumbotron padding-modificado">
                        <div>
                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="grupo1" ShowMessageBox="true" ShowSummary="false" HeaderText="Se han encontrado los siguientes errores: " runat="server" BorderStyle="NotSet" />
                        </div>
                        <h2><strong>Nuevo envío</strong></h2>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="Label9" runat="server" Text="Cliente"></asp:Label><br />
                                <asp:DropDownList ID="DdlCliente" runat="server" AutoPostBack="true"></asp:DropDownList>
                                <asp:Label ID="LabelCliente" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label4" runat="server" Text="Producto"></asp:Label><br />
                                <asp:DropDownList ID="DdlProducto" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label><br />
                                <asp:TextBox ID="TxtCantidad" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtCantidad" ErrorMessage="Falta campo Cantidad" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label6" runat="server" Text="Tipo de envio"></asp:Label><br />
                                <asp:DropDownList ID="DdlTipoEnvio" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label7" runat="server" Text="Empresa de envio"></asp:Label><br />
                                <asp:TextBox ID="TxtEmpresa" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtEmpresa" ErrorMessage="Falta campo Empresa" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label8" runat="server" Text="Sucursal"></asp:Label><br />
                                <asp:DropDownList ID="DdlSucursal" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <br />
                            <asp:Button ID="BtnGuardar" ValidationGroup="grupo1" OnClientClick="if (!confirm('¿Guardar datos?')) return;" runat="server" Text="Guardar" />
                            <asp:Button ID="BtnCancelar" OnClientClick="return confirm('¿Esta seguro de vaciar los campos?');" runat="server" Text="Cancelar" />
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="jumbotron padding-modificado">
                        <h2><strong>Listado de envíos</strong></h2>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="scroll">
                                    <table id="tablaCl">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                                <tr>
                                                    <th>ID Envio</th>
                                                    <th>Fecha de envio</th>
                                                    <th>Tipo de envio de envio</th>
                                                    <th>Empresa de envio</th>
                                                    <th>Sucursal</th>
                                                    <th>ID Cliente</th>
                                                    <th>ID Producto</th>
                                                    <th>Cantidad</th>
                                                    <th>Precio</th>
                                                    <th>Baja</th>
                                                    <th></th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.DataItem("idEnvio") %></td>
                                                    <td><%#CorregirFecha(Container.DataItem("fecha")) %></td>
                                                    <td><%#Container.DataItem("tipoEnvio") %></td>
                                                    <td><%#Container.DataItem("empresaEnvio") %></td>
                                                    <td><%#Container.DataItem("sucursal") %></td>
                                                    <td><%#Container.DataItem("idCliente") %></td>
                                                    <td><%#Container.DataItem("idProducto") %></td>
                                                    <td><%#Container.DataItem("cantidad") %></td>
                                                    <td><%#Container.DataItem("precio") %></td>
                                                    <td><%#Container.DataItem("baja") %></td>
                                                    <td><a href="ModificarEnvio.aspx?id=<%#Container.DataItem("idEnvio")%>">MODIFICAR </a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
