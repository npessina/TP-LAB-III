Imports System.Data.SqlClient
Partial Class Ventas
    Inherits System.Web.UI.Page
    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If (Not IsPostBack) Then
            Dim conexion As SqlConnection
            Dim comando As SqlCommand
            Dim reader As SqlDataReader

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
            DdlCliente_SelectedIndexChanged(DdlCliente, e)

            conexion.Close()
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

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
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
        End If

        LabelCantidad.Text = Convert.ToInt32(LabelCantidad.Text) + Convert.ToInt32(TxtCantidad.Text)
        LabelPrecioTotal.Text = LabelPrecioTotal.Text + (precio * TxtCantidad.Text)
        conexion.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))

        conexion.Open()
        If LabelCantidad.Text <> "0" Then
            comando = New SqlCommand("Insert Into Ventas(fecha, idCliente, vendedor, cantidad, precio) Values(@fecha, @idCliente, @vendedor, @cantidad, @precio)", conexion)
            comando.Parameters.AddWithValue("@fecha", (Today).ToString("yyyy-MM-dd"))
            comando.Parameters.AddWithValue("@idCliente", DdlCliente.SelectedValue)
            comando.Parameters.AddWithValue("@vendedor", TxtVendedor.Text)
            comando.Parameters.AddWithValue("@cantidad", LabelCantidad.Text)
            comando.Parameters.AddWithValue("@precio", Convert.ToDouble(LabelPrecioTotal.Text))
            comando.ExecuteNonQuery()

            BtnCancelar_Click(BtnCancelar, e)
            Repeater1_Load(Repeater1, e)
        End If

        conexion.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        TxtVendedor.Text = ""
        LabelCantidad.Text = "0"
        LabelPrecioTotal.Text = "0"
        TxtCantidad.Text = ""
    End Sub

    Private Sub Repeater1_Load(sender As Object, e As EventArgs) Handles Repeater1.Load
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Ventas", conexion)
        reader = comando.ExecuteReader
        Repeater1.DataSource = reader
        Repeater1.DataBind()
        conexion.Close()
    End Sub

    Function CorregirFecha(fecha As Date) As String
        Return (Day(fecha) & "/" & Month(fecha) & "/" & Year(fecha))
    End Function
End Class

