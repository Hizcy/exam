// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Role.cs
// 项目名称：买车网
// 创建时间：2015/8/10
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Role数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_RoleEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _roleId;
		///<summary>
		///
		///</summary>
		private string _name = String.Empty;
		///<summary>
		///
		///</summary>
		private int _permissions;
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
		public tb_RoleEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_RoleEntity
		(
			int roleId,
			string name,
			int permissions,
			int status,
			DateTime addtime
		)
		{
			_roleId      = roleId;
			_name        = name;
			_permissions = permissions;
			_status      = status;
			_addtime     = addtime;
			
		}
		#endregion
		
		#region 公共属性

		
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
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Permissions
		{
			get {return _permissions;}
			set {_permissions = value;}
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
