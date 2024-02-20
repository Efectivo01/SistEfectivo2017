Imports System.Data.SqlClient

Public Class frmCelular
    Dim conn As New ConexionSQLS
    Public ColorTarjeta As String
    Public NumCelular As String
    Public Cliente As String
    Public NumTarjeta As String
    Public FechaEmvioP As String
    Dim SQL As String
    Dim comm As SqlCommand
    Dim rs As SqlDataReader

    Private Sub frmCelular_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCelular.Focus()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Aceptar()
    End Sub

    Sub Aceptar()
        conn.EstablecerConexion()
        conn.AbrirConexion()

        SQL = ""
        SQL = SQL & "Select "
        SQL = SQL & "   cliente, "
        SQL = SQL & "   Tarjeta, "
        SQL = SQL & "   Fecha_Envio_P "
        SQL = SQL & "From "
        SQL = SQL & "   clientescnbv "
        SQL = SQL & "Where "
        SQL = SQL & "   Telcelular = '" & txtCelular.Text.Trim & "'"

        comm = New SqlCommand(SQL, conn.con)
        rs = comm.ExecuteReader

        NumTarjeta = ""
        Cliente = ""
        NumCelular = txtCelular.Text
        FechaEmvioP = ""

        While rs.Read
            NumTarjeta = rs(1)
            Cliente = rs(0)
            If IsDBNull(rs(2)) Then
                FechaEmvioP = ""
            Else
                FechaEmvioP = rs(2)
            End If
        End While
        rs.Close()

        conn.CerrarConexion()

        If ColorTarjeta = "VERDE" Then
            If NumTarjeta = "" Then
                MsgBox("Este Numero de Celular no tiene Monedero Verde asignada", vbInformation)
                Exit Sub
            End If
        Else
            If FechaEmvioP = "" Then
                MsgBox("Este Numero de Celular no tiene Monedero Rojo asignada", vbInformation)
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        NumTarjeta = ""
        Cliente = ""
        NumCelular = ""
        Me.Close()
    End Sub

    Private Sub txtCelular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCelular.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Aceptar()
        End If
    End Sub
End Class