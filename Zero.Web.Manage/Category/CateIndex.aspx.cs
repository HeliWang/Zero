using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zero.Core.Web;
using Zero.Category.Bll;

namespace Zero.Web.Manage.Category
{
    public partial class CateIndex :Zero.Pages.ManagePage
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
            List<Zero.Category.Model.CateInfo> list = CateService.GetCateList(0, 0);
            this.DataList.DataSource = list;
            this.DataList.DataBind();
        }

        private void Operate()
        {
            int id = RequestHelper.FormInt("ids");
            string action = RequestHelper.Form("action");

            if (string.IsNullOrEmpty(action))
            {
                ErrorMsg.Append("请选择操作项目！"); return;
            }

            if (id <= 0)
            {
                ErrorMsg.Append("请选择操作数据！"); return;
            }

            switch (action)
            {
                case "delete":
                    CateService.DeleteCateInfo(id);
                    break;

                default:
                    ErrorMsg.Append("没有符合的操作项目！"); return;
            }

            ErrorMsg.Append("操作成功！");
        }
    }
}