Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.InterOffices.Business

    Public Class InterOfficeInfo
        Implements IHydratable
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ModuleId As Integer

        Private _jRCIOfficeCode As String
        Private _iOfficeCode As String
        Private _iOName As String
        Private _abvrName As String
        Private _addressLine1 As String
        Private _addressLine2 As String
        Private _city As String
        Private _state As String
        Private _zipCode As String
        Private _countryCode As String
        Private _phoneNo As String
        Private _ext As String
        Private _emailAddress As String

        Private _HasProbDrivers As Boolean

        Private _commRate As String
        Private _adminExempt As String
        Private _status As String
        Private _loadType As String
        Private _division As String
        Private _faxNo As String
        Private _officeOR As String
        Private _officeORAcct As String
        Private _officeORPct As Double
        Private _officeCodeNo As String
        Private _logOnPW As String
        Private _officName As String
        Private _officeAddr As String
        Private _officeAbrv As String
        Private _tempFile1 As String
        Private _oONo As String
        Private _bKNo As String
        Private _aVNo As String
        Private _useDispatch As String
        Private _officePct As Double
        Private _loadAcct As String
        Private _discAcct As String
        Private _detenAcct As String
        Private _tollsAcct As String
        Private _fuelAcct As String
        Private _dropAcct As String
        Private _reconAcct As String
        Private _tarpAcct As String
        Private _lumperAcct As String
        Private _unloadAcct As String
        Private _adminMiscAcct As String
        Private _bKOfficePct As Double
        Private _lastXferDate As DateTime
        Private _lastXmission As String
        Private _xfer As Decimal
        Private _noOffChar As Integer
        Private _allowORide As String
        Private _jRCAdminP As Double
        Private _reminder As String
        Private _defDispNo As String
        Private _defDispName As String
        Private _loadAcctB As String
        Private _discAcctB As String
        Private _detenAcctB As String
        Private _tollsAcctB As String
        Private _fuelAcctB As String
        Private _dropAcctB As String
        Private _reconAcctB As String
        Private _tarpAcctB As String
        Private _lumperAcctB As String
        Private _unloadAcctB As String
        Private _adminMiscAcctB As String
        Private _confName As String
        Private _confAddr As String
        Private _confSTZ As String
        Private _confPNo As String
        Private _bWordsA As String
        Private _bWordsB As String
        Private _bWordsC As String
        Private _pASplit As String
        Private _commAdj As String
        Private _multiSing As String
        Private _brokerOnly As String
        Private _autoLoadSeq As String
        Private _whatDivision As String
        Private _intraOComm As String
        Private _initQForCust As String
        Private _day0 As Decimal
        Private _day7 As Decimal
        Private _day15 As Decimal
        Private _day30 As Decimal
        Private _alumaPct As Double
        Private _lastcorpbu As DateTime
        Private _xMissionSeq As String
        Private _cNOfficName As String
        Private _offOrgin As String
        Private _doABU As String
        Private _tSL As String
        Private _tPBCalc As String
        Private _lastCustUpd As DateTime
        Private _lastUpdTime As DateTime
        Private _aPCodeFM As String
        Private _abvrNameFM As String
        Private _commRateFM As Double
        Private _bKCommRateFM As Double
        Private _subOffComm As String
        Private _userOn As Integer
        Private _mgrCode As String
        Private _mgrName As String
        Private _commRatex As Double
        Private _bKCommRate As Double
        Private _mGRSplit As String
        Private _iODiv As String
        Private _logDisp As String
        Private _logDispName As String
        Private _logonOffice As String
        Private _jRCOfficeNo As String
        Private _allowCDed As String
        Private _dvrDAcct1 As String
        Private _dvrDAcct2 As String
        Private _oOLoadNo As Integer
        Private _bKLoadNo As Integer
        Private _aVLoadNo As Integer
        Private _jRCActive As String
        Private _CopyAddress As Boolean
        Private _ShowOnWeb As Boolean
        Private _CorpOff As Boolean

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

        Public Property JRCIOfficeCode() As String
            Get
                Return _jRCIOfficeCode
            End Get
            Set(ByVal Value As String)
                _jRCIOfficeCode = Value
            End Set
        End Property

        Public Property IOfficeCode() As String
            Get
                Return _iOfficeCode
            End Get
            Set(ByVal Value As String)
                _iOfficeCode = Value
            End Set
        End Property

        Public Property IOName() As String
            Get
                Return _iOName
            End Get
            Set(ByVal Value As String)
                _iOName = Value
            End Set
        End Property

        Public Property AbvrName() As String
            Get
                Return _abvrName
            End Get
            Set(ByVal Value As String)
                _abvrName = Value
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
                _phoneNo = Value
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

        Public Property HasProbDrivers() As Boolean
            Get
                Return _HasProbDrivers
            End Get
            Set(ByVal value As Boolean)
                _HasProbDrivers = value
            End Set
        End Property

        Public Property CommRate() As String
            Get
                Return _commRate
            End Get
            Set(ByVal Value As String)
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

        Public Property LoadType() As String
            Get
                Return _loadType
            End Get
            Set(ByVal Value As String)
                _loadType = Value
            End Set
        End Property

        Public Property Division() As String
            Get
                Return _division
            End Get
            Set(ByVal Value As String)
                _division = Value
            End Set
        End Property

        Public Property FaxNo() As String
            Get
                Return _faxNo
            End Get
            Set(ByVal Value As String)
                _faxNo = Value
            End Set
        End Property

        Public Property OfficeOR() As String
            Get
                Return _officeOR
            End Get
            Set(ByVal Value As String)
                _officeOR = Value
            End Set
        End Property

        Public Property OfficeORAcct() As String
            Get
                Return _officeORAcct
            End Get
            Set(ByVal Value As String)
                _officeORAcct = Value
            End Set
        End Property

        Public Property OfficeORPct() As Double
            Get
                Return _officeORPct
            End Get
            Set(ByVal Value As Double)
                _officeORPct = Value
            End Set
        End Property

        Public Property OfficeCodeNo() As String
            Get
                Return _officeCodeNo
            End Get
            Set(ByVal Value As String)
                _officeCodeNo = Value
            End Set
        End Property

        Public Property LogOnPW() As String
            Get
                Return _logOnPW
            End Get
            Set(ByVal Value As String)
                _logOnPW = Value
            End Set
        End Property

        Public Property OfficName() As String
            Get
                Return _officName
            End Get
            Set(ByVal Value As String)
                _officName = Value
            End Set
        End Property

        Public Property OfficeAddr() As String
            Get
                Return _officeAddr
            End Get
            Set(ByVal Value As String)
                _officeAddr = Value
            End Set
        End Property

        Public Property OfficeAbrv() As String
            Get
                Return _officeAbrv
            End Get
            Set(ByVal Value As String)
                _officeAbrv = Value
            End Set
        End Property

        Public Property TempFile1() As String
            Get
                Return _tempFile1
            End Get
            Set(ByVal Value As String)
                _tempFile1 = Value
            End Set
        End Property

        Public Property OONo() As String
            Get
                Return _oONo
            End Get
            Set(ByVal Value As String)
                _oONo = Value
            End Set
        End Property

        Public Property BKNo() As String
            Get
                Return _bKNo
            End Get
            Set(ByVal Value As String)
                _bKNo = Value
            End Set
        End Property

        Public Property AVNo() As String
            Get
                Return _aVNo
            End Get
            Set(ByVal Value As String)
                _aVNo = Value
            End Set
        End Property

        Public Property UseDispatch() As String
            Get
                Return _useDispatch
            End Get
            Set(ByVal Value As String)
                _useDispatch = Value
            End Set
        End Property

        Public Property OfficePct() As Double
            Get
                Return _officePct
            End Get
            Set(ByVal Value As Double)
                _officePct = Value
            End Set
        End Property

        Public Property LoadAcct() As String
            Get
                Return _loadAcct
            End Get
            Set(ByVal Value As String)
                _loadAcct = Value
            End Set
        End Property

        Public Property DiscAcct() As String
            Get
                Return _discAcct
            End Get
            Set(ByVal Value As String)
                _discAcct = Value
            End Set
        End Property

        Public Property DetenAcct() As String
            Get
                Return _detenAcct
            End Get
            Set(ByVal Value As String)
                _detenAcct = Value
            End Set
        End Property

        Public Property TollsAcct() As String
            Get
                Return _tollsAcct
            End Get
            Set(ByVal Value As String)
                _tollsAcct = Value
            End Set
        End Property

        Public Property FuelAcct() As String
            Get
                Return _fuelAcct
            End Get
            Set(ByVal Value As String)
                _fuelAcct = Value
            End Set
        End Property

        Public Property DropAcct() As String
            Get
                Return _dropAcct
            End Get
            Set(ByVal Value As String)
                _dropAcct = Value
            End Set
        End Property

        Public Property ReconAcct() As String
            Get
                Return _reconAcct
            End Get
            Set(ByVal Value As String)
                _reconAcct = Value
            End Set
        End Property

        Public Property TarpAcct() As String
            Get
                Return _tarpAcct
            End Get
            Set(ByVal Value As String)
                _tarpAcct = Value
            End Set
        End Property

        Public Property LumperAcct() As String
            Get
                Return _lumperAcct
            End Get
            Set(ByVal Value As String)
                _lumperAcct = Value
            End Set
        End Property

        Public Property UnloadAcct() As String
            Get
                Return _unloadAcct
            End Get
            Set(ByVal Value As String)
                _unloadAcct = Value
            End Set
        End Property

        Public Property AdminMiscAcct() As String
            Get
                Return _adminMiscAcct
            End Get
            Set(ByVal Value As String)
                _adminMiscAcct = Value
            End Set
        End Property

        Public Property BKOfficePct() As Double
            Get
                Return _bKOfficePct
            End Get
            Set(ByVal Value As Double)
                _bKOfficePct = Value
            End Set
        End Property

        Public Property LastXferDate() As DateTime
            Get
                Return _lastXferDate
            End Get
            Set(ByVal Value As DateTime)
                _lastXferDate = Value
            End Set
        End Property

        Public Property LastXmission() As String
            Get
                Return _lastXmission
            End Get
            Set(ByVal Value As String)
                _lastXmission = Value
            End Set
        End Property

        Public Property Xfer() As Decimal
            Get
                Return _xfer
            End Get
            Set(ByVal Value As Decimal)
                _xfer = Value
            End Set
        End Property

        Public Property NoOffChar() As Integer
            Get
                Return _noOffChar
            End Get
            Set(ByVal Value As Integer)
                _noOffChar = Value
            End Set
        End Property

        Public Property AllowORide() As String
            Get
                Return _allowORide
            End Get
            Set(ByVal Value As String)
                _allowORide = Value
            End Set
        End Property

        Public Property JRCAdminP() As Double
            Get
                Return _jRCAdminP
            End Get
            Set(ByVal Value As Double)
                _jRCAdminP = Value
            End Set
        End Property

        Public Property Reminder() As String
            Get
                Return _reminder
            End Get
            Set(ByVal Value As String)
                _reminder = Value
            End Set
        End Property

        Public Property DefDispNo() As String
            Get
                Return _defDispNo
            End Get
            Set(ByVal Value As String)
                _defDispNo = Value
            End Set
        End Property

        Public Property DefDispName() As String
            Get
                Return _defDispName
            End Get
            Set(ByVal Value As String)
                _defDispName = Value
            End Set
        End Property

        Public Property LoadAcctB() As String
            Get
                Return _loadAcctB
            End Get
            Set(ByVal Value As String)
                _loadAcctB = Value
            End Set
        End Property

        Public Property DiscAcctB() As String
            Get
                Return _discAcctB
            End Get
            Set(ByVal Value As String)
                _discAcctB = Value
            End Set
        End Property

        Public Property DetenAcctB() As String
            Get
                Return _detenAcctB
            End Get
            Set(ByVal Value As String)
                _detenAcctB = Value
            End Set
        End Property

        Public Property TollsAcctB() As String
            Get
                Return _tollsAcctB
            End Get
            Set(ByVal Value As String)
                _tollsAcctB = Value
            End Set
        End Property

        Public Property FuelAcctB() As String
            Get
                Return _fuelAcctB
            End Get
            Set(ByVal Value As String)
                _fuelAcctB = Value
            End Set
        End Property

        Public Property DropAcctB() As String
            Get
                Return _dropAcctB
            End Get
            Set(ByVal Value As String)
                _dropAcctB = Value
            End Set
        End Property

        Public Property ReconAcctB() As String
            Get
                Return _reconAcctB
            End Get
            Set(ByVal Value As String)
                _reconAcctB = Value
            End Set
        End Property

        Public Property TarpAcctB() As String
            Get
                Return _tarpAcctB
            End Get
            Set(ByVal Value As String)
                _tarpAcctB = Value
            End Set
        End Property

        Public Property LumperAcctB() As String
            Get
                Return _lumperAcctB
            End Get
            Set(ByVal Value As String)
                _lumperAcctB = Value
            End Set
        End Property

        Public Property UnloadAcctB() As String
            Get
                Return _unloadAcctB
            End Get
            Set(ByVal Value As String)
                _unloadAcctB = Value
            End Set
        End Property

        Public Property AdminMiscAcctB() As String
            Get
                Return _adminMiscAcctB
            End Get
            Set(ByVal Value As String)
                _adminMiscAcctB = Value
            End Set
        End Property

        Public Property ConfName() As String
            Get
                Return _confName
            End Get
            Set(ByVal Value As String)
                _confName = Value
            End Set
        End Property

        Public Property ConfAddr() As String
            Get
                Return _confAddr
            End Get
            Set(ByVal Value As String)
                _confAddr = Value
            End Set
        End Property

        Public Property ConfSTZ() As String
            Get
                Return _confSTZ
            End Get
            Set(ByVal Value As String)
                _confSTZ = Value
            End Set
        End Property

        Public Property ConfPNo() As String
            Get
                Return _confPNo
            End Get
            Set(ByVal Value As String)
                _confPNo = Value
            End Set
        End Property

        Public Property BWordsA() As String
            Get
                Return _bWordsA
            End Get
            Set(ByVal Value As String)
                _bWordsA = Value
            End Set
        End Property

        Public Property BWordsB() As String
            Get
                Return _bWordsB
            End Get
            Set(ByVal Value As String)
                _bWordsB = Value
            End Set
        End Property

        Public Property BWordsC() As String
            Get
                Return _bWordsC
            End Get
            Set(ByVal Value As String)
                _bWordsC = Value
            End Set
        End Property

        Public Property PASplit() As String
            Get
                Return _pASplit
            End Get
            Set(ByVal Value As String)
                _pASplit = Value
            End Set
        End Property

        Public Property CommAdj() As String
            Get
                Return _commAdj
            End Get
            Set(ByVal Value As String)
                _commAdj = Value
            End Set
        End Property

        Public Property MultiSing() As String
            Get
                Return _multiSing
            End Get
            Set(ByVal Value As String)
                _multiSing = Value
            End Set
        End Property

        Public Property BrokerOnly() As String
            Get
                Return _brokerOnly
            End Get
            Set(ByVal Value As String)
                _brokerOnly = Value
            End Set
        End Property

        Public Property AutoLoadSeq() As String
            Get
                Return _autoLoadSeq
            End Get
            Set(ByVal Value As String)
                _autoLoadSeq = Value
            End Set
        End Property

        Public Property WhatDivision() As String
            Get
                Return _whatDivision
            End Get
            Set(ByVal Value As String)
                _whatDivision = Value
            End Set
        End Property

        Public Property IntraOComm() As String
            Get
                Return _intraOComm
            End Get
            Set(ByVal Value As String)
                _intraOComm = Value
            End Set
        End Property

        Public Property InitQForCust() As String
            Get
                Return _initQForCust
            End Get
            Set(ByVal Value As String)
                _initQForCust = Value
            End Set
        End Property

        Public Property Day0() As Decimal
            Get
                Return _day0
            End Get
            Set(ByVal Value As Decimal)
                _day0 = Value
            End Set
        End Property

        Public Property Day7() As Decimal
            Get
                Return _day7
            End Get
            Set(ByVal Value As Decimal)
                _day7 = Value
            End Set
        End Property

        Public Property Day15() As Decimal
            Get
                Return _day15
            End Get
            Set(ByVal Value As Decimal)
                _day15 = Value
            End Set
        End Property

        Public Property Day30() As Decimal
            Get
                Return _day30
            End Get
            Set(ByVal Value As Decimal)
                _day30 = Value
            End Set
        End Property

        Public Property AlumaPct() As Double
            Get
                Return _alumaPct
            End Get
            Set(ByVal Value As Double)
                _alumaPct = Value
            End Set
        End Property

        Public Property Lastcorpbu() As DateTime
            Get
                Return _lastcorpbu
            End Get
            Set(ByVal Value As DateTime)
                _lastcorpbu = Value
            End Set
        End Property

        Public Property XMissionSeq() As String
            Get
                Return _xMissionSeq
            End Get
            Set(ByVal Value As String)
                _xMissionSeq = Value
            End Set
        End Property

        Public Property CNOfficName() As String
            Get
                Return _cNOfficName
            End Get
            Set(ByVal Value As String)
                _cNOfficName = Value
            End Set
        End Property

        Public Property OffOrgin() As String
            Get
                Return _offOrgin
            End Get
            Set(ByVal Value As String)
                _offOrgin = Value
            End Set
        End Property

        Public Property DoABU() As String
            Get
                Return _doABU
            End Get
            Set(ByVal Value As String)
                _doABU = Value
            End Set
        End Property

        Public Property TSL() As String
            Get
                Return _tSL
            End Get
            Set(ByVal Value As String)
                _tSL = Value
            End Set
        End Property

        Public Property TPBCalc() As String
            Get
                Return _tPBCalc
            End Get
            Set(ByVal Value As String)
                _tPBCalc = Value
            End Set
        End Property

        Public Property LastCustUpd() As DateTime
            Get
                Return _lastCustUpd
            End Get
            Set(ByVal Value As DateTime)
                _lastCustUpd = Value
            End Set
        End Property

        Public Property LastUpdTime() As DateTime
            Get
                Return _lastUpdTime
            End Get
            Set(ByVal Value As DateTime)
                _lastUpdTime = Value
            End Set
        End Property

        Public Property APCodeFM() As String
            Get
                Return _aPCodeFM
            End Get
            Set(ByVal Value As String)
                _aPCodeFM = Value
            End Set
        End Property

        Public Property AbvrNameFM() As String
            Get
                Return _abvrNameFM
            End Get
            Set(ByVal Value As String)
                _abvrNameFM = Value
            End Set
        End Property

        Public Property CommRateFM() As Double
            Get
                Return _commRateFM
            End Get
            Set(ByVal Value As Double)
                _commRateFM = Value
            End Set
        End Property

        Public Property BKCommRateFM() As Double
            Get
                Return _bKCommRateFM
            End Get
            Set(ByVal Value As Double)
                _bKCommRateFM = Value
            End Set
        End Property

        Public Property SubOffComm() As String
            Get
                Return _subOffComm
            End Get
            Set(ByVal Value As String)
                _subOffComm = Value
            End Set
        End Property

        Public Property UserOn() As Integer
            Get
                Return _userOn
            End Get
            Set(ByVal Value As Integer)
                _userOn = Value
            End Set
        End Property

        Public Property MgrCode() As String
            Get
                Return _mgrCode
            End Get
            Set(ByVal Value As String)
                _mgrCode = Value
            End Set
        End Property

        Public Property MgrName() As String
            Get
                Return _mgrName
            End Get
            Set(ByVal Value As String)
                _mgrName = Value
            End Set
        End Property

        Public Property CommRatex() As Double
            Get
                Return _commRatex
            End Get
            Set(ByVal Value As Double)
                _commRatex = Value
            End Set
        End Property

        Public Property BKCommRate() As Double
            Get
                Return _bKCommRate
            End Get
            Set(ByVal Value As Double)
                _bKCommRate = Value
            End Set
        End Property

        Public Property MGRSplit() As String
            Get
                Return _mGRSplit
            End Get
            Set(ByVal Value As String)
                _mGRSplit = Value
            End Set
        End Property

        Public Property IODiv() As String
            Get
                Return _iODiv
            End Get
            Set(ByVal Value As String)
                _iODiv = Value
            End Set
        End Property

        Public Property LogDisp() As String
            Get
                Return _logDisp
            End Get
            Set(ByVal Value As String)
                _logDisp = Value
            End Set
        End Property

        Public Property LogDispName() As String
            Get
                Return _logDispName
            End Get
            Set(ByVal Value As String)
                _logDispName = Value
            End Set
        End Property

        Public Property LogonOffice() As String
            Get
                Return _logonOffice
            End Get
            Set(ByVal Value As String)
                _logonOffice = Value
            End Set
        End Property

        Public Property JRCOfficeNo() As String
            Get
                Return _jRCOfficeNo
            End Get
            Set(ByVal Value As String)
                _jRCOfficeNo = Value
            End Set
        End Property

        Public Property AllowCDed() As String
            Get
                Return _allowCDed
            End Get
            Set(ByVal Value As String)
                _allowCDed = Value
            End Set
        End Property

        Public Property DvrDAcct1() As String
            Get
                Return _dvrDAcct1
            End Get
            Set(ByVal Value As String)
                _dvrDAcct1 = Value
            End Set
        End Property

        Public Property DvrDAcct2() As String
            Get
                Return _dvrDAcct2
            End Get
            Set(ByVal Value As String)
                _dvrDAcct2 = Value
            End Set
        End Property

        Public Property OOLoadNo() As Integer
            Get
                Return _oOLoadNo
            End Get
            Set(ByVal Value As Integer)
                _oOLoadNo = Value
            End Set
        End Property

        Public Property BKLoadNo() As Integer
            Get
                Return _bKLoadNo
            End Get
            Set(ByVal Value As Integer)
                _bKLoadNo = Value
            End Set
        End Property

        Public Property AVLoadNo() As Integer
            Get
                Return _aVLoadNo
            End Get
            Set(ByVal Value As Integer)
                _aVLoadNo = Value
            End Set
        End Property

        Public Property JRCActive() As String
            Get
                Return _jRCActive
            End Get
            Set(ByVal Value As String)
                _jRCActive = Value
            End Set
        End Property


        Public Property CopyAddress() As Boolean
            Get
                Return _CopyAddress
            End Get
            Set(ByVal value As Boolean)
                _CopyAddress = value
            End Set
        End Property


        Public Property ShowOnWeb() As Boolean
            Get
                Return _ShowOnWeb
            End Get
            Set(ByVal value As Boolean)
                _ShowOnWeb = value
            End Set
        End Property


        Public Property CorpOff() As Boolean
            Get
                Return _CorpOff
            End Get
            Set(ByVal value As Boolean)
                _CorpOff = value
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

            Try


                'Insert the Actual Fields Below 

                _jRCIOfficeCode = Convert.ToString(Null.SetNull(dr("JRCIOfficeCode"), JRCIOfficeCode))
                _iOfficeCode = Convert.ToString(Null.SetNull(dr("IOfficeCode"), IOfficeCode))
                _IOName = Convert.ToString(Null.SetNull(dr("IOName"), IOName))
                _abvrName = Convert.ToString(Null.SetNull(dr("AbvrName"), AbvrName))
                _addressLine1 = Convert.ToString(Null.SetNull(dr("AddressLine1"), AddressLine1))
                _addressLine2 = Convert.ToString(Null.SetNull(dr("AddressLine2"), AddressLine2))
                _city = Convert.ToString(Null.SetNull(dr("City"), City))
                _state = Convert.ToString(Null.SetNull(dr("State"), State))
                _zipCode = Convert.ToString(Null.SetNull(dr("ZipCode"), ZipCode))
                _countryCode = Convert.ToString(Null.SetNull(dr("CountryCode"), CountryCode))
                _phoneNo = Convert.ToString(Null.SetNull(dr("PhoneNo"), PhoneNo))
                _ext = Convert.ToString(Null.SetNull(dr("Ext"), Ext))
                _emailAddress = Convert.ToString(Null.SetNull(dr("EmailAddress"), EmailAddress))

                _HasProbDrivers = Convert.ToBoolean(Null.SetNull(dr("HasProbDrivers"), HasProbDrivers))

                _commRate = Convert.ToString(Null.SetNull(dr("CommRate"), CommRate))
                _adminExempt = Convert.ToString(Null.SetNull(dr("AdminExempt"), AdminExempt))
                _status = Convert.ToString(Null.SetNull(dr("Status"), Status))
                _loadType = Convert.ToString(Null.SetNull(dr("LoadType"), LoadType))
                _division = Convert.ToString(Null.SetNull(dr("Division"), Division))
                _faxNo = Convert.ToString(Null.SetNull(dr("FaxNo"), FaxNo))
                _officeOR = Convert.ToString(Null.SetNull(dr("OfficeOR"), OfficeOR))
                _officeORAcct = Convert.ToString(Null.SetNull(dr("OfficeORAcct"), OfficeORAcct))
                _officeORPct = Convert.ToDouble(Null.SetNull(dr("OfficeORPct"), OfficeORPct))
                _officeCodeNo = Convert.ToString(Null.SetNull(dr("OfficeCodeNo"), OfficeCodeNo))
                _logOnPW = Convert.ToString(Null.SetNull(dr("LogOnPW"), LogOnPW))
                _officName = Convert.ToString(Null.SetNull(dr("OfficName"), OfficName))
                _officeAddr = Convert.ToString(Null.SetNull(dr("OfficeAddr"), OfficeAddr))
                _officeAbrv = Convert.ToString(Null.SetNull(dr("OfficeAbrv"), OfficeAbrv))
                _tempFile1 = Convert.ToString(Null.SetNull(dr("TempFile1"), TempFile1))
                _oONo = Convert.ToString(Null.SetNull(dr("OONo"), OONo))
                _bKNo = Convert.ToString(Null.SetNull(dr("BKNo"), BKNo))
                _aVNo = Convert.ToString(Null.SetNull(dr("AVNo"), AVNo))
                _useDispatch = Convert.ToString(Null.SetNull(dr("UseDispatch"), UseDispatch))
                _officePct = Convert.ToDouble(Null.SetNull(dr("OfficePct"), OfficePct))
                _loadAcct = Convert.ToString(Null.SetNull(dr("LoadAcct"), LoadAcct))
                _discAcct = Convert.ToString(Null.SetNull(dr("DiscAcct"), DiscAcct))
                _detenAcct = Convert.ToString(Null.SetNull(dr("DetenAcct"), DetenAcct))
                _tollsAcct = Convert.ToString(Null.SetNull(dr("TollsAcct"), TollsAcct))
                _fuelAcct = Convert.ToString(Null.SetNull(dr("FuelAcct"), FuelAcct))
                _dropAcct = Convert.ToString(Null.SetNull(dr("DropAcct"), DropAcct))
                _reconAcct = Convert.ToString(Null.SetNull(dr("ReconAcct"), ReconAcct))
                _tarpAcct = Convert.ToString(Null.SetNull(dr("TarpAcct"), TarpAcct))
                _lumperAcct = Convert.ToString(Null.SetNull(dr("LumperAcct"), LumperAcct))
                _unloadAcct = Convert.ToString(Null.SetNull(dr("UnloadAcct"), UnloadAcct))
                _adminMiscAcct = Convert.ToString(Null.SetNull(dr("AdminMiscAcct"), AdminMiscAcct))
                _bKOfficePct = Convert.ToDouble(Null.SetNull(dr("BKOfficePct"), BKOfficePct))
                _lastXferDate = Convert.ToDateTime(Null.SetNull(dr("LastXferDate"), LastXferDate))
                _lastXmission = Convert.ToString(Null.SetNull(dr("LastXmission"), LastXmission))
                _xfer = Convert.ToDecimal(Null.SetNull(dr("Xfer"), Xfer))
                _noOffChar = Convert.ToInt32(Null.SetNull(dr("NoOffChar"), NoOffChar))
                _allowORide = Convert.ToString(Null.SetNull(dr("AllowORide"), AllowORide))
                _jRCAdminP = Convert.ToDouble(Null.SetNull(dr("JRCAdminP"), JRCAdminP))
                _reminder = Convert.ToString(Null.SetNull(dr("Reminder"), Reminder))
                _defDispNo = Convert.ToString(Null.SetNull(dr("DefDispNo"), DefDispNo))
                _defDispName = Convert.ToString(Null.SetNull(dr("DefDispName"), DefDispName))
                _loadAcctB = Convert.ToString(Null.SetNull(dr("LoadAcctB"), LoadAcctB))
                _discAcctB = Convert.ToString(Null.SetNull(dr("DiscAcctB"), DiscAcctB))
                _detenAcctB = Convert.ToString(Null.SetNull(dr("DetenAcctB"), DetenAcctB))
                _tollsAcctB = Convert.ToString(Null.SetNull(dr("TollsAcctB"), TollsAcctB))
                _fuelAcctB = Convert.ToString(Null.SetNull(dr("FuelAcctB"), FuelAcctB))
                _dropAcctB = Convert.ToString(Null.SetNull(dr("DropAcctB"), DropAcctB))
                _reconAcctB = Convert.ToString(Null.SetNull(dr("ReconAcctB"), ReconAcctB))
                _tarpAcctB = Convert.ToString(Null.SetNull(dr("TarpAcctB"), TarpAcctB))
                _lumperAcctB = Convert.ToString(Null.SetNull(dr("LumperAcctB"), LumperAcctB))
                _unloadAcctB = Convert.ToString(Null.SetNull(dr("UnloadAcctB"), UnloadAcctB))
                _adminMiscAcctB = Convert.ToString(Null.SetNull(dr("AdminMiscAcctB"), AdminMiscAcctB))
                _confName = Convert.ToString(Null.SetNull(dr("ConfName"), ConfName))
                _confAddr = Convert.ToString(Null.SetNull(dr("ConfAddr"), ConfAddr))
                _confSTZ = Convert.ToString(Null.SetNull(dr("ConfSTZ"), ConfSTZ))
                _confPNo = Convert.ToString(Null.SetNull(dr("ConfPNo"), ConfPNo))
                _bWordsA = Convert.ToString(Null.SetNull(dr("BWordsA"), BWordsA))
                _bWordsB = Convert.ToString(Null.SetNull(dr("BWordsB"), BWordsB))
                _bWordsC = Convert.ToString(Null.SetNull(dr("BWordsC"), BWordsC))
                _pASplit = Convert.ToString(Null.SetNull(dr("PASplit"), PASplit))
                _commAdj = Convert.ToString(Null.SetNull(dr("CommAdj"), CommAdj))
                _multiSing = Convert.ToString(Null.SetNull(dr("MultiSing"), MultiSing))
                _brokerOnly = Convert.ToString(Null.SetNull(dr("BrokerOnly"), BrokerOnly))
                _autoLoadSeq = Convert.ToString(Null.SetNull(dr("AutoLoadSeq"), AutoLoadSeq))
                _whatDivision = Convert.ToString(Null.SetNull(dr("WhatDivision"), WhatDivision))
                _intraOComm = Convert.ToString(Null.SetNull(dr("IntraOComm"), IntraOComm))
                _initQForCust = Convert.ToString(Null.SetNull(dr("InitQForCust"), InitQForCust))
                _day0 = Convert.ToDecimal(Null.SetNull(dr("Day0"), Day0))
                _day7 = Convert.ToDecimal(Null.SetNull(dr("Day7"), Day7))
                _day15 = Convert.ToDecimal(Null.SetNull(dr("Day15"), Day15))
                _day30 = Convert.ToDecimal(Null.SetNull(dr("Day30"), Day30))
                _alumaPct = Convert.ToDouble(Null.SetNull(dr("AlumaPct"), AlumaPct))
                _lastcorpbu = Convert.ToDateTime(Null.SetNull(dr("Lastcorpbu"), Lastcorpbu))
                _xMissionSeq = Convert.ToString(Null.SetNull(dr("XMissionSeq"), XMissionSeq))
                _cNOfficName = Convert.ToString(Null.SetNull(dr("CNOfficName"), CNOfficName))
                _offOrgin = Convert.ToString(Null.SetNull(dr("OffOrgin"), OffOrgin))
                _doABU = Convert.ToString(Null.SetNull(dr("DoABU"), DoABU))
                _tSL = Convert.ToString(Null.SetNull(dr("TSL"), TSL))
                _tPBCalc = Convert.ToString(Null.SetNull(dr("TPBCalc"), TPBCalc))
                _lastCustUpd = Convert.ToDateTime(Null.SetNull(dr("LastCustUpd"), LastCustUpd))
                _lastUpdTime = Convert.ToDateTime(Null.SetNull(dr("LastUpdTime"), LastUpdTime))
                _aPCodeFM = Convert.ToString(Null.SetNull(dr("APCodeFM"), APCodeFM))
                _abvrNameFM = Convert.ToString(Null.SetNull(dr("AbvrNameFM"), AbvrNameFM))
                _commRateFM = Convert.ToDouble(Null.SetNull(dr("CommRateFM"), CommRateFM))
                _bKCommRateFM = Convert.ToDouble(Null.SetNull(dr("BKCommRateFM"), BKCommRateFM))
                _subOffComm = Convert.ToString(Null.SetNull(dr("SubOffComm"), SubOffComm))
                _userOn = Convert.ToInt32(Null.SetNull(dr("UserOn"), UserOn))
                _mgrCode = Convert.ToString(Null.SetNull(dr("MgrCode"), MgrCode))
                _mgrName = Convert.ToString(Null.SetNull(dr("MgrName"), MgrName))
                _commRatex = Convert.ToDouble(Null.SetNull(dr("CommRatex"), CommRatex))
                _bKCommRate = Convert.ToDouble(Null.SetNull(dr("BKCommRate"), BKCommRate))
                _mGRSplit = Convert.ToString(Null.SetNull(dr("MGRSplit"), MGRSplit))
                _iODiv = Convert.ToString(Null.SetNull(dr("IODiv"), IODiv))
                _logDisp = Convert.ToString(Null.SetNull(dr("LogDisp"), LogDisp))
                _logDispName = Convert.ToString(Null.SetNull(dr("LogDispName"), LogDispName))
                _logonOffice = Convert.ToString(Null.SetNull(dr("LogonOffice"), LogonOffice))
                _jRCOfficeNo = Convert.ToString(Null.SetNull(dr("JRCOfficeNo"), JRCOfficeNo))
                _allowCDed = Convert.ToString(Null.SetNull(dr("AllowCDed"), AllowCDed))
                _dvrDAcct1 = Convert.ToString(Null.SetNull(dr("DvrDAcct1"), DvrDAcct1))
                _dvrDAcct2 = Convert.ToString(Null.SetNull(dr("DvrDAcct2"), DvrDAcct2))
                _oOLoadNo = Convert.ToInt32(Null.SetNull(dr("OOLoadNo"), OOLoadNo))
                _bKLoadNo = Convert.ToInt32(Null.SetNull(dr("BKLoadNo"), BKLoadNo))
                _aVLoadNo = Convert.ToInt32(Null.SetNull(dr("AVLoadNo"), AVLoadNo))
                _jRCActive = Convert.ToString(Null.SetNull(dr("JRCActive"), JRCActive))
                _CopyAddress = Convert.ToBoolean(Null.SetNull(dr("CopyAddress"), CopyAddress))
                _ShowOnWeb = Convert.ToBoolean(Null.SetNull(dr("ShowOnWeb"), ShowOnWeb))
                _CorpOff = Convert.ToBoolean(Null.SetNull(dr("CorpOff"), CorpOff))

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

    Public Class InterOfficesController
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
        Public Function AddInterOffice(ByVal objInterOffice As InterOfficeInfo) As Integer
            With objInterOffice
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddInterOffice", .ModuleId, GetNull(.JRCIOfficeCode), GetNull(.IOfficeCode), GetNull(.IOName), GetNull(.AbvrName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.CountryCode), GetNull(.PhoneNo), GetNull(.Ext), GetNull(.EmailAddress), GetNull(.HasProbDrivers), GetNull(.CommRate), GetNull(.AdminExempt), GetNull(.Status), GetNull(.LoadType), GetNull(.Division), GetNull(.FaxNo), GetNull(.OfficeOR), GetNull(.OfficeORAcct), GetNull(.OfficeORPct), GetNull(.OfficeCodeNo), GetNull(.LogOnPW), GetNull(.OfficName), GetNull(.OfficeAddr), GetNull(.OfficeAbrv), GetNull(.TempFile1), GetNull(.OONo), GetNull(.BKNo), GetNull(.AVNo), GetNull(.UseDispatch), GetNull(.OfficePct), GetNull(.LoadAcct), GetNull(.DiscAcct), GetNull(.DetenAcct), GetNull(.TollsAcct), GetNull(.FuelAcct), GetNull(.DropAcct), GetNull(.ReconAcct), GetNull(.TarpAcct), GetNull(.LumperAcct), GetNull(.UnloadAcct), GetNull(.AdminMiscAcct), GetNull(.BKOfficePct), GetNull(.LastXferDate), GetNull(.LastXmission), GetNull(.Xfer), GetNull(.NoOffChar), GetNull(.AllowORide), GetNull(.JRCAdminP), GetNull(.Reminder), GetNull(.DefDispNo), GetNull(.DefDispName), GetNull(.LoadAcctB), GetNull(.DiscAcctB), GetNull(.DetenAcctB), GetNull(.TollsAcctB), GetNull(.FuelAcctB), GetNull(.DropAcctB), GetNull(.ReconAcctB), GetNull(.TarpAcctB), GetNull(.LumperAcctB), GetNull(.UnloadAcctB), GetNull(.AdminMiscAcctB), GetNull(.ConfName), GetNull(.ConfAddr), GetNull(.ConfSTZ), GetNull(.ConfPNo), GetNull(.BWordsA), GetNull(.BWordsB), GetNull(.BWordsC), GetNull(.PASplit), GetNull(.CommAdj), GetNull(.MultiSing), GetNull(.BrokerOnly), GetNull(.AutoLoadSeq), GetNull(.WhatDivision), GetNull(.IntraOComm), GetNull(.InitQForCust), GetNull(.Day0), GetNull(.Day7), GetNull(.Day15), GetNull(.Day30), GetNull(.AlumaPct), GetNull(.Lastcorpbu), GetNull(.XMissionSeq), GetNull(.CNOfficName), GetNull(.OffOrgin), GetNull(.DoABU), GetNull(.TSL), GetNull(.TPBCalc), GetNull(.LastCustUpd), GetNull(.LastUpdTime), GetNull(.APCodeFM), GetNull(.AbvrNameFM), GetNull(.CommRateFM), GetNull(.BKCommRateFM), GetNull(.SubOffComm), GetNull(.UserOn), GetNull(.MgrCode), GetNull(.MgrName), GetNull(.CommRatex), GetNull(.BKCommRate), GetNull(.MGRSplit), GetNull(.IODiv), GetNull(.LogDisp), GetNull(.LogDispName), GetNull(.LogonOffice), GetNull(.JRCOfficeNo), GetNull(.AllowCDed), GetNull(.DvrDAcct1), GetNull(.DvrDAcct2), GetNull(.OOLoadNo), GetNull(.BKLoadNo), GetNull(.AVLoadNo), GetNull(.JRCActive), GetNull(.CopyAddress), GetNull(.ShowOnWeb), GetNull(.CorpOff), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        Public Sub UpdateInterOffice(ByVal objInterOffice As InterOfficeInfo)
            With objInterOffice
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateInterOffice", .ItemId, GetNull(.JRCIOfficeCode), GetNull(.IOfficeCode), GetNull(.IOName), GetNull(.AbvrName), GetNull(.AddressLine1), GetNull(.AddressLine2), GetNull(.City), GetNull(.State), GetNull(.ZipCode), GetNull(.CountryCode), GetNull(.PhoneNo), GetNull(.Ext), GetNull(.EmailAddress), GetNull(.HasProbDrivers), GetNull(.CommRate), GetNull(.AdminExempt), GetNull(.Status), GetNull(.LoadType), GetNull(.Division), GetNull(.FaxNo), GetNull(.OfficeOR), GetNull(.OfficeORAcct), GetNull(.OfficeORPct), GetNull(.OfficeCodeNo), GetNull(.LogOnPW), GetNull(.OfficName), GetNull(.OfficeAddr), GetNull(.OfficeAbrv), GetNull(.TempFile1), GetNull(.OONo), GetNull(.BKNo), GetNull(.AVNo), GetNull(.UseDispatch), GetNull(.OfficePct), GetNull(.LoadAcct), GetNull(.DiscAcct), GetNull(.DetenAcct), GetNull(.TollsAcct), GetNull(.FuelAcct), GetNull(.DropAcct), GetNull(.ReconAcct), GetNull(.TarpAcct), GetNull(.LumperAcct), GetNull(.UnloadAcct), GetNull(.AdminMiscAcct), GetNull(.BKOfficePct), GetNull(.LastXferDate), GetNull(.LastXmission), GetNull(.Xfer), GetNull(.NoOffChar), GetNull(.AllowORide), GetNull(.JRCAdminP), GetNull(.Reminder), GetNull(.DefDispNo), GetNull(.DefDispName), GetNull(.LoadAcctB), GetNull(.DiscAcctB), GetNull(.DetenAcctB), GetNull(.TollsAcctB), GetNull(.FuelAcctB), GetNull(.DropAcctB), GetNull(.ReconAcctB), GetNull(.TarpAcctB), GetNull(.LumperAcctB), GetNull(.UnloadAcctB), GetNull(.AdminMiscAcctB), GetNull(.ConfName), GetNull(.ConfAddr), GetNull(.ConfSTZ), GetNull(.ConfPNo), GetNull(.BWordsA), GetNull(.BWordsB), GetNull(.BWordsC), GetNull(.PASplit), GetNull(.CommAdj), GetNull(.MultiSing), GetNull(.BrokerOnly), GetNull(.AutoLoadSeq), GetNull(.WhatDivision), GetNull(.IntraOComm), GetNull(.InitQForCust), GetNull(.Day0), GetNull(.Day7), GetNull(.Day15), GetNull(.Day30), GetNull(.AlumaPct), GetNull(.Lastcorpbu), GetNull(.XMissionSeq), GetNull(.CNOfficName), GetNull(.OffOrgin), GetNull(.DoABU), GetNull(.TSL), GetNull(.TPBCalc), GetNull(.LastCustUpd), GetNull(.LastUpdTime), GetNull(.APCodeFM), GetNull(.AbvrNameFM), GetNull(.CommRateFM), GetNull(.BKCommRateFM), GetNull(.SubOffComm), GetNull(.UserOn), GetNull(.MgrCode), GetNull(.MgrName), GetNull(.CommRatex), GetNull(.BKCommRate), GetNull(.MGRSplit), GetNull(.IODiv), GetNull(.LogDisp), GetNull(.LogDispName), GetNull(.LogonOffice), GetNull(.JRCOfficeNo), GetNull(.AllowCDed), GetNull(.DvrDAcct1), GetNull(.DvrDAcct2), GetNull(.OOLoadNo), GetNull(.BKLoadNo), GetNull(.AVLoadNo), GetNull(.JRCActive), GetNull(.CopyAddress), GetNull(.ShowOnWeb), GetNull(.CorpOff), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
        End Sub

        Public Sub UpdateInterOfficeXmission(ByVal JRCIOfficeCode As String, ByVal Xfer As Double, ByVal LastXferDate As Date, ByVal LastXmission As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateInterOfficeXmission", JRCIOfficeCode, Xfer, GetNull(LastXferDate), GetNull(LastXmission))
        End Sub

        Public Sub DeleteInterOffice(ByVal objInterOffice As InterOfficeInfo)
            DeleteInterOffice(objInterOffice.ItemId)
        End Sub

        Public Sub DeleteInterOffice(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteInterOffice", ItemID)
        End Sub

        Public Sub FixInterOffices(ByVal ModuleID As Integer, ByVal UpdatedByUserId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_FixInterOffices", ModuleID, UpdatedByUserId)
        End Sub

        Public Sub SortInterOffices(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortInterOffices", ModuleID)
        End Sub

        Public Function IsUniqueCode(ByVal JRCIOfficeCode As String) As Boolean
            Return GetInterOfficeId(JRCIOfficeCode) < 1
        End Function

        Public Function GetInterOfficeId(ByVal JRCIOfficeCode As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetInterOfficeId", JRCIOfficeCode))
        End Function

        Public Function GetInterOffice(ByVal JRCIOfficeCode As String) As InterOfficeInfo
            Return GetInterOffice(GetInterOfficeId(JRCIOfficeCode))
        End Function
        Public Function GetInterOffice(ByVal ItemID As Integer) As InterOfficeInfo
            'Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetInterOffice", ItemID), GetType(InterOfficeInfo)), InterOfficeInfo)
            Return CBO.FillObject(Of InterOfficeInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetInterOffice", ItemID))
        End Function

        'This function retreives the Items from Database, 
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()
        Public Function GetInterOfficesForGrid(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable 'ArrayList 'IDataReader '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If ((New OptionsInfo(ModuleId)).ViewControl.ToUpper = "WORDS") AndAlso (Not Users.UserController.GetCurrentUserInfo.IsSuperUser) Then
                Dim LoginName As String = Users.UserController.GetCurrentUserInfo.Username
                Dim dt As New DataTable
                dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetUserIOs", LoginName))
                Return dt
                'Return GetUserIOs(LoginName)
            Else
                Return GetInterOffices(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            End If
        End Function

        Public Function GetUserIOs(ByVal Username As String) As ArrayList
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetUserIOs", Username), GetType(InterOfficeInfo))
        End Function

        Public Function GetInterOffices(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable
            Dim dt As New DataTable
            dt.Load(GetInterOfficesCommons(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
            Return dt
        End Function
        Public Function GetInterOfficesCommons(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As IDataReader 'ArrayList '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If SearchText <> "" Then
                Return GetSearchedInterOffices(SearchText, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            Else
                Select Case GetItems
                    Case 0
                        If ModuleId > -1 Then
                            Return GetModuleInterOffices(ModuleId, NoOfItems)
                        Else
                            Return GetAllInterOffices(NoOfItems)
                        End If
                    Case 1
                        If PortalId > -1 Then
                            Return GetPortalInterOffices(PortalId, NoOfItems)
                        Else
                            Return GetAllInterOffices(NoOfItems)
                        End If
                    Case 2
                        Return GetAllInterOffices(NoOfItems)
                    Case Else '0
                        If PortalId > -1 Then
                            Return GetPortalInterOffices(PortalId, NoOfItems)
                        ElseIf ModuleId > -1 Then
                            Return GetModuleInterOffices(ModuleId, NoOfItems)
                        Else
                            Return GetAllInterOffices(NoOfItems)
                        End If
                End Select
            End If
        End Function

        Public Function GetModuleInterOffices(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetModuleInterOffices", ModuleId, NoOfItems), GetType(InterOfficeInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleInterOffices", ModuleId, NoOfItems)
        End Function

        Public Function GetPortalInterOffices(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetPortalInterOffices", PortalId, NoOfItems), GetType(InterOfficeInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalInterOffices", PortalId, NoOfItems)
        End Function

        Public Function GetAllInterOffices(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            'Return CBO.FillCollection(DataProvider.Instance().ExecuteReader("bhattji_GetAllInterOffices", NoOfItems), GetType(InterOfficeInfo))
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllInterOffices", NoOfItems)
        End Function

        Public Function GetSearchedInterOffices(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'ArrayList '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""


            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleInterOffices(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalInterOffices(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalInterOffices(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleInterOffices(ModuleId)
                    End If
            End Select

            Dim strSearchText As String
            If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

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
            sbSql.Append("JRCIOfficeCode, ")
            sbSql.Append("JRCActive, ")
            sbSql.Append("IOName, ")

            sbSql.Append("APCodeFM, ")
            sbSql.Append("AbvrNameFM, ")
            sbSql.Append("CommRateFM, ")
            sbSql.Append("BKCommRateFM, ")

            sbSql.Append("City, ")
            sbSql.Append("State ")

            sbSql.Append("FROM " & MyOjectQualifier & "ARD_InterOffice AS x ")


            Select Case SearchOn.ToUpper
                Case "IONAME", "JRCIOFFICECODE"
                    sbSql.Append("WHERE (x." & SearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x." & SearchOn & ", x.ViewOrder, x.UpdatedDate desc ")


                Case Else '"ANY"
                    sbSql.Append("WHERE ((x.IOName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.JRCIOfficeCode LIKE '" & strSearchText & "')) ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    sbSql.Append("ORDER BY x.IOName, x.ViewOrder, x.UpdatedDate desc ")

            End Select

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString), GetType(InterOfficeInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function

        Public Function GetNoOfProbDrivers(ByVal JRCIOfficeCode As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetNoOfProbDrivers", JRCIOfficeCode))
        End Function
        Public Function DoesHaveProbDrivers(ByVal JRCIOfficeCode As String) As Boolean
            Return GetNoOfProbDrivers(JRCIOfficeCode) > 0
        End Function
        Public Sub UpdateInterOffices4HasProbDrivers()
            UpdateInterOffices4HasProbDrivers("")
        End Sub
        Public Sub UpdateInterOffices4HasProbDrivers(ByVal JRCIOfficeCode As String)
            Dim strSql As String = "Select JRCIOfficeCode, HasProbDrivers FROM ARD_InterOffice "
            If JRCIOfficeCode <> "" AndAlso JRCIOfficeCode <> "000000000" Then
                strSql &= " WHERE JRCIOfficeCode='" & JRCIOfficeCode & "' "
            End If

            Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(strSql)
            If Not dr Is Nothing Then
                Dim OfficeCode9 As String
                Dim HasProbDrivers As Boolean
                Dim IsProblematic As Boolean
                While dr.Read()
                    OfficeCode9 = Convert.ToString(Null.SetNull(dr("JRCIOfficeCode"), Null.NullString))
                    HasProbDrivers = Convert.ToBoolean(Null.SetNull(dr("HasProbDrivers"), Null.NullBoolean))
                    IsProblematic = DoesHaveProbDrivers(OfficeCode9)
                    If HasProbDrivers <> IsProblematic Then
                        DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateInterOffice4HasProbDriver", OfficeCode9, IsProblematic)
                    End If
                End While
            End If
        End Sub
        'Public Sub UpdateInterOffice4HasProbDrivers(ByVal JRCIOfficeCode As String, ByVal HasProbDrivers As Boolean)
        '    DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateInterOffice4HasProbDriver", JRCIOfficeCode, HasProbDrivers)
        'End Sub

        Public Function GetStateCodes() As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetStateCodes")
        End Function
#End Region

#Region " Optional Interfaces "

        Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As DotNetNuke.Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
            Dim SearchItemCollection As New SearchItemInfoCollection

            'Dim InterOffices As ArrayList = GetInterOffices(ModInfo.ModuleID)
            Dim InterOffices As List(Of InterOfficeInfo) = CBO.FillCollection(Of InterOfficeInfo)(GetModuleInterOffices(ModInfo.ModuleID))
            Dim objInterOffice As Object
            For Each objInterOffice In InterOffices
                Dim SearchItem As SearchItemInfo
                With CType(objInterOffice, InterOfficeInfo)
                    ' 
                    Dim UserId As Integer = Null.NullInteger
                    If IsNumeric(.CreatedByUser) Then
                        UserId = Integer.Parse(.CreatedByUser)
                    End If

                    Dim strContent As String = System.Web.HttpUtility.HtmlDecode(.IOName)
                    Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(.IOName), False), 100, "...")

                    SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .IOName, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent, "ItemId=" & .ItemId.ToString, Null.NullInteger)
                    SearchItemCollection.Add(SearchItem)
                End With
            Next

            Return SearchItemCollection

        End Function

        Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
            Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
            Dim strXML As String = ""
            strXML += "<InterOffices>"

            'Export each InterOffice Details
            'Dim arrInterOffices As ArrayList = GetInterOffices(ModuleID)
            Dim arrInterOffices As List(Of InterOfficeInfo) = CBO.FillCollection(Of InterOfficeInfo)(GetModuleInterOffices(ModuleID))
            If arrInterOffices.Count <> 0 Then
                Dim objInterOffice As InterOfficeInfo
                For Each objInterOffice In arrInterOffices
                    With objInterOffice
                        strXML += "<InterOffice>"

                        strXML &= "<JRCIOfficeCode>" & XMLEncode(.JRCIOfficeCode) & "</JRCIOfficeCode>"
                        strXML &= "<IOfficeCode>" & XMLEncode(.IOfficeCode) & "</IOfficeCode>"
                        strXML &= "<IOName>" & XMLEncode(.IOName) & "</IOName>"
                        strXML &= "<AbvrName>" & XMLEncode(.AbvrName) & "</AbvrName>"
                        strXML &= "<AddressLine1>" & XMLEncode(.AddressLine1) & "</AddressLine1>"
                        strXML &= "<AddressLine2>" & XMLEncode(.AddressLine2) & "</AddressLine2>"
                        strXML &= "<City>" & XMLEncode(.City) & "</City>"
                        strXML &= "<State>" & XMLEncode(.State) & "</State>"
                        strXML &= "<ZipCode>" & XMLEncode(.ZipCode) & "</ZipCode>"
                        strXML &= "<CountryCode>" & XMLEncode(.CountryCode) & "</CountryCode>"
                        strXML &= "<PhoneNo>" & XMLEncode(.PhoneNo) & "</PhoneNo>"
                        strXML &= "<Ext>" & XMLEncode(.Ext) & "</Ext>"
                        strXML &= "<EmailAddress>" & XMLEncode(.EmailAddress) & "</EmailAddress>"

                        strXML &= "<HasProbDrivers>" & XMLEncode(.HasProbDrivers.ToString) & "</HasProbDrivers>"

                        strXML &= "<CommRate>" & XMLEncode(.CommRate) & "</CommRate>"
                        strXML &= "<AdminExempt>" & XMLEncode(.AdminExempt) & "</AdminExempt>"
                        strXML &= "<Status>" & XMLEncode(.Status) & "</Status>"
                        strXML &= "<LoadType>" & XMLEncode(.LoadType) & "</LoadType>"
                        strXML &= "<Division>" & XMLEncode(.Division) & "</Division>"
                        strXML &= "<FaxNo>" & XMLEncode(.FaxNo) & "</FaxNo>"
                        strXML &= "<OfficeOR>" & XMLEncode(.OfficeOR) & "</OfficeOR>"
                        strXML &= "<OfficeORAcct>" & XMLEncode(.OfficeORAcct) & "</OfficeORAcct>"
                        strXML &= "<OfficeORPct>" & XMLEncode(.OfficeORPct.ToString) & "</OfficeORPct>"
                        strXML &= "<OfficeCodeNo>" & XMLEncode(.OfficeCodeNo) & "</OfficeCodeNo>"
                        strXML &= "<LogOnPW>" & XMLEncode(.LogOnPW) & "</LogOnPW>"
                        strXML &= "<OfficName>" & XMLEncode(.OfficName) & "</OfficName>"
                        strXML &= "<OfficeAddr>" & XMLEncode(.OfficeAddr) & "</OfficeAddr>"
                        strXML &= "<OfficeAbrv>" & XMLEncode(.OfficeAbrv) & "</OfficeAbrv>"
                        strXML &= "<TempFile1>" & XMLEncode(.TempFile1) & "</TempFile1>"
                        strXML &= "<OONo>" & XMLEncode(.OONo) & "</OONo>"
                        strXML &= "<BKNo>" & XMLEncode(.BKNo) & "</BKNo>"
                        strXML &= "<AVNo>" & XMLEncode(.AVNo) & "</AVNo>"
                        strXML &= "<UseDispatch>" & XMLEncode(.UseDispatch) & "</UseDispatch>"
                        strXML &= "<OfficePct>" & XMLEncode(.OfficePct.ToString) & "</OfficePct>"
                        strXML &= "<LoadAcct>" & XMLEncode(.LoadAcct) & "</LoadAcct>"
                        strXML &= "<DiscAcct>" & XMLEncode(.DiscAcct) & "</DiscAcct>"
                        strXML &= "<DetenAcct>" & XMLEncode(.DetenAcct) & "</DetenAcct>"
                        strXML &= "<TollsAcct>" & XMLEncode(.TollsAcct) & "</TollsAcct>"
                        strXML &= "<FuelAcct>" & XMLEncode(.FuelAcct) & "</FuelAcct>"
                        strXML &= "<DropAcct>" & XMLEncode(.DropAcct) & "</DropAcct>"
                        strXML &= "<ReconAcct>" & XMLEncode(.ReconAcct) & "</ReconAcct>"
                        strXML &= "<TarpAcct>" & XMLEncode(.TarpAcct) & "</TarpAcct>"
                        strXML &= "<LumperAcct>" & XMLEncode(.LumperAcct) & "</LumperAcct>"
                        strXML &= "<UnloadAcct>" & XMLEncode(.UnloadAcct) & "</UnloadAcct>"
                        strXML &= "<AdminMiscAcct>" & XMLEncode(.AdminMiscAcct) & "</AdminMiscAcct>"
                        strXML &= "<BKOfficePct>" & XMLEncode(.BKOfficePct.ToString) & "</BKOfficePct>"
                        strXML &= "<LastXferDate>" & XMLEncode(.LastXferDate.ToString) & "</LastXferDate>"
                        strXML &= "<LastXmission>" & XMLEncode(.LastXmission) & "</LastXmission>"
                        strXML &= "<Xfer>" & XMLEncode(.Xfer.ToString) & "</Xfer>"
                        strXML &= "<NoOffChar>" & XMLEncode(.NoOffChar.ToString) & "</NoOffChar>"
                        strXML &= "<AllowORide>" & XMLEncode(.AllowORide) & "</AllowORide>"
                        strXML &= "<JRCAdminP>" & XMLEncode(.JRCAdminP.ToString) & "</JRCAdminP>"
                        strXML &= "<Reminder>" & XMLEncode(.Reminder) & "</Reminder>"
                        strXML &= "<DefDispNo>" & XMLEncode(.DefDispNo) & "</DefDispNo>"
                        strXML &= "<DefDispName>" & XMLEncode(.DefDispName) & "</DefDispName>"
                        strXML &= "<LoadAcctB>" & XMLEncode(.LoadAcctB) & "</LoadAcctB>"
                        strXML &= "<DiscAcctB>" & XMLEncode(.DiscAcctB) & "</DiscAcctB>"
                        strXML &= "<DetenAcctB>" & XMLEncode(.DetenAcctB) & "</DetenAcctB>"
                        strXML &= "<TollsAcctB>" & XMLEncode(.TollsAcctB) & "</TollsAcctB>"
                        strXML &= "<FuelAcctB>" & XMLEncode(.FuelAcctB) & "</FuelAcctB>"
                        strXML &= "<DropAcctB>" & XMLEncode(.DropAcctB) & "</DropAcctB>"
                        strXML &= "<ReconAcctB>" & XMLEncode(.ReconAcctB) & "</ReconAcctB>"
                        strXML &= "<TarpAcctB>" & XMLEncode(.TarpAcctB) & "</TarpAcctB>"
                        strXML &= "<LumperAcctB>" & XMLEncode(.LumperAcctB) & "</LumperAcctB>"
                        strXML &= "<UnloadAcctB>" & XMLEncode(.UnloadAcctB) & "</UnloadAcctB>"
                        strXML &= "<AdminMiscAcctB>" & XMLEncode(.AdminMiscAcctB) & "</AdminMiscAcctB>"
                        strXML &= "<ConfName>" & XMLEncode(.ConfName) & "</ConfName>"
                        strXML &= "<ConfAddr>" & XMLEncode(.ConfAddr) & "</ConfAddr>"
                        strXML &= "<ConfSTZ>" & XMLEncode(.ConfSTZ) & "</ConfSTZ>"
                        strXML &= "<ConfPNo>" & XMLEncode(.ConfPNo) & "</ConfPNo>"
                        strXML &= "<BWordsA>" & XMLEncode(.BWordsA) & "</BWordsA>"
                        strXML &= "<BWordsB>" & XMLEncode(.BWordsB) & "</BWordsB>"
                        strXML &= "<BWordsC>" & XMLEncode(.BWordsC) & "</BWordsC>"
                        strXML &= "<PASplit>" & XMLEncode(.PASplit) & "</PASplit>"
                        strXML &= "<CommAdj>" & XMLEncode(.CommAdj) & "</CommAdj>"
                        strXML &= "<MultiSing>" & XMLEncode(.MultiSing) & "</MultiSing>"
                        strXML &= "<BrokerOnly>" & XMLEncode(.BrokerOnly) & "</BrokerOnly>"
                        strXML &= "<AutoLoadSeq>" & XMLEncode(.AutoLoadSeq) & "</AutoLoadSeq>"
                        strXML &= "<WhatDivision>" & XMLEncode(.WhatDivision) & "</WhatDivision>"
                        strXML &= "<IntraOComm>" & XMLEncode(.IntraOComm) & "</IntraOComm>"
                        strXML &= "<InitQForCust>" & XMLEncode(.InitQForCust) & "</InitQForCust>"
                        strXML &= "<Day0>" & XMLEncode(.Day0.ToString) & "</Day0>"
                        strXML &= "<Day7>" & XMLEncode(.Day7.ToString) & "</Day7>"
                        strXML &= "<Day15>" & XMLEncode(.Day15.ToString) & "</Day15>"
                        strXML &= "<Day30>" & XMLEncode(.Day30.ToString) & "</Day30>"
                        strXML &= "<AlumaPct>" & XMLEncode(.AlumaPct.ToString) & "</AlumaPct>"
                        strXML &= "<Lastcorpbu>" & XMLEncode(.Lastcorpbu.ToString) & "</Lastcorpbu>"
                        strXML &= "<XMissionSeq>" & XMLEncode(.XMissionSeq) & "</XMissionSeq>"
                        strXML &= "<CNOfficName>" & XMLEncode(.CNOfficName) & "</CNOfficName>"
                        strXML &= "<OffOrgin>" & XMLEncode(.OffOrgin) & "</OffOrgin>"
                        strXML &= "<DoABU>" & XMLEncode(.DoABU) & "</DoABU>"
                        strXML &= "<TSL>" & XMLEncode(.TSL) & "</TSL>"
                        strXML &= "<TPBCalc>" & XMLEncode(.TPBCalc) & "</TPBCalc>"
                        strXML &= "<LastCustUpd>" & XMLEncode(.LastCustUpd.ToString) & "</LastCustUpd>"
                        strXML &= "<LastUpdTime>" & XMLEncode(.LastUpdTime.ToString) & "</LastUpdTime>"
                        strXML &= "<APCodeFM>" & XMLEncode(.APCodeFM) & "</APCodeFM>"
                        strXML &= "<AbvrNameFM>" & XMLEncode(.AbvrNameFM) & "</AbvrNameFM>"
                        strXML &= "<CommRateFM>" & XMLEncode(.CommRateFM.ToString) & "</CommRateFM>"
                        strXML &= "<BKCommRateFM>" & XMLEncode(.BKCommRateFM.ToString) & "</BKCommRateFM>"
                        strXML &= "<SubOffComm>" & XMLEncode(.SubOffComm) & "</SubOffComm>"
                        strXML &= "<UserOn>" & XMLEncode(.UserOn.ToString) & "</UserOn>"
                        strXML &= "<MgrCode>" & XMLEncode(.MgrCode) & "</MgrCode>"
                        strXML &= "<MgrName>" & XMLEncode(.MgrName) & "</MgrName>"
                        strXML &= "<CommRatex>" & XMLEncode(.CommRatex.ToString) & "</CommRatex>"
                        strXML &= "<BKCommRate>" & XMLEncode(.BKCommRate.ToString) & "</BKCommRate>"
                        strXML &= "<MGRSplit>" & XMLEncode(.MGRSplit) & "</MGRSplit>"
                        strXML &= "<IODiv>" & XMLEncode(.IODiv) & "</IODiv>"
                        strXML &= "<LogDisp>" & XMLEncode(.LogDisp) & "</LogDisp>"
                        strXML &= "<LogDispName>" & XMLEncode(.LogDispName) & "</LogDispName>"
                        strXML &= "<LogonOffice>" & XMLEncode(.LogonOffice) & "</LogonOffice>"
                        strXML &= "<JRCOfficeNo>" & XMLEncode(.JRCOfficeNo) & "</JRCOfficeNo>"
                        strXML &= "<AllowCDed>" & XMLEncode(.AllowCDed) & "</AllowCDed>"
                        strXML &= "<DvrDAcct1>" & XMLEncode(.DvrDAcct1) & "</DvrDAcct1>"
                        strXML &= "<DvrDAcct2>" & XMLEncode(.DvrDAcct2) & "</DvrDAcct2>"
                        strXML &= "<OOLoadNo>" & XMLEncode(.OOLoadNo.ToString) & "</OOLoadNo>"
                        strXML &= "<BKLoadNo>" & XMLEncode(.BKLoadNo.ToString) & "</BKLoadNo>"
                        strXML &= "<AVLoadNo>" & XMLEncode(.AVLoadNo.ToString) & "</AVLoadNo>"
                        strXML &= "<JRCActive>" & XMLEncode(.JRCActive) & "</JRCActive>"
                        strXML &= "<CopyAddress>" & XMLEncode(.CopyAddress.ToString) & "</CopyAddress>"
                        strXML &= "<ShowOnWeb>" & XMLEncode(.ShowOnWeb.ToString) & "</ShowOnWeb>"
                        strXML &= "<CorpOff>" & XMLEncode(.CorpOff.ToString) & "</CorpOff>"

                        strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
                        strXML += "</InterOffice>"
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

            strXML += "</InterOffices>"

            Return strXML

        End Function

        Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
            Dim xmlInterOffices As System.Xml.XmlNode = GetContent(Content, "InterOffices")

            'Import each InterOffice Details
            Dim xmlInterOffice As System.Xml.XmlNode
            For Each xmlInterOffice In xmlInterOffices.SelectNodes("InterOffice")
                Dim objInterOffice As New InterOfficeInfo
                With objInterOffice
                    .ModuleId = ModuleID

                    Try
                        .JRCIOfficeCode = xmlInterOffice.Item("JRCIOfficeCode").InnerText
                    Catch
                    End Try
                    Try
                        .IOfficeCode = xmlInterOffice.Item("IOfficeCode").InnerText
                    Catch
                    End Try
                    Try
                        .IOName = xmlInterOffice.Item("IOName").InnerText
                    Catch
                    End Try
                    Try
                        .AbvrName = xmlInterOffice.Item("AbvrName").InnerText
                    Catch
                    End Try
                    Try
                        .AddressLine1 = xmlInterOffice.Item("AddressLine1").InnerText
                    Catch
                    End Try
                    Try
                        .AddressLine2 = xmlInterOffice.Item("AddressLine2").InnerText
                    Catch
                    End Try
                    Try
                        .City = xmlInterOffice.Item("City").InnerText
                    Catch
                    End Try
                    Try
                        .State = xmlInterOffice.Item("State").InnerText
                    Catch
                    End Try
                    Try
                        .ZipCode = xmlInterOffice.Item("ZipCode").InnerText
                    Catch
                    End Try
                    Try
                        .CountryCode = xmlInterOffice.Item("CountryCode").InnerText
                    Catch
                    End Try
                    Try
                        .PhoneNo = xmlInterOffice.Item("PhoneNo").InnerText
                    Catch
                    End Try
                    Try
                        .Ext = xmlInterOffice.Item("Ext").InnerText
                    Catch
                    End Try
                    Try
                        .EmailAddress = xmlInterOffice.Item("EmailAddress").InnerText
                    Catch
                    End Try

                    Try
                        .HasProbDrivers = Boolean.Parse(xmlInterOffice.Item("HasProbDrivers").InnerText)
                    Catch
                    End Try

                    Try
                        .CommRate = xmlInterOffice.Item("CommRate").InnerText
                    Catch
                    End Try
                    Try
                        .AdminExempt = xmlInterOffice.Item("AdminExempt").InnerText
                    Catch
                    End Try
                    Try
                        .Status = xmlInterOffice.Item("Status").InnerText
                    Catch
                    End Try
                    Try
                        .LoadType = xmlInterOffice.Item("LoadType").InnerText
                    Catch
                    End Try
                    Try
                        .Division = xmlInterOffice.Item("Division").InnerText
                    Catch
                    End Try
                    Try
                        .FaxNo = xmlInterOffice.Item("FaxNo").InnerText
                    Catch
                    End Try
                    Try
                        .OfficeOR = xmlInterOffice.Item("OfficeOR").InnerText
                    Catch
                    End Try
                    Try
                        .OfficeORAcct = xmlInterOffice.Item("OfficeORAcct").InnerText
                    Catch
                    End Try
                    Try
                        .OfficeORPct = Double.Parse(xmlInterOffice.Item("OfficeORPct").InnerText)
                    Catch
                    End Try
                    Try
                        .OfficeCodeNo = xmlInterOffice.Item("OfficeCodeNo").InnerText
                    Catch
                    End Try
                    Try
                        .LogOnPW = xmlInterOffice.Item("LogOnPW").InnerText
                    Catch
                    End Try
                    Try
                        .OfficName = xmlInterOffice.Item("OfficName").InnerText
                    Catch
                    End Try
                    Try
                        .OfficeAddr = xmlInterOffice.Item("OfficeAddr").InnerText
                    Catch
                    End Try
                    Try
                        .OfficeAbrv = xmlInterOffice.Item("OfficeAbrv").InnerText
                    Catch
                    End Try
                    Try
                        .TempFile1 = xmlInterOffice.Item("TempFile1").InnerText
                    Catch
                    End Try
                    Try
                        .OONo = xmlInterOffice.Item("OONo").InnerText
                    Catch
                    End Try
                    Try
                        .BKNo = xmlInterOffice.Item("BKNo").InnerText
                    Catch
                    End Try
                    Try
                        .AVNo = xmlInterOffice.Item("AVNo").InnerText
                    Catch
                    End Try
                    Try
                        .UseDispatch = xmlInterOffice.Item("UseDispatch").InnerText
                    Catch
                    End Try
                    Try
                        .OfficePct = Double.Parse(xmlInterOffice.Item("OfficePct").InnerText)
                    Catch
                    End Try
                    Try
                        .LoadAcct = xmlInterOffice.Item("LoadAcct").InnerText
                    Catch
                    End Try
                    Try
                        .DiscAcct = xmlInterOffice.Item("DiscAcct").InnerText
                    Catch
                    End Try
                    Try
                        .DetenAcct = xmlInterOffice.Item("DetenAcct").InnerText
                    Catch
                    End Try
                    Try
                        .TollsAcct = xmlInterOffice.Item("TollsAcct").InnerText
                    Catch
                    End Try
                    Try
                        .FuelAcct = xmlInterOffice.Item("FuelAcct").InnerText
                    Catch
                    End Try
                    Try
                        .DropAcct = xmlInterOffice.Item("DropAcct").InnerText
                    Catch
                    End Try
                    Try
                        .ReconAcct = xmlInterOffice.Item("ReconAcct").InnerText
                    Catch
                    End Try
                    Try
                        .TarpAcct = xmlInterOffice.Item("TarpAcct").InnerText
                    Catch
                    End Try
                    Try
                        .LumperAcct = xmlInterOffice.Item("LumperAcct").InnerText
                    Catch
                    End Try
                    Try
                        .UnloadAcct = xmlInterOffice.Item("UnloadAcct").InnerText
                    Catch
                    End Try
                    Try
                        .AdminMiscAcct = xmlInterOffice.Item("AdminMiscAcct").InnerText
                    Catch
                    End Try
                    Try
                        .BKOfficePct = Double.Parse(xmlInterOffice.Item("BKOfficePct").InnerText)
                    Catch
                    End Try
                    Try
                        .LastXferDate = Date.Parse(xmlInterOffice.Item("LastXferDate").InnerText)
                    Catch
                    End Try
                    Try
                        .LastXmission = xmlInterOffice.Item("LastXmission").InnerText
                    Catch
                    End Try
                    Try
                        .NoOffChar = Integer.Parse(xmlInterOffice.Item("NoOffChar").InnerText)
                    Catch
                    End Try
                    Try
                        .AllowORide = xmlInterOffice.Item("AllowORide").InnerText
                    Catch
                    End Try
                    Try
                        .JRCAdminP = Double.Parse(xmlInterOffice.Item("JRCAdminP").InnerText)
                    Catch
                    End Try
                    Try
                        .Reminder = xmlInterOffice.Item("Reminder").InnerText
                    Catch
                    End Try
                    Try
                        .DefDispNo = xmlInterOffice.Item("DefDispNo").InnerText
                    Catch
                    End Try
                    Try
                        .DefDispName = xmlInterOffice.Item("DefDispName").InnerText
                    Catch
                    End Try
                    Try
                        .LoadAcctB = xmlInterOffice.Item("LoadAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .DiscAcctB = xmlInterOffice.Item("DiscAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .DetenAcctB = xmlInterOffice.Item("DetenAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .TollsAcctB = xmlInterOffice.Item("TollsAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .FuelAcctB = xmlInterOffice.Item("FuelAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .DropAcctB = xmlInterOffice.Item("DropAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .ReconAcctB = xmlInterOffice.Item("ReconAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .TarpAcctB = xmlInterOffice.Item("TarpAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .LumperAcctB = xmlInterOffice.Item("LumperAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .UnloadAcctB = xmlInterOffice.Item("UnloadAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .AdminMiscAcctB = xmlInterOffice.Item("AdminMiscAcctB").InnerText
                    Catch
                    End Try
                    Try
                        .ConfName = xmlInterOffice.Item("ConfName").InnerText
                    Catch
                    End Try
                    Try
                        .ConfAddr = xmlInterOffice.Item("ConfAddr").InnerText
                    Catch
                    End Try
                    Try
                        .ConfSTZ = xmlInterOffice.Item("ConfSTZ").InnerText
                    Catch
                    End Try
                    Try
                        .ConfPNo = xmlInterOffice.Item("ConfPNo").InnerText
                    Catch
                    End Try
                    Try
                        .BWordsA = xmlInterOffice.Item("BWordsA").InnerText
                    Catch
                    End Try
                    Try
                        .BWordsB = xmlInterOffice.Item("BWordsB").InnerText
                    Catch
                    End Try
                    Try
                        .BWordsC = xmlInterOffice.Item("BWordsC").InnerText
                    Catch
                    End Try
                    Try
                        .PASplit = xmlInterOffice.Item("PASplit").InnerText
                    Catch
                    End Try
                    Try
                        .CommAdj = xmlInterOffice.Item("CommAdj").InnerText
                    Catch
                    End Try
                    Try
                        .MultiSing = xmlInterOffice.Item("MultiSing").InnerText
                    Catch
                    End Try
                    Try
                        .BrokerOnly = xmlInterOffice.Item("BrokerOnly").InnerText
                    Catch
                    End Try
                    Try
                        .AutoLoadSeq = xmlInterOffice.Item("AutoLoadSeq").InnerText
                    Catch
                    End Try
                    Try
                        .WhatDivision = xmlInterOffice.Item("WhatDivision").InnerText
                    Catch
                    End Try
                    Try
                        .IntraOComm = xmlInterOffice.Item("IntraOComm").InnerText
                    Catch
                    End Try
                    Try
                        .InitQForCust = xmlInterOffice.Item("InitQForCust").InnerText
                    Catch
                    End Try
                    Try
                        .AlumaPct = Double.Parse(xmlInterOffice.Item("AlumaPct").InnerText)
                    Catch
                    End Try
                    Try
                        .Lastcorpbu = Date.Parse(xmlInterOffice.Item("Lastcorpbu").InnerText)
                    Catch
                    End Try
                    Try
                        .XMissionSeq = xmlInterOffice.Item("XMissionSeq").InnerText
                    Catch
                    End Try
                    Try
                        .CNOfficName = xmlInterOffice.Item("CNOfficName").InnerText
                    Catch
                    End Try
                    Try
                        .OffOrgin = xmlInterOffice.Item("OffOrgin").InnerText
                    Catch
                    End Try
                    Try
                        .DoABU = xmlInterOffice.Item("DoABU").InnerText
                    Catch
                    End Try
                    Try
                        .TSL = xmlInterOffice.Item("TSL").InnerText
                    Catch
                    End Try
                    Try
                        .TPBCalc = xmlInterOffice.Item("TPBCalc").InnerText
                    Catch
                    End Try
                    Try
                        .LastCustUpd = Date.Parse(xmlInterOffice.Item("LastCustUpd").InnerText)
                    Catch
                    End Try
                    Try
                        .LastUpdTime = Date.Parse(xmlInterOffice.Item("LastUpdTime").InnerText)
                    Catch
                    End Try
                    Try
                        .APCodeFM = xmlInterOffice.Item("APCodeFM").InnerText
                    Catch
                    End Try
                    Try
                        .AbvrNameFM = xmlInterOffice.Item("AbvrNameFM").InnerText
                    Catch
                    End Try
                    Try
                        .CommRateFM = Double.Parse(xmlInterOffice.Item("CommRateFM").InnerText)
                    Catch
                    End Try
                    Try
                        .BKCommRateFM = Double.Parse(xmlInterOffice.Item("BKCommRateFM").InnerText)
                    Catch
                    End Try
                    Try
                        .SubOffComm = xmlInterOffice.Item("SubOffComm").InnerText
                    Catch
                    End Try
                    Try
                        .UserOn = Integer.Parse(xmlInterOffice.Item("UserOn").InnerText)
                    Catch
                    End Try
                    Try
                        .MgrCode = xmlInterOffice.Item("MgrCode").InnerText
                    Catch
                    End Try
                    Try
                        .MgrName = xmlInterOffice.Item("MgrName").InnerText
                    Catch
                    End Try
                    Try
                        .CommRatex = Double.Parse(xmlInterOffice.Item("CommRatex").InnerText)
                    Catch
                    End Try
                    Try
                        .BKCommRate = Double.Parse(xmlInterOffice.Item("BKCommRate").InnerText)
                    Catch
                    End Try
                    Try
                        .MGRSplit = xmlInterOffice.Item("MGRSplit").InnerText
                    Catch
                    End Try
                    Try
                        .IODiv = xmlInterOffice.Item("IODiv").InnerText
                    Catch
                    End Try
                    Try
                        .LogDisp = xmlInterOffice.Item("LogDisp").InnerText
                    Catch
                    End Try
                    Try
                        .LogDispName = xmlInterOffice.Item("LogDispName").InnerText
                    Catch
                    End Try
                    Try
                        .LogonOffice = xmlInterOffice.Item("LogonOffice").InnerText
                    Catch
                    End Try
                    Try
                        .JRCOfficeNo = xmlInterOffice.Item("JRCOfficeNo").InnerText
                    Catch
                    End Try
                    Try
                        .AllowCDed = xmlInterOffice.Item("AllowCDed").InnerText
                    Catch
                    End Try
                    Try
                        .DvrDAcct1 = xmlInterOffice.Item("DvrDAcct1").InnerText
                    Catch
                    End Try
                    Try
                        .DvrDAcct2 = xmlInterOffice.Item("DvrDAcct2").InnerText
                    Catch
                    End Try
                    Try
                        .JRCActive = xmlInterOffice.Item("JRCActive").InnerText
                    Catch
                    End Try

                    Try
                        .CopyAddress = Boolean.Parse(xmlInterOffice.Item("CopyAddress").InnerText)
                    Catch
                    End Try

                    Try
                        .ShowOnWeb = Boolean.Parse(xmlInterOffice.Item("ShowOnWeb").InnerText)
                    Catch
                    End Try

                    Try
                        .CorpOff = Boolean.Parse(xmlInterOffice.Item("CorpOff").InnerText)
                    Catch
                    End Try

                    Try
                        .ViewOrder = Integer.Parse(xmlInterOffice.Item("ViewOrder").InnerText)
                    Catch
                    End Try
                    .CreatedByUser = UserId.ToString
                End With

                AddInterOffice(objInterOffice)
            Next

            'Import the Module Settings
            Dim objModules As New Entities.Modules.ModuleController
            Dim objOI As New OptionsInfo
            With objOI
                '.ModuleID = ModuleID

                'Control Options
                Try
                    .GetItems = Integer.Parse(xmlInterOffices.SelectSingleNode("GetItems").InnerText)
                Catch
                End Try
                .ViewControl = xmlInterOffices.SelectSingleNode("ViewControl").InnerText

                'Option1 Options
                Try
                    .PagerSize = Integer.Parse(xmlInterOffices.SelectSingleNode("PagerSize").InnerText)
                Catch
                End Try


                .Update(ModuleID)
            End With

        End Sub

#End Region

    End Class 'InterOfficesController


End Namespace
