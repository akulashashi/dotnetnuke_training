using System.Data;
using System;
using System.Text;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.Providers;

namespace bhattji.Modules.MyLogins
{
    [Serializable]
    public class PQR45Info : IHydratable
	{
		//---------------------------------------------------------------------
		// TODO Declare BLL Class Info fields and property accessors
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------

		#region " Private Members "
        //private int _ItemId;
        //private int _MyLoginId;
        private string _MyLoginTitle;

        //private string _PQR45;

        //private int _ViewOrder;
		#endregion

		#region " Properties "

		int IHydratable.KeyID {
			get { return ItemId; }
			set { ItemId = value; }
		}

        public int ItemId { get; set; }

        public int MyLoginId { get; set; }

		public string MyLoginTitle {get { return _MyLoginTitle; }}

        public string PQR45 { get; set; }

        public int ViewOrder { get; set; }

		#endregion

		#region " Optional IHydratable Implementation "

		void IHydratable.Fill(IDataReader dr)
		{
			ItemId = Convert.ToInt32(Null.SetNull(dr["ItemID"], ItemId));
			MyLoginId = Convert.ToInt32(Null.SetNull(dr["MyLoginId"], MyLoginId));
			_MyLoginTitle = Convert.ToString(Null.SetNull(dr["MyLoginTitle"], MyLoginTitle));
			PQR45 = Convert.ToString(Null.SetNull(dr["PQR45"], PQR45));

			ViewOrder = Convert.ToInt32(Null.SetNull(dr["ViewOrder"], ViewOrder));
		}

		#endregion

	}//PQR45Info

    public partial class PQR45sController
	{

		#region " Public Methods "
		private object GetNull(object Field)
		{
			return Null.GetNull(Field, DBNull.Value);
		} //GetNull
		private string GetObjectQualifier()
		{
			ProviderConfiguration _providerConfiguration = ProviderConfiguration.GetProviderConfiguration("data");
			Provider objProvider = (Provider)_providerConfiguration.Providers[_providerConfiguration.DefaultProvider];
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
		} //GetPrefixedDbObjectName

		//---------------------------------------------------------------------
		// TODO Implement BLL methods
		// You can use CodeSmith templates to generate this code
		//---------------------------------------------------------------------
		public int AddUpdatePQR45(PQR45Info objPQR45)
		{
			if (objPQR45.ItemId > 0)
			{
				UpdatePQR45(objPQR45);
				return objPQR45.ItemId;
			}
			else
			{
				return AddPQR45(objPQR45);
			}
		}

		public int AddPQR45(PQR45Info objPQR45)
		{
			{
                return DataProvider.Instance().ExecuteScalar<int>(GetPrefixedDbObjectName("AddMyLoginPQR45"), objPQR45.MyLoginId, objPQR45.PQR45, GetNull(objPQR45.ViewOrder));
			}
		}

		public void UpdatePQR45(PQR45Info objPQR45)
		{
			{
				DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("UpdateMyLoginPQR45"), objPQR45.ItemId, objPQR45.MyLoginId, objPQR45.PQR45, GetNull(objPQR45.ViewOrder));
			}
		}

		public void DeletePQR45(PQR45Info objPQR45)
		{
			DeletePQR45(objPQR45.ItemId);
		}

