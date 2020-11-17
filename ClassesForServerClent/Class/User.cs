﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ClassesForServerClent.Class
{
	[Serializable]
	[Table("User")]
	public class User
	{
		private Int32 id;
		private String name;
		private String password;
		private DateTime dater;
		private DateTime? dateB;
		private String rname;
		private String status;

		public User(Int32 id, String name, String realName)
		{
			try
			{
				ID = id;
				Name = name;
				RealName = realName;
			}
			catch { throw; }
		}
		public User(Int32 id, String name, DateTime dateReg, String realName, Byte[] icon, Status status, String status2) : this(id, name, realName)
		{
			try
			{
				Icon = icon;
				Status = status;
				Status2 = status2;
				DateReg = dateReg;
			}
			catch { throw; }
		}

		public Int32 ID
		{
			get => id;
			set
			{
				if (value < 0)
					throw new ArgumentException("value < 0", nameof(value));

				id = value;
			}
		}
		[Required]
		public String Name
		{
			get => name;
			set
			{
				if (String.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("The nickname cannot be empty!");

				if (value.Length > 50)
					throw new ArgumentNullException("The nickname is longer than 50 characters!");

				name = value;
			}
		}
		[Required]
		public String RealName
		{
			get => rname;
			set
			{
				if (String.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("The Name cannot be empty!");

				if (value.Length > 50)
					throw new ArgumentNullException("The Name is longer than 50 characters!");

				rname = value;
			}
		}
		public Byte[] Icon { get; set; }

		[Column(TypeName = "int")]
		public Status Status { get; set; }

		public String Status2
		{
			get => status;
			set
			{
				if (value?.Length > 100)
					throw new ArgumentException("The status length is too long!");

				status = value;
			}
		}

		[Column(TypeName = "date")]
		public DateTime DateReg
		{
			get => dater;
			set
			{
				if ((value) > DateTime.Now)
					throw new ArgumentException("Are you trying to register in the future!? ");

				dater = value;
			}
		}

		[Column(TypeName = "date")]
		public DateTime? DateOfBirht
		{
			get => dateB;
			set
			{
				if ((value) > DateTime.Now)
					throw new ArgumentException("Were you born in the future!?");

				dateB = value;
			}
		}

		public String Password
		{
			get => password;
			set
			{
				if (String.IsNullOrEmpty(value))
					throw new ArgumentNullException("The password can't be empty!");

				if (value.Length < 6 || value.Length > 15)
					throw new ArgumentException("The password must be between 6 and 15 characters long!");

				password = value;
			}
		}

		[NotMapped]
		public ActionForServer? ActionForServer { get; set; } = null;

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public User()
		{
			EventLog = new HashSet<EventLog>();
			Message = new HashSet<Message>();
			Opinion = new HashSet<Opinion>();
			Request = new HashSet<Request>();
			Request1 = new HashSet<Request>();
			ServerUser = new HashSet<ServerUser>();
			UserLog = new HashSet<UserLog>();
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public ICollection<EventLog> EventLog { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public ICollection<Message> Message { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public ICollection<Opinion> Opinion { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public ICollection<Request> Request { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public ICollection<Request> Request1 { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public ICollection<ServerUser> ServerUser { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public ICollection<UserLog> UserLog { get; set; }
	}
}