Imports System.Data.SqlClient
Partial Class ABM_Clientes
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If (Not IsPostBack) Then
            Dim conexion As SqlConnection
            Dim comando As SqlCommand
            Dim reader As SqlDataReader

            conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
            conexion.Open()
            comando = New SqlCommand("Select * From Provincia Where baja='No'", conexion)
            reader = comando.ExecuteReader()
            DdlProvincia.DataSource = reader
            DdlProvincia.DataValueField = "idProvincia"
            DdlProvincia.DataTextField = "nombre"
            DdlProvincia.DataBind()
            reader.Close()
            conexion.Close()
            DdlProvincia_SelectedIndexChanged(DdlProvincia, e)
        End If

    End Sub

    Private Sub DdlProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlProvincia.SelectedIndexChanged
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader

        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Ciudad Where idProvincia=@id", conexion)
        comando.Parameters.AddWithValue("@id", DdlProvincia.SelectedValue)
        reader = comando.ExecuteReader()
        DdlCiudad.DataSource = reader
        DdlCiudad.DataValueField = "idCiudad"
        DdlCiudad.DataTextField = "nombre"
        DdlCiudad.DataBind()

        reader.Close()
        conexion.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))

        Dim reader As SqlDataReader
        conexion.Open()
        comando = New SqlCommand("Select * From Cliente Where dni=@dni", conexion)
        comando.Parameters.AddWithValue("@dni", TxtDNI.Text)
        reader = comando.ExecuteReader()

        If reader.Read() = False Then
            reader.Close()
            comando = New SqlCommand("Insert Into Cliente(nombre, apellido, direccion, dni, telefono, idCiudad, idProvincia, fecha_nacimiento) Values(@nombre, @apellido, @direccion, @dni, @telefono, @idCiudad, @idProvincia, @fecha_nacimiento)", conexion)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@apellido", TxtApellido.Text)
            comando.Parameters.AddWithValue("@direccion", TxtDireccion.Text)
            comando.Parameters.AddWithValue("@dni", TxtDNI.Text)
            comando.Parameters.AddWithValue("@telefono", TxtTelefono.Text)
            comando.Parameters.AddWithValue("@idCiudad", DdlCiudad.SelectedValue)
            comando.Parameters.AddWithValue("@idProvincia", DdlProvincia.SelectedValue)
            comando.Parameters.AddWithValue("@fecha_nacimiento", TxtFechaNacimiento.Text)
            comando.ExecuteNonQuery()
            LabelErrorDNI.Text = ""
            BtnCancelar_Click(BtnCancelar, e)
            Repeater1_Load(Repeater1, e)
        Else
            LabelErrorDNI.Text = "El DNI del cliente ya existe. Seleccione otro."
        End If
        reader.Close()
        conexion.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        TxtNombre.Text = ""
        TxtApellido.Text = ""
        TxtDireccion.Text = ""
        TxtDNI.Text = ""
        TxtTelefono.Text = ""
        TxtFechaNacimiento.Text = ""
        LabelErrorDNI.Text = ""

    End Sub

    Private Sub Repeater1_Load(sender As Object, e As EventArgs) Handles Repeater1.Load
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Cliente", conexion)
        reader = comando.ExecuteReader
        Repeater1.DataSource = reader
        Repeater1.DataBind()
        conexion.Close()
    End Sub

    Function CorregirFecha(fecha As Date) As String
        Return (Day(fecha) & "/" & Month(fecha) & "/" & Year(fecha))
    End Function
End Class
