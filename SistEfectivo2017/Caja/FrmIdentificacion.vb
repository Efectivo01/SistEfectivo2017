Imports System.Drawing
Imports System.IO

Public Class FrmIdentificacion
    Public oclientescnbvM As New clientescnbvM
    Dim alto1, ancho1, alto2, ancho2, originalAl, originalAn As Integer
    Dim IMAGENCLIENT As String = " \\tsclient\C\IDENTIFICA\COPIA\"
    Dim copiar As Process
    Dim fs As System.IO.FileStream = Nothing
    Dim ImagenA As Bitmap = Nothing
    Dim ImagenB As Bitmap = Nothing

    Private Sub FrmIdentificacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oclientescnbvM = Nothing
        If copiar IsNot Nothing Then
            copiar.Dispose()
        Else
            copiar = Nothing
        End If
        If fs IsNot Nothing Then
            fs.Dispose()
        End If
        If pkb5.Image IsNot Nothing Then
            pkb5.Image.Dispose()
        End If
        If pkb6.Image IsNot Nothing Then
            pkb6.Image.Dispose()
        End If
    End Sub
    Private Sub FrmIdentificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = (Screen.PrimaryScreen.WorkingArea.Width - 20)
        Me.Height = (Screen.PrimaryScreen.WorkingArea.Height / 2)
        Me.Location = New Point(0, 0)
        Me.Location = New Point(((Screen.PrimaryScreen.WorkingArea.Width - (pkb5.Width * 2))) / 2, ((Screen.PrimaryScreen.WorkingArea.Height - pkb5.Height)) / 2)
        pkb5.Location = New Point(0, 0)
        pkb6.Location = New Point(pkb5.Width + 10, 0)
        pkb5.Width = (Me.Width / 2)
        pkb5.Height = (Me.Height - 20) - Panel1.Height
        pkb6.Width = (Me.Width / 2)
        pkb6.Height = (Me.Height - 20) - Panel1.Height
        pkb6.Location = New Point(pkb5.Width + 2, 0)
        Me.Height = Me.Height + 10
        If oclientescnbvM.identifica2 = "" Or oclientescnbvM.identifica2 Is Nothing Then
            Me.Height = Me.Height * 2
            pkb5.Height = pkb5.Height * 2
            pkb6.Visible = False
        End If

        Me.Location = New Point(((Screen.PrimaryScreen.WorkingArea.Width - (pkb5.Width * 2))) / 2, ((Screen.PrimaryScreen.WorkingArea.Height - pkb5.Height)) / 2)
        If System.IO.File.Exists(oclientescnbvM.identifica1) Then
            fs = New System.IO.FileStream(oclientescnbvM.identifica1, IO.FileMode.Open, IO.FileAccess.Read)
            ImagenA = System.Drawing.Image.FromStream(fs)
            pkb5.Image = ImagenA
            pkb5.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            pkb5.Image = Nothing
        End If

        If System.IO.File.Exists(oclientescnbvM.identifica2) Then
            fs = New System.IO.FileStream(oclientescnbvM.identifica2, IO.FileMode.Open, IO.FileAccess.Read)
            ImagenB = System.Drawing.Image.FromStream(fs)
            pkb6.Image = ImagenB
            pkb6.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            pkb6.Image = Nothing
        End If

        alto1 = pkb5.Height
        ancho1 = pkb5.Width
        alto2 = pkb6.Height
        ancho2 = pkb6.Width
        originalAl = Me.Height
        originalAn = Me.Width
        Me.Location = New Point(5, 20)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnAlto_Click(sender As Object, e As EventArgs) Handles btnAlto.Click
        If Me.Height >= originalAl Then
            Me.Height += 100
        End If
        If pkb5.Height >= alto1 Then
            Me.pkb5.Height += 100
        End If
        If pkb6.Height >= alto2 Then
            Me.pkb6.Height += 100
        End If
    End Sub

    Private Sub btnAncho_Click(sender As Object, e As EventArgs) Handles btnAncho.Click
        If Me.Width >= originalAn Then
            Me.Width += 100
        End If
        If pkb5.Width >= ancho1 Then
            Me.pkb5.Width += 100
        End If
        If pkb6.Width >= ancho2 Then
            Me.pkb6.Width += 100
        End If
    End Sub

    Private Sub btnReinicio_Click(sender As Object, e As EventArgs) Handles btnReinicio.Click
        Me.Height = originalAl
        Me.Width = originalAn
        Me.pkb5.Height = alto1
        Me.pkb5.Width = ancho1
        Me.pkb6.Height = alto2
        Me.pkb6.Width = ancho2
    End Sub

    Private Sub btnAlto2_Click(sender As Object, e As EventArgs) Handles btnAlto2.Click
        If Me.Height > originalAl Then
            Me.Height -= 100
        End If
        If pkb5.Height > alto1 Then
            Me.pkb5.Height -= 100
        End If
        If pkb6.Height > alto2 Then
            Me.pkb6.Height -= 100
        End If
    End Sub

    Private Sub btnAncho2_Click(sender As Object, e As EventArgs) Handles btnAncho2.Click
        If Me.Width > originalAn Then
            Me.Width -= 100
        End If
        If pkb5.Width > ancho1 Then
            Me.pkb5.Width -= 100
        End If
        If pkb6.Width > ancho2 Then
            Me.pkb6.Width -= 100
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pkb5.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pkb6.BringToFront()
    End Sub

    Private Sub btnCopia_Click(sender As Object, e As EventArgs) Handles btnCopia.Click
        Me.Cursor = Cursors.WaitCursor
        If Not Directory.Exists(IMAGENCLIENT) Then
            Directory.CreateDirectory(IMAGENCLIENT)
        End If
        If oclientescnbvM.identifica1 <> "" Then
            'imagen1 = "D:\IDENTIFICACIONES\" + imagen1
            copiar = Process.Start("C:\Windows\System32\cmd.exe", "/c copy " & oclientescnbvM.identifica1 & IMAGENCLIENT)
            copiar.StartInfo.CreateNoWindow = False
            copiar.WaitForExit()
            copiar.Close()
        End If
        If oclientescnbvM.identifica2 <> "" Then
            'imagen2 = "D:\IDENTIFICACIONES\" + imagen2
            copiar = Process.Start("C:\Windows\System32\cmd.exe", "/c copy " & oclientescnbvM.identifica2 & IMAGENCLIENT)
            copiar.StartInfo.CreateNoWindow = False
            copiar.WaitForExit()
            copiar.Close()
        End If
        Me.Cursor = Cursors.Default
        MessageBox.Show("COPIA FINALIZADA, REVISE LA CARPETA C:\IDENTIFICA\COPIA")
    End Sub
End Class