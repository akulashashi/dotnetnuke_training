// Copyright (c) 2002-2005
// by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
//
// Permission is hereby granted, to the person obtaining a copy of this software legaly and associated 
// documentation files (the "Software"), to deal in the Software with restriction, including with limitation 
// the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Framework;

namespace bhattji.Modules.JsonUpdates
{

    public abstract partial class Views : JsonUpdateModuleBase, IActionable
    {

        #region " Methods "

        private void RegisterJS()
        {
            //Put user code to initialize the page here
            //string RattleImageJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JbRattleImage.js\"></SCRIPT>";
            //if ((!Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")))
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RattleImageJS", RattleImageJS);
            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("RattleImageJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "RattleImageJS", ControlPath + "js/JbRattleImage.js");

            //string JB_ActiveContentJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JB_ActiveContent.js\"></SCRIPT>";
            //if ((!Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")))
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS);
            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("JB_ActiveContentJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "JB_ActiveContentJS", ControlPath + "js/JB_ActiveContent.js");
        }

        private void LoadData()
        {
            string consString = System.Configuration.ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(consString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [tblStudent]", conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader drStudents = cmd.ExecuteReader();
                GridView1.DataSource = drStudents;
                GridView1.DataBind();
            }
        }
    
        #endregion

        #region " Event Handlers "

        private void Page_Init(object sender, EventArgs e)
        {
            try
            {
                //Always get the Options Object First
                OptionsInfo objOI = new OptionsInfo(ModuleId);

                //Register Common JavaScripts
                RegisterJS();
                

                if (!Page.IsPostBack)
                {
                }
                //Not Page.IsPostBack Then
            }

            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }
        
        protected void OnCheckedChanged(object sender, EventArgs e)
        {
            bool isUpdateVisible = false;
            lblMessage.Text = string.Empty;

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                        row.RowState = DataControlRowState.Edit;

                    for (int i = 3; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = !isChecked;
                        if (row.Cells[i].Controls.OfType<TextBox>().ToList().Count > 0)
                        {
                            row.Cells[i].Controls.OfType<TextBox>().FirstOrDefault().Visible = isChecked;
                        }

                        if (isChecked && !isUpdateVisible)
                        {
                            isUpdateVisible = true;
                        }
                    }
                }
            }
            btnUpdate.Visible = isUpdateVisible;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("[");
                List<Student> students = new List<Student>();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    if (isChecked)
                    {
                        TextBox txtC = (TextBox)row.FindControl("txtC");
                        TextBox txtCPP = (TextBox)row.FindControl("txtCPP");
                        TextBox txtCS = (TextBox)row.FindControl("txtCS");

                        students.Add(new Student()
                        {
                            ID = row.Cells[1].Text,
                            C = txtC.Text,
                            CPP = txtCPP.Text,
                            CS = txtCS.Text
                        });

                        //sb.Append("{");
                        //sb.AppendFormat("\"ID\":\"{0}\",\"C\":\"{1}\",\"CPP\":\"{2}\",\"CS\":\"{3}\"", 
                        //row.Cells[1].Text, txtC.Text, txtCPP.Text, txtCS.Text);
                        //sb.Append("},");
                    }
                }

                //if (sb.ToString().Length > 1)
                if (students.Count > 0)
                {
                    //sb.Append("]");
                    //string inputData = sb.ToString();
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string inputData = serializer.Serialize(students);

                    string consString = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(consString))
                    {
                        SqlCommand cmd = new SqlCommand("spUpdateMarks", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inputJSON", inputData);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    btnUpdate.Visible = false;
                    lblMessage.Text = "Data updated successfully!";
                    LoadData();
                }
                else
                {
                    lblMessage.Text = "No value selected for update!";
                }
            }
            catch (SqlException ex)
            {
                lblMessage.Text = "error" + ex.ToString();
            }
        }


        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            DotNetNuke.Services.Mail.Mail.SendEmail(PortalSettings.Email, PortalSettings.Email, "_message.Subject", "_message.Body");
        }
        #endregion

        #region " Web Form Designer generated code "
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            //this.Load += new EventHandler(this.Page_Load);
            //this.Load += Page_Load;
        }

        #endregion

        #region " Optional Interfaces "

        ModuleActionCollection IActionable.ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                //Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.ContentOptions, LocalResourceFile), ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID(), Localization.GetString("ManageCategories", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditCat"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID(), Localization.GetString("ManageZipcodes", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditZip"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID, "Edit Alts", Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl("ItemId", "1", "EditAlt"), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
                /*
                OptionsInfo objOI = new OptionsInfo(ModuleId,TabId);
                if (IsEditable || (new OptionsInfo(ModuleId, TabId)).CanAdd) Actions.Add(GetNextActionID(), "Add", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanAlter) Actions.Add(GetNextActionID(), "Alter", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanApprove) Actions.Add(GetNextActionID(), "Approve", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanDelete) Actions.Add(GetNextActionID(), "Delete", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanSelfEdit) Actions.Add(GetNextActionID(), "SelfEdit", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Add", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Alter", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Approve", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Delete", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "SelfEdit", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                */
                return Actions;
            }
        }

        #endregion

    }//Views

    public class Student
    {
        public string ID { get; set; }
        public string C { get; set; }
        public string CPP { get; set; }
        public string CS { get; set; }
    }
}//bhattji.Modules.JsonUpdates
