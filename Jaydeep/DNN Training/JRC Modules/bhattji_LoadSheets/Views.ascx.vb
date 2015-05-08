' Copyright (c) 2002-2005
' by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
'
' Permission is hereby granted, to the person obtaining a copy of this software legaly and associated 
' documentation files (the "Software"), to deal in the Software with restriction, including with limitation 
' the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports bhattji.Modules.LoadSheets.Business

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class Views
        Inherits Entities.Modules.PortalModuleBase
        Implements Entities.Modules.IActionable


#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Sample code to get data
                Dim RattleImageJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JbRattleImage.js""></SCRIPT>"
                If (Not Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "RattleImageJS", RattleImageJS)
                End If
                Dim JB_ActiveContentJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "js/JB_ActiveContent.js""></SCRIPT>"
                If (Not Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS)
                End If

                Dim MyView As New Entities.Modules.PortalModuleBase
                Dim objOI As New OptionsInfo(ModuleId)
                'If objOI.ViewControl.ToLower() = "xmission" Then
                '    MyView = CType(LoadControl(ModulePath & "Xmission.ascx"), Xmission)
                '    MyView.ID = "Xmission"
                'Else
                '    MyView = CType(LoadControl(ModulePath & "ViewList.ascx"), ViewList)
                '    MyView.ID = "ViewList"
                'End If
                Select Case objOI.ViewControl.ToLower
                    Case "xmission"
                        MyView = CType(LoadControl(ModulePath & "Xmission.ascx"), Xmission)
                        MyView.ID = "Xmission"
                    Case "report"
                        MyView = CType(LoadControl(ModulePath & "ViewReport.ascx"), ViewReport)
                        MyView.ID = "ViewReport"
                    Case Else '"list"
                        MyView = CType(LoadControl(ModulePath & "ViewList.ascx"), ViewList)
                        MyView.ID = "ViewList"
                End Select


                'Dim MyView As ViewList = CType(LoadControl(ModulePath & "ViewList.ascx"), ViewList)
                'MyView.ModuleConfiguration = ModuleConfiguration
                'Controls.Add(MyView)

                ModuleConfiguration.ModuleTitle = Localization.GetString(MyView.ID & "Title", LocalResourceFile)
                MyView.ModuleConfiguration = ModuleConfiguration

                Dim pnlBhattji As New Panel()
                'pnlBhattji.ID = "pnlBhattji"
                pnlBhattji.Style.Add(HtmlTextWriterStyle.Position, "relative")
                pnlBhattji.Controls.Add(MyView)

                If AJAX.IsInstalled Then 'If AJAX.IsInstalled AndAlso (MyView.ID <> "Xmission") Then
                    AJAX.RegisterScriptManager()

                    If (MyView.ID = "Xmission") Then
                        AJAX.SetScriptManagerProperty(Me.Page, "AsyncPostBackTimeout", New Object() {3600})
                    End If

                    'AJAX.WrapUpdatePanelControl(pnlBhattji, True)
                    Dim AjaxPanel As New UpdatePanel()
                    'AjaxPanel.ID = "updtpnlBhattji"
                    AjaxPanel.UpdateMode = UpdatePanelUpdateMode.Conditional
                    AjaxPanel.ContentTemplateContainer.Controls.Add(pnlBhattji)

                    'Dim ProgressPanel As New UpdateProgress
                    'ProgressPanel.AssociatedUpdatePanelID = AjaxPanel.ID
                    'ProgressPanel.ProgressTemplate.InstantiateIn(Me)

                    'Dim ProgressImage As New Image()
                    'ProgressImage.ImageUrl = "~/images/progressbar.gif"
                    'ProgressPanel.Controls.Add(ProgressImage)

                    'AjaxPanel.ContentTemplateContainer.Controls.Add(ProgressPanel)

                    'Controls.AddAt(0, AjaxPanel)
                    phtViews.Controls.Add(AjaxPanel)
                Else
                    'Controls.AddAt(0, pnlBhattji)
                    phtViews.Controls.Add(pnlBhattji)
                End If

                If Not Page.IsPostBack Then
                End If 'Not Page.IsPostBack Then

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

#Region " Optional Interfaces "

        Public ReadOnly Property ModuleActions() As Entities.Modules.Actions.ModuleActionCollection Implements Entities.Modules.IActionable.ModuleActions
            Get
                Dim Actions As New Entities.Modules.Actions.ModuleActionCollection
                Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.AddContent, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
                Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.ContentOptions, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString, "Settings"), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
                Return Actions
            End Get
        End Property

#End Region

    End Class 'Views

End Namespace 'bhattji.Modules.LoadSheets
