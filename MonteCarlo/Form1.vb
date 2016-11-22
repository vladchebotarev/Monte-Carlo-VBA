Public Class Form1

    Private Function g_x(x As Double) As Double
        Return Math.Abs(Math.Sin(x))
    End Function

    Private Function f_x(x As Double) As Double
        Return Math.Abs(Math.Sin(x)) * (-1)
    End Function

    Private Function generuj(low As Double, up As Double) As Double
        Return Rnd() * (up - low) + low
    End Function

    Private Function Monte_Carlo(low As Double, up As Double) As Double
        Dim dx, krok, N, Npunkt, x, y, Max, Min As Double
        dx = up - low
        krok = dx / 1000000
        N = 10000000
        Max = 0
        Min = 0
        Npunkt = 0
        For x = low To up Step krok
            If (g_x(x) >= Max) Then
                Max = g_x(x)
            End If
            If (f_x(x) <= Min) Then
                Min = f_x(x)
            End If
        Next

        Dim i As Integer


        For i = 1 To N Step 1
            x = generuj(low, up)
            y = generuj(Min, Max)
            If ((g_x(x) >= y) And (f_x(x) <= y)) Then
                Npunkt += 1
            End If
            If ((g_x(x) < y) And (f_x(x) > y)) Then
                Npunkt -= 1
            End If

        Next

        
        Return (Npunkt / N) * dx * (Max - Min)


    End Function

    

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Try
            Label4.Text = Convert.ToString(Math.Round(Monte_Carlo(Convert.ToDouble(TextBox1.Text), Convert.ToDouble(TextBox2.Text)), 4))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
End Class
