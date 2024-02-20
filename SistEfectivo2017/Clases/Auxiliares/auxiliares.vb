Public Class auxiliares
    Implements IDisposable
    Dim disposed As Boolean = False
    Public Function EliminarAcentos(texto) As String
        Dim i, s1, s2
        s1 = "ÁÀÉÈÍÏÓÒÚÜáàèéíïóòúüñç"
        s2 = "AAEEIIOOUUaaeeiioouunc"
        If Len(texto) <> 0 Then
            For i = 1 To Len(s1)
                texto = Replace(texto, Mid(s1, i, 1), Mid(s2, i, 1))
            Next
        End If
        'EliminarAcentos = texto
        Return texto
    End Function

    Public Sub LetrasyNumeros1(ByVal e)
        If Char.IsLetter(e.keychar) Or e.keychar = "." Or e.keychar = "," Or Char.IsDigit(e.KeyChar) Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
        ElseIf Char.IsSeparator(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub

    Public Sub LetrasyNumeros2(ByVal e)
        If Char.IsLetter(e.keychar) Or Char.IsDigit(e.KeyChar) Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
        ElseIf Char.IsSeparator(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub

    Public Sub LetrasyNumeros3(ByVal e)
        If Char.IsLetter(e.keychar) Or e.keychar = "_" Or e.keychar = "-" Or Char.IsDigit(e.KeyChar) Or e.keychar = "@" Or e.keychar = "." Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
        ElseIf Char.IsSeparator(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub

    Public Sub SoloLetras1(ByVal e)
        If Char.IsLetter(e.keychar) Or e.keychar = "." Or e.keychar = "," Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
        ElseIf Char.IsSeparator(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub

    Public Sub SoloLetras2(ByVal e)
        If Char.IsLetter(e.keychar) Then 'Or (e.KeyChar = ChrW(Keys.Right) Or e.KeyChar = ChrW(Keys.Left) Or e.KeyChar = ChrW(Keys.Up) Or e.KeyChar = ChrW(Keys.Down)) Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
        ElseIf Char.IsSeparator(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub

    Public Sub SoloNumeros(ByVal e)
        If Char.IsDigit(e.KeyChar) Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
        ElseIf Char.IsSeparator(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub

    Public Sub SoloNumeros2(ByVal e)
        If Char.IsDigit(e.KeyChar) Or e.keychar = "." Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
        ElseIf Char.IsSeparator(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub

    Public Sub SoloNumerosLetras(ByVal e)
        If Char.IsDigit(e.KeyChar) Then
            e.handled = False
        ElseIf Char.IsControl(e.keychar) Then
            e.handled = False
            'ElseIf Char.IsSeparator(e.keychar) Then
            '    e.handled = False
        ElseIf Char.IsLetter(e.keychar) Then
            e.handled = False
        Else
            e.handled = True
        End If
    End Sub


    Public Function EnLetras(Numero As String) As String
        Dim b, paso As Integer
        Dim expresion, entero, deci, flag As String
        b = 0
        paso = 0
        expresion = ""
        entero = ""
        deci = ""
        flag = ""
        Numero = Trim(Numero)
        flag = "N"
        For paso = 1 To Len(Numero)
            If Mid(Numero, paso, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(Numero, paso, 1) 'Extae la parte entera del numero
                Else
                    deci = deci + Mid(Numero, paso, 1) 'Extrae la parte decimal del numero
                End If
            End If
        Next paso

        If Len(deci) = 1 Then
            deci = deci & "0"
        End If

        flag = "N"
        If Val(Numero) >= -999999999 And Val(Numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999
            For paso = Len(entero) To 1 Step -1
                b = Len(entero) - (paso - 1)
                Select Case paso
                    Case 3, 6, 9
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then
                                    expresion = expresion & "cien "
                                Else
                                    expresion = expresion & "ciento "
                                End If
                            Case "2"
                                expresion = expresion & "doscientos "
                            Case "3"
                                expresion = expresion & "trescientos "
                            Case "4"
                                expresion = expresion & "cuatrocientos "
                            Case "5"
                                expresion = expresion & "quinientos "
                            Case "6"
                                expresion = expresion & "seiscientos "
                            Case "7"
                                expresion = expresion & "setecientos "
                            Case "8"
                                expresion = expresion & "ochocientos "
                            Case "9"
                                expresion = expresion & "novecientos "
                        End Select

                    Case 2, 5, 8
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    flag = "S"
                                    expresion = expresion & "diez "
                                End If
                                If Mid(entero, b + 1, 1) = "1" Then
                                    flag = "S"
                                    expresion = expresion & "once "
                                End If
                                If Mid(entero, b + 1, 1) = "2" Then
                                    flag = "S"
                                    expresion = expresion & "doce "
                                End If
                                If Mid(entero, b + 1, 1) = "3" Then
                                    flag = "S"
                                    expresion = expresion & "trece "
                                End If
                                If Mid(entero, b + 1, 1) = "4" Then
                                    flag = "S"
                                    expresion = expresion & "catorce "
                                End If
                                If Mid(entero, b + 1, 1) = "5" Then
                                    flag = "S"
                                    expresion = expresion & "quince "
                                End If
                                If Mid(entero, b + 1, 1) > "5" Then
                                    flag = "N"
                                    expresion = expresion & "dieci"
                                End If

                            Case "2"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "veinte "
                                    flag = "S"
                                Else
                                    expresion = expresion & "veinti"
                                    flag = "N"
                                End If

                            Case "3"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "treinta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "treinta y "
                                    flag = "N"
                                End If

                            Case "4"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cuarenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cuarenta y "
                                    flag = "N"
                                End If

                            Case "5"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cincuenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cincuenta y "
                                    flag = "N"
                                End If

                            Case "6"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "sesenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "sesenta y "
                                    flag = "N"
                                End If

                            Case "7"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "setenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "setenta y "
                                    flag = "N"
                                End If

                            Case "8"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "ochenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "ochenta y "
                                    flag = "N"
                                End If

                            Case "9"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "noventa "
                                    flag = "S"
                                Else
                                    expresion = expresion & "noventa y "
                                    flag = "N"
                                End If
                        End Select

                    Case 1, 4, 7
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If flag = "N" Then
                                    If paso = 1 Then
                                        expresion = expresion & "uno "
                                    Else
                                        expresion = expresion & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then
                                    expresion = expresion & "dos "
                                End If
                            Case "3"
                                If flag = "N" Then
                                    expresion = expresion & "tres "
                                End If
                            Case "4"
                                If flag = "N" Then
                                    expresion = expresion & "cuatro "
                                End If
                            Case "5"
                                If flag = "N" Then
                                    expresion = expresion & "cinco "
                                End If
                            Case "6"
                                If flag = "N" Then
                                    expresion = expresion & "seis "
                                End If
                            Case "7"
                                If flag = "N" Then
                                    expresion = expresion & "siete "
                                End If
                            Case "8"
                                If flag = "N" Then
                                    expresion = expresion & "ocho "
                                End If
                            Case "9"
                                If flag = "N" Then
                                    expresion = expresion & "nueve "
                                End If
                        End Select
                End Select
                If paso = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                       Len(entero) <= 6) Then
                        expresion = expresion & "mil "
                    End If
                End If
                If paso = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        expresion = expresion & "millón "
                    Else
                        expresion = expresion & "millones "
                    End If
                End If
            Next paso

            If deci <> "" Then
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion & " con " & deci ' & "/100"
                Else
                    EnLetras = expresion & " con " & deci ' & "/100"
                End If
            Else
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion
                Else
                    EnLetras = UCase(expresion)
                End If
            End If
        Else 'si el numero a convertir esta fuera del rango superior e inferior
            EnLetras = ""
        End If
    End Function

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Overloads Sub Dispose(disposing As Boolean)
        If disposed = False Then
            If disposing Then
                ' Free other state (managed objects).
                disposed = True
            End If
            ' Free your own state (unmanaged objects).
            ' Set large fields to null.
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    Public Function PrimerDiaDelMes(ByVal dtmFecha As Date) As Date
        PrimerDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha), 1)
    End Function

    Public Function UltimoDiaDelMes(ByVal dtmFecha As Date) As Date
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function

End Class
