Imports System.Data.SqlClient
Partial Class ReportesEnvios
    Inherits System.Web.UI.Page
    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If (Not IsPostBack) Then
            DdlBuscar.Items.Add("ID")
            DdlBuscar.Items.Add("Vendedor")
        End If
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()

        If TxtBuscar.Text = "" Then
            comando = New SqlCommand("Select * From Ventas", conexion)
            reader = comando.ExecuteReader
            Repeater1.DataSource = reader
            Repeater1.DataBind()
        ElseIf DdlBuscar.SelectedValue = "ID" Then
            comando = New SqlCommand("Select * From Ventas Where idVenta=@id", conexion)
            comando.Parameters.AddWithValue("@id", TxtBuscar.Text)
            reader = comando.ExecuteReader
            Repeater1.DataSource = reader
            Repeater1.DataBind()
        ElseIf DdlBuscar.SelectedValue = "Vendedor" Then
            comando = New SqlCommand("Select * From Ventas Where vendedor Like ''+@vendedor+'%'", conexion)
            comando.Parameters.AddWithValue("@vendedor", TxtBuscar.Text)
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
