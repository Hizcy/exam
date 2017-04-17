// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_ExampaperExt.cs
// 项目名称：买车网
// 创建时间：2015/8/19
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_ExampaperExt数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_ExampaperExtEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _extId;
		///<summary>
		///（所属试题类型）
		///</summary>
		private int _exampaperId;
		///<summary>
		///
		///</summary>
		private int _tb_QuestionClsId;
		///<summary>
		///（单选，多选……）
		///</summary>
		private int _type;
		///<summary>
		///（单选题）
		///</summary>
		private string _title = String.Empty;
		///<summary>
		///（单选题数量）
		///</summary>
		private int _number;
		///<summary>
		///
		///</summary>
		private int _diff;
		///<summary>
		///（当前单选成绩）
		///</summary>
		private int _score;
		///<summary>
		///
		///</summary>
		private DateTime _addtime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_ExampaperExtEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_ExampaperExtEntity
		(
			int extId,
			int exampaperId,
			int tb_QuestionClsId,
			int type,
			string title,
			int number,
			int diff,
			int score,
			DateTime addtime
		)
		{
			_extId            = extId;
			_exampaperId      = exampaperId;
			_tb_QuestionClsId = tb_QuestionClsId;
			_type             = type;
			_title            = title;
			_number           = number;
			_diff             = diff;
			_score            = score;
			_addtime          = addtime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int ExtId
		{
			get {return _extId;}
			set {_extId = value;}
		}

		///<summary>
		///（所属试题类型）
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
		public int tb_QuestionClsId
		{
			get {return _tb_QuestionClsId;}
			set {_tb_QuestionClsId = value;}
		}

		///<summary>
		///（单选，多选……）
		///</summary>
		[DataMember]
		public int Type
		{
			get {return _type;}
			set {_type = value;}
		}

		///<summary>
		///（单选题）
		///</summary>
		[DataMember]
		public string Title
		{
			get {return _title;}
			set {_title = value;}
		}

		///<summary>
		///（单选题数量）
		///</summary>
		[DataMember]
		public int Number
		{
			get {return _number;}
			set {_number = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Diff
		{
			get {return _diff;}
			set {_diff = value;}
		}

		///<summary>
		///（当前单选成绩）
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
		public DateTime Addtime
		{
			get {return _addtime;}
			set {_addtime = value;}
		}
	
		#endregion
		
	}
}
