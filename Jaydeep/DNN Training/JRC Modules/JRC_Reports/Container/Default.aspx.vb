
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            'Dim objOI As New OptionsInfo(ModuleId)

            Dim ModulePath As String = Request.ApplicationPath & "/"

            Dim ReportType As String = "container"
            Try
                If (Not Request.QueryString("ReportType") Is Nothing) OrElse (Request.QueryString("ReportType") <> "") Then
                    ReportType = Request.QueryString("ReportType").ToLower
                End If
            Catch
            End Try

            Dim MyReport As New System.Web.UI.UserControl
            Select Case ReportType.ToLower
                'Case "report1"
                '    MyReport = CType(LoadControl(ModulePath & "rptReport1.ascx"), rptReport1)
                '    MyReport.ID = "rptReport1"
                'Case "rvsalessummary"
                '    MyReport = CType(LoadControl(ModulePath & "rvSalesSummary.ascx"), rvSalesSummary)
                '    MyReport.ID = "rvSalesSummary"
                '    'Case "radsalessummary"
                '    '    MyReport = CType(LoadControl(ModulePath & "radSalesSummary.ascx"), radSalesSummary)
                '    '    MyReport.ID = "radSalesSummary"

                'Case "report2driver"
                '    MyReport = CType(LoadControl(ModulePath & "rptReport2Driver.ascx"), rptReport2Driver)
                '    MyReport.ID = "rptReport2Driver"
                'Case "rvloadstatusdriver"
                '    MyReport = CType(LoadControl(ModulePath & "rvLoadStatusDriver.ascx"), rvLoadStatusDriver)
                '    MyReport.ID = "rvLoadStatusDriver"

                'Case "report2broker"
                '    MyReport = CType(LoadControl(ModulePath & "rptReport2Broker.ascx"), rptReport2Broker)
                '    MyReport.ID = "rptReport2Broker"
                'Case "rvloadstatusbroker"
                '    MyReport = CType(LoadControl(ModulePath & "rvLoadStatusBroker.ascx"), rvLoadStatusBroker)
                '    MyReport.ID = "rvLoadStatusBroker"

                'Case "report3"
                '    MyReport = CType(LoadControl(ModulePath & "rptReport3.ascx"), rptReport3)
                '    MyReport.ID = "rptReport3"
                'Case "rvloadstatusreview"
                '    MyReport = CType(LoadControl(ModulePath & "rvLoadStatusReview.ascx"), rvLoadStatusReview)
                '    MyReport.ID = "rvLoadStatusReview"

                'Case "driverstatus"
                '    MyReport = CType(LoadControl(ModulePath & "rptDriverStatus.ascx"), rptDriverStatus)
                '    MyReport.ID = "rptDriverStatus"
                'Case "rvdriverstatus"
                '    MyReport = CType(LoadControl(ModulePath & "rvDriverStatus.ascx"), rvDriverStatus)
                '    MyReport.ID = "rvDriverStatus"
                '    'Case "raddriverstatus"
                '    '    MyReport = CType(LoadControl(ModulePath & "radDriverStatus.ascx"), radDriverStatus)
                '    '    MyReport.ID = "radDriverStatus"
                '    'Case "crdriverstatus"
                '    '    MyReport = CType(LoadControl(ModulePath & "crDriverStatus.ascx"), crDriverStatus)
                '    '    MyReport.ID = "crDriverStatus"

                'Case "reportxmission"
                '    MyReport = CType(LoadControl(ModulePath & "rptXmission.ascx"), rptXmission)
                '    MyReport.ID = "rptXmission"
                'Case "rvxmission"
                '    MyReport = CType(LoadControl(ModulePath & "rvXmission.ascx"), rvXmission)
                '    MyReport.ID = "rvXmission"

                'Case "confirmreport"
                '    MyReport = CType(LoadControl(ModulePath & "rptLoadConfirm.ascx"), rptLoadConfirm)
                '    MyReport.ID = "rptLoadConfirm"
                Case "container"
                    MyReport = LoadControl(ModulePath & "rvContainer.ascx")
                    MyReport.ID = "rvContainer"

                    'Case "loadreport"
                    '    MyReport = CType(LoadControl(ModulePath & "rvLoadReport.ascx"), rvLoadReport)
                    '    MyReport.ID = "rvLoadReport"
                    'Case Else '"loadreport"
                    '    If (Not Request.QueryString("LoadType") Is Nothing) OrElse (Request.QueryString("LoadType") <> "") Then
                    '        MyReport = CType(LoadControl(ModulePath & "rptLoadSheetInit.ascx"), rptLoadSheetInit)
                    '        MyReport.ID = "rptLoadSheetInit"
                    '    Else
                    '        MyReport = CType(LoadControl(ModulePath & "rvLoadReport.ascx"), rvLoadReport)
                    '        MyReport.ID = "rvLoadReport"
                    '    End If
            End Select

            'MyReport.ModuleConfiguration = ModuleConfiguration
            'If MyReport.ID = "rptLoadConfirm" Then
            '    Run_iTextSharp(MyReport)
            'Else
            '    Controls.Add(MyReport)
            'End If
            form1.Controls.Add(MyReport)

            'Dim MyEditItem As EditItem = CType(LoadControl(ModulePath & "EditItem.ascx"), EditItem)
            'With MyEditItem
            '    '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
            '    .ModuleConfiguration = ModuleConfiguration
            '    .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
            'End With 'MyEditItem
            'Controls.Add(MyEditItem)

        Catch exc As Exception
            Response.Write(exc.ToString)
        End Try

    End Sub
End Class
