Imports System.Data.SqlClient
Partial Class ModificarVenta
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

            comando = New SqlCommand("Select * From Ventas Where idVenta=@param", conexion)
            comando.Parameters.AddWithValue("@param", Request.QueryString("id"))
            reader = comando.ExecuteReader()

            If reader.Read() Then
                DdlCliente.SelectedValue = reader("idCliente")
                TxtFecha.Text = Convert.ToDateTime(reader("fecha")).ToString("yyyy-MM-dd")
                TxtVendedor.Text = reader("vendedor")
                TxtCantidad.Text = reader("cantidad")
                TxtPrecioTotal.Text = reader("precio")
                If reader("baja") = "Si" Then
                    CbBaja.Checked = True
                Else
                    CbBaja.Checked = False
                End If
            End If
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
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        Dim baja As String
        If CbBaja.Checked = True Then
            baja = "Si"
        Else
            baja = "No"
        End If

        If TxtCantidad.Text <> "0" Then
            conexion.Open()
            comando = New SqlCommand("Update Ventas Set fecha=@fecha, idCliente=@idCliente, vendedor=@vendedor, cantidad=@cantidad, precio=@precio, baja=@baja Where idVenta=@id", conexion)
            comando.Parameters.AddWithValue("@fecha", TxtFecha.Text)
            comando.Parameters.AddWithValue("@idCliente", DdlCliente.SelectedValue)
            comando.Parameters.AddWithValue("@vendedor", TxtVendedor.Text)
            comando.Parameters.AddWithValue("@cantidad", TxtCantidad.Text)
            comando.Parameters.AddWithValue("@precio", Convert.ToDouble(TxtPrecioTotal.Text))
            comando.Parameters.AddWithValue("@baja", baja)
            comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
            comando.ExecuteNonQuery()
            Response.Redirect("Ventas.aspx")
            conexion.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Response.Redirect("Ventas.aspx")
    End Sub
End Class
