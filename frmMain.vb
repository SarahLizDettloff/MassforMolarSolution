Imports System.ComponentModel

Public Class frmMain
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Enter the formula weight, select a volume, and select a concentration.", "Mass for Molar Solution Calculator")
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtWeight.Clear()
        lblMass.ResetText()
        cbConc.Text = "Pick a concentration"

        If rbLiter.Checked Then
            rbLiter.Checked = False
        End If
        If rbMicroliter.Checked Then
            rbMicroliter.Checked = False
        End If
        If rbMiliter.Checked Then
            rbMiliter.Checked = False
        End If
        If cbConc.SelectedIndex <> -1 Then
            cbConc.Text = "Pick a concentration"
        End If
        If cbConc.SelectedIndex = 0 Then
            cbConc.Text = "Pick a concentration"
        ElseIf cbConc.SelectedIndex = 1 Then
            cbConc.Text = "Pick a concentration"
        ElseIf cbConc.SelectedIndex = 2 Then
            cbConc.Text = "Pick a concentration"
        ElseIf cbConc.SelectedIndex = 3 Then
            cbConc.Text = "Pick a concentration"
        ElseIf cbConc.SelectedIndex = 4 Then
            cbConc.Text = "Pick a concentration"
        ElseIf cbConc.SelectedIndex = 5 Then
            cbConc.Text = "Pick a concentration"
        ElseIf cbConc.SelectedIndex = 6 Then
            cbConc.Text = "Pick a concentration"
        End If


    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Dim dblConc As Double = 0
        Dim dblVol As Double = 0
        Dim dblWeight As Double = 0
        Dim dblMass As Double = 0
        Dim dblUserAnswer As Double = 0.0
        Dim strDetails As String = ""
        If Double.TryParse(txtWeight.Text, dblWeight) = 0 Then
            MessageBox.Show("Please enter the formula weight.", "Input Error")
        End If
        strDetails += "Formula Weight : "
        If Double.TryParse(txtWeight.Text, dblWeight) Then
            strDetails += txtWeight.Text
            strDetails += vbCrLf + "Volume : "
            If rbLiter.Checked Then
                rbLiter.Checked = 1
                dblVol = 1
                strDetails += "Liter"
            ElseIf rbMiliter.Checked Then
                rbMiliter.Checked = 0.001
                dblVol = 0.001
                strDetails += "Militer"
            ElseIf rbMicroliter.Checked Then
                rbMiliter.Checked = 0.000001
                dblVol = 0.000001
                strDetails += "Microliter"
            Else
                MessageBox.Show("Please select a volume", "Input error")
                rbLiter.Focus()
            End If
        End If
        strDetails += vbCrLf + "Concentration : "
        If cbConc.SelectedIndex = 0 Then
            dblConc = 1
            strDetails += "Molar"
        ElseIf cbConc.SelectedIndex = 1 Then
            dblConc = 0.001
            strDetails += "Milmolar"
        ElseIf cbConc.SelectedIndex = 2 Then
            dblConc = 0.00001
            strDetails += "Micromolar"
        ElseIf cbConc.SelectedIndex = 3 Then
            dblConc = 0.000001
            strDetails += "Nanomolar"
        ElseIf cbConc.SelectedIndex = 4 Then
            dblConc = 0.0000000000001
            strDetails += "Picomolar"
        ElseIf cbConc.SelectedIndex = 5 Then
            dblConc = 0.00000000000001
            strDetails += "Femtomolar"
        Else
            MessageBox.Show("Please select a concentration", "Input error")
            txtWeight.Focus()
        End If

        dblConc = dblConc * dblVol
        dblMass = dblConc * dblWeight
        lblMass.Text = dblMass.ToString("")
        strDetails += vbCrLf + "Mass needed in grams : " + lblMass.Text
        MessageBox.Show(strDetails)
    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MessageBox.Show("This calculator allows you to discover the mass molarity of a compound which requires a concentration and volume. Scientists practice this equation in order to make solutions.
Formula weight is the sum of the atomic weights of every atom in a given empirical formula.
Molar concentration is the total amount of a solute present in one unit of a solution. Molar concentration is also known as molarity. 
The mass is important to know because it is the amount of matter present in a substance. Mass is different from weight, since it is not affected by gravity that makes the value constant.
In order to calculate the mass required for a molar solution follow this equation:
Mass (g) = Concentration (mol/L) * Volume (L) * Formular Weight (g/mol)
", "Why is this important?")
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim result As DialogResult
        result = MessageBox.Show(“Exit?”, “Confirmation Needed”, MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            e.Cancel = False
        Else
            MessageBox.Show(“Click the reset button to clear the screen.”, "Ready for more calculations?")
            e.Cancel = True
        End If
    End Sub

End Class
