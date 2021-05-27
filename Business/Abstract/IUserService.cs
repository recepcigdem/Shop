using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Login(string userName, string password);
    }
}
