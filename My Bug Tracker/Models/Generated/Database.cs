



















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `DefaultConnection`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Persist Security Info=False;database=MVC_MyBugTracker;server=GREGG-ACER\SQLEXPRESS;user id=sa;password=**zapped**;`
//     Schema:                 ``
//     Include Views:          `False`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace MyBugTracker
{

	public partial class repoMyBugTracker : Database
	{
		public repoMyBugTracker() 
			: base("DefaultConnection")
		{
			CommonConstruct();
		}

		public repoMyBugTracker(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			repoMyBugTracker GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static repoMyBugTracker GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new repoMyBugTracker();
        }

		[ThreadStatic] static repoMyBugTracker _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static repoMyBugTracker repo { get { return repoMyBugTracker.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    
	[TableName("UserProfile")]


	[PrimaryKey("UserId")]



	[ExplicitColumns]
    public partial class UserProfile : repoMyBugTracker.Record<UserProfile>  
    {



		[Column] public int UserId { get; set; }





		[Column] public string UserName { get; set; }



	}

    
	[TableName("webpages_OAuthMembership")]


	[PrimaryKey("Provider", autoIncrement=false)]

	[ExplicitColumns]
    public partial class webpages_OAuthMembership : repoMyBugTracker.Record<webpages_OAuthMembership>  
    {



		[Column] public string Provider { get; set; }





		[Column] public string ProviderUserId { get; set; }





		[Column] public int UserId { get; set; }



	}

    
	[TableName("webpages_Membership")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class webpages_Membership : repoMyBugTracker.Record<webpages_Membership>  
    {



		[Column] public int UserId { get; set; }





		[Column] public DateTime? CreateDate { get; set; }





		[Column] public string ConfirmationToken { get; set; }





		[Column] public bool? IsConfirmed { get; set; }





		[Column] public DateTime? LastPasswordFailureDate { get; set; }





		[Column] public int PasswordFailuresSinceLastSuccess { get; set; }





		[Column] public string Password { get; set; }





		[Column] public DateTime? PasswordChangedDate { get; set; }





		[Column] public string PasswordSalt { get; set; }





		[Column] public string PasswordVerificationToken { get; set; }





		[Column] public DateTime? PasswordVerificationTokenExpirationDate { get; set; }



	}

    
	[TableName("webpages_Roles")]


	[PrimaryKey("RoleId")]



	[ExplicitColumns]
    public partial class webpages_Role : repoMyBugTracker.Record<webpages_Role>  
    {



		[Column] public int RoleId { get; set; }





		[Column] public string RoleName { get; set; }



	}

    
	[TableName("webpages_UsersInRoles")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class webpages_UsersInRole : repoMyBugTracker.Record<webpages_UsersInRole>  
    {



		[Column] public int UserId { get; set; }





		[Column] public int RoleId { get; set; }



	}

    
	[TableName("Bug")]


	[PrimaryKey("BugId")]



	[ExplicitColumns]
    public partial class Bug : repoMyBugTracker.Record<Bug>  
    {



		[Column] public int BugId { get; set; }





		[Column] public string Issue { get; set; }





		[Column] public string Cause { get; set; }





		[Column] public string Status { get; set; }





		[Column] public string Resolution { get; set; }





		[Column] public string Comments { get; set; }





		[Column] public string Rating { get; set; }





		[Column] public string Tag { get; set; }





		[Column] public DateTime? DateCreated { get; set; }





		[Column] public DateTime? LastModified { get; set; }



	}


}



