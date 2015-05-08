Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.SalesPersons.Business

    Public Class SalesPersonInfo
        Implements IHydratable
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ModuleId As Integer

        Private _driverCode As String
        Private _driverName As String
        Private _dLastName As String
        Private _dFirstName As String
        Private _addressLine1 As String
        Private _addressLine2 As String
        Private _addressLine3 As String
        Private _city As String
        Private _state As String
        Private _zipCode As String
        Private _countryCode As String
        Private _phoneNo As String
        Private _ext As String
        Private _emailAddress As String
        Private _commRate As Double
        Private _adminExempt As String
        Private _status As String
        Private _driverNotes As String
        Private _loadType As String
        Private _lastLoad As DateTime
        Private _safetyAuth As String
        Private _cellPhone As String
        Private _pager As String
        Private _accountNo As String
        Private _officeOwner As String
        Private _IOName As String
        Private _faxNo As String
        Private _jRCTrailer As String
        Private _lastLoadID As String
        Private _lastPU As String
        Private _lastDP As String
        Private _safetyNotes As String
        Private _lastTrailerUsed As String
        Private _lastLoadDeliv As DateTime
        Private _drugDate As DateTime
        Private _licenceDate As DateTime
        Private _truckInsDate As DateTime
        Private _trailerInsDate As DateTime
        Private _regRenewDate As DateTime
        Private _newLeaseDate As DateTime
        Private _InactivateDate As DateTime
        Private _medicalDate As DateTime
        Private _logBookOS As String

        Private _MoMaint As Date
        Private _DotInspec As Date
        Private _TrailerMaint As Date
        Private _RegRenew As Date
        Private _OccIns As Date
        Private _NtlIns As Date
        Private _PhysDmg As Date
        Private _SeaLink As Date
        Private _AnnIns As Date
        Private _ProbDriver As Boolean

        Private _calc87 As String
        Private _calc85 As String
        Private _brokerCodeD As String
        Private _dvrDedPct As Double
        Private _dvrDedResn As String

        Private _Terminated As Boolean
        Private _Term_Staff As String
        Private _Term_Date As Date
        Private _Term_Reason As String

        Private _ViewOrder As Integer
        Private _UpdatedByUserId As Integer
        Private _UpdatedByUser As String
        Private _UpdatedDate As Date
        Private _CreatedByUserId As Integer
        Private _CreatedByUser As String
        Private _CreatedDate As Date

#End Region

