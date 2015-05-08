using System;
using System.Xml;
using DotNetNuke.Services.Search;
using DotNetNuke.Common.Utilities;
using System.Text;
using System.Collections;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Common;


namespace bhattji.Modules.XYZ70s
{
    public class XYZ70sController : ISearchable, IPortable, IUpgradeable
    {
        #region " Optional Interface(s) Implementation "
        #region " ISearchable Members "
        public SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {
            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();
            //IEnumerable<XYZ70Info> lotXYZ70s = GetModuleXYZ70s(ModInfo.ModuleID);
            ////XYZ70Info objXYZ70;
            //foreach (XYZ70Info objXYZ70 in lotXYZ70s)
            //{
            //    SearchItemInfo SearchItem;

            //    int UserId = objXYZ70.CreatedByUserId;

            //    string strContent = HttpUtility.HtmlDecode(((XYZ70Info)objXYZ70).Title + " " + ((XYZ70Info)objXYZ70).Description);
            //    string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(((XYZ70Info)objXYZ70).Description + " " + ((XYZ70Info)objXYZ70).Details), false), 100, "...");

            //    SearchItem = new SearchItemInfo(ModInfo.ModuleTitle + " - " + ((XYZ70Info)objXYZ70).Title, strDescription, UserId, ((XYZ70Info)objXYZ70).CreatedDate, ModInfo.ModuleID, ((XYZ70Info)objXYZ70).ItemId.ToString(), strContent, "ItemId=" + ((XYZ70Info)objXYZ70).ItemId.ToString(), Null.NullInteger);
            //    SearchItemCollection.Add(SearchItem);

            //}
            return SearchItemCollection;
        }
        #endregion //" ISearchable Members "
        #region " IPortable Members "
        public string ExportModule(int ModuleID)
        {
            OptionsInfo objOI = new OptionsInfo(ModuleID);
            StringBuilder sbXML = new StringBuilder();
            sbXML.Append("<XYZ70s>");
            
            //Export the Module Settings
            //Control Options
            sbXML.Append("<OnlyHostCanEdit>" + XmlUtils.XMLEncode(objOI.OnlyHostCanEdit.ToString()) + "</OnlyHostCanEdit>");
            /*CreateExportOptionStub*/
            sbXML.Append("<ThumbWidth>" + XmlUtils.XMLEncode(objOI.ThumbWidth) + "</ThumbWidth>");
            sbXML.Append("<RattleImage>" + XmlUtils.XMLEncode(objOI.RattleImage.ToString()) + "</RattleImage>");
            sbXML.Append("<PayPalId>" + XmlUtils.XMLEncode(objOI.PayPalId) + "</PayPalId>");
            
            sbXML.Append("<UpdatedByUserId>" + XmlUtils.XMLEncode(objOI.UpdatedByUserId.ToString()) + "</UpdatedByUserId>");
            sbXML.Append("<UpdatedByUser>" + XmlUtils.XMLEncode(objOI.UpdatedByUser) + "</UpdatedByUser>");
            sbXML.Append("<UpdatedDate>" + XmlUtils.XMLEncode(objOI.UpdatedDate.ToString()) + "</UpdatedDate>");

            //Option1 Options

            sbXML.Append("</XYZ70s>");

            return sbXML.ToString();

        }
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            XmlNode xmlXYZ70s = Globals.GetContent(Content, "XYZ70s");
            

            //Import the Module Settings
            ModuleController objModules = new ModuleController();
            OptionsInfo objOI = new OptionsInfo();

            //.ModuleID = ModuleID

            //Control Options
            try { objOI.OnlyHostCanEdit = bool.Parse(xmlXYZ70s.SelectSingleNode("OnlyHostCanEdit").InnerText); }catch { }
            /*CreateImportOptionStub*/
            try { objOI.ThumbWidth = xmlXYZ70s.SelectSingleNode("ThumbWidth").InnerText; }catch { }
            try { objOI.RattleImage = bool.Parse(xmlXYZ70s.SelectSingleNode("RattleImage").InnerText); }catch { }
            try{objOI.PayPalId = xmlXYZ70s.SelectSingleNode("PayPalId").InnerText;}catch{}
            try{objOI.UpdatedByUserId = int.Parse(xmlXYZ70s.SelectSingleNode("UpdatedByUserId").InnerText);}catch{}
            try{objOI.UpdatedByUser = xmlXYZ70s.SelectSingleNode("UpdatedByUser").InnerText;}catch{}
            try { objOI.UpdatedDate = DateTime.Parse(xmlXYZ70s.SelectSingleNode("UpdatedDate").InnerText); }catch { }
            
            objOI.Update(ModuleID);
        }
        #endregion //" IPortable Members "
        #region " IUpgradeable Members "
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Implements the upgrade interface for DotNetNuke
        /// </summary>
        /// <history>
        /// [scullmann] 12/30/2005 First Implementation
        /// </history>
        /// -----------------------------------------------------------------------------
        public string UpgradeModule(string Version)
        {
            InitPermissions();
            //SetPortalSettings();
            return Version;
        }

        private void SetPortalSettings()
        {
            PortalController.UpdatePortalSetting(0, "ControlPanelSecurity", "TAB");
            PortalController.UpdatePortalSetting(0, "ControlPanelVisibility", "MIN");
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// adds the module specific permissions
        /// </summary>
        /// <history>
        /// [scullmann] 12/30/2005 First Implementation
        /// </history>
        /// -----------------------------------------------------------------------------
        private void InitPermissions()
        {
            //Definition
            string ModuleFriendlyName = "bhattji.XYZ70s";
            string ModuleName = "bhattji.XYZ70s";

            //Permissions
            string Code = "bhattji.XYZ70s_PERMISSION";
            string[] permissionKeys = new string[6] { "ADD", "ALTER", "APPROVE", "CONFIGURE", "DELETE", "SELFEDIT" };
            string[] permissionNames = new string[6] { "Add XYZ70", "Alter XYZ70", "Approve XYZ70", "Configure XYZ70", "Delete XYZ70", "SelfEdit XYZ70" };

            //PermissionFlags
            PermissionController pc = new PermissionController();
            ArrayList permissions = pc.GetPermissionByCodeAndKey(Code, null);
            DesktopModuleController dc = new DesktopModuleController();
            DesktopModuleInfo desktopInfo = dc.GetDesktopModuleByModuleName(ModuleName);
            ModuleDefinitionController mc = new ModuleDefinitionController();
            ModuleDefinitionInfo mInfo = ModuleDefinitionController.GetModuleDefinitionByFriendlyName(ModuleFriendlyName, desktopInfo.DesktopModuleID);
            int moduleDefId = mInfo.ModuleDefID;

            for (int i = 0; i < permissionKeys.GetLength(0); i++)
            {
                foreach (PermissionInfo p in permissions)
                {
                    if ((p.ModuleDefID == moduleDefId) && (p.PermissionKey == permissionKeys[i]))
                    {
                        permissionKeys[i] = "permissionExists";
                        break;
                    }
                }
                if (permissionKeys[i] != "permissionExists")
                {
                    PermissionInfo p = new PermissionInfo();
                    p.ModuleDefID = moduleDefId;
                    p.PermissionCode = Code;
                    p.PermissionKey = permissionKeys[i];//"MODERATEPOSTS";
                    p.PermissionName = permissionNames[i];//"Moderate Posts";
                    pc.AddPermission(p);
                }
            }
        }//InitPermissions

        #endregion //" IUpgradeable Members "
        #endregion //" Optional Interface(s) Implementation "
    } //XYZ70sController
} //bhattji.Modules.XYZ70s