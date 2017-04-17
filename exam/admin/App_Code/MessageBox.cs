using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using System.Net;
using System.Text.RegularExpressions;
/// <summary>
/// MessageBox ��ժҪ˵����
/// </summary>
public static class MessageBox
{
    /// <summary>
    /// ��ʾ��Ϣ��ʾ�Ի���
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="msg">��ʾ��Ϣ</param>
    public static void Show(System.Web.UI.Page page, string msg)
    {
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>ymPrompt.errorInfo({message:'" + msg + "',title:'��ʾ��Ϣ',showMask:false});</script>");

    }
    public static void ShowMsg(System.Web.UI.Page page, string msg)
    {
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "')</script>");

    }
    /// <summary>
    /// �ؼ���� ��Ϣȷ����ʾ��
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="msg">��ʾ��Ϣ</param>
    public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
    {
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
        Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
    }

    /// <summary>
    /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="msg">��ʾ��Ϣ</param>
    /// <param name="url">��ת��Ŀ��URL</param>
    public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
    {
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        StringBuilder Builder = new StringBuilder();
        Builder.Append("<script language='javascript' defer>");
        Builder.AppendFormat("alert('{0}');", msg);
        Builder.AppendFormat("self.location.href='{0}'", url);
        Builder.Append("</script>");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

    }

    /// <summary>
    /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="msg">��ʾ��Ϣ</param>
    /// <param name="url">��ת��Ŀ��URL</param>
    public static void ShowAndRedirectParent(System.Web.UI.Page page, string msg, string url)
    {
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        StringBuilder Builder = new StringBuilder();
        Builder.Append("<script language='javascript' defer>");
        Builder.AppendFormat("parent.frames['mainFrame'].location.href='{0}';", url);
        Builder.Append("parent.ymPrompt.close();");
        Builder.Append("parent.ymPrompt.succeedInfo({message:'" + msg);
        Builder.Append("',title:'��ʾ��Ϣ'});");
        Builder.Append("</script>");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

    }

    /// <summary>
    /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="msg">��ʾ��Ϣ</param>
    /// <param name="url">��ת��Ŀ��URL</param>
    public static void ShowAndTransfer(System.Web.UI.Page page, string msg)
    {
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        StringBuilder Builder = new StringBuilder();
        Builder.Append("<script language='javascript' defer>");
        /* if(url != "")
           Builder.AppendFormat("parent.frames['mainFrame'].location.href='{0}';", url);*/
        Builder.Append("parent.frames['mainFrame'].test();");
        Builder.Append("parent.ymPrompt.close();");
        Builder.Append("parent.ymPrompt.succeedInfo({message:'" + msg);
        Builder.Append("',title:'��ʾ��Ϣ'});");
        Builder.Append("</script>");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

    }

    /// <summary>
    /// ���ظ�ҳ�棬���б�ˢ��
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="msg">��ʾ��Ϣ</param>
    /// <param name="url">��ת��Ŀ��URL</param>
    public static void ShowAndTransferBack(System.Web.UI.Page page, string msg)
    {
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        StringBuilder Builder = new StringBuilder();
        Builder.Append("<script language='javascript' defer>");
        /* if(url != "")
           Builder.AppendFormat("parent.frames['mainFrame'].location.href='{0}';", url);*/
        Builder.Append("parent.ymPrompt.close();");
        Builder.Append("parent.ymPrompt.succeedInfo({message:'" + msg);
        Builder.Append("',title:'��ʾ��Ϣ'});");
        Builder.Append("</script>");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

    }

    /// <summary>
    /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="msg">��ʾ��Ϣ</param>
    /// <param name="pageindex">ҳ��</param>
    public static void ShowAndTransfer(System.Web.UI.Page page, string msg, int pageindex)
    {
        if (pageindex == 0)
            pageindex = 1;
        msg = msg.Replace("'", "\'");
        msg = msg.Replace(")", "");
        msg = msg.Replace("(", "");
        msg = msg.Replace("\n", "\\n");
        StringBuilder Builder = new StringBuilder();
        Builder.Append("<script language='javascript' defer>");
        if (pageindex != -1) Builder.Append("parent.frames['mainFrame'].showPage(" + pageindex + ");");
        Builder.Append("parent.ymPrompt.close();");
        Builder.Append("parent.ymPrompt.succeedInfo({message:'" + msg);
        Builder.Append("',title:'��ʾ��Ϣ'});");
        Builder.Append("</script>");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

    }
    /// <summary>
    /// ����Զ���ű���Ϣ
    /// </summary>
    /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
    /// <param name="script">����ű�</param>
    public static void ResponseScript(System.Web.UI.Page page, string script)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
    }
    /// <summary>
    /// Ϊ�ַ���д����չ����������������ת����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="str"></param>
    /// <param name="split"></param>
    /// <returns></returns>
    public static List<T> ToList<T>(this string str, string split)
    {
        if (!string.IsNullOrEmpty(str))
        {
            string[] arr = str.Split(new char[] { Convert.ToChar(split) });
            if (typeof(T) == typeof(int))
            {
                int[] arrInt = Array.ConvertAll<string, int>(arr, delegate(string s) { return int.Parse(s); });
                List<int> list = new List<int>(arrInt);
                return list as List<T>;
            }
            else if (typeof(T) == typeof(string))
            {
                List<string> list = new List<string>(arr);
                return list as List<T>;
            }
            else
            {
                return new List<T>();
            }
        }
        else
        {
            return new List<T>();
        }
    }
    public static string ToStringBuilder(this List<string> l, string split)
    {
        if (l.Count != 0)
        {
            StringBuilder sb = new StringBuilder();
            l.ForEach(c => sb.Append(c + split));
            return sb.ToString().TrimEnd(new char[] { Convert.ToChar(split) });
        }
        return "";
    }
    public static string ToStringBuilder(this Hashtable h, string split)
    {
        string skey = "";
        string svalue = "";
        if (h.Count != 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DictionaryEntry myDE in h)
            {
                skey = myDE.Key as string;
                svalue = myDE.Value as string;
                if (skey != null && svalue != null)
                {
                    sb.Append(skey + ":" + svalue + split);
                }
                else
                {
                    continue;
                }
            }
            return sb.ToString().TrimEnd(new char[] { Convert.ToChar(split) });
        }
        return "";
    }
    public static string MD5(this string str)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.Default.GetBytes(str);
        byte[] result = md5.ComputeHash(data);
        String ret = "";
        for (int i = 0; i < result.Length; i++)
            ret += result[i].ToString("x").PadLeft(2, '0');
        return ret;
    }
    public static long IpToLong(this string strip)
    {
        bool b;
        string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
        b = Regex.IsMatch(strip, ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        if (b)
        {
            IPAddress ip = IPAddress.Parse(strip);
            int x = 3;
            long l = 0;
            foreach (byte f in ip.GetAddressBytes())
            {
                l += (long)f << 8 * x--;
            }
            return l;
        }
        else
        {
            return -1;
        }
    }
    public static IPAddress LongToIp(this long l)
    {
        var b = new byte[4];

        for (int i = 0; i < 4; i++)
        {
            b[3 - i] = (byte)(l >> 8 * i & 255);
        }
        
        return new IPAddress(b);
    }

}
