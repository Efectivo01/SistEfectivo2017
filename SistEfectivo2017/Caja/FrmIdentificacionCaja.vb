Imports System.Drawing

Public Class FrmIdentificacionCaja
    Public IdenLadoA, IdenLadoB As String
    Dim alto1, ancho1, alto2, ancho2, originalAl, originalAn As Integer
    Dim IMAGENCLIENT As String = " \\tsclient\C\IDENTIFICA\COPIA\"
    Dim copiar As Process
    Dim fs As System.IO.FileStream = Nothing
    Dim ImagenA As Bitmap = Nothing
    Dim ImagenB As Bitmap = Nothing
    Public Respuesta As Boolean

    Private Sub FrmIdentificacionCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.Height = Me.Height + 20
        If IdenLadoA = "" Or IdenLadoA Is Nothing Then
            Me.Height = Me.Height * 2
            pkb5.Height = pkb5.Height * 2
            pkb6.Visible = False
        End If

        Me.Location = New Point(((Screen.PrimaryScreen.WorkingArea.Width - (pkb5.Width * 2))) / 2, ((Screen.PrimaryScreen.WorkingArea.Height - pkb5.Height)) / 2)
        If System.IO.File.Exists(IdenLadoA) Then
            fs = New System.IO.FileStream(IdenLadoA, IO.FileMode.Open, IO.FileAccess.Read)
            ImagenA = System.Drawing.Image.FromStream(fs)
            pkb5.Image = ImagenA
            pkb5.SizeMode = PictureBoxSizeMode.StretchImage
            fs.Close()
        Else
            pkb5.Image = Nothing
        End If

        If System.IO.File.Exists(IdenLadoB) Then
            fs = New System.IO.FileStream(IdenLadoB, IO.FileMode.Open, IO.FileAccess.Read)
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
        BtnSi.Focus()
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

    Private Sub BtnSi_Click(sender As Object, e As EventArgs) Handles BtnSi.Click
        FrmCaja.IdentificacionCorrecta = True
        Respuesta = True
        Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs) Handles BtnNo.Click
        FrmCaja.IdentificacionCorrecta = False
        Respuesta = False
        Close()
    End Sub
End Class