using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> Login(string userName, string password)
        {
            var user = _userDal.Get(u => u.UserName == userName && u.Password == password);
            if (user == null)
                return new ErrorDataResult<User>(Messages.UserNotFound);

            return new DataResult<User>(user, true, Messages.SuccessfulLogin);
        }
    }
}
