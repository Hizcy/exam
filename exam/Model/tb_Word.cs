// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Word.cs
// 项目名称：买车网
// 创建时间：2015/12/24
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Word数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_WordEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _id;
		///<summary>
		///
		///</summary>
		private int _roleId;
		///<summary>
		///
		///</summary>
		private int _userId;
		///<summary>
		///
		///</summary>
		private string _word = String.Empty;
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
		public tb_WordEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_WordEntity
		(
			int id,
			int roleId,
			int userId,
			string word,
			int status,
			DateTime addtime,
			DateTime updatetime
		)
		{
			_id         = id;
			_roleId     = roleId;
			_userId     = userId;
			_word       = word;
			_status     = status;
			_addtime    = addtime;
			_updatetime = updatetime;
			
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
		public int RoleId
		{
			get {return _roleId;}
			set {_roleId = value;}
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
		public string Word
		{
			get {return _word;}
			set {_word = value;}
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
