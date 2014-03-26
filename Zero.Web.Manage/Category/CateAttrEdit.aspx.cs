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
    public partial class CateAttrEdit : Zero.Pages.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = RequestHelper.QueryInt("caId");

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
            this.tab.Text = "类目属性添加";

            this.cateList.DataSource = CateService.GetCateDropList("cateList", 0, 0);
            this.cateList.DataValueField = "Key";
            this.cateList.DataTextField = "Value";
            this.cateList.DataBind();

            //this.status.DataSource = BaseStatusCtrl.GetStatusList();
            //this.status.DataValueField = "Key";
            //this.status.DataTextField = "Value";
            //this.status.DataBind();

            string attrId = RequestHelper.Query("attrId");
            string attr = RequestHelper.Query("attr");

            if (!string.IsNullOrEmpty(attrId) && !string.IsNullOrEmpty(attr))
            {
                this.attrId.Value = attrId.ToString();
                this.attr.Value = string.Format("{0} | {1}", attrId, attr);
            }
        }

        private void EidtInit(int caId)
        {
            this.tab.Text = "类目属性修改";

            this.cateList.DataSource = CateService.GetCateDropList("cateList", 0, 0);
            this.cateList.DataValueField = "Key";
            this.cateList.DataTextField = "Value";
            this.cateList.DataBind();

            //this.status.DataSource = BaseStatusCtrl.GetStatusList();
            //this.status.DataValueField = "Key";
            //this.status.DataTextField = "Value";
            //this.status.DataBind();

            CateAttrInfo info = CateAttrService.GetCateAttrInfo(caId);

            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }
            this.cateList.Value = info.CateId.ToString();
            this.attrId.Value = info.AttrId.ToString();
            this.type.Value = info.Type.ToString();
            this.isMust.Value = info.IsMust.ToString();
            this.isSale.Value = info.IsSale.ToString();
            this.isKey.Value = info.IsKey.ToString();
        }

        private void Add()
        {
            CateAttrInfo info = GetAddForm();

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            //是否存在所属类别
            if (!CateService.ExistCateId(info.CateId))
            {
                ShowError("无法找到所属分类！"); return;
            }

            //是否存在所属属性
            if (!AttrService.ExistAttr(info.AttrId))
            {
                ShowError("不存在所属属性！"); return;
            }

            //不能存在同样的属性
            if (CateAttrService.ExistCateAttr(info.CateId,info.AttrId))
            {
                ShowError("该类别已存在此属性！"); return;
            }

            CateAttrService.AddCateAttrInfo(info);

            ShowOK("操作成功！", "/category/cateAttrIndex.aspx");
        }

        private void Edit(int cateId)
        {
            CateAttrInfo info = CateAttrService.GetCateAttrInfo(cateId);

            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }

            GetEditForm(info);

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            //是否存在所属类别
            if (!CateService.ExistCateId(info.CateId))
            {
                ShowError("无法找到所属分类！"); return;
            }

            //是否存在所属属性
            if (!AttrService.ExistAttr(info.AttrId))
            {
                ShowError("不存在所属属性！"); return;
            }

            //不能存在同样的属性
            if (CateAttrService.ExistCateAttr(info.CAID, info.CateId, info.AttrId))
            {
                ShowError("该类别已存在此属性！"); return;
            }

            CateAttrService.UpdateCateAttrInfo(info);

            ShowOK("操作成功！", "/category/cateAttrIndex.aspx");
        }

        private CateAttrInfo GetAddForm()
        {
            CateAttrInfo info = new CateAttrInfo();
            FormItem<int> cateIdItem = new FormItem<int>("cateList", "请选择分类", 1, int.MaxValue);
            FormItem<int> attrIdItem = new FormItem<int>("attrId", "请选择属性", 1, int.MaxValue);
            FormItem<int> typeItem = new FormItem<int>("type", "属性类型", 0, 4);
            FormItem<int> isMustItem = new FormItem<int>("isMust", "是否必须", 0, 1);
            FormItem<int> isSaleItem = new FormItem<int>("isSale", "是否销售属性", 0, 1);
            FormItem<int> isKeyItem = new FormItem<int>("isKey", "是否关键属性", 0, 1);
            

            info.CateId = cateIdItem.GetFormValue(ErrorMsg);
            info.AttrId = attrIdItem.GetFormValue(ErrorMsg);
            info.Type = typeItem.GetFormValue(ErrorMsg);
            info.IsMust = isMustItem.GetFormValue(ErrorMsg);
            info.IsSale = isSaleItem.GetFormValue(ErrorMsg);
            info.IsKey = isKeyItem.GetFormValue(ErrorMsg);
            return info;
        }

        private void GetEditForm(CateAttrInfo info)
        {
            FormItem<int> cateIdItem = new FormItem<int>("cateList", "请选择分类", 1, int.MaxValue);
            FormItem<int> attrIdItem = new FormItem<int>("attrId", "请选择属性", 1, int.MaxValue);
            FormItem<int> typeItem = new FormItem<int>("type", "属性类型", 0, 4);
            FormItem<int> isMustItem = new FormItem<int>("isMust", "是否必须", 0, 1);
            FormItem<int> isSaleItem = new FormItem<int>("isSale", "是否销售属性", 0, 1);
            FormItem<int> isKeyItem = new FormItem<int>("isKey", "是否关键属性", 0, 1);


            info.CateId = cateIdItem.GetFormValue(ErrorMsg);
            info.AttrId = attrIdItem.GetFormValue(ErrorMsg);
            info.Type = typeItem.GetFormValue(ErrorMsg);
            info.IsMust = isMustItem.GetFormValue(ErrorMsg);
            info.IsSale = isSaleItem.GetFormValue(ErrorMsg);
            info.IsKey = isKeyItem.GetFormValue(ErrorMsg);
        }
    }
}