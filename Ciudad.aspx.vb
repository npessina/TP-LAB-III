Imports System.Data.SqlClient
Partial Class Ciudad
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
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))

        Dim reader As SqlDataReader
        conexion.Open()
        comando = New SqlCommand("Select * From Ciudad Where nombre=@nombre And idProvincia=@idProvincia", conexion)
        comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
        comando.Parameters.AddWithValue("@idProvincia", DdlProvincia.SelectedValue)
        reader = comando.ExecuteReader()

        If reader.Read() = False Then
            reader.Close()
            comando = New SqlCommand("Insert Into Ciudad(idProvincia, nombre) Values(@idProvincia, @nombre)", conexion)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@idProvincia", DdlProvincia.SelectedValue)
            comando.ExecuteNonQuery()
            LabelErrorNombre.Text = ""
            BtnCancelar_Click(BtnCancelar, e)
            Repeater1_Load(Repeater1, e)
        Else
            LabelErrorNombre.Text = "El nombre de la provincia ya existe. Seleccione otro."
        End If
        reader.Close()
        conexion.Close()
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        TxtNombre.Text = ""
        LabelErrorNombre.Text = ""
    End Sub

    Private Sub Repeater1_Load(sender As Object, e As EventArgs) Handles Repeater1.Load
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Ciudad", conexion)
        reader = comando.ExecuteReader
        Repeater1.DataSource = reader
        Repeater1.DataBind()
        conexion.Close()
    End Sub
End Class
