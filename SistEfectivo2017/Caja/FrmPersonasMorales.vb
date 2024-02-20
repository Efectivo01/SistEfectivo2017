Imports System.Drawing

Public Class FrmPersonasMorales
    Dim oPersonasMoralespM1, oPersonasMoralespM2 As New PersonasMoralespM
    Dim oclientescnbvC As New clientescnbvC
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmPersonasMorales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        classResize.ResizeForm(Me, 1167, 734)
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        lblTitulo.Location = New Point((Me.Width - lblTitulo.Width) / 2, 0)
        lblTitulo2.Location = New Point((Me.Width - lblTitulo2.Width) / 2, (lblTitulo.Height))
        lblTitulo3.Location = New Point((Me.Width - lblTitulo3.Width) / 2, (lblTitulo.Height + lblTitulo2.Height))
        pkb4.Location = New Point(Me.Width - pkb4.Width, 0)
        pkb3.Location = New Point(0, 0)
    End Sub

    Private Sub vbtnConsultar_Click(sender As Object, e As EventArgs) Handles vbtnConsultar.Click
        Dim dialog As DialogResult
        Dim form As New FrmPersonasMConsulta
        dialog = form.ShowDialog(Me)
        TxtID.Text = form.clave
        If IsNumeric(TxtID.Text.Trim) Then
            clientescnbvAcciones()
            txtColonia.BringToFront()
            TxtID.SelectAll()
            'BtnDocumentacion.Enabled = True
        Else
            TxtID.SelectAll()
        End If
        TxtID.Focus()
        TxtID.SelectAll()
    End Sub

    Private Sub clientescnbvAcciones()

        Try
            '''''''''''''''''''oclientescnbvM.cliente = Convert.ToInt32(txtID.Text)
            oPersonasMoralespM1.Num = Convert.ToInt32(TxtID.Text)
            oPersonasMoralespM2 = oclientescnbvC.S1PersonasMorales(oPersonasMoralespM1, Convert.ToInt32(TxtID.Text))
            oclientescnbvC.LiberarDS()
            DatosCliente()
            'buscado = True
        Catch ex As Exception
            'dtpFechaN.Text = DateTime.Now.Date.AddYears(-18)
            'cmbActividad.Text = ""
            MessageBox.Show("NO SE PUDO TRAER LA INFORMACIÓN DEL CLIENTE PORQUE NO SE ENCONTRÓ EN LA BASE DE DATOS O PROVOCÓ UN ERROR")
            'txtNocli.Select()
        End Try
    End Sub

    Private Sub DatosCliente()
        'LLenarDataTables()
        'LlenarCombos()
        'txtNoTarjeta.Text = oclientescnbvM.Iniciales
        TxtID.Text = oPersonasMoralespM2.cliente
        txtRazonSocial.Text = oPersonasMoralespM2.RazonSocial
        txtGiro.Text = oPersonasMoralespM2.Giro
        txtNacionalidad.Text = oPersonasMoralespM2.Nacionalidad

        txtrfc.Text = oPersonasMoralespM2.RFC
        txtNoFiel.Text = oPersonasMoralespM2.NoFiel
        txtCalle.Text = oPersonasMoralespM2.Calle
        txtNoExt.Text = oPersonasMoralespM2.NoExt
        txtNoInt.Text = oPersonasMoralespM2.NoInt
        txtColonia.Text = oPersonasMoralespM2.Colonia
        txtCP.Text = oPersonasMoralespM2.CP
        'cmbEstadoR.SelectedItem = oclientescnbvM.Estado
        txtCiudad.Text = oPersonasMoralespM2.Ciudad
        txtEstado.Text = oPersonasMoralespM2.Estado
        txtNumTelefonico.Text = oPersonasMoralespM2.NoTelefono
        txtCorreoE.Text = oPersonasMoralespM2.CorreoE
        txtFechaConstitucion.Text = oPersonasMoralespM2.FechaConstitucion
        txtNomDirector.Text = oPersonasMoralespM2.DirectorGeneral
        txtNomRepresentanteL.Text = oPersonasMoralespM2.RepresentanteL

        'oclientescnbvM = New clientescnbvM
    End Sub
End Class