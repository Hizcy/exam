// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ResultExt.cs
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
	///tb_ResultExt数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_ResultExtEntity
	{
		#region 变量定义
		///<summary>
		///考试扩展表
		///</summary>
		private int _extId;
		///<summary>
		///
		///</summary>
		private int _resultId;
		///<summary>
		///随机试题
		///</summary>
		private int _questionId;
		///<summary>
		///答案
		///</summary>
		private string _answer = String.Empty;
		///<summary>
		///是否正确
		///</summary>
		private int _isRight;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_ResultExtEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_ResultExtEntity
		(
			int extId,
			int resultId,
			int questionId,
			string answer,
			int isRight
		)
		{
			_extId      = extId;
			_resultId   = resultId;
			_questionId = questionId;
			_answer     = answer;
			_isRight    = isRight;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///考试扩展表
		///</summary>
		[DataMember]
		public int ExtId
		{
			get {return _extId;}
			set {_extId = value;}
		}

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
		///随机试题
		///</summary>
		[DataMember]
		public int QuestionId
		{
			get {return _questionId;}
			set {_questionId = value;}
		}

		///<summary>
		///答案
		///</summary>
		[DataMember]
		public string Answer
		{
			get {return _answer;}
			set {_answer = value;}
		}

		///<summary>
		///是否正确
		///</summary>
		[DataMember]
		public int IsRight
		{
			get {return _isRight;}
			set {_isRight = value;}
		}
	
		#endregion
		
	}
}
