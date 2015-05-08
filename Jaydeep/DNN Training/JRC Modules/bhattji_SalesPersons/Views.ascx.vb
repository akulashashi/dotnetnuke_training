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
Imports bhattji.Modules.SalesPersons.Business

Namespace bhattji.Modules.SalesPersons

    Public MustInherit Class Views
        Inherits Entities.Modules.PortalModuleBase
        Implements Entities.Modules.IActionable


#Region " Event Handlers "
        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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

                Dim objOI As New OptionsInfo(ModuleId)

                Dim MyViewList As ViewList = CType(LoadControl(ModulePath & "ViewList.ascx"), ViewList)
                With MyViewList
                    .ModuleConfiguration = ModuleConfiguration
                    .ID = "ViewList"
                    '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "ViewList.ascx")
                End With 'MyViewList
                'Controls.Add(MyViewList)

                ModuleConfiguration.ModuleTitle = Localization.GetString(MyViewList.ID & "Title", LocalResourceFile)
                MyViewList.ModuleConfiguration = ModuleConfiguration


                If AJAX.IsInstalled Then
                    AJAX.RegisterScriptManager()

                    Dim pnlBhattji As New Panel()
                    pnlBhattji.ID = "pnlBhattji"
                    pnlBhattji.Style.Add(HtmlTextWriterStyle.Position, "relative")
                    pnlBhattji.Controls.Add(MyViewList)

                    'AJAX.WrapUpdatePanelControl(pnlBhattji, True)
                    Dim AjaxPanel As New UpdatePanel()
                    AjaxPanel.ID = "updtpnlBhattji"
                    AjaxPanel.UpdateMode = UpdatePanelUpdateMode.Conditional
                    AjaxPanel.ContentTemplateContainer.Controls.Add(pnlBhattji)
                    Controls.Add(AjaxPanel)
                Else
                    Controls.Add(MyViewList)
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

End Namespace 'bhattji.Modules.SalesPersons
