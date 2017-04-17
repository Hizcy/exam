// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Exam.cs
// 项目名称：买车网
// 创建时间：2015/8/17
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Exam数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_ExamEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _examId;
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///
		///</summary>
		private int _examClsId;
		///<summary>
		///
		///</summary>
		private int _exampaperId;
		///<summary>
		///
		///</summary>
		private string _name = String.Empty;
		///<summary>
		///及格分数
		///</summary>
		private int _pass;
		///<summary>
		///时长（单位分钟）
		///</summary>
		private int _duration;
		///<summary>
		///考试次数
		///</summary>
		private int _number;
		///<summary>
		///需要参加考试的部门
		///</summary>
		private int _departmentId;
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
		public tb_ExamEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_ExamEntity
		(
			int examId,
			int schoolId,
			int examClsId,
			int exampaperId,
			string name,
			int pass,
			int duration,
			int number,
			int departmentId,
			int status,
			string founder,
			DateTime addtime,
			DateTime updatetime
		)
		{
			_examId       = examId;
			_schoolId     = schoolId;
			_examClsId    = examClsId;
			_exampaperId  = exampaperId;
			_name         = name;
			_pass         = pass;
			_duration     = duration;
			_number       = number;
			_departmentId = departmentId;
			_status       = status;
			_founder      = founder;
			_addtime      = addtime;
			_updatetime   = updatetime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int ExamId
		{
			get {return _examId;}
			set {_examId = value;}
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
		public int ExamClsId
		{
			get {return _examClsId;}
			set {_examClsId = value;}
		}

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
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}

		///<summary>
		///及格分数
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
		///考试次数
		///</summary>
		[DataMember]
		public int Number
		{
			get {return _number;}
			set {_number = value;}
		}

		///<summary>
		///需要参加考试的部门
		///</summary>
		[DataMember]
		public int DepartmentId
		{
			get {return _departmentId;}
			set {_departmentId = value;}
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
