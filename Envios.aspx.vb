Imports System.Data.SqlClient
Partial Class Envios
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If (Not IsPostBack) Then
            Dim conexion As SqlConnection
            Dim comando As SqlCommand
            Dim reader As SqlDataReader

            DdlTipoEnvio.Items.Add("Encomienda")
            DdlTipoEnvio.Items.Add("Correo")

            conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))

            conexion.Open()
            comando = New SqlCommand("Select * From Cliente Where baja='No'", conexion)
            reader = comando.ExecuteReader()
            DdlCliente.DataSource = reader
            DdlCliente.DataValueField = "id"
            DdlCliente.DataTextField = "dni"
            DdlCliente.DataBind()
            reader.Close()

            comando = New SqlCommand("Select * From Producto Where baja='No'", conexion)
            reader = comando.ExecuteReader()

            DdlProducto.DataSource = reader
            DdlProducto.DataValueField = "idProducto"
            DdlProducto.DataTextField = "nombre"
            DdlProducto.DataBind()
            reader.Close()

            comando = New SqlCommand("Select * From Ciudad Where baja='No'", conexion)
            reader = comando.ExecuteReader()

            DdlSucursal.DataSource = reader
            DdlSucursal.DataValueField = "idCiudad"
            DdlSucursal.DataTextField = "nombre"
            DdlSucursal.DataBind()
            reader.Close()

            conexion.Close()
            DdlCliente_SelectedIndexChanged(DdlCliente, e)
        End If
    End Sub

    Private Sub DdlCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlCliente.SelectedIndexChanged
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader

        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Cliente Where id=@id And baja='No'", conexion)
        comando.Parameters.AddWithValue("@id", DdlCliente.SelectedValue)
        reader = comando.ExecuteReader()
        If reader.Read() Then
            LabelCliente.Text = reader("nombre") + " " + reader("apellido")
        End If
        conexion.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim precio As Double
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))

        conexion.Open()

        comando = New SqlCommand("Select * From Producto Where idProducto=@id", conexion)
        comando.Parameters.AddWithValue("@id", DdlProducto.SelectedValue)
        reader = comando.ExecuteReader()
        If reader.Read() Then
            precio = reader("precio")
            precio = precio * TxtCantidad.Text
        End If
        reader.Close()

        If TxtCantidad.Text <> "0" Then
            comando = New SqlCommand("Insert Into Envios(fecha, tipoEnvio, empresaEnvio, sucursal, idCliente, idProducto, cantidad, precio) Values(@fecha, @tipoEnvio, @empresa, @sucursal, @idCliente, @idProducto, @cantidad, @precio)", conexion)
            comando.Parameters.AddWithValue("@fecha", (Today).ToString("yyyy-MM-dd"))
            comando.Parameters.AddWithValue("@tipoEnvio", DdlTipoEnvio.SelectedValue)
            comando.Parameters.AddWithValue("@empresa", TxtEmpresa.Text)
            comando.Parameters.AddWithValue("@sucursal", DdlSucursal.SelectedValue)
            comando.Parameters.AddWithValue("@idCliente", DdlCliente.SelectedValue)
            comando.Parameters.AddWithValue("@idProducto", DdlProducto.SelectedValue)
            comando.Parameters.AddWithValue("@cantidad", TxtCantidad.Text)
            comando.Parameters.AddWithValue("@precio", precio)
            comando.ExecuteNonQuery()

            BtnCancelar_Click(BtnCancelar, e)
            Repeater1_Load(Repeater1, e)
        End If

        conexion.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        TxtCantidad.Text = ""
        TxtEmpresa.Text = ""
    End Sub

    Private Sub Repeater1_Load(sender As Object, e As EventArgs) Handles Repeater1.Load
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Envios", conexion)
        reader = comando.ExecuteReader
        Repeater1.DataSource = reader
        Repeater1.DataBind()
        conexion.Close()
    End Sub

    Function CorregirFecha(fecha As Date) As String
        Return (Day(fecha) & "/" & Month(fecha) & "/" & Year(fecha))
    End Function
End Class
