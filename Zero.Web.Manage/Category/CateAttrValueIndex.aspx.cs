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
    public partial class CateAttrValueIndex : System.Web.UI.Page
    {
        List<CateAttrValueInfo> cateAttrValueList;

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            this.tab.Text = "编辑类别包含的属性值";
            int cateId = 7;
            string condition=string.Empty;

            //获取分类对应的属性列表
            condition = string.Format("where cateId={0}", cateId);
            List<CateAttrExpandInfo> cateAttrList = CateAttrService.GetCateAttrList(condition);

            //获取分类选中的属性值
             cateAttrValueList = CateAttrValueService.GetCateAttrValueList(condition);

            //获取属性对应的属性值列表
            for(int i=0;i<cateAttrList.Count;i++)
            {
                condition = string.Format("where attrId={0}",cateAttrList[i].AttrId);
                cateAttrList[i].AttrValueList = AttrValueService.GetAttrValueList(condition);
            }

            this.attrList.ItemDataBound += new RepeaterItemEventHandler(AttrList_ItemDataBound);
            this.attrList.DataSource = cateAttrList;
            this.attrList.DataBind();

            this.cateList.DataSource = CateService.GetCateDropList("cateList", 0, 0);
            this.cateList.DataValueField = "Key";
            this.cateList.DataTextField = "Value";
            this.cateList.DataBind();
        }

        protected void AttrList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CateAttrExpandInfo info = (CateAttrExpandInfo)e.Item.DataItem;
                Repeater valueList = (Repeater)e.Item.FindControl("valueList");
                valueList.DataSource = info.AttrValueList;
                valueList.DataBind();
            }
        }
    }
}