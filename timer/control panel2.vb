Public Class control_panel2
    Dim holdmin As Integer
    Dim holdsec As Integer
    Public Structure side
        Public Left As Integer
        Public Right As Integer
        Public Top As Integer
        Public Bottom As Integer
    End Structure
    Private Sub upload()
        Try
            Dim open As New OpenFileDialog()
            open.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp"
            If open.ShowDialog() = DialogResult.OK Then
                Dim fileName As String = System.IO.Path.GetFullPath(open.FileName)
                Me.PictureBox4.Image = New Bitmap(open.FileName)
                Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label11.ForeColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        If ColorDialog2.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label12.ForeColor = ColorDialog2.Color
        End If
    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click

    End Sub

    Private Sub Control_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set timer and test
        Dim dateFile As String = "\Data.txt"
        Dim filePath As String = My.Computer.FileSystem.SpecialDirectories.Programs
        Dim fullPathAndFilename As String = filePath & dateFile

        Dim dateFromFile As Date
        Dim ts As TimeSpan

        'See if the file exists.>>
        If System.IO.File.Exists(fullPathAndFilename) = True Then

            Using sr As New System.IO.StreamReader(fullPathAndFilename)
                'Try to read the date from the file.>>
                Date.TryParse(sr.ReadLine, dateFromFile)
                'Subtract the date in the file from the Date NOW!! >>
                ts = Now.Subtract(dateFromFile)
                'An average year is 365.25 days allowing for leap years.>>
                If ts.TotalDays > 365.25 Then
                    Dim result As DialogResult = MessageBox.Show("Software Subscription expired, sorry. Contact developer on beulahpikins@gmail.com or +2347069503705")
                    If result = Windows.Forms.DialogResult.OK Or result = Windows.Forms.DialogResult.Cancel Then
                        sr.Close()
                        End
                    End If
                Else
                    'Do nothing more!!
                End If
                sr.Close()
            End Using

            'Write the date to the file if it does not exist.>>
        ElseIf System.IO.File.Exists(fullPathAndFilename) = False Then
            Using sw As New System.IO.StreamWriter(fullPathAndFilename)
                sw.WriteLine(Now.ToLongDateString & " " & Now.ToLongTimeString)
                sw.Close()
            End Using
        End If

        Try
            Me.BackColor = Color.Black
            Dim side As side = New side
            side.Left = -1
            side.Right = -1
            side.Top = -1
            side.Bottom = -1

        Catch ex As Exception

        End Try

        Timer1.Start()

        Scrn()
        CboScn.SelectedIndex = 0
        cboaftercountdown.SelectedIndex = 0
        cboduringcountdown.SelectedIndex = 0
        RadioButton1.Checked = True
    End Sub
    Private Sub Scrn()
        For Each scren In Screen.AllScreens
            With CboScn.Items
                .Add(scren.DeviceName)
            End With
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        CboScn.SelectedIndex = -1
        Scrn()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Form1.Label4.Visible = False
        Form1.Label3.Visible = True
        Form1.countermins = 0
        Form1.countersecs = 0
        Form1.tmrCountUp.Stop()
        Form1.tmrCountDown.Start()
        If txtMinutes.Text = String.Empty Or txtSeconds.Text = String.Empty Then
            MessageBox.Show("Please enter all fields", "Timer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtSeconds.Text > 60 Then
            MessageBox.Show("Seconds can't be greater than 60 secs", "Timer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtMinutes.Text > 99 Then
            MessageBox.Show("Minutes can't be greater than 99 Minutes", "Timer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf ReferenceEquals(PictureBox4.Image, My.Resources.camera) And RadioButton2.Checked = True Then
            MessageBox.Show("Insert a background image of you want an image as a background", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If RadioButton1.Checked = True Then
            Form1.BackColor = Panel5.BackColor
        ElseIf RadioButton2.Checked = True Then
            Form1.BackgroundImage = Me.PictureBox4.Image
            Form1.BackgroundImageLayout = ImageLayout.Stretch
        End If
        Dim scren As Screen
        'Show the form on second screen
        For Each item In CboScn.SelectedItem
            Button2.Image = My.Resources.LiveIcon1
            Form1.minutes = Val(txtMinutes.Text)
            Form1.seconds = Val(txtSeconds.Text)
            Form1.Label2.Text = cboduringcountdown.Text
            Form1.Label2.ForeColor = Label11.ForeColor
            Form1.Label3.ForeColor = Label11.ForeColor
            Form1.Label1.ForeColor = Label12.ForeColor
            scren = Screen.AllScreens(CboScn.SelectedIndex)
            Form1.StartPosition = FormStartPosition.Manual
            Form1.Location = scren.Bounds.Location + New Point(100, 100)
            Form1.Show()
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Close()
        Button2.Image = My.Resources.offline1
    End Sub

    Private Sub txtMinutes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinutes.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If

    End Sub

    Private Sub txtSeconds_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSeconds.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        upload()
    End Sub


    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        If ColorDialog3.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Panel5.BackColor = ColorDialog3.Color
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        End
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        tes.ShowDialog()
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class