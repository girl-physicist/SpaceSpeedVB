Imports System.Math
Public Class Form1

    Const G As Double = 0.00000000006672

    Dim _id As Int16
    Dim _h As Double
    Dim _m As Double
    Dim _r As Double
    Dim _v1 As Double
    Dim _v2 As Double
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fm2 As New Form2
        fm2.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "SpaceDataSet1.Planets". При необходимости она может быть перемещена или удалена.
        Me.PlanetsTableAdapter.Fill(Me.SpaceDataSet.Planets)

    End Sub


    Private Sub GetPlanetInfo()
        Try
            _id = Int16.Parse(ComboBox1.SelectedValue)
            _h = Double.Parse(TextBox3.Text)
        Catch ex As Exception
            MsgBox("")
        End Try
      
        Dim planets = PlanetsTableAdapter.GetData()
       ' LINQ
        'Dim rows = From planet In planets
        '           Where planet.ID = _id
        '           Select planet.M, planet.R

        'лямбда-выражение
        Dim rows1 = planets.Where(Function(p) p.ID=_id)

        For Each row As Object In rows1
            _m = row.M
            _r = row.R
        Next
        


    End Sub

    Private Sub CalcVelocity()
        _v1 = Sqrt((G * _m) / (_r + _h))
        _v2 = _v1 * Sqrt(2)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GetPlanetInfo()
        MsgBox("Данные успешно загружены")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CalcVelocity()
        TextBox1.Text = _v1.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CalcVelocity()
        TextBox2.Text = _v2.ToString()
    End Sub
End Class
