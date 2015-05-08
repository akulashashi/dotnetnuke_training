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
using System.Web; 
using System.Web.Mail; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.ComponentModel;
using DotNetNuke.Common;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization; 
using bhattji.Modules.SalesReps.Business;
//Imports Microsoft.ScalableHosting.Security 
//Imports AspNetSecurity = Microsoft.ScalableHosting.Security 

namespace bhattji.Modules.SalesReps 
{ 
    
    public abstract partial class EditCategories : DotNetNuke.Entities.Modules.PortalModuleBase 
    { 
        
        #region " Private Members " 
        OptionsInfo objOI; 
        #endregion 
        
        #region " Public Members " 
        public bool Embeded; 
        #endregion 
        
        #region " Public Methods " 
        
        private void InitEveryTime() 
        { 
            //'this needs to execute always, even on Postback, to the client script code is registred in InvokePopupCal 
            //hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom) 
            //hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo) 
            
            //Bind the ObjectDataSource everytime, even on Postback 
            SetODS(); 
        } 
        
        private void InitFirstTime() 
        { 
            hypClose.Visible = !Embeded; 
            hypImgClose.Visible = hypClose.Visible; 
            
            if (hypClose.Visible) { 
                if (((Request.Params["ItemId"] != null)) || (Request.Params["ItemId"] != "")) { 
                    hypClose.NavigateUrl = EditUrl("ItemId", Request.QueryString["ItemId"]); 
                } 
                else { 
                    hypClose.NavigateUrl = Globals.NavigateURL(); 
                } 
                hypImgClose.NavigateUrl = hypClose.NavigateUrl; 
            } 
            
            ShowHide(); 
            SetGridView(); 
        } 
        
        
        private void SetODS() 
        { 
            { 
                odsSalesRepCategories.DataObjectTypeName = "bhattji.Modules.SalesReps.Business.CategoryInfo"; 
                odsSalesRepCategories.TypeName = "bhattji.Modules.SalesReps.Business.CategoriesController"; 
                odsSalesRepCategories.SelectMethod = "GetCategories"; 
                odsSalesRepCategories.InsertMethod = "AddCategory"; 
                odsSalesRepCategories.UpdateMethod = "UpdateCategory"; 
                odsSalesRepCategories.DeleteMethod = "DeleteCategory"; 
            } 
            //odsSalesRepCategories 
        } 
        //SetODS 
        public void ShowHide() 
        { 
           ShowHide(false);
        }
        public void ShowHide(bool InsertMode) 
        { 
            trAddCategory.Visible = InsertMode; 
            trManageCategories.Visible = !InsertMode; 
            //lnkAddLoadPU.Visible = Not InsertMode 
        } 
        //ShowHide(Optional ByVal InsertMode As Boolean = False) 
        
        public void SetGridView() 
        { 
            { 
                //.PageSize = objOI.PagerSize 
                //.AllowPaging = objOI.PagerSize > 0 
                gdvSalesRepCategories.Columns[0].Visible = IsEditable; 
                //Remove the First column if the User is not Admin 
                
                if (objOI.BackColor != string.Empty) { 
                    try { 
                        gdvSalesRepCategories.RowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor); 
                    } 
                    catch { 
                    } 
                } 
                if (objOI.AltColor != string.Empty) { 
                    try { 
                        gdvSalesRepCategories.AlternatingRowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.AltColor); 
                    } 
                    catch { 
                    } 
                } 
                
                if (objOI.HeaderBackColor != string.Empty) { 
                    try { 
                        gdvSalesRepCategories.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor); 
                        gdvSalesRepCategories.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor); 
                    } 
                    catch { 
                    } 
                } 
                if (objOI.PagerBackColor != string.Empty) { 
                    try { 
                        gdvSalesRepCategories.PagerStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.PagerBackColor); 
                    } 
                    catch { 
                    } 
                } 
            } 
            //gdvSalesRepCategories 
            
        } 
        
        #endregion 
        
        #region " Event Handlers " 
        
        private void Page_Load(object sender, EventArgs e) 
        { 
            try { 
                objOI = new OptionsInfo(ModuleId); 
                
                InitEveryTime(); 
                
                if (!Page.IsPostBack) { 
                    InitFirstTime(); 
                } 
            } 
            
            catch (Exception exc) { 
                //Module failed to load 
                Exceptions.ProcessModuleLoadException(this, exc); 
            } 
        } 
        
        private void gdvSalesRepCategories_RowCommand(object sender, GridViewCommandEventArgs e) 
        { 
            if (e.CommandName == "Add") { 
                ShowHide(true); 
            } 
        } 
        
        private void frmSalesRepCategories_ItemCommand(object sender, FormViewCommandEventArgs e) 
        { 
            ShowHide(); 
        } 
        
        private void gdvSalesRepCategories_RowDataBound(object sender, GridViewRowEventArgs e) 
        { 
            try { 
                if (e.Row.RowType == DataControlRowType.DataRow) { 
                    ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete"); 
                    
                    if ((imbDelete != null)) { 
                        { 
                            imbDelete.Visible = IsEditable; 
                            if (imbDelete.Visible) { 
                                //.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String)) 
                                imbDelete.ToolTip = "Delete"; 
                                imbDelete.Attributes.Add("onmouseover", "window.status=this.title; return true"); 
                                imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');"); 
                            } 
                        } 
                        //imbDelete 
                    } 
                    
                } 
            } 
            catch (Exception exc) { 
                //Module failed to RowDataBound 
                Exceptions.ProcessModuleLoadException(this, exc); 
            } 
            
        } 
        
        private void frmSalesRepCategories_ItemInserting(object sender, FormViewInsertEventArgs e) 
        { 
            try { 
                e.Values["ModuleId"] = ModuleId; 
                e.Values["Category"] = ((TextBox)frmSalesRepCategories.FindControl("txtCategory")).Text; 
                try { 
                    e.Values["ViewOrder"] = ((TextBox)frmSalesRepCategories.FindControl("txtViewOrder")).Text; 
                } 
                catch { 
                    e.Values["ViewOrder"] = -1; 
                } 
            } 
            catch { 
            } 
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
            gdvSalesRepCategories.RowCommand += new GridViewCommandEventHandler(gdvSalesRepCategories_RowCommand);
            frmSalesRepCategories.ItemCommand += new FormViewCommandEventHandler(frmSalesRepCategories_ItemCommand);
            gdvSalesRepCategories.RowDataBound += new GridViewRowEventHandler(gdvSalesRepCategories_RowDataBound);
            frmSalesRepCategories.ItemInserting += new FormViewInsertEventHandler(frmSalesRepCategories_ItemInserting);
            //this.Load += new EventHandler(this.Page_Load);

        }

        #endregion
        
    } 
    //EditCategories 
    
} 
//bhattji.Modules.SalesReps 
