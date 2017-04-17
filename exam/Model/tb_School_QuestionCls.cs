// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School_QuestionCls.cs
// 项目名称：买车网
// 创建时间：2015/8/29
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_School_QuestionCls数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_School_QuestionClsEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _relationId;
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
		private string _path = String.Empty;
		///<summary>
		///
		///</summary>
		private int _score;
		///<summary>
		///
		///</summary>
		private int _isMust;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_School_QuestionClsEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_School_QuestionClsEntity
		(
			int relationId,
			int schoolId,
			int questionClsId,
			string path,
			int score,
			int isMust
		)
		{
			_relationId    = relationId;
			_schoolId      = schoolId;
			_questionClsId = questionClsId;
			_path          = path;
			_score         = score;
			_isMust        = isMust;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int RelationId
		{
			get {return _relationId;}
			set {_relationId = value;}
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
		public string Path
		{
			get {return _path;}
			set {_path = value;}
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
	
		#endregion
		
	}
}
