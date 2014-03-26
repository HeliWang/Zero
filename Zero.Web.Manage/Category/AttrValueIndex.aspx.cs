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
    public partial class AttrValueIndex : Zero.Pages.ManagePage
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

            List<string> statusResult = BaseStatusCtrl.GetStatusHtml(status);
            this.searchStatus.Text = statusResult[0];
            this.selectStatus.Text = statusResult[1];
            this.targetStatus.Text = statusResult[2];

            StringBuilder condition = new StringBuilder("where 1=1");

            if (status != (int)BaseStatus.全部)
            {
                condition.AppendFormat("and status={0}", status);
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
                    case "valueId":
                        condition.AppendFormat(" and ValueId={0}", Utils.StrToInt(keyword));
                        break;
                    case "value":
                        condition.AppendFormat(" and Value='{0}'", keyword);
                        break;
                }
                this.keytype.Value = keytype;
                this.keyword.Value = keyword;

            }
            condition.AppendFormat(" order by ValueId desc");

            Paging paging = new Paging(30);
            this.DateList.DataSource = AttrValueService.GetAttrValueList(paging, condition.ToString());
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
                    AttrValueService.ChangeAttrValueStatus(ids, targetStatus);
                    break;

                case "delete":
                    AttrValueService.DeleteAttrValueList(ids);
                    break;

                default:
                    ErrorMsg.Append("没有符合的操作项目！"); return;
            }

            ErrorMsg.Append("操作成功！");
        }
    }
}