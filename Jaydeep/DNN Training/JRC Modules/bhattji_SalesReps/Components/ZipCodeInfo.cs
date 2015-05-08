//Imports System
using System.Data;
using System;
using System.Collections;
using System.Text;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
//Imports DotNetNuke.Data

namespace bhattji.Modules.SalesReps.Business
{

	public class ZipCodeInfo
	{
		//---------------------------------------------------------------------
		// TODO Declare BLL Class Info fields and property accessors
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		#region " Private Members "

		private int _ItemId;
		private string _ZipCode;
		private string _Area;
		private string _City;
		private string _StateCode;
		private string _State;
		private string _Display;

		#endregion

		#region " Properties "

		public int ItemId {
			get { return _ItemId; }
			set { _ItemId = value; }
		}

		public string ZipCode {
			get { return _ZipCode; }

			set { _ZipCode = value; }
		}

		public string Area {
			get { return _Area; }

			set { _Area = value; }
		}

		public string City {
			get { return _City; }

			set { _City = value; }
		}

		public string StateCode {
			get { return _StateCode; }

			set { _StateCode = value; }
		}

		public string State {
			get { return _State; }

			set { _State = value; }
		}

		public string Display {
			get { return _Display; }

			set { _Display = value; }
		}

		#endregion

		#region " Constructors "

		#endregion

	}
	//ZipCodeInfo

	public class ZipCodesController
	{
		//Implements Entities.Modules.ISearchable
		//Implements Entities.Modules.IPortable

		#region " Public Methods "

		private object GetNull(object Field)
		{
			return DotNetNuke.Common.Utilities.Null.GetNull(Field, System.DBNull.Value);
		}
        private string GetObjectQualifier()
        {
            DotNetNuke.Framework.Providers.ProviderConfiguration _providerConfiguration = DotNetNuke.Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data");
            DotNetNuke.Framework.Providers.Provider objProvider = (DotNetNuke.Framework.Providers.Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];
            string ObjectQualifier = objProvider.Attributes["objectQualifier"];
            if ((ObjectQualifier.Length > 0) && (!ObjectQualifier.EndsWith("_")))
            {
                ObjectQualifier += "_";
            }

            return ObjectQualifier;
        } //GetObjectQualifier
		private string GetPrefixedDbObjectName(string DbObjectName)
		{
			if (DbObjectName.StartsWith("bhattji_"))
			{
				return DbObjectName;
			}
			else
			{
				return "bhattji_" + DbObjectName;
			}
		}
		//GetPrefixedDbObjectName
		//---------------------------------------------------------------------
		// TODO Implement BLL methods
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		public int AddUpdateZipCode(ZipCodeInfo objZipCode)
		{
			if (objZipCode.ItemId > 0)
			{
				UpdateZipCode(objZipCode);
				return objZipCode.ItemId;
			}
			else
			{
				return AddZipCode(objZipCode);
			}
		}

		public int AddZipCode(ZipCodeInfo objZipCode)
		{
			{
                return Convert.ToInt32(DotNetNuke.Data.DataProvider.Instance().ExecuteScalar(GetPrefixedDbObjectName("AddZipCode"), GetNull(objZipCode.ZipCode), GetNull(objZipCode.Area), GetNull(objZipCode.City), GetNull(objZipCode.StateCode.ToUpper()), GetNull(objZipCode.State)));
			}
		}

		public void UpdateZipCode(ZipCodeInfo objZipCode)
		{
			{
				DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateZipCode"), objZipCode.ItemId, GetNull(objZipCode.ZipCode), GetNull(objZipCode.Area), GetNull(objZipCode.City), GetNull(objZipCode.StateCode.ToUpper()), GetNull(objZipCode.State));
			}
		}

		public void DeleteZipCode(ZipCodeInfo objZipCode)
		{
			DeleteZipCode(objZipCode.ItemId);
		}

		public void DeleteZipCode(int ItemId)
		{
			DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteZipCode"), ItemId);
		}


		public ZipCodeInfo GetZipCode(int ItemId)
		{
			return (ZipCodeInfo)DotNetNuke.Common.Utilities.CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetZipCode"), ItemId), typeof(ZipCodeInfo));
		}
		public ZipCodeInfo GetZipCode(string ZipCode)
		{
            return (ZipCodeInfo)DotNetNuke.Common.Utilities.CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetZipCodeByZipCode"), ZipCode), typeof(ZipCodeInfo));
		}

		//List(Of ZipCodeInfo) 'IDataReader
		public ArrayList GetZipCodes()
		{
            return DotNetNuke.Common.Utilities.CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetZipCodes")), typeof(ZipCodeInfo));
			//Return CBO.FillCollection(Of ZipCodeInfo)(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("bhattji_GetZipCodes"))
		}

