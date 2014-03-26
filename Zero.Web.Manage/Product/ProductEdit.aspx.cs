using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zero.Core.Web;
using Zero.Category.Model;
using Zero.Category.Bll;

namespace Zero.Web.Manage.Product
{
    public partial class ProductEdit :Zero.Pages.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int productId = RequestHelper.QueryInt("productId");

            if (!IsPostBack)
            {
                if (productId > 0)
                {
                    EidtInit(productId);
                }
                else
                {
                    AddInit();
                }
            }
            else
            {
                if (productId > 0)
                {
                    Edit(productId);
                }
                else
                {
                    Add();
                }
            }
        }

        private void AddInit()
        {
            this.tab.Text = "产品添加";

            this.cateList.DataSource = CateService.GetCateDropList("cateList", 0, 0);
            this.cateList.DataValueField = "Key";
            this.cateList.DataTextField = "Value";
            this.cateList.DataBind();
            this.cateList.Items.Insert(0, new ListItem("- 请选择分类 -", "0"));
        }

        private void EidtInit(int productId)
        {
            this.tab.Text = "产品修改";

            this.cateList.DataSource = CateService.GetCateDropList("cateList", 0, 0);
            this.cateList.DataValueField = "Key";
            this.cateList.DataTextField = "Value";
            this.cateList.DataBind();
        }

        private void Add()
        {
           
        }

        private void Edit(int productId)
        {
            
        }

        //private AdminInfo GetAddForm()
        //{
        //    AdminInfo info = new AdminInfo();
        //    FormItem<string> productNameItem = new FormItem<string>("productName", "帐号", 3, 15);
        //    FormItem<string> passwordItem = new FormItem<string>("password", "密码", 5, 10);
        //    FormItem<int> statusItem = new FormItem<int>("status", "状态", -100, 99999, 0);

        //    info.AdminName = productNameItem.GetFormValue(ErrorMsg);
        //    info.Password = passwordItem.GetFormValue(ErrorMsg);
        //    info.Status = statusItem.GetFormValue(ErrorMsg);
        //    info.Keyt = Zero.Core.Web.Utils.GetRandomEn(5);
        //    info.Password = Zero.Core.Security.Encrypt.EncodeMD5(info.Keyt + info.Password);
        //    return info;
        //}

        //private AdminInfo GetEditForm(AdminInfo info)
        //{
        //    FormItem<string> productNameItem = new FormItem<string>("productName", "帐号", 3, 15);
        //    FormItem<string> passwordItem = new FormItem<string>("password", "密码", 5, 10, "");
        //    FormItem<int> statusItem = new FormItem<int>("status", "状态", -100, 99999, 0);

        //    info.AdminName = productNameItem.GetFormValue(ErrorMsg);
        //    info.Password = passwordItem.GetFormValue(ErrorMsg);
        //    info.Status = statusItem.GetFormValue(ErrorMsg);
        //    info.UpdateTime = DateTime.Now;

        //    if (!string.IsNullOrEmpty(info.Password))
        //    {
        //        info.Keyt = Zero.Core.Web.Utils.GetRandomEn(5);
        //        info.Password = Zero.Core.Security.Encrypt.EncodeMD5(info.Keyt + info.Password);
        //    }
        //    return info;
        //}
    }
}