		public void DeletePQR45(int ItemID)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("DeleteMyLoginPQR45"), ItemID);
		}

		public void SetViewOrderPQR45s(int MyLoginId)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("SetViewOrderMyLoginPQR45s"), MyLoginId);
		}

		public void ClaimOrphanPQR45s(int MyLoginId)
		{
			DataProvider.Instance().ExecuteNonQuery(GetPrefixedDbObjectName("ClaimOrphanMyLoginPQR45s"), MyLoginId);
		}



		public PQR45Info GetPQR45(int ItemID)
		{
            return CBO.FillObject<PQR45Info>(DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetMyLoginPQR45"), ItemID));
		}

		//This function retreives the Items from Database,
		//depending upon the paramters supplied
		//If you supplied MyLoginId only, it gets GetMyLoginItems(MyLoginId)
		//If you supplied any MyLoginId, with PortalID only, it gets GetPortalItems(PortalID)
		//If you dont suppliy any parameter it gets GetAllItems()

		//List(Of PQR45Info) 'ArrayList 'IDataReader '
		public DataTable GetPQR45s()
		{
			return GetPQR45s("");
		}
		//List(Of PQR45Info) 'ArrayList 'IDataReader '
		public DataTable GetPQR45s(int MyLoginId)
		{
			return GetPQR45s("", false, MyLoginId);
		}
		public DataTable GetPQR45s(string SearchText)
		{
			return GetPQR45s(SearchText, false, -1);
		}
		//GetPQR45s
		//List(Of PQR45Info) 'ArrayList 'IDataReader '
		public DataTable GetPQR45s(string SearchText, bool StartsWith, int MyLoginId)
		{
	    	DataTable dt = new DataTable();
			dt.Load(GetPQR45sCommon(SearchText, StartsWith, MyLoginId));
			return dt;
		} //GetPQR45s

		public IDataReader GetPQR45sCommon(string SearchText)
		{
			return GetPQR45sCommon(SearchText, false, -1);
		} //GetPQR45sCommon

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetPQR45sCommon(string SearchText, bool StartsWith, int MyLoginId)
		{
			if (!string.IsNullOrEmpty(SearchText))
			{
				return GetSearchedPQR45s(SearchText, StartsWith, MyLoginId);
			}
			else
			{
				if (MyLoginId > -1)
				{
					return GetMyLoginPQR45s(MyLoginId);
				}
				else
				{
					return GetAllPQR45s();
				}
			}
		}//GetPQR45sCommon

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetMyLoginPQR45s(int MyLoginId)
		{
			return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetMyLoginPQR45s"), MyLoginId);
		}

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetAllPQR45s()
		{
            return DataProvider.Instance().ExecuteReader(GetPrefixedDbObjectName("GetAllMyLoginPQR45s"));
		}

		public IDataReader GetSearchedPQR45s(string SearchText)
		{
			return GetSearchedPQR45s(SearchText, false, -1);
		}
		//GetSearchedPQR45s

		//ArrayList 'List(Of PQR45Info) '
		public IDataReader GetSearchedPQR45s(string SearchText, bool StartsWith, int MyLoginId)
		{
			string MyObjectQualifier = GetObjectQualifier();

	    	string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();
            
            StringBuilder sbSql = new StringBuilder();

                sbSql.Append("SELECT ");
                //sbSql.Append("x.* " 
                sbSql.Append("x.ItemId, ");
                sbSql.Append("x.MyLoginId, ");
                sbSql.Append("'MyLoginTitle' = p.Title, ");
                sbSql.Append("x.PQR45, ");
                sbSql.Append("x.ViewOrder ");

                sbSql.Append("FROM " + MyObjectQualifier + GetPrefixedDbObjectName("MyLoginPQR45s") + " AS x ");
                sbSql.Append("LEFT OUTER JOIN [" + MyObjectQualifier + GetPrefixedDbObjectName("MyLogins") + "] As p on x.MyLoginId = p.ItemId ");

                sbSql.Append("WHERE (x.PQR45 LIKE '" + strSearchText + "') ");
                if (MyLoginId > 0)
                    sbSql.Append("AND (x.MyLoginId = " + MyLoginId.ToString() + ") ");

                sbSql.Append("ORDER BY x.MyLoginId, x.ViewOrder, x.PQR45 ");

                return DataProvider.Instance().ExecuteSQL(sbSql.ToString());

		}//GetSearchedPQR45s


		#endregion

	} //PQR45sController

} //bhattji.Modules.MyLogins
