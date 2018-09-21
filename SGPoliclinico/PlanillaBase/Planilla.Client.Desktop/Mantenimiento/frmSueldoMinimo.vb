Imports Planilla.Client.Utils.clsUtils
Imports Planilla.Business.Entities
Public Class frmSueldoMinimo

    Private Sub txtMonto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemuneracionBasica.KeyDown
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
            oTextBox.Text = "0.00"
        End If

    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemuneracionBasica.KeyPress

        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        If InStr(1, "0123456789." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        Else
            Try
                Dim vCapturar As Boolean = False
                Dim vCharCode As Char = ""
                Validar_NumericoV(oTextBox, e.KeyChar, vCapturar)
                e.Handled = vCapturar
            Catch ex As Exception

                e.Handled = True
                oTextBox.Text = "0.00"
            End Try

        End If
    End Sub

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemuneracionBasica.Leave
        Dim oTextBox As TextBox = DirectCast(sender, TextBox)
        If oTextBox.Text.Trim.Length = 0 Then
            oTextBox.Text = "0.00"
        End If
    End Sub

    Private Sub frmSueldoMinimo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtRemuneracionBasica.Text = Planilla.Business.Entities.Properties.Settings.Default.SueldoMinimo
        Me.ActiveControl = Me.txtRemuneracionBasica
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Planilla.Business.Entities.Properties.Settings.Default.SueldoMinimo = Me.txtRemuneracionBasica.Text
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub
End Class