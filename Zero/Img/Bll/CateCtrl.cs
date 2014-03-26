using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Zero.Img.Model;
using Zero.Category.Bll;


namespace Zero.Img.Bll
{
    public class CateCtrl
    {
        //public static CateBaseService<CateInfo> cateBaseCtrl = new CateBaseService<CateInfo>("[Attachment_Cate]");

        ///// <summary>
        ///// 添加类别
        ///// </summary>
        //public static void AddCateInfo(string cateName, int pid)
        //{
        //    cateBaseCtrl.AddCateInfo(cateName, pid);
        //}

        ///// <summary>
        ///// 更新类别信息
        ///// </summary>
        //public static void UpdateCateInfo(int cateId, string cateName)
        //{
        //    cateBaseCtrl.UpdateCateInfo(cateId, cateName);
        //}

        ////删除类别
        //public static void DeleteCateInfo(int cateId)
        //{
        //    cateBaseCtrl.DeleteCateInfo(cateId);
        //}

        ///// <summary>
        ///// 修改所属类别
        ///// </summary>
        //public static void ChangeCateParent(int cateId, int pid)
        //{
        //    cateBaseCtrl.ChangeCateParent(cateId, pid);
        //}

        ///// <summary>
        ///// 判断是否存在此类别
        ///// </summary>
        //public static bool ExistCateId(int cateId)
        //{
        //    return cateBaseCtrl.ExistCateId(cateId);
        //}

        ///// <summary>
        ///// 判断同一父节点并且同级别的类目是否出现同名
        ///// </summary>
        //public static bool ExistCateName(string cateName, int pid, int depth)
        //{
        //    return cateBaseCtrl.ExistCateName(cateName, pid, depth);
        //}

        ///// <summary>
        ///// 判断同一父节点并且同级别的类目是否出现同名
        ///// </summary>
        //public static bool ExistCateName(int cateId, string cateName, int pid, int depth)
        //{
        //    return cateBaseCtrl.ExistCateName(cateId, cateName, pid, depth);
        //}

        ///// <summary>
        ///// 获取类别信息
        ///// </summary>
        //public static CateInfo GetCateInfo(int cateId)
        //{
        //    return cateBaseCtrl.GetCateInfo(cateId);
        //}

        ///// <summary>
        ///// 获取父亲类别 ，倒序 , 第一个为最亲近的父亲节点
        ///// </summary>
        //public static List<CateInfo> GetCateParent(int cateId)
        //{
        //    return cateBaseCtrl.GetCateParent(cateId);
        //}

        ///// <summary>
        ///// 获取类别的路径 
        ///// </summary>
        //public static List<CateInfo> GetCatePath(int cateId)
        //{
        //    return cateBaseCtrl.GetCatePath(cateId);
        //}

        ///// <summary>
        ///// 获取类别列表 (depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        ///// </summary>
        //public static List<CateInfo> GetCateList(int cateId, int depth)
        //{
        //    return cateBaseCtrl.GetCateList(cateId, depth);
        //}

        ///// <summary>
        ///// 获取分类下拉列表(depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        ///// </summary>
        //public static string GetCateDropList(string controlName, int cateId, int depth, int selectValue)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    List<CateInfo> list = GetCateList(cateId, depth);

        //    sb.AppendFormat("<select id=\"{0}\" name=\"{0}\">\n", controlName);
        //    sb.AppendFormat("<option value=\"0\">请选择分类</option>\n");

        //    foreach (CateInfo info in list)
        //    {
        //        string sign = string.Empty;
        //        string selected = string.Empty;

        //        if (info.Depth > 1)
        //        {

        //            for (int i = 1; i < info.Depth; i++)
        //            {
        //                sign += "&nbsp;&nbsp;&nbsp;";
        //            }

        //            info.CateName = sign + "|-" + "&nbsp;" + info.CateName;
        //        }

        //        if (info.CateId == selectValue)
        //        {
        //            selected = "selected";
        //        }

        //        sb.AppendFormat("<option value=\"{0}\" {1}>{2}</option>\n", info.CateId, selected, info.CateName);
        //    }

        //    sb.AppendFormat("</select>");
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// 获取分类下拉列表(depth=-1为自身，depth=0 为所有子节点 , depth>0为指定深度的子节点)
        ///// </summary>
        //public static Dictionary<int, string> GetCateDropList(string controlName, int cateId, int depth)
        //{
        //    Dictionary<int, string> list = new Dictionary<int, string>();
        //    List<CateInfo> catelist = GetCateList(cateId, depth);

        //    foreach (CateInfo info in catelist)
        //    {
        //        string sign = string.Empty;
        //        string selected = string.Empty;

        //        if (info.Depth > 1)
        //        {
        //            for (int i = 1; i < info.Depth; i++)
        //            {
        //                sign += "&nbsp;&nbsp;&nbsp;";
        //            }

        //            info.CateName = HttpUtility.HtmlDecode(sign + "|-" + "&nbsp;") + info.CateName;
        //        }

        //        list.Add(info.CateId, info.CateName);
        //    }
        //    return list;
        //}
    }
}
