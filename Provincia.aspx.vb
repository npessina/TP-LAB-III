Imports System.Data.SqlClient
Partial Class Provincia
    Inherits System.Web.UI.Page

    Private Sub Repeater1_Load(sender As Object, e As EventArgs) Handles Repeater1.Load
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Provincia", conexion)
        reader = comando.ExecuteReader
        Repeater1.DataSource = reader
        Repeater1.DataBind()
        conexion.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))

        Dim reader As SqlDataReader
        conexion.Open()
        comando = New SqlCommand("Select * From Provincia Where nombre=@nombre", conexion)
        comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
        reader = comando.ExecuteReader()

        If reader.Read() = False Then
            reader.Close()
            comando = New SqlCommand("Insert Into Provincia(nombre) Values(@nombre)", conexion)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
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
End Class
