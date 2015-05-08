//
// DotNetNuke -  http://www.dotnetnuke.com
// Copyright (c) 2002-2005
// by Jaydeep Bhatt ( sales@bhattji.com ) of Vision Consultants. ( http://www.bhattji.com )
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
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

#region " Namespaces "
//Imports System
using System.Collections;
//Imports System.Configuration
//Imports System.Data
using System.Web.UI.WebControls;
using DotNetNuke;
using System;
using System.Web;
using System.IO;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Security.Permissions;
using System.Collections.Specialized;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
#endregion

namespace bhattji.Modules.Trackings
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Options Class provides the TabbedPages Business Object
    /// </summary>
    ///
    /// <remarks>
    /// </remarks>
    /// <history>
    /// 	[bhattji]	9/20/2004	Moved TabbedPages to a separate Project
    /// </history>
    /// -----------------------------------------------------------------------------
    /// 
    [Serializable]
    public class OptionsInfo : HybridDictionary //ListDictionary//Hashtable//NameValueCollection//
    {
        #region " Private Members "
        //Private ModSets As New Hashtable
        #endregion

        #region " Properties "

        private int _TabID;
        private int _ModuleID;
        public int ModuleID
        {
            get { return _ModuleID; }
            set { _ModuleID = value; }
        }

        //Tracking
        public string EventId
        {
            get { return GetString("EventId", "323606"); }
            set { SetString("EventId", value); }
        }

        public string OrgId
        {
            get { return GetString("OrgId", "1954300"); }
            set { SetString("OrgId", value); }
        }

        public string Currency
        {
            get { return GetString("Currency", "SEK"); }
            set { SetString("Currency", value); }
        }

        public string ProductName
        {
            get { return GetString("ProductName", "KURSID"); }
            set { SetString("ProductName", value); }
        }

        //Audit Control
        public int UpdatedByUserId
        {
            get { return GetInteger("UpdatedByUserId", 1); }
            set { SetString("UpdatedByUserId", value.ToString()); }
        }

        public string UpdatedByUser
        {
            get { return GetString("UpdatedByUser", "System Account"); }
            set { SetString("UpdatedByUser", value); }
        }

        public DateTime UpdatedDate
        {
            get { return GetDate("UpdatedDate", DateTime.Now); }
            //SetString("UpdatedDate", Now.ToString())
            set { SetString("UpdatedDate", value.ToString()); }
        }
        #endregion

        #region " Constructors "

        public OptionsInfo()
        {
            _TabID = -1;
            _ModuleID = -1;
        }

        public OptionsInfo(int ModuleId)
        {
            _TabID = -1;
            _ModuleID = ModuleId;
            Load(ModuleId);
        }

        public OptionsInfo(int ModuleId, int TabId)
        {
            _TabID = TabId;
            _ModuleID = ModuleId;
            Load(ModuleId);
        }

        #endregion

        #region " Private Methods "
        private void SetString(string OptionKey, string OptionValue)
        {
            if (this.Contains(OptionKey))
            {
                this[OptionKey] = OptionValue;
            }
            else
            {
                this.Add(OptionKey, OptionValue);
            }
        }

        private string GetString(string OptionKey, string FailSafe)
        {
            try
            {
                if (this.Contains(OptionKey))
                {
                    return (string)this[OptionKey];
                }
                else
                {
                    return FailSafe;
                }
            }
            catch
            {
                return FailSafe;
            }
        }

        private int GetInteger(string OptionKey, int FailSafe)
        {
            try
            {
                if (this.Contains(OptionKey))
                {
                    return Convert.ToInt32(this[OptionKey]);
                }
                else
                {
                    return FailSafe;
                }
            }
            catch
            {
                return FailSafe;
            }
        }

        private double GetDouble(string OptionKey, double FailSafe)
        {
            try
            {
                if (this.Contains(OptionKey))
                {
                    return (double)this[OptionKey];
                }
                else
                {
                    return FailSafe;
                }
            }
            catch
            {
                return FailSafe;
            }
        }

        private decimal GetDecimal(string OptionKey, decimal FailSafe)
        {
            try
            {
                if (this.Contains(OptionKey))
                {
                    return (decimal)this[OptionKey];
                }
                else
                {
                    return FailSafe;
                }
            }
            catch
            {
                return FailSafe;
            }
        }

        private bool GetBoolean(string OptionKey, bool FailSafe)
        {
            try
            {
                if (this.Contains(OptionKey))
                {
                    return Convert.ToBoolean(this[OptionKey]);
                }
                else
                {
                    return FailSafe;
                }
            }
            catch
            {
                return FailSafe;
            }
        }

        private DateTime GetDate(string OptionKey, DateTime FailSafe)
        {
            try
            {
                if (this.Contains(OptionKey))
                {
                    return (DateTime)this[OptionKey];
                }
                else
                {
                    return FailSafe;
                }
            }
            catch
            {
                return FailSafe;
            }
        }

        #endregion

        #region " Public Methods "

        public void Load(int ModuleId)
        {
            //Try
            if (ModuleId > -1)
            {
                //ModSets.Clear()
                Hashtable ModSets = (new ModuleController()).GetModuleSettings(ModuleId);
                //DictionaryEntry de;

                foreach (DictionaryEntry de in ModSets)
                {
                    try
                    {
                        //use the Key and Value properties. Note chr(9) is a tab
                        //Console.WriteLine("{0}" & Chr(9) & "{1}", d.Key, d.Value)
                        this.Add(de.Key, de.Value);
                    }
                    catch
                    {
                    }
                }
            }
            //Catch
            //End Try
        }

        public void Update(int ModuleId)
        {
            _ModuleID = ModuleId;
            Update();
        }

        public void Update()
        {
            if (ModuleID > -1)
            {
                ModuleController objMC = new ModuleController();
                //DictionaryEntry de;

                foreach (DictionaryEntry de in this)
                {
                    try
                    {
                        //use the Key and Value properties. Note chr(9) is a tab
                        //Console.WriteLine("{0}" & Chr(9) & "{1}", d.Key, d.Value)
                        objMC.UpdateModuleSetting(ModuleID, de.Key.ToString(), de.Value.ToString());
                    }
                    catch { }
                }
            }

        }

        //public string LinkClickUrlLegacy(string Link)
        //{
        //    string strLink = Link;

        //    switch (Globals.GetURLType(strLink))
        //    {
        //        case TabType.Tab:
        //            strLink = Globals.ApplicationPath + "/" + Globals.glbDefaultPage + "?tabid=" + Link;
        //            break;
        //        case TabType.File:
        //            PortalSettings _portalSettings = PortalController.GetCurrentPortalSettings();
        //            strLink = _portalSettings.HomeDirectory + Link;
        //            break;
        //    }

        //    return strLink;
        //}//LinkClickUrlLegacy
        public string LinkClickUrlLegacy(string Link)
        {
            switch (Globals.GetURLType(Link))
            {
                case TabType.Tab:
                    return Globals.ApplicationPath + "/" + Globals.glbDefaultPage + "?tabid=" + Link;
                case TabType.File:
                    return PortalController.GetCurrentPortalSettings().HomeDirectory + Link;
                default:
                    return Link;
            }
        }//LinkClickUrlLegacy
               
        public string MediaType(string MediaFilename)
        {
            switch (Path.GetExtension(MediaFilename).ToLower())
            {
                case ".gif":
                case ".jpg":
                case ".jpeg":
                case ".jpe":
                    return "Image";
                case ".swf":
                    return "Flash";
                case ".wmv":
                case ".mpeg":
                case ".mpg":
                case ".mov":
                    return "Movie";
                default:
                    return "Unknown";
            }
        }

        public bool IsImageFile(string Filename)
        {
            return MediaType(Filename).ToLower() == "image";
        }//IsImageFile
   
        public bool IsModuleItem(int ModId)
        {
            return _ModuleID == ModId;
        }

        public bool IsItemEditable(int ModId)
        {
            return DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo().IsSuperUser || IsModuleItem(ModId);
        }

        //public TrackingModuleBase GetPMB(string ControlSrc)
        //{
        //    return GetPMB(ControlSrc, "Edit");
        //}
        //public TrackingModuleBase GetPMB(string ControlSrc, string ControlType)
        //{
        //    if (ControlType.ToLower() == "view") 
        //        return GetViewControl(ControlSrc);
        //    else 
        //        return GetEditControl(ControlSrc);
        //}
        //public TrackingModuleBase GetViewControl(string ControlSrc)
        //{
        //    TrackingModuleBase MyPMB;
        //    switch (ControlSrc.ToLower())
        //    {
        //        case "grid":
        //            MyPMB = (ViewGrid)LoadControl(ControlPath + "ViewGrid.ascx");
        //            MyPMB.ID = "ViewGrid";
        //            break;

        //        case "catalog":
        //            MyPMB = (ViewCat)LoadControl(ControlPath + "ViewCat.ascx");
        //            MyPMB.ID = "ViewCat";
        //            break;

        //        case "jukes":
        //            MyPMB = (ViewJukes)LoadControl(ControlPath + "ViewJukes.ascx");
        //            MyPMB.ID = "ViewJukes";
        //            break;

        //        case "thumbs":
        //            MyPMB = (ViewThumbs)LoadControl(ControlPath + "ViewThumbs.ascx");
        //            MyPMB.ID = "ViewThumbs";
        //            break;

        //        case "tabs":
        //            MyPMB = (ViewTabs)LoadControl(ControlPath + "ViewTabs.ascx");
        //            MyPMB.ID = "ViewTabs";
        //            break;

        //        default:
        //            //"list"
        //            MyPMB = (ViewList)LoadControl(ControlPath + "ViewList.ascx");
        //            MyPMB.ID = "ViewList";
        //            break;
        //    }
        //    return MyPMB;
        //}
        //public TrackingModuleBase GetEditControl(string ControlSrc)
        //{
        //    TrackingModuleBase MyPMB;
        //    switch (ControlSrc.ToLower())
        //    {
        //        case "editcat":
        //            MyPMB = (ViewCategories)LoadControl(ControlPath + "ViewCategories.ascx");
        //            MyPMB.ID = "ViewCategories";
        //            //ModuleConfiguration.ModuleTitle = "Edit Categories";
        //            break;
        //        case "editzip":
        //            MyPMB = (ViewZipCodes)LoadControl(ControlPath + "ViewZipCodes.ascx");
        //            MyPMB.ID = "ViewZipCodes";
        //            //ModuleConfiguration.ModuleTitle = "Edit ZipCodes";
        //            break;
        //        default: //"edititem", "EditItem"
        //            MyPMB = (EditItem)LoadControl(ControlPath + "EditItem.ascx");
        //            MyPMB.ID = "EditItem";
        //            //ModuleConfiguration.ModuleTitle = "Edit Tracking";
        //            break;
        //    }
        //    return MyPMB;
        //}

        //public bool HasPermission(int moduleId, string permissionKey) {
        //    return HasPermission(moduleId, -1, permissionKey);
        //}
        //public static bool HasPermission(int moduleId, int tabId, string permissionKey)
        //{
        //    if (tabId > -1) { return ModulePermissionController.HasModulePermission(moduleId, tabId, permissionKey); }
        //    else { return ModulePermissionController.HasModulePermission(moduleId, permissionKey); }
        //}
        #endregion

    } //OptionsInfo

} //bhattji.Modules.Trackings
