using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zero.Core.Web;
using Zero.Category.Bll;
using Zero.Category.Model;

namespace Zero.Web.Manage.Category
{
    public partial class AttrEdit : Zero.Pages.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = RequestHelper.QueryInt("attrId");

            if (!IsPostBack)
            {
                if (id > 0)
                {
                    EidtInit(id);
                }
                else
                {
                    AddInit();
                }
            }
            else
            {
                if (id > 0)
                {
                    Edit(id);
                }
                else
                {
                    Add();
                }
            }
        }

        private void AddInit()
        {
            this.tab.Text = "添加属性";

            //this.cateList.DataSource = CategoryCtrl.GetCateDropList("cateList", 0, 0);  
            //this.cateList.DataValueField = "Key";
            //this.cateList.DataTextField = "Value";
            //this.cateList.DataBind();

            this.status.DataSource = BaseStatusCtrl.GetStatusList();
            this.status.DataValueField = "Key";
            this.status.DataTextField = "Value";
            this.status.DataBind();
        }

        private void EidtInit(int attrId)
        {
            this.tab.Text = "修改属性";

            //this.cateList.DataSource = CategoryCtrl.GetCateDropList("cateList", 0, 0);
            //this.cateList.DataValueField = "Key";
            //this.cateList.DataTextField = "Value";
            //this.cateList.DataBind();

            this.status.DataSource = BaseStatusCtrl.GetStatusList();
            this.status.DataValueField = "Key";
            this.status.DataTextField = "Value";
            this.status.DataBind();

            AttrInfo info = AttrService.GetAttrInfo(attrId);

            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }
            //this.cateList.Value = info.CateId.ToString();
            this.attr.Value = info.Attr;
            //this.type.Value = info.Type.ToString();
            //this.isMust.Value = info.IsMust.ToString();
            //this.isSale.Value = info.IsSale.ToString();
            this.status.Value = info.Status.ToString();
        }

        private void Add()
        {
            AttrInfo info = GetAddForm();

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            ////是否存在类别
            //if (!CategoryCtrl.ExistCateId(info.CateId))
            //{
            //    ShowError("无法找到所属分类！"); return;
            //}

            //不能存在同名
            if (AttrService.ExistAttr(info.Attr))
            {
                ShowError("该类别不能存在同名的属性名称！"); return;
            }

            AttrService.AddAttrInfo(info);

            ShowOK("操作成功！", "/category/attrIndex.aspx");
        }

        private void Edit(int cateId)
        {
            AttrInfo info = AttrService.GetAttrInfo(cateId);

            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }

            GetEditForm(info);

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            ////是否存在类别
            //if (!CategoryCtrl.ExistCateId(info.CateId))
            //{
            //    ShowError("无法找到所属分类！"); return;
            //}

            //不能存在同名
            if (AttrService.ExistAttr(info.AttrId, info.Attr))
            {
                ShowError("该类别不能存在同名的属性名称！"); return;
            }

            AttrService.UpdateAttrInfo(info);

            ShowOK("操作成功！", "/category/attrIndex.aspx");
        }

        private AttrInfo GetAddForm()
        {
            AttrInfo info = new AttrInfo();
            //FormItem<int> cateIdItem = new FormItem<int>("cateList", "请选择分类", 1, int.MaxValue);
            FormItem<string> attrItem = new FormItem<string>("attr", "属性名称", 0, 100);
            //FormItem<int> typeItem = new FormItem<int>("type", "属性类型", 0, 4);
            //FormItem<int> isMustItem = new FormItem<int>("isMust", "是否必须", 0, 1);
            //FormItem<int> isSaleItem = new FormItem<int>("isSale", "是否销售属性", 0, 1);
            FormItem<int> statusItem = new FormItem<int>("status", "状态", 0, 99999);

            //info.CateId = cateIdItem.GetFormValue(ErrorMsg);
            info.Attr = attrItem.GetFormValue(ErrorMsg);
            //info.Type = typeItem.GetFormValue(ErrorMsg);
            //info.IsMust = isMustItem.GetFormValue(ErrorMsg);
            //info.IsSale = isSaleItem.GetFormValue(ErrorMsg);
            //info.Status = statusItem.GetFormValue(ErrorMsg);
            return info;
        }

        private void GetEditForm(AttrInfo info)
        {
            //FormItem<int> cateIdItem = new FormItem<int>("cateList", "请选择分类", 1, int.MaxValue);
            FormItem<string> attrItem = new FormItem<string>("attr", "属性名称", 0, 100);
            //FormItem<int> typeItem = new FormItem<int>("type", "属性类型", 0, 4);
            //FormItem<int> isMustItem = new FormItem<int>("isMust", "是否必须", 0, 1);
            //FormItem<int> isSaleItem = new FormItem<int>("isSale", "是否销售属性", 0, 1);
            FormItem<int> statusItem = new FormItem<int>("status", "状态", 0, 99999);

            //info.CateId = cateIdItem.GetFormValue(ErrorMsg);
            info.Attr = attrItem.GetFormValue(ErrorMsg);
            //info.Type = typeItem.GetFormValue(ErrorMsg);
            //info.IsMust = isMustItem.GetFormValue(ErrorMsg);
            //info.IsSale = isSaleItem.GetFormValue(ErrorMsg);
            info.Status = statusItem.GetFormValue(ErrorMsg);
        }
    }
}