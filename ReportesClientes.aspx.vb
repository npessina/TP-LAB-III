Imports System.Data.SqlClient
Partial Class Reportes
    Inherits System.Web.UI.Page
    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If (Not IsPostBack) Then
            DdlBuscar.Items.Add("DNI")
            DdlBuscar.Items.Add("Apellido")
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()

        If TxtBuscar.Text = "" Then
            comando = New SqlCommand("Select * From Cliente", conexion)
            reader = comando.ExecuteReader
            Repeater1.DataSource = reader
            Repeater1.DataBind()
        ElseIf DdlBuscar.SelectedValue = "DNI" Then
            comando = New SqlCommand("Select * From Cliente Where dni Like ''+@dni+'%'", conexion)
            comando.Parameters.AddWithValue("@dni", TxtBuscar.Text)
            reader = comando.ExecuteReader
            Repeater1.DataSource = reader
            Repeater1.DataBind()
        ElseIf DdlBuscar.SelectedValue = "Apellido" Then
            comando = New SqlCommand("Select * From Cliente Where apellido Like ''+@apellido+'%'", conexion)
            comando.Parameters.AddWithValue("@apellido", TxtBuscar.Text)
            reader = comando.ExecuteReader
            Repeater1.DataSource = reader
            Repeater1.DataBind()
        End If
        conexion.Close()

    End Sub

    Function CorregirFecha(fecha As Date) As String
        Return (Day(fecha) & "/" & Month(fecha) & "/" & Year(fecha))
    End Function
End Class
