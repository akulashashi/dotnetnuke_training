using System.Data;
using System;
using System.Text;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.Providers;
using bhattji.Modules.XYZ70s.PetaPoco;
using System.Collections.Generic;

namespace bhattji.Modules.XYZ70s
{
    [Serializable]
    [TableName("bhattji_XYZ70PQR45s")]
    [PrimaryKey("ItemId")]
    public class PQR45Info
    {
        #region " Properties "

        public int ItemId { get; set; }
        public int XYZ70Id { get; set; }
        [ResultColumn]
        public string XYZ70Title { get; set; }
        public string PQR45 { get; set; }
        public int? ViewOrder { get; set; }
        [Ignore]
        public string ViewOrderString
        {
            get
            {
                return ViewOrder > 0 ? ViewOrder.ToString() : string.Empty;
            }
            set
            {
                try{ViewOrder = Convert.ToInt32(value);}catch {}
            }
        }

        #endregion
    }//PQR45Info

    public partial class PQR45sController : CommonControllerMethods
    {
        #region " Private Members "
        private StringBuilder GetSearchSql(int XYZ70Id, string SearchText, bool StartsWith)
        {
            string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT x.ItemId, x.XYZ70Id, ");
            sbSql.Append("'XYZ70Title' = p.Title, ");
            sbSql.Append("x.PQR45, x.ViewOrder ");

            sbSql.Append("FROM " + GetDboName("XYZ70PQR45s") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ70s") + " As p on x.XYZ70Id = p.ItemId ");

            sbSql.Append("WHERE (x.XYZ70Id = " + XYZ70Id.ToString() + ") ");
            if (!string.IsNullOrEmpty(SearchText))
            {
                sbSql.Append("AND (x.PQR45 LIKE '" + strSearchText + "') ");
            }
            sbSql.Append("ORDER BY x.XYZ70Id, x.ViewOrder, x.PQR45 ");

            return sbSql;
        }
        #endregion
        #region " Public Methods "
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
            return Convert.ToInt32(db.Insert(GetDboName("XYZ70PQR45s"), "ItemId", objPQR45));
        }

        public int UpdatePQR45(PQR45Info objPQR45)
        {
            return db.Update(GetDboName("XYZ70PQR45s"), "ItemId", objPQR45);
        }

        public int DeletePQR45(PQR45Info objPQR45)
        {
            return db.Delete(GetDboName("XYZ70PQR45s"), "ItemId", objPQR45);
        }

        public int DeletePQR45(int ItemID)
        {
            return db.Delete(GetDboName("XYZ70PQR45s"), "ItemId", null, ItemID);
        }


        public PQR45Info GetPQR45(int ItemID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT x.ItemId, x.XYZ70Id, ");
            sbSql.Append("'XYZTitle' = p.Title, ");
            sbSql.Append("x.PQR45, x.ViewOrder ");
            sbSql.Append("FROM " + GetDboName("XYZ70PQR45s") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ70s") + " AS p on x.XYZ70Id = p.ItemId ");
            sbSql.Append("WHERE x.ItemID = " + ItemID.ToString());

            return db.SingleOrDefault<PQR45Info>(sbSql.ToString());
        }
        public Page<PQR45Info> GetSearchedPQR45s(int XYZ70Id, string SearchText, bool StartsWith, int PageIndex, int PageSize)
        {
            StringBuilder sbSql = GetSearchSql(XYZ70Id, SearchText, StartsWith);
            return db.Page<PQR45Info>(PageIndex, PageSize, sbSql.ToString());

        }//GetSearchedPQR45s
        public IEnumerable<PQR45Info> GetFullPQR45s(int XYZ70Id)
        {
            StringBuilder sbSql = GetSearchSql(XYZ70Id, "",false);
            return db.Query<PQR45Info>(sbSql.ToString());
        }//GetSearchedPQR45s
        #endregion

        #region " Userful Stored Procedures "
        public int SetViewOrderPQR45s(int XYZ70Id)
        {
            //DataProvider.Instance().ExecuteNonQuery(GetDboName("SetViewOrderXYZ70PQR45s"), XYZ70Id);
            string strSP = ";EXEC " + GetDboName("SetViewOrderXYZ70PQR45s") + " @0";
            return db.Execute(strSP, XYZ70Id);
        }
        public int ClaimOrphanPQR45s(int XYZ70Id)
        {
            //DataProvider.Instance().ExecuteNonQuery(GetDboName("ClaimOrphanXYZ70PQR45s"), XYZ70Id);
            string strSP = ";EXEC " + GetDboName("ClaimOrphanXYZ70PQR45s") + " @0";
            return db.Execute(strSP, XYZ70Id);
        }
        #endregion
    } //PQR45sController

} //bhattji.Modules.XYZ70s
