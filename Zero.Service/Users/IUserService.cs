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
    public interface IUserService
    {
        ResultInfo Login(string userName, string password);

        ResultInfo Register(User user);

        ResultInfo Edit(User user);

        ResultInfo MobileBind(int userId, string phone, string num);

        ResultInfo EmailBind(int userId, string email, string num);

        User GetById(int userId);

        ResultInfo IsExist(string key, string value);

        IPage<User> GetList(int pageIndex, int pageSize);
    }
}
