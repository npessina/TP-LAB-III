
Partial Class Reportes
    Inherits System.Web.UI.Page

    Private Sub BtnClientes_Click(sender As Object, e As EventArgs) Handles BtnClientes.Click
        Response.Redirect("ReportesClientes.aspx")
    End Sub

    Private Sub BtnVentas_Click(sender As Object, e As EventArgs) Handles BtnVentas.Click
        Response.Redirect("ReportesVentas.aspx")
    End Sub
End Class
