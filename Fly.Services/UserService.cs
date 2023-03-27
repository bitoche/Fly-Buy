using Fly.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Fly.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
       
        public UserService(IUserRepository userRepository)
        {
            
            this.userRepository = userRepository;

        }
        public BaseResponse<ClaimsIdentity> Register(string name, string password, string login)
        {
            try
            {
                var user = userRepository.GetAll().FirstOrDefault(x => x.Name == name);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть"
                    };
                }
                user = new User()
                {
                    Name = name,
                    Login = login,
                    Password = HashPasswordHelper.HashPassword(password),
                    Role = Role.Common
                };
                userRepository.Create(user);
                var result = Authentificate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };

            }
            catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        private ClaimsIdentity Authentificate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Role.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Balance.ToString())
            };

            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultNameClaimType);
        }

        

        public BaseResponse<ClaimsIdentity> Login(string login, string password)
        {
            try
            {
                var user = userRepository.GetAll().FirstOrDefault(x => x.Login == login);
                if(user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"

                    };
                }

                if(user.Password != HashPasswordHelper.HashPassword(password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль"
                    };
                }

                var result = Authentificate(user);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}

