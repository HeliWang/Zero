using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Users;
using Zero.Domain.Sys;
using Zero.Core.Web;

namespace Zero.Service.Users
{
    public class UserServices : IUserServices
    {
        private IRepository<User> _userRepository;
        private IRepository<Code> _codeRepository;

        public UserServices(IRepository<User> userRepository, IRepository<Code> codeRepository)
        {
            _userRepository = userRepository;
            _codeRepository = codeRepository;
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

        public ResultInfo PhoneBind(int userId, string phone, string num)
        {
            var oldUser = _userRepository.GetById(userId);

            if (!string.IsNullOrEmpty(oldUser.Phone))
            {
                return new ResultInfo("您已经绑定过手机号");
            }

            //手机是否绑定过
            var user = (from u in _userRepository.Table
                        where u.UserId != userId && u.Phone == phone
                        select u).DefaultIfEmpty();

            if (user != null)
            {
                return new ResultInfo("该手机号已被绑定过");
            }

            //判断验证码是否正确
            var code = (from c in _codeRepository.Table
                        where c.UserId == userId && c.CodeType == (int)CodeType.验证手机
                        select c).OrderByDescending(c => c.CreateTime).DefaultIfEmpty();

            

            oldUser.Phone = phone;
            _userRepository.Update(oldUser);

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
