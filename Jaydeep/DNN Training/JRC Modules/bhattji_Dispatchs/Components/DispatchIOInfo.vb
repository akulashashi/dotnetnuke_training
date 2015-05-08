Imports System
Imports System.Data

Namespace bhattji.Modules.Dispatchs.Business

    Public Class DispatchIOInfo
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "
        Dim _DispatcherId As Integer
        Dim _InterOfficeId As Integer

        Dim _DispatchName As String
        Dim _IOName As String

#End Region

#Region " Properties "
        Public Property DispatcherId() As Integer
            Get
                Return _DispatcherId
            End Get
            Set(ByVal Value As Integer)
                _DispatcherId = Value
            End Set
        End Property

        Public Property InterOfficeId() As Integer
            Get
                Return _InterOfficeId
            End Get
            Set(ByVal Value As Integer)
                _InterOfficeId = Value
            End Set
        End Property


        Public Property DispatchName() As String
            Get
                Return _DispatchName
            End Get
            Set(ByVal Value As String)
                _DispatchName = Value
            End Set
        End Property

        Public Property IOName() As String
            Get
                Return _IOName
            End Get
            Set(ByVal Value As String)
                _IOName = Value
            End Set
        End Property


#End Region

#Region " Constructors "
        Public Sub New()
        End Sub
#End Region

    End Class



    Public Class DispatchIOsController
        'Implements Entities.Modules.ISearchable
        'Implements Entities.Modules.IPortable

#Region " Public Methods "

        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
        '---------------------------------------------------------------------
        ' TODO Implement BLL methods
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

        'Public Function AddDispatchIO(ByVal objDispatchIO As DispatchIOInfo) As Integer
        '    With objDispatchIO
        '        Return CType(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_AddDispatcherIO", .DispatcherId, .InterOfficeId), Integer)
        '        'Return DataProvider.Instance().AddDispatchIO(.ModuleId, .CreatedByUser, .Title, .NavURL, .ImgSrc, .ImgMoSrc, .ImgBgSrc, .ImgWidth, .ImgHeight, .ViewOrder, .Description, .AltText, .Player, .uiMode, .RepeatCount)
        '    End With
        'End Function
        Public Function AddDispatchIO(ByVal DispatcherId As Integer, ByVal InterOfficeId As Integer) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_AddDispatcherIO", DispatcherId, InterOfficeId))
        End Function

        Public Sub DeleteDispatchIO(ByVal DispatcherId As Integer, ByVal InterOfficeId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_DeleteDispatcherIO", DispatcherId, InterOfficeId)
            'DataProvider.Instance().DeleteDispatchIO(ItemID)
        End Sub





        'Public Function GetDispatchIO(ByVal ItemID As Integer) As DispatchIOInfo
        '    ''''Return CType(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetDispatchIO", ItemID), DispatchIOInfo)
        '    Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetDispatchIO", ItemID), GetType(DispatchIOInfo)), DispatchIOInfo)
        '    'Return CType(CBO.FillObject(DataProvider.Instance().GetDispatchIO(ItemID), GetType(DispatchIOInfo)), DispatchIOInfo)
        'End Function

        'This function retreives the Items from Database, 
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()
        'Public Function GetDispatchIOs(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
        '    Select Case GetItems
        '        Case 0
        '            If ModuleId > -1 Then
        '                Return GetModuleDispatchIOs(ModuleId)
        '            Else
        '                Return GetAllDispatchIOs()
        '            End If
        '        Case 1
        '            If PortalId > -1 Then
        '                Return GetPortalDispatchIOs(PortalId)
        '            Else
        '                Return GetAllDispatchIOs()
        '            End If
        '        Case 2
        '            Return GetAllDispatchIOs()
        '        Case Else '0
        '            If PortalId > -1 Then
        '                Return GetPortalDispatchIOs(PortalId)
        '            ElseIf ModuleId > -1 Then
        '                Return GetModuleDispatchIOs(ModuleId)
        '            Else
        '                Return GetAllDispatchIOs()
        '            End If
        '    End Select
        'End Function

        Public Function GetDispatchersByIO(ByVal InterOfficeId As Integer) As ArrayList
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetDispatchersByIO", InterOfficeId), GetType(DispatchIOInfo))
            'Return CBO.FillCollection(DataProvider.Instance().GetModuleDispatchIOs(ModuleId), GetType(DispatchIOInfo))
        End Function

        Public Function GetIOsByDispatcher(ByVal DispatcherId As Integer) As ArrayList
            ''Return CBO.FillCollection(DataProvider.Instance().GetModuleDispatchIOs(ModuleId), GetType(DispatchIOInfo))
            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetIOsByDispatcher", DispatcherId), GetType(DispatchIOInfo))
            Dim al As ArrayList = CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetIOsByDispatcher", DispatcherId), GetType(DispatchIOInfo))
            If Not al Is Nothing Then
                Dim IO As String
                For Each DIO As DispatchIOInfo In al
                    'If DIO.IOName.Contains("N/A") Then
                    '    al.Remove(DIO)
                    'Else
                    IO = Replace(DIO.IOName, "JRC - ", "").ToUpper
                    IO = Replace(IO, "JRC ", "").ToUpper
                    DIO.IOName = IO.ToUpper
                    'End If
                Next
                'al.Sort()
            End If
            Return al
        End Function


        Public Function GetDispatchersByIO() As ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().GetModuleDispatchIOs(ModuleId), GetType(DispatchIOInfo))
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetDispatchersAll"), GetType(DispatchIOInfo))
        End Function

        Public Function GetIOsByDispatcher() As ArrayList
            ''Return CBO.FillCollection(DataProvider.Instance().GetModuleDispatchIOs(ModuleId), GetType(DispatchIOInfo))
            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetIOsAll"), GetType(DispatchIOInfo))
            Dim al As ArrayList = CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetIOsAll"), GetType(DispatchIOInfo))
            If Not al Is Nothing Then
                Dim IO As String
                For Each DIO As DispatchIOInfo In al
                    'If DIO.IOName.Contains("N/A") Then
                    '    al.Remove(DIO)
                    'Else
                    IO = Replace(DIO.IOName, "JRC - ", "").ToUpper
                    IO = Replace(IO, "JRC ", "").ToUpper
                    DIO.IOName = IO.ToUpper
                    'End If
                Next
                'al.Sort()
            End If
            Return al
        End Function

        Public Function GetInterOfficeId(ByVal JRCIOfficeCode As String) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetInterOfficeId", JRCIOfficeCode))
        End Function

#End Region

    End Class 'DispatchsController

End Namespace
