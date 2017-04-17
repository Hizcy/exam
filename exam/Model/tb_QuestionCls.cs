// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_QuestionCls.cs
// 项目名称：买车网
// 创建时间：2015/8/21
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_QuestionCls数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_QuestionClsEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _questionClsId;
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///
		///</summary>
		private int _parentId;
		///<summary>
		///
		///</summary>
		private string _name = String.Empty;
		///<summary>
		///
		///</summary>
		private string _description = String.Empty;
		///<summary>
		///
		///</summary>
		private int _score;
		///<summary>
		///
		///</summary>
		private int _isMust;
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
		public tb_QuestionClsEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_QuestionClsEntity
		(
			int questionClsId,
			int schoolId,
			int parentId,
			string name,
			string description,
			int score,
			int isMust,
			int status,
			DateTime addtime,
			DateTime updatetime
		)
		{
			_questionClsId = questionClsId;
			_schoolId      = schoolId;
			_parentId      = parentId;
			_name          = name;
			_description   = description;
			_score         = score;
			_isMust        = isMust;
			_status        = status;
			_addtime       = addtime;
			_updatetime    = updatetime;
			
		}
		#endregion
		
		#region 公共属性

		
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
		public int SchoolId
		{
			get {return _schoolId;}
			set {_schoolId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int ParentId
		{
			get {return _parentId;}
			set {_parentId = value;}
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
		///
		///</summary>
		[DataMember]
		public string Description
		{
			get {return _description;}
			set {_description = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Score
		{
			get {return _score;}
			set {_score = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int IsMust
		{
			get {return _isMust;}
			set {_isMust = value;}
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
		
	}
}
