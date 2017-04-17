using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Exam.BLL
{
    public abstract class BaseBLL<T>
    {
        static T instance = default(T);
        static public T GetInstance()
        {
            if (instance == null)
            {
                instance = (T)System.Reflection.Assembly.GetAssembly(typeof(T)).CreateInstance(typeof(T).ToString());
            }
            return instance;
        }
        
    }

}