        public ArrayList GetSearchedZipCodes(string SearchText)
		{
			return GetSearchedZipCodes(SearchText, "Any", 100);
		}
		//GetSearchedZipCodes

        public ArrayList GetSearchedZipCodes(string SearchText, string SearchOn)
		{
			return GetSearchedZipCodes(SearchText, SearchOn, 100);
		}
		//GetSearchedZipCodes

        //List(Of ZipCodeInfo) 'IDataReader 
        public ArrayList GetSearchedZipCodes(string SearchText, string SearchOn, int NoOfItems)
        {
            // Public Function GetSearchedZipCodes(ByVal SearchText As String, Optional ByVal SearchOn As String = "Any", Optional ByVal NoOfItems As Integer = 100) As ArrayList 'List(Of ZipCodeInfo) 'IDataReader 
            //Dim _providerConfiguration As Framework.Providers.ProviderConfiguration = Framework.Providers.ProviderConfiguration.GetProviderConfiguration("data") 
            //Dim objProvider As Framework.Providers.Provider = CType(_providerConfiguration.Providers[_providerConfiguration.DefaultProvider], Framework.Providers.Provider) 
            //Dim MyOjectQualifier As String = objProvider.Attributes["objectQualifier"] 
            //If (MyOjectQualifier.Length > 0) And (Not MyOjectQualifier.EndsWith("_")) Then 
            // MyOjectQualifier += "_" 
            //End If 
            string MyObjectQualifier = GetObjectQualifier();

            //string sbSql = string.Empty;
            StringBuilder sbSql = new StringBuilder();

            sbSql.Append("SELECT TOP " + NoOfItems.ToString() + " ");
            sbSql.Append("x.ItemId, ");
            sbSql.Append("x.ZipCode, ");
            sbSql.Append("x.Area, ");
            sbSql.Append("x.City, ");
            sbSql.Append("x.StateCode, ");
            sbSql.Append("sc.State, ");
            sbSql.Append("'Display'=x.City + ', ' + x.StateCode + ' ' + x.ZipCode ");

            sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("ZipCodes") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN " + MyObjectQualifier + GetPrefixedDbObjectName("StateCodes") + " AS sc ON x.StateCode=sc.StateCode ");

            switch (SearchOn.ToUpper())
            {
                case "ZIPCODE":
                    sbSql.Append("WHERE (x.ZipCode LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY x.ZipCode ");
                    break;

                case "AREA":
                    sbSql.Append("WHERE (x.Area LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY x.Area, x.City ");
                    break;

                case "CITY":
                    sbSql.Append("WHERE (x.City LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY x.City, x.Area ");
                    break;

                case "SATAE":
                    sbSql.Append("WHERE (sc.State LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY sc.State, x.City, x.Area ");
                    break;

                default:
                    //"ANY" 
                    sbSql.Append("WHERE (x.ZipCode LIKE '" + SearchText + "%') ");
                    sbSql.Append("OR (x.Area LIKE '" + SearchText + "%') ");
                    sbSql.Append("OR (x.City LIKE '" + SearchText + "%') ");
                    sbSql.Append("OR (sc.State LIKE '" + SearchText + "%') ");
                    sbSql.Append("ORDER BY sc.State, x.City, x.Area ");
                    break;

            }


            //Return DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql) 
            return DotNetNuke.Common.Utilities.CBO.FillCollection(DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString()), typeof(ZipCodeInfo));
            //Return CBO.FillCollection(Of ZipCodeInfo)(DotNetNuke.Data.DataProvider.Instance().ExecuteSQL(sbSql.ToString)) 
        }
        //GetSearchedZipCodes 

		#endregion

		#region " Optional Interfaces "

		//Public Function GetSearchItems(ByVal ModInfo As Entities.Modules.ModuleInfo) As Services.Search.SearchItemInfoCollection Implements Entities.Modules.ISearchable.GetSearchItems
		//    Dim SearchItemCollection As New SearchItemInfoCollection

		//    Dim ZipCodes As ArrayList = GetZipCodes(ModInfo.ModuleID)

		//    Dim objZipCode As Object
		//    For Each objZipCode In ZipCodes
		//        Dim SearchItem As SearchItemInfo
		//        With CType(objZipCode, ZipCodeInfo)
		//            '
		//            Dim UserId As Integer = Null.NullInteger
		//            If IsNumeric(.CreatedByUser) Then
		//                UserId = Integer.Parse(.CreatedByUser)
		//            End If
		//            SearchItem = New SearchItemInfo(ModInfo.ModuleTitle & " - " & .Title, .Description, UserId, .CreatedDate, ModInfo.ModuleID, .ItemId.ToString(), .Description, "ItemId=" & .ItemId.ToString(), Null.NullInteger)
		//            SearchItemCollection.Add(SearchItem)
		//        End With
		//    Next

		//    Return SearchItemCollection

		//End Function

