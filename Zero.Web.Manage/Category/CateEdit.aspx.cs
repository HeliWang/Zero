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
    public partial class CateEdit : Zero.Pages.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cateId = RequestHelper.QueryInt("cateId");

            if (!IsPostBack)
            {
                if (cateId > 0)
                {
                    EidtInit(cateId);
                }
                else
                {
                    AddInit();
                }
            }
            else
            {
                if (cateId > 0)
                {
                    Edit(cateId);
                }
                else
                {
                    Add();
                }
            }
        }

        private void AddInit()
        {
            this.tab.Text = "添加类别";
            this.cateList.Text = CateService.GetCateDropList("cateList", 0, 0, RequestHelper.QueryInt("pid"));
        }

        private void EidtInit(int cateId)
        {
            this.tab.Text = "修改类别";
            CateInfo info = CateService.GetCateInfo(cateId);
            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }
            this.cateList.Text = CateService.GetCateDropList("cateList", 0, 0, info.Pid);
            this.cateName.Value = info.CateName;
        }

        private void Add()
        {
            int depth = 0;
            CateInfo info = GetAddForm();

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            //父节点必须存在
            if (info.Pid > 0)
            {
                CateInfo parentInfo = CateService.GetCateInfo(info.Pid);
                if (parentInfo == null)
                {
                    ShowError("无法找到所属分类！"); return;
                }
                depth = parentInfo.Depth;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (CateService.ExistCateName(info.CateName, info.Pid, depth + 1))
            {
                ShowError("已经存在此类别名称！"); return;
            }

            CateService.AddCateInfo(info.CateName, info.Pid);

            ShowOK("操作成功！", "/category/categoryIndex.aspx");
        }

        private void Edit(int cateId)
        {
            CateInfo info = CateService.GetCateInfo(cateId);
            int oldPid = info.Pid;

            if (info == null)
            {
                ShowError("未找到相关信息！"); return;
            }

            GetEditForm(info);

            if (ErrorMsg.Length > 0)
            {
                ShowError(ErrorMsg.ToString()); return;
            }

            //是否存在父节点
            if (info.Pid > 0 && !CateService.ExistCateId(info.Pid))
            {
                ShowError("无法找到所属分类！"); return;
            }

            //同一父节点并且同级别的类目不能出现同名
            if (CateService.ExistCateName(info.CateId, info.CateName, info.Pid, info.Depth))
            {
                ShowError("已经存在此类别名称！"); return;
            }

            //移动类目到指定的父类目下
            if (info.Pid != oldPid)
            {
                CateService.ChangeCateParent(info.CateId, info.Pid);
            }

            CateService.UpdateCateInfo(info.CateId, info.CateName);
            ShowOK("操作成功！", "/category/categoryIndex.aspx");
        }

        private CateInfo GetAddForm()
        {
            CateInfo info = new CateInfo();
            FormItem<int> parentIdItem = new FormItem<int>("cateList", "请选择分类", 0, int.MaxValue, 0);
            FormItem<string> cateNameItem = new FormItem<string>("cateName", "分类名称", 1, 50);

            info.Pid = parentIdItem.GetFormValue(ErrorMsg);
            info.CateName = cateNameItem.GetFormValue(ErrorMsg);
            return info;
        }

        private CateInfo GetEditForm(CateInfo info)
        {
            FormItem<int> parentIdItem = new FormItem<int>("cateList", "请选择分类", 0, int.MaxValue, 0);
            FormItem<string> cateNameItem = new FormItem<string>("cateName", "分类名称", 1, 50);

            info.Pid = parentIdItem.GetFormValue(ErrorMsg);
            info.CateName = cateNameItem.GetFormValue(ErrorMsg);
            return info;
        }
    }
}