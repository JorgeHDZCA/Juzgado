Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load




    End Sub

    Private Sub Btn_Entrar_Click(sender As Object, e As EventArgs) Handles Btn_Entrar.Click
        If (TxtClave.Text = "") Then
            MessageBox.Show("ingrese su clave")
            TxtClave.Focus()
        Else
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim fecha = DtpF.Value.ToString("yyyy/mm/dd")
                Variables.Query = "insert into Asistencia(Fecha,Estado,id_cliente)'" + fecha + "',1" + TxtClave.Text + ""
                Using comando As New SqlCommand(Query, connection)
                    comando.Parameters.AddWithValue("fecha", fecha)
                    comando.Parameters.AddWithValue("id_cliente", TxtClave.Text)
                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()
                    If filasAfectadas > 0 Then
                        MessageBox.Show("Asistencia Registrada")
                    Else
                        MessageBox.Show("No se pudo insertar la asistencia")
                    End If
                End Using
            End Using
        End If
    End Sub
End Class
