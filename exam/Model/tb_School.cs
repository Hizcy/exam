// =================================================================== 
// 项目说明
//====================================================================
// 杨晓光。@Copy Right 2014
// 文件： tb_School.cs
// 项目名称：买车网
// 创建时间：2015/9/7
// 负责人：杨晓光
// ===================================================================
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel;
namespace Exam.Entity
{
	/// <summary>
	///tb_School数据实体
	/// </summary>
	[Serializable]
	[DataContract]
	public class tb_SchoolEntity
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private int _schoolId;
		///<summary>
		///
		///</summary>
		private string _name = String.Empty;
		///<summary>
		///
		///</summary>
		private string _domain = String.Empty;
		///<summary>
		///
		///</summary>
		private int _locationId;
		///<summary>
		///
		///</summary>
		private int _agent;
		///<summary>
		///
		///</summary>
		private string _linkman = String.Empty;
		///<summary>
		///
		///</summary>
		private string _mail = String.Empty;
		///<summary>
		///
		///</summary>
		private string _phone = String.Empty;
		///<summary>
		///
		///</summary>
		private string _tel = String.Empty;
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
		///<summary>
		///
		///</summary>
		private DateTime _begintime;
		///<summary>
		///
		///</summary>
		private DateTime _endtime;
		#endregion
		
		#region 构造函数

		///<summary>
		///
		///</summary>
		public tb_SchoolEntity()
		{
		}
		///<summary>
		///
		///</summary>
		public tb_SchoolEntity
		(
			int schoolId,
			string name,
			string domain,
			int locationId,
			int agent,
			string linkman,
			string mail,
			string phone,
			string tel,
			int status,
			DateTime addtime,
			DateTime updatetime,
			DateTime begintime,
			DateTime endtime
		)
		{
			_schoolId   = schoolId;
			_name       = name;
			_domain     = domain;
			_locationId = locationId;
			_agent      = agent;
			_linkman    = linkman;
			_mail       = mail;
			_phone      = phone;
			_tel        = tel;
			_status     = status;
			_addtime    = addtime;
			_updatetime = updatetime;
			_begintime  = begintime;
			_endtime    = endtime;
			
		}
		#endregion
		
		#region 公共属性

		
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
		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Domain
		{
			get {return _domain;}
			set {_domain = value;}
		}

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
		public int Agent
		{
			get {return _agent;}
			set {_agent = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Linkman
		{
			get {return _linkman;}
			set {_linkman = value;}
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
		public string Phone
		{
			get {return _phone;}
			set {_phone = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public string Tel
		{
			get {return _tel;}
			set {_tel = value;}
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

		///<summary>
		///
		///</summary>
		[DataMember]
		public DateTime Begintime
		{
			get {return _begintime;}
			set {_begintime = value;}
		}

		///<summary>
		///
		///</summary>
		[DataMember]
		public DateTime Endtime
		{
			get {return _endtime;}
			set {_endtime = value;}
		}
	
		#endregion
		
	}
}
