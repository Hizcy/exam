// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Department.cs
// 项目名称：买车网
// 创建时间：2015/8/11
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Department数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_DepartmentEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _departmentId;
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///
		///</summary>
		private int _roleId;
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
		public tb_DepartmentEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_DepartmentEntity
		(
			int departmentId,
			int schoolId,
			int roleId,
			int parentId,
			string name,
			string description,
			int status,
			DateTime addtime,
			DateTime updatetime
		)
		{
			_departmentId = departmentId;
			_schoolId     = schoolId;
			_roleId       = roleId;
			_parentId     = parentId;
			_name         = name;
			_description  = description;
			_status       = status;
			_addtime      = addtime;
			_updatetime   = updatetime;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int DepartmentId
		{
			get {return _departmentId;}
			set {_departmentId = value;}
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
		public int RoleId
		{
			get {return _roleId;}
			set {_roleId = value;}
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
