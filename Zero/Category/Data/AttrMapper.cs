using System.Collections.Generic;
using Zero.Core.Web;
using Zero.Category.Model;
using PetaPoco;
using Zero.Orm;

namespace Zero.Category.Data
{
	public class AttrMapper : Mapper<AttrInfo>
	{
		/// <summary>
		/// 更改状态
		/// </summary>
		/// <param name="ids"></param>
		/// <param name="status"></param>
		public void ChangeStatus(string ids, int status)
		{
			string sql = string.Format("update [Attr] set status={0} where AttrId in ({1})", status, ids);
			db.Execute(sql);
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="ids"></param>
        public void DeleteList(string ids)
		{
			string sql = string.Format("delete [Attr] where AttrId in ({0})", ids);
			db.Execute(sql);
		}

		/// <summary>
		/// 判断是否存在同名
		/// </summary>
		/// <param name="AttrName"></param>
		/// <returns></returns>
		public bool Exist(string attr)
		{
			return db.Exists<AttrInfo>("Attr=@0", attr);
		}

		/// <summary>
		/// 判断是否存在同名
		/// </summary>
		/// <param name="AttrId"></param>
		/// <param name="AttrName"></param>
		/// <returns></returns>
		public bool Exist(int attrId, string attr)
		{
			return db.Exists<AttrInfo>("AttrId<>@0 and Attr=@1", attrId, attr);
		}
	}
}
