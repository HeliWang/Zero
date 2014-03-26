using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using Zero.Core.Web;
using Zero.Category.Model;
using Zero.Category.Bll;

namespace Zero.Web.Manage.Category
{
    public partial class CateAttrIndex : Zero.Pages.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RequestHelper.IsPost())
            {
                Operate();
            }

            Bind();

            if (ErrorMsg.Length > 0)
            {
                this.sysMessage.Text = GetClientScript(ErrorMsg.ToString());
            }
        }

        private void Bind()
        {
            int status = RequestHelper.QueryInt("searchStatus");
            string keytype = RequestHelper.Query("keytype");
            string keyword = RequestHelper.Query("keyword");
            int cateId = RequestHelper.QueryInt("cateList");

            List<string> statusResult = BaseStatusCtrl.GetStatusHtml(status);
            this.searchStatus.Text = statusResult[0];
            this.selectStatus.Text = statusResult[1];
            this.targetStatus.Text = statusResult[2];

            Dictionary<int, string> categoryList = CateService.GetCateDropList("cateList", 0, 0);
            this.cateList.DataSource = categoryList;
            this.cateList.DataValueField = "Key";
            this.cateList.DataTextField = "Value";
            this.cateList.DataBind();
            this.cateList.Items.Insert(0, new ListItem("请选择", ""));

            this.targetCateList.DataSource = categoryList;
            this.targetCateList.DataValueField = "Key";
            this.targetCateList.DataTextField = "Value";
            this.targetCateList.DataBind();

            StringBuilder condition = new StringBuilder("where 1=1");

            //if (status != (int)BaseStatus.全部)
            //{
            //    condition.AppendFormat("and status={0}", status);
            //}

            //if (cateId > 0)
            //{
            //    CategoryInfo categoryInfo = CategoryCtrl.GetCateInfo(cateId);
            //    if (categoryInfo != null)
            //    {
            //        condition.AppendFormat(" and Lid={0} and Rid={1}", categoryInfo.Lid, categoryInfo.Rid);
            //        this.cateList.Value = cateId.ToString();
            //    }
            //}

            if (cateId > 0)
            {
                condition.AppendFormat(" and CateId={0}", cateId);
                this.cateList.Value = cateId.ToString();
            }

            if (!string.IsNullOrEmpty(keytype) && !string.IsNullOrEmpty(keyword))
            {
                switch (keytype)
                {
                    case "attrId":
                        condition.AppendFormat(" and AttrId={0}", Utils.StrToInt(keyword));
                        break;
                    case "attr":
                        condition.AppendFormat(" and attr='{0}'", keyword);
                        break;
                }
                this.keytype.Value = keytype;
                this.keyword.Value = keyword;

            }
            condition.AppendFormat(" order by CateId asc,AttrId asc");

            Paging paging = new Paging(30);
            this.DateList.DataSource = CateAttrService.GetCateAttrList(paging, condition.ToString());
            this.DateList.DataBind();
            this.paging.Text = paging.GetHtml();
        }

        private void Operate()
        {
            string ids = RequestHelper.Form("ids");
            string action = RequestHelper.Form("action");

            if (string.IsNullOrEmpty(action))
            {
                ErrorMsg.Append("请选择操作项目！"); return;
            }

            if (string.IsNullOrEmpty(ids))
            {
                ErrorMsg.Append("请选择操作数据！"); return;
            }

            switch (action)
            {
                case "audit":
                    int targetStatus = RequestHelper.FormInt("targetStatus");
                    CateAttrService.ChangeCateAttrStatus(ids, targetStatus);
                    break;

                //case "selectCategory":
                //    int cateId = Requests.FormInt("targetCateList");
                //    CateAttrCtrl.ChangeCateAttrCate(ids, cateId);
                //    //先批量调取数据，验证属性名称是否重覆
                //    //最后修改状态

                //    break;

                case "delete":
                    CateAttrService.DeleteCateAttrList(ids);
                    break;

                default:
                    ErrorMsg.Append("没有符合的操作项目！"); return;
            }

            ErrorMsg.Append("操作成功！");
        }
    }
}