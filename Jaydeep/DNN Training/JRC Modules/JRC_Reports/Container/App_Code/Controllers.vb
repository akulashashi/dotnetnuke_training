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

    Public Function GetReportContainer(ByVal JRCIOfficeCode As String) As DataTable
        Dim strConn As String = ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString
        Dim Conn As New SqlConnection(strConn)
        Conn.Open()

        Dim MySqlString As String = String.Empty
        MySqlString &= "SELECT "
        MySqlString &= "TOP 100 "
        ' MySqlString &= "x.* "
        MySqlString &= "x.ItemId, "
        MySqlString &= "x.LoadID, "
        MySqlString &= "x.LoadDate, "
        MySqlString &= "x.DeliveryDate, "
        MySqlString &= "cn.CustomerName, "
        MySqlString &= "x.CustPO, "
        MySqlString &= "x.LoadType, "
        MySqlString &= "'CarrierName'= CASE WHEN (x.LoadType='BK') THEN bk.BrokerName ELSE sp.DriverName END, "
        'MySqlString &= "x.CarrierName, "
        MySqlString &= "x.BkrInvNo, "
        MySqlString &= "bk.BkrType, "
        MySqlString &= "la.GPPct, "
        MySqlString &= "la.BCustBill, "
        MySqlString &= "la.JRCOffComm, "
        MySqlString &= "la.IOOffL1, "
        MySqlString &= "x.JRCIOfficeCode, "
        MySqlString &= "x.XMissionFile, "
        MySqlString &= "'XCount'=(SELECT Count(*) From tblOOLoadSheetHeader Where XmissionFile = x.XmissionFile ), "
        MySqlString &= "x.CodCheckSeq, "
        'MySqlString &= "x.DispatchCode, "
        MySqlString &= "'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN x.DispatchCode ELSE dm.DispatchName END, "
        MySqlString &= "x.XMissionDate "

        MySqlString &= "FROM tblOOLoadSheetHeader AS x "
        MySqlString &= "LEFT OUTER JOIN ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "
        MySqlString &= "LEFT OUTER JOIN tblLoadAcct As la ON x.LoadID=la.LoadID "
        MySqlString &= "LEFT OUTER JOIN AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
        MySqlString &= "LEFT OUTER JOIN ARD_SalesPersonMasterfile AS sp ON x.DriverCode=sp.DriverCode "
        MySqlString &= "LEFT OUTER JOIN ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
        'MySqlString &= "LEFT OUTER JOIN ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
        'MySqlString &= "LEFT OUTER JOIN ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "



        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        'If LoadStatus = "" Then
        '    MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
        '    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
        'Else
        '    MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
        'End If

        MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "

        MySqlString &= "ORDER BY x.JRCIOfficeCode, x.XMissionDate desc, x.LoadId "

        Dim strCmd As String = MySqlString

        Dim Cmd As New SqlCommand(strCmd, Conn)

        Dim dt As New DataTable
        dt.Load(Cmd.ExecuteReader)
        Return dt
    End Function

End Class
