<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Clientes.aspx.vb" Inherits="ABM_Clientes" %>

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
    <title>Clientes</title>
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
                        <h2><strong>Nuevo cliente</strong></h2>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label><br />
                                <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Falta campo Nombre" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label1" runat="server" Text="Apellido"></asp:Label><br />
                                <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtApellido" ErrorMessage="Falta campo Apellido" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label3" runat="server" Text="Direccion"></asp:Label><br />
                                <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="Falta campo Direccion" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label4" runat="server" Text="DNI"></asp:Label><br />
                                <asp:TextBox ID="TxtDNI" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtDNI" ErrorMessage="Falta campo DNI" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label><br />
                                <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="Falta campo Telefono" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label8" runat="server" Text="Fecha de nacimiento"></asp:Label><br />
                                <asp:TextBox ID="TxtFechaNacimiento" TextMode="Date" runat="server"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" ControlToValidate="TxtFechaNacimiento" ValidationGroup="grupo1" Type="Date" MinimumValue="1-1-1900" MaximumValue="31-12-2019" runat="server" ErrorMessage="Fecha de nacimiento invalida" Display="None"></asp:RangeValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtFechaNacimiento" ErrorMessage="Falta campo Fecha de nacimiento" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label6" runat="server" Text="Provincia"></asp:Label><br />
                                <asp:DropDownList ID="DdlProvincia" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="Label7" runat="server" Text="Ciudad"></asp:Label><br />
                                <asp:DropDownList ID="DdlCiudad" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <br />
                            <asp:Button ID="BtnGuardar" ValidationGroup="grupo1" OnClientClick="if (!confirm('¿Guardar datos?')) return;" runat="server" Text="Guardar" />
                            <asp:Button ID="BtnCancelar" OnClientClick="return confirm('¿Esta seguro de vaciar los campos?');" runat="server" Text="Cancelar" />
                        </div>
                        <div>
                            <asp:Label ID="LabelErrorDNI" runat="server" CssClass="textoError" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="col-md-8">
                    <div class="jumbotron padding-modificado">
                        <h2><strong>Listado de clientes</strong></h2>
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
                                                    <th></th>
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
                                                    <td><a href="ModificarCliente.aspx?id=<%#Container.DataItem("id")%>">MODIFICAR </a></td>
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
