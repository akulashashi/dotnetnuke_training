Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

'Add Namespace references
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports DotNetNuke.Common.Utilities

Namespace bhattji.Modules.LoadSheets
    'Don't forget to add System.Web.Script.Services.ScriptService attribute
    <System.Web.Script.Services.ScriptService()> _
    <WebService(Namespace:="http://tempuri.org/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Public Class WebService
        Inherits System.Web.Services.WebService

        'String List for return
        Protected returnStr As New List(Of String)

        'Web Method would be called by auto complete extender
        <WebMethod()> _
        Public Function GetListOfCities(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Try
                Dim sql As String = "SELECT DISTINCT TOP " & count.ToString() & " City " & _
                                    "FROM bhattji_ZipCodes " & _
                                    "WHERE City LIKE  '" & prefixText & "%' " & _
                                    "ORDER BY City"

                'Get DB Connection
                Dim connectionString As String = Config.GetConnectionString()
                Dim conn As New SqlConnection(connectionString)

                Dim ds As DataSet = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql)

                Dim row As DataRow

                For Each row In ds.Tables(0).Rows
                    returnStr.Add(row("City").ToString())
                Next

            Catch ex As Exception
                returnStr.Add(ex.Message)
            End Try

            Return returnStr

        End Function

        'Web Method would be called by auto complete extender
        <WebMethod()> _
        Public Function GetCityList(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Return (New Business.ZipCodesController).GetCityList(prefixText, count)
        End Function

        'Web Method would be called by auto complete extender
        <WebMethod()> _
        Public Function GetCityNames(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Return (New Business.ZipCodesController).GetCityNames(prefixText, count)
        End Function

        'Web Method would be called by auto complete extender
        <WebMethod()> _
        Public Function GetCustomerNames(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Return (New Business.ZipCodesController).GetCustomerNames(prefixText, count)
        End Function

        'Web Method would be called by auto complete extender
        <WebMethod()> _
        Public Function GetBrokerNames(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
            Return (New Business.ZipCodesController).GetBrokerNames(prefixText, count)
        End Function


        'http://www.asp.net/AJAX/AjaxControlToolkit/Samples/AutoComplete/AutoComplete.aspx
        'Web Method would be called by auto complete extender
        '<System.Web.Script.Services.ScriptMethod()> _
        <System.Web.Services.WebMethod()> _
        Public Function GetDriverNames(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As List(Of String) 'String()
            'Return (New Business.ZipCodesController).GetDriverNames(prefixText, count, contextKey).ToArray() '.ToArray() will Convert List(Of String) to String()
            Return (New Business.ZipCodesController).GetDriverNames(prefixText, count, contextKey)
        End Function
    End Class
End Namespace
