// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Question.cs
// 项目名称：买车网
// 创建时间：2015/8/14
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Question数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_QuestionEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _questionId;
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///
		///</summary>
		private int _questionClsId;
		///<summary>
		///
		///</summary>
		private int _type;
		///<summary>
		///
		///</summary>
		private string _title = String.Empty;
		///<summary>
		///
		///</summary>
		private string _a = String.Empty;
		///<summary>
		///
		///</summary>
		private string _b = String.Empty;
		///<summary>
		///
		///</summary>
		private string _c = String.Empty;
		///<summary>
		///
		///</summary>
		private string _d = String.Empty;
		///<summary>
		///
		///</summary>
		private string _e = String.Empty;
		///<summary>
		///
		///</summary>
		private string _f = String.Empty;
		///<summary>
		///
		///</summary>
		private string _g = String.Empty;
		///<summary>
		///
		///</summary>
		private string _h = String.Empty;
		///<summary>
		///
		///</summary>
		private string _answer = String.Empty;
		///<summary>
		///
		///</summary>
		private string _interpretation = String.Empty;
		///<summary>
		///
		///</summary>
		private int _isdifficulty;
		///<summary>
		///
		///</summary>
		private int _status;
		///<summary>
		///
		///</summary>
		private DateTime _addtime;
		///<summary>
		///
		///</summary>
		private DateTime _updatetime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_QuestionEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_QuestionEntity
		(
			int questionId,
			int schoolId,
			int questionClsId,
			int type,
			string title,
			string a,
			string b,
			string c,
			string d,
			string e,
			string f,
			string g,
			string h,
			string answer,
			string interpretation,
			int isdifficulty,
			int status,
			DateTime addtime,
			DateTime updatetime
		)
		{
			_questionId     = questionId;
			_schoolId       = schoolId;
			_questionClsId  = questionClsId;
			_type           = type;
			_title          = title;
			_a              = a;
			_b              = b;
			_c              = c;
			_d              = d;
			_e              = e;
			_f              = f;
			_g              = g;
			_h              = h;
			_answer         = answer;
			_interpretation = interpretation;
			_isdifficulty   = isdifficulty;
			_status         = status;
			_addtime        = addtime;
			_updatetime     = updatetime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int QuestionId
		{
			get {return _questionId;}
			set {_questionId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int SchoolId
		{
			get {return _schoolId;}
			set {_schoolId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int QuestionClsId
		{
			get {return _questionClsId;}
			set {_questionClsId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Type
		{
			get {return _type;}
			set {_type = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Title
		{
			get {return _title;}
			set {_title = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string A
		{
			get {return _a;}
			set {_a = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string B
		{
			get {return _b;}
			set {_b = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string C
		{
			get {return _c;}
			set {_c = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string D
		{
			get {return _d;}
			set {_d = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string E
		{
			get {return _e;}
			set {_e = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string F
		{
			get {return _f;}
			set {_f = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string G
		{
			get {return _g;}
			set {_g = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string H
		{
			get {return _h;}
			set {_h = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Answer
		{
			get {return _answer;}
			set {_answer = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Interpretation
		{
			get {return _interpretation;}
			set {_interpretation = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Isdifficulty
		{
			get {return _isdifficulty;}
			set {_isdifficulty = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Status
		{
			get {return _status;}
			set {_status = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public DateTime Addtime
		{
			get {return _addtime;}
			set {_addtime = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public DateTime Updatetime
		{
			get {return _updatetime;}
			set {_updatetime = value;}
		}
	
		#endregion
        /// <summary>
        /// 临时排序
        /// </summary>
        [DataMember]
        public int TempId
        {
            get;
            set;
        }
	}
}
