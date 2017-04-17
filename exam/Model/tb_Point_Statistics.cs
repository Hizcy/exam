// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Point_Statistics.cs
// 项目名称：买车网
// 创建时间：2015/8/28
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_Point_Statistics数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_Point_StatisticsEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _id;
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
		private int _point;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_Point_StatisticsEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_Point_StatisticsEntity
		(
			int id,
			int schoolId,
			int userId,
			int point
		)
		{
			_id       = id;
			_schoolId = schoolId;
			_userId   = userId;
			_point    = point;
			
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
		public int Point
		{
			get {return _point;}
			set {_point = value;}
		}
	
		#endregion
		
	}
}
