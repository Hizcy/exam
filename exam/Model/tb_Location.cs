// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_Location.cs
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
	///tb_Location数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_LocationEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _locationId;
		///<summary>
		///
		///</summary>
		private int _locationParentId;
		///<summary>
		///
		///</summary>
		private int _locationGroupId;
		///<summary>
		///
		///</summary>
		private string _locationName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _locationRemark = String.Empty;
		///<summary>
		///
		///</summary>
		private int _locationStatus;
		///<summary>
		///
		///</summary>
		private string _locationPath = String.Empty;
		///<summary>
		///
		///</summary>
		private int _locationGeographyTypeId;
		///<summary>
		///
		///</summary>
		private int _locationBusinessTypeId;
		///<summary>
		///
		///</summary>
		private string _locationShortName = String.Empty;
		///<summary>
		///
		///</summary>
		private string _locationSpellName = String.Empty;
		///<summary>
		///
		///</summary>
		private int _otherParentId;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_LocationEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_LocationEntity
		(
			int locationId,
			int locationParentId,
			int locationGroupId,
			string locationName,
			string locationRemark,
			int locationStatus,
			string locationPath,
			int locationGeographyTypeId,
			int locationBusinessTypeId,
			string locationShortName,
			string locationSpellName,
			int otherParentId
		)
		{
			_locationId              = locationId;
			_locationParentId        = locationParentId;
			_locationGroupId         = locationGroupId;
			_locationName            = locationName;
			_locationRemark          = locationRemark;
			_locationStatus          = locationStatus;
			_locationPath            = locationPath;
			_locationGeographyTypeId = locationGeographyTypeId;
			_locationBusinessTypeId  = locationBusinessTypeId;
			_locationShortName       = locationShortName;
			_locationSpellName       = locationSpellName;
			_otherParentId           = otherParentId;
			
		}
		#endregion
		
		#region 公共属性

		
		///<summary>
		///
		///</summary>
		[DataMember]
		public int LocationId
		{
			get {return _locationId;}
			set {_locationId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int LocationParentId
		{
			get {return _locationParentId;}
			set {_locationParentId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int LocationGroupId
		{
			get {return _locationGroupId;}
			set {_locationGroupId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LocationName
		{
			get {return _locationName;}
			set {_locationName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LocationRemark
		{
			get {return _locationRemark;}
			set {_locationRemark = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int LocationStatus
		{
			get {return _locationStatus;}
			set {_locationStatus = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LocationPath
		{
			get {return _locationPath;}
			set {_locationPath = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int LocationGeographyTypeId
		{
			get {return _locationGeographyTypeId;}
			set {_locationGeographyTypeId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int LocationBusinessTypeId
		{
			get {return _locationBusinessTypeId;}
			set {_locationBusinessTypeId = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LocationShortName
		{
			get {return _locationShortName;}
			set {_locationShortName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string LocationSpellName
		{
			get {return _locationSpellName;}
			set {_locationSpellName = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public int OtherParentId
		{
			get {return _otherParentId;}
			set {_otherParentId = value;}
		}
	
		#endregion
		
	}
}
