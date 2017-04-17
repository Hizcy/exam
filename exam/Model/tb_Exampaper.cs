// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Exampaper.cs
// 项目名称：买车网
// 创建时间：2015/8/20
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Exampaper数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_ExampaperEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _exampaperId;
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///
		///</summary>
		private int _exampaperClsId;
		///<summary>
		///
		///</summary>
		private string _name = String.Empty;
		///<summary>
		///组卷方式（随机组卷）
		///</summary>
		private int _type;
		///<summary>
		///总题数
		///</summary>
		private int _num;
		///<summary>
		///总分
		///</summary>
		private int _total;
		///<summary>
		///
		///</summary>
		private int _pass;
		///<summary>
		///时长（单位分钟）
		///</summary>
		private int _duration;
		///<summary>
		///状态（正常，禁用）
		///</summary>
		private int _status;
		///<summary>
		///创建人
		///</summary>
		private string _founder = String.Empty;
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
		public tb_ExampaperEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_ExampaperEntity
		(
			int exampaperId,
			int schoolId,
			int exampaperClsId,
			string name,
			int type,
			int num,
			int total,
			int pass,
			int duration,
			int status,
			string founder,
			DateTime addtime,
			DateTime updatetime
		)
		{
			_exampaperId    = exampaperId;
			_schoolId       = schoolId;
			_exampaperClsId = exampaperClsId;
			_name           = name;
			_type           = type;
			_num            = num;
			_total          = total;
			_pass           = pass;
			_duration       = duration;
			_status         = status;
			_founder        = founder;
			_addtime        = addtime;
			_updatetime     = updatetime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int ExampaperId
		{
			get {return _exampaperId;}
			set {_exampaperId = value;}
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
		public int ExampaperClsId
		{
			get {return _exampaperClsId;}
			set {_exampaperClsId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}

		///<summary>
		///组卷方式（随机组卷）
		///</summary>
		[DataMember]
		public int Type
		{
			get {return _type;}
			set {_type = value;}
		}

		///<summary>
		///总题数
		///</summary>
		[DataMember]
		public int Num
		{
			get {return _num;}
			set {_num = value;}
		}

		///<summary>
		///总分
		///</summary>
		[DataMember]
		public int Total
		{
			get {return _total;}
			set {_total = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Pass
		{
			get {return _pass;}
			set {_pass = value;}
		}

		///<summary>
		///时长（单位分钟）
		///</summary>
		[DataMember]
		public int Duration
		{
			get {return _duration;}
			set {_duration = value;}
		}

		///<summary>
		///状态（正常，禁用）
		///</summary>
		[DataMember]
		public int Status
		{
			get {return _status;}
			set {_status = value;}
		}

		///<summary>
		///创建人
		///</summary>
		[DataMember]
		public string Founder
		{
			get {return _founder;}
			set {_founder = value;}
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
		
	}
}