#Region " Properties "

        Private Property KeyID() As Integer Implements IHydratable.KeyID
            Get
                Return _ItemId
            End Get
            Set(ByVal value As Integer)
                _ItemId = value
            End Set
        End Property

        Public Property ItemId() As Integer
            Get
                Return _ItemId
            End Get
            Set(ByVal Value As Integer)
                _ItemId = Value
            End Set
        End Property

        Public Property ModuleId() As Integer
            Get
                Return _ModuleId
            End Get
            Set(ByVal Value As Integer)
                _ModuleId = Value
            End Set
        End Property

        Public Property DriverCode() As String
            Get
                Return _driverCode
            End Get
            Set(ByVal Value As String)
                _driverCode = Value
            End Set
        End Property

        Public Property DriverName() As String
            Get
                Return _driverName
            End Get
            Set(ByVal Value As String)
                _driverName = Value
            End Set
        End Property

        Public Property DLastName() As String
            Get
                Return _dLastName
            End Get
            Set(ByVal Value As String)
                _dLastName = Value
            End Set
        End Property

        Public Property DFirstName() As String
            Get
                Return _dFirstName
            End Get
            Set(ByVal Value As String)
                _dFirstName = Value
            End Set
        End Property

        Public Property AddressLine1() As String
            Get
                Return _addressLine1
            End Get
            Set(ByVal Value As String)
                _addressLine1 = Value
            End Set
        End Property

        Public Property AddressLine2() As String
            Get
                Return _addressLine2
            End Get
            Set(ByVal Value As String)
                _addressLine2 = Value
            End Set
        End Property

        Public Property AddressLine3() As String
            Get
                Return _addressLine3
            End Get
            Set(ByVal Value As String)
                _addressLine3 = Value
            End Set
        End Property

        Public Property City() As String
            Get
                Return _city
            End Get
            Set(ByVal Value As String)
                _city = Value
            End Set
        End Property

        Public Property State() As String
            Get
                Return _state
            End Get
            Set(ByVal Value As String)
                _state = Value
            End Set
        End Property

        Public Property ZipCode() As String
            Get
                Return _zipCode
            End Get
            Set(ByVal Value As String)
                _zipCode = Value
            End Set
        End Property

        Public Property CountryCode() As String
            Get
                Return _countryCode
            End Get
            Set(ByVal Value As String)
                _countryCode = Value
            End Set
        End Property

        Public Property PhoneNo() As String
            Get
                Return _phoneNo
            End Get
            Set(ByVal Value As String)
                _phoneNo = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property Ext() As String
            Get
                Return _ext
            End Get
            Set(ByVal Value As String)
                _ext = Value
            End Set
        End Property

        Public Property EmailAddress() As String
            Get
                Return _emailAddress
            End Get
            Set(ByVal Value As String)
                _emailAddress = Value
            End Set
        End Property

        Public Property CommRate() As Double
            Get
                Return _commRate
            End Get
            Set(ByVal Value As Double)
                _commRate = Value
            End Set
        End Property

        Public Property AdminExempt() As String
            Get
                Return _adminExempt
            End Get
            Set(ByVal Value As String)
                _adminExempt = Value
            End Set
        End Property

        Public Property Status() As String
            Get
                Return _status
            End Get
            Set(ByVal Value As String)
                _status = Value
            End Set
        End Property

        Public Property DriverNotes() As String
            Get
                Return _driverNotes
            End Get
            Set(ByVal Value As String)
                _driverNotes = Value
            End Set
        End Property

        Public Property LoadType() As String
            Get
                Return _loadType
            End Get
            Set(ByVal Value As String)
                _loadType = Value
            End Set
        End Property

        Public Property LastLoad() As DateTime
            Get
                Return _lastLoad
            End Get
            Set(ByVal Value As DateTime)
                _lastLoad = Value
            End Set
        End Property

        Public Property SafetyAuth() As String
            Get
                Return _safetyAuth
            End Get
            Set(ByVal Value As String)
                _safetyAuth = Value
            End Set
        End Property

        Public Property CellPhone() As String
            Get
                Return _cellPhone
            End Get
            Set(ByVal Value As String)
                _cellPhone = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property Pager() As String
            Get
                Return _pager
            End Get
            Set(ByVal Value As String)
                _pager = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property AccountNo() As String
            Get
                Return _accountNo
            End Get
            Set(ByVal Value As String)
                _accountNo = Value
            End Set
        End Property

        Public Property OfficeOwner() As String
            Get
                Return _officeOwner
            End Get
            Set(ByVal Value As String)
                _officeOwner = Value
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

        Public Property FaxNo() As String
            Get
                Return _faxNo
            End Get
            Set(ByVal Value As String)
                _faxNo = Phone.StripPhoneNo(Value)
            End Set
        End Property

        Public Property JRCTrailer() As String
            Get
                Return _jRCTrailer
            End Get
            Set(ByVal Value As String)
                _jRCTrailer = Value
            End Set
        End Property

        Public Property LastLoadID() As String
            Get
                Return _lastLoadID
            End Get
            Set(ByVal Value As String)
                _lastLoadID = Value
            End Set
        End Property

        Public Property LastPU() As String
            Get
                Return _lastPU
            End Get
            Set(ByVal Value As String)
                _lastPU = Value
            End Set
        End Property

        Public Property LastDP() As String
            Get
                Return _lastDP
            End Get
            Set(ByVal Value As String)
                _lastDP = Value
            End Set
        End Property

        Public Property SafetyNotes() As String
            Get
                Return _safetyNotes
            End Get
            Set(ByVal Value As String)
                _safetyNotes = Value
            End Set
        End Property

        Public Property LastTrailerUsed() As String
            Get
                Return _lastTrailerUsed
            End Get
            Set(ByVal Value As String)
                _lastTrailerUsed = Value
            End Set
        End Property

        Public Property LastLoadDeliv() As DateTime
            Get
                Return _lastLoadDeliv
            End Get
            Set(ByVal Value As DateTime)
                _lastLoadDeliv = Value
            End Set
        End Property

        Public Property DrugDate() As DateTime
            Get
                Return _drugDate
            End Get
            Set(ByVal Value As DateTime)
                _drugDate = Value
            End Set
        End Property

        Public Property LicenceDate() As DateTime
            Get
                Return _licenceDate
            End Get
            Set(ByVal Value As DateTime)
                _licenceDate = Value
            End Set
        End Property

        Public Property TruckInsDate() As DateTime
            Get
                Return _truckInsDate
            End Get
            Set(ByVal Value As DateTime)
                _truckInsDate = Value
            End Set
        End Property

        Public Property TrailerInsDate() As DateTime
            Get
                Return _trailerInsDate
            End Get
            Set(ByVal Value As DateTime)
                _trailerInsDate = Value
            End Set
        End Property

        Public Property RegRenewDate() As DateTime
            Get
                Return _regRenewDate
            End Get
            Set(ByVal Value As DateTime)
                _regRenewDate = Value
            End Set
        End Property

        Public Property NewLeaseDate() As DateTime
            Get
                Return _newLeaseDate
            End Get
            Set(ByVal Value As DateTime)
                _newLeaseDate = Value
            End Set
        End Property

        Public Property InactivateDate() As DateTime
            Get
                Return _InactivateDate
            End Get
            Set(ByVal Value As DateTime)
                _InactivateDate = Value
            End Set
        End Property

        Public Property MedicalDate() As DateTime
            Get
                Return _medicalDate
            End Get
            Set(ByVal Value As DateTime)
                _medicalDate = Value
            End Set
        End Property

        Public Property LogBookOS() As String
            Get
                Return _logBookOS
            End Get
            Set(ByVal Value As String)
                _logBookOS = Value
            End Set
        End Property


        Public Property MoMaint() As Date
            Get
                Return _MoMaint
            End Get
            Set(ByVal Value As Date)
                _MoMaint = Value
            End Set
        End Property

        Public Property DotInspec() As Date
            Get
                Return _DotInspec
            End Get
            Set(ByVal Value As Date)
                _DotInspec = Value
            End Set
        End Property

        Public Property TrailerMaint() As Date
            Get
                Return _TrailerMaint
            End Get
            Set(ByVal Value As Date)
                _TrailerMaint = Value
            End Set
        End Property

        Public Property RegRenew() As Date
            Get
                Return _RegRenew
            End Get
            Set(ByVal Value As Date)
                _RegRenew = Value
            End Set
        End Property

        Public Property OccIns() As Date
            Get
                Return _OccIns
            End Get
            Set(ByVal Value As Date)
                _OccIns = Value
            End Set
        End Property

        Public Property NtlIns() As Date
            Get
                Return _NtlIns
            End Get
            Set(ByVal Value As Date)
                _NtlIns = Value
            End Set
        End Property

        Public Property PhysDmg() As Date
            Get
                Return _PhysDmg
            End Get
            Set(ByVal Value As Date)
                _PhysDmg = Value
            End Set
        End Property

        Public Property SeaLink() As Date
            Get
                Return _SeaLink
            End Get
            Set(ByVal Value As Date)
                _SeaLink = Value
            End Set
        End Property

        Public Property AnnIns() As Date
            Get
                Return _AnnIns
            End Get
            Set(ByVal Value As Date)
                _AnnIns = Value
            End Set
        End Property

        Public Property ProbDriver() As Boolean
            Get
                Return _ProbDriver
            End Get
            Set(ByVal Value As Boolean)
                _ProbDriver = Value
            End Set
        End Property


        Public Property Calc87() As String
            Get
                Return _calc87
            End Get
            Set(ByVal Value As String)
                _calc87 = Value
            End Set
        End Property

        Public Property Calc85() As String
            Get
                Return _calc85
            End Get
            Set(ByVal Value As String)
                _calc85 = Value
            End Set
        End Property

        Public Property BrokerCodeD() As String
            Get
                Return _brokerCodeD
            End Get
            Set(ByVal Value As String)
                _brokerCodeD = Value
            End Set
        End Property

        Public Property DvrDedPct() As Double
            Get
                Return _dvrDedPct
            End Get
            Set(ByVal Value As Double)
                _dvrDedPct = Value
            End Set
        End Property

        Public Property DvrDedResn() As String
            Get
                Return _dvrDedResn
            End Get
            Set(ByVal Value As String)
                _dvrDedResn = Value
            End Set
        End Property


        Public Property Terminated() As Boolean
            Get
                Return _Terminated
            End Get
            Set(ByVal Value As Boolean)
                _Terminated = Value
            End Set
        End Property

        Public Property Term_Staff() As String
            Get
                Return _Term_Staff
            End Get
            Set(ByVal Value As String)
                _Term_Staff = Value
            End Set
        End Property

        Public Property Term_Date() As Date
            Get
                Return _Term_Date
            End Get
            Set(ByVal Value As Date)
                _Term_Date = Value
            End Set
        End Property

        Public Property Term_Reason() As String
            Get
                Return _Term_Reason
            End Get
            Set(ByVal Value As String)
                _Term_Reason = Value
            End Set
        End Property


        Public Property ViewOrder() As Integer
            Get
                Return _ViewOrder
            End Get
            Set(ByVal Value As Integer)
                _ViewOrder = Value
            End Set
        End Property

        'Audit Control
        Public Property UpdatedByUserId() As Integer
            Get
                Return _UpdatedByUserId
            End Get
            Set(ByVal Value As Integer)
                _UpdatedByUserId = Value
            End Set
        End Property

        Public Property UpdatedByUser() As String
            Get
                Return _UpdatedByUser
            End Get
            Set(ByVal Value As String)
                _UpdatedByUser = Value
            End Set
        End Property

        Public Property UpdatedDate() As Date
            Get
                Return _UpdatedDate
            End Get
            Set(ByVal Value As Date)
                _UpdatedDate = Value
            End Set
        End Property

        Public Property CreatedByUserId() As Integer
            Get
                Return _CreatedByUserId
            End Get
            Set(ByVal Value As Integer)
                _CreatedByUserId = Value
            End Set
        End Property

        Public Property CreatedByUser() As String
            Get
                Return _CreatedByUser
            End Get
            Set(ByVal Value As String)
                _CreatedByUser = Value
            End Set
        End Property

        Public Property CreatedDate() As Date
            Get
                Return _CreatedDate
            End Get
            Set(ByVal Value As Date)
                _CreatedDate = Value
            End Set
        End Property

#End Region

