Imports System
Imports System.Data
Imports DotNetNuke.Data
Imports DotNetNuke.Services.Search
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace bhattji.Modules.LoadSheets.Business

    Public Class LoadAcctInfo
        '---------------------------------------------------------------------
        ' TODO Declare BLL Class Info fields and property accessors
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------

#Region " Private Members "
        Private _ItemId As Integer
        Private _ModuleId As Integer

        'Insert the Actual Fields Below

        Private _LoadType As String
        Private _JRCIOfficeCode As String
        Private _OfficeOverride As String

        'Private _ManagerOverride As String
        'Private _ManagerOverrideAccount As String
        'Private _ManagerCommRate As Double

        Private _DriverCode As String
        Private _DriverName As String
        Private _CommRate As Double
        Private _JRCIOCode As String
        Private _IOCode As String
        Private _IOName As String

        Private _officeVendorNO As String
        Private _subOffComm As String
        'Private _aPCodeFM As String
        'Private _abvrNameFM As String

        Private _BrokerCode As String
        Private _BrokerName As String
        Private _BStatus As String
        Private _customerNumber As String
        Private _customerName As String
        Private _customerStatus As String
        Private _RepNoC As String
        Private _RepNo As String
        Private _RepName As String

        Private _CreationSource As Integer

        Private _comCheckSeq As String
        Private _comCheckAmt As Decimal
        Private _codCheckSeq As String
        Private _codCheckAmt As Decimal

        Private _loadID As String
        Private _bBaseLoad As Decimal
        Private _FixedDiscount As Boolean
        Private _discountPCT As Double
        Private _discountDlr As Decimal
        Private _bDeten As Double
        Private _bTolls As Double
        Private _bFuel As Double
        Private _bDrop As Double
        Private _bRecon As Double
        Private _bTarp As Double
        Private _bLumper As Double
        Private _bUnload As Double
        Private _bAdminMisc As Double
        Private _bCustBill As Decimal
        Private _dRCommBase As Decimal
        Private _dRRebur As Double
        Private _dRPermits As Double
        Private _dRTolls As Double
        Private _dRMisc As Double
        Private _dRTotDue As Double
        Private _aPCommTot As Double
        Private _calcMI As Double
        Private _calcRate As Double
        Private _calcTot As Decimal
        Private _jRCIOOffC1 As String
        Private _jRCIOOffC2 As String
        Private _iOOffC1 As String
        Private _iOOffC2 As String
        Private _iOOffC3 As String
        Private _iOOffC4 As String
        Private _iOOffN1 As String
        Private _iOOffN2 As String
        Private _iOOffN3 As String
        Private _iOOffN4 As String
        Private _iOComm1 As Double
        Private _iOComm2 As Double
        Private _iOComm3 As Double
        Private _iOComm4 As Double
        Private _iOOffL1 As String
        Private _iOOffL2 As String
        Private _iOOffL3 As String
        Private _iOOffL4 As String
        Private _iOCommTot As Double
        Private _iOAdmin1 As Double
        Private _iOAdmin2 As Double
        Private _iOAdmin3 As Double
        Private _iOAdmin4 As Double
        Private _iOAdminTot As Double
        Private _exPermits As Double
        Private _exTrailer As Double
        Private _exMisc As Double
        Private _exTot As Double
        Private _adminExempt As String
        Private _jRCOnePct As Decimal
        Private _jRCOffComm As Decimal
        Private _jRCTotal As Decimal
        Private _bINC3 As String
        Private _bINC4 As String
        Private _bINC5 As String
        Private _bINC6 As String
        Private _bINC7 As String
        Private _bINC8 As String
        Private _bINC9 As String
        Private _bINC10 As String
        Private _bINC11 As String
        Private _jRCOffPct As Double
        Private _jRCBkrPct As Double
        Private _bkrPct As Double
        Private _bkrDlr As Double
        Private _iODlr As Double
        Private _iOPct As Double
        Private _dCPCT As Double
        Private _oNEPCT As Double
        Private _repFixed As Boolean
        Private _repPct As Double
        Private _repDlr As Double
        Private _repPctC As Double
        Private _repDlrC As Double
        Private _dispPct As Double
        Private _dispDlr As Double
        Private _iOXPct1 As Double
        Private _iOXPct2 As Double
        Private _iOXPct3 As Double
        Private _iOXPct4 As Double
        Private _jRCAdminP As Double
        Private _aPOffC1 As String
        Private _aPOffC2 As String
        Private _aPOffC3 As String
        Private _aPOffC4 As String
        Private _aPOffN1 As String
        Private _aPOffN2 As String
        Private _aPOffN3 As String
        Private _aPOffN4 As String
        Private _aPComm1 As Double
        Private _aPComm2 As Double
        Private _aPComm3 As Double
        Private _aPComm4 As Double
        Private _aPCPct1 As Double
        Private _aPCPct2 As Double
        Private _aPCPct3 As Double
        Private _aPCPct4 As Double
        Private _allowORide As String
        Private _bType As String
        Private _oCommPlus As Double
        Private _oCommNeg As Double
        Private _alumaPct As Double
        Private _alumaDlrDisc As Double
        Private _bKFixed As String
        Private _iOFixed As String
        Private _gPPct As Double
        Private _tPName As String
        Private _tPAmt As Double
        Private _tPDesc As String
        Private _tPPaidDate As DateTime
        Private _tPCkNo As String
        Private _jRC5050 As String
        Private _calc85 As String
        Private _dvrDedPct As Double
        Private _dvrDedResn As String

        Private _SecPinA As Integer
        Private _SecPinB As Integer
        Private _OverrideCode As Integer
        Private _OverriddenBy As String
        Private _AdjustJrcTotal As Boolean

        'Insert the Actual Fields above

        Private _ViewOrder As Integer
        Private _UpdatedByUserId As Integer
        Private _UpdatedByUser As String
        Private _UpdatedDate As Date
        Private _CreatedByUserId As Integer
        Private _CreatedByUser As String
        Private _CreatedDate As Date

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


        'Insert the Actual Fields Below
        'From LoadSheet
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

        Public Property LoadType() As String
            Get
                Return _LoadType
            End Get
            Set(ByVal Value As String)
                _LoadType = Value
            End Set
        End Property
        Public Property JRCIOfficeCode() As String
            Get
                Return _JRCIOfficeCode
            End Get
            Set(ByVal Value As String)
                _JRCIOfficeCode = Value
            End Set
        End Property
        Public Property OfficeOverride() As String
            Get
                Return _OfficeOverride.Substring(0, 7)
            End Get
            Set(ByVal Value As String)
                _OfficeOverride = Value
            End Set
        End Property

        'Public Property ManagerOverride() As String
        '    Get
        '        Return _ManagerOverride
        '    End Get
        '    Set(ByVal Value As String)
        '        _ManagerOverride = Value
        '    End Set
        'End Property

        'Public Property ManagerCommRate() As Double
        '    Get
        '        Return _ManagerCommRate
        '    End Get
        '    Set(ByVal Value As Double)
        '        _ManagerCommRate = Value
        '    End Set
        'End Property

        'Public Property ManagerOverrideAccount() As String
        '    Get
        '        Return _ManagerOverrideAccount.Substring(0, 7)
        '    End Get
        '    Set(ByVal Value As String)
        '        _ManagerOverrideAccount = Value
        '    End Set
        'End Property

        'Public ReadOnly Property JRCOffCommM() As Decimal
        '    Get
        '        If (Not String.IsNullOrEmpty(_ManagerOverride)) AndAlso _ManagerCommRate > 0 Then 'AndAlso _jRCOffComm > 0
        '            Return _jRCOffComm * _ManagerCommRate / 100
        '        Else
        '            Return 0
        '        End If
        '    End Get
        'End Property

        'Public ReadOnly Property JRCOffCommO() As Decimal
        '    Get
        '        Return _jRCOffComm - JRCOffCommM
        '    End Get
        'End Property

        Public Property DriverCode() As String
            Get
                Return _DriverCode
            End Get
            Set(ByVal Value As String)
                _DriverCode = Value
            End Set
        End Property
        Public Property JRCIOCode() As String
            Get
                Return _JRCIOCode
            End Get
            Set(ByVal Value As String)
                _JRCIOCode = Value
            End Set
        End Property
        Public Property IOCode() As String
            Get
                Return _IOCode
            End Get
            Set(ByVal Value As String)
                _IOCode = Value
            End Set
        End Property
        Public Property BrokerCode() As String
            Get
                Return _BrokerCode
            End Get
            Set(ByVal Value As String)
                _BrokerCode = Value
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
        Public Property RepNoC() As String
            Get
                Return _RepNoC
            End Get
            Set(ByVal Value As String)
                _RepNoC = Value
            End Set
        End Property
        Public Property RepNo() As String
            Get
                Return _RepNo
            End Get
            Set(ByVal Value As String)
                _RepNo = Value
            End Set
        End Property

        'From Driver(SalesPerson)
        Public Property DriverName() As String
            Get
                Return _DriverName
            End Get
            Set(ByVal Value As String)
                _DriverName = Value
            End Set
        End Property

        Public Property CommRate() As Double
            Get
                Return _CommRate
            End Get
            Set(ByVal Value As Double)
                _CommRate = Value
            End Set
        End Property

        'From InterOffice
        Public Property IOName() As String
            Get
                Return _IOName
            End Get
            Set(ByVal Value As String)
                _IOName = Value
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
        Public Property SubOffComm() As String
            Get
                Return _subOffComm
            End Get
            Set(ByVal Value As String)
                _subOffComm = Value
            End Set
        End Property
        'Public Property APCodeFM() As String
        '    Get
        '        Return _aPCodeFM
        '    End Get
        '    Set(ByVal Value As String)
        '        _aPCodeFM = Value
        '    End Set
        'End Property
        'Public Property AbvrNameFM() As String
        '    Get
        '        Return _abvrNameFM
        '    End Get
        '    Set(ByVal Value As String)
        '        _abvrNameFM = Value
        '    End Set
        'End Property

        'From Broker
        Public Property BrokerName() As String
            Get
                Return _BrokerName
            End Get
            Set(ByVal Value As String)
                _BrokerName = Value
            End Set
        End Property
        Public Property BStatus() As String
            Get
                Return _BStatus
            End Get
            Set(ByVal Value As String)
                _BStatus = Value
            End Set
        End Property

        'From SalesRep
        Public Property RepName() As String
            Get
                Return _RepName
            End Get
            Set(ByVal Value As String)
                _RepName = Value
            End Set
        End Property


        'From Load Accounts
        Public Property LoadID() As String
            Get
                Return _loadID
            End Get
            Set(ByVal Value As String)
                _loadID = Value
            End Set
        End Property

        Public Property BBaseLoad() As Decimal
            Get
                Return _bBaseLoad
            End Get
            Set(ByVal Value As Decimal)
                _bBaseLoad = Value
            End Set
        End Property

        Public Property FixedDiscount() As Boolean
            Get
                Return _FixedDiscount
            End Get
            Set(ByVal Value As Boolean)
                _FixedDiscount = Value
            End Set
        End Property

        Public Property DiscountPCT() As Double
            Get
                Return _discountPCT
            End Get
            Set(ByVal Value As Double)
                _discountPCT = Value
            End Set
        End Property

        Public Property DiscountDlr() As Decimal
            Get
                Return _discountDlr
            End Get
            Set(ByVal Value As Decimal)
                _discountDlr = Value
            End Set
        End Property

        Public Property BDeten() As Double
            Get
                Return _bDeten
            End Get
            Set(ByVal Value As Double)
                _bDeten = Value
            End Set
        End Property

        Public Property BTolls() As Double
            Get
                Return _bTolls
            End Get
            Set(ByVal Value As Double)
                _bTolls = Value
            End Set
        End Property

        Public Property BFuel() As Double
            Get
                Return _bFuel
            End Get
            Set(ByVal Value As Double)
                _bFuel = Value
            End Set
        End Property

        Public Property BDrop() As Double
            Get
                Return _bDrop
            End Get
            Set(ByVal Value As Double)
                _bDrop = Value
            End Set
        End Property

        Public Property BRecon() As Double
            Get
                Return _bRecon
            End Get
            Set(ByVal Value As Double)
                _bRecon = Value
            End Set
        End Property

        Public Property BTarp() As Double
            Get
                Return _bTarp
            End Get
            Set(ByVal Value As Double)
                _bTarp = Value
            End Set
        End Property

        Public Property BLumper() As Double
            Get
                Return _bLumper
            End Get
            Set(ByVal Value As Double)
                _bLumper = Value
            End Set
        End Property

        Public Property BUnload() As Double
            Get
                Return _bUnload
            End Get
            Set(ByVal Value As Double)
                _bUnload = Value
            End Set
        End Property

        Public Property BAdminMisc() As Double
            Get
                Return _bAdminMisc
            End Get
            Set(ByVal Value As Double)
                _bAdminMisc = Value
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

        Public Property DRCommBase() As Decimal
            Get
                Return _dRCommBase
            End Get
            Set(ByVal Value As Decimal)
                _dRCommBase = Value
            End Set
        End Property

        Public Property DRRebur() As Double
            Get
                Return _dRRebur
            End Get
            Set(ByVal Value As Double)
                _dRRebur = Value
            End Set
        End Property

        Public Property DRPermits() As Double
            Get
                Return _dRPermits
            End Get
            Set(ByVal Value As Double)
                _dRPermits = Value
            End Set
        End Property

        Public Property DRTolls() As Double
            Get
                Return _dRTolls
            End Get
            Set(ByVal Value As Double)
                _dRTolls = Value
            End Set
        End Property

        Public Property DRMisc() As Double
            Get
                Return _dRMisc
            End Get
            Set(ByVal Value As Double)
                _dRMisc = Value
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

        Public Property APCommTot() As Double
            Get
                Return _aPCommTot
            End Get
            Set(ByVal Value As Double)
                _aPCommTot = Value
            End Set
        End Property

        Public Property CalcMI() As Double
            Get
                Return _calcMI
            End Get
            Set(ByVal Value As Double)
                _calcMI = Value
            End Set
        End Property

        Public Property CalcRate() As Double
            Get
                Return _calcRate
            End Get
            Set(ByVal Value As Double)
                _calcRate = Value
            End Set
        End Property

        Public Property CalcTot() As Decimal
            Get
                Return _calcTot
            End Get
            Set(ByVal Value As Decimal)
                _calcTot = Value
            End Set
        End Property

        Public Property JRCIOOffC1() As String
            Get
                Return _jRCIOOffC1
            End Get
            Set(ByVal Value As String)
                _jRCIOOffC1 = Value
            End Set
        End Property

        Public Property JRCIOOffC2() As String
            Get
                Return _jRCIOOffC2
            End Get
            Set(ByVal Value As String)
                _jRCIOOffC2 = Value
            End Set
        End Property

        Public Property IOOffC1() As String
            Get
                Return _iOOffC1
            End Get
            Set(ByVal Value As String)
                _iOOffC1 = Value
            End Set
        End Property

        Public Property IOOffC2() As String
            Get
                Return _iOOffC2
            End Get
            Set(ByVal Value As String)
                _iOOffC2 = Value
            End Set
        End Property

        Public Property IOOffC3() As String
            Get
                Return _iOOffC3
            End Get
            Set(ByVal Value As String)
                _iOOffC3 = Value
            End Set
        End Property

        Public Property IOOffC4() As String
            Get
                Return _iOOffC4
            End Get
            Set(ByVal Value As String)
                _iOOffC4 = Value
            End Set
        End Property

        Public Property IOOffN1() As String
            Get
                Return _iOOffN1
            End Get
            Set(ByVal Value As String)
                _iOOffN1 = Value
            End Set
        End Property

        Public Property IOOffN2() As String
            Get
                Return _iOOffN2
            End Get
            Set(ByVal Value As String)
                _iOOffN2 = Value
            End Set
        End Property

        Public Property IOOffN3() As String
            Get
                Return _iOOffN3
            End Get
            Set(ByVal Value As String)
                _iOOffN3 = Value
            End Set
        End Property

        Public Property IOOffN4() As String
            Get
                Return _iOOffN4
            End Get
            Set(ByVal Value As String)
                _iOOffN4 = Value
            End Set
        End Property

        Public Property IOComm1() As Double
            Get
                Return _iOComm1
            End Get
            Set(ByVal Value As Double)
                _iOComm1 = Value
            End Set
        End Property

        Public Property IOComm2() As Double
            Get
                Return _iOComm2
            End Get
            Set(ByVal Value As Double)
                _iOComm2 = Value
            End Set
        End Property

        Public Property IOComm3() As Double
            Get
                Return _iOComm3
            End Get
            Set(ByVal Value As Double)
                _iOComm3 = Value
            End Set
        End Property

        Public Property IOComm4() As Double
            Get
                Return _iOComm4
            End Get
            Set(ByVal Value As Double)
                _iOComm4 = Value
            End Set
        End Property

        Public Property IOOffL1() As String
            Get
                Return _iOOffL1
            End Get
            Set(ByVal Value As String)
                _iOOffL1 = Value
            End Set
        End Property

        Public Property IOOffL2() As String
            Get
                Return _iOOffL2
            End Get
            Set(ByVal Value As String)
                _iOOffL2 = Value
            End Set
        End Property

        Public Property IOOffL3() As String
            Get
                Return _iOOffL3
            End Get
            Set(ByVal Value As String)
                _iOOffL3 = Value
            End Set
        End Property

        Public Property IOOffL4() As String
            Get
                Return _iOOffL4
            End Get
            Set(ByVal Value As String)
                _iOOffL4 = Value
            End Set
        End Property

        Public Property IOCommTot() As Double
            Get
                Return _iOCommTot
            End Get
            Set(ByVal Value As Double)
                _iOCommTot = Value
            End Set
        End Property

        Public Property IOAdmin1() As Double
            Get
                Return _iOAdmin1
            End Get
            Set(ByVal Value As Double)
                _iOAdmin1 = Value
            End Set
        End Property

        Public Property IOAdmin2() As Double
            Get
                Return _iOAdmin2
            End Get
            Set(ByVal Value As Double)
                _iOAdmin2 = Value
            End Set
        End Property

        Public Property IOAdmin3() As Double
            Get
                Return _iOAdmin3
            End Get
            Set(ByVal Value As Double)
                _iOAdmin3 = Value
            End Set
        End Property

        Public Property IOAdmin4() As Double
            Get
                Return _iOAdmin4
            End Get
            Set(ByVal Value As Double)
                _iOAdmin4 = Value
            End Set
        End Property

        Public Property IOAdminTot() As Double
            Get
                Return _iOAdminTot
            End Get
            Set(ByVal Value As Double)
                _iOAdminTot = Value
            End Set
        End Property

        Public Property ExPermits() As Double
            Get
                Return _exPermits
            End Get
            Set(ByVal Value As Double)
                _exPermits = Value
            End Set
        End Property

        Public Property ExTrailer() As Double
            Get
                Return _exTrailer
            End Get
            Set(ByVal Value As Double)
                _exTrailer = Value
            End Set
        End Property

        Public Property ExMisc() As Double
            Get
                Return _exMisc
            End Get
            Set(ByVal Value As Double)
                _exMisc = Value
            End Set
        End Property

        Public Property ExTot() As Double
            Get
                Return _exTot
            End Get
            Set(ByVal Value As Double)
                _exTot = Value
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

        Public Property JRCOnePct() As Decimal
            Get
                Return _jRCOnePct
            End Get
            Set(ByVal Value As Decimal)
                _jRCOnePct = Value
            End Set
        End Property

        Public Property JRCOffComm() As Decimal
            Get
                Return _jRCOffComm
            End Get
            Set(ByVal Value As Decimal)
                _jRCOffComm = Value
            End Set
        End Property

        Public Property JRCTotal() As Decimal
            Get
                Return _jRCTotal
            End Get
            Set(ByVal Value As Decimal)
                _jRCTotal = Value
            End Set
        End Property

        Public Property BINC3() As String
            Get
                Return _bINC3
            End Get
            Set(ByVal Value As String)
                _bINC3 = Value
            End Set
        End Property

        Public Property BINC4() As String
            Get
                Return _bINC4
            End Get
            Set(ByVal Value As String)
                _bINC4 = Value
            End Set
        End Property

        Public Property BINC5() As String
            Get
                Return _bINC5
            End Get
            Set(ByVal Value As String)
                _bINC5 = Value
            End Set
        End Property

        Public Property BINC6() As String
            Get
                Return _bINC6
            End Get
            Set(ByVal Value As String)
                _bINC6 = Value
            End Set
        End Property

        Public Property BINC7() As String
            Get
                Return _bINC7
            End Get
            Set(ByVal Value As String)
                _bINC7 = Value
            End Set
        End Property

        Public Property BINC8() As String
            Get
                Return _bINC8
            End Get
            Set(ByVal Value As String)
                _bINC8 = Value
            End Set
        End Property

        Public Property BINC9() As String
            Get
                Return _bINC9
            End Get
            Set(ByVal Value As String)
                _bINC9 = Value
            End Set
        End Property

        Public Property BINC10() As String
            Get
                Return _bINC10
            End Get
            Set(ByVal Value As String)
                _bINC10 = Value
            End Set
        End Property

        Public Property BINC11() As String
            Get
                Return _bINC11
            End Get
            Set(ByVal Value As String)
                _bINC11 = Value
            End Set
        End Property

        Public Property JRCOffPct() As Double
            Get
                Return _jRCOffPct
            End Get
            Set(ByVal Value As Double)
                _jRCOffPct = Value
            End Set
        End Property

        Public Property JRCBkrPct() As Double
            Get
                Return _jRCBkrPct
            End Get
            Set(ByVal Value As Double)
                _jRCBkrPct = Value
            End Set
        End Property

        Public Property BkrPct() As Double
            Get
                Return _bkrPct
            End Get
            Set(ByVal Value As Double)
                _bkrPct = Value
            End Set
        End Property

        Public Property BkrDlr() As Double
            Get
                Return _bkrDlr
            End Get
            Set(ByVal Value As Double)
                _bkrDlr = Value
            End Set
        End Property

        Public Property IODlr() As Double
            Get
                Return _iODlr
            End Get
            Set(ByVal Value As Double)
                _iODlr = Value
            End Set
        End Property

        Public Property IOPct() As Double
            Get
                Return _iOPct
            End Get
            Set(ByVal Value As Double)
                _iOPct = Value
            End Set
        End Property

        Public Property DCPCT() As Double
            Get
                Return _dCPCT
            End Get
            Set(ByVal Value As Double)
                _dCPCT = Value
            End Set
        End Property

        Public Property ONEPCT() As Double
            Get
                Return _oNEPCT
            End Get
            Set(ByVal Value As Double)
                _oNEPCT = Value
            End Set
        End Property

        Public Property RepFixed() As Boolean
            Get
                Return _repFixed
            End Get
            Set(ByVal Value As Boolean)
                _repFixed = Value
            End Set
        End Property

        Public Property RepPct() As Double
            Get
                Return _repPct
            End Get
            Set(ByVal Value As Double)
                _repPct = Value
            End Set
        End Property

        Public Property RepDlr() As Double
            Get
                Return _repDlr
            End Get
            Set(ByVal Value As Double)
                _repDlr = Value
            End Set
        End Property


        Public Property RepPctC() As Double
            Get
                Return _repPctC
            End Get
            Set(ByVal Value As Double)
                _repPctC = Value
            End Set
        End Property

        Public Property RepDlrC() As Double
            Get
                Return _repDlrC
            End Get
            Set(ByVal Value As Double)
                _repDlrC = Value
            End Set
        End Property


        Public Property DispPct() As Double
            Get
                Return _dispPct
            End Get
            Set(ByVal Value As Double)
                _dispPct = Value
            End Set
        End Property

        Public Property DispDlr() As Double
            Get
                Return _dispDlr
            End Get
            Set(ByVal Value As Double)
                _dispDlr = Value
            End Set
        End Property

        Public Property IOXPct1() As Double
            Get
                Return _iOXPct1
            End Get
            Set(ByVal Value As Double)
                _iOXPct1 = Value
            End Set
        End Property

        Public Property IOXPct2() As Double
            Get
                Return _iOXPct2
            End Get
            Set(ByVal Value As Double)
                _iOXPct2 = Value
            End Set
        End Property

        Public Property IOXPct3() As Double
            Get
                Return _iOXPct3
            End Get
            Set(ByVal Value As Double)
                _iOXPct3 = Value
            End Set
        End Property

        Public Property IOXPct4() As Double
            Get
                Return _iOXPct4
            End Get
            Set(ByVal Value As Double)
                _iOXPct4 = Value
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

        Public Property APOffC1() As String
            Get
                Return _aPOffC1
            End Get
            Set(ByVal Value As String)
                _aPOffC1 = Value
            End Set
        End Property

        Public Property APOffC2() As String
            Get
                Return _aPOffC2
            End Get
            Set(ByVal Value As String)
                _aPOffC2 = Value
            End Set
        End Property

        Public Property APOffC3() As String
            Get
                Return _aPOffC3
            End Get
            Set(ByVal Value As String)
                _aPOffC3 = Value
            End Set
        End Property

        Public Property APOffC4() As String
            Get
                Return _aPOffC4
            End Get
            Set(ByVal Value As String)
                _aPOffC4 = Value
            End Set
        End Property

        Public Property APOffN1() As String
            Get
                Return _aPOffN1
            End Get
            Set(ByVal Value As String)
                _aPOffN1 = Value
            End Set
        End Property

        Public Property APOffN2() As String
            Get
                Return _aPOffN2
            End Get
            Set(ByVal Value As String)
                _aPOffN2 = Value
            End Set
        End Property

        Public Property APOffN3() As String
            Get
                Return _aPOffN3
            End Get
            Set(ByVal Value As String)
                _aPOffN3 = Value
            End Set
        End Property

        Public Property APOffN4() As String
            Get
                Return _aPOffN4
            End Get
            Set(ByVal Value As String)
                _aPOffN4 = Value
            End Set
        End Property

        Public Property APComm1() As Double
            Get
                Return _aPComm1
            End Get
            Set(ByVal Value As Double)
                _aPComm1 = Value
            End Set
        End Property

        Public Property APComm2() As Double
            Get
                Return _aPComm2
            End Get
            Set(ByVal Value As Double)
                _aPComm2 = Value
            End Set
        End Property

        Public Property APComm3() As Double
            Get
                Return _aPComm3
            End Get
            Set(ByVal Value As Double)
                _aPComm3 = Value
            End Set
        End Property

        Public Property APComm4() As Double
            Get
                Return _aPComm4
            End Get
            Set(ByVal Value As Double)
                _aPComm4 = Value
            End Set
        End Property

        Public Property APCPct1() As Double
            Get
                Return _aPCPct1
            End Get
            Set(ByVal Value As Double)
                _aPCPct1 = Value
            End Set
        End Property

        Public Property APCPct2() As Double
            Get
                Return _aPCPct2
            End Get
            Set(ByVal Value As Double)
                _aPCPct2 = Value
            End Set
        End Property

        Public Property APCPct3() As Double
            Get
                Return _aPCPct3
            End Get
            Set(ByVal Value As Double)
                _aPCPct3 = Value
            End Set
        End Property

        Public Property APCPct4() As Double
            Get
                Return _aPCPct4
            End Get
            Set(ByVal Value As Double)
                _aPCPct4 = Value
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

        Public Property BType() As String
            Get
                Return _bType
            End Get
            Set(ByVal Value As String)
                _bType = Value
            End Set
        End Property

        Public Property OCommPlus() As Double
            Get
                Return _oCommPlus
            End Get
            Set(ByVal Value As Double)
                _oCommPlus = Value
            End Set
        End Property

        Public Property OCommNeg() As Double
            Get
                Return _oCommNeg
            End Get
            Set(ByVal Value As Double)
                _oCommNeg = Value
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

        Public Property AlumaDlrDisc() As Double
            Get
                Return _alumaDlrDisc
            End Get
            Set(ByVal Value As Double)
                _alumaDlrDisc = Value
            End Set
        End Property

        Public Property BKFixed() As String
            Get
                Return _bKFixed
            End Get
            Set(ByVal Value As String)
                _bKFixed = Value
            End Set
        End Property

        Public Property IOFixed() As String
            Get
                Return _iOFixed
            End Get
            Set(ByVal Value As String)
                _iOFixed = Value
            End Set
        End Property

        Public Property GPPct() As Double
            Get
                Return _gPPct
            End Get
            Set(ByVal Value As Double)
                _gPPct = Value
            End Set
        End Property

        Public Property TPName() As String
            Get
                Return _tPName
            End Get
            Set(ByVal Value As String)
                _tPName = Value
            End Set
        End Property

        Public Property TPAmt() As Double
            Get
                Return _tPAmt
            End Get
            Set(ByVal Value As Double)
                _tPAmt = Value
            End Set
        End Property

        Public Property TPDesc() As String
            Get
                Return _tPDesc
            End Get
            Set(ByVal Value As String)
                _tPDesc = Value
            End Set
        End Property

        Public Property TPPaidDate() As DateTime
            Get
                Return _tPPaidDate
            End Get
            Set(ByVal Value As DateTime)
                _tPPaidDate = Value
            End Set
        End Property

        Public Property TPCkNo() As String
            Get
                Return _tPCkNo
            End Get
            Set(ByVal Value As String)
                _tPCkNo = Value
            End Set
        End Property

        Public Property JRC5050() As String
            Get
                Return _jRC5050
            End Get
            Set(ByVal Value As String)
                _jRC5050 = Value
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

        Public Property SecPinA() As Integer
            Get
                Return _SecPinA
            End Get
            Set(ByVal Value As Integer)
                _SecPinA = Value
            End Set
        End Property
        Public Property SecPinB() As Integer
            Get
                Return _SecPinB
            End Get
            Set(ByVal Value As Integer)
                _SecPinB = Value
            End Set
        End Property
        Public Property OverrideCode() As Integer
            Get
                Return _OverrideCode
            End Get
            Set(ByVal Value As Integer)
                _OverrideCode = Value
            End Set
        End Property
        Public Property OverriddenBy() As String
            Get
                Return _OverriddenBy
            End Get
            Set(ByVal Value As String)
                _OverriddenBy = Value
            End Set
        End Property
        Public ReadOnly Property IsOverridden() As Boolean
            Get
                Return (_OverriddenBy <> "")
            End Get
        End Property

        Public ReadOnly Property IoRecoveryCode() As String
            Get
                If IsIORecoveredLoad AndAlso IOOffL1 <> "" Then
                    'Dim Code As String = ""
                    'Dim objLA As LoadAcctInfo = (New LoadAcctsController).GetLoadAcctByLoadId(IOOffL1)
                    'If Not objLA Is Nothing Then
                    '    Code = objLA.OverrideCode
                    'End If
                    'Return Code
                    Try
                        Return (New LoadAcctsController).GetLoadAcctByLoadId(IOOffL1).OfficeOverride
                    Catch
                        Return ""
                    End Try
                Else
                    Return ""
                End If
            End Get
        End Property

        Public Property AdjustJrcTotal() As Boolean
            Get
                Return _AdjustJrcTotal
            End Get
            Set(ByVal Value As Boolean)
                _AdjustJrcTotal = Value
            End Set
        End Property
        'Insert the Actual Fields above



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

    Public Class LoadAcctsController

