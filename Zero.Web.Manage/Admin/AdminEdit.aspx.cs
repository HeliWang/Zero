using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zero.Core.Web;
using Zero.User.Bll;
using Zero.User.Model;

namespace Zero.Web.Manage.Admin
{
    public partial class AdminEdit : Zero.Pages.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int adminId = RequestHelper.QueryInt("adminId");

            if (!IsPostBack)
            {
                if (adminId > 0)
                {
                    EidtInit(adminId);
                }
                else
                {
                    AddInit();
                }
            }
            else
            {
                if (adminId > 0)
                {
                    Edit(adminId);
                }
                else
                {
                    Add();
                }
            }
        }

        private void AddInit()
        {
            this.status.Text = BaseStatusCtrl.GetSelectStatusHtml((int)BaseStatus.已通过);
        }

        private void EidtInit(int adminId)
        {
            AdminInfo info = AdminCtrl.GetAdminInfo(adminId);
            if (info == null)
            {
                ShowError("未找到相关的信息！"); return;
            }
            this.adminName.Value = info.AdminName;
            this.status.Text = BaseStatusCtrl.GetSelectStatusHtml(info.Status);
        }

        private void Add()
        {
            AdminInfo info = GetAddForm();

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            if (AdminCtrl.ExistAdminName(info.AdminName))
            {
                ShowError("已存在此用户名称！"); return;
            }

            AdminCtrl.AddAdminInfo(info);

            ShowOK("操作成功！", string.Format("/admin/adminIndex.aspx?searchStatus={0}", info.Status));
        }

        private void Edit(int adminId)
        {
            AdminInfo info = AdminCtrl.GetAdminInfo(adminId);

            if (info == null)
            {
                ShowError("未找到相关的用户信息！"); return;
            }

            GetEditForm(info);

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            if (AdminCtrl.ExistAdminName(info.AdminId, info.AdminName))
            {
                ShowError("已存在此用户名称！"); return;
            }

            AdminCtrl.UpdateAdminInfo(info);

            ShowOK("操作成功！", string.Format("/admin/adminIndex.aspx?searchStatus={0}", info.Status));
        }

        private AdminInfo GetAddForm()
        {
            AdminInfo info = new AdminInfo();
            FormItem<string> adminNameItem = new FormItem<string>("adminName", "帐号", 3, 15);
            FormItem<string> passwordItem = new FormItem<string>("password", "密码", 5, 10);
            FormItem<int> statusItem = new FormItem<int>("status", "状态", -100, 99999, 0);

            info.AdminName = adminNameItem.GetFormValue(ErrorMsg);
            info.Password = passwordItem.GetFormValue(ErrorMsg);
            info.Status = statusItem.GetFormValue(ErrorMsg);
            info.Keyt = Zero.Core.Web.Utils.GetRandomEn(5);
            info.Password = Zero.Core.Security.Encrypt.EncodeMD5(info.Keyt + info.Password);
            return info;
        }

        private AdminInfo GetEditForm(AdminInfo info)
        {
            FormItem<string> adminNameItem = new FormItem<string>("adminName", "帐号", 3, 15);
            FormItem<string> passwordItem = new FormItem<string>("password", "密码", 5, 10, "");
            FormItem<int> statusItem = new FormItem<int>("status", "状态", -100, 99999, 0);

            info.AdminName = adminNameItem.GetFormValue(ErrorMsg);
            info.Password = passwordItem.GetFormValue(ErrorMsg);
            info.Status = statusItem.GetFormValue(ErrorMsg);
            info.UpdateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(info.Password))
            {
                info.Keyt = Zero.Core.Web.Utils.GetRandomEn(5);
                info.Password = Zero.Core.Security.Encrypt.EncodeMD5(info.Keyt + info.Password);
            }
            return info;
        }
    }
}