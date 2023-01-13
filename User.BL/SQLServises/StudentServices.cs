using Main_Project.BL.DTO;
using Main_Project.Interfaces;
using Main_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Main_Project.BL.JWT;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Main_Project.BL.SQLServises
{
    public class StudentServices : IStudentServices
    {
        private readonly IUnitOfWork Uof;
        protected IMapper Mapper;


        public StudentServices(IUnitOfWork uof, IMapper mapper)
        {
            Uof = uof;
            Mapper = mapper;
        }

        public async Task<User> AddStudent(StudentDTO obj)
        {
            User loc = Mapper.Map<StudentDTO, User>(obj);
            var res = await Uof.Students.Add(loc);
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<StudentDTO> GetStudentById(string? StudentID)
        {
            var res = Mapper.Map<User, StudentDTO>
            (await Uof.Students.GetById(StudentID));
            return res;
        }

        public async Task<IEnumerable<StudentDTO>> GetAll()
        {

            var students = await Uof.Students.AllS();
            var res = Mapper.Map<IEnumerable<User>, IEnumerable<StudentDTO>>(students);
            return res;
        }

        public async Task<StudentDTO> UpdateStudent(StudentDTO obj)
        {
            User location = Mapper.Map<User>(obj);
            var res = Mapper.Map<User, StudentDTO>
            (await Uof.Students.Update(location));
            await Uof.SaveChangesAsync();
            return res;
        }

        public async Task<bool> DeleteStudent(string StudentID)
        {
            return await Uof.Students.DeleteById(StudentID);
        }

        public async Task<string> Login(UserLoginDTO userLogin)
        {
            var user = await Uof.Students.Login(userLogin.Email, userLogin.Password);
            if (user != null)
            {
                var mappedUser = Mapper.Map<User, StudentDTO>(user);
                return TokenManager.CteateTokens(mappedUser);
            }
            return null;
        }

        public async Task<StudentDTO> GetStudentByAccessToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(JWTconfig.KEY);

                var tokenVakidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                var principle = tokenHandler.ValidateToken(token, tokenVakidationParameters, out SecurityToken securityToken);

                if (securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var email = principle.FindFirst(ClaimTypes.Email)?.Value;
                    var user = await Uof.Students.GetByEmail(email);
                    var mappedStudent = Mapper.Map<User, StudentDTO>(user);
                    return mappedStudent;
                }
            }
            catch (Exception)
            {
                return new StudentDTO();
            }

            return new StudentDTO();
        }

        public async Task<bool> Register(RegisterDTO register)
        {

            User student = new User()
            {
                Fullname = register.FullName,
                City = register.City,
                PhoneNumber = register.PhoneNumber,
                Email = register.Gmail,
                PasswordHash = register.Password,
                PhoneNumberConfirmed = false,
                EmailConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                LockoutEnd = DateTime.Now,
                AccessFailedCount = 0,
                UserName = register.FullName,
                StudyingformID = "1"
            };

            var result = await Uof.Students.Add(student);
            var checkIfExists = await Uof.Students.GetByEmail(register.Gmail);
            return checkIfExists != null ? true : false;
        }

        public Task<User> DeleteStudent(User id)
        {
            throw new NotImplementedException();
        }
    }
}
