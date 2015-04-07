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
    public interface IUserServices
    {
        ResultInfo Login(string userName, string password);

        ResultInfo Register(User user);

        ResultInfo Edit(User user);

        User GetById(int userId);

        ResultInfo IsExist(string key, string value);
    }
}
