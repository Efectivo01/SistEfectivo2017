Imports System.Data.OleDb
Public Class FrmTablaDivisas
    Dim otipodivisasM As tipodivisasM
    Dim otipodivisasC As tipodivisasC
    Dim odivisasM As divisasM
    Dim odivisasC As divisasC
    Dim dt1, dt2 As DataTable
    Dim lste As List(Of Integer)
    Dim lstCompra As List(Of Double)
    Dim lstVenta As List(Of Double)
    Public No_sucursal As String
    Dim oExistenciaC As New ExistenciaC

    Private Sub PrepararVariables()
        otipodivisasM = New tipodivisasM
        otipodivisasC = New tipodivisasC
        odivisasM = New divisasM
        odivisasC = New divisasC
        dt1 = New DataTable
        dt2 = New DataTable
        lste = New List(Of Integer)
        lstCompra = New List(Of Double)
        lstVenta = New List(Of Double)
    End Sub

    Private Sub LiberarVariables()
        If otipodivisasM IsNot Nothing Then
            otipodivisasM = Nothing
        End If
        If otipodivisasC IsNot Nothing Then
            otipodivisasC.Dispose()
        End If

        If odivisasM IsNot Nothing Then
            odivisasM = Nothing
        End If
        If odivisasC IsNot Nothing Then
            odivisasC.Dispose()
        End If

        dt1 = Nothing
        dt2 = Nothing
        lste = Nothing
        lstCompra = Nothing
        lstVenta = Nothing
    End Sub

    Private Sub FrmTablaDivisas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If oExistenciaC IsNot Nothing Then
            oExistenciaC.Dispose()
        End If
        LiberarVariables()
    End Sub

    Private Sub FrmTablaDivisas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararVariables()
        otipodivisasM.nosucursal = No_sucursal
        dgvTabla.DataSource = otipodivisasC.Stipodivisas(otipodivisasM, No_sucursal).Tables(0)
        Me.dgvTabla.Columns.Item(1).ReadOnly = True
        Me.dgvTabla.Columns.Item(2).DefaultCellStyle.Format = "n2"
        Me.dgvTabla.Columns.Item(3).DefaultCellStyle.Format = "n2"
        dgvNoOrden(dgvTabla)
        dgvTabla.Columns("tipo").Visible = False
        dgvTabla.Columns("nosucursal").Visible = False
    End Sub

    Private Sub dgvNoOrden(ByVal dgv As DataGridView)
        Dim x As DataGridViewColumn
        For Each x In dgv.Columns
            x.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        x = Nothing
        dgv = Nothing
    End Sub

    Private Sub modificar_precios()
        For x As Integer = 0 To dgvTabla.Rows.Count - 1
            otipodivisasM.tipo = Convert.ToInt32(dgvTabla.Rows(x).Cells("tipo").Value.ToString)
            otipodivisasM.Compra = Convert.ToDouble(dgvTabla.Rows(x).Cells("Compra").Value.ToString)
            otipodivisasM.Venta = Convert.ToDouble(dgvTabla.Rows(x).Cells("Venta").Value.ToString)
            otipodivisasM.nosucursal = No_sucursal
            otipodivisasC.Mtipodivisas2(otipodivisasM, No_sucursal)
            oExistenciaC.ActualizaPrecio(No_sucursal, Date.Now.ToShortDateString, Convert.ToInt32(dgvTabla.Rows(x).Cells("tipo").Value.ToString), Convert.ToDouble(dgvTabla.Rows(x).Cells("Compra").Value.ToString))
        Next
    End Sub

    Private Sub VButton1_Click(sender As Object, e As EventArgs) Handles VButton1.Click
        modificar_precios()
        Me.Close()
    End Sub

End Class