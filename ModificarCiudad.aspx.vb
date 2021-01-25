Imports System.Data.SqlClient
Partial Class ModificarCiudad
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

            comando = New SqlCommand("Select * From Ciudad Where idCiudad=@param", conexion)
            comando.Parameters.AddWithValue("@param", Request.QueryString("id"))
            reader = comando.ExecuteReader()

            If reader.Read() Then
                TxtNombre.Text = reader("nombre")
                DdlProvincia.SelectedValue = reader("idProvincia")
                If reader("baja") = "Si" Then
                    CbBaja.Checked = True
                Else
                    CbBaja.Checked = False
                End If
            End If
            reader.Close()
            conexion.Close()
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        Dim reader As SqlDataReader
        Dim encontrado As Boolean
        Dim baja As String
        If CbBaja.Checked = True Then
            baja = "Si"
        Else
            baja = "No"
        End If

        encontrado = False
        conexion.Open()
        comando = New SqlCommand("Select * From Ciudad Where nombre=@nombre And idProvincia=@idProvincia", conexion)
        comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
        comando.Parameters.AddWithValue("@idProvincia", DdlProvincia.SelectedValue)
        reader = comando.ExecuteReader()
        If reader.Read() Then
            If Request.QueryString("id") <> reader("idCiudad") Then
                encontrado = True
            End If
        End If
        reader.Close()
        If encontrado = False Then
            comando = New SqlCommand("Update Ciudad Set nombre=@nombre, idProvincia=@idProvincia, baja=@baja Where idCiudad=@id", conexion)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
            comando.Parameters.AddWithValue("@idProvincia", DdlProvincia.SelectedValue)
            comando.Parameters.AddWithValue("@baja", baja)
            comando.ExecuteNonQuery()
            Response.Redirect("Ciudad.aspx")
            LabelErrorNombre.Text = ""
        Else
            LabelErrorNombre.Text = "El nombre de la ciudad ya existe. Seleccione otro."
        End If
        conexion.Close()
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Response.Redirect("Ciudad.aspx")
    End Sub
End Class