#Region " Public Methods "

        Private Function GetNull(ByVal Field As Object) As Object
            Return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value)
        End Function

        '---------------------------------------------------------------------
        ' TODO Implement BLL methods
        ' You can use CodeSmith templates to generate this code
        '---------------------------------------------------------------------
        Public Function AddLoadAcct(ByVal objLoadAcct As LoadAcctInfo) As Integer
            With objLoadAcct
                Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_AddLoadAcct", .ModuleId, GetNull(.LoadID), GetNull(.BBaseLoad), GetNull(.FixedDiscount), GetNull(.DiscountPCT), GetNull(.DiscountDlr), GetNull(.BDeten), GetNull(.BTolls), GetNull(.BFuel), GetNull(.BDrop), GetNull(.BRecon), GetNull(.BTarp), GetNull(.BLumper), GetNull(.BUnload), GetNull(.BAdminMisc), GetNull(.BCustBill), GetNull(.DRCommBase), GetNull(.DRRebur), GetNull(.DRPermits), GetNull(.DRTolls), GetNull(.DRMisc), GetNull(.DRTotDue), GetNull(.APCommTot), GetNull(.CalcMI), GetNull(.CalcRate), GetNull(.CalcTot), GetNull(.JRCIOOffC1), GetNull(.JRCIOOffC2), GetNull(.IOOffC1), GetNull(.IOOffC2), GetNull(.IOOffC3), GetNull(.IOOffC4), GetNull(.IOOffN1), GetNull(.IOOffN2), GetNull(.IOOffN3), GetNull(.IOOffN4), GetNull(.IOComm1), GetNull(.IOComm2), GetNull(.IOComm3), GetNull(.IOComm4), GetNull(.IOOffL1), GetNull(.IOOffL2), GetNull(.IOOffL3), GetNull(.IOOffL4), GetNull(.IOCommTot), GetNull(.IOAdmin1), GetNull(.IOAdmin2), GetNull(.IOAdmin3), GetNull(.IOAdmin4), GetNull(.IOAdminTot), GetNull(.ExPermits), GetNull(.ExTrailer), GetNull(.ExMisc), GetNull(.ExTot), GetNull(.AdminExempt), GetNull(.JRCOnePct), GetNull(.JRCOffComm), GetNull(.JRCTotal), GetNull(.BINC3), GetNull(.BINC4), GetNull(.BINC5), GetNull(.BINC6), GetNull(.BINC7), GetNull(.BINC8), GetNull(.BINC9), GetNull(.BINC10), GetNull(.BINC11), GetNull(.JRCOffPct), GetNull(.JRCBkrPct), GetNull(.BkrPct), GetNull(.BkrDlr), GetNull(.IODlr), GetNull(.IOPct), GetNull(.DCPCT), GetNull(.ONEPCT), GetNull(.RepFixed), GetNull(.RepPct), GetNull(.RepDlr), GetNull(.DispPct), GetNull(.DispDlr), GetNull(.IOXPct1), GetNull(.IOXPct2), GetNull(.IOXPct3), GetNull(.IOXPct4), GetNull(.JRCAdminP), GetNull(.APOffC1), GetNull(.APOffC2), GetNull(.APOffC3), GetNull(.APOffC4), GetNull(.APOffN1), GetNull(.APOffN2), GetNull(.APOffN3), GetNull(.APOffN4), GetNull(.APComm1), GetNull(.APComm2), GetNull(.APComm3), GetNull(.APComm4), GetNull(.APCPct1), GetNull(.APCPct2), GetNull(.APCPct3), GetNull(.APCPct4), GetNull(.AllowORide), GetNull(.BType), GetNull(.OCommPlus), GetNull(.OCommNeg), GetNull(.AlumaPct), GetNull(.AlumaDlrDisc), GetNull(.BKFixed), GetNull(.IOFixed), GetNull(.GPPct), GetNull(.TPName), GetNull(.TPAmt), GetNull(.TPDesc), GetNull(.TPPaidDate), GetNull(.TPCkNo), GetNull(.JRC5050), GetNull(.Calc85), GetNull(.DvrDedPct), GetNull(.DvrDedResn), GetNull(.OverrideCode), GetNull(.OverriddenBy), GetNull(.AdjustJrcTotal), GetNull(.ViewOrder), GetNull(.CreatedByUserId)))
            End With
        End Function

        Public Sub UpdateLoadAcct(ByVal objLoadAcct As LoadAcctInfo)
            With objLoadAcct
                DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateLoadAcct", .ItemId, GetNull(.LoadID), GetNull(.BBaseLoad), GetNull(.FixedDiscount), GetNull(.DiscountPCT), GetNull(.DiscountDlr), GetNull(.BDeten), GetNull(.BTolls), GetNull(.BFuel), GetNull(.BDrop), GetNull(.BRecon), GetNull(.BTarp), GetNull(.BLumper), GetNull(.BUnload), GetNull(.BAdminMisc), GetNull(.BCustBill), GetNull(.DRCommBase), GetNull(.DRRebur), GetNull(.DRPermits), GetNull(.DRTolls), GetNull(.DRMisc), GetNull(.DRTotDue), GetNull(.APCommTot), GetNull(.CalcMI), GetNull(.CalcRate), GetNull(.CalcTot), GetNull(.JRCIOOffC1), GetNull(.JRCIOOffC2), GetNull(.IOOffC1), GetNull(.IOOffC2), GetNull(.IOOffC3), GetNull(.IOOffC4), GetNull(.IOOffN1), GetNull(.IOOffN2), GetNull(.IOOffN3), GetNull(.IOOffN4), GetNull(.IOComm1), GetNull(.IOComm2), GetNull(.IOComm3), GetNull(.IOComm4), GetNull(.IOOffL1), GetNull(.IOOffL2), GetNull(.IOOffL3), GetNull(.IOOffL4), GetNull(.IOCommTot), GetNull(.IOAdmin1), GetNull(.IOAdmin2), GetNull(.IOAdmin3), GetNull(.IOAdmin4), GetNull(.IOAdminTot), GetNull(.ExPermits), GetNull(.ExTrailer), GetNull(.ExMisc), GetNull(.ExTot), GetNull(.AdminExempt), GetNull(.JRCOnePct), GetNull(.JRCOffComm), GetNull(.JRCTotal), GetNull(.BINC3), GetNull(.BINC4), GetNull(.BINC5), GetNull(.BINC6), GetNull(.BINC7), GetNull(.BINC8), GetNull(.BINC9), GetNull(.BINC10), GetNull(.BINC11), GetNull(.JRCOffPct), GetNull(.JRCBkrPct), GetNull(.BkrPct), GetNull(.BkrDlr), GetNull(.IODlr), GetNull(.IOPct), GetNull(.DCPCT), GetNull(.ONEPCT), GetNull(.RepFixed), GetNull(.RepPct), GetNull(.RepDlr), GetNull(.DispPct), GetNull(.DispDlr), GetNull(.IOXPct1), GetNull(.IOXPct2), GetNull(.IOXPct3), GetNull(.IOXPct4), GetNull(.JRCAdminP), GetNull(.APOffC1), GetNull(.APOffC2), GetNull(.APOffC3), GetNull(.APOffC4), GetNull(.APOffN1), GetNull(.APOffN2), GetNull(.APOffN3), GetNull(.APOffN4), GetNull(.APComm1), GetNull(.APComm2), GetNull(.APComm3), GetNull(.APComm4), GetNull(.APCPct1), GetNull(.APCPct2), GetNull(.APCPct3), GetNull(.APCPct4), GetNull(.AllowORide), GetNull(.BType), GetNull(.OCommPlus), GetNull(.OCommNeg), GetNull(.AlumaPct), GetNull(.AlumaDlrDisc), GetNull(.BKFixed), GetNull(.IOFixed), GetNull(.GPPct), GetNull(.TPName), GetNull(.TPAmt), GetNull(.TPDesc), GetNull(.TPPaidDate), GetNull(.TPCkNo), GetNull(.JRC5050), GetNull(.Calc85), GetNull(.DvrDedPct), GetNull(.DvrDedResn), GetNull(.OverrideCode), GetNull(.OverriddenBy), GetNull(.AdjustJrcTotal), GetNull(.ViewOrder), GetNull(.UpdatedByUserId))
            End With
        End Sub
        Public Sub UpdateIOOffL1(ByVal LoadID As String, ByVal IOOffL1 As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateIOOffL1", LoadID, IOOffL1)
        End Sub
        Public Sub UpdateRepDetails(ByVal ItemId As Integer, ByVal RepPct As Double, ByVal RepDlr As Double)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateRepDetails", ItemId, GetNull(RepPct), GetNull(RepDlr))
        End Sub
        Public Sub UpdateBrokerDetails(ByVal LoadId As String, ByVal BkrPct As Double, ByVal BKFixed As String)
            DataProvider.Instance().ExecuteNonQuery("bhattji_UpdateBrokerDetails", LoadId, GetNull(BkrPct), GetNull(BKFixed))
        End Sub

        Public Sub DeleteLoadAcct(ByVal objLoadAcct As LoadAcctInfo)
            DeleteLoadAcct(objLoadAcct.ItemId)
        End Sub

        Public Sub DeleteLoadAcct(ByVal ItemID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_DeleteLoadAcct", ItemID)
        End Sub

        Public Sub SortLoadAccts(ByVal ModuleID As Integer)
            DataProvider.Instance().ExecuteNonQuery("bhattji_SortLoadAccts", ModuleID)
        End Sub

        Public Function GetLoadAcctId(ByVal LoadId As String) As Integer
            Return Convert.ToInt32(DataProvider.Instance().ExecuteScalar("bhattji_GetLoadAcctId", LoadId))
        End Function
        'Public Function GetAcctByIOOffN(ByVal IOOffN As String) As IDataReader
        '    Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadAcct", GetLoadAcctId(IOOffN))
        'End Function
        Public Function GetAcctForIOOffN(ByVal LoadId As String) As IDataReader
            Return DotNetNuke.Data.DataProvider.Instance.ExecuteReader("bhattji_GetLoadAcct", GetLoadAcctId(LoadId))
        End Function
        Public Function GetLoadAcctByLoadId(ByVal LoadId As String) As LoadAcctInfo
            Return GetLoadAcct(GetLoadAcctId(LoadId))
        End Function
        Public Function GetLoadAcct(ByVal ItemID As Integer) As LoadAcctInfo
            Return CType(CBO.FillObject(DataProvider.Instance().ExecuteReader("bhattji_GetLoadAcct", ItemID), GetType(LoadAcctInfo)), LoadAcctInfo)
        End Function

        'This function retreives the Items from Database,
        'depending upon the paramters supplied
        'If you supplied ModuleID only, it gets GetModuleItems(ModuleId)
        'If you supplied any ModuleID, with PortalID only, it gets GetPortalItems(PortalID)
        'If you dont suppliy any parameter it gets GetAllItems()

        Public Function GetLoadAccts(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As DataTable
            Dim dt As New DataTable
            dt.Load(GetLoadAcctsCommon(ModuleId, PortalId, GetItems))
            Return dt
        End Function

        Public Function GetLoadAcctsCommon(Optional ByVal ModuleId As Integer = -1, Optional ByVal PortalId As Integer = -1, Optional ByVal GetItems As Integer = -1) As IDataReader
            Select Case GetItems
                Case 0
                    If ModuleId > -1 Then
                        Return GetModuleLoadAccts(ModuleId)
                    Else
                        Return GetAllLoadAccts()
                    End If
                Case 1
                    If PortalId > -1 Then
                        Return GetPortalLoadAccts(PortalId)
                    Else
                        Return GetAllLoadAccts()
                    End If
                Case 2
                    Return GetAllLoadAccts()
                Case Else '0
                    If PortalId > -1 Then
                        Return GetPortalLoadAccts(PortalId)
                    ElseIf ModuleId > -1 Then
                        Return GetModuleLoadAccts(ModuleId)
                    Else
                        Return GetAllLoadAccts()
                    End If
            End Select
        End Function

        Public Function GetModuleLoadAccts(ByVal ModuleId As Integer) As IDataReader 'ArrayList
            Return DataProvider.Instance().ExecuteReader("bhattji_GetModuleLoadAccts", ModuleId)
        End Function

        Public Function GetPortalLoadAccts(ByVal PortalId As Integer) As IDataReader 'ArrayList
            Return DataProvider.Instance().ExecuteReader("bhattji_GetPortalLoadAccts", PortalId)
        End Function

        Public Function GetAllLoadAccts() As IDataReader 'ArrayList
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllLoadAccts")
        End Function
        Public Function GetAllLoadAccount(Optional ByVal NoOfItems As Integer = 100) As IDataReader 'ArrayList
            Return DataProvider.Instance().ExecuteReader("bhattji_GetAllLoadAccts", NoOfItems)
        End Function

        Public Function GetSearchData(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal StartsWith As Boolean = False, Optional ByVal NoOfItems As Integer = 100, Optional ByVal FromDate As String = "", Optional ByVal ToDate As String = "") As ArrayList
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
            MySqlString &= "ItemId, "
            MySqlString &= "LoadID, "
            MySqlString &= "TPName, "
            MySqlString &= "BCustBill, "
            MySqlString &= "TPCKNo "

            MySqlString &= "FROM " & MyOjectQualifier & "tblLoadAcct AS x "

            'Dim strSearchText As String
            'If StartsWith Then strSearchText = SearchText & "%" Else strSearchText = "%" & SearchText & "%"

            Select Case SearchOn.ToUpper
                Case "TPNAME", "LOADID"
                    MySqlString &= "WHERE x." & SearchOn & " LIKE '" & strSearchText & "' "
                    MySqlString &= "ORDER BY x." & SearchOn & ", x.ViewOrder, x.CreatedDate desc"

                Case Else '"ANY"
                    MySqlString &= "WHERE (x.TPNAME LIKE '" & strSearchText & "') "
                    MySqlString &= "OR (x.LOADID LIKE '" & strSearchText & "') "
                    MySqlString &= "ORDER BY x.TPNAME, x.ViewOrder, x.CreatedDate desc"

            End Select

            Return CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance.ExecuteSQL(MySqlString.ToString), GetType(LoadAcctInfo))

        End Function

        Public Function GetIOName(ByVal JRCIOfficeCode As String) As String
            Return Convert.ToString(DataProvider.Instance().ExecuteScalar("bhattji_GetIOName", JRCIOfficeCode))
        End Function
        Public Function GetIOOffN1(ByVal IOOffN1 As String) As String
            Return Convert.ToString(DataProvider.Instance().ExecuteScalar("bhattji_GetIOOffN1", IOOffN1))
        End Function
        Public Function GetIOOffN2(ByVal IOOffN2 As String) As String
            Return Convert.ToString(DataProvider.Instance().ExecuteScalar("bhattji_GetIOOffN2", IOOffN2))
        End Function


        Public Function GetDispatchersByJRCIOfficeCode(ByVal JRCIOfficeCode As String) As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetDispatchersByJRCIOfficeCode", JRCIOfficeCode)
        End Function

        Public Function GetDispatchersByJRCIOfficeCode9(ByVal JRCIOfficeCode As String) As IDataReader
            Return DataProvider.Instance().ExecuteReader("bhattji_GetDispatchersByJRCIOfficeCode9", JRCIOfficeCode)
        End Function
#End Region

    End Class 'LoadAcctsController

End Namespace
