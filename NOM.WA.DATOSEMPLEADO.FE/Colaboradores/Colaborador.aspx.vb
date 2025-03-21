Imports System.Net.Http
Imports System.Web.Script.Serialization

Public Class Colaborador
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ObtenerColaboradoresAPI()
    End Sub

    <System.Web.Services.WebMethod>
    Private Shared Function ObtenerColaboradoresAPI() As String
        Dim client As New HttpClient()
        Dim strUrlApi As String = "https://localhost:44399/api/Colaboradores"
        Dim strJsonColaboradores As String
        Dim lstResultado As New List(Of ColaboradoresEtiqueta)

        Try
            Dim respuesta As HttpResponseMessage = client.GetAsync(strUrlApi).Result

            If respuesta.IsSuccessStatusCode Then
                strJsonColaboradores = respuesta.Content.ReadAsStringAsync().Result
            End If

            Dim serializer As New JavaScriptSerializer()
            Dim strColaborador As List(Of colaborador) = serializer.Deserialize(Of List(Of colaborador))(strJsonColaboradores)

            For Each c As colaborador In strColaborador
                Dim strEtiqueta As String = ""

                If c.strEdad >= 18 AndAlso c.strEdad <= 25 Then
                    strEtiqueta = "FUERA DE PELIGRO"
                ElseIf c.strEdad >= 26 AndAlso c.strEdad <= 50 Then
                    strEtiqueta = "TENGA CUIDADO, TOME TODAS LAS MEDIDAS DE PREVENSION"
                ElseIf c.strEdad >= 51 Then
                    strEtiqueta = "POR FAVOR QUEDARSE EN CASA"
                End If

                lstResultado.Add(New ColaboradoresEtiqueta With {
                    .intIdColaborador = c.intIdColaborador,
                    .strNombre = c.strNombre,
                    .strApellido = c.strApellido,
                    .strDireccion = c.strDireccion,
                    .strEdad = c.strEdad,
                    .strProfesion = c.strProfesion,
                    .strEstadoCivil = c.strEstadoCivil,
                    .strEtiqueta = strEtiqueta
                })
            Next

        Catch ex As AggregateException
            ' Captura excepciones internas de Task
            For Each innerEx As Exception In ex.InnerExceptions
                Console.WriteLine("Error interno: " & innerEx.Message)
            Next
        Catch ex As Exception
            Return "[]"
        End Try

        Dim jsonResultado As String = (New JavaScriptSerializer()).Serialize(lstResultado)
        Return jsonResultado

    End Function

    Public Class colaborador
        Public intIdColaborador As Integer
        Public Property strNombre As String
        Public Property strApellido As String
        Public Property strDireccion As String
        Public Property strEdad As String
        Public Property strProfesion As String
        Public Property strEstadoCivil As String
    End Class
    Public Class ColaboradoresEtiqueta
        Public intIdColaborador As Integer
        Public Property strNombre As String
        Public Property strApellido As String
        Public Property strDireccion As String
        Public Property strEdad As String
        Public Property strProfesion As String
        Public Property strEstadoCivil As String
        Public Property strEtiqueta As String
    End Class

End Class