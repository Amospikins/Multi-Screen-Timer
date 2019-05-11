
Public Class Form1
    Public minutes As Integer
    Public seconds As Integer
    Public countermins As Integer = 0
    Public countersecs As Integer = 0

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        control_panel2.Button2.Image = My.Resources.offline1
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrCountDown.Start()
        Label3.Text = CStr(TimeOfDay)
        tmrcolor1.Start()
        Timer1.Start()
        Label4.Visible = False


    End Sub

    Private Sub tmrCountDown_Tick(sender As Object, e As EventArgs) Handles tmrCountDown.Tick
        logic()
        If minutes = 0 And seconds = 0 Then
            Label2.Text = control_panel2.cboaftercountdown.Text
            Label3.Visible = False
            tmrCountUp.Start()
            Label4.Visible = True
            tmrCountDown.Stop()

        End If

    End Sub

    Private Sub logic()
        seconds -= 1
        If seconds < 0 And minutes > 0 Then
            minutes = minutes - 1
            seconds = 59
        End If
        If seconds.ToString.Length < 2 And minutes.ToString.Length < 2 Then
            Label1.Text = "0" & minutes & ":" & "0" & seconds
        End If
        If seconds.ToString.Length < 2 And minutes.ToString.Length > 1 Then
            Label1.Text = minutes & ":" & "0" & seconds
        End If
        If seconds.ToString.Length > 1 And minutes.ToString.Length < 2 Then
            Label1.Text = "0" & minutes & ":" & seconds
   
        End If
        If seconds.ToString.Length > 1 And minutes.ToString.Length > 1 Then
            Label1.Text = minutes & ":" & seconds
        End If

    End Sub
    Private Sub tmrCountUp_Tick(sender As Object, e As EventArgs) Handles tmrCountUp.Tick
        logic2()
    End Sub
    Private Sub logic2()
        countersecs += 1
        If countersecs > 59 And countermins >= 0 Then
            countermins = countermins + 1
            countersecs = 0
        End If
        If countersecs.ToString.Length < 2 And countermins.ToString.Length < 2 Then
            Label4.Text = "Used Time:- " & "0" & countermins & ":" & "0" & countersecs
        End If
        If countersecs.ToString.Length < 2 And countermins.ToString.Length > 1 Then
            Label4.Text = "Used Time:- " & countermins & ":" & "0" & countersecs
        End If
        If countersecs.ToString.Length > 1 And countermins.ToString.Length < 2 Then
            Label4.Text = "Used Time:- " & "0" & countermins & ":" & countersecs
        End If

    End Sub

    Private Sub tmrcolor1_Tick(sender As Object, e As EventArgs) Handles tmrcolor1.Tick
        If minutes <= 0 And seconds < 60 Then
            Label2.ForeColor = Color.Black
            Label1.ForeColor = Color.Black
            tmrcolor2.Start()
            tmrcolor1.Stop()
        End If
        tmrcolor2.Start()
        tmrcolor1.Stop()
    End Sub

    Private Sub tmrcolor2_Tick(sender As Object, e As EventArgs) Handles tmrcolor2.Tick
        If minutes <= 0 And seconds < 60 Then
            Label2.ForeColor = Color.Red
            Label1.ForeColor = Color.Red
            tmrcolor2.Stop()
            tmrcolor1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = CStr(TimeOfDay)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub


End Class
