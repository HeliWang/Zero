using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.DomainModel
{
	public class UserService
	{
		private readonly IRepository<User> _rep;
		public UserService(IRepository<User> repository)
		{
			this._rep = repository;
		}

		public string Register(string name, string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				return "未设置密码";
			}
			if (this._rep.Exist(o => o.Name == name))
			{
				return "用户名已存在";
			}
			var user = new User() { Name = name, Password = password };
			this._rep.Save(user);

			return null;
		}
	}
}
