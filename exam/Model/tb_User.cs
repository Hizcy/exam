// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User.cs
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
	///tb_User数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_UserEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _userId;
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///
		///</summary>
		private int _departmentId;
		///<summary>
		///
		///</summary>
		private string _path = String.Empty;
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
		private string _pwd = String.Empty;
		///<summary>
		///
		///</summary>
		private string _realName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _sex;
		///<summary>
		///
		///</summary>
		private string _position = String.Empty;
		///<summary>
		///
		///</summary>
		private string _mail = String.Empty;
		///<summary>
		///
		///</summary>
		private string _identityCard = String.Empty;
		///<summary>
		///
		///</summary>
		private string _phone = String.Empty;
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
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_UserEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_UserEntity
		(
			int userId,
			int schoolId,
			int departmentId,
			string path,
			int roleId,
			string name,
			string pwd,
			string realName,
			int sex,
			string position,
			string mail,
			string identityCard,
			string phone,
			string description,
			int status,
			DateTime addtime
		)
		{
			_userId       = userId;
			_schoolId     = schoolId;
			_departmentId = departmentId;
			_path         = path;
			_roleId       = roleId;
			_name         = name;
			_pwd          = pwd;
			_realName     = realName;
			_sex          = sex;
			_position     = position;
			_mail         = mail;
			_identityCard = identityCard;
			_phone        = phone;
			_description  = description;
			_status       = status;
			_addtime      = addtime;
			
		}
		#endregion
		
		#region 公共属性

		
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
		public int SchoolId
		{
			get {return _schoolId;}
			set {_schoolId = value;}
		}

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
		public string Path
		{
			get {return _path;}
			set {_path = value;}
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
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Pwd
		{
			get {return _pwd;}
			set {_pwd = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string RealName
		{
			get {return _realName;}
			set {_realName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int Sex
		{
			get {return _sex;}
			set {_sex = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Position
		{
			get {return _position;}
			set {_position = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Mail
		{
			get {return _mail;}
			set {_mail = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string IdentityCard
		{
			get {return _identityCard;}
			set {_identityCard = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Phone
		{
			get {return _phone;}
			set {_phone = value;}
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
	
		#endregion
		
	}
}
