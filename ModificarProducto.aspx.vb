Imports System.Data.SqlClient
Partial Class ModificarProducto
    Inherits System.Web.UI.Page
    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If (Not IsPostBack) Then
            Dim conexion As SqlConnection
            Dim comando As SqlCommand
            Dim reader As SqlDataReader

            conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
            conexion.Open()

            comando = New SqlCommand("Select * From Producto Where idProducto=@param", conexion)
            comando.Parameters.AddWithValue("@param", Request.QueryString("id"))
            reader = comando.ExecuteReader()

            If reader.Read() Then
                TxtCodigo.Text = reader("codigo")
                TxtNombre.Text = reader("nombre")
                TxtDescripcion.Text = reader("descripcion")
                TxtPrecio.Text = reader("precio")
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
        comando = New SqlCommand("Select * From Producto Where codigo=@codigo", conexion)
        comando.Parameters.AddWithValue("@codigo", TxtCodigo.Text)
        reader = comando.ExecuteReader()
        If reader.Read() Then
            If Request.QueryString("id") <> reader("idProducto") Then
                encontrado = True
            End If
        End If
        reader.Close()
        If encontrado = False Then
            comando = New SqlCommand("Update Producto Set codigo=@codigo, nombre=@nombre, descripcion=@descripcion, precio=@precio, baja=@baja Where idProducto=@id", conexion)
            comando.Parameters.AddWithValue("@codigo", TxtCodigo.Text)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@descripcion", TxtDescripcion.Text)
            comando.Parameters.AddWithValue("@precio", Convert.ToDouble(TxtPrecio.Text))
            comando.Parameters.AddWithValue("@baja", baja)
            comando.Parameters.AddWithValue("@id", Request.QueryString("id"))
            comando.ExecuteNonQuery()
            Response.Redirect("Producto.aspx")
            LabelErrorCodigo.Text = ""
        Else
            LabelErrorCodigo.Text = "El codigo del producto ya existe. Seleccione otro."
        End If
        conexion.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Response.Redirect("Producto.aspx")
    End Sub
End Class
