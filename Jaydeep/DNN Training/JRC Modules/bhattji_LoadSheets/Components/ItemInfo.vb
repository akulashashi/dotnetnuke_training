Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.LoadSheets.Business

    Public Class LoadSheetInfo
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "

        Private _ItemId As Integer
        Private _ModuleId As Integer

        Private _loadID As String
        Private _officeVendorNO As String
        Private _jRCIOfficeCode As String
        Private _JRCIOfficeName As String
        Private _jRCActive As String
        Private _loadDate As DateTime
        Private _deliveryDate As DateTime
        Private _completedLoad As Boolean
        Private _completedDate As DateTime
        Private _officeCode As String
        Private _customerNumber As String
        Private _customerStatus As String
        Private _customerName As String
        Private _cStatus As String
        Private _safetyAuth As String
        Private _custPO As String
        Private _trailerNumber As String
        Private _TrailerDue As Date

        Private _Container1 As String
        Private _Container1Due As Date
        Private _Container2 As String
        Private _Container2Due As Date

        Private _driverCode As String
        Private _driverName As String
        Private _accountNo As String
        Private _brokerCode As String
        Private _brokerName As String
        'Private _BStatus As String
        Private _jRCIOCode As String
        Private _iOCode As String
        Private _iOName As String
        Private _overrideComm As Double
        Private _driverPct As Double
        Private _fOB As String
        Private _loadNotes As String
        Private _comCheckSeq As String
        Private _comCheckAmt As Decimal
        Private _codCheckSeq As String
        Private _codCheckAmt As Decimal
        Private _tarpMessage As String
        Private _dispatchCode As String
        Private _dispName As String
        Private _loadStatus As String
        Private _dispOverride As Double
        Private _repNo As String
        Private _repName As String
        Private _lastUpdate As DateTime
        Private _xmissionSeq As Double
        Private _loadType As String
        Private _driverComm As Double
        Private _brokerComm As Double
        Private _loadWeight As String
        Private _loadPieces As String
        Private _loadMileage As Double
        Private _adminExempt As String
        Private _tarpLoad As String
        Private _proNox As String
        Private _XMissionSave As Boolean
        Private _xMissionFile As String
        Private _xMissionDate As DateTime
        Private _entryDate As DateTime
        Private _repDlrM As Double
        Private _repPctM As Double
        Private _repOverride As String
        Private _repDlrStd As Double
        Private _repPctStd As Double
        Private _corpTo As String
        Private _trailerType As String
        Private _brokerType As String
        Private _officePaid As String
        Private _pDCkNo As String
        Private _pDDate As DateTime
        Private _pDAmt As Double
        Private _proJob As String
        Private _invCommentA As String
        Private _invCommentB As String
        Private _invCommentC As String
        Private _invCommentD As String
        Private _bkrInvNo As String
        Private _reasonFor As String
        Private _bkrInvDate As DateTime
        Private _iOAvail As String
        Private _isPrinted As String
        Private _acctNull As String
        Private _bkrFunds As String
        Private _offFunds As String
        Private _offOrgin As String
        Private _cNOfficeVendorNO As String
        Private _pUSEQ As Decimal
        Private _ShowPUInfo As Boolean
        Private _pUCityST As String
        Private _dPCityST As String
        Private _dPSEQ As Decimal
        Private _isIODiv As String
        Private _oLPUDate As DateTime
        Private _oLNoStops As String
        Private _carrierName As String
        Private _bkrIOName As String
        Private _bkrDriverNo As String
        Private _bKDriver As String
        Private _commPaid As Boolean
        Private _lDNotesA As String
        Private _lDNotesB As String
        Private _lDNotesC As String
        Private _lDNotesD As String
        Private _loadMo As Double
        Private _loadYR As Double
        Private _calc85 As String
        Private _dvrDedPct As Double
        Private _dvrDedResn As String
        Private _BBaseLoad As Decimal
        Private _bCustBill As Decimal
        Private _dRTotDue As Double
        Private _GPPct As Decimal
        Private _ViewOrder As Integer
        Private _UpdatedByUserId As Integer
        Private _UpdatedByUser As String
        Private _UpdatedDate As Date
        Private _CreatedByUserId As Integer
        Private _CreatedByUser As String
        Private _CreatedDate As Date
        Private _IORecovery As Double
        Private _CanRecover As String
        Private _CreationSource As Integer

#End Region

#Region " Properties "

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

        Public Property LoadID() As String
            Get
                Return _loadID
            End Get
            Set(ByVal Value As String)
                _loadID = Value
            End Set
        End Property

        Public Property OfficeVendorNO() As String
            Get
                Return _officeVendorNO
            End Get
            Set(ByVal Value As String)
                _officeVendorNO = Value
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

        Public Property JRCIOfficeName() As String
            Get
                Return _JRCIOfficeName
            End Get
            Set(ByVal Value As String)
                _JRCIOfficeName = Value
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

        Public Property LoadDate() As DateTime
            Get
                Return _loadDate
            End Get
            Set(ByVal Value As DateTime)
                _loadDate = Value
            End Set
        End Property

        Public Property DeliveryDate() As DateTime
            Get
                Return _deliveryDate
            End Get
            Set(ByVal Value As DateTime)
                _deliveryDate = Value
            End Set
        End Property

        Public Property CompletedLoad() As Boolean
            Get
                Return _completedLoad
            End Get
            Set(ByVal Value As Boolean)
                _completedLoad = Value
            End Set
        End Property

        Public Property CompletedDate() As DateTime
            Get
                Return _completedDate
            End Get
            Set(ByVal Value As DateTime)
                _completedDate = Value
            End Set
        End Property

        Public Property OfficeCode() As String
            Get
                Return _officeCode
            End Get
            Set(ByVal Value As String)
                _officeCode = Value
            End Set
        End Property

        Public Property CustomerNumber() As String
            Get
                Return _customerNumber
            End Get
            Set(ByVal Value As String)
                _customerNumber = Value
            End Set
        End Property

        Public Property CustomerName() As String
            Get
                Return _customerName
            End Get
            Set(ByVal Value As String)
                _customerName = Value
            End Set
        End Property

        Public Property CustomerStatus() As String
            Get
                Return _customerStatus.ToUpper
            End Get
            Set(ByVal Value As String)
                _customerStatus = Value
            End Set
        End Property

        Public Property CStatus() As String
            Get
                Return _cStatus.ToUpper
            End Get
            Set(ByVal Value As String)
                _cStatus = Value
            End Set
        End Property

        Public Property SafetyAuth() As String
            Get
                Return _safetyAuth.ToUpper
            End Get
            Set(ByVal Value As String)
                _safetyAuth = Value
            End Set
        End Property

        Public Property CustPO() As String
            Get
                Return _custPO
            End Get
            Set(ByVal Value As String)
                _custPO = Value
            End Set
        End Property

        Public Property TrailerNumber() As String
            Get
                Return _trailerNumber
            End Get
            Set(ByVal Value As String)
                _trailerNumber = Value
            End Set
        End Property

        Public Property TrailerDue() As Date
            Get
                Return _TrailerDue
            End Get
            Set(ByVal Value As Date)
                _TrailerDue = Value
            End Set
        End Property

        Public Property Container1() As String
            Get
                Return _Container1
            End Get
            Set(ByVal Value As String)
                _Container1 = Value
            End Set
        End Property

        Public Property Container1Due() As Date
            Get
                Return _Container1Due
            End Get
            Set(ByVal Value As Date)
                _Container1Due = Value
            End Set
        End Property

        Public Property Container2() As String
            Get
                Return _Container2
            End Get
            Set(ByVal Value As String)
                _Container2 = Value
            End Set
        End Property

        Public Property Container2Due() As Date
            Get
                Return _Container2Due
            End Get
            Set(ByVal Value As Date)
                _Container2Due = Value
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
        Public Property AccountNo() As String
            Get
                Return _accountNo
            End Get
            Set(ByVal Value As String)
                _accountNo = Value
            End Set
        End Property

        Public Property BrokerCode() As String
            Get
                Return _brokerCode
            End Get
            Set(ByVal Value As String)
                _brokerCode = Value
            End Set
        End Property

        Public Property BrokerName() As String
            Get
                Return _brokerName
            End Get
            Set(ByVal Value As String)
                _brokerName = Value
            End Set
        End Property
        'Public Property BStatus() As String
        '    Get
        '        Return _BStatus
        '    End Get
        '    Set(ByVal Value As String)
        '        _BStatus = Value
        '    End Set
        'End Property

        Public Property JRCIOCode() As String
            Get
                Return _jRCIOCode
            End Get
            Set(ByVal Value As String)
                _jRCIOCode = Value
            End Set
        End Property

        Public Property IOCode() As String
            Get
                Return _iOCode
            End Get
            Set(ByVal Value As String)
                _iOCode = Value
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

        Public Property OverrideComm() As Double
            Get
                Return _overrideComm
            End Get
            Set(ByVal Value As Double)
                _overrideComm = Value
            End Set
        End Property

        Public Property DriverPct() As Double
            Get
                Return _driverPct
            End Get
            Set(ByVal Value As Double)
                _driverPct = Value
            End Set
        End Property

        Public Property FOB() As String
            Get
                Return _fOB
            End Get
            Set(ByVal Value As String)
                _fOB = Value
            End Set
        End Property

        Public Property LoadNotes() As String
            Get
                Return _loadNotes
            End Get
            Set(ByVal Value As String)
                _loadNotes = Value
            End Set
        End Property

        Public Property ComCheckSeq() As String
            Get
                Return _comCheckSeq
            End Get
            Set(ByVal Value As String)
                _comCheckSeq = Value
            End Set
        End Property

        Public Property ComCheckAmt() As Decimal
            Get
                Return _comCheckAmt
            End Get
            Set(ByVal Value As Decimal)
                _comCheckAmt = Value
            End Set
        End Property

        Public Property CodCheckSeq() As String
            Get
                Return _codCheckSeq
            End Get
            Set(ByVal Value As String)
                _codCheckSeq = Value
            End Set
        End Property

        Public Property CodCheckAmt() As Decimal
            Get
                Return _codCheckAmt
            End Get
            Set(ByVal Value As Decimal)
                _codCheckAmt = Value
            End Set
        End Property

        Public Property TarpMessage() As String
            Get
                Return _tarpMessage
            End Get
            Set(ByVal Value As String)
                _tarpMessage = Value
            End Set
        End Property

        Public Property DispatchCode() As String
            Get
                Return _dispatchCode
            End Get
            Set(ByVal Value As String)
                _dispatchCode = Value
            End Set
        End Property

        Public Property DispName() As String
            Get
                Return _dispName
            End Get
            Set(ByVal Value As String)
                _dispName = Value
            End Set
        End Property

        Public Property LoadStatus() As String
            Get
                Return _loadStatus
            End Get
            Set(ByVal Value As String)
                _loadStatus = Value
            End Set
        End Property

        Public Property DispOverride() As Double
            Get
                Return _dispOverride
            End Get
            Set(ByVal Value As Double)
                _dispOverride = Value
            End Set
        End Property

        Public Property RepNo() As String
            Get
                Return _repNo
            End Get
            Set(ByVal Value As String)
                _repNo = Value
            End Set
        End Property

        Public Property RepName() As String
            Get
                Return _repName
            End Get
            Set(ByVal Value As String)
                _repName = Value
            End Set
        End Property

        Public Property LastUpdate() As DateTime
            Get
                Return _lastUpdate
            End Get
            Set(ByVal Value As DateTime)
                _lastUpdate = Value
            End Set
        End Property

        Public Property XmissionSeq() As Double
            Get
                Return _xmissionSeq
            End Get
            Set(ByVal Value As Double)
                _xmissionSeq = Value
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

        Public Property DriverComm() As Double
            Get
                Return _driverComm
            End Get
            Set(ByVal Value As Double)
                _driverComm = Value
            End Set
        End Property

        Public Property BrokerComm() As Double
            Get
                Return _brokerComm
            End Get
            Set(ByVal Value As Double)
                _brokerComm = Value
            End Set
        End Property

        Public Property LoadWeight() As String
            Get
                Return _loadWeight
            End Get
            Set(ByVal Value As String)
                _loadWeight = Value
            End Set
        End Property

        Public Property LoadPieces() As String
            Get
                Return _loadPieces
            End Get
            Set(ByVal Value As String)
                _loadPieces = Value
            End Set
        End Property

        Public Property LoadMileage() As Double
            Get
                Return _loadMileage
            End Get
            Set(ByVal Value As Double)
                _loadMileage = Value
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

        Public Property TarpLoad() As String
            Get
                Return _tarpLoad
            End Get
            Set(ByVal Value As String)
                _tarpLoad = Value
            End Set
        End Property

        Public Property ProNox() As String
            Get
                Return _proNox
            End Get
            Set(ByVal Value As String)
                _proNox = Value
            End Set
        End Property

        Public Property XMissionSave() As Boolean
            Get
                Return _XMissionSave
            End Get
            Set(ByVal value As Boolean)
                _XMissionSave = value
            End Set
        End Property

        Public Property XMissionFile() As String
            Get
                Return _xMissionFile
            End Get
            Set(ByVal Value As String)
                _xMissionFile = Value
            End Set
        End Property

        Public Property XMissionDate() As DateTime
            Get
                Return _xMissionDate
            End Get
            Set(ByVal Value As DateTime)
                _xMissionDate = Value
            End Set
        End Property

        Public Property EntryDate() As DateTime
            Get
                Return _entryDate
            End Get
            Set(ByVal Value As DateTime)
                _entryDate = Value
            End Set
        End Property

        Public Property RepDlrM() As Double
            Get
                Return _repDlrM
            End Get
            Set(ByVal Value As Double)
                _repDlrM = Value
            End Set
        End Property

        Public Property RepPctM() As Double
            Get
                Return _repPctM
            End Get
            Set(ByVal Value As Double)
                _repPctM = Value
            End Set
        End Property

        Public Property RepOverride() As String
            Get
                Return _repOverride
            End Get
            Set(ByVal Value As String)
                _repOverride = Value
            End Set
        End Property

        Public Property RepDlrStd() As Double
            Get
                Return _repDlrStd
            End Get
            Set(ByVal Value As Double)
                _repDlrStd = Value
            End Set
        End Property

        Public Property RepPctStd() As Double
            Get
                Return _repPctStd
            End Get
            Set(ByVal Value As Double)
                _repPctStd = Value
            End Set
        End Property

        Public Property CorpTo() As String
            Get
                Return _corpTo
            End Get
            Set(ByVal Value As String)
                _corpTo = Value
            End Set
        End Property

        Public Property TrailerType() As String
            Get
                Return _trailerType
            End Get
            Set(ByVal Value As String)
                _trailerType = Value
            End Set
        End Property

        Public Property BrokerType() As String
            Get
                Return _brokerType
            End Get
            Set(ByVal Value As String)
                _brokerType = Value
            End Set
        End Property

        Public Property OfficePaid() As String
            Get
                Return _officePaid
            End Get
            Set(ByVal Value As String)
                _officePaid = Value
            End Set
        End Property

        Public Property PDCkNo() As String
            Get
                Return _pDCkNo
            End Get
            Set(ByVal Value As String)
                _pDCkNo = Value
            End Set
        End Property

        Public Property PDDate() As DateTime
            Get
                Return _pDDate
            End Get
            Set(ByVal Value As DateTime)
                _pDDate = Value
            End Set
        End Property

        Public Property PDAmt() As Double
            Get
                Return _pDAmt
            End Get
            Set(ByVal Value As Double)
                _pDAmt = Value
            End Set
        End Property

        Public Property ProJob() As String
            Get
                Return _proJob
            End Get
            Set(ByVal Value As String)
                _proJob = Value
            End Set
        End Property

        Public Property InvCommentA() As String
            Get
                Return _invCommentA
            End Get
            Set(ByVal Value As String)
                _invCommentA = Value
            End Set
        End Property

        Public Property InvCommentB() As String
            Get
                Return _invCommentB
            End Get
            Set(ByVal Value As String)
                _invCommentB = Value
            End Set
        End Property

        Public Property InvCommentC() As String
            Get
                Return _invCommentC
            End Get
            Set(ByVal Value As String)
                _invCommentC = Value
            End Set
        End Property

        Public Property InvCommentD() As String
            Get
                Return _invCommentD
            End Get
            Set(ByVal Value As String)
                _invCommentD = Value
            End Set
        End Property

        Public Property BkrInvNo() As String
            Get
                Return _bkrInvNo
            End Get
            Set(ByVal Value As String)
                _bkrInvNo = Value
            End Set
        End Property

        Public Property ReasonFor() As String
            Get
                Return _reasonFor
            End Get
            Set(ByVal Value As String)
                _reasonFor = Value
            End Set
        End Property

        Public Property BkrInvDate() As DateTime
            Get
                Return _bkrInvDate
            End Get
            Set(ByVal Value As DateTime)
                _bkrInvDate = Value
            End Set
        End Property

        Public Property IOAvail() As String
            Get
                Return _iOAvail
            End Get
            Set(ByVal Value As String)
                _iOAvail = Value
            End Set
        End Property

        Public Property IsPrinted() As String
            Get
                Return _isPrinted
            End Get
            Set(ByVal Value As String)
                _isPrinted = Value
            End Set
        End Property

        Public Property AcctNull() As String
            Get
                Return _acctNull
            End Get
            Set(ByVal Value As String)
                _acctNull = Value
            End Set
        End Property

        Public Property BkrFunds() As String
            Get
                Return _bkrFunds
            End Get
            Set(ByVal Value As String)
                _bkrFunds = Value
            End Set
        End Property

        Public Property OffFunds() As String
            Get
                Return _offFunds
            End Get
            Set(ByVal Value As String)
                _offFunds = Value
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

        Public Property CNOfficeVendorNO() As String
            Get
                Return _cNOfficeVendorNO
            End Get
            Set(ByVal Value As String)
                _cNOfficeVendorNO = Value
            End Set
        End Property

        Public Property PUSEQ() As Decimal
            Get
                Return _pUSEQ
            End Get
            Set(ByVal Value As Decimal)
                _pUSEQ = Value
            End Set
        End Property

        Public Property ShowPUInfo() As Boolean
            Get
                Return _ShowPUInfo
            End Get
            Set(ByVal value As Boolean)
                _ShowPUInfo = value
            End Set
        End Property

        Public Property PUCityST() As String
            Get
                Return _pUCityST
            End Get
            Set(ByVal Value As String)
                _pUCityST = Value
            End Set
        End Property

        Public Property DPCityST() As String
            Get
                Return _dPCityST
            End Get
            Set(ByVal Value As String)
                _dPCityST = Value
            End Set
        End Property

        Public Property DPSEQ() As Decimal
            Get
                Return _dPSEQ
            End Get
            Set(ByVal Value As Decimal)
                _dPSEQ = Value
            End Set
        End Property

        Public Property IsIODiv() As String
            Get
                Return _isIODiv
            End Get
            Set(ByVal Value As String)
                _isIODiv = Value
            End Set
        End Property

        Public Property OLPUDate() As DateTime
            Get
                Return _oLPUDate
            End Get
            Set(ByVal Value As DateTime)
                _oLPUDate = Value
            End Set
        End Property

        Public Property OLNoStops() As String
            Get
                Return _oLNoStops
            End Get
            Set(ByVal Value As String)
                _oLNoStops = Value
            End Set
        End Property

        Public Property CarrierName() As String
            Get
                Return _carrierName
            End Get
            Set(ByVal Value As String)
                _carrierName = Value
            End Set
        End Property

        Public Property BkrIOName() As String
            Get
                Return _bkrIOName
            End Get
            Set(ByVal Value As String)
                _bkrIOName = Value
            End Set
        End Property

        Public Property BkrDriverNo() As String
            Get
                Return _bkrDriverNo
            End Get
            Set(ByVal Value As String)
                _bkrDriverNo = Value
            End Set
        End Property

        Public Property BKDriver() As String
            Get
                Return _bKDriver
            End Get
            Set(ByVal Value As String)
                _bKDriver = Value
            End Set
        End Property

        Public Property CommPaid() As Boolean
            Get
                Return _commPaid
            End Get
            Set(ByVal Value As Boolean)
                _commPaid = Value
            End Set
        End Property

        Public Property LDNotesA() As String
            Get
                Return _lDNotesA
            End Get
            Set(ByVal Value As String)
                _lDNotesA = Value
            End Set
        End Property

        Public Property LDNotesB() As String
            Get
                Return _lDNotesB
            End Get
            Set(ByVal Value As String)
                _lDNotesB = Value
            End Set
        End Property

        Public Property LDNotesC() As String
            Get
                Return _lDNotesC
            End Get
            Set(ByVal Value As String)
                _lDNotesC = Value
            End Set
        End Property

        Public Property LDNotesD() As String
            Get
                Return _lDNotesD
            End Get
            Set(ByVal Value As String)
                _lDNotesD = Value
            End Set
        End Property

        Public Property LoadMo() As Double
            Get
                Return _loadMo
            End Get
            Set(ByVal Value As Double)
                _loadMo = Value
            End Set
        End Property

        Public Property LoadYR() As Double
            Get
                Return _loadYR
            End Get
            Set(ByVal Value As Double)
                _loadYR = Value
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

        Public Property CanRecover() As String
            Get
                Return _CanRecover
            End Get
            Set(ByVal Value As String)
                _CanRecover = Value
            End Set
        End Property

        Public Property CreationSource() As Integer
            Get
                Return _CreationSource
            End Get
            Set(ByVal value As Integer)
                _CreationSource = value
            End Set
        End Property
        Public ReadOnly Property IsIORecoveredLoad() As Boolean
            Get
                Return (_CreationSource = 1)
            End Get
        End Property
        Public ReadOnly Property IsCopiedLoad() As Boolean
            Get
                Return (_CreationSource = 3)
            End Get
        End Property


        Public Property BBaseLoad() As Decimal
            Get
                Return _BBaseLoad
            End Get
            Set(ByVal Value As Decimal)
                _BBaseLoad = Value
            End Set
        End Property

        Public Property BCustBill() As Decimal
            Get
                Return _bCustBill
            End Get
            Set(ByVal Value As Decimal)
                _bCustBill = Value
            End Set
        End Property

        Public Property DRTotDue() As Double
            Get
                Return _dRTotDue
            End Get
            Set(ByVal Value As Double)
                _dRTotDue = Value
            End Set
        End Property

        Public Property GPPct() As Decimal
            Get
                Return _GPPct
            End Get
            Set(ByVal Value As Decimal)
                _GPPct = Value
            End Set
        End Property

        Public Property IORecovery() As Double
            Get
                Return _IORecovery
            End Get
            Set(ByVal Value As Double)
                _IORecovery = Value
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

    End Class

    Public Class LoadSheetsController
        'Implements Entities.Modules.ISearchable
        'Implements Entities.Modules.IPortable
        'Public Shared TotalRecords As Integer
        Public Shared BBaseLoadTotal As Decimal
        Public Shared RepDlrTotal As Decimal
        Public Shared DRTotDueTotal As Decimal
        Public Shared IOCommTotTotal As Decimal
        Public Shared IOComm3Total As Decimal
        Public Shared JRCOffCommTotal As Decimal
        Public Shared JRCTotalTotal As Decimal
        Public Shared TotalLoadXmited As Integer

        Public Shared LoadMileageTotal As Integer
        Public Shared ExTotTotal As Decimal
        Public Shared ComCheckAmtTotal As Decimal
        Public Shared BCustBillTotal As Decimal

