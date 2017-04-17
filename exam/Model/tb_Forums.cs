// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Forums.cs
// 项目名称：买车网
// 创建时间：2015/12/16
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Forums数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_ForumsEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _id;
		///<summary>
		///
		///</summary>
		private int _userId;
		///<summary>
		///
		///</summary>
		private int _bookId;
		///<summary>
		///
		///</summary>
		private string _content = String.Empty;
		///<summary>
		///
		///</summary>
		private int _status;
		///<summary>
		///
		///</summary>
		private DateTime _addtime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_ForumsEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_ForumsEntity
		(
			int id,
			int userId,
			int bookId,
			string content,
			int status,
			DateTime addtime
		)
		{
			_id      = id;
			_userId  = userId;
			_bookId  = bookId;
			_content = content;
			_status  = status;
			_addtime = addtime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int UserId
		{
			get {return _userId;}
			set {_userId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int BookId
		{
			get {return _bookId;}
			set {_bookId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Content
		{
			get {return _content;}
			set {_content = value;}
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
	
		#endregion
		
	}
}