#Region " Optional IHydratable Implementation "

        Private Sub Fill(ByVal dr As IDataReader) Implements IHydratable.Fill
            ''Following two Sections are created, so that those Items, which are not part of the Search may not be returned, in Try-Catch Block 
            _ItemId = Convert.ToInt32(Null.SetNull(dr("ItemID"), ItemId))
            _ModuleId = Convert.ToInt32(Null.SetNull(dr("ModuleID"), ModuleId))
          

            Try
                _driverCode = Convert.ToString(Null.SetNull(dr("DriverCode"), DriverCode))

                _MoMaint = Convert.ToDateTime(Null.SetNull(dr("MoMaint"), MoMaint))
                _DotInspec = Convert.ToDateTime(Null.SetNull(dr("DotInspec"), DotInspec))
                _TrailerMaint = Convert.ToDateTime(Null.SetNull(dr("TrailerMaint"), TrailerMaint))
                _RegRenew = Convert.ToDateTime(Null.SetNull(dr("RegRenew"), RegRenew))
                _OccIns = Convert.ToDateTime(Null.SetNull(dr("OccIns"), OccIns))
                _NtlIns = Convert.ToDateTime(Null.SetNull(dr("NtlIns"), NtlIns))
                _PhysDmg = Convert.ToDateTime(Null.SetNull(dr("PhysDmg"), PhysDmg))
                _SeaLink = Convert.ToDateTime(Null.SetNull(dr("SeaLink"), SeaLink))
                _AnnIns = Convert.ToDateTime(Null.SetNull(dr("AnnIns"), AnnIns))
                _ProbDriver = Convert.ToBoolean(Null.SetNull(dr("ProbDriver"), ProbDriver))

                '_ActualFields = Convert.ToString(Null.SetNull(dr["ActualFields"], ActualFields)); 

                _driverName = Convert.ToString(Null.SetNull(dr("DriverName"), DriverName))
                _dLastName = Convert.ToString(Null.SetNull(dr("DLastName"), DLastName))
                _dFirstName = Convert.ToString(Null.SetNull(dr("DFirstName"), DFirstName))
                _addressLine1 = Convert.ToString(Null.SetNull(dr("AddressLine1"), AddressLine1))
                _addressLine2 = Convert.ToString(Null.SetNull(dr("AddressLine2"), AddressLine2))
                _addressLine3 = Convert.ToString(Null.SetNull(dr("AddressLine3"), AddressLine3))
                _city = Convert.ToString(Null.SetNull(dr("City"), City))
                _state = Convert.ToString(Null.SetNull(dr("State"), State))
                _zipCode = Convert.ToString(Null.SetNull(dr("ZipCode"), ZipCode))
                _countryCode = Convert.ToString(Null.SetNull(dr("CountryCode"), CountryCode))
                _phoneNo = Convert.ToString(Null.SetNull(dr("PhoneNo"), PhoneNo))
                _ext = Convert.ToString(Null.SetNull(dr("Ext"), Ext))
                _emailAddress = Convert.ToString(Null.SetNull(dr("EmailAddress"), EmailAddress))
                _commRate = Convert.ToDouble(Null.SetNull(dr("CommRate"), CommRate))
                _adminExempt = Convert.ToString(Null.SetNull(dr("AdminExempt"), AdminExempt))
                _status = Convert.ToString(Null.SetNull(dr("Status"), Status))
                _driverNotes = Convert.ToString(Null.SetNull(dr("DriverNotes"), DriverNotes))
                _loadType = Convert.ToString(Null.SetNull(dr("LoadType"), LoadType))
                _lastLoad = Convert.ToDateTime(Null.SetNull(dr("LastLoad"), LastLoad))
                _safetyAuth = Convert.ToString(Null.SetNull(dr("SafetyAuth"), SafetyAuth))
                _cellPhone = Convert.ToString(Null.SetNull(dr("CellPhone"), CellPhone))
                _pager = Convert.ToString(Null.SetNull(dr("Pager"), Pager))
                _accountNo = Convert.ToString(Null.SetNull(dr("AccountNo"), AccountNo))
                _officeOwner = Convert.ToString(Null.SetNull(dr("OfficeOwner"), OfficeOwner))
                _faxNo = Convert.ToString(Null.SetNull(dr("FaxNo"), FaxNo))
                _jRCTrailer = Convert.ToString(Null.SetNull(dr("JRCTrailer"), JRCTrailer))
                _lastLoadID = Convert.ToString(Null.SetNull(dr("LastLoadID"), LastLoadID))
                _lastPU = Convert.ToString(Null.SetNull(dr("LastPU"), LastPU))
                _lastDP = Convert.ToString(Null.SetNull(dr("LastDP"), LastDP))
                _safetyNotes = Convert.ToString(Null.SetNull(dr("SafetyNotes"), SafetyNotes))
                _lastTrailerUsed = Convert.ToString(Null.SetNull(dr("LastTrailerUsed"), LastTrailerUsed))
                _lastLoadDeliv = Convert.ToDateTime(Null.SetNull(dr("LastLoadDeliv"), LastLoadDeliv))
                _drugDate = Convert.ToDateTime(Null.SetNull(dr("DrugDate"), DrugDate))
                _licenceDate = Convert.ToDateTime(Null.SetNull(dr("LicenceDate"), LicenceDate))
                _truckInsDate = Convert.ToDateTime(Null.SetNull(dr("TruckInsDate"), TruckInsDate))
                _trailerInsDate = Convert.ToDateTime(Null.SetNull(dr("TrailerInsDate"), TrailerInsDate))
                _regRenewDate = Convert.ToDateTime(Null.SetNull(dr("RegRenewDate"), RegRenewDate))
                _newLeaseDate = Convert.ToDateTime(Null.SetNull(dr("NewLeaseDate"), NewLeaseDate))
                _InactivateDate = Convert.ToDateTime(Null.SetNull(dr("InactivateDate"), InactivateDate))
                _medicalDate = Convert.ToDateTime(Null.SetNull(dr("MedicalDate"), MedicalDate))
                _logBookOS = Convert.ToString(Null.SetNull(dr("LogBookOS"), LogBookOS))

                _calc87 = Convert.ToString(Null.SetNull(dr("Calc87"), Calc87))
                _calc85 = Convert.ToString(Null.SetNull(dr("Calc85"), Calc85))
                _brokerCodeD = Convert.ToString(Null.SetNull(dr("BrokerCodeD"), BrokerCodeD))
                _dvrDedPct = Convert.ToDouble(Null.SetNull(dr("DvrDedPct"), DvrDedPct))
                _dvrDedResn = Convert.ToString(Null.SetNull(dr("DvrDedResn"), DvrDedResn))

                _Terminated = Convert.ToBoolean(Null.SetNull(dr("Terminated"), Terminated))
                _Term_Staff = Convert.ToString(Null.SetNull(dr("Term_Staff"), Term_Staff))
                _Term_Date = Convert.ToDateTime(Null.SetNull(dr("Term_Date"), Term_Date))
                _Term_Reason = Convert.ToString(Null.SetNull(dr("Term_Reason"), Term_Reason))

                'Insert the Actual Fields above 

                _ViewOrder = Convert.ToInt32(Null.SetNull(dr("ViewOrder"), ViewOrder))
                _UpdatedByUserId = Convert.ToInt32(Null.SetNull(dr("UpdatedByUserId"), UpdatedByUserId))
                _UpdatedByUser = Convert.ToString(Null.SetNull(dr("UpdatedByUser"), UpdatedByUser))
                _UpdatedDate = Convert.ToDateTime(Null.SetNull(dr("UpdatedDate"), UpdatedDate))
                _CreatedByUserId = Convert.ToInt32(Null.SetNull(dr("CreatedByUserId"), CreatedByUserId))
                _CreatedByUser = Convert.ToString(Null.SetNull(dr("CreatedByUser"), CreatedByUser))
                _CreatedDate = Convert.ToDateTime(Null.SetNull(dr("CreatedDate"), CreatedDate))
            Catch

            End Try
        End Sub

#End Region


    End Class

    Public Class SalesPersonsController
        Implements Entities.Modules.ISearchable
        Implements Entities.Modules.IPortable

