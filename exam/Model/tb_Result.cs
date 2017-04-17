// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Result.cs
// 项目名称：买车网
// 创建时间：2015/8/27
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Result数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_ResultEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _resultId;
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///那个人考试
		///</summary>
		private int _userId;
		///<summary>
		///所选试卷
		///</summary>
		private int _exampaperId;
		///<summary>
		///考试成绩
		///</summary>
		private int _score;
		///<summary>
		///积分
		///</summary>
		private int _point;
		///<summary>
		///考试时间
		///</summary>
		private DateTime _addtime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_ResultEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_ResultEntity
		(
			int resultId,
			int schoolId,
			int userId,
			int exampaperId,
			int score,
			int point,
			DateTime addtime
		)
		{
			_resultId    = resultId;
			_schoolId    = schoolId;
			_userId      = userId;
			_exampaperId = exampaperId;
			_score       = score;
			_point       = point;
			_addtime     = addtime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int ResultId
		{
			get {return _resultId;}
			set {_resultId = value;}
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
		///那个人考试
		///</summary>
		[DataMember]
		public int UserId
		{
			get {return _userId;}
			set {_userId = value;}
		}

		///<summary>
		///所选试卷
		///</summary>
		[DataMember]
		public int ExampaperId
		{
			get {return _exampaperId;}
			set {_exampaperId = value;}
		}

		///<summary>
		///考试成绩
		///</summary>
		[DataMember]
		public int Score
		{
			get {return _score;}
			set {_score = value;}
		}

		///<summary>
		///积分
		///</summary>
		[DataMember]
		public int Point
		{
			get {return _point;}
			set {_point = value;}
		}

		///<summary>
		///考试时间
		///</summary>
		[DataMember]
		public DateTime Addtime
		{
			get {return _addtime;}
			set {_addtime = value;}
		}
	
		#endregion
		
	}
}
