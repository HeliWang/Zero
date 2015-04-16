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
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        private IRepository<Code> _codeRepository;

        public UserService(IRepository<User> userRepository, IRepository<Code> codeRepository)
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

        public ResultInfo MobileBind(int userId, string mobile, string num)
        {
            var oldUser = _userRepository.GetById(userId);

            if (!string.IsNullOrEmpty(oldUser.Mobile))
            {
                return new ResultInfo(1,"您已经绑定过手机号");
            }

            //手机是否绑定过
            var user = (from u in _userRepository.Table
                        where u.UserId != userId && u.Mobile == mobile
                        select u).FirstOrDefault();

            if (user != null)
            {
                return new ResultInfo(1, "该手机号已被绑定过");
            }

            //判断验证码是否正确
            var code = (from c in _codeRepository.Table
                        where c.UserId == userId && c.CodeType == (int)CodeType.绑定手机
                        select c).OrderByDescending(c => c.CreateTime).FirstOrDefault();

            if (code == null || code.Num != num || code.SendNo != mobile || code.CodeStatus != (int)CodeStatus.发送成功 || (DateTime.Now - code.CreateTime).TotalHours > 12)
            {
                return new ResultInfo(1, "验证码不正确，或者已失效，请重新输入或者获取");
            }

            oldUser.Mobile = mobile;
            _userRepository.Update(oldUser);

            code.CodeStatus = (int)CodeStatus.已验证;
            _codeRepository.Update(code);

            return new ResultInfo("操作成功");
        }

        public ResultInfo EmailBind(int userId, string email, string num)
        {
            var oldUser = _userRepository.GetById(userId);

            if (!string.IsNullOrEmpty(oldUser.Email))
            {
                return new ResultInfo(1, "您已经绑定过邮箱");
            }

            //手机是否绑定过
            var user = (from u in _userRepository.Table
                        where u.UserId != userId && u.Email == email
                        select u).FirstOrDefault();

            if (user != null)
            {
                return new ResultInfo(1, "该邮箱已被绑定过");
            }

            //判断验证码是否正确
            var code = (from c in _codeRepository.Table
                        where c.UserId == userId && c.CodeType == (int)CodeType.绑定邮箱
                        select c).OrderByDescending(c => c.CreateTime).FirstOrDefault();

            if (code == null || code.Num != num || code.SendNo != email || code.CodeStatus != (int)CodeStatus.发送成功 || (DateTime.Now - code.CreateTime).TotalHours > 12)
            {
                return new ResultInfo(1, "验证码不正确，或者已失效，请重新输入或者获取");
            }

            oldUser.Email = email;
            _userRepository.Update(oldUser);

            code.CodeStatus = (int)CodeStatus.已验证;
            _codeRepository.Update(code);

            return new ResultInfo("操作成功");
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public ResultInfo IsExist(string key, string value)
        {
            return new ResultInfo("不存在");
        }

        public IPage<User> GetList(int pageIndex, int pageSize)
        {
            var query = _userRepository.Table;
            query = query.OrderByDescending(c => c.RegTime);
            return new Page<User>(query, pageIndex, pageSize);
        }
    }
}
