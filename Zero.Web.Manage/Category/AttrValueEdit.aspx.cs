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
    public partial class AttrValueEdit : Zero.Pages.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = RequestHelper.QueryInt("valueId");

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
            this.tab.Text = "添加属性值";

            this.status.DataSource = BaseStatusCtrl.GetStatusList();
            this.status.DataValueField = "Key";
            this.status.DataTextField = "Value";
            this.status.DataBind();

            string attrId = RequestHelper.Query("attrId");
            string attr = RequestHelper.Query("attr");

            if (!string.IsNullOrEmpty(attrId) && !string.IsNullOrEmpty(attr))
            {
                this.attrId.Value = attrId.ToString();
                this.attr.Value = string.Format("{0} | {1}", attrId, attr);
            }
        }

        private void EidtInit(int valueId)
        {
            this.tab.Text = "修改属性值";

            this.status.DataSource = BaseStatusCtrl.GetStatusList();
            this.status.DataValueField = "Key";
            this.status.DataTextField = "Value";
            this.status.DataBind();

            AttrValueInfo info = AttrValueService.GetAttrValueInfo(valueId);

            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }
            this.value.Value = info.Value;
            this.oid.Value = info.Oid.ToString();
            this.status.Value = info.Status.ToString();

            string attrId = RequestHelper.Query("attrId");
            string attr = RequestHelper.Query("attr");

            if (!string.IsNullOrEmpty(attrId) && !string.IsNullOrEmpty(attr))
            {
                this.attrId.Value = attrId.ToString();
                this.attr.Value = string.Format("{0} | {1}", attrId, attr);
            }
        }

        private void Add()
        {
            AttrValueInfo info = GetAddForm();

            //表单验证结果
            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            //不存在属性
            if (info.AttrId > 0 && !AttrService.ExistAttr(info.AttrId))
            {
                ShowError("不存在此属性！"); return;
            }

            //不能存在同名
            if (AttrValueService.ExistAttrValue(info.Value))
            {
                ShowError("已存在此同名的属性值！"); return;
            }

            AttrValueService.AddAttrValueInfo(info);

            ShowOK("操作成功！", "/category/attrValueIndex.aspx");
        }

        private void Edit(int cateId)
        {
            AttrValueInfo info = AttrValueService.GetAttrValueInfo(cateId);

            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }

            GetEditForm(info);

            //表单验证结果
            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            //不存在属性
            if (info.AttrId > 0 && !AttrService.ExistAttr(info.AttrId))
            {
                ShowError("不存在此属性！"); return;
            }

            //不能存在同名
            if (AttrValueService.ExistAttrValue(info.ValueId, info.Value))
            {
                ShowError("已存在此同名的属性值！"); return;
            }

            AttrValueService.UpdateAttrValueInfo(info);

            ShowOK("操作成功！", "/category/attrValueIndex.aspx");
        }

        private AttrValueInfo GetAddForm()
        {
            AttrValueInfo info = new AttrValueInfo();
            FormItem<string> valueItem = new FormItem<string>("value", "属性值", 0, 100);
            FormItem<int> attrIdItem = new FormItem<int>("attrId", "所属属性", 0, int.MaxValue);
            FormItem<int> oidItem = new FormItem<int>("oid", "排序编号", 0, 100000);
            FormItem<int> statusItem = new FormItem<int>("status", "状态", 0, 100000);

            info.Value = valueItem.GetFormValue(ErrorMsg);
            info.AttrId = attrIdItem.GetFormValue(ErrorMsg);
            info.Oid = oidItem.GetFormValue(ErrorMsg);
            info.Status = statusItem.GetFormValue(ErrorMsg);
            return info;
        }

        private void GetEditForm(AttrValueInfo info)
        {
            FormItem<string> valueItem = new FormItem<string>("value", "属性值", 0, 100);
            FormItem<int> attrIdItem = new FormItem<int>("attrId", "所属属性", 0, int.MaxValue);
            FormItem<int> oidItem = new FormItem<int>("oid", "排序编号", 0, 100000);
            FormItem<int> statusItem = new FormItem<int>("status", "状态", 0, 100000);

            info.Value = valueItem.GetFormValue(ErrorMsg);
            info.AttrId = attrIdItem.GetFormValue(ErrorMsg);
            info.Oid = oidItem.GetFormValue(ErrorMsg);
            info.Status = statusItem.GetFormValue(ErrorMsg);
        }
    }
}