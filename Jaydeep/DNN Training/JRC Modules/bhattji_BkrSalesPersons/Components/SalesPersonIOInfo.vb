Imports System
Imports System.Data

Namespace bhattji.Modules.BkrSalesPersons.Business

    Public Class SalesPersonIOInfo
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "
        Dim _SalesPersonId As Integer
        Dim _InterOfficeId As Integer

        Dim _SalesPersonName As String
        Dim _IOName As String

#End Region

#Region " Properties "
        Public Property SalesPersonId() As Integer
            Get
                Return _SalesPersonId
            End Get
            Set(ByVal Value As Integer)
                _SalesPersonId = Value
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


        Public Property SalesPersonName() As String
            Get
                Return _SalesPersonName
            End Get
            Set(ByVal Value As String)
                _SalesPersonName = Value
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



    Public Class SalesPersonIOsController
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

        'Public Function AddSalesPersonIO(ByVal objSalesPersonIO As SalesPersonIOInfo) As Integer
        '    With objSalesPersonIO
        '        Return CType(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_BkrAddSalesPersonIO", .SalesPersonId, .InterOfficeId), Integer)
        '        'Return DataProvider.Instance().AddSalesPersonIO(.ModuleId, .CreatedByUser, .Title, .NavURL, .ImgSrc, .ImgMoSrc, .ImgBgSrc, .ImgWidth, .ImgHeight, .ViewOrder, .Description, .AltText, .Player, .uiMode, .RepeatCount)
        '    End With
        'End Function
        Public Function AddSalesPersonIO(ByVal SalesPersonId As Integer, ByVal InterOfficeId As Integer) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_BkrAddSalesPersonIO", SalesPersonId, InterOfficeId))
        End Function

        Public Sub DeleteSalesPersonIO(ByVal SalesPersonId As Integer, ByVal InterOfficeId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_BkrDeleteSalesPersonIO", SalesPersonId, InterOfficeId)
            'DataProvider.Instance().DeleteSalesPersonIO(ItemID)
        End Sub

        Public Sub AssignSalesPersonIO()
            DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_BkrAssignSalesPersonIO")
        End Sub
        'Public Function GetSalesPersonIO(ByVal ItemID As Integer) As SalesPersonIOInfo
        '    ''''Return CType(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrGetSalesPersonIO", ItemID), SalesPersonIOInfo)
        '    Return CType(CBO.FillObject(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrGetSalesPersonIO", ItemID), GetType(SalesPersonIOInfo)), SalesPersonIOInfo)
        '    'Return CType(CBO.FillObject(DataProvider.Instance().GetSalesPersonIO(ItemID), GetType(SalesPersonIOInfo)), SalesPersonIOInfo)
        'End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()
        'Public Function GetSalesPersonIOs(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
        '    Select Case GetItems
        '        Case 0
        '            If ModuleId > -1 Then
        '                Return GetModuleSalesPersonIOs(ModuleId)
        '            Else
        '                Return GetAllSalesPersonIOs()
        '            End If
        '        Case 1
        '            If PortalId > -1 Then
        '                Return GetPortalSalesPersonIOs(PortalId)
        '            Else
        '                Return GetAllSalesPersonIOs()
        '            End If
        '        Case 2
        '            Return GetAllSalesPersonIOs()
        '        Case Else '0
        '            If PortalId > -1 Then
        '                Return GetPortalSalesPersonIOs(PortalId)
        '            ElseIf ModuleId > -1 Then
        '                Return GetModuleSalesPersonIOs(ModuleId)
        '            Else
        '                Return GetAllSalesPersonIOs()
        '            End If
        '    End Select
        'End Function

        Public Function GetSalesPersonsByIO(ByVal InterOfficeId As Integer) As IDataReader 'ArrayList
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrGetSalesPersonsByIO", InterOfficeId)
            'Return CBO.FillCollection(DataProvider.Instance().GetModuleSalesPersonIOs(ModuleId), GetType(SalesPersonIOInfo))
        End Function

        Public Function GetIOsBySalesPerson(ByVal SalesPersonId As Integer) As ArrayList 'IDataReader '
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrGetIOsBySalesPerson", SalesPersonId), GetType(SalesPersonIOInfo))
            'Return CBO.FillCollection(DataProvider.Instance().GetModuleSalesPersonIOs(ModuleId), GetType(SalesPersonIOInfo))
        End Function

        Public Function GetSalesPersonsByIO() As IDataReader 'ArrayList
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrGetSalesPersonsAll")
            'Return CBO.FillCollection(DataProvider.Instance().GetModuleSalesPersonIOs(ModuleId), GetType(SalesPersonIOInfo))
        End Function

        Public Function GetIOsBySalesPerson() As ArrayList 'IDataReader '
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrGetIOsAll")
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrGetIOsAll"), GetType(SalesPersonIOInfo))
            'Return CBO.FillCollection(DataProvider.Instance().GetModuleSalesPersonIOs(ModuleId), GetType(SalesPersonIOInfo))
        End Function

#End Region

    End Class 'SalesPersonsController

End Namespace