		//Public Function ExportModule(ByVal ModuleID As Integer) As String Implements Entities.Modules.IPortable.ExportModule
		//    Dim settings As Hashtable = Entities.Portals.PortalSettings.GetModuleSettings(ModuleID)
		//    Dim strXML As String = ""
		//    strXML += "<ZipCodes>"

		//    'Export the Module Settings
		//    Dim objOI As New OptionsInfo(ModuleID)
		//    With objOI
		//        'Control Options
		//        strXML += "<ItemsScope>" & XMLEncode(.ItemsScope.ToString()) & "</ItemsScope>"
		//        strXML += "<ControlOption>" & XMLEncode(.ControlOption) & "</ControlOption>"

		//        'Option1 Options

		//        'Option2 Options

		//    End With

		//    'Export each ZipCode Details
		//    Dim arrZipCodes As ArrayList = GetZipCodes(ModuleID)
		//    If arrZipCodes.Count <> 0 Then
		//        Dim objZipCode As ZipCodeInfo
		//        For Each objZipCode In arrZipCodes
		//            With objZipCode
		//                strXML += "<ZipCode>"
		//                strXML += "<Title>" & XMLEncode(.Title) & "</Title>"
		//                strXML += "<NavURL>" & XMLEncode(.NavURL) & "</NavURL>"
		//                strXML += "<ImgSrc>" & XMLEncode(.ImgSrc) & "</ImgSrc>"
		//                strXML += "<ImgMoSrc>" & XMLEncode(.ImgMoSrc) & "</ImgMoSrc>"
		//                strXML += "<ImgBgSrc>" & XMLEncode(.ImgBgSrc) & "</ImgBgSrc>"
		//                strXML += "<ImgWidth>" & XMLEncode(.ImgWidth) & "</ImgWidth>"
		//                strXML += "<ImgHeight>" & XMLEncode(.ImgHeight) & "</ImgHeight>"
		//                strXML += "<ViewOrder>" & XMLEncode(.ViewOrder.ToString()) & "</ViewOrder>"
		//                strXML += "<Description>" & XMLEncode(.Description) & "</Description>"
		//                strXML += "<NewWindow>" & XMLEncode(.NewWindow.ToString()) & "</NewWindow>"
		//                strXML += "</ZipCode>"
		//            End With
		//        Next
		//    End If

		//    strXML += "</ZipCodes>"

		//    Return strXML

		//End Function

		//Public Sub ImportModule(ByVal ModuleID As Integer, ByVal Content As String, ByVal Version As String, ByVal UserId As Integer) Implements Entities.Modules.IPortable.ImportModule
		//    Dim xmlZipCodes As XmlNode = GetContent(Content, "ZipCodes")

		//    'Import the Module Settings
		//    Dim objModules As New Entities.Modules.ModuleController
		//    Dim objOI As New OptionsInfo
		//    With objOI
		//        'Control Options
		//        .ItemsScope = Integer.Parse(xmlZipCodes.SelectSingleNode("ItemsScope").InnerText)
		//        .ControlOption = xmlZipCodes.SelectSingleNode("ControlOption").InnerText

		//        'Option1 Options

		//        'Option2 Options


		//        .SaveOptionsInfo(ModuleID)
		//    End With

		//    'Import each ZipCode Details
		//    Dim xmlZipCode As XmlNode
		//    For Each xmlZipCode In xmlZipCodes.SelectNodes("ZipCode")
		//        Dim objZipCode As New ZipCodeInfo
		//        With objZipCode
		//            .ModuleId = ModuleID
		//            .Title = xmlZipCode.Item("title").InnerText
		//            .NavURL = ImportUrl(ModuleID, xmlZipCode.Item("NavURL").InnerText)
		//            .ImgSrc = ImportUrl(ModuleID, xmlZipCode.Item("ImgSrc").InnerText)
		//            .ImgMoSrc = ImportUrl(ModuleID, xmlZipCode.Item("ImgMoSrc").InnerText)
		//            .ImgBgSrc = ImportUrl(ModuleID, xmlZipCode.Item("ImgBgSrc").InnerText)
		//            .ImgWidth = ImportUrl(ModuleID, xmlZipCode.Item("ImgWidth").InnerText)
		//            .ImgHeight = ImportUrl(ModuleID, xmlZipCode.Item("ImgHeight").InnerText)
		//            .ViewOrder = Integer.Parse(xmlZipCode.Item("ViewOrder").InnerText)
		//            .Description = xmlZipCode.Item("Description").InnerText
		//            .NewWindow = Boolean.Parse(xmlZipCode.Item("NewWindow").InnerText)
		//            .CreatedByUser = UserId.ToString()
		//        End With

		//        AddZipCode(objZipCode)
		//    Next

		//End Sub

		#endregion

	}
	//ZipCodesController

}
//bhattji.Modules.SalesReps.Business
