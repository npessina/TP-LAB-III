<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificarCiudad.aspx.vb" Inherits="ModificarCiudad" %>

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
    <title>Modificar Ciudad</title>
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
        <div class="container">
            <div class="jumbotron">
                <h2><strong>Modificar ciudad</strong></h2>
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label><br />
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grupo1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Falta campo Nombre" Display="None" BorderStyle="NotSet"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label6" runat="server" Text="Provincia"></asp:Label><br />
                        <asp:DropDownList ID="DdlProvincia" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <br />
                        <asp:CheckBox ID="CbBaja" runat="server" Text="&nbsp;Baja" />
                    </div>
                </div>
                <div>
                    <br />
                    <asp:Button ID="BtnGuardar" ValidationGroup="grupo1" OnClientClick="return confirm('¿Guardar datos?');" runat="server" Text="Guardar" />
                    <asp:Button ID="BtnCancelar" OnClientClick="return confirm('¿Esta seguro de cancelar y volver a la pagina anterior?');" runat="server" Text="Cancelar" />

                </div>
                <div>
                    <asp:Label ID="LabelErrorNombre" runat="server" CssClass="textoError" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
