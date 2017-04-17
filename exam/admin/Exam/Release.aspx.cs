using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_Release : System.Web.UI.Page
{
    public int schoolId
    {
        get
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity == null)
            {
                return 0;
            }
            return identity._schoolID;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(!string.IsNullOrEmpty(txthid.Text.Trim()))
            {
                IList<Exam.Entity.tb_ExampaperEntity> list = Exam.BLL.tb_ExampaperBLL.GetInstance().Gettb_ExampaperById(int.Parse(txthid.Text.Trim()));
                if (list != null && list.Count > 0)
                {

                }
            }
          
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string paperid = txthid.Text.Trim();
        string name = txtname.Text.Trim();
        int status = int.Parse(ddlstatus.SelectedValue);
        string score = txtscore.Text.Trim();
        string datetime = txtlength.Text.Trim();
        if (paperid == "")
        {
            MessageBox.ShowMsg(this, "请选择试卷！");
            return;
        }
        else if (name == "")
        {
            MessageBox.ShowMsg(this, "请填写\"考试名称\"！");
            return;
        }
        else if (score == "")
        {
            MessageBox.ShowMsg(this, "请填写\"及格分数\"！");
            return;
        }
        else if (datetime == "")
        {
            MessageBox.ShowMsg(this, "请填写\"答卷时长\"！");
            return;
        }
        try
        {
            UserIdentity identity = User.Identity as UserIdentity;
            Exam.Entity.tb_ExamEntity model = new Exam.Entity.tb_ExamEntity();
            model.SchoolId = schoolId;
            model.ExamClsId = 0;
            model.ExampaperId = int.Parse(paperid);
            model.Name = name;
            model.Pass = int.Parse(score);
            model.Duration = int.Parse(datetime);
            model.Number = 0;
            model.DepartmentId = 1;
            model.Status = 1;
            model.Founder = identity.Name + identity._domain;
            model.Addtime = DateTime.Now;
            model.Updatetime = DateTime.Now;
            if (Exam.BLL.tb_ExamBLL.GetInstance().Insert(model) > 0)
            {
                MessageBox.ShowMsg(this, "保存成功！");
            }
        }
        catch (Exception ex)
        {
            MessageBox.ShowMsg(this, "保存失败！");
        }
        
        
    }
}