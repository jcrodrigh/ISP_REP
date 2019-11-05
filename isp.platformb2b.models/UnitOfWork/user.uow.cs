using AutoMapper;
using isp.platformb2b.data;
using isp.platformb2b.data.DatabaseModels;
using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;




namespace isp.platformb2b.models.UnitOfWork
{
    public interface IUserService
    {
        UserSignIn Authenticate(UserLoginDTO userLogin);

        List<NavBarByRoles> GetNavBarByRoles(string username);
    }

    public class UserService : IUserService
    {
        private readonly EFDataContext _dbContext;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserService(EFDataContext dbContext,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public UserSignIn Authenticate(UserLoginDTO userLogin)
        {
            var user = _dbContext.usuarios
                       .Where(us => us.username == userLogin.username 
                                && us.password == userLogin.password
                                && us.activo)
                       .Select(us => new UserSignIn
                       {
                           username = us.username,
                           ruc_empresa = us.ruc_empresa,

                           roles = us.ti_roles_empresa.
                                Select(rol => rol.tipo_Rol.nombre_rol)
                                .ToList()
                       }).SingleOrDefault<UserSignIn>();

            // return null if user not found
                if (user == null)
                return null;

            List<Claim> claims = new List<Claim>  {
                    new Claim(ClaimTypes.Name, user.ruc_empresa),
                    new Claim(ClaimTypes.Sid, user.username)
            };

            foreach (var role in user.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    claims
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;
        }

        public List<NavBarByRoles> GetNavBarByRoles(string username)
        {
            //var temp = _dbContext.tipo_menu
            //    .Join(_dbContext.ti_roles_menu,tm=> tm.id_tipo_menu,tmc );



            var query = from tm in _dbContext.tipo_menu
            join titmro in _dbContext.ti_roles_menu on tm.id_tipo_menu equals titmro.id_tipo_menu
            join tr in _dbContext.tipo_roles on titmro.id_tipo_roles equals tr.id_tipo_roles
            join titrus in _dbContext.ti_usuario_roles on tr.id_tipo_roles equals titrus.id_tipo_roles
            where titrus.Equals(username)
            select new NavBarByRoles
            {
                id_tipo_menu = tm.id_tipo_menu,
                icon = tm.icon,
                id_tipo_menu_padre = tm.id_tipo_menu_padre,
                name = tm.name,
                url = tm.url
            };

            var temp = query.ToList();
            List < NavBarByRoles > nv = new List<NavBarByRoles>();

            _mapper.Map(temp, nv);

            return nv;
        }
    }
}
