// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_User_Department.cs
// 项目名称：买车网
// 创建时间：2015/8/25
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_User_Department数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_User_DepartmentEntity
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
		private int _userId;
		///<summary>
		///
		///</summary>
		private string _departmentId = String.Empty;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_User_DepartmentEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_User_DepartmentEntity
		(
			int relationId,
			int schoolId,
			int userId,
			string departmentId
		)
		{
			_relationId   = relationId;
			_schoolId     = schoolId;
			_userId       = userId;
			_departmentId = departmentId;
			
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
		public int UserId
		{
			get {return _userId;}
			set {_userId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string DepartmentId
		{
			get {return _departmentId;}
			set {_departmentId = value;}
		}
	
		#endregion
		
	}
}
