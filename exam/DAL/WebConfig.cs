using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exam.DAL
{
    public class WebConfig
    {
        public static string GetConnectionString(string key)
        {
            return Jnwf.Utils.Config.ConfigurationUtil.GetConnectionString(key);
        }

        public static string ExamRW
        {
            get
            {
                return GetConnectionString("exam");
            }
        }

        public static XmlDocument ReadXml(string xml)
        {
            XmlDocument _xml = new XmlDocument();

            _xml.LoadXml(xml);

            return _xml;
        }
    }
}
