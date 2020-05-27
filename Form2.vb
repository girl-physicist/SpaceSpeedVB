Imports System.Data.SqlClient

Public Class Form2
    Dim _planetName As String
    Dim _m As Double
    Dim _r As Double

    Private Sub GetInfo()
        _planetName = TextBox1.Text
        _m = Double.Parse(TextBox2.Text)
        _r = Double.Parse(TextBox3.Text)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetInfo()
        PlanetsTableAdapter.Insert(_planetName,_m,_r)
      
     

 
    End Sub





    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "SpaceDataSet.Planets". При необходимости она может быть перемещена или удалена.
        Me.PlanetsTableAdapter.Fill(Me.SpaceDataSet.Planets)

    End Sub

End Class