#Region " Public Methods "
        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function
        Private Function GetDataTable(ByVal dr As IDataReader) As DataTable
            Dim dt As New DataTable
            dt.Load(dr)
            Return dt
        End Function

        '---------------------------------------------------------------------
        ' TODO Implement BLL methods
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------
        Public Function AddLoadSheet(ByVal objLoadSheet As LoadSheetInfo) As Integer
            With objLoadSheet
                'With .CreationSource Field
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddLoadSheet", .ModuleId, GetNull(.LoadID), GetNull(.OfficeVendorNO), GetNull(.JRCIOfficeCode), GetNull(.LoadDate), GetNull(.DeliveryDate), GetNull(.CompletedLoad), GetNull(.CompletedDate), GetNull(.OfficeCode), GetNull(.CustomerNumber), GetNull(.CustomerName), GetNull(.CustPO), GetNull(.TrailerNumber), GetNull(.TrailerDue), GetNull(.DriverCode), GetNull(.DriverName), GetNull(.BrokerCode), GetNull(.BrokerName), GetNull(.JRCIOCode), GetNull(.IOCode), GetNull(.IOName), GetNull(.OverrideComm), GetNull(.DriverPct), GetNull(.FOB), GetNull(.LoadNotes), GetNull(.ComCheckSeq), GetNull(.ComCheckAmt), GetNull(.CodCheckSeq), GetNull(.CodCheckAmt), GetNull(.TarpMessage), GetNull(.DispatchCode), GetNull(.DispName), GetNull(.LoadStatus), GetNull(.DispOverride), GetNull(.RepNo), GetNull(.RepName), GetNull(.LastUpdate), GetNull(.XmissionSeq), GetNull(.LoadType), GetNull(.DriverComm), GetNull(.BrokerComm), GetNull(.LoadWeight), GetNull(.LoadPieces), GetNull(.LoadMileage), GetNull(.AdminExempt), GetNull(.TarpLoad), GetNull(.ProNox), GetNull(.XMissionSave), GetNull(.XMissionFile), GetNull(.XMissionDate), GetNull(.EntryDate), GetNull(.RepDlrM), GetNull(.RepPctM), GetNull(.RepOverride), GetNull(.RepDlrStd), GetNull(.RepPctStd), GetNull(.CorpTo), GetNull(.TrailerType), GetNull(.BrokerType), GetNull(.OfficePaid), GetNull(.PDCkNo), GetNull(.PDDate), GetNull(.PDAmt), GetNull(.ProJob), GetNull(.InvCommentA), GetNull(.InvCommentB), GetNull(.InvCommentC), GetNull(.InvCommentD), GetNull(.BkrInvNo), GetNull(.ReasonFor), GetNull(.BkrInvDate), GetNull(.IOAvail), GetNull(.IsPrinted), GetNull(.AcctNull), GetNull(.BkrFunds), GetNull(.OffFunds), GetNull(.OffOrgin), GetNull(.CNOfficeVendorNO), GetNull(.PUSEQ), GetNull(.PUCityST), GetNull(.DPCityST), GetNull(.DPSEQ), GetNull(.IsIODiv), GetNull(.OLPUDate), GetNull(.OLNoStops), GetNull(.CarrierName), GetNull(.BkrIOName), GetNull(.BkrDriverNo), GetNull(.BKDriver), GetNull(.CommPaid), GetNull(.LDNotesA), GetNull(.LDNotesB), GetNull(.LDNotesC), GetNull(.LDNotesD), GetNull(.LoadMo), GetNull(.LoadYR), GetNull(.Calc85), GetNull(.DvrDedPct), GetNull(.DvrDedResn), GetNull(.CanRecover), GetNull(.CreationSource), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
                'Without .CreationSource Field
                'Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddLoadSheet", .ModuleId, GetNull(.LoadID), GetNull(.OfficeVendorNO), GetNull(.JRCIOfficeCode), GetNull(.LoadDate), GetNull(.DeliveryDate), GetNull(.CompletedLoad), GetNull(.CompletedDate), GetNull(.OfficeCode), GetNull(.CustomerNumber), GetNull(.CustomerName), GetNull(.CustPO), GetNull(.TrailerNumber), GetNull(.TrailerDue), GetNull(.DriverCode), GetNull(.DriverName), GetNull(.BrokerCode), GetNull(.BrokerName), GetNull(.JRCIOCode), GetNull(.IOCode), GetNull(.IOName), GetNull(.OverrideComm), GetNull(.DriverPct), GetNull(.FOB), GetNull(.LoadNotes), GetNull(.ComCheckSeq), GetNull(.ComCheckAmt), GetNull(.CodCheckSeq), GetNull(.CodCheckAmt), GetNull(.TarpMessage), GetNull(.DispatchCode), GetNull(.DispName), GetNull(.LoadStatus), GetNull(.DispOverride), GetNull(.RepNo), GetNull(.RepName), GetNull(.LastUpdate), GetNull(.XmissionSeq), GetNull(.LoadType), GetNull(.DriverComm), GetNull(.BrokerComm), GetNull(.LoadWeight), GetNull(.LoadPieces), GetNull(.LoadMileage), GetNull(.AdminExempt), GetNull(.TarpLoad), GetNull(.ProNox), GetNull(.XMissionSave), GetNull(.XMissionFile), GetNull(.XMissionDate), GetNull(.EntryDate), GetNull(.RepDlrM), GetNull(.RepPctM), GetNull(.RepOverride), GetNull(.RepDlrStd), GetNull(.RepPctStd), GetNull(.CorpTo), GetNull(.TrailerType), GetNull(.BrokerType), GetNull(.OfficePaid), GetNull(.PDCkNo), GetNull(.PDDate), GetNull(.PDAmt), GetNull(.ProJob), GetNull(.InvCommentA), GetNull(.InvCommentB), GetNull(.InvCommentC), GetNull(.InvCommentD), GetNull(.BkrInvNo), GetNull(.ReasonFor), GetNull(.BkrInvDate), GetNull(.IOAvail), GetNull(.IsPrinted), GetNull(.AcctNull), GetNull(.BkrFunds), GetNull(.OffFunds), GetNull(.OffOrgin), GetNull(.CNOfficeVendorNO), GetNull(.PUSEQ), GetNull(.PUCityST), GetNull(.DPCityST), GetNull(.DPSEQ), GetNull(.IsIODiv), GetNull(.OLPUDate), GetNull(.OLNoStops), GetNull(.CarrierName), GetNull(.BkrIOName), GetNull(.BkrDriverNo), GetNull(.BKDriver), GetNull(.CommPaid), GetNull(.LDNotesA), GetNull(.LDNotesB), GetNull(.LDNotesC), GetNull(.LDNotesD), GetNull(.LoadMo), GetNull(.LoadYR), GetNull(.Calc85), GetNull(.DvrDedPct), GetNull(.DvrDedResn), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        Public Sub VoidLoad(ByVal LoadID As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_VoidLoad", LoadID)
        End Sub

        Public Sub UpdateCodCheckSeq(ByVal LoadID As String, ByVal CodCheckSeq As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateCodCheckSeq", LoadID, CodCheckSeq)
        End Sub

        Public Sub UpdateBkrInvNoCustPO(ByVal LoadID As String, ByVal BkrInvNo As String, ByVal CustPO As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateBkrInvNoCustPO", LoadID, BkrInvNo, CustPO)
        End Sub

        Public Sub UpdateXMissionSave(ByVal LoadID As String, ByVal XMissionSave As Boolean)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateXMissionSave", LoadID, XMissionSave)
        End Sub

        Public Sub UnXmit(ByVal XmissionFile As String)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_UnXmit", XmissionFile)
        End Sub

        Public Sub UpdateLoadSheet(ByVal objLoadSheet As LoadSheetInfo)
            With objLoadSheet
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateLoadSheet", .ItemId, GetNull(.LoadID), GetNull(.OfficeVendorNO), GetNull(.JRCIOfficeCode), GetNull(.LoadDate), GetNull(.DeliveryDate), GetNull(.CompletedLoad), GetNull(.CompletedDate), GetNull(.OfficeCode), GetNull(.CustomerNumber), GetNull(.CustomerName), GetNull(.CustPO), GetNull(.TrailerNumber), GetNull(.TrailerDue), GetNull(.Container1), GetNull(.Container1Due), GetNull(.Container2), GetNull(.Container2Due), GetNull(.DriverCode), GetNull(.DriverName), GetNull(.BrokerCode), GetNull(.BrokerName), GetNull(.JRCIOCode), GetNull(.IOCode), GetNull(.IOName), GetNull(.OverrideComm), GetNull(.DriverPct), GetNull(.FOB), GetNull(.LoadNotes), GetNull(.ComCheckSeq), GetNull(.ComCheckAmt), GetNull(.CodCheckSeq), GetNull(.CodCheckAmt), GetNull(.TarpMessage), GetNull(.DispatchCode), GetNull(.DispName), GetNull(.LoadStatus), GetNull(.DispOverride), GetNull(.RepNo), GetNull(.RepName), GetNull(.LastUpdate), GetNull(.XmissionSeq), GetNull(.LoadType), GetNull(.DriverComm), GetNull(.BrokerComm), GetNull(.LoadWeight), GetNull(.LoadPieces), GetNull(.LoadMileage), GetNull(.AdminExempt), GetNull(.TarpLoad), GetNull(.ProNox), GetNull(.XMissionSave), GetNull(.XMissionFile), GetNull(.XMissionDate), GetNull(.EntryDate), GetNull(.RepDlrM), GetNull(.RepPctM), GetNull(.RepOverride), GetNull(.RepDlrStd), GetNull(.RepPctStd), GetNull(.CorpTo), GetNull(.TrailerType), GetNull(.BrokerType), GetNull(.OfficePaid), GetNull(.PDCkNo), GetNull(.PDDate), GetNull(.PDAmt), GetNull(.ProJob), GetNull(.InvCommentA), GetNull(.InvCommentB), GetNull(.InvCommentC), GetNull(.InvCommentD), GetNull(.BkrInvNo), GetNull(.ReasonFor), GetNull(.BkrInvDate), GetNull(.IOAvail), GetNull(.IsPrinted), GetNull(.AcctNull), GetNull(.BkrFunds), GetNull(.OffFunds), GetNull(.OffOrgin), GetNull(.CNOfficeVendorNO), GetNull(.PUSEQ), GetNull(.ShowPUInfo), GetNull(.PUCityST), GetNull(.DPCityST), GetNull(.DPSEQ), GetNull(.IsIODiv), GetNull(.OLPUDate), GetNull(.OLNoStops), GetNull(.CarrierName), GetNull(.BkrIOName), GetNull(.BkrDriverNo), GetNull(.BKDriver), GetNull(.CommPaid), GetNull(.LDNotesA), GetNull(.LDNotesB), GetNull(.LDNotesC), GetNull(.LDNotesD), GetNull(.LoadMo), GetNull(.LoadYR), GetNull(.Calc85), GetNull(.DvrDedPct), GetNull(.DvrDedResn), GetNull(.CanRecover), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
        End Sub

        Public Sub DeleteLoadSheet(ByVal objLoadSheet As LoadSheetInfo)
            DeleteLoadSheet(objLoadSheet.ItemId)
        End Sub

        Public Sub DeleteLoadSheet(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteLoadSheet", ItemID)
        End Sub

        Public Sub FixLoadSheets(ByVal ModuleID As Integer, ByVal UpdatedByUserId As Integer)
            DotNetNuke.Data.DataProvider.Instance.ExecuteNonQuery("bhattji_FixLoadSheets", ModuleID, UpdatedByUserId)
        End Sub

        Public Sub SortLoadSheets(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortLoadSheets", ModuleID)
        End Sub

        Public Function GetItemId(ByVal LoadId As String) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetItemIdByLoadId", LoadId))
        End Function

        Public Function GetLoadId(ByVal ItemId As Integer) As String
            Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetLoadIdByItemId", ItemId))
        End Function

        Public Function GetLoadId(ByVal JRCIOfficeCode As String, ByVal LoadType As String) As String
            Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetLoadId", JRCIOfficeCode, LoadType))
        End Function

        Public Function GetNewLoadId(ByVal JRCIOfficeCode As String, ByVal LoadType As String) As String
            Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetNewLoadId", JRCIOfficeCode, LoadType))
        End Function


        Public Function GetLoadSheetByLoadId(ByVal LoadID As String) As LoadSheetInfo
            Return GetLoadSheet(GetItemId(LoadID))
        End Function
        Public Function GetLoadSheet(ByVal ItemID As Integer) As LoadSheetInfo
            'Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetLoadSheet", ItemID), GetType(LoadSheetInfo)), LoadSheetInfo)
            Return CBO.FillObject(Of LoadSheetInfo)(DataProvider.Instance().ExecuteReader("bhattji_GetLoadSheet", ItemID))
        End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()

        Public Function GetLoadSheets(ByVal JRCIOfficeCode As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 2) As DataTable
            Dim dt As New DataTable
            dt.Load(GetLoadSheetsCommon(JRCIOfficeCode, SearchText, LoadStatus, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
            Return dt
        End Function

        Public Function GetLoadSheetsCommon(ByVal JRCIOfficeCode As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 2) As IDataReader 'ArrayList '(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As ArrayList
            If SearchText <> "" OrElse (JRCIOfficeCode <> "000000000") Then
                Return GetSearchedLoadSheets(JRCIOfficeCode, SearchText, LoadStatus, SearchOn, StartsWith, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems)
            Else
                Select Case GetItems
                    Case 0
                        If ModuleId > -1 Then
                            Return GetModuleLoadSheets(ModuleId, NoOfItems)
                        Else
                            Return GetAllLoadSheets(NoOfItems)
                        End If
                    Case 1
                        If PortalId > -1 Then
                            Return GetPortalLoadSheets(PortalId, NoOfItems)
                        Else
                            Return GetAllLoadSheets(NoOfItems)
                        End If
                    Case 2
                        Return GetAllLoadSheets(NoOfItems)
                    Case Else '0
                        If PortalId > -1 Then
                            Return GetPortalLoadSheets(PortalId, NoOfItems)
                        ElseIf ModuleId > -1 Then
                            Return GetModuleLoadSheets(ModuleId, NoOfItems)
                        Else
                            Return GetAllLoadSheets(NoOfItems)
                        End If
                End Select
            End If
        End Function

        Public Function GetModuleLoadSheets(ByVal ModuleId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleLoadSheets", ModuleId, NoOfItems)
        End Function

        Public Function GetPortalLoadSheets(ByVal PortalId As Integer, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalLoadSheets", PortalId, NoOfItems)
        End Function

        Public Function GetAllLoadSheets(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllLoadSheets", NoOfItems)
        End Function
        Public Function GetSearchedLoadSheetsDT(ByVal JRCIOfficeCode As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal Datewise As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 2) As DataTable
            Return GetDataTable(GetSearchedLoadSheets(JRCIOfficeCode, SearchText, LoadStatus, SearchOn, StartsWith, Datewise, NoOfItems, FromDate, ToDate, ModuleId, PortalId, GetItems))
        End Function

        Public Function GetSearchedLoadSheets(ByVal JRCIOfficeCode As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal Datewise As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'ArrayList '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If LoadStatus.ToUpper = "COMPLETE" Then
                If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            Else
                If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            End If


            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT TOP " & NoOfItems.ToString & " ")
            ' MySqlString &= "x.* "
            sbSql.Append("x.ItemId, ")
            sbSql.Append("x.LoadDate, ")
            sbSql.Append("x.LoadID, ")
            sbSql.Append("x.LoadStatus, ")
            sbSql.Append("x.JRCIOfficeCode, ")
            sbSql.Append("so.JRCActive, ")
            sbSql.Append("x.CustomerNumber, ")
            sbSql.Append("cn.CustomerName, ")
            sbSql.Append("cn.CStatus AS CustomerStatus, ")
            sbSql.Append("x.DispatchCode, ")
            sbSql.Append("x.DriverCode, ")
            sbSql.Append("oo.DriverName, ")
            sbSql.Append("x.JRCIOCode, ")
            sbSql.Append("io.IOName, ")
            sbSql.Append("x.BrokerCode, ")
            sbSql.Append("bk.BrokerName, ")
            sbSql.Append("bk.BStatus, ")
            sbSql.Append("bk.BrokerNotes, ")
            sbSql.Append("x.CustPO, ")
            sbSql.Append("x.ProJob, ")
            sbSql.Append("x.PUCityST, ")
            sbSql.Append("x.DPCityST, ")
            sbSql.Append("x.LoadType, ")
            sbSql.Append("x.XMissionSave, ")
            sbSql.Append("x.IsPrinted, ")
            sbSql.Append("la.IOOffL1, ")
            sbSql.Append("la.BBaseLoad, ")
            sbSql.Append("la.BCustBill, ")
            sbSql.Append("'IORecovery' = la.IOAdmin1 + la.IOComm1 ")

            sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile As oo ON x.DriverCode=oo.DriverCode ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct AS la ON x.LoadId=la.LoadId ")



            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                Case "OO"
                    strSearchOn = "oo.DriverName "
                Case "IO"
                    strSearchOn = "io.IOName "
                Case "BK"
                    strSearchOn = "bk.BrokerName "
                Case "OL"
                    strSearchOn = "la.IOOffL1 "
                Case "LI"
                    strSearchOn = "x.LoadId "
                Case "PO"
                    strSearchOn = "x.CustPO "
                Case "PJ"
                    strSearchOn = "x.ProJob "
                Case "PC"
                    strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            sbSql.Append("WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') ")

            'If LoadStatus = "" Then
            '    sbSql.Append("AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE') OR (x.LoadStatus = 'VOIDED')) ")
            '    'sbSql.Append("AND (x.LoadStatus <> 'VOIDED') ")
            'Else
            '    sbSql.Append("AND (x.LoadStatus = '" & LoadStatus & "') ")
            'End If
            If LoadStatus <> "" Then
                sbSql.Append("AND (x.LoadStatus = '" & LoadStatus & "') ")
            End If

            Select Case SearchOn.ToUpper
                Case "OO", "IO", "BK"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    sbSql.Append("AND (x.LoadType = '" & SearchOn & "') ") 'This has been introduced for filtering only OO or BK Loads
                    sbSql.Append("AND (" & strSearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    If Datewise Then
                        sbSql.Append("ORDER BY x.LoadDate desc, x.LoadId desc, x.UpdatedDate desc, x.ViewOrder ")
                    Else
                        sbSql.Append("ORDER BY x.LoadId desc, x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder ")
                    End If
                Case "CN", "OL", "LI", "PO", "PJ", "PC"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    sbSql.Append("AND (" & strSearchOn & " LIKE '" & strSearchText & "') ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    If Datewise Then
                        sbSql.Append("ORDER BY x.LoadDate desc, x.LoadId desc, x.UpdatedDate desc, x.ViewOrder ")
                    Else
                        sbSql.Append("ORDER BY x.LoadId desc, x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder ")
                    End If

                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    sbSql.Append("AND ((cn.CustomerName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (oo.DriverName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (io.IOName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (bk.BrokerName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (la.IOOffL1 LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.LoadId LIKE '" & strSearchText & "')) ")
                    sbSql.Append(DateFilter)
                    sbSql.Append(ScopeFilter)

                    If Datewise Then
                        sbSql.Append("ORDER BY x.LoadDate desc, x.LoadType desc, x.LoadId desc, x.UpdatedDate desc, x.ViewOrder ")
                    Else
                        sbSql.Append("ORDER BY x.LoadType desc, x.LoadId desc, x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder ")
                     End If
            End Select

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function

        Public Function GetSearchedLoadSheetsX(ByVal JRCIOfficeCode As String, ByVal SearchText As String, Optional ByVal XmissionFile As String = "", Optional ByVal CodOnly As Boolean = False, Optional ByVal MissingCodOnly As Boolean = False, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'ArrayList 'IDataReader '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT TOP " & NoOfItems.ToString & " ")
            ' sbSql.Append("x.* "
            sbSql.Append("x.ItemId, ")
            sbSql.Append("x.LoadDate, ")
            sbSql.Append("x.LoadID, ")
            sbSql.Append("x.LoadStatus, ")
            sbSql.Append("x.JRCIOfficeCode, ")
            sbSql.Append("so.JRCActive, ")
            sbSql.Append("cn.CustomerName, ")
            sbSql.Append("cn.CStatus AS CustomerStatus, ")
            sbSql.Append("x.DispatchCode, ")
            sbSql.Append("x.DriverCode, ")
            sbSql.Append("oo.DriverName, ")
            sbSql.Append("x.JRCIOCode, ")
            sbSql.Append("io.IOName, ")
            sbSql.Append("x.BrokerCode, ")
            sbSql.Append("bk.BrokerName, ")
            sbSql.Append("x.BkrInvNo, ")
            sbSql.Append("x.CustPO, ")
            sbSql.Append("x.ProJob, ")
            sbSql.Append("x.PUCityST, ")
            sbSql.Append("x.LoadType, ")
            sbSql.Append("x.CodCheckSeq, ")
            sbSql.Append("x.XMissionSave, ")
            sbSql.Append("x.XMissionFile ")

            sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile As oo ON x.DriverCode=oo.DriverCode ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode ")


            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                Case "OO"
                    strSearchOn = "oo.DriverName "
                Case "IO"
                    strSearchOn = "io.IOName "
                Case "BK"
                    strSearchOn = "bk.BrokerName "
                Case "LI"
                    strSearchOn = "x.LoadId "
                Case "PO"
                    strSearchOn = "x.CustPO "
                Case "PJ"
                    strSearchOn = "x.ProJob "
                Case "PC"
                    strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            sbSql.Append("WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') ")
            If XmissionFile = "" Then
                If CodOnly Then
                    sbSql.Append("AND (cn.CustomerStatus = 'C') ")
                    If MissingCodOnly Then
                        sbSql.Append("AND ((x.CodCheckSeq IS NULL) OR (x.CodCheckSeq = '')) ")
                    End If
                Else
                    sbSql.Append("AND (cn.CustomerStatus <> 'C') ")
                End If
                sbSql.Append("AND (x.LoadStatus = 'WIP') AND ((x.LoadType = 'OO') OR (x.LoadType = 'BK')) ")
            Else
                sbSql.Append("AND (x.XmissionFile = '" & XmissionFile & "') AND (x.LoadStatus = 'COMPLETE') ")
            End If
            'sbSql.Append("WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') AND  (x.LoadStatus = 'WIP') AND  ((x.LoadType = 'OO') OR (x.LoadType = 'BK')) ")


            Select Case SearchOn.ToUpper
                Case "OO", "IO", "BK"
                    'sbSql.Append("WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') ")
                    sbSql.Append("AND (x.LoadType = '" & SearchOn & "') ") 'This has been introduced for filtering only OO or BK Loads
                    sbSql.Append("AND (" & strSearchOn & " LIKE '" & strSearchText & "') ")
                    'sbSql.Append(DateFilter)
                    'sbSql.Append(ScopeFilter)
                    'sbSql.Append("ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc ")
                    'sbSql.Append("ORDER BY x.LoadType desc, x.LoadID desc, x.UpdatedDate desc, x.ViewOrder ")

                Case "CN", "LI", "PO", "PJ", "PC"
                    'sbSql.Append("WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') ")
                    sbSql.Append("AND (" & strSearchOn & " LIKE '" & strSearchText & "') ")
                    'sbSql.Append(DateFilter)
                    'sbSql.Append(ScopeFilter)
                    'sbSql.Append("ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc ")
                    'sbSql.Append("ORDER BY x.LoadType desc, x.LoadID desc, x.UpdatedDate desc, x.ViewOrder ")

                Case Else '"ANY"
                    'sbSql.Append("WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') ")
                    sbSql.Append("AND ((cn.CustomerName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (oo.DriverName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (io.IOName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (bk.BrokerName LIKE '" & strSearchText & "') ")
                    sbSql.Append("OR (x.LoadId LIKE '" & strSearchText & "')) ")
                    'sbSql.Append(DateFilter)
                    'sbSql.Append(ScopeFilter)
                    'sbSql.Append("ORDER BY x.LoadType desc, x.LoadID desc, x.UpdatedDate desc, x.ViewOrder ")
            End Select
            sbSql.Append(DateFilter)
            sbSql.Append(ScopeFilter)
            'sbSql.Append("ORDER BY x.LoadType desc, x.LoadID desc, x.UpdatedDate desc, x.ViewOrder ")
            'sbSql.Append("ORDER BY x.JRCIOfficeCode, x.LoadType desc, x.XMissionDate desc, x.LoadId desc ")
            sbSql.Append("ORDER BY x.JRCIOfficeCode, x.LoadType desc, x.XMissionDate, x.LoadId ")

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString), GetType(LoadSheetInfo))
            ' Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)
            Dim dt As New DataTable
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString))
            Return dt

        End Function

        'Function to get the Searched Data
        Public Function GetSearchLoadSheets(Optional ByVal LoadType As String = "IO", Optional ByVal SearchText As String = "", Optional ByVal SearchType As String = "A") As IDataReader 'ArrayList '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT TOP 111 ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.ItemID, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.LoadID, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.OfficeVendorNO, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.CustomerName, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.LoadType")

            Select Case LoadType.ToUpper
                Case "BK"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "ARD_BrokerMaster.BrokerName ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "ARD_BrokerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.BrokerCode = " & MyOjectQualifier & "ARD_BrokerMaster.BrokerCode ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadType = '" & LoadType & "' ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_BrokerMaster.BrokerName LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_BrokerMaster.BrokerName LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                Case "OO"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverName ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile ON " & MyOjectQualifier & "tblOOLoadSheetHeader.DriverCode = " & MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverCode ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadType = '" & LoadType & "' ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverName LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverName LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                Case "IO"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "ARD_InterOffice.IOName ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "ARD_InterOffice ON " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = " & MyOjectQualifier & "ARD_InterOffice.JRCIOfficeCode ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadType = '" & LoadType & "' ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_InterOffice.IOName LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_InterOffice.IOName LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                Case Else '"IO"
                    sbSql.Append(" ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")

            End Select

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)
            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))

        End Function

        'Function to get the Searched Data
        Public Function GetSearchUserLoads(ByVal JRCIOCode As String, Optional ByVal LoadType As String = "CN", Optional ByVal SearchText As String = "", Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal SearchType As String = "A") As IDataReader 'ArrayList  '
            Dim DateTo As Date = Now
            If ToDate <> "" Then
                Try
                    DateTo = Date.Parse(ToDate)
                Catch
                    DateTo = Now
                End Try
            End If
            Dim DateFrom As Date = #1/1/2000#
            If FromDate <> "" Then
                Try
                    DateFrom = Date.Parse(FromDate)
                Catch
                    DateFrom = #1/1/2000#
                End Try
            End If

            If DateFrom > DateTo Then
                Dim tDate As Date = DateFrom
                DateFrom = DateTo
                DateTo = tDate
            End If

            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT TOP 111 ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.ItemID, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.LoadID, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.LoadStatus, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.OfficeVendorNO, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.IOName, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.CustomerName, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.LoadType, ")
            sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate, ")

            sbSql.Append("'CustomerStatus'=" & MyOjectQualifier & "AR1_CustomerMaster.CStatus")

            Select Case LoadType.ToUpper
                Case "CN"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "AR1_CustomerMaster.CustomerName ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "AR1_CustomerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.CustomerNumber = " & MyOjectQualifier & "AR1_CustomerMaster.CustomerNumber ")
                    'sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = '" & IOCode & "' ")
                    'sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.OfficeVendorNO = '" & JRCIOCode & "' ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode = '" & JRCIOCode & "' ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "') ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "') ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "AR1_CustomerMaster.CustomerName LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "AR1_CustomerMaster.CustomerName LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                Case "OO"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverName ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "AR1_CustomerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.CustomerNumber = " & MyOjectQualifier & "AR1_CustomerMaster.CustomerNumber ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile ON " & MyOjectQualifier & "tblOOLoadSheetHeader.DriverCode = " & MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverCode ")
                    'sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = '" & IOCode & "' ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode = '" & JRCIOCode & "' ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "') ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "') ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverName LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_SalesPersonMasterfile.DriverName LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                Case "IO"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "ARD_InterOffice.IOName ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "AR1_CustomerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.CustomerNumber = " & MyOjectQualifier & "AR1_CustomerMaster.CustomerNumber ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "ARD_InterOffice ON " & MyOjectQualifier & "tblOOLoadSheetHeader.IOCode = " & MyOjectQualifier & "ARD_InterOffice.JRCIOfficeCode ")
                    'sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = '" & IOCode & "' ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode = '" & JRCIOCode & "' ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "') ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "') ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_InterOffice.IOName LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_InterOffice.IOName LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                Case "BK"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "ARD_BrokerMaster.BrokerName ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "AR1_CustomerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.CustomerNumber = " & MyOjectQualifier & "AR1_CustomerMaster.CustomerNumber ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "ARD_BrokerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.BrokerCode = " & MyOjectQualifier & "ARD_BrokerMaster.BrokerCode ")
                    'sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = '" & IOCode & "' ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode = '" & JRCIOCode & "' ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "') ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "') ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_BrokerMaster.BrokerName LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "ARD_BrokerMaster.BrokerName LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                Case "LI"
                    sbSql.Append(", ")
                    sbSql.Append(MyOjectQualifier & "tblOOLoadSheetHeader.LoadId ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "AR1_CustomerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.CustomerNumber = " & MyOjectQualifier & "AR1_CustomerMaster.CustomerNumber ")
                    'sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = '" & IOCode & "' ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode = '" & JRCIOCode & "' ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "') ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "') ")
                    If SearchType.ToUpper = "S" Then
                        sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadId LIKE '" & SearchText & "%' ")
                    Else
                        sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadId LIKE '%" & SearchText & "%' ")
                    End If
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")
                    'Case Else '"ANY"
                    '    sbSql.Append(", "
                    '    sbSql.Append(MyOjectQualifier & "ARD_InterOffice.IOName "
                    '    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader "
                    '    sbSql.Append("JOIN " & MyOjectQualifier & "ARD_InterOffice ON " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = " & MyOjectQualifier & "ARD_InterOffice.JRCIOfficeCode "
                    '    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadType = '" & LoadType & "' "
                    'If SearchType.ToUpper = "S" Then
                    'Else
                    'End If
                    '    sbSql.Append("AND " & MyOjectQualifier & "ARD_InterOffice.IOName LIKE '%" & SearchText & "%' "
                    '    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc"
                Case Else '"ANY"
                    sbSql.Append(" ")
                    sbSql.Append("FROM " & MyOjectQualifier & "tblOOLoadSheetHeader ")
                    sbSql.Append("JOIN " & MyOjectQualifier & "AR1_CustomerMaster ON " & MyOjectQualifier & "tblOOLoadSheetHeader.CustomerNumber = " & MyOjectQualifier & "AR1_CustomerMaster.CustomerNumber ")
                    'sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOCode = '" & IOCode & "' ")
                    sbSql.Append("WHERE " & MyOjectQualifier & "tblOOLoadSheetHeader.JRCIOfficeCode = '" & JRCIOCode & "' ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "') ")
                    sbSql.Append("AND " & MyOjectQualifier & "tblOOLoadSheetHeader.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "') ")
                    sbSql.Append("ORDER BY " & MyOjectQualifier & "tblOOLoadSheetHeader.CreatedDate desc")

            End Select

            'Return CType(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), IDataReader)
            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString), GetType(LoadSheetInfo))

        End Function

        'Function to get LoadStatus info
        Public Function GetInfoForLoadStatus(ByVal LoadId As String) As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_InfoForLoadStatus", LoadId)
        End Function

        'Function to get ForUnXmit
        'Public Function GetForUnXmit(ByVal JRCIOfficeCode As String, Optional ByVal NoOfItems As Integer = 100) As IDataReader
        '    Return DataProvider.Instance().ExecuteReader("bhattji_ForUnXmit", JRCIOfficeCode, NoOfItems)
        'End Function
        Public Function GetForUnXmit(ByVal JRCIOfficeCode As String, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
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
            Return DataProvider.Instance().ExecuteReader("bhattji_ForUnXmit", JRCIOfficeCode, NoOfItems, DateFrom, DateTo)
        End Function
        'Functions defined for getting values from the External Stored Procedures
        Public Function GetCustomerId(ByVal CustomerNumber As String) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetCustomerId", CustomerNumber))
        End Function

        Public Function GetCustomerByNumber(ByVal CustomerNumber As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetCustomer", GetCustomerId(CustomerNumber))
        End Function

        Public Function GetCustomerName(ByVal CustomerNumber As String) As String
            Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetCustomerName", CustomerNumber))
        End Function

        Public Function GetAllCustomers() As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllCustomers")
        End Function

        Public Function GetSearchedCustomers(ByVal SearchText As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetSearchedCustomers", SearchText)
        End Function

        Public Function GetSearchedBrokers(ByVal SearchText As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetSearchedBrokers", SearchText)
        End Function

        'Public Function GetSearchedCustomers(ByVal SearchText As String) As IDataReader
        '    Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
        '    Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
        '    Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
        '    If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
        '        MyOjectQualifier &= "_"
        '    End If

        '    Dim MySqlString As String = String.Empty
        '    MySqlString &= "SELECT "
        '    MySqlString &= MyOjectQualifier & "AR1_CustomerMaster.CustomerName, "
        '    MySqlString &= MyOjectQualifier & "AR1_CustomerMaster.CustomerNumber "

        '    MySqlString &= "FROM " & MyOjectQualifier & "AR1_CustomerMaster "

        '    MySqlString &= "WHERE " & MyOjectQualifier & "AR1_CustomerMaster.CustomerName LIKE '%" & SearchText & "%' "

        '    MySqlString &= "ORDER BY " & MyOjectQualifier & "AR1_CustomerMaster.CustomerName"

        '    Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        'End Function

        Public Function GetAllSalesPersons(Optional ByVal NoOfItems As Integer = 1000) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllSalesPersons", NoOfItems)
        End Function

        Public Function GetAllSalesPersonsByJRCIOCode(ByVal JRCIOCode As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllSalesPersonsByJRCIOCode", JRCIOCode)
        End Function

        'Public Function GetActiveSalesPersonsByIOCode(ByVal JRCIOCode As String) As IDataReader
        '    Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetActiveSalesPersonsByIOCode", JRCIOCode)
        'End Function

        Public Function GetAllBrokers(Optional ByVal NoOfItems As Integer = 1000) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllBrokers", NoOfItems)
        End Function

        Public Function GetAllSalesReps(Optional ByVal NoOfItems As Integer = 100) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllSalesReps", NoOfItems)
        End Function

        Public Function GetAllInterOffices(Optional ByVal NoOfItems As Integer = 100) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetAllInterOffices", NoOfItems)
        End Function

        Public Function GetUserIOs(ByVal Username As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetUserIOs", Username)
        End Function

        Public Function GetUserDefaultIO(ByVal Username As String) As String
            Return Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetUserDefaultIO", Username))
        End Function

        Public Sub UpdateInterOfficeXmission(ByVal JRCIOfficeCode As String, ByVal Xfer As Double, ByVal LastXferDate As Date, ByVal LastXmission As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateInterOfficeXmission", JRCIOfficeCode, Xfer, GetNull(LastXferDate), GetNull(LastXmission))
        End Sub

        Public Function IsBrokerOnlyOffice(ByVal JRCIOfficeCode As String) As Boolean
            Return (Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_IsBrokerOnly", JRCIOfficeCode)).ToUpper = "Y")
        End Function

        Public Function GetBrokerId(ByVal BrokerCode As String) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetBrokerId", BrokerCode))
        End Function

        Public Function GetBrokerByCode(ByVal BrokerCode As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetBroker", GetBrokerId(BrokerCode))
        End Function

        'Public Function GetCustomerSearchForReports(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "", Optional ByVal StartsWith As Boolean = False, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
        '    Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
        '    Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
        '    Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
        '    If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
        '        MyOjectQualifier &= "_"
        '    End If

        '    Dim strSearchText As String
        '    If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

        '    Dim DateFilter As String = ""
        '    Dim DateTo As Date = Now
        '    If ToDate <> "" Then
        '        Try
        '            DateTo = Date.Parse(ToDate)
        '        Catch
        '            DateTo = Now
        '        End Try
        '    End If
        '    Dim DateFrom As Date = #1/1/1947#
        '    If FromDate <> "" Then
        '        Try
        '            DateFrom = Date.Parse(FromDate)
        '        Catch
        '            DateFrom = #1/1/1947#
        '        End Try
        '    End If

        '    If DateFrom > DateTo Then
        '        Dim tDate As Date = DateFrom
        '        DateFrom = DateTo
        '        DateTo = tDate
        '    End If

        '    If FromDate <> "" Then DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
        '    If ToDate <> "" Then DateFilter &= "AND (x.UpdatedDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

        '    Dim MySqlString As String = String.Empty
        '    MySqlString &= "SELECT DISTINCT "

        '    MySqlString &= "x.CustomerNumber, "
        '    MySqlString &= "cn.CustomerName "

        '    MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "


        '    MySqlString &= "WHERE ((x.CustomerNumber LIKE '%" & SearchText & "%') "
        '    MySqlString &= "OR (cn.CustomerName LIKE '" & strSearchText & "')) "
        '    MySqlString &= DateFilter
        '    If ((JRCIOfficeCode <> "") AndAlso (JRCIOfficeCode <> "000000000")) Then MySqlString &= "AND (x.JRCIOfficeCode='" & JRCIOfficeCode & "') "
        '    MySqlString &= "ORDER BY x.CustomerNumber, cn.CustomerName"

        '    Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        'End Function

        Public Function GetCustomerSearchForReports(ByVal SearchText As String, Optional ByVal JRCIOfficeCode As String = "", Optional ByVal StartsWith As Boolean = False, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim strSearchText As String
            If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "

            MySqlString &= "x.CustomerNumber, "
            MySqlString &= "x.CustomerName "

            MySqlString &= "FROM " & MyOjectQualifier & "AR1_CustomerMaster AS x "

            MySqlString &= "WHERE ((x.CustomerNumber LIKE '%" & SearchText & "%') "
            MySqlString &= "OR (x.CustomerName LIKE '" & strSearchText & "')) "
            'MySqlString &= DateFilter
            'If ((JRCIOfficeCode <> "") AndAlso (JRCIOfficeCode <> "000000000")) Then MySqlString &= "AND (x.JRCIOfficeCode='" & JRCIOfficeCode & "') "
            MySqlString &= "ORDER BY x.CustomerName, x.CustomerNumber "

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        End Function

        'Public Function GetCustomerDDL(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As DataTable
        '    Dim dt As New DataTable
        '    dt.Columns.Add("CustomerNumber", GetType(String))
        '    dt.Columns.Add("CustomerName", GetType(String))

        '    Return dt
        'End Function
        Public Function GetCustomerSearch(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

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

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT TOP " & NoOfItems.ToString & " "

            MySqlString &= "x.CustomerName, "
            MySqlString &= "'CustomerNameNumber'=x.CustomerName + ' | ' + x.CustomerNumber, "
            MySqlString &= "x.CustomerNumber "

            MySqlString &= "FROM " & MyOjectQualifier & "AR1_CustomerMaster AS x "

            MySqlString &= "WHERE (x.CustomerStatus <> 'I') "


            Select Case SearchOn.ToUpper
                Case "CUSTOMERNAME"
                    MySqlString &= "AND (x.CustomerName LIKE '" & strSearchText & "') "
                Case "CUSTOMERNUMBER"
                    MySqlString &= "AND (x.CustomerNumber LIKE '%" & SearchText & "%') "

                Case Else '"ANY"
                    MySqlString &= "AND ((x.CustomerName LIKE '" & strSearchText & "') "
                    MySqlString &= "OR (x.CustomerNumber LIKE '%" & SearchText & "%')) "

            End Select

            MySqlString &= DateFilter
            MySqlString &= "ORDER BY x.CustomerName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        End Function

        Public Function GetDriverSearchByIO(ByVal SearchText As String, ByVal JRCIOCode As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

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

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "

            MySqlString &= "DriverName, "
            MySqlString &= "DriverCode "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x "

            MySqlString &= "WHERE (x.OfficeOwner = '" & JRCIOCode & "') "

            MySqlString &= "AND (x.Status='N') "

            If Not String.IsNullOrEmpty(SearchText) Then
                Select Case SearchOn.ToUpper
                    Case "DRIVERNAME", "DRIVERCODE"
                        MySqlString &= "AND (x." & SearchOn & " LIKE '" & strSearchText & "') "

                    Case Else '"ANY"
                        MySqlString &= "AND ((x.DriverName LIKE '" & strSearchText & "') "
                        MySqlString &= "OR (x.DriverCode LIKE '" & strSearchText & "')) "

                End Select
            End If

            MySqlString &= DateFilter
            MySqlString &= "ORDER BY x.DriverName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)
        End Function

        Public Function GetDriverSearch(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

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

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT TOP " & NoOfItems.ToString & " "

            MySqlString &= "DriverName, "
            MySqlString &= "DriverCode "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x "

            MySqlString &= "WHERE (x.Status='N') "

            Select Case SearchOn.ToUpper
                Case "DRIVERNAME", "DRIVERCODE"
                    MySqlString &= "AND (x." & SearchOn & " LIKE '" & strSearchText & "') "

                Case Else '"ANY"
                    MySqlString &= "AND ((x.DriverName LIKE '" & strSearchText & "') "
                    MySqlString &= "OR (x.DriverCode LIKE '" & strSearchText & "')) "

            End Select

            MySqlString &= DateFilter
            MySqlString &= "ORDER BY x.DriverName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        End Function

        Public Function GetDriverSearchByIO2(ByVal SearchText As String, ByVal JRCIOCode As String, ByVal Status As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If



            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT  "
            'MySqlString &= "TOP " & NoOfItems.ToString & " "

            MySqlString &= "DriverName, "
            MySqlString &= "DriverCode "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x "

            MySqlString &= "WHERE (x.OfficeOwner = '" & JRCIOCode & "') "

            Select Case Status.ToUpper
                Case "N", "Y"
                    MySqlString &= "AND (x.Status='" & Status & "') "
            End Select

            MySqlString &= "AND ((x.DriverName LIKE '" & SearchText & "%') "
            MySqlString &= "OR (x.DriverCode LIKE '%" & SearchText & "%')) "

            MySqlString &= "ORDER BY x.DriverName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)
        End Function

        Public Function GetBrokerSearchByIO2(ByVal SearchText As String, ByVal JRCIOCode As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If



            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT  "
            'MySqlString &= "TOP " & NoOfItems.ToString & " "

            MySqlString &= "BrokerName, "
            MySqlString &= "BrokerCode "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_BrokerMaster AS x "

            MySqlString &= "WHERE (x.OfficeOwner = '" & JRCIOCode & "') "

            MySqlString &= "AND (x.BStatus='ACTIVE') "

            MySqlString &= "AND ((x.BrokerName LIKE '" & SearchText & "%') "
            MySqlString &= "OR (x.BrokerCode LIKE '%" & SearchText & "%')) "

            MySqlString &= "ORDER BY x.BrokerName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)
        End Function


        Public Function GetDriverSearch2(ByVal SearchText As String, ByVal Status As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT  "
            'MySqlString &= "TOP " & NoOfItems.ToString & " "

            MySqlString &= "DriverName, "
            MySqlString &= "DriverCode "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x "

            MySqlString &= "WHERE ((x.DriverName LIKE '" & SearchText & "%') "
            MySqlString &= "OR (x.DriverCode LIKE '%" & SearchText & "%')) "

            Select Case Status.ToUpper
                Case "N", "Y"
                    MySqlString &= "AND (x.Status='" & Status & "') "
            End Select

            MySqlString &= "ORDER BY x.DriverName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        End Function

        Public Function GetBrokerSearch2(ByVal SearchText As String, ByVal Status As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT  "
            'MySqlString &= "TOP " & NoOfItems.ToString & " "
            MySqlString &= "TOP 200 "

            MySqlString &= "BrokerName, "
            MySqlString &= "BrokerCode "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_BrokerMaster AS x "

            MySqlString &= "WHERE ((x.BrokerName LIKE '" & SearchText & "%') "
            MySqlString &= "OR (x.BrokerCode LIKE '%" & SearchText & "%')) "

            'MySqlString &= "WHERE (x.Status='Y') "
            'MySqlString &= "WHERE (x.BStatus='ACTIVE') "
            Select Case Status.ToUpper
                Case "ACTIVE", "INACTIVE"
                    MySqlString &= "AND (x.BStatus='" & Status.ToUpper & "') "
            End Select
            MySqlString &= "ORDER BY x.BrokerName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        End Function

        Public Function GetBkrSalesPersonId(ByVal DriverCode As String) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_BkrGetSalesPersonId", DriverCode))
        End Function

        Public Function GetSalesPersonId(ByVal DriverCode As String) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetSalesPersonId", DriverCode))
        End Function

        Public Function GetDriverByCode(ByVal DriverCode As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetSalesPerson", GetSalesPersonId(DriverCode))
        End Function

        Public Function GetIOSearch(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

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

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT TOP " & NoOfItems.ToString & " "

            MySqlString &= "IOName, "
            MySqlString &= "JRCIOfficeCode, "
            MySqlString &= "JRCActive "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_InterOffice AS x "

            MySqlString &= "WHERE (x.JRCActive = 'Y') "

            Select Case SearchOn.ToUpper
                Case "IONAME", "JRCIOFFICECODE"
                    MySqlString &= "AND (x." & SearchOn & " LIKE '" & strSearchText & "') "

                Case Else '"ANY"
                    MySqlString &= "AND ((x.IOName LIKE '" & strSearchText & "') "
                    MySqlString &= "OR (x.JRCIOfficeCode LIKE '" & strSearchText & "')) "

            End Select

            MySqlString &= DateFilter
            MySqlString &= "ORDER BY x.IOName, x.ViewOrder, x.CreatedDate desc"

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)
        End Function

        Public Function GetInterOfficeId(ByVal JRCIOfficeCode As String) As Integer
            Return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetInterOfficeId", JRCIOfficeCode))
        End Function

        Public Function GetInterOfficeOOCode(ByVal JRCIOfficeCode As String) As String
            Dim OONo As String = Convert.ToString(DotNetNuke.Data.DataProvider.Instance.ExecuteScalar("bhattji_GetInterOfficeOOCode", JRCIOfficeCode))
            If OONo = "" Then OONo = "OO"
            Return OONo.Substring(0, 2)
        End Function

        Public Function GetIOByCode(ByVal JRCIOfficeCode As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetInterOffice", GetInterOfficeId(JRCIOfficeCode))
        End Function

        'Public Function GetBrokerSearch(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As IDataReader
        '    Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
        '    Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
        '    Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
        '    If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
        '        MyOjectQualifier &= "_"
        '    End If

        '    Dim strSearchText As String
        '    If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

        '    Dim DateFilter As String = ""
        '    Dim DateTo As Date = Now
        '    If ToDate <> "" Then
        '        Try
        '            DateTo = Date.Parse(ToDate)
        '        Catch
        '            DateTo = Now
        '        End Try
        '    End If
        '    Dim DateFrom As Date = #1/1/1947#
        '    If FromDate <> "" Then
        '        Try
        '            DateFrom = Date.Parse(FromDate)
        '        Catch
        '            DateFrom = #1/1/1947#
        '        End Try
        '    End If

        '    If DateFrom > DateTo Then
        '        Dim tDate As Date = DateFrom
        '        DateFrom = DateTo
        '        DateTo = tDate
        '    End If

        '    If FromDate <> "" Then DateFilter = "AND (x.UpdatedDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
        '    If ToDate <> "" Then DateFilter &= "AND (x.UpdatedDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

        '    Dim MySqlString As String = String.Empty
        '    MySqlString &= "SELECT TOP " & NoOfItems.ToString & " "

        '    MySqlString &= "BrokerName, "
        '    MySqlString &= "BrokerCode "

        '    MySqlString &= "FROM " & MyOjectQualifier & "ARD_BrokerMaster AS x "

        '    'MySqlString &= "WHERE (x.Status='Y') "
        '    MySqlString &= "WHERE (x.BStatus='ACTIVE') "

        '    Select Case SearchOn.ToUpper
        '        Case "BROKERCODE", "BROKERNAME"
        '            MySqlString &= "AND (x." & SearchOn & " LIKE '" & strSearchText & "') "

        '        Case Else '"ANY"
        '            MySqlString &= "AND ((x.BrokerName LIKE '" & strSearchText & "') "
        '            MySqlString &= "OR (x.BrokerCode LIKE '%" & SearchText & "%')) "

        '    End Select

        '    MySqlString &= DateFilter
        '    MySqlString &= "ORDER BY x.BrokerName, x.ViewOrder, x.CreatedDate desc"

        '    Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString)

        'End Function

        'Public Function GetBrokerSearch(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100) As IDataReader
        '    Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
        '    Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
        '    Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
        '    If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
        '        MyOjectQualifier &= "_"
        '    End If

        '    Dim strSearchText As String
        '    If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

        '    Dim sbSql As New StringBuilder
        '    sbSql.Append("SELECT TOP " & NoOfItems.ToString & " ")

        '    sbSql.Append("BrokerName, ")
        '    sbSql.Append("BrokerCode ")

        '    sbSql.Append("FROM " & MyOjectQualifier & "ARD_BrokerMaster AS x ")

        '    'MySqlString &= "WHERE (x.Status='Y') "
        '    sbSql.Append("WHERE (x.BStatus='ACTIVE') ")

        '    Select Case SearchOn.ToUpper
        '        Case "BROKERCODE", "BROKERNAME"
        '            sbSql.Append("AND (x." & SearchOn & " LIKE '" & strSearchText & "') ")

        '        Case Else '"ANY"
        '            sbSql.Append("AND ((x.BrokerName LIKE '" & strSearchText & "') ")
        '            sbSql.Append("OR (x.BrokerCode LIKE '%" & SearchText & "%')) ")

        '    End Select

        '    sbSql.Append("ORDER BY x.BrokerName, x.ViewOrder, x.CreatedDate desc ")

        '    Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        'End Function


        Public Function GetBrokerSearch(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList '
            'Public Function GetBrokerSearch(ByVal SearchText As String, Optional ByVal StartsWith As Boolean = False) As IDataReader 'ArrayList '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim strSearchText As String
            If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT TOP " & NoOfItems.ToString & " ")
            'sbSql.Append("SELECT TOP 100 ")

            sbSql.Append("x.BrokerName, ")
            sbSql.Append("x.BrokerCode ")

            sbSql.Append("FROM " & MyOjectQualifier & "ARD_BrokerMaster AS x ")

            'sbSql.Append("WHERE (x.State LIKE '%" & StateCode & "%') ")
            sbSql.Append("WHERE ((x.BStatus='ACTIVE') OR (x.BStatus='HOLD')) ")

            'Select Case SearchOn.ToUpper
            '    Case "BROKERNAME", "BROKERCODE"
            '        sbSql.Append("AND (x." & SearchOn & " LIKE '" & strSearchText & "') ")

            '    Case Else '"ANY"
            '        sbSql.Append("AND ((x.BrokerName LIKE '" & strSearchText & "') ")
            '        sbSql.Append("OR (x.BrokerCode LIKE '%" & SearchText & "%')) ")

            'End Select
            sbSql.Append("AND ((x.BrokerName LIKE '" & strSearchText & "') ")
            sbSql.Append("OR (x.BrokerCode LIKE '%" & SearchText & "%')) ")

            sbSql.Append("ORDER BY x.BrokerName, x.ViewOrder, x.UpdatedDate desc ")

            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)

        End Function

        Public Function GetBkrDrivers(ByVal JRCIOfficeCode As String, ByVal BrokerCode As String, Optional ByVal Active As String = "N") As IDataReader
            If Active = "" OrElse Active = "Y" Then
                Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrDrivers", JRCIOfficeCode, BrokerCode)
            Else
                Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_BkrDriversActive", JRCIOfficeCode, BrokerCode)
            End If
        End Function


        'Reports Functions
        'Public Function GetSysInquiry(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0, Optional ByVal SortOn As String = "LoadDate desc, JRCIOfficeCode, LoadId", Optional ByVal SortDesc As Boolean = False) As DataTable 'IDataReader '
        '    'Public Function GetReport1() As DataTable 'IDataReader '
        '    Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
        '    Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
        '    Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
        '    If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
        '        MyOjectQualifier &= "_"
        '    End If

        '    'Set Scope for Module, Portal or All
        '    Dim ScopeFilter As String = ""


        '    Select Case GetItems
        '        Case 0
        '            If ModuleId > -1 Then
        '                ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
        '            End If
        '        Case 1
        '            If PortalId > -1 Then
        '                ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
        '            End If
        '        Case 2
        '            'Do Nothing
        '        Case Else '0
        '            If PortalId > -1 Then
        '                ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
        '            ElseIf ModuleId > -1 Then
        '                ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
        '            End If
        '    End Select

        '    Dim strSearchText As String
        '    If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

        '    Dim DateFilter As String = ""
        '    Dim DateTo As Date = Now
        '    If ToDate <> "" Then
        '        Try
        '            DateTo = Date.Parse(ToDate)
        '        Catch
        '            DateTo = Now
        '        End Try
        '    End If
        '    Dim DateFrom As Date = #1/1/1947#
        '    If FromDate <> "" Then
        '        Try
        '            DateFrom = Date.Parse(FromDate)
        '        Catch
        '            DateFrom = #1/1/1947#
        '        End Try
        '    End If

        '    If DateFrom > DateTo Then
        '        Dim tDate As Date = DateFrom
        '        DateFrom = DateTo
        '        DateTo = tDate
        '    End If

        '    If LoadStatus.ToUpper = "COMPLETE" Then
        '        If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
        '        If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
        '    Else
        '        If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
        '        If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
        '    End If

        '    'If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
        '    'If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

        '    Dim MySqlString As String = String.Empty
        '    MySqlString &= "SELECT "
        '    If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
        '    'MySqlString &= "x.* "
        '    MySqlString &= "x.ItemId, "
        '    MySqlString &= "x.JRCIOfficeCode, "
        '    MySqlString &= "x.LoadType, "

        '    MySqlString &= "x.LoadID, "
        '    MySqlString &= "x.LoadDate, "
        '    MySqlString &= "x.LoadStatus, "
        '    MySqlString &= "x.XMissionFile, "
        '    MySqlString &= "cn.CustomerName, "
        '    MySqlString &= "dm.DispatchName, "
        '    MySqlString &= "x.CustPO, "
        '    MySqlString &= "IO.IOName, "
        '    MySqlString &= "x.PUCityST, "
        '    MySqlString &= "x.DPCityST, "
        '    MySqlString &= "sp.DriverName, "
        '    MySqlString &= "bk.BrokerName, "

        '    MySqlString &= "la.BCustBill, "
        '    MySqlString &= "la.BBaseLoad, "
        '    MySqlString &= "la.RepDlr, "
        '    MySqlString &= "la.DRTotDue, "
        '    MySqlString &= "la.IOCommTot, "
        '    MySqlString &= "la.IOAdminTot, "
        '    MySqlString &= "la.ExTot, "
        '    MySqlString &= "la.APComm4, "
        '    MySqlString &= "la.JRCOffComm, "
        '    MySqlString &= "la.JRCOnePct, "
        '    MySqlString &= "la.JRCTotal, "
        '    MySqlString &= "la.GPPct "

        '    MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
        '    'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS sp ON x.DriverCode=sp.DriverCode "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "



        '    Dim strSearchOn As String
        '    Select Case SearchOn.ToUpper
        '        Case "CN"
        '            strSearchOn = "cn.CustomerName "
        '            '    Case "OO"
        '            '        strSearchOn = "oo.DriverName "
        '            '    Case "IO"
        '            '        strSearchOn = "io.IOName "
        '            '    Case "BK"
        '            '        strSearchOn = "bk.BrokerName "
        '            '    Case "LI"
        '            '        strSearchOn = "x.LoadId "
        '            '    Case "PO"
        '            '        strSearchOn = "x.CustPO "
        '            '    Case "PJ"
        '            '        strSearchOn = "x.ProJob "
        '            '    Case "PC"
        '            '        strSearchOn = "x.PUCityST "
        '        Case Else '"Any"
        '            strSearchOn = "Any"
        '    End Select

        '    MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '    If LoadStatus = "" Then
        '        MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
        '        'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
        '    Else
        '        MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
        '    End If
        '    If CustomerNumber <> "" Then
        '        MySqlString &= "AND (cn.CustomerNumber = '" & CustomerNumber & "') "
        '    End If


        '    Select Case SearchOn.ToUpper
        '        '    Case "OO", "IO", "BK"
        '        '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '        '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
        '        '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
        '        '        MySqlString &= DateFilter
        '        '        MySqlString &= ScopeFilter
        '        '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '        '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

        '        Case "CN"
        '            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
        '            MySqlString &= DateFilter
        '            MySqlString &= ScopeFilter
        '            'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '            'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

        '            'Case "LI", "PO", "PJ", "PC"
        '            '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            '    MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
        '            '    MySqlString &= DateFilter
        '            '    MySqlString &= ScopeFilter
        '            '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '            '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

        '        Case Else '"ANY"
        '            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
        '            '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
        '            '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
        '            '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
        '            '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
        '            MySqlString &= ") "
        '            MySqlString &= DateFilter
        '            MySqlString &= ScopeFilter
        '            '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
        '    End Select
        '    MySqlString &= "ORDER BY x.LoadDate desc, x.JRCIOfficeCode, x.LoadId "

        '    'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
        '    'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

        '    'Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

        '    'BBaseLoadTotal = 0
        '    'If Not dr Is Nothing Then
        '    '    While dr.Read
        '    '        Dim _BBaseLoad As Decimal = Convert.ToDecimal(Null.SetNull(dr.Item("BBaseLoad"), _BBaseLoad))
        '    '        If Not Null.IsNull(_BBaseLoad) Then    BBaseLoadTotal += _BBaseLoad

        '    '    End While
        '    'End If

        '    Dim dt As New DataTable
        '    dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

        '    Dim dtr As DataRow
        '    ' TotalRecords = dt.Rows.Count
        '    BBaseLoadTotal = 0
        '    RepDlrTotal = 0
        '    DRTotDueTotal = 0
        '    IOCommTotTotal = 0
        '    IOComm3Total = 0
        '    JRCOffCommTotal = 0
        '    JRCTotalTotal = 0

        '    For Each dtr In dt.Rows
        '        Dim _BBaseLoad As Decimal = Convert.ToDecimal(Null.SetNull(dtr("BBaseLoad"), _BBaseLoad))
        '        If Not Null.IsNull(_BBaseLoad) Then BBaseLoadTotal += _BBaseLoad

        '        Dim _RepDlr As Decimal = Convert.ToDecimal(Null.SetNull(dtr("RepDlr"), _RepDlr))
        '        If Not Null.IsNull(_RepDlr) Then RepDlrTotal += _RepDlr

        '        Dim _DRTotDue As Decimal = Convert.ToDecimal(Null.SetNull(dtr("DRTotDue"), _DRTotDue))
        '        If Not Null.IsNull(_DRTotDue) Then DRTotDueTotal += _DRTotDue

        '        Dim _IOCommTot As Decimal = Convert.ToDecimal(Null.SetNull(dtr("IOCommTot"), _IOCommTot))
        '        If Not Null.IsNull(_IOCommTot) Then IOCommTotTotal += _IOCommTot

        '        Dim _IOComm3 As Decimal = Convert.ToDecimal(Null.SetNull(dtr("IOComm3"), _IOComm3))
        '        If Not Null.IsNull(_IOComm3) Then IOComm3Total += _IOComm3

        '        Dim _JRCOffComm As Decimal = Convert.ToDecimal(Null.SetNull(dtr("JRCOffComm"), _JRCOffComm))
        '        If Not Null.IsNull(_JRCOffComm) Then JRCOffCommTotal += _JRCOffComm

        '        Dim _JRCTotal As Decimal = Convert.ToDecimal(Null.SetNull(dtr("JRCTotal"), _JRCTotal))
        '        If Not Null.IsNull(_JRCTotal) Then JRCTotalTotal += _JRCTotal
        '    Next

        '    If SortDesc Then
        '        dt.DefaultView.Sort = SortOn & " DESC"
        '    Else
        '        dt.DefaultView.Sort = SortOn
        '    End If

        '    'dt.DefaultView.Sort = "LoadDate desc, JRCIOfficeCode, LoadId"

        '    Return dt.DefaultView.ToTable

        'End Function

        Private Function GetDateFilter(ByVal DateField As String, ByVal FromDate As String, ByVal ToDate As String) As String
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

            If FromDate <> "" Then DateFilter = "AND (" & DateField & " >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (" & DateField & " <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Return DateFilter
        End Function

        Public Function GetSysInquiry(ByVal JRCIOfficeCode As String, Optional ByVal LoadType As String = "", Optional ByVal DriverCode As String = "", Optional ByVal BrokerCode As String = "", Optional ByVal JRCIOCode As String = "", Optional ByVal LoadStatus As String = "", Optional ByVal CustomerNumber As String = "", Optional ByVal CustPO As String = "", Optional ByVal ProJob As String = "", Optional ByVal BkrInvNo As String = "", Optional ByVal PUCity As String = "", Optional ByVal DPCity As String = "", Optional ByVal LoadDateFrom As String = "", Optional ByVal LoadDateTo As String = "", Optional ByVal DeliveryDateFrom As String = "", Optional ByVal DeliveryDateTo As String = "", Optional ByVal CompletedDateFrom As String = "", Optional ByVal CompletedDateTo As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
            'Public Function GetReport1() As DataTable 'IDataReader '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            Dim LoadTypeFilter As String = ""
            If LoadType <> "" Then
                LoadTypeFilter = "AND (x.LoadType='" & LoadType & "') "
                Select Case LoadType
                    Case "OO"
                        If DriverCode <> "" Then LoadTypeFilter &= "AND (x.DriverCode='" & DriverCode & "') "
                    Case "BK"
                        If BrokerCode <> "" Then LoadTypeFilter &= "AND (x.BrokerCode='" & BrokerCode & "') "
                        If BkrInvNo <> "" Then LoadTypeFilter &= "AND (x.BkrInvNo LIKE '%" & BkrInvNo & "%') "
                    Case "IO"
                        If JRCIOCode <> "" Then LoadTypeFilter &= "AND (x.JRCIOCode='" & JRCIOCode & "') "
                End Select
            End If

            Dim CustomerFilter As String = ""
            If CustomerNumber <> "" Then CustomerFilter = "AND (x.CustomerNumber='" & CustomerNumber & "') "
            If CustPO <> "" Then CustomerFilter &= "AND (x.CustPO LIKE '%" & CustPO & "%') "
            If ProJob <> "" Then CustomerFilter &= "AND (x.ProJob LIKE '%" & ProJob & "%') "

            'Dim LoadStatusFilter As String = ""
            'If LoadStatus <> "" Then LoadStatusFilter = "AND (x.LoadStatus='" & LoadStatus & "') "


            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""

            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
            End Select

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            'If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            'MySqlString &= "x.* "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.JRCIOfficeCode, "
            MySqlString &= "x.LoadType, "

            MySqlString &= "x.LoadID, "
            MySqlString &= "x.LoadDate, "
            MySqlString &= "x.LoadStatus, "
            MySqlString &= "x.XMissionFile, "
            MySqlString &= "cn.CustomerName, "
            MySqlString &= "dm.DispatchName, "
            MySqlString &= "x.CustPO, "
            MySqlString &= "IO.IOName, "
            MySqlString &= "x.PUCityST, "
            MySqlString &= "x.DPCityST, "
            MySqlString &= "sp.DriverName, "
            MySqlString &= "bk.BrokerName, "

            MySqlString &= "la.BCustBill, "
            MySqlString &= "la.BBaseLoad, "
            MySqlString &= "la.RepDlr, "
            MySqlString &= "la.DRTotDue, "
            MySqlString &= "la.IOCommTot, "
            MySqlString &= "la.IOAdminTot, "
            MySqlString &= "la.ExTot, "
            MySqlString &= "la.APComm4, "
            MySqlString &= "la.JRCOffComm, "
            MySqlString &= "la.JRCOnePct, "
            MySqlString &= "la.JRCTotal, "
            MySqlString &= "la.GPPct "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS sp ON x.DriverCode=sp.DriverCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "


            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            'MySqlString &= LoadStatusFilter
            If JRCIOfficeCode = "999999999" Then
                If LoadStatus = "" Then
                    MySqlString &= "WHERE ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE') OR (x.LoadStatus = 'VOIDED')) "
                Else
                    MySqlString &= "WHERE (x.LoadStatus = '" & LoadStatus & "') "
                End If
            Else
                MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                'If LoadStatus = "" Then
                '    MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE') OR (x.LoadStatus = 'VOIDED')) "
                'Else
                '    MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
                'End If
                If LoadStatus <> "" Then MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
            End If

            MySqlString &= LoadTypeFilter
            MySqlString &= CustomerFilter
            MySqlString &= GetDateFilter("x.LoadDate", LoadDateFrom, LoadDateTo)
            MySqlString &= GetDateFilter("x.DeliveryDate", DeliveryDateFrom, DeliveryDateTo)
            MySqlString &= GetDateFilter("x.CompletedDate", CompletedDateFrom, CompletedDateTo)
            If PUCity <> "" Then MySqlString &= "AND (x.PUCityST LIKE '%" & PUCity & "%') "
            If DPCity <> "" Then MySqlString &= "AND (x.DPCityST LIKE '%" & DPCity & "%') "
            MySqlString &= ScopeFilter
            MySqlString &= "ORDER BY x.LoadDate desc, x.JRCIOfficeCode, x.LoadId "

            Return GetDataTable(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

        End Function

        Public Function GetDrvCerti(ByVal JRCIOfficeCode As String, Optional ByVal Status As String = "All", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
            'Public Function GetReport1() As DataTable 'IDataReader '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If



            'Dim LoadStatusFilter As String = ""
            'If LoadStatus <> "" Then LoadStatusFilter = "AND (x.LoadStatus='" & LoadStatus & "') "


            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""

            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
            End Select

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            'If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            'MySqlString &= "x.* "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.DriverCode, "
            MySqlString &= "x.DriverName, "
            MySqlString &= "x.AccountNo, "
            MySqlString &= "x.Status, "
            MySqlString &= "x.City, "
            MySqlString &= "x.State, "
            MySqlString &= "x.ZipCode, "
            MySqlString &= "x.PhoneNo, "
            MySqlString &= "x.CellPhone, "
            MySqlString &= "x.LastTrailerUsed, "
            MySqlString &= "x.LastLoadID, "
            MySqlString &= "x.LastLoad,"
            MySqlString &= "x.Term_Date, "
            MySqlString &= "x.CommRate, "
            MySqlString &= "x.MoMaint,"
            MySqlString &= "x.DotInspec,"
            MySqlString &= "x.TrailerMaint, "
            MySqlString &= "x.RegRenew, "
            MySqlString &= "x.OccIns, "
            MySqlString &= "x.NtlIns, "
            MySqlString &= "x.PhysDmg, "
            MySqlString &= "x.SeaLink, "
            MySqlString &= "x.AnnIns, "
            MySqlString &= "x.OfficeOwner "

            MySqlString &= "FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
            ''MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS sp ON x.DriverCode=sp.DriverCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "


            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            'MySqlString &= LoadStatusFilter
            If JRCIOfficeCode <> "999999999" Then
                MySqlString &= "WHERE (x.OfficeOwner = '" & JRCIOfficeCode & "') "
                If (Status = "N") OrElse (Status = "Y") Then
                    MySqlString &= "AND (x.Status = '" & Status & "') "
                End If
            Else
                If (Status = "N") OrElse (Status = "Y") Then
                    MySqlString &= "WHERE (x.Status = '" & Status & "') "
                End If
            End If

            MySqlString &= ScopeFilter
            MySqlString &= "ORDER BY x.OfficeOwner, x.DriverName, x.LastLoad DESC "

            Dim dt As DataTable = GetDataTable(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

            For Each dtr As DataRow In dt.Rows
                'If Null.IsNull(dtr("LoadItemId")) Then dtr("LoadItemId") = 0
                dtr("PhoneNo") = Phone.FormatPhoneNo(dtr("PhoneNo").ToString)
                dtr("CellPhone") = Phone.FormatPhoneNo(dtr("CellPhone").ToString)
            Next

            Return dt

        End Function

        Public Function GetReport1(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0, Optional ByVal SortOn As String = "LoadDate desc, JRCIOfficeCode, LoadId", Optional ByVal SortDesc As Boolean = False) As DataTable 'IDataReader '
            'Public Function GetReport1() As DataTable 'IDataReader '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If LoadStatus.ToUpper = "COMPLETE" Then
                If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            Else
                If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            End If

            'If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            'If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            'MySqlString &= "x.* "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.LoadStatus, "
            MySqlString &= "x.LoadID, "
            MySqlString &= "x.LoadDate, "
            MySqlString &= "la.BBaseLoad, "
            MySqlString &= "la.BCustBill, "
            MySqlString &= "la.RepDlr, "
            MySqlString &= "la.DRTotDue, "
            MySqlString &= "la.JRCIOOffC1, "
            MySqlString &= "la.IOCommTot, "
            MySqlString &= "la.IOOffL1, "
            MySqlString &= "la.IOComm3, "
            MySqlString &= "la.JRCOffComm, "
            MySqlString &= "la.JRCTotal, "
            MySqlString &= "la.OCommPlus, "
            MySqlString &= "x.CustomerNumber, "
            MySqlString &= "cn.CustomerName, "
            MySqlString &= "x.JRCIOfficeCode, "
            'MySqlString &= "x.DispatchCode , "
            'MySqlString &= "'DispatchCode' = dm.DispatchName, "
            MySqlString &= "'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN x.DispatchCode ELSE dm.DispatchName END, "
            MySqlString &= "x.XMissionDate "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "



            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                    '    Case "OO"
                    '        strSearchOn = "oo.DriverName "
                    '    Case "IO"
                    '        strSearchOn = "io.IOName "
                    '    Case "BK"
                    '        strSearchOn = "bk.BrokerName "
                    '    Case "LI"
                    '        strSearchOn = "x.LoadId "
                    '    Case "PO"
                    '        strSearchOn = "x.CustPO "
                    '    Case "PJ"
                    '        strSearchOn = "x.ProJob "
                    '    Case "PC"
                    '        strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            'If JRCIOfficeCode = "999999999" Then
            '    MySqlString &= "WHERE (x.JRCIOfficeCode LIKE '%%') "
            'Else
            '    MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            'End If
            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            If JRCIOfficeCode = "999999999" Then
                If LoadStatus = "" Then
                    MySqlString &= "WHERE ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
                    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
                Else
                    MySqlString &= "WHERE (x.LoadStatus = '" & LoadStatus & "') "
                End If
            Else
                MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                If LoadStatus = "" Then
                    MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
                    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
                Else
                    MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
                End If
            End If

            
            If CustomerNumber <> "" Then
                MySqlString &= "AND (cn.CustomerNumber = '" & CustomerNumber & "') "
            End If


            Select Case SearchOn.ToUpper
                '    Case "OO", "IO", "BK"
                '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
                '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                '        MySqlString &= DateFilter
                '        MySqlString &= ScopeFilter
                '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "CN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                    'Case "LI", "PO", "PJ", "PC"
                    '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    '    MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                    '    MySqlString &= DateFilter
                    '    MySqlString &= ScopeFilter
                    '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
                    MySqlString &= ") "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            End Select
            MySqlString &= "ORDER BY x.JRCIOfficeCode, x.LoadDate desc, x.LoadId "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            'Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            'BBaseLoadTotal = 0
            'If Not dr Is Nothing Then
            '    While dr.Read
            '        Dim _BBaseLoad As Decimal = Convert.ToDecimal(Null.SetNull(dr.Item("BBaseLoad"), _BBaseLoad))
            '        If Not Null.IsNull(_BBaseLoad) Then    BBaseLoadTotal += _BBaseLoad

            '    End While
            'End If

            Dim dt As New DataTable
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

            Dim dtr As DataRow
            ' TotalRecords = dt.Rows.Count
            BBaseLoadTotal = 0
            RepDlrTotal = 0
            DRTotDueTotal = 0
            IOCommTotTotal = 0
            IOComm3Total = 0
            JRCOffCommTotal = 0
            JRCTotalTotal = 0

            For Each dtr In dt.Rows
                Dim _BBaseLoad As Decimal = Convert.ToDecimal(Null.SetNull(dtr("BBaseLoad"), _BBaseLoad))
                If Not Null.IsNull(_BBaseLoad) Then BBaseLoadTotal += _BBaseLoad

                Dim _RepDlr As Decimal = Convert.ToDecimal(Null.SetNull(dtr("RepDlr"), _RepDlr))
                If Not Null.IsNull(_RepDlr) Then RepDlrTotal += _RepDlr

                Dim _DRTotDue As Decimal = Convert.ToDecimal(Null.SetNull(dtr("DRTotDue"), _DRTotDue))
                If Not Null.IsNull(_DRTotDue) Then DRTotDueTotal += _DRTotDue

                Dim _IOCommTot As Decimal = Convert.ToDecimal(Null.SetNull(dtr("IOCommTot"), _IOCommTot))
                If Not Null.IsNull(_IOCommTot) Then IOCommTotTotal += _IOCommTot

                Dim _IOComm3 As Decimal = Convert.ToDecimal(Null.SetNull(dtr("IOComm3"), _IOComm3))
                If Not Null.IsNull(_IOComm3) Then IOComm3Total += _IOComm3

                Dim _JRCOffComm As Decimal = Convert.ToDecimal(Null.SetNull(dtr("JRCOffComm"), _JRCOffComm))
                If Not Null.IsNull(_JRCOffComm) Then JRCOffCommTotal += _JRCOffComm

                Dim _JRCTotal As Decimal = Convert.ToDecimal(Null.SetNull(dtr("JRCTotal"), _JRCTotal))
                If Not Null.IsNull(_JRCTotal) Then JRCTotalTotal += _JRCTotal
            Next

            If SortDesc Then
                dt.DefaultView.Sort = SortOn & " DESC"
            Else
                dt.DefaultView.Sort = SortOn
            End If

            'dt.DefaultView.Sort = "LoadDate desc, JRCIOfficeCode, LoadId"

            Return dt.DefaultView.ToTable

        End Function

        Public Function GetReport1Totals(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'DataTable '
            'Public Function GetReport1() As DataTable 'IDataReader '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            'MySqlString &= "x.* "
            'MySqlString &= "x.ItemId, "
            'MySqlString &= "x.LoadID, "
            'MySqlString &= "x.LoadDate, "
            MySqlString &= "'BBaseLoadTotal'=Sum(la.BBaseLoad), "
            MySqlString &= "'RepDlrTotal'=Sum(la.RepDlr), "
            MySqlString &= "'DRTotDueTotal'=Sum(la.DRTotDue), "
            'MySqlString &= "'JRCIOOffC1Total'=Sum(la.JRCIOOffC1), "
            MySqlString &= "'IOCommTotTotal'=Sum(la.IOCommTot), "
            'MySqlString &= "'IOOffL1Total'=Sum(la.IOOffL1), "
            MySqlString &= "'IOComm3Total'=Sum(la.IOComm3), "
            MySqlString &= "'JRCOffCommTotal'=Sum(la.JRCOffComm), "
            MySqlString &= "'JRCTotalTotal'=Sum(la.JRCTotal) "
            'MySqlString &= "x.CustomerNumber, "
            'MySqlString &= "cn.CustomerName, "
            'MySqlString &= "x.JRCIOfficeCode "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "



            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                    '    Case "OO"
                    '        strSearchOn = "oo.DriverName "
                    '    Case "IO"
                    '        strSearchOn = "io.IOName "
                    '    Case "BK"
                    '        strSearchOn = "bk.BrokerName "
                    '    Case "LI"
                    '        strSearchOn = "x.LoadId "
                    '    Case "PO"
                    '        strSearchOn = "x.CustPO "
                    '    Case "PJ"
                    '        strSearchOn = "x.ProJob "
                    '    Case "PC"
                    '        strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "


            Select Case SearchOn.ToUpper
                '    Case "OO", "IO", "BK"
                '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
                '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                '        MySqlString &= DateFilter
                '        MySqlString &= ScopeFilter
                '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "CN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                    'Case "LI", "PO", "PJ", "PC"
                    '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    '    MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                    '    MySqlString &= DateFilter
                    '    MySqlString &= ScopeFilter
                    '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
                    MySqlString &= ") "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            End Select
            'MySqlString &= "ORDER BY x.LoadDate desc, x.JRCIOfficeCode, x.LoadId "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            'Dim dt As New DataTable
            'dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))
            'Return dt
        End Function

        'Public Function GetReport2Driver(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal LoadType As String = "OO", Optional ByVal CarrierCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
        '    'Public Function GetReport2() As DataTable 'IDataReader '
        '    Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
        '    Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
        '    Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
        '    If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
        '        MyOjectQualifier &= "_"
        '    End If

        '    'Set Scope for Module, Portal or All
        '    Dim ScopeFilter As String = ""


        '    Select Case GetItems
        '        Case 0
        '            If ModuleId > -1 Then
        '                ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
        '            End If
        '        Case 1
        '            If PortalId > -1 Then
        '                ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
        '            End If
        '        Case 2
        '            'Do Nothing
        '        Case Else '0
        '            If PortalId > -1 Then
        '                ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
        '            ElseIf ModuleId > -1 Then
        '                ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
        '            End If
        '    End Select

        '    Dim strSearchText As String
        '    If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

        '    Dim DateFilter As String = ""
        '    Dim DateTo As Date = Now
        '    If ToDate <> "" Then
        '        Try
        '            DateTo = Date.Parse(ToDate)
        '        Catch
        '            DateTo = Now
        '        End Try
        '    End If
        '    Dim DateFrom As Date = #1/1/1947#
        '    If FromDate <> "" Then
        '        Try
        '            DateFrom = Date.Parse(FromDate)
        '        Catch
        '            DateFrom = #1/1/1947#
        '        End Try
        '    End If

        '    If DateFrom > DateTo Then
        '        Dim tDate As Date = DateFrom
        '        DateFrom = DateTo
        '        DateTo = tDate
        '    End If

        '    If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
        '    If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

        '    Dim MySqlString As String = String.Empty
        '    MySqlString &= "SELECT "
        '    If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
        '    ' MySqlString &= "x.* "
        '    MySqlString &= "x.ItemId, "
        '    MySqlString &= "x.LoadID, "
        '    MySqlString &= "x.LoadDate, "
        '    MySqlString &= "x.DeliveryDate, "
        '    MySqlString &= "x.CustomerNumber, "
        '    MySqlString &= "cn.CustomerName, "
        '    MySqlString &= "x.CarrierName, "
        '    MySqlString &= "x.LoadMileage, "
        '    MySqlString &= "la.DRTotDue, "
        '    MySqlString &= "la.ExTot, "
        '    MySqlString &= "la.CalcRate, "
        '    MySqlString &= "x.ComCheckSeq, "
        '    MySqlString &= "x.ComCheckAmt, "
        '    MySqlString &= "x.PUCityST, "
        '    MySqlString &= "x.DPCityST, "
        '    MySqlString &= "oo.DriverCode, "
        '    MySqlString &= "oo.City, "
        '    MySqlString &= "oo.State, "
        '    MySqlString &= "oo.Status "

        '    MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
        '    'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
        '    'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile As oo ON x.DriverCode=oo.DriverCode "
        '    MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "


        '    Dim strSearchOn As String
        '    Select Case SearchOn.ToUpper
        '        Case "CN"
        '            strSearchOn = "cn.CustomerName "
        '        Case "DCODE"
        '            strSearchOn = "oo.DriverCode "
        '        Case "DCITY"
        '            strSearchOn = "oo.City "
        '        Case "DSTATE"
        '            strSearchOn = "oo.State "
        '        Case "DSTATUS"
        '            strSearchOn = "oo.Status "
        '            'Case "BN"
        '            '    strSearchOn = "bk.BrokerName "
        '            'Case "PO"
        '            '    strSearchOn = "x.CustPO "
        '            '    Case "PJ"
        '            '        strSearchOn = "x.ProJob "
        '            '    Case "PC"
        '            '        strSearchOn = "x.PUCityST "
        '        Case Else '"Any"
        '            strSearchOn = "Any"
        '    End Select

        '    MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '    MySqlString &= "AND (x.LoadType = '" & LoadType.ToUpper & "') "

        '    If CarrierCode <> "" Then
        '        'If LoadType.ToUpper = "OO" Then
        '        '    '    MySqlString &= "AND (x.BrokerCode = '" & CarrierCode & "') "
        '        '    'Else
        '        'End If
        '        MySqlString &= "AND (x.DriverCode = '" & CarrierCode & "') "
        '    End If

        '    Select Case SearchOn.ToUpper
        '        '    Case "OO", "IO", "BK"
        '        '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '        '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
        '        '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
        '        '        MySqlString &= DateFilter
        '        '        MySqlString &= ScopeFilter
        '        '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '        '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

        '        Case "CN"
        '            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
        '            MySqlString &= DateFilter
        '            MySqlString &= ScopeFilter
        '            'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '            'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
        '        Case "CN"
        '            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
        '            MySqlString &= DateFilter
        '            MySqlString &= ScopeFilter
        '            'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '            'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
        '            'Case "DN"
        '            '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            '    MySqlString &= "AND ((x.DriverCode LIKE '%" & SearchText & "%') OR (oo.DriverName LIKE '" & strSearchText & "')) "
        '            '    MySqlString &= DateFilter
        '            '    MySqlString &= ScopeFilter
        '            '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '            '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

        '        Case "BN"
        '            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            MySqlString &= "AND ((x.brokerCode LIKE '%" & SearchText & "%') OR (bk.BrokerName LIKE '" & strSearchText & "')) "
        '            MySqlString &= DateFilter
        '            MySqlString &= ScopeFilter
        '            'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '            'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "


        '        Case Else '"ANY"
        '            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '            MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
        '            MySqlString &= "OR (oo.DriverCode LIKE '" & strSearchText & "') "
        '            MySqlString &= "OR (oo.City LIKE '" & strSearchText & "') "
        '            MySqlString &= "OR (oo.State LIKE '" & strSearchText & "') "
        '            MySqlString &= "OR (oo.Status LIKE '" & strSearchText & "') "
        '            MySqlString &= ") "
        '            MySqlString &= DateFilter
        '            MySqlString &= ScopeFilter
        '            '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
        '    End Select
        '    MySqlString &= "ORDER BY x.LoadDate desc, x.JRCIOfficeCode, x.LoadId "

        '    'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
        '    'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)


        '    Dim dt As New DataTable
        '    dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

        '    Dim dtr As DataRow
        '    '  TotalRecords = dt.Rows.Count
        '    LoadMileageTotal = 0
        '    DRTotDueTotal = 0
        '    ExTotTotal = 0
        '    ComCheckAmtTotal = 0


        '    For Each dtr In dt.Rows
        '        Dim _LoadMileage As Integer = Convert.ToInt64(Null.SetNull(dtr("LoadMileage"), _LoadMileage))
        '        If Not Null.IsNull(_LoadMileage) Then LoadMileageTotal += _LoadMileage

        '        Dim _DRTotDue As Decimal = Convert.ToDecimal(Null.SetNull(dtr("DRTotDue"), _DRTotDue))
        '        If Not Null.IsNull(_DRTotDue) Then DRTotDueTotal += _DRTotDue

        '        Dim _ExTot As Decimal = Convert.ToDecimal(Null.SetNull(dtr("ExTot"), _ExTot))
        '        If Not Null.IsNull(_ExTot) Then ExTotTotal += _ExTot

        '        Dim _ComCheckAmt As Decimal = Convert.ToDecimal(Null.SetNull(dtr("ComCheckAmt"), _ComCheckAmt))
        '        If Not Null.IsNull(_ComCheckAmt) Then ComCheckAmtTotal += _ComCheckAmt

        '    Next

        '    Return dt

        'End Function

        Public Function GetReport2Driver(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal Status As String = "N", Optional ByVal LoadType As String = "OO", Optional ByVal CarrierCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
            'Public Function GetReport2() As DataTable 'IDataReader '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""
            Dim StatusFilter As String = ""


            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If LoadStatus.ToUpper = "COMPLETE" Then
                If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            Else
                If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            End If

            'If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            'If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Select Case Status.ToUpper
                Case "Y"
                    StatusFilter = "AND (oo.Status='Y') "
                Case "N"
                    StatusFilter = "AND (oo.Status='N') "
            End Select


            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            ' MySqlString &= "x.* "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.LoadStatus, "
            MySqlString &= "oo.Status, "
            MySqlString &= "x.LoadID, "
            MySqlString &= "x.LoadDate, "
            MySqlString &= "x.DeliveryDate, "
            MySqlString &= "x.CustomerNumber, "
            MySqlString &= "cn.CustomerName, "
            MySqlString &= "'CarrierName'=oo.DriverName, "
            'MySqlString &= "x.LoadMileage, "
            MySqlString &= "'LoadMileage'=la.CalcMI, "
            MySqlString &= "la.DRTotDue, "
            MySqlString &= "la.ExTot, "
            MySqlString &= "la.CalcRate, "
            MySqlString &= "x.ComCheckSeq, "
            MySqlString &= "x.ComCheckAmt, "
            MySqlString &= "x.PUCityST, "
            MySqlString &= "x.DPCityST, "
            'MySqlString &= "x.DispatchCode , "
            'MySqlString &= "'DispatchCode' = dm.DispatchName, "
            MySqlString &= "'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN x.DispatchCode ELSE dm.DispatchName END, "
            MySqlString &= "x.XMissionDate "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile As oo ON x.DriverCode=oo.DriverCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "


            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                Case "DN"
                    strSearchOn = "oo.DriverName "
                    'Case "BN"
                    '    strSearchOn = "bk.BrokerName "
                    'Case "PO"
                    '    strSearchOn = "x.CustPO "
                    '    Case "PJ"
                    '        strSearchOn = "x.ProJob "
                    '    Case "PC"
                    '        strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            If JRCIOfficeCode = "999999999" Then
                MySqlString &= "WHERE (x.LoadType = '" & LoadType.ToUpper & "') "
            Else
                MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                MySqlString &= "AND (x.LoadType = '" & LoadType.ToUpper & "') "
            End If
            If LoadStatus = "" Then
                MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
                'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
            Else
                MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
            End If

            If CarrierCode <> "" Then
                'If LoadType.ToUpper = "OO" Then
                '    '    MySqlString &= "AND (x.BrokerCode = '" & CarrierCode & "') "
                '    'Else
                'End If
                MySqlString &= "AND (x.DriverCode = '" & CarrierCode & "') "
            End If
            If CustomerNumber <> "" Then
                MySqlString &= "AND (cn.CustomerNumber = '" & CustomerNumber & "') "
            End If

            Select Case SearchOn.ToUpper
                '    Case "OO", "IO", "BK"
                '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
                '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                '        MySqlString &= DateFilter
                '        MySqlString &= ScopeFilter
                '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "CN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    MySqlString &= StatusFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                    'Case "DN"
                    '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    '    MySqlString &= "AND ((x.DriverCode LIKE '%" & SearchText & "%') OR (oo.DriverName LIKE '" & strSearchText & "')) "
                    '    MySqlString &= DateFilter
                    '    MySqlString &= ScopeFilter
                    '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "BN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.brokerCode LIKE '%" & SearchText & "%') OR (bk.BrokerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    MySqlString &= StatusFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "


                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
                    MySqlString &= ") "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    MySqlString &= StatusFilter
                    '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            End Select
            MySqlString &= "ORDER BY x.JRCIOfficeCode, x.LoadId desc, x.LoadDate desc "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)


            Dim dt As New DataTable
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

            Dim dtr As DataRow
            'TotalRecords = dt.Rows.Count
            LoadMileageTotal = 0
            DRTotDueTotal = 0
            ExTotTotal = 0
            ComCheckAmtTotal = 0


            For Each dtr In dt.Rows
                Dim _LoadMileage As Integer = Convert.ToInt64(Null.SetNull(dtr("LoadMileage"), _LoadMileage))
                If Not Null.IsNull(_LoadMileage) Then LoadMileageTotal += _LoadMileage

                Dim _DRTotDue As Decimal = Convert.ToDecimal(Null.SetNull(dtr("DRTotDue"), _DRTotDue))
                If Not Null.IsNull(_DRTotDue) Then DRTotDueTotal += _DRTotDue

                Dim _ExTot As Decimal = Convert.ToDecimal(Null.SetNull(dtr("ExTot"), _ExTot))
                If Not Null.IsNull(_ExTot) Then ExTotTotal += _ExTot

                Dim _ComCheckAmt As Decimal = Convert.ToDecimal(Null.SetNull(dtr("ComCheckAmt"), _ComCheckAmt))
                If Not Null.IsNull(_ComCheckAmt) Then ComCheckAmtTotal += _ComCheckAmt

            Next

            Return dt

        End Function

        Public Function GetReport2Broker(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal Status As String = "N", Optional ByVal LoadType As String = "BK", Optional ByVal CarrierCode As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
            'Public Function GetReport2() As DataTable 'IDataReader '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""
            Dim StatusFilter As String = ""


            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If LoadStatus.ToUpper = "COMPLETE" Then
                If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            Else
                If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            End If
            'If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            'If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Select Case Status.ToUpper
                Case "Y"
                    StatusFilter = "AND (bk.BStatus='INACTIVE') "
                Case "N"
                    StatusFilter = "AND (bk.BStatus='ACTIVE') "
            End Select

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            ' MySqlString &= "x.* "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.LoadStatus, "
            MySqlString &= "bk.BStatus, "
            MySqlString &= "x.LoadID, "
            MySqlString &= "x.LoadDate, "
            MySqlString &= "x.DeliveryDate, "
            MySqlString &= "x.CustomerNumber, "
            MySqlString &= "cn.CustomerName, "
            MySqlString &= "'CarrierName'=bk.BrokerName, "
            'MySqlString &= "x.LoadMileage, "
            MySqlString &= "'LoadMileage'=la.CalcMI, "
            MySqlString &= "la.DRTotDue, "
            MySqlString &= "la.ExTot, "
            MySqlString &= "la.CalcRate, "
            MySqlString &= "x.ComCheckSeq, "
            MySqlString &= "x.ComCheckAmt, "
            MySqlString &= "x.PUCityST, "
            MySqlString &= "x.DPCityST, "
            'MySqlString &= "x.DispatchCode , "
            'MySqlString &= "'DispatchCode' = dm.DispatchName, "
            MySqlString &= "'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN x.DispatchCode ELSE dm.DispatchName END, "
            MySqlString &= "x.XMissionDate "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile As oo ON x.DriverCode=oo.DriverCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "


            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                    'Case "DN"
                    '    strSearchOn = "oo.DriverName "
                Case "BN"
                    strSearchOn = "bk.BrokerName "
                    'Case "PO"
                    '    strSearchOn = "x.CustPO "
                    '    Case "PJ"
                    '        strSearchOn = "x.ProJob "
                    '    Case "PC"
                    '        strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            If JRCIOfficeCode = "999999999" Then
                MySqlString &= "WHERE (x.LoadType = '" & LoadType.ToUpper & "') "
            Else
                MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                MySqlString &= "AND (x.LoadType = '" & LoadType.ToUpper & "') "
            End If
            If LoadStatus = "" Then
                MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
                'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
            Else
                MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
            End If

            If CarrierCode <> "" Then
                'If LoadType.ToUpper = "BK" Then
                '    'Else
                '    '    MySqlString &= "AND (x.DriverCode = '" & CarrierCode & "') "
                'End If
                MySqlString &= "AND (x.BrokerCode = '" & CarrierCode & "') "
            End If

            If CustomerNumber <> "" Then
                MySqlString &= "AND (cn.CustomerNumber = '" & CustomerNumber & "') "
            End If

            Select Case SearchOn.ToUpper
                '    Case "OO", "IO", "BK"
                '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
                '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                '        MySqlString &= DateFilter
                '        MySqlString &= ScopeFilter
                '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "CN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    MySqlString &= StatusFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                    'Case "DN"
                    '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    '    MySqlString &= "AND ((x.DriverCode LIKE '%" & SearchText & "%') OR (oo.DriverName LIKE '" & strSearchText & "')) "
                    '    MySqlString &= DateFilter
                    '    MySqlString &= ScopeFilter
                    '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "BN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.brokerCode LIKE '%" & SearchText & "%') OR (bk.BrokerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    MySqlString &= StatusFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "


                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
                    MySqlString &= ") "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    MySqlString &= StatusFilter
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            End Select
            MySqlString &= "ORDER BY x.JRCIOfficeCode, x.LoadId desc, x.LoadDate desc "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)


            Dim dt As New DataTable
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

            Dim dtr As DataRow
            'TotalRecords = dt.Rows.Count
            LoadMileageTotal = 0
            DRTotDueTotal = 0
            ExTotTotal = 0
            ComCheckAmtTotal = 0


            For Each dtr In dt.Rows
                Dim _LoadMileage As Integer = Convert.ToInt32(Null.SetNull(dtr("LoadMileage"), _LoadMileage))
                If Not Null.IsNull(_LoadMileage) Then LoadMileageTotal += _LoadMileage

                Dim _DRTotDue As Decimal = Convert.ToDecimal(Null.SetNull(dtr("DRTotDue"), _DRTotDue))
                If Not Null.IsNull(_DRTotDue) Then DRTotDueTotal += _DRTotDue

                Dim _ExTot As Decimal = Convert.ToDecimal(Null.SetNull(dtr("ExTot"), _ExTot))
                If Not Null.IsNull(_ExTot) Then ExTotTotal += _ExTot

                Dim _ComCheckAmt As Decimal = Convert.ToDecimal(Null.SetNull(dtr("ComCheckAmt"), _ComCheckAmt))
                If Not Null.IsNull(_ComCheckAmt) Then ComCheckAmtTotal += _ComCheckAmt

            Next

            Return dt

        End Function

        Public Function GetReport2Totals(ByVal JRCIOfficeCode As String, ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As IDataReader 'DataTable '
            'Public Function GetReport2() As DataTable 'IDataReader '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            ' MySqlString &= "x.* "
            'MySqlString &= "x.ItemId, "
            'MySqlString &= "x.LoadID, "
            'MySqlString &= "x.LoadDate, "
            'MySqlString &= "x.DeliveryDate, "
            'MySqlString &= "x.CustomerNumber, "
            'MySqlString &= "cn.CustomerName, "
            'MySqlString &= "x.CarrierName, "
            MySqlString &= "'LoadMileageTotal'=Sum(x.LoadMileage), "
            MySqlString &= "'DRTotDueTotal'=Sum(la.DRTotDue), "
            MySqlString &= "'ExTotTotal'=Sum(la.ExTot), "
            'MySqlString &= "'CalcRateTotal'=Sum(la.CalcRate), "
            'MySqlString &= "Sum(x.ComCheckSeq), "
            MySqlString &= "'ComCheckAmtTotal'=Sum(x.ComCheckAmt) "
            'MySqlString &= "x.PUCityST, "
            'MySqlString &= "x.DPCityST "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile As oo ON x.DriverCode=oo.DriverCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "


            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                Case "DN"
                    strSearchOn = "oo.DriverName "
                Case "BN"
                    strSearchOn = "bk.BrokerName "
                    'Case "PO"
                    '    strSearchOn = "x.CustPO "
                    '    Case "PJ"
                    '        strSearchOn = "x.ProJob "
                    '    Case "PC"
                    '        strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "


            Select Case SearchOn.ToUpper
                '    Case "OO", "IO", "BK"
                '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
                '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                '        MySqlString &= DateFilter
                '        MySqlString &= ScopeFilter
                '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "CN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "DN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((oo.DriverCode LIKE '%" & SearchText & "%') OR (oo.DriverName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "BN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((bk.brokerCode LIKE '%" & SearchText & "%') OR (bk.BrokerName LIKE '" & strSearchText & "')) "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "


                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
                    MySqlString &= ") "
                    MySqlString &= DateFilter
                    MySqlString &= ScopeFilter
                    '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            End Select
            'MySqlString &= "ORDER BY x.LoadDate desc, x.JRCIOfficeCode, x.LoadId "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            'Dim dt As New DataTable
            'dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))
            'Return dt

        End Function

        Public Function GetReport3(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal LoadStatus As String = "", Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
            'Public Function GetReport3() As DataTable 'IDataReader '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If LoadStatus.ToUpper = "COMPLETE" Then
                If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            Else
                If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
                If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            End If

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            ' MySqlString &= "x.* "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.LoadStatus, "
            MySqlString &= "x.LoadID, "
            MySqlString &= "x.LoadDate, "
            MySqlString &= "x.XMissionDate, "
            MySqlString &= "x.DeliveryDate, "
            MySqlString &= "x.CustomerNumber, "
            MySqlString &= "cn.CustomerName, "
            'MySqlString &= "x.CarrierName, "
            MySqlString &= "'CarrierName' = CASE WHEN (x.LoadType='BK') THEN bk.BrokerName ELSE sp.DriverName END, "
            MySqlString &= "x.CustPO, "
            MySqlString &= "x.ProJob, "
            MySqlString &= "x.PUCityST, "
            MySqlString &= "x.DPCityST, "
            'MySqlString &= "x.DispatchCode, "
            MySqlString &= "'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN x.DispatchCode ELSE dm.DispatchName END, "
            MySqlString &= "x.JRCIOfficeCode "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS sp on x.DriverCode = sp.DriverCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "


            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                Case "PO"
                    strSearchOn = "x.CustPO "
                Case "PJ"
                    strSearchOn = "x.ProJob "
                    '    Case "BK"
                    '        strSearchOn = "bk.BrokerName "
                    '    Case "LI"
                    '        strSearchOn = "x.LoadId "
                    '    Case "PO"
                    '        strSearchOn = "x.CustPO "
                    '    Case "PJ"
                    '        strSearchOn = "x.ProJob "
                    '    Case "PC"
                    '        strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            'If LoadStatus = "" Then
            '    MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
            '    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
            'Else
            '    MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
            'End If
            If JRCIOfficeCode = "999999999" Then
                If LoadStatus = "" Then
                    MySqlString &= "WHERE ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
                    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
                Else
                    MySqlString &= "WHERE (x.LoadStatus = '" & LoadStatus & "') "
                End If
            Else
                MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                If LoadStatus = "" Then
                    MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
                    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
                Else
                    MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
                End If
            End If
            If CustomerNumber <> "" Then
                MySqlString &= "AND (cn.CustomerNumber = '" & CustomerNumber & "') "
            End If

            Select Case SearchOn.ToUpper
                '    Case "OO", "IO", "BK"
                '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
                '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                '        MySqlString &= DateFilter
                '        MySqlString &= ScopeFilter
                '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "CN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "LI", "PO", "PJ" ', "PC"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
                    MySqlString &= ") "
                    '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            End Select
            MySqlString &= DateFilter
            MySqlString &= ScopeFilter
            MySqlString &= "ORDER BY x.LoadDate desc, x.JRCIOfficeCode, x.LoadId "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            Dim dt As New DataTable
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

            ' TotalRecords = dt.Rows.Count
            Return dt
        End Function

        ' Public Function GetReportDriverStatus(ByVal JRCIOfficeCode As String, ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
        Public Function GetReportDriverStatus(ByVal JRCIOfficeCode As String, Optional ByVal SortOn As String = "DriverName", Optional ByVal SortDesc As Boolean = False, Optional ByVal DriverType As String = "Any", Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal GetItems As Integer = 0) As DataTable 'DataView 'IDataReader '
            'Public Function GetReportDriverStatus() As DataTable 'IDataReader '
            Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
            Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
            Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
            If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
                MyOjectQualifier &= "_"
            End If

            'Set Scope for Module, Portal or All
            Dim ScopeFilter As String = ""


            'Select Case GetItems
            '    Case 0
            '        If ModuleId > -1 Then
            '            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
            '        End If
            '    Case 1
            '        If PortalId > -1 Then
            '            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
            '        End If
            '    Case 2
            '        'Do Nothing
            '    Case Else '0
            '        If PortalId > -1 Then
            '            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
            '        ElseIf ModuleId > -1 Then
            '            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
            '        End If
            'End Select

            'Dim strSearchText As String
            'If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

            Dim DateFilter As String = ""
            Dim FromDateFilter As String = ""
            Dim ToDateFilter As String = ""
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

            If FromDate <> "" Then FromDateFilter &= " (x.LastLoad >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then ToDateFilter &= " (x.LastLoad <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            If (FromDateFilter <> "") OrElse (ToDateFilter <> "") Then
                If (FromDateFilter <> "") Then
                    DateFilter = "WHERE " & FromDateFilter
                    If (ToDateFilter <> "") Then
                        DateFilter &= "AND " & ToDateFilter
                    End If
                Else
                    DateFilter = "WHERE " & ToDateFilter
                End If
            End If

            Dim sbSql As New StringBuilder
            sbSql.Append("SELECT ")
            If NoOfItems > 0 Then sbSql.Append("TOP " & NoOfItems.ToString & " ")
            'MySqlString &= "x.* "
            sbSql.Append("x.ItemId, ")
            sbSql.Append("x.DriverCode, ")
            sbSql.Append("x.DriverName, ")
            sbSql.Append("x.AccountNo, ")
            sbSql.Append("ls.LoadStatus, ")
            sbSql.Append("ls.LoadType, ")
            sbSql.Append("'LoadItemId'=ls.ItemId, ")
            sbSql.Append("x.LastLoadID, ")
            sbSql.Append("x.LastLoad, ")
            sbSql.Append("x.LastPU, ")
            sbSql.Append("x.LastDP, ")
            sbSql.Append("x.CellPhone, ")
            sbSql.Append("'BrokerCodeD'=Null, ")
            sbSql.Append("x.OfficeOwner, ")

            sbSql.Append("ls.DispatchCode, ")
            'sbSql.Append("'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN ls.DispatchCode ELSE dm.DispatchName END, ")
            sbSql.Append("ls.XMissionDate ")

            sbSql.Append("FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x ")
            sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "tblOOLoadSheetHeader AS ls ON x.LastLoadId = ls.LoadId ")
            'sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON ls.DispatchCode=dm.DispatchCode ")

            sbSql.Append("WHERE (x.Status='N') ")

            'MySqlString &= DateFilter
            If JRCIOfficeCode <> "" AndAlso JRCIOfficeCode <> "000000000" Then
                sbSql.Append("AND (x.OfficeOwner = '" & JRCIOfficeCode & "') ")
            End If

            sbSql.Append("ORDER BY x.OfficeOwner, x.DriverName, x.LastLoad desc ")

            Dim drSP As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)


            Dim sbSqlBkr As New StringBuilder
            sbSqlBkr.Append("SELECT ")
            If NoOfItems > 0 Then sbSqlBkr.Append("TOP " & NoOfItems.ToString & " ")
            'MySqlString &= "x.* "
            sbSqlBkr.Append("x.ItemId, ")
            sbSqlBkr.Append("x.DriverCode, ")
            sbSqlBkr.Append("x.DriverName, ")
            sbSqlBkr.Append("x.AccountNo, ")
            sbSqlBkr.Append("ls.LoadStatus, ")
            sbSqlBkr.Append("ls.LoadType, ")
            sbSqlBkr.Append("'LoadItemId'=ls.ItemId, ")
            sbSqlBkr.Append("x.LastLoadID, ")
            sbSqlBkr.Append("x.LastLoad, ")
            sbSqlBkr.Append("x.LastPU, ")
            sbSqlBkr.Append("x.LastDP, ")
            sbSqlBkr.Append("x.CellPhone, ")
            sbSqlBkr.Append("x.BrokerCodeD, ")
            sbSqlBkr.Append("x.OfficeOwner, ")

            sbSqlBkr.Append("ls.DispatchCode, ")
            'sbSqlBkr.Append("'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN ls.DispatchCode ELSE dm.DispatchName END, ")
            sbSqlBkr.Append("ls.XMissionDate ")

            sbSqlBkr.Append("FROM " & MyOjectQualifier & "BKR_SalesPersonMasterfile AS x ")
            sbSqlBkr.Append("LEFT OUTER JOIN " & MyOjectQualifier & "tblOOLoadSheetHeader AS ls ON x.LastLoadId = ls.LoadId ")
            'sbSqlBkr.Append("LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON ls.DispatchCode=dm.DispatchCode ")

            sbSqlBkr.Append("WHERE (x.Status='N') ")

            'MySqlString &= DateFilter
            If JRCIOfficeCode <> "" AndAlso JRCIOfficeCode <> "000000000" Then
                sbSqlBkr.Append("AND (x.OfficeOwner = '" & JRCIOfficeCode & "') ")
            End If

            sbSqlBkr.Append("ORDER BY x.OfficeOwner, x.DriverName, x.LastLoad desc ")



            Dim drBkrSP As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSqlBkr.ToString)


            'Dim strSearchOn As String
            'Select Case SearchOn.ToUpper
            '    'Case "CN"
            '    '    strSearchOn = "cn.CustomerName "
            '    Case "OO"
            '        strSearchOn = "x.DriverName "
            '        '    Case "IO"
            '        '        strSearchOn = "io.IOName "
            '        'Case "BK"
            '        '    strSearchOn = "x.BrokerName "
            '        '    Case "LI"
            '        '        strSearchOn = "x.LoadId "
            '        '    Case "PO"
            '        '        strSearchOn = "x.CustPO "
            '        '    Case "PJ"
            '        '        strSearchOn = "x.ProJob "
            '        '    Case "PC"
            '        '        strSearchOn = "x.PUCityST "
            '    Case Else '"Any"
            '        strSearchOn = "Any"
            'End Select

            '  MySqlString &= "WHERE (x.OfficeOwner = '" & JRCIOfficeCode & "') "


            'Select Case SearchOn.ToUpper
            '    Case "OO" ', "IO", "BK"
            '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '        'MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
            '        'MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
            '        MySqlString &= "AND ((x.DriverCode LIKE '%" & SearchText & "%') OR (x.DriverName LIKE '" & strSearchText & "')) "
            '        MySqlString &= DateFilter
            '        MySqlString &= ScopeFilter
            '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
            '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            '        MySqlString &= "ORDER BY x.LastLoad desc, x.LastLoadId "

            '        'Case "CN"
            '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '        'MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
            '        'MySqlString &= DateFilter
            '        'MySqlString &= ScopeFilter
            '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
            '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

            '        'Case "LI", "PO", "PJ", "PC"
            '        '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '        '    MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
            '        '    MySqlString &= DateFilter
            '        '    MySqlString &= ScopeFilter
            '        '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
            '        '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

            '    Case Else '"ANY"
            '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '        'MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
            '        MySqlString &= "OR (x.DriverName LIKE '" & strSearchText & "') "
            '        'MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
            '        'MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
            '        'MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
            '        'MySqlString &= ") "
            '        'MySqlString &= DateFilter
            '        'MySqlString &= ScopeFilter
            '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            'End Select
            'MySqlString &= "ORDER BY x.LastLoad desc, x.JRCIOfficeCode, x.LastLoadId "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            'Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)


            Dim dt As New DataTable
            If DriverType <> "BK" Then
                dt.Load(drSP)
            End If
            If DriverType <> "OO" Then
                dt.Load(drBkrSP)
            End If

            For Each dtr As DataRow In dt.Rows
                If Null.IsNull(dtr("LoadItemId")) Then dtr("LoadItemId") = 0
                dtr("CellPhone") = Phone.FormatPhoneNo(dtr("CellPhone").ToString)
            Next

            If SortDesc Then
                dt.DefaultView.Sort = SortOn & " DESC"
            Else
                dt.DefaultView.Sort = SortOn
            End If

            Return dt.DefaultView.ToTable
        End Function

        'Public Function GetReportDriverStatusRV(ByVal JRCIOfficeCode As String, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal GetItems As Integer = 0, Optional ByVal DriverType As String = "Any") As DataTable 'DataView 'IDataReader '
        '    'Public Function GetReportDriverStatus() As DataTable 'IDataReader '
        '    Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data")
        '    Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers(_providerConfiguration.DefaultProvider), Framework.Providers.Provider)
        '    Dim MyOjectQualifier As String = objProvider.Attributes("objectQualifier")
        '    If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then
        '        MyOjectQualifier &= "_"
        '    End If

        '    'Set Scope for Module, Portal or All
        '    Dim ScopeFilter As String = ""


        '    'Select Case GetItems
        '    '    Case 0
        '    '        If ModuleId > -1 Then
        '    '            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
        '    '        End If
        '    '    Case 1
        '    '        If PortalId > -1 Then
        '    '            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
        '    '        End If
        '    '    Case 2
        '    '        'Do Nothing
        '    '    Case Else '0
        '    '        If PortalId > -1 Then
        '    '            ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
        '    '        ElseIf ModuleId > -1 Then
        '    '            ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
        '    '        End If
        '    'End Select

        '    'Dim strSearchText As String
        '    'If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

        '    Dim DateFilter As String = ""
        '    Dim FromDateFilter As String = ""
        '    Dim ToDateFilter As String = ""
        '    Dim DateTo As Date = Now
        '    If ToDate <> "" Then
        '        Try
        '            DateTo = Date.Parse(ToDate)
        '        Catch
        '            DateTo = Now
        '        End Try
        '    End If
        '    Dim DateFrom As Date = #1/1/1947#
        '    If FromDate <> "" Then
        '        Try
        '            DateFrom = Date.Parse(FromDate)
        '        Catch
        '            DateFrom = #1/1/1947#
        '        End Try
        '    End If

        '    If DateFrom > DateTo Then
        '        Dim tDate As Date = DateFrom
        '        DateFrom = DateTo
        '        DateTo = tDate
        '    End If

        '    If FromDate <> "" Then FromDateFilter &= " (x.LastLoad >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
        '    If ToDate <> "" Then ToDateFilter &= " (x.LastLoad <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

        '    If (FromDateFilter <> "") OrElse (ToDateFilter <> "") Then
        '        If (FromDateFilter <> "") Then
        '            DateFilter = "WHERE " & FromDateFilter
        '            If (ToDateFilter <> "") Then
        '                DateFilter &= "AND " & ToDateFilter
        '            End If
        '        Else
        '            DateFilter = "WHERE " & ToDateFilter
        '        End If
        '    End If

        '    Dim sbSql As New StringBuilder
        '    sbSql.Append("SELECT ")
        '    If NoOfItems > 0 Then sbSql.Append("TOP " & NoOfItems.ToString & " ")
        '    'MySqlString &= "x.* "
        '    sbSql.Append("x.ItemId, ")
        '    sbSql.Append("x.DriverCode, ")
        '    sbSql.Append("x.DriverName, ")
        '    sbSql.Append("x.AccountNo, ")
        '    sbSql.Append("ls.LoadStatus, ")
        '    sbSql.Append("ls.LoadType, ")
        '    sbSql.Append("'LoadItemId'=ls.ItemId, ")
        '    sbSql.Append("x.LastLoadID, ")
        '    sbSql.Append("x.LastLoad, ")
        '    sbSql.Append("x.LastPU, ")
        '    sbSql.Append("x.LastDP, ")
        '    sbSql.Append("x.CellPhone, ")
        '    sbSql.Append("'BrokerCodeD'=Null, ")
        '    sbSql.Append("x.OfficeOwner ")

        '    sbSql.Append("FROM " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS x ")
        '    sbSql.Append("LEFT OUTER JOIN " & MyOjectQualifier & "tblOOLoadSheetHeader AS ls ON x.LastLoadId = ls.LoadId ")

        '    sbSql.Append("WHERE (x.Status='N') ")

        '    'MySqlString &= DateFilter
        '    If JRCIOfficeCode <> "" AndAlso JRCIOfficeCode <> "000000000" Then
        '        sbSql.Append("AND (x.OfficeOwner = '" & JRCIOfficeCode & "') ")
        '    End If

        '    sbSql.Append("ORDER BY x.OfficeOwner, x.DriverName, x.LastLoad desc ")

        '    Dim drSP As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSql.ToString)


        '    Dim sbSqlBkr As New StringBuilder
        '    sbSqlBkr.Append("SELECT ")
        '    If NoOfItems > 0 Then sbSqlBkr.Append("TOP " & NoOfItems.ToString & " ")
        '    'MySqlString &= "x.* "
        '    sbSqlBkr.Append("x.ItemId, ")
        '    sbSqlBkr.Append("x.DriverCode, ")
        '    sbSqlBkr.Append("x.DriverName, ")
        '    sbSqlBkr.Append("x.AccountNo, ")
        '    sbSqlBkr.Append("ls.LoadStatus, ")
        '    sbSqlBkr.Append("ls.LoadType, ")
        '    sbSqlBkr.Append("'LoadItemId'=ls.ItemId, ")
        '    sbSqlBkr.Append("x.LastLoadID, ")
        '    sbSqlBkr.Append("x.LastLoad, ")
        '    sbSqlBkr.Append("x.LastPU, ")
        '    sbSqlBkr.Append("x.LastDP, ")
        '    sbSqlBkr.Append("x.CellPhone, ")
        '    sbSqlBkr.Append("x.BrokerCodeD, ")
        '    sbSqlBkr.Append("x.OfficeOwner ")

        '    sbSqlBkr.Append("FROM " & MyOjectQualifier & "BKR_SalesPersonMasterfile AS x ")
        '    sbSqlBkr.Append("LEFT OUTER JOIN " & MyOjectQualifier & "tblOOLoadSheetHeader AS ls ON x.LastLoadId = ls.LoadId ")

        '    sbSqlBkr.Append("WHERE (x.Status='N') ")

        '    'MySqlString &= DateFilter
        '    If JRCIOfficeCode <> "" AndAlso JRCIOfficeCode <> "000000000" Then
        '        sbSqlBkr.Append("AND (x.OfficeOwner = '" & JRCIOfficeCode & "') ")
        '    End If

        '    sbSqlBkr.Append("ORDER BY x.OfficeOwner, x.DriverName, x.LastLoad desc ")



        '    Dim drBkrSP As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(sbSqlBkr.ToString)


        '    'Dim strSearchOn As String
        '    'Select Case SearchOn.ToUpper
        '    '    'Case "CN"
        '    '    '    strSearchOn = "cn.CustomerName "
        '    '    Case "OO"
        '    '        strSearchOn = "x.DriverName "
        '    '        '    Case "IO"
        '    '        '        strSearchOn = "io.IOName "
        '    '        'Case "BK"
        '    '        '    strSearchOn = "x.BrokerName "
        '    '        '    Case "LI"
        '    '        '        strSearchOn = "x.LoadId "
        '    '        '    Case "PO"
        '    '        '        strSearchOn = "x.CustPO "
        '    '        '    Case "PJ"
        '    '        '        strSearchOn = "x.ProJob "
        '    '        '    Case "PC"
        '    '        '        strSearchOn = "x.PUCityST "
        '    '    Case Else '"Any"
        '    '        strSearchOn = "Any"
        '    'End Select

        '    '  MySqlString &= "WHERE (x.OfficeOwner = '" & JRCIOfficeCode & "') "


        '    'Select Case SearchOn.ToUpper
        '    '    Case "OO" ', "IO", "BK"
        '    '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '    '        'MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
        '    '        'MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
        '    '        MySqlString &= "AND ((x.DriverCode LIKE '%" & SearchText & "%') OR (x.DriverName LIKE '" & strSearchText & "')) "
        '    '        MySqlString &= DateFilter
        '    '        MySqlString &= ScopeFilter
        '    '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '    '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
        '    '        MySqlString &= "ORDER BY x.LastLoad desc, x.LastLoadId "

        '    '        'Case "CN"
        '    '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '    '        'MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
        '    '        'MySqlString &= DateFilter
        '    '        'MySqlString &= ScopeFilter
        '    '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '    '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

        '    '        'Case "LI", "PO", "PJ", "PC"
        '    '        '    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '    '        '    MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
        '    '        '    MySqlString &= DateFilter
        '    '        '    MySqlString &= ScopeFilter
        '    '        '    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
        '    '        '    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

        '    '    Case Else '"ANY"
        '    '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
        '    '        'MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
        '    '        MySqlString &= "OR (x.DriverName LIKE '" & strSearchText & "') "
        '    '        'MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
        '    '        'MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
        '    '        'MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
        '    '        'MySqlString &= ") "
        '    '        'MySqlString &= DateFilter
        '    '        'MySqlString &= ScopeFilter
        '    '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
        '    'End Select
        '    'MySqlString &= "ORDER BY x.LastLoad desc, x.JRCIOfficeCode, x.LastLoadId "

        '    'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
        '    'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

        '    'Dim dr As IDataReader = DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)


        '    Dim dt As New DataTable
        '    If DriverType <> "BK" Then
        '        dt.Load(drSP)
        '    End If
        '    If DriverType <> "OO" Then
        '        dt.Load(drBkrSP)
        '    End If

        '    For Each dtr As DataRow In dt.Rows
        '        If Null.IsNull(dtr("LoadItemId")) Then dtr("LoadItemId") = 0
        '        dtr("CellPhone") = Phone.FormatPhoneNo(dtr("CellPhone").ToString)
        '    Next

        '    dt.DefaultView.Sort = "DriverName"


        '    'TotalRecords = dt.Rows.Count

        '    'Return dt
        '    Return dt.DefaultView.ToTable
        'End Function

        Public Function GetReportXmission(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal XmissionFile As String = "", Optional ByVal LoadStatus As String = "", Optional ByVal SortOn As String = "XMissionDate", Optional ByVal SortDesc As Boolean = True, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
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

            If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            'If LoadStatus.ToUpper = "COMPLETE" Then
            '    If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            '    If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            'Else
            '    If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            '    If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            'End If

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
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
            MySqlString &= "'XCount'=(SELECT Count(*) From " & MyOjectQualifier & "tblOOLoadSheetHeader Where XmissionFile = x.XmissionFile ), "
            MySqlString &= "x.CodCheckSeq, "
            'MySqlString &= "x.DispatchCode, "
            MySqlString &= "'DispatchCode' = CASE WHEN (dm.DispatchName IS Null) OR (dm.DispatchName='')  THEN x.DispatchCode ELSE dm.DispatchName END, "
            MySqlString &= "x.XMissionDate "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS sp ON x.DriverCode=sp.DriverCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "

            Dim strSearchOn As String
            Select Case SearchOn.ToUpper
                Case "CN"
                    strSearchOn = "cn.CustomerName "
                Case "PO"
                    strSearchOn = "x.CustPO "
                    'Case "PJ"
                    '    strSearchOn = "x.ProJob "
                    '    Case "BK"
                    '        strSearchOn = "bk.BrokerName "
                    '    Case "LI"
                    '        strSearchOn = "x.LoadId "
                    '    Case "PO"
                    '        strSearchOn = "x.CustPO "
                    '    Case "PJ"
                    '        strSearchOn = "x.ProJob "
                    '    Case "PC"
                    '        strSearchOn = "x.PUCityST "
                Case Else '"Any"
                    strSearchOn = "Any"
            End Select

            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            'If LoadStatus = "" Then
            '    MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
            '    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
            'Else
            '    MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
            'End If

            MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "

            If CustomerNumber <> "" Then
                MySqlString &= "AND (cn.CustomerNumber = '" & CustomerNumber & "') "
            End If
            If XmissionFile <> "" Then MySqlString &= " AND (x.XmissionFile = '" & XmissionFile & "') "

            Select Case SearchOn.ToUpper
                '    Case "OO", "IO", "BK"
                '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
                '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                '        MySqlString &= DateFilter
                '        MySqlString &= ScopeFilter
                '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case "CN"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                    'Case "LI", "PO", "PJ" ', "PC"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    'MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
                    'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
                    'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

                Case Else '"ANY"
                    'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
                    MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
                    '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
                    MySqlString &= ") "
                    '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            End Select
            MySqlString &= DateFilter
            MySqlString &= ScopeFilter
            MySqlString &= "ORDER BY x.JRCIOfficeCode, x.LoadType desc, x.XMissionDate desc, x.LoadId "

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            Dim dt As New DataTable
            dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

            Dim dtr As DataRow
            BCustBillTotal = 0
            JRCOffCommTotal = 0
            TotalLoadXmited = dt.Rows.Count

            For Each dtr In dt.Rows

                Dim _BCustBill As Decimal = Convert.ToDecimal(Null.SetNull(dtr("BCustBill"), _BCustBill))
                If Not Null.IsNull(_BCustBill) Then BCustBillTotal += _BCustBill

                Dim _JRCOffComm As Decimal = Convert.ToDecimal(Null.SetNull(dtr("JRCOffComm"), _JRCOffComm))
                If Not Null.IsNull(_JRCOffComm) Then JRCOffCommTotal += _JRCOffComm

            Next

            If SortDesc Then
                dt.DefaultView.Sort = SortOn & " DESC"
            Else
                dt.DefaultView.Sort = SortOn
            End If

            Return dt.DefaultView.ToTable

        End Function

        Public Function GetReportContainer(ByVal JRCIOfficeCode As String, ByVal CustomerNumber As String, ByVal SearchText As String, Optional ByVal SearchDriverText As String = "", Optional ByVal DriverStatus As String = "N", Optional ByVal ReportTitle As String = "CA", Optional ByVal LoadStatus As String = "", Optional ByVal SortOn As String = "LoadDate", Optional ByVal SortDesc As Boolean = True, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "", Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = 0) As DataTable 'IDataReader '
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
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
                Case 1
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    End If
                Case 2
                    'Do Nothing
                Case Else '0
                    If PortalId > -1 Then
                        ScopeFilter = "AND (m.PortalId = " & PortalId.ToString & ") " 'Return GetPortalLoadSheets(PortalId)
                    ElseIf ModuleId > -1 Then
                        ScopeFilter = "AND (x.ModuleId = " & ModuleId.ToString & ") " 'Return GetModuleLoadSheets(ModuleId)
                    End If
            End Select

            Dim strSearchText As String
            If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

            Dim strSearchDriverText As String
            If StartsWith Then strSearchDriverText = SearchDriverText & "%" Else strSearchDriverText = "%" & SearchDriverText & "%"

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

            'If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            'If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "

            'If LoadStatus.ToUpper = "COMPLETE" Then
            '    If FromDate <> "" Then DateFilter = "AND (x.XMissionDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            '    If ToDate <> "" Then DateFilter &= "AND (x.XMissionDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            'Else
            '    If FromDate <> "" Then DateFilter = "AND (x.LoadDate >= Convert(DateTime, '" & DateFrom.ToShortDateString & "')) "
            '    If ToDate <> "" Then DateFilter &= "AND (x.LoadDate <= Convert(DateTime, '" & DateTo.ToShortDateString & "')) "
            'End If

            'Dim strSearchOn As String
            'Select Case SearchOn.ToUpper
            '    Case "CN"
            '        strSearchOn = "cn.CustomerName "
            '    Case "PO"
            '        strSearchOn = "x.CustPO "
            '        'Case "PJ"
            '        '    strSearchOn = "x.ProJob "
            '        '    Case "BK"
            '        '        strSearchOn = "bk.BrokerName "
            '        '    Case "LI"
            '        '        strSearchOn = "x.LoadId "
            '        '    Case "PO"
            '        '        strSearchOn = "x.CustPO "
            '        '    Case "PJ"
            '        '        strSearchOn = "x.ProJob "
            '        '    Case "PC"
            '        '        strSearchOn = "x.PUCityST "
            '    Case Else '"Any"
            '        strSearchOn = "Any"
            'End Select

            Dim MySqlString As String = String.Empty
            MySqlString &= "SELECT "
            If NoOfItems > 0 Then MySqlString &= "TOP " & NoOfItems.ToString & " "
            ' MySqlString &= "x.* "
            MySqlString &= "x.ItemId, "
            MySqlString &= "x.LoadID, "
            MySqlString &= "x.LoadDate, "
            MySqlString &= "x.LoadStatus, "
            MySqlString &= "x.DeliveryDate, "
            MySqlString &= "x.CustPO, "
            MySqlString &= "x.CustomerNumber, "
            MySqlString &= "cn.CustomerName, "
            MySqlString &= "x.LoadType, "
            'MySqlString &= "x.CarrierName, "
            MySqlString &= "'CarrierName'= CASE WHEN (x.LoadType='BK') THEN bk.BrokerName ELSE sp.DriverName END, "
            MySqlString &= "'CarrierCode'= CASE WHEN (x.LoadType='BK') THEN bk.BrokerCode ELSE sp.DriverCode END, "
            'MySqlString &= "sp.AccountNo, "
            MySqlString &= "'AccountNo'= CASE WHEN (x.LoadType='BK') THEN bksp.AccountNo ELSE sp.AccountNo END, "
            MySqlString &= "'DriverName'= CASE WHEN (x.LoadType='BK') THEN bksp.DriverName ELSE sp.DriverName END, "
            MySqlString &= "'BrokerName'= CASE WHEN (x.LoadType='BK') THEN bk.BrokerName ELSE '' END, "
            MySqlString &= "x.TrailerNumber, "
            'MySqlString &= "x.TrailerType, "
            MySqlString &= "'TrailerType'= "
            MySqlString &= "CASE "
            MySqlString &= "WHEN x.TrailerType='FD' THEN 'Flatbed' "
            MySqlString &= "WHEN x.TrailerType='SD' THEN 'Stepdeck' "
            MySqlString &= "WHEN x.TrailerType='RG' THEN 'RGN' "
            MySqlString &= "WHEN x.TrailerType='DD' THEN 'Double Drop' "
            MySqlString &= "WHEN x.TrailerType='48' THEN 'Van 48''' "
            MySqlString &= "WHEN x.TrailerType='53' THEN 'Van 53''' "
            MySqlString &= "WHEN x.TrailerType='20' THEN '20'' Container' "
            MySqlString &= "WHEN x.TrailerType='40' THEN '40'' Container' "
            MySqlString &= "ELSE x.TrailerType "
            MySqlString &= "END, "
            'MySqlString &= "tt.TrailerType, "

            MySqlString &= "x.Container1, "
            MySqlString &= "x.Container2, "
            MySqlString &= "la.BBaseLoad, "
            MySqlString &= "x.PUCityST, "
            MySqlString &= "x.DPCityST "

            MySqlString &= "FROM " & MyOjectQualifier & "tblOOLoadSheetHeader AS x "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "tblLoadAcct As la ON x.LoadID=la.LoadID "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "AR1_CustomerMaster AS cn ON x.CustomerNumber=cn.CustomerNumber "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_SalesPersonMasterfile AS sp ON x.DriverCode=sp.DriverCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_BrokerMaster AS bk ON x.BrokerCode=bk.BrokerCode "
            MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "BKR_SalesPersonMasterfile AS bksp ON x.BkrDriverNo=bksp.DriverCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_DispatchMasterfile AS dm ON x.DispatchCode=dm.DispatchCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS so ON x.JRCIOfficeCode=so.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "ARD_InterOffice AS io ON x.JRCIOCode=io.JRCIOfficeCode "
            'MySqlString &= "LEFT OUTER JOIN " & MyOjectQualifier & "TrailerTypes As tt ON x.TrailerType=tt.TrailerCode "

            'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            If JRCIOfficeCode = "999999999" Then
                MySqlString &= "WHERE (x.JRCIOfficeCode LIKE '%%') "
            Else
                MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            End If

            'If LoadStatus = "" Then
            '    MySqlString &= "AND ((x.LoadStatus = 'WIP') OR (x.LoadStatus = 'SUSPENSE') OR (x.LoadStatus = 'COMPLETE' )) "
            '    'MySqlString &= "AND (x.LoadStatus <> 'VOIDED') "
            'Else
            '    MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
            'End If
            If LoadStatus <> "" Then
                MySqlString &= "AND (x.LoadStatus = '" & LoadStatus & "') "
            End If

            If CustomerNumber <> "" Then
                MySqlString &= "AND (x.CustomerNumber = '" & CustomerNumber & "') "
            End If

            Select Case ReportTitle.ToUpper
                Case "TS"
                    MySqlString &= "AND (x.TrailerNumber <> '') "
                    If SearchDriverText <> "" Then
                        MySqlString &= "AND ((sp.DriverName LIKE '" & strSearchDriverText & "') "
                        MySqlString &= "OR (bksp.DriverName LIKE '" & strSearchDriverText & "')) "
                    End If
                    If (DriverStatus = "N") OrElse (DriverStatus = "Y") Then
                        MySqlString &= "AND (((x.LoadType='OO') AND (sp.Status='" & DriverStatus & "')) "
                        MySqlString &= "OR ((x.LoadType='BK') AND (bksp.Status='" & DriverStatus & "'))) "
                    ElseIf (DriverStatus = "HOLD") Then
                        MySqlString &= "AND (((x.LoadType='OO') AND (sp.SafetyAuth='HOLD')) "
                        MySqlString &= "OR ((x.LoadType='BK') AND (bksp.SafetyAuth='HOLD'))) "
                    End If
                Case "CS"
                    MySqlString &= "AND ((x.Container1 <> '') OR (x.Container2  <> '')) "
            End Select
            If SearchText <> "" Then
                Select Case SearchOn.ToUpper
                    Case "TR"
                        MySqlString &= "AND (x.TrailerNumber LIKE '" & strSearchText & "') "
                    Case "C1"
                        MySqlString &= "AND (x.Container1 LIKE '" & strSearchText & "') "
                    Case "C2"
                        MySqlString &= "AND (x.Container2 LIKE '" & strSearchText & "') "
                    Case "C12"
                        MySqlString &= "AND ((x.Container1 LIKE '" & strSearchText & "') "
                        MySqlString &= "OR (x.Container2 LIKE '" & strSearchText & "')) "
                    Case Else '"ANY"
                        MySqlString &= "AND ((x.TrailerNumber LIKE '" & strSearchText & "') "
                        MySqlString &= "OR (x.Container1 LIKE '" & strSearchText & "') "
                        MySqlString &= "OR (x.Container2 LIKE '" & strSearchText & "')) "
                End Select
            End If
            'Select Case SearchOn.ToUpper
            '    '    Case "OO", "IO", "BK"
            '    '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '    '        MySqlString &= "AND (x.LoadType = '" & SearchOn & "') " 'This has been introduced for filtering only OO or BK Loads
            '    '        MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
            '    '        MySqlString &= DateFilter
            '    '        MySqlString &= ScopeFilter
            '    '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
            '    '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

            '    Case "CN"
            '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '        MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "')) "
            '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
            '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

            '        'Case "LI", "PO", "PJ" ', "PC"
            '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '        'MySqlString &= "AND (" & strSearchOn & " LIKE '" & strSearchText & "') "
            '        'MySqlString &= "ORDER BY " & strSearchOn & ", x.ViewOrder, x.CreatedDate desc "
            '        'MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "

            '    Case Else '"ANY"
            '        'MySqlString &= "WHERE (x.JRCIOfficeCode = '" & JRCIOfficeCode & "') "
            '        MySqlString &= "AND ((x.CustomerNumber LIKE '%" & SearchText & "%') OR (cn.CustomerName LIKE '" & strSearchText & "') "
            '        '        MySqlString &= "OR (oo.DriverName LIKE '" & strSearchText & "') "
            '        '        MySqlString &= "OR (io.IOName LIKE '" & strSearchText & "') "
            '        '        MySqlString &= "OR (bk.BrokerName LIKE '" & strSearchText & "') "
            '        '        MySqlString &= "OR (x.LoadId LIKE '" & strSearchText & "') "
            '        MySqlString &= ") "
            '        '        MySqlString &= "ORDER BY x.LoadDate desc, x.UpdatedDate desc, x.ViewOrder "
            'End Select
            MySqlString &= DateFilter
            MySqlString &= ScopeFilter
            If ReportTitle = "TS" Then
                'MySqlString &= "ORDER BY x.TrailerNumber, x.LoadDate desc, x.JRCIOfficeCode, x.LoadType desc, x.LoadId "
                MySqlString &= "ORDER BY x.TrailerNumber, x.LoadDate desc, x.LoadId "
            Else
                'MySqlString &= "ORDER BY x.LoadId, x.LoadDate desc, x.JRCIOfficeCode, x.LoadType desc "
                MySqlString &= "ORDER BY x.LoadId "
            End If

            'Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadSheetInfo))
            'Return DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString)

            Return GetDataTable(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))
            'Dim dt As New DataTable
            'dt.Load(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString))

            'Dim dtr As DataRow
            'BBaseLoadTotal = 0
            ''BCustBillTotal = 0
            ''JRCOffCommTotal = 0
            ''TotalLoadXmited = dt.Rows.Count

            'For Each dtr In dt.Rows

            '    Dim _BBaseLoad As Decimal = Convert.ToDecimal(Null.SetNull(dtr("BBaseLoad"), _BBaseLoad))
            '    If Not Null.IsNull(_BBaseLoad) Then BBaseLoadTotal += _BBaseLoad

            '    'Dim _BCustBill As Decimal = Convert.ToDecimal(Null.SetNull(dtr("BCustBill"), _BCustBill))
            '    'If Not Null.IsNull(_BCustBill) Then BCustBillTotal += _BCustBill

            '    'Dim _JRCOffComm As Decimal = Convert.ToDecimal(Null.SetNull(dtr("JRCOffComm"), _JRCOffComm))
            '    'If Not Null.IsNull(_JRCOffComm) Then JRCOffCommTotal += _JRCOffComm

            'Next

            'If SortDesc Then
            '    dt.DefaultView.Sort = SortOn & " DESC"
            'Else
            '    dt.DefaultView.Sort = SortOn
            'End If

            'Return dt.DefaultView.ToTable
            'Return dt
        End Function

        Public Function GetLoadConfirmHeader(ByVal ItemId As Integer) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("CarrierPhone", GetType(String))
            dt.Columns.Add("CarrierFax", GetType(String))
            dt.Columns.Add("CarrierCell", GetType(String))
            dt.Columns.Add("CarrierEmail", GetType(String))

            dt.Load(DataProvider.Instance().ExecuteReader("bhattji_GetLoadConfirmHeader", ItemId))

            For Each dtr As DataRow In dt.Rows
                dtr("CarrierPhone") = Phone.FormatPhoneNo(Convert.ToString(Null.SetNull(dtr("CarrierPhone"), Null.NullString))) '& IIf(Null.IsNull(dtr("CarrierExt")), "", " Ext: " & dtr("CarrierExt").ToString).ToString
                dtr("CarrierFax") = Phone.FormatPhoneNo(Convert.ToString(Null.SetNull(dtr("CarrierFax"), Null.NullString)))
                dtr("CarrierCell") = Phone.FormatPhoneNo(Convert.ToString(Null.SetNull(dtr("CarrierCell"), Null.NullString)))
                If Not Validators.IsEmailValid(Convert.ToString(Null.SetNull(dtr("CarrierEmail"), Null.NullString))) Then
                    dtr("CarrierEmail") = ""
                End If
            Next

            Return dt
        End Function
#End Region

#Region " Optional Interfaces "

        'Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As DotNetNuke.Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
        '    Dim SearchItemCollection As New SearchItemInfoCollection

        '    Dim LoadSheets As ArrayList = GetLoadSheets(ModInfo.ModuleID)

        '    Dim objLoadSheet As Object
        '    For Each objLoadSheet In LoadSheets
        '        Dim SearchItem As SearchItemInfo
        '        With CType(objLoadSheet, LoadSheetInfo)
        '            '
        '            Dim UserId As Integer = Null.NullInteger
        '            If IsNumeric(.CreatedByUser) Then
        '                UserId = Integer.Parse(.CreatedByUser)
        '            End If

        '            Dim strContent As String = System.Web.HttpUtility.HtmlDecode(.ActualFields)
        '            Dim strDescription As String = HtmlUtils.Shorten(HtmlUtils.Clean(System.Web.HttpUtility.HtmlDecode(.ActualFields), False), 100, "...")

        '            SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .ActualFields, strDescription, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString, strContent, "ItemId=" & .ItemId.ToString, Null.NullInteger)
        '            SearchItemCollection.Add(SearchItem)
        '        End With
        '    Next

        '    Return SearchItemCollection

        'End Function

        'Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
        '    Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
        '    Dim strXML As String = ""
        '    strXML += "<LoadSheets>"

        '    'Export each LoadSheet Details
        '    Dim arrLoadSheets As ArrayList = GetLoadSheets(ModuleID)
        '    If arrLoadSheets.Count <> 0 Then
        '        Dim objLoadSheet As LoadSheetInfo
        '        For Each objLoadSheet In arrLoadSheets
        '            With objLoadSheet
        '                strXML += "<LoadSheet>"

        '                strXML += "<ActualFields>" & XMLEncode(.ActualFields) & "</ActualFields>"

        '                strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString) & "</ViewOrder>"
        '                strXML += "</LoadSheet>"
        '            End With
        '        Next
        '    End If

        '    'Export the Module Settings
        '    Dim objOI As New OptionsInfo(ModuleID)
        '    With objOI
        '        'Control Options
        '        strXML += "<GetItems>" & XMLEncode(.GetItems.ToString) & "</GetItems>"
        '        strXML += "<ViewControl>" & XMLEncode(.ViewControl) & "</ViewControl>"

        '        'Option1 Options
        '        strXML += "<PagerSize>" & XMLEncode(.PagerSize.ToString) & "</PagerSize>"

        '    End With

        '    strXML += "</LoadSheets>"

        '    Return strXML

        'End Function

        'Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
        '    Dim xmlLoadSheets As System.Xml.XmlNode = GetContent(Content, "LoadSheets")

        '    'Import each LoadSheet Details
        '    Dim xmlLoadSheet As System.Xml.XmlNode
        '    For Each xmlLoadSheet In xmlLoadSheets.SelectNodes("LoadSheet")
        '        Dim objLoadSheet As New LoadSheetInfo
        '        With objLoadSheet
        '            .ModuleId = ModuleID

        '            .ActualFields = xmlLoadSheet.Item("ActualFields").InnerText

        '            Try
        '                .ViewOrder = Integer.Parse(xmlLoadSheet.Item("ViewOrder").InnerText)
        '            Catch
        '            End Try
        '            .CreatedByUser = UserId.ToString
        '        End With

        '        AddLoadSheet(objLoadSheet)
        '    Next

        '    'Import the Module Settings
        '    Dim objModules As New Entities.Modules.ModuleController
        '    Dim objOI As New OptionsInfo
        '    With objOI
        '        '.ModuleID = ModuleID

        '        'Control Options
        '        Try
        '            .GetItems = Integer.Parse(xmlLoadSheets.SelectSingleNode("GetItems").InnerText)
        '        Catch
        '        End Try
        '        .ViewControl = xmlLoadSheets.SelectSingleNode("ViewControl").InnerText

        '        'Option1 Options
        '        Try
        '            .PagerSize = Integer.Parse(xmlLoadSheets.SelectSingleNode("PagerSize").InnerText)
        '        Catch
        '        End Try


        '        .Update(ModuleID)
        '    End With

        'End Sub

#End Region

    End Class 'LoadSheetInfo

End Namespace
