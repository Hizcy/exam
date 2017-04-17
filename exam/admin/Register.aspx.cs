using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using Exam.Entity;
public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<tb_LocationEntity> list = Exam.BLL.tb_LocationBLL.GetInstance().GetProvinceList();
            this.ddlprovince.DataSource = list;
            this.ddlprovince.DataTextField = "LocationName";
            this.ddlprovince.DataValueField = "LocationId";
            this.ddlprovince.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtyuming.Text.Trim()))
            {
                MessageBox.ShowMsg(this,"域名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txtname.Text.Trim()))
            {
                MessageBox.ShowMsg(this, "学校名称不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txtrealname.Text.Trim()))
            {
                MessageBox.ShowMsg(this, "姓名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txtphone.Text.Trim()))
            {
                MessageBox.ShowMsg(this, "电话不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txtmail.Text.Trim()))
            {
                MessageBox.ShowMsg(this, "邮箱不能为空");
                return;
            }
            Exam.Entity.tb_SchoolEntity model = Exam.BLL.tb_SchoolBLL.GetInstance().GetModel("@" + txtyuming.Text.Trim() + ddldomain.SelectedValue);
            if (model == null)
            {
                RandomCode r = new RandomCode();
                r.IncludeSpecial = false;
                r.MaximumLength = 6;
                string pwd = r.Create();
                int locationid = 0;

                //if (ddleurozone.SelectedValue =="0")
                //{
                //    int.TryParse(ddlcity.SelectedValue,out locationid);
                //}
                //else
                //{
                //    int.TryParse(ddleurozone.SelectedValue, out locationid);
                //}

                int rows = Exam.BLL.tb_SchoolBLL.GetInstance().InsertSchool("@" + txtyuming.Text.Trim() + ddldomain.SelectedValue,
                    txtname.Text.Trim(), locationid, txtrealname.Text.Trim(), male.Checked ? 1 : 0, txtphone.Text.Trim(), txtmail.Text.Trim(), pwd,0);
                /*model = new Exam.Entity.tb_SchoolEntity();
                model.Name = txtname.Text.Trim();
                model.Domain = "@" + txtyuming.Text.Trim();
                model.LocationId = 0;
                model.Linkman = txtrealname.Text.Trim();
                model.Phone = txtphone.Text.Trim();
                model.Tel = "";
                model.Mail = txtmail.Text.Trim();
                model.Addtime = DateTime.Now;
                model.Updatetime = DateTime.Now;
                model.Begintime = DateTime.Now;
                model.Endtime = DateTime.Now.AddYears(1);

                int row = Exam.BLL.tb_SchoolBLL.GetInstance().Insert(model);

                Exam.Entity.tb_UserEntity user = new Exam.Entity.tb_UserEntity();
                user.SchoolId = row;
                user.DepartmentId = 0;
                user.RoleId = 1;
                user.Name = "admin";
                user.Pwd = "admin";
                user.RealName = txtrealname.Text.Trim();
                user.Sex = male.Checked ? 1 : 0;
                user.Position = "管理员";
                user.Mail = txtmail.Text.Trim();
                user.IdentityCard = "";
                user.Phone = txtphone.Text.Trim();
                user.Description = "";
                user.Status = 1;
                user.Addtime = DateTime.Now;

                Exam.BLL.tb_UserBLL.GetInstance().Insert(user);
                */
                MessageBox.ShowMsg(this, "添加成功，请等待管理员审核");



                //SendWelcome(txtrealname.Text.Trim(), txtmail.Text.Trim(),"admin",pwd);
            }
            else
            {
                MessageBox.ShowMsg(this, "注册域名重复");
                return;
            }
        }
        catch (Exception ex)
        {
            MessageBox.ShowMsg(this,ex.Message);
        }
    }
    public void SendWelcome(string name,string mail,string username,string userpwd)
    {
        string body = "<p><b>尊敬的用户" + name + "</b></p>";
        body += "<p>祝贺您成功注册快去读。<br />用户名："+username+"<br/>密码："+userpwd+"<br/>请您妥善保管好账号信息，以免给您带来不必要的损失！</P>";

        Jnwf.Utils.Mail.MailHelper.SendEmail(
            Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpServer"), 
            Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpUser"), 
            Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpPass"),
            mail, "欢迎加入快去读", body, true, null);
    }
    protected void selectcity_Load(object sender, EventArgs e)
    {
        if (ddlprovince.Value.Equals("0"))
        {
            List<tb_LocationEntity> list = new List<tb_LocationEntity>();
            tb_LocationEntity model = new tb_LocationEntity();
            model.LocationName = "市";
            model.LocationId = 0;
            list.Add(model);
            ddlcity.DataSource = list;
            ddlcity.DataTextField = "LocationName";
            ddlcity.DataValueField = "LocationId";
            ddlcity.DataBind();

            List<tb_LocationEntity> tlist = new List<tb_LocationEntity>();
            tb_LocationEntity tmodel = new tb_LocationEntity();
            tmodel.LocationName = "县/区";
            tmodel.LocationId = 0;
            tlist.Add(tmodel);
            ddleurozone.DataSource = tlist;
            ddleurozone.DataTextField = "LocationName";
            ddleurozone.DataValueField = "LocationId";
            ddleurozone.DataBind();

        }
        if (!string.IsNullOrEmpty(selectcity.Text) && !selectcity.Text.Equals("0"))
        {
            Exam.Entity.tb_LocationEntity model = Exam.BLL.tb_LocationBLL.GetInstance().GetAdminSingle(int.Parse(ddlprovince.Value));
            if (model != null)
            {
                IList<Exam.Entity.tb_LocationEntity> ds = Exam.BLL.tb_LocationBLL.GetInstance().GetLocationInfo(model.LocationPath, 1);
                if (ds != null && ds.Count > 0)
                {
                    ddlcity.DataSource = ds;
                    ddlcity.DataTextField = "LocationName";
                    ddlcity.DataValueField = "LocationId";
                    ddlcity.DataBind();
                    for (int i = 0; i < ddlcity.Items.Count; i++)
                    {
                        if (ddlcity.Items[i].Value == selectcity.Text)
                        {
                            ddlcity.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
        if (!string.IsNullOrEmpty(selecteurozone.Text) && !selecteurozone.Text.Equals("0"))
        {
            Exam.Entity.tb_LocationEntity model = Exam.BLL.tb_LocationBLL.GetInstance().GetAdminSingle(int.Parse(ddlcity.Value));
            IList<Exam.Entity.tb_LocationEntity> ds = Exam.BLL.tb_LocationBLL.GetInstance().GetLocationInfo(model.LocationPath, 2);
            if (ds != null)
            {
                ddleurozone.DataSource = ds;
                ddleurozone.DataTextField = "LocationName";
                ddleurozone.DataValueField = "LocationId";
                ddleurozone.DataBind();
                for (int i = 0; i < ddleurozone.Items.Count; i++)
                {
                    if (ddleurozone.Items[i].Value == selecteurozone.Text)
                    {
                        ddleurozone.Items[i].Selected = true;
                    }
                }
            }
        }
    }
}