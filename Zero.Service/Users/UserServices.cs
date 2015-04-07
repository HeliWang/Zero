using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Users;
using Zero.Core.Web;

namespace Zero.Service.Users
{
    public class UserServices : IUserServices
    {
        private IRepository<User> _userRepository;

        public UserServices(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public ResultInfo Login(string userName, string password)
        {
            var query = _userRepository.Table;

            query = from u in query
                       where u.UserName == userName
                       select u;

            var user = query.DefaultIfEmpty();

            
            
            return new ResultInfo("登入成功");
        }

        public ResultInfo Register(User user)
        {
            _userRepository.Add(user);

            return new ResultInfo("注册成功");
        }

        public ResultInfo Edit(User user)
        {
            _userRepository.Update(user);

            return new ResultInfo("修改成功");
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public ResultInfo IsExist(string key, string value)
        {

            return new ResultInfo("不存在");
        }
    }
}
