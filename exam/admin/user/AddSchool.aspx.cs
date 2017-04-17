using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;
using System.Data;

public partial class user_AddSchool :BasePage //System.Web.UI.Page
{
    public int schoolId
    {
        get
        {
            object obj = Request.QueryString["schoolid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<tb_UserEntity> agentList = tb_UserBLL.GetInstance().GetAgentList();
            tb_UserEntity userModel = new tb_UserEntity();
            userModel.UserId = 0;
            userModel.Name = "选择代理商";
            agentList.Insert(0, userModel);
            if (agentList != null && agentList.Count > 0)
            {
                dllagent.DataSource = agentList;
                dllagent.DataTextField = "name";
                dllagent.DataValueField = "userid";
                dllagent.DataBind();
            }
            //省
            IList<tb_LocationEntity> list = Exam.BLL.tb_LocationBLL.GetInstance().GetProvinceByCache();
            this.ddlprovince.DataSource = list;
            this.ddlprovince.DataTextField = "LocationName";
            this.ddlprovince.DataValueField = "LocationId";
            this.ddlprovince.DataBind();
            if (identity != null)
            {
                if (schoolId > 0)
                {
                    Exam.Entity.tb_SchoolEntity model = Exam.BLL.tb_SchoolBLL.GetInstance().GetAdminSingle(schoolId);
                    if (model != null)
                    {
                        string str = model.Domain;
                        string[] arr = str.Split('.');
                        this.txtname.Text = model.Name;
                        this.txtdomain.Text = arr[0];
                        this.txtdomain.Enabled = false;
                        this.ddldomain.SelectedItem.Text = arr[1];
                        this.ddldomain.Enabled = false;
                        this.txtrealname.Text = model.Linkman;
                        this.txtphone.Text = model.Phone;
                        this.ddlstatus.SelectedValue = model.Status.ToString();
                        this.txtemail.Text = model.Mail;
                        DataSet ds = Exam.BLL.tb_LocationBLL.GetInstance().GetLocationInfo(model.LocationId);
                        if (ds != null && ds.Tables.Count>0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count>0)
                        {
                            //城市
                            if (int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString()) == 0)
                            {
                                for (int i = 0; i < ddlprovince.Items.Count; i++)
                                {
                                    if (ddlprovince.Items[i].Value == ds.Tables[0].Rows[0]["CityID"].ToString())
                                    {
                                        ddlprovince.Items[i].Selected = true;
                                        IList<tb_LocationEntity> tlist = Exam.BLL.tb_LocationBLL.GetInstance().GetCityByCache(int.Parse(ds.Tables[0].Rows[0]["CityID"].ToString()));
                                        this.ddlcity.DataSource = tlist;
                                        this.ddlcity.DataTextField = "LocationName";
                                        this.ddlcity.DataValueField = "LocationId";
                                        this.ddlcity.DataBind();
                                    }
                                }
                                //城市选中
                                for (int k = 0; k < ddlcity.Items.Count; k++)
                                {
                                    if (ddlcity.Items[k].Value == ds.Tables[0].Rows[0]["LocationId"].ToString())
                                    {
                                        ddlcity.Items[k].Selected = true;
                                    }
                                }
                            }
                            else if (int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString()) > 0)
                            {
                                for (int i = 0; i < ddlprovince.Items.Count; i++)
                                {
                                    if (ddlprovince.Items[i].Value == ds.Tables[0].Rows[0]["ProvinceID"].ToString())
                                    {
                                        //省选中
                                        ddlprovince.Items[i].Selected = true;
                                        //市赋值
                                        IList<tb_LocationEntity> tlist = Exam.BLL.tb_LocationBLL.GetInstance().GetCityByCache(int.Parse(ds.Tables[0].Rows[0]["ProvinceID"].ToString()));
                                        if (tlist != null)
                                        {
                                            this.ddlcity.DataSource = tlist;
                                            this.ddlcity.DataTextField = "LocationName";
                                            this.ddlcity.DataValueField = "LocationId";
                                            this.ddlcity.DataBind();
                                        }
                                    }
                                }
                                for(int y=0;y<ddlcity.Items.Count;y++)
                                {
                                    if (ddlcity.Items[y].Value == ds.Tables[0].Rows[0]["CityID"].ToString())
                                    {
                                        //市选中
                                        ddlcity.Items[y].Selected = true;
                                        //区赋值
                                        IList<tb_LocationEntity> templist = Exam.BLL.tb_LocationBLL.GetInstance().GetEurozoneList(int.Parse(ddlcity.Value));
                                        if (templist != null)
                                        {
                                            this.ddleurozone.DataSource = templist;
                                            this.ddleurozone.DataTextField = "LocationName";
                                            this.ddleurozone.DataValueField = "LocationId";
                                            this.ddleurozone.DataBind();
                                        }
                                    }
                                }
                                for (int k = 0; k < ddleurozone.Items.Count; k++)
                                {
                                    //区选择
                                    if (ddleurozone.Items[k].Value == ds.Tables[0].Rows[0]["LocationId"].ToString())
                                    {
                                        ddleurozone.Items[k].Selected = true;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string domain = SqlInject(this.txtdomain.Text.Trim());
            string domain2 = ddldomain.SelectedValue;
            string realname = SqlInject(this.txtrealname.Text.Trim());
            string name = SqlInject(this.txtname.Text.Trim());
            string phone=SqlInject(txtphone.Text.Trim());
            string status = ddlstatus.SelectedValue;
            string mail = SqlInject(this.txtemail.Text.Trim());
            int agentId = int.Parse(SqlInject(this.dllagent.SelectedValue.ToString()));
            if (identity != null)
            {
                //添加
                if (schoolId == 0)
                {
                    Exam.Entity.tb_SchoolEntity model = Exam.BLL.tb_SchoolBLL.GetInstance().GetModel("@" + domain + ddldomain.SelectedValue);
                    if (model != null)
                    {
                        MessageBox.ShowMsg(this, "域名已存在！");
                        return;
                    }
                    else
                    {
                        RandomCode r = new RandomCode();
                        r.IncludeSpecial = false;
                        r.MaximumLength = 6;
                        string pwd = r.Create();
                        int locationid = 0;
                        if (ddleurozone.Value == "0")
                        {
                            int.TryParse(ddlcity.Value, out locationid);
                        }
                        else
                        {
                            int.TryParse(ddleurozone.Value, out locationid);
                        }
                        string body = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("body");
                        int rows = 0;
                        if (identity._roleID == 4)
                        {
                            if (agentId == 0)
                            {
                                rows = Exam.BLL.tb_SchoolBLL.GetInstance().InsertSchool("@" + domain + ddldomain.SelectedValue,
                                   name, locationid, realname, male.Checked ? 1 : 0, phone, mail, pwd, 0, 1);
                            }
                            else
                            {
                                rows = Exam.BLL.tb_SchoolBLL.GetInstance().InsertSchool("@" + domain + ddldomain.SelectedValue,
                                   name, locationid, realname, male.Checked ? 1 : 0, phone, mail, pwd, agentId, 1);
                            }
                                Exam.Entity.tb_SchoolEntity tmodel = Exam.BLL.tb_SchoolBLL.GetInstance().GetModel("@" + domain + ddldomain.SelectedValue);
                                body = string.Format(body, "<p><b>", name, "</b></p><p>", "<br/>", "admin@" + domain + domain2 + "<br/>", pwd + "<br/><p>", tmodel.SchoolId + "</p>", "</p>");
                                if (rows > 0)
                                {
                                    Jnwf.Utils.Mail.MailHelper.SendEmail(
                                               Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpServer"),
                                               Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpUser"),
                                               Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpPass"),
                                               mail, "欢迎加入快去读", body, true, null);
                                    MessageBox.ShowAndRedirect(this, "添加成功！", "listschool.aspx");
                                }
                        }
                        //代理商
                        else if (identity._roleID == 5)
                        {
                            Exam.BLL.tb_SchoolBLL.GetInstance().InsertSchool("@" + domain + ddldomain.SelectedValue,
                                name, locationid, realname, male.Checked ? 1 : 0, phone, mail, pwd, identity.UserID, 0);
                        }
                    }

                }
                //修改
                else
                {
                    Exam.Entity.tb_SchoolEntity model = Exam.BLL.tb_SchoolBLL.GetInstance().GetAdminSingle(schoolId);
                    if (model != null)
                    {
                        if (selecteurozone.Text != "0")
                        {
                            model.LocationId = int.Parse(ddleurozone.Value);
                        }
                        else if (selectcity.Text != "0")
                        {
                            model.LocationId = int.Parse(ddlcity.Value);
                        }
                        model.Name = name;
                        model.Linkman = txtrealname.Text;
                        model.Mail = mail;
                        model.Phone = txtphone.Text;
                        model.Status = int.Parse(status);
                        model.Updatetime = DateTime.Now;
                        Exam.BLL.tb_SchoolBLL.GetInstance().Update(model);
                    }
                    Response.Redirect("listschool.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("AddSchool.aspx.cs,btnSave_Click,ex:" + ex.Message + "|" + ex.StackTrace);
            //throw;
        }
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
       
    }
    protected void selecteurozone_Load(object sender, EventArgs e)
    {
        if (ddlprovince.Value.Equals("0"))
        {
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