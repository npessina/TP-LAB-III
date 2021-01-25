Imports System.Data.SqlClient
Partial Class Producto
    Inherits System.Web.UI.Page

    Private Sub Repeater1_Load(sender As Object, e As EventArgs) Handles Repeater1.Load
        Dim conexion As SqlConnection
        Dim comando As SqlCommand
        Dim reader As SqlDataReader
        conexion = New SqlConnection(ConfigurationManager.AppSettings("con"))
        conexion.Open()
        comando = New SqlCommand("Select * From Producto", conexion)
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
        comando = New SqlCommand("Select * From Producto Where codigo=@codigo", conexion)
        comando.Parameters.AddWithValue("@codigo", TxtCodigo.Text)
        reader = comando.ExecuteReader()

        If reader.Read() = False Then
            reader.Close()
            comando = New SqlCommand("Insert Into Producto(codigo, nombre, descripcion, precio) Values(@codigo, @nombre, @descripcion, @precio)", conexion)
            comando.Parameters.AddWithValue("@codigo", TxtCodigo.Text)
            comando.Parameters.AddWithValue("@nombre", TxtNombre.Text)
            comando.Parameters.AddWithValue("@descripcion", TxtDescripcion.Text)
            comando.Parameters.AddWithValue("@precio", Convert.ToDouble(TxtPrecio.Text))
            comando.ExecuteNonQuery()
            LabelErrorCodigo.Text = ""

            BtnCancelar_Click(BtnCancelar, e)
            Repeater1_Load(Repeater1, e)

        Else
            LabelErrorCodigo.Text = "El codigo del producto ya existe. Seleccione otro."
        End If
        reader.Close()
        conexion.Close()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        TxtNombre.Text = ""
        TxtCodigo.Text = ""
        TxtDescripcion.Text = ""
        TxtPrecio.Text = ""
        LabelErrorCodigo.Text = ""
    End Sub
End Class
