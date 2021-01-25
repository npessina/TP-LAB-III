Imports System.Data.SqlClient
Partial Class ModificarCliente
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If (Not IsPostBack) Then
            Dim conexion As SqlConnection
            Dim comando As SqlCommand
            Dim reader As SqlDataReader

            conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
            conexion.Open()
            comando = New SqlCommand("Select * From Provincia", conexion)
            reader = comando.ExecuteReader()
            DdlProvincia.DataSource = reader
            DdlProvincia.DataValueField = "idProvincia"
            DdlProvincia.DataTextField = "nombre"
            DdlProvincia.DataBind()

            reader.Close()

            comando = New SqlCommand("Select * From Cliente Where id=@param", conexion)
            comando.Parameters.AddWithValue("@param", Request.QueryString("id"))
            reader = comando.ExecuteReader()

            If reader.Read() Then
                TxtNombre.Text = reader("nombre")
                TxtApellido.Text = reader("apellido")
                TxtDireccion.Text = reader("direccion")
                TxtDNI.Text = reader("dni")
                TxtTelefono.Text = reader("telefono")
                TxtFechaNacimiento.Text = Convert.ToDateTime(reader("fecha_nacimiento")).ToString("yyyy-MM-dd")
                DdlProvincia.SelectedValue = reader("idProvincia")
                DdlProvincia_SelectedIndexChanged(DdlProvincia, e)
                DdlCiudad.SelectedValue = reader("idCiudad")
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

    Private Sub DdlProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlProvincia.SelectedIndexChanged
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Ciudad Where idProvincia=@provincia", conexion)
        comando.Parameters.AddWithValue("@provincia", DdlProvincia.SelectedValue)

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
        Dim encontrado As Boolean
        Dim baja As String
        If CbBaja.Checked = True Then
            baja = "Si"
        Else
            baja = "No"
        End If

        encontrado = False
        conexion.Open()
        comando = New SqlCommand("Select * From Cliente Where dni=@dni", conexion)
        comando.Parameters.AddWithValue("@dni", TxtDNI.Text)
        reader = comando.ExecuteReader()
        If reader.Read() Then
            If Request.QueryString("id") <> reader("id") Then
                encontrado = True
            End If
        End If
        reader.Close()
        If encontrado = False Then
            comando = New SqlCommand("Update Cliente Set nombre=@nombre, apellido=@apellido, direccion=@direccion, dni=@dni, telefono=@telefono, idCiudad=@idCiudad, idProvincia=@idProvincia, fecha_nacimiento=@fecha_nacimiento, baja=@baja Where id=@id", conexion)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@apellido", TxtApellido.Text)
            comando.Parameters.AddWithValue("@direccion", TxtDireccion.Text)
            comando.Parameters.AddWithValue("@dni", TxtDNI.Text)
            comando.Parameters.AddWithValue("@telefono", TxtTelefono.Text)
            comando.Parameters.AddWithValue("@idCiudad", DdlCiudad.SelectedValue)
            comando.Parameters.AddWithValue("@idProvincia", DdlProvincia.SelectedValue)
            comando.Parameters.AddWithValue("@fecha_nacimiento", TxtFechaNacimiento.Text)
            comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
            comando.Parameters.AddWithValue("@baja", baja)
            comando.ExecuteNonQuery()
            Response.Redirect("Clientes.aspx")
            LabelErrorDNI.Text = ""
        Else
            LabelErrorDNI.Text = "El DNI del cliente ya existe. Seleccione otro."
        End If
        conexion.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Response.Redirect("Clientes.aspx")
    End Sub
End Class
