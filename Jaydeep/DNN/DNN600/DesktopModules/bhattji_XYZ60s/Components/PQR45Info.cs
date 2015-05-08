using System.Data;
using System;
using System.Text;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.Providers;
using bhattji.Modules.XYZ60s.PetaPoco;
using System.Collections.Generic;

namespace bhattji.Modules.XYZ60s
{
    [Serializable]
    [TableName("bhattji_XYZ60PQR45s")]
    [PrimaryKey("ItemId")]
    public class PQR45Info
    {
        #region " Properties "

        public int ItemId { get; set; }
        public int XYZ60Id { get; set; }
        [ResultColumn]
        public string XYZ60Title { get; set; }
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
        private StringBuilder GetSearchSql(int XYZ60Id, string SearchText, bool StartsWith)
        {
            string strSearchText = (StartsWith ? SearchText + "%" : "%" + SearchText + "%").ToString();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT x.ItemId, x.XYZ60Id, ");
            sbSql.Append("'XYZ60Title' = p.Title, ");
            sbSql.Append("x.PQR45, x.ViewOrder ");

            sbSql.Append("FROM " + GetDboName("XYZ60PQR45s") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ60s") + " As p on x.XYZ60Id = p.ItemId ");

            sbSql.Append("WHERE (x.XYZ60Id = " + XYZ60Id.ToString() + ") ");
            if (!string.IsNullOrEmpty(SearchText))
            {
                sbSql.Append("AND (x.PQR45 LIKE '" + strSearchText + "') ");
            }
            sbSql.Append("ORDER BY x.XYZ60Id, x.ViewOrder, x.PQR45 ");

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
            return Convert.ToInt32(db.Insert(GetDboName("XYZ60PQR45s"), "ItemId", objPQR45));
        }

        public int UpdatePQR45(PQR45Info objPQR45)
        {
            return db.Update(GetDboName("XYZ60PQR45s"), "ItemId", objPQR45);
        }

        public int DeletePQR45(PQR45Info objPQR45)
        {
            return db.Delete(GetDboName("XYZ60PQR45s"), "ItemId", objPQR45);
        }

        public int DeletePQR45(int ItemID)
        {
            return db.Delete(GetDboName("XYZ60PQR45s"), "ItemId", null, ItemID);
        }


        public PQR45Info GetPQR45(int ItemID)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT x.ItemId, x.XYZ60Id, ");
            sbSql.Append("'XYZTitle' = p.Title, ");
            sbSql.Append("x.PQR45, x.ViewOrder ");
            sbSql.Append("FROM " + GetDboName("XYZ60PQR45s") + " AS x ");
            sbSql.Append("LEFT OUTER JOIN " + GetDboName("XYZ60s") + " AS p on x.XYZ60Id = p.ItemId ");
            sbSql.Append("WHERE x.ItemID = " + ItemID.ToString());

            return db.SingleOrDefault<PQR45Info>(sbSql.ToString());
        }
        public Page<PQR45Info> GetSearchedPQR45s(int XYZ60Id, string SearchText, bool StartsWith, int PageIndex, int PageSize)
        {
            StringBuilder sbSql = GetSearchSql(XYZ60Id, SearchText, StartsWith);
            return db.Page<PQR45Info>(PageIndex, PageSize, sbSql.ToString());

        }//GetSearchedPQR45s
        public IEnumerable<PQR45Info> GetFullPQR45s(int XYZ60Id)
        {
            StringBuilder sbSql = GetSearchSql(XYZ60Id, "",false);
            return db.Query<PQR45Info>(sbSql.ToString());
        }//GetSearchedPQR45s
        #endregion

        #region " Userful Stored Procedures "
        public int SetViewOrderPQR45s(int XYZ60Id)
        {
            //DataProvider.Instance().ExecuteNonQuery(GetDboName("SetViewOrderXYZ60PQR45s"), XYZ60Id);
            string strSP = ";EXEC " + GetDboName("SetViewOrderXYZ60PQR45s") + " @0";
            return db.Execute(strSP, XYZ60Id);
        }
        public int ClaimOrphanPQR45s(int XYZ60Id)
        {
            //DataProvider.Instance().ExecuteNonQuery(GetDboName("ClaimOrphanXYZ60PQR45s"), XYZ60Id);
            string strSP = ";EXEC " + GetDboName("ClaimOrphanXYZ60PQR45s") + " @0";
            return db.Execute(strSP, XYZ60Id);
        }
        #endregion
    } //PQR45sController

} //bhattji.Modules.XYZ60s
