Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class LoadSheetsController
    Public Function GetCommand(ByVal strCmd As String, Optional ByVal CmdType As CommandType = CommandType.StoredProcedure) As SqlCommand
        Dim strConn As String = ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString
        Dim Conn As New SqlConnection(strConn)
        Conn.Open()
        Dim Cmd As New SqlCommand(strCmd, Conn)
        Cmd.CommandType = CmdType

        Return Cmd
    End Function

    Public Function GetLoadId(ByVal ItemId As Integer) As String
        Dim strCmd As String = "bhattji_GetLoadIdByItemId"
        Dim Cmd As SqlCommand = GetCommand(strCmd)
        Cmd.Parameters.AddWithValue("ItemId", ItemId)

        Return Convert.ToString(Cmd.ExecuteScalar())
    End Function
    Public Function GetLoadConfirmHeader(ByVal ItemId As Integer) As DataTable
        Dim strConn As String = ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString
        Dim Conn As New SqlConnection(strConn)
        Conn.Open()


        Dim strCmd As String = "bhattji_GetLoadConfirmHeader"
        'Dim Cmd As New SqlCommand(strCmd, Conn)
        Dim Cmd As SqlCommand = GetCommand(strCmd)
        Cmd.Parameters.AddWithValue("ItemId", ItemId)

        Dim dt As New DataTable
        dt.Load(Cmd.ExecuteReader())
        Return dt
    End Function
    Public Function GetReportLoadPUByLoadId(ByVal LoadId As String) As DataTable
        Dim strCmd As String = "bhattji_GetLoadPUByLoadId"
        Dim Cmd As SqlCommand = GetCommand(strCmd)
        Cmd.Parameters.AddWithValue("LoadId", LoadId)

        Dim dt As New DataTable
        dt.Load(Cmd.ExecuteReader())
        Return dt
    End Function
    Public Function GetReportLoadDropByLoadId(ByVal LoadId As String) As DataTable
        Dim strCmd As String = "bhattji_GetLoadDropByLoadId"
        Dim Cmd As SqlCommand = GetCommand(strCmd)
        Cmd.Parameters.AddWithValue("LoadId", LoadId)

        Dim dt As New DataTable
        dt.Load(Cmd.ExecuteReader())
        Return dt
    End Function

End Class