#Region " Public Methods "

        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function

        '---------------------------------------------------------------------
        ' TODO Implement BLL methods
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------
        Public Function AddSalesPerson(ByVal objSalesPerson As SalesPersonInfo) As Integer
            Dim IsProbDriver As Boolean = IsDriverProblematic(objSalesPerson)
            With objSalesPerson
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddSalesPerson", .ModuleId, GetNull(.DriverCode), GetNull(.DriverName), GetNull(.DLastName), GetNull(.DFirstName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.AddressLine3), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.CountryCode), GetNull(.PhoneNo), GetNull(.Ext), GetNull(.EmailAddress), GetNull(.CommRate), GetNull(.AdminExempt), GetNull(.Status), GetNull(.DriverNotes), GetNull(.LoadType), GetNull(.LastLoad), GetNull(.SafetyAuth), GetNull(.CellPhone), GetNull(.Pager), GetNull(.AccountNo), GetNull(.OfficeOwner), GetNull(.FaxNo), GetNull(.JRCTrailer), GetNull(.LastLoadID), GetNull(.LastPU), GetNull(.LastDP), GetNull(.SafetyNotes), GetNull(.LastTrailerUsed), GetNull(.LastLoadDeliv), GetNull(.DrugDate), GetNull(.LicenceDate), GetNull(.TruckInsDate), GetNull(.TrailerInsDate), GetNull(.RegRenewDate), GetNull(.NewLeaseDate), GetNull(.InactivateDate), GetNull(.MedicalDate), GetNull(.LogBookOS), GetNull(.MoMaint), GetNull(.DotInspec), GetNull(.TrailerMaint), GetNull(.RegRenew), GetNull(.OccIns), GetNull(.NtlIns), GetNull(.PhysDmg), GetNull(.SeaLink), GetNull(.AnnIns), IsProbDriver, GetNull(.Calc87), GetNull(.Calc85), GetNull(.BrokerCodeD), GetNull(.DvrDedPct), GetNull(.DvrDedResn), GetNull(.Terminated), GetNull(.Term_Staff), GetNull(.Term_Date), GetNull(.Term_Reason), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        'Public Sub UpdateSalesPerson(ByVal objSalesPerson As SalesPersonInfo, Optional ByVal UpdateLoadStatus As Boolean = False)
        Public Sub UpdateSalesPerson(ByVal objSalesPerson As SalesPersonInfo)
            Dim IsProbDriver As Boolean = IsDriverProblematic(objSalesPerson)
            With objSalesPerson
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateSalesPerson", .ItemId, GetNull(.DriverCode), GetNull(.DriverName), GetNull(.DLastName), GetNull(.DFirstName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.AddressLine3), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.CountryCode), GetNull(.PhoneNo), GetNull(.Ext), GetNull(.EmailAddress), GetNull(.CommRate), GetNull(.AdminExempt), GetNull(.Status), GetNull(.DriverNotes), GetNull(.LoadType), GetNull(.LastLoad), GetNull(.SafetyAuth), GetNull(.CellPhone), GetNull(.Pager), GetNull(.AccountNo), GetNull(.OfficeOwner), GetNull(.FaxNo), GetNull(.JRCTrailer), GetNull(.LastLoadID), GetNull(.LastPU), GetNull(.LastDP), GetNull(.SafetyNotes), GetNull(.LastTrailerUsed), GetNull(.LastLoadDeliv), GetNull(.DrugDate), GetNull(.LicenceDate), GetNull(.TruckInsDate), GetNull(.TrailerInsDate), GetNull(.RegRenewDate), GetNull(.NewLeaseDate), GetNull(.InactivateDate), GetNull(.MedicalDate), GetNull(.LogBookOS), GetNull(.MoMaint), GetNull(.DotInspec), GetNull(.TrailerMaint), GetNull(.RegRenew), GetNull(.OccIns), GetNull(.NtlIns), GetNull(.PhysDmg), GetNull(.SeaLink), GetNull(.AnnIns), IsProbDriver, GetNull(.Calc87), GetNull(.Calc85), GetNull(.BrokerCodeD), GetNull(.DvrDedPct), GetNull(.DvrDedResn), GetNull(.Terminated), GetNull(.Term_Staff), GetNull(.Term_Date), GetNull(.Term_Reason), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
            'If UpdateLoadStatus Then UpdateLoadStatus4Driver(objSalesPerson)
        End Sub
        Public Function IsDriverProblematic(ByVal DriverCode As String) As Boolean
            Return IsDriverProblematic(GetSalesPersonId(DriverCode))
        End Function
        Public Function IsDriverProblematic(ByVal SalesPersonId As Integer) As Boolean
            Return IsDriverProblematic(GetSalesPerson(SalesPersonId))
        End Function
        Public Function IsDriverProblematic(ByVal objSalesPerson As SalesPersonInfo) As Boolean
            Dim DDate As Date = Today().AddDays(30)
            With objSalesPerson
                If ((Not Null.IsNull(.MoMaint)) AndAlso (.MoMaint < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.DotInspec)) AndAlso (.DotInspec < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.TrailerMaint)) AndAlso (.TrailerMaint < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.RegRenew)) AndAlso (.RegRenew < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.OccIns)) AndAlso (.OccIns < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.NtlIns)) AndAlso (.NtlIns < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.PhysDmg)) AndAlso (.PhysDmg < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.SeaLink)) AndAlso (.SeaLink < DDate)) Then
                    Return True
                ElseIf ((Not Null.IsNull(.AnnIns)) AndAlso (.AnnIns < DDate)) Then
                    Return True
                Else
                    Return False
                End If
            End With
        End Function
        Public Sub UpdateSalesPersons4ProbDriver()
            UpdateSalesPersons4ProbDriver("")
        End Sub
        Public Sub UpdateSalesPersons4ProbDriver(ByVal JRCIOfficeCode As String)
            Dim strSql As String = "Select ItemId, ModuleId, DriverCode, MoMaint, DotInspec, TrailerMaint, RegRenew, OccIns, NtlIns, PhysDmg, SeaLink, AnnIns, ProbDriver FROM ARD_SalesPersonMasterfile "
            If JRCIOfficeCode <> "" AndAlso JRCIOfficeCode <> "000000000" Then
                strSql &= " WHERE OfficeOwner='" & JRCIOfficeCode & "' "
            End If

            Dim lotSalesPersons As List(Of SalesPersonInfo) = CBO.FillCollection(Of SalesPersonInfo)(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(strSql))
            Dim IsProblematic As Boolean
            For Each objSalesPerson As SalesPersonInfo In lotSalesPersons
                IsProblematic = IsDriverProblematic(objSalesPerson)
                If objSalesPerson.ProbDriver <> IsProblematic Then
                    DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateSalesPerson4ProbDriver", objSalesPerson.ItemId, IsProblematic)
                End If
            Next
        End Sub

        Public Sub DeleteSalesPerson(ByVal objSalesPerson As SalesPersonInfo)
            DeleteSalesPerson(objSalesPerson.ItemId)
        End Sub

        Public Sub DeleteSalesPerson(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteSalesPerson", ItemID)
        End Sub

        Public Sub FixSalesPersons(ByVal ModuleID As Integer, ByVal UpdatedByUserId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_FixSalesPersons", ModuleID, UpdatedByUserId)
        End Sub

        Public Sub UpdateLoadStatus4Driver(ByVal objSalesPerson As SalesPersonInfo)
            With objSalesPerson
                'If (.SafetyAuth = "HOLD") OrElse (.Status = "Y") Then
                'If (.SafetyAuth = "HOLD") OrElse ((.Status = "Y") AndAlso .InactivateDate < Today()) Then
                If (.SafetyAuth = "HOLD") Then
                    SetLoadStatus2Supsense4Driver(.DriverCode)
                ElseIf (.Status = "Y") Then
                    SetLoadStatus2Supsense4DriverInactivateDate(.DriverCode, .InactivateDate)
                Else
                    SetLoadStatus2Wip4Driver(.DriverCode)
                End If
            End With
        End Sub
        Public Sub SetLoadStatus2Supsense4Driver(ByVal DriverCode As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SetLoadStatus2Supsense4Driver", DriverCode)
        End Sub
        Public Sub SetLoadStatus2Supsense4DriverInactivateDate(ByVal DriverCode As String, ByVal InactivateDate As DateTime)
            SetLoadStatus2Wip4Driver(DriverCode)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SetLoadStatus2Supsense4DriverInactivateDate", DriverCode, InactivateDate)
        End Sub
        Public Sub SetLoadStatus2Wip4Driver(ByVal DriverCode As String)
            Dim dr As IDataReader = DataProvider.Instance().ExecuteReader("bhattji_GetSupsensedLoads4Driver", DriverCode)
            If Not dr Is Nothing Then
                Dim LoadID As String = Null.NullString
                While dr.Read
                    Try
                        LoadID = Convert.ToString(Null.SetNull(dr("LoadID"), Null.NullString))
                        If LoadID <> Null.NullString Then DataProvider.Instance().ExecuteNonQuery("bhattji_SetLoadStatus2Wip4LoadID", LoadID)
                    Catch
                    End Try
                End While
            End If
        End Sub

        Public Sub ClearLastLoadData(ByVal LastLoadID As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_ClearLastLoadData", LastLoadID)
        End Sub
        Public Sub RefreshForNullLoadId()
            Dim dr As IDataReader = DataProvider.Instance().ExecuteReader("bhattji_GetDriversForNullLoadId")
            If Not dr Is Nothing Then
                While dr.Read
                    Try
                        RefreshLastLoadData(Convert.ToString(dr("DriverCode")))
                    Catch
                    End Try
                End While
            End If
        End Sub
        Public Sub RefreshForLastLoadId(ByVal LastLoadID As String)
            Dim dr As IDataReader = DataProvider.Instance().ExecuteReader("bhattji_GetDriversForLastLoadId", LastLoadID)
            If Not dr Is Nothing Then
                While dr.Read
                    Try
                        RefreshLastLoadData(Convert.ToString(dr("DriverCode")))
                    Catch
                    End Try
                End While
            End If
        End Sub
        Public Sub RefreshLastLoadData(ByVal DriverCode As String)
            Dim dr As IDataReader = DataProvider.Instance().ExecuteReader("bhattji_GetLastLoadData", DriverCode)
            If Not dr Is Nothing Then
                Dim objSalePerson As SalesPersonInfo = GetSalesPerson(GetSalesPersonId(DriverCode))
                If Not objSalePerson Is Nothing Then
                    dr.Read()
                    objSalePerson.LastLoadID = Convert.ToString(Null.SetNull(dr("LastLoadID"), Null.NullString)) 'Convert.ToString(dr("LastLoadID"))
                    Try
                        objSalePerson.LastLoad = Convert.ToDateTime(Null.SetNull(dr("LastLoad"), Null.NullDate)) 'Convert.ToDateTime(dr("LastLoad"))
                    Catch
                    End Try
                    objSalePerson.LastPU = Convert.ToString(Null.SetNull(dr("LastPU"), Null.NullString)) 'Convert.ToString(dr("LastPU"))
                    objSalePerson.LastDP = Convert.ToString(Null.SetNull(dr("LastDP"), Null.NullString)) 'Convert.ToString(dr("LastDP"))
                    Try
                        objSalePerson.LastLoadDeliv = Convert.ToDateTime(Null.SetNull(dr("LastLoadDeliv"), Null.NullDate)) 'Convert.ToDateTime(dr("LastLoadDeliv"))
                    Catch
                    End Try

                    objSalePerson.LastTrailerUsed = Convert.ToString(Null.SetNull(dr("LastTrailerUsed"), Null.NullString)) 'Convert.ToString(dr("LastTrailerUsed"))

                    UpdateSalesPerson(objSalePerson)
                End If
            End If
        End Sub

        Public Sub SortSalesPersons(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortSalesPersons", ModuleID)
        End Sub

        Public Function IsTotalUniqueCode(ByVal DriverCode As String) As Boolean
            Return (CType(DataProvider.Instance().ExecuteScalar("bhattji_GetSalesPersonId", DriverCode), Integer) < 1) AndAlso (CType(DataProvider.Instance().ExecuteScalar("bhattji_BkrGetSalesPersonId", DriverCode), Integer) < 1)
        End Function

        Public Function IsUniqueCode(ByVal DriverCode As String) As Boolean
            Return GetSalesPersonId(DriverCode) < 1
        End Function

        Public Function IsUniqueCode(ByVal DriverCode As String, ByVal OfficeOwner As String) As Boolean
            Return GetSalesPersonId(DriverCode, OfficeOwner) < 1
        End Function

        Public Function IsUniqueAccountNo(ByVal AccountNo As String) As Boolean
            Return GetSalesPersonIdByAccountNo(AccountNo) < 1
        End Function
        Public Function GetSalesPersonIdByAccountNo(ByVal AccountNo As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetSalesPersonIdByAccountNo", AccountNo))
        End Function

        Public Function GetSalesPersonId(ByVal DriverCode As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetSalesPersonId", DriverCode))
        End Function

        Public Function GetSalesPersonId(ByVal DriverCode As String, ByVal OfficeOwner As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetSalesPersonIdUnique", DriverCode, OfficeOwner))
        End Function

        Public Function GetSalesPerson(ByVal ItemID As Integer) As SalesPersonInfo
            'Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetSalesPerson", ItemID), GetType(SalesPersonInfo)), SalesPersonInfo)
            Return CBO.FillObject(Of SalesPersonInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetSalesPerson", ItemID))
        End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()

        Public Function GetSalesPersons(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "000000000", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal Status As String = "A", Optional ByVal Terminated As String = "A", Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable
            Dim dt As New DataTable
            dt.Load(GetSalesPersonsCommons(SearchText, JRCIOfficeCode, SearchOn, StartsWith, Status, Terminated, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
            Return dt
        End Function

        Public Function GetSalesPersonsCommons(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "000000000", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal Status As String = "A", Optional ByVal Terminated As String = "A", Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As IDataReader 'ArrayList '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If (SearchText <> "") OrElse (Status = "Y") OrElse (Status = "N") OrElse (Terminated = "T") OrElse (Terminated = "U") OrElse ((JRCIOfficeCode <> "000000000") AndAlso (JRCIOfficeCode <> "")) Then
                Return GetSearchedSalesPersons(SearchText, JRCIOfficeCode, SearchOn, StartsWith, Status, Terminated, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            Else
                Select Case GetItems
                    Case 0
                        If ModuleId > -1 Then
                            Return GetModuleSalesPersons(ModuleId, NoOfItems)
                        Else
                            Return GetAllSalesPersons(NoOfItems)
                        End If
                    Case 1
                        If PortalId > -1 Then
                            Return GetPortalSalesPersons(PortalId, NoOfItems)
                        Else
                            Return GetAllSalesPersons(NoOfItems)
                        End If
                    Case 2
                        Return GetAllSalesPersons(NoOfItems)
                    Case Else '0
                        If PortalId > -1 Then
                            Return GetPortalSalesPersons(PortalId, NoOfItems)
                        ElseIf ModuleId > -1 Then
                            Return GetModuleSalesPersons(ModuleId, NoOfItems)
                        Else
                            Return GetAllSalesPersons(NoOfItems)
                        End If
                End Select
            End If
        End Function

        Public Function GetModuleSalesPersons(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList '
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleSalesPersons", ModuleId, NoOfItems)
        End Function

        Public Function GetPortalSalesPersons(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList '
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalSalesPersons", PortalId, NoOfItems)
        End Function

        Public Function GetAllSalesPersons(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllSalesPersons", NoOfItems)
        End Function

        Public Function GetSearchedSalesPersons(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "000000000", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal Status As String = "A", Optional ByVal Terminated As String = "A", Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'ArrayList '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""
            Dim OfficeFilter As String '= ""
            Dim StatusFilter As String = ""
            Dim TerminatedFilter As String = ""


            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleSalesPersons(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalSalesPersons(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalSalesPersons(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleSalesPersons(ModuleId)
                    End If
            End Select

            If (JRCIOfficeCode = "") OrElse (JRCIOfficeCode = "000000000") Then
                OfficeFilter = " "
            Else
                OfficeFilter = "AND (x.OfficeOwner = " & JRCIOfficeCode & ") "
            End If

            Dim strSearchText As String
            If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"
            Select Case Status.ToUpper
                Case "Y"
                    StatusFilter = "AND (x.Status='Y') "
                Case "N"
                    StatusFilter = "AND (x.Status='N') "
            End Select
            Select Case Terminated.ToUpper
                Case "T"
                    TerminatedFilter = "AND (x.Terminated=1) "
                Case "U"
                    TerminatedFilter = "AND ((x.Terminated IS Null) OR (x.Terminated=0)) "
            End Select

            Dim DateFilter As String = ""
            Dim DateTo As Date = Now
            If ToDate <> "" Then
                Try
                    DateTo = Date.Parse(ToDate)
                Catch
                    DateTo = Now
                End Try
            End If
            Dim DateFrom As Date = #1/1/1947#
            If FromDate <> "" Then
                Try
                    DateFrom = Date.Parse(FromDate)
                Catch
                    DateFrom = #1/1/1947#
                End Try
            End If

            If DateFrom > DateTo Then
                Dim tDate As Date = DateFrom
                DateFrom = DateTo
                DateTo = tDate
            End If

            If FromDate <> "" Then DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (x.UpdatedDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT TOP " & NoOfItems.ToString & " ")
            ' MySqlString &= "x.* ")
            sbSql.Append("x.ItemId, ")
            sbSql.Append("x.ModuleId, ")
            sbSql.Append("x.DriverName, ")
            sbSql.Append("x.DriverCode, ")
            sbSql.Append("x.AccountNo, ")
            sbSql.Append("x.Status, ")
            sbSql.Append("x.SafetyAuth, ")
            sbSql.Append("x.Terminated, ")
            sbSql.Append("x.City, ")
            sbSql.Append("x.State, ")
            sbSql.Append("x.PhoneNo, ")
            sbSql.Append("x.CellPhone, ")
            sbSql.Append("x.OfficeOwner, ")
            sbSql.Append("io.IOName ")

            sbSql.Append("FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x ")
            sbSql.Append("LEFT OUTER JOIN [" & MyOjectQualifier & "ARD_InterOffice] AS io on x.OfficeOwner = io.JRCIOfficeCode ")


            Select Case SearchOn.ToUpper
                Case "DRIVERNAME", "DRIVERCODE"
                    sbSql.Append("WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(StatusFilter)
                    sbSql.Append(TerminatedFilter)
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append(OfficeFilter)
                    sbSql.Append("ORDER BY x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc ")


                Case Else '"ANY"
                    sbSql.Append("WHERE ((x.DriverName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.DriverCode LIKE '" & strSearchText & "')) ")
                    sbSql.Append(StatusFilter)
                    sbSql.Append(TerminatedFilter)
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append(OfficeFilter)
                    sbSql.Append("ORDER BY x.DriverName, x.ViewOrder, x.UpdatedDate desc ")

            End Select

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString), GetType(SalesPersonInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function

        'Additional Functions

        Public Function GetAllInterOffices(Optional ByVal NoOfItems As Integer = 100) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllInterOffices", NoOfItems)
        End Function

        Public Function GetUserIOs(ByVal Username As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetUserIOs", Username)
        End Function

        Public Function GetUserDefaultIO(ByVal Username As String) As String
            Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetUserDefaultIO", Username))
        End Function

        Public Function GetAllowCDed(ByVal JRCIOfficeCode As String) As Boolean
            Return (CType(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetAllowCDed", JRCIOfficeCode), String).ToUpper = "Y")
        End Function

        Public Function GetStateCodes() As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetStateCodes")
        End Function

#End Region

#Region " Optional Interfaces "

        Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As DotNetNuke.Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
            Dim SearchItemCollection As New SearchItemInfoCollection

            'Dim SalesPersons As ArrayList = GetSalesPersons(ModInfo.ModuleID)
            Dim SalesPersons As List(Of SalesPersonInfo) = CBO.FillCollection(Of SalesPersonInfo)(GetModuleSalesPersons(ModInfo.ModuleID))
            Dim objSalesPerson As Object
            For Each objSalesPerson In SalesPersons
                Dim SearchItem As SearchItemInfo
                With CType(objSalesPerson, SalesPersonInfo)
                    '
                    Dim UserId As Integer = Null.NullInteger
                    If IsNumeric(.CreatedByUser) Then
                        UserId = Integer.Parse(.CreatedByUser)
                    End If

                    Dim strContent As String = System.Web.HttpUtility.HtmlDecode(.DriverName)
                    Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(.DriverName), False), 100, "...")

                    SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .DriverName, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent, "ItemId=" & .ItemId.ToString, Null.NullInteger)
                    SearchItemCollection.Add(SearchItem)
                End With
            Next

            Return SearchItemCollection

        End Function

        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
            Dim strXML As String = ""
            strXML += "<SalesPersons>"

            'Export each SalesPerson Details
            'Dim arrSalesPersons As ArrayList = GetSalesPersons(ModuleID)
            Dim arrSalesPersons As List(Of SalesPersonInfo) = CBO.FillCollection(Of SalesPersonInfo)(GetModuleSalesPersons(ModuleID))
            If arrSalesPersons.Count <> 0 Then
                Dim objSalesPerson As SalesPersonInfo
                For Each objSalesPerson In arrSalesPersons
                    With objSalesPerson
                        strXML += "<SalesPerson>"

                        strXML &= "<DriverCode>" & XMLEncode(.DriverCode) & "</DriverCode>"
                        strXML &= "<DriverName>" & XMLEncode(.DriverName) & "</DriverName>"
                        strXML &= "<DLastName>" & XMLEncode(.DLastName) & "</DLastName>"
                        strXML &= "<DFirstName>" & XMLEncode(.DFirstName) & "</DFirstName>"
                        strXML &= "<AddressLine1>" & XMLEncode(.AddressLine1) & "</AddressLine1>"
                        strXML &= "<AddressLine2>" & XMLEncode(.AddressLine2) & "</AddressLine2>"
                        strXML &= "<AddressLine3>" & XMLEncode(.AddressLine3) & "</AddressLine3>"
                        strXML &= "<City>" & XMLEncode(.City) & "</City>"
                        strXML &= "<State>" & XMLEncode(.State) & "</State>"
                        strXML &= "<ZipCode>" & XMLEncode(.ZipCode) & "</ZipCode>"
                        strXML &= "<CountryCode>" & XMLEncode(.CountryCode) & "</CountryCode>"
                        strXML &= "<PhoneNo>" & XMLEncode(.PhoneNo) & "</PhoneNo>"
                        strXML &= "<Ext>" & XMLEncode(.Ext) & "</Ext>"
                        strXML &= "<EmailAddress>" & XMLEncode(.EmailAddress) & "</EmailAddress>"
                        strXML &= "<CommRate>" & XMLEncode(.CommRate.ToString) & "</CommRate>"
                        strXML &= "<AdminExempt>" & XMLEncode(.AdminExempt) & "</AdminExempt>"
                        strXML &= "<Status>" & XMLEncode(.Status) & "</Status>"
                        strXML &= "<DriverNotes>" & XMLEncode(.DriverNotes) & "</DriverNotes>"
                        strXML &= "<LoadType>" & XMLEncode(.LoadType) & "</LoadType>"
                        strXML &= "<LastLoad>" & XMLEncode(.LastLoad.ToString) & "</LastLoad>"
                        strXML &= "<SafetyAuth>" & XMLEncode(.SafetyAuth) & "</SafetyAuth>"
                        strXML &= "<CellPhone>" & XMLEncode(.CellPhone) & "</CellPhone>"
                        strXML &= "<Pager>" & XMLEncode(.Pager) & "</Pager>"
                        strXML &= "<AccountNo>" & XMLEncode(.AccountNo) & "</AccountNo>"
                        strXML &= "<OfficeOwner>" & XMLEncode(.OfficeOwner) & "</OfficeOwner>"
                        strXML &= "<FaxNo>" & XMLEncode(.FaxNo) & "</FaxNo>"
                        strXML &= "<JRCTrailer>" & XMLEncode(.JRCTrailer) & "</JRCTrailer>"
                        strXML &= "<LastLoadID>" & XMLEncode(.LastLoadID) & "</LastLoadID>"
                        strXML &= "<LastPU>" & XMLEncode(.LastPU) & "</LastPU>"
                        strXML &= "<LastDP>" & XMLEncode(.LastDP) & "</LastDP>"
                        strXML &= "<SafetyNotes>" & XMLEncode(.SafetyNotes) & "</SafetyNotes>"
                        strXML &= "<LastTrailerUsed>" & XMLEncode(.LastTrailerUsed) & "</LastTrailerUsed>"
                        strXML &= "<LastLoadDeliv>" & XMLEncode(.LastLoadDeliv.ToString) & "</LastLoadDeliv>"
                        strXML &= "<DrugDate>" & XMLEncode(.DrugDate.ToString) & "</DrugDate>"
                        strXML &= "<LicenceDate>" & XMLEncode(.LicenceDate.ToString) & "</LicenceDate>"
                        strXML &= "<TruckInsDate>" & XMLEncode(.TruckInsDate.ToString) & "</TruckInsDate>"
                        strXML &= "<TrailerInsDate>" & XMLEncode(.TrailerInsDate.ToString) & "</TrailerInsDate>"
                        strXML &= "<RegRenewDate>" & XMLEncode(.RegRenewDate.ToString) & "</RegRenewDate>"
                        strXML &= "<NewLeaseDate>" & XMLEncode(.NewLeaseDate.ToString) & "</NewLeaseDate>"
                        strXML &= "<InactivateDate>" & XMLEncode(.InactivateDate.ToString) & "</InactivateDate>"
                        strXML &= "<MedicalDate>" & XMLEncode(.MedicalDate.ToString) & "</MedicalDate>"
                        strXML &= "<LogBookOS>" & XMLEncode(.LogBookOS) & "</LogBookOS>"

                        strXML &= "<MoMaint>" & XMLEncode(.MoMaint.ToString) & "</MoMaint>"
                        strXML &= "<DotInspec>" & XMLEncode(.DotInspec.ToString) & "</DotInspec>"
                        strXML &= "<TrailerMaint>" & XMLEncode(.TrailerMaint.ToString) & "</TrailerMaint>"
                        strXML &= "<RegRenew>" & XMLEncode(.RegRenew.ToString) & "</RegRenew>"
                        strXML &= "<OccIns>" & XMLEncode(.OccIns.ToString) & "</OccIns>"
                        strXML &= "<NtlIns>" & XMLEncode(.NtlIns.ToString) & "</NtlIns>"
                        strXML &= "<PhysDmg>" & XMLEncode(.PhysDmg.ToString) & "</PhysDmg>"
                        strXML &= "<SeaLink>" & XMLEncode(.SeaLink.ToString) & "</SeaLink>"
                        strXML &= "<AnnIns>" & XMLEncode(.AnnIns.ToString) & "</AnnIns>"
                        strXML &= "<ProbDriver>" & XMLEncode(.ProbDriver.ToString) & "</ProbDriver>"

                        strXML &= "<Calc87>" & XMLEncode(.Calc87) & "</Calc87>"
                        strXML &= "<Calc85>" & XMLEncode(.Calc85) & "</Calc85>"
                        strXML &= "<BrokerCodeD>" & XMLEncode(.BrokerCodeD) & "</BrokerCodeD>"
                        strXML &= "<DvrDedPct>" & XMLEncode(.DvrDedPct.ToString) & "</DvrDedPct>"
                        strXML &= "<DvrDedResn>" & XMLEncode(.DvrDedResn) & "</DvrDedResn>"

                        strXML &= "<Terminated>" & XMLEncode(.Terminated.ToString) & "</Terminated>"
                        strXML &= "<Term_Staff>" & XMLEncode(.Term_Staff) & "</Term_Staff>"
                        strXML &= "<Term_Date>" & XMLEncode(.Term_Date.ToString) & "</Term_Date>"
                        strXML &= "<Term_Reason>" & XMLEncode(.Term_Reason) & "</Term_Reason>"

                        strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
                        strXML += "</SalesPerson>"
                    End With
                Next
            End If

            'Export the Module Settings
            Dim objOI As New OptionsInfo(ModuleID)
            With objOI
                'Control Options
                strXML += "<GetItems>" & XMLEncode(.GetItems.ToString) & "</GetItems>"
                strXML += "<ViewControl>" & XMLEncode(.ViewControl) & "</ViewControl>"

                'Option1 Options
                strXML += "<PagerSize>" & XMLEncode(.PagerSize.ToString) & "</PagerSize>"

            End With

            strXML += "</SalesPersons>"

            Return strXML

        End Function

        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            Dim xmlSalesPersons As System.Xml.XmlNode = GetContent(Content, "SalesPersons")

            'Import each SalesPerson Details
            Dim xmlSalesPerson As System.Xml.XmlNode
            For Each xmlSalesPerson In xmlSalesPersons.SelectNodes("SalesPerson")
                Dim objSalesPerson As New SalesPersonInfo
                With objSalesPerson
                    .ModuleId = ModuleID

                    Try
                        .DriverCode = xmlSalesPerson.Item("DriverCode").InnerText
                    Catch
                    End Try
                    Try
                        .DriverName = xmlSalesPerson.Item("DriverName").InnerText
                    Catch
                    End Try
                    Try
                        .DLastName = xmlSalesPerson.Item("DLastName").InnerText
                    Catch
                    End Try
                    Try
                        .DFirstName = xmlSalesPerson.Item("DFirstName").InnerText
                    Catch
                    End Try
                    Try
                        .AddressLine1 = xmlSalesPerson.Item("AddressLine1").InnerText
                    Catch
                    End Try
                    Try
                        .AddressLine2 = xmlSalesPerson.Item("AddressLine2").InnerText
                    Catch
                    End Try
                    Try
                        .AddressLine3 = xmlSalesPerson.Item("AddressLine3").InnerText
                    Catch
                    End Try
                    Try
                        .City = xmlSalesPerson.Item("City").InnerText
                    Catch
                    End Try
                    Try
                        .State = xmlSalesPerson.Item("State").InnerText
                    Catch
                    End Try
                    Try
                        .ZipCode = xmlSalesPerson.Item("ZipCode").InnerText
                    Catch
                    End Try
                    Try
                        .CountryCode = xmlSalesPerson.Item("CountryCode").InnerText
                    Catch
                    End Try
                    Try
                        .PhoneNo = xmlSalesPerson.Item("PhoneNo").InnerText
                    Catch
                    End Try
                    Try
                        .Ext = xmlSalesPerson.Item("Ext").InnerText
                    Catch
                    End Try
                    Try
                        .EmailAddress = xmlSalesPerson.Item("EmailAddress").InnerText
                    Catch
                    End Try
                    Try
                        .CommRate = Double.Parse(xmlSalesPerson.Item("CommRate").InnerText)
                    Catch
                    End Try
                    Try
                        .AdminExempt = xmlSalesPerson.Item("AdminExempt").InnerText
                    Catch
                    End Try
                    Try
                        .Status = xmlSalesPerson.Item("Status").InnerText
                    Catch
                    End Try
                    Try
                        .DriverNotes = xmlSalesPerson.Item("DriverNotes").InnerText
                    Catch
                    End Try
                    Try
                        .LoadType = xmlSalesPerson.Item("LoadType").InnerText
                    Catch
                    End Try
                    Try
                        .LastLoad = Date.Parse(xmlSalesPerson.Item("LastLoad").InnerText)
                    Catch
                    End Try
                    Try
                        .SafetyAuth = xmlSalesPerson.Item("SafetyAuth").InnerText
                    Catch
                    End Try
                    Try
                        .CellPhone = xmlSalesPerson.Item("CellPhone").InnerText
                    Catch
                    End Try
                    Try
                        .Pager = xmlSalesPerson.Item("Pager").InnerText
                    Catch
                    End Try
                    Try
                        .AccountNo = xmlSalesPerson.Item("AccountNo").InnerText
                    Catch
                    End Try
                    Try
                        .OfficeOwner = xmlSalesPerson.Item("OfficeOwner").InnerText
                    Catch
                    End Try
                    Try
                        .FaxNo = xmlSalesPerson.Item("FaxNo").InnerText
                    Catch
                    End Try
                    Try
                        .JRCTrailer = xmlSalesPerson.Item("JRCTrailer").InnerText
                    Catch
                    End Try
                    Try
                        .LastLoadID = xmlSalesPerson.Item("LastLoadID").InnerText
                    Catch
                    End Try
                    Try
                        .LastPU = xmlSalesPerson.Item("LastPU").InnerText
                    Catch
                    End Try
                    Try
                        .LastDP = xmlSalesPerson.Item("LastDP").InnerText
                    Catch
                    End Try
                    Try
                        .SafetyNotes = xmlSalesPerson.Item("SafetyNotes").InnerText
                    Catch
                    End Try
                    Try
                        .LastTrailerUsed = xmlSalesPerson.Item("LastTrailerUsed").InnerText
                    Catch
                    End Try
                    Try
                        .LastLoadDeliv = Date.Parse(xmlSalesPerson.Item("LastLoadDeliv").InnerText)
                    Catch
                    End Try
                    Try
                        .DrugDate = Date.Parse(xmlSalesPerson.Item("DrugDate").InnerText)
                    Catch
                    End Try
                    Try
                        .LicenceDate = Date.Parse(xmlSalesPerson.Item("LicenceDate").InnerText)
                    Catch
                    End Try
                    Try
                        .TruckInsDate = Date.Parse(xmlSalesPerson.Item("TruckInsDate").InnerText)
                    Catch
                    End Try
                    Try
                        .TrailerInsDate = Date.Parse(xmlSalesPerson.Item("TrailerInsDate").InnerText)
                    Catch
                    End Try
                    Try
                        .RegRenewDate = Date.Parse(xmlSalesPerson.Item("RegRenewDate").InnerText)
                    Catch
                    End Try
                    Try
                        .NewLeaseDate = Date.Parse(xmlSalesPerson.Item("NewLeaseDate").InnerText)
                    Catch
                    End Try
                    Try
                        .InactivateDate = Date.Parse(xmlSalesPerson.Item("InactivateDate").InnerText)
                    Catch
                    End Try
                    Try
                        .MedicalDate = Date.Parse(xmlSalesPerson.Item("MedicalDate").InnerText)
                    Catch
                    End Try
                    Try
                        .LogBookOS = xmlSalesPerson.Item("LogBookOS").InnerText
                    Catch
                    End Try

                    Try
                        .MoMaint = Date.Parse(xmlSalesPerson.Item("MoMaint").InnerText)
                    Catch
                    End Try
                    Try
                        .DotInspec = Date.Parse(xmlSalesPerson.Item("DotInspec").InnerText)
                    Catch
                    End Try
                    Try
                        .TrailerMaint = Date.Parse(xmlSalesPerson.Item("TrailerMaint").InnerText)
                    Catch
                    End Try
                    Try
                        .RegRenew = Date.Parse(xmlSalesPerson.Item("RegRenew").InnerText)
                    Catch
                    End Try
                    Try
                        .OccIns = Date.Parse(xmlSalesPerson.Item("OccIns").InnerText)
                    Catch
                    End Try
                    Try
                        .NtlIns = Date.Parse(xmlSalesPerson.Item("NtlIns").InnerText)
                    Catch
                    End Try
                    Try
                        .PhysDmg = Date.Parse(xmlSalesPerson.Item("PhysDmg").InnerText)
                    Catch
                    End Try
                    Try
                        .SeaLink = Date.Parse(xmlSalesPerson.Item("SeaLink").InnerText)
                    Catch
                    End Try
                    Try
                        .AnnIns = Date.Parse(xmlSalesPerson.Item("AnnIns").InnerText)
                    Catch
                    End Try
                    Try
                        .ProbDriver = Boolean.Parse(xmlSalesPerson.Item("ProbDriver").InnerText)
                    Catch
                    End Try

                    Try
                        .Calc87 = xmlSalesPerson.Item("Calc87").InnerText
                    Catch
                    End Try
                    Try
                        .Calc85 = xmlSalesPerson.Item("Calc85").InnerText
                    Catch
                    End Try
                    Try
                        .BrokerCodeD = xmlSalesPerson.Item("BrokerCodeD").InnerText
                    Catch
                    End Try
                    Try
                        .DvrDedPct = Double.Parse(xmlSalesPerson.Item("DvrDedPct").InnerText)
                    Catch
                    End Try
                    Try
                        .DvrDedResn = xmlSalesPerson.Item("DvrDedResn").InnerText
                    Catch
                    End Try

                    Try
                        .Terminated = Boolean.Parse(xmlSalesPerson.Item("Terminated").InnerText)
                    Catch
                    End Try
                    Try
                        .Term_Staff = xmlSalesPerson.Item("Term_Staff").InnerText
                    Catch
                    End Try
                    Try
                        .Term_Date = Date.Parse(xmlSalesPerson.Item("Term_Date").InnerText)
                    Catch
                    End Try
                    Try
                        .Term_Reason = xmlSalesPerson.Item("Term_Reason").InnerText
                    Catch
                    End Try


                    Try
                        .ViewOrder = Integer.Parse(xmlSalesPerson.Item("ViewOrder").InnerText)
                    Catch
                    End Try
                    .CreatedByUser = UserId.ToString
                End With

                AddSalesPerson(objSalesPerson)
            Next

            'Import the Module Settings
            Dim objModules As New Entities.Modules.ModuleController
            Dim objOI As New OptionsInfo
            With objOI
                '.ModuleID = ModuleID

                'Control Options
                Try
                    .GetItems = Integer.Parse(xmlSalesPersons.SelectSingleNode("GetItems").InnerText)
                Catch
                End Try
                .ViewControl = xmlSalesPersons.SelectSingleNode("ViewControl").InnerText

                'Option1 Options
                Try
                    .PagerSize = Integer.Parse(xmlSalesPersons.SelectSingleNode("PagerSize").InnerText)
                Catch
                End Try


                .Update(ModuleID)
            End With

        End Sub

#End Region

    End Class 'SalesPersonsController


End Namespace
