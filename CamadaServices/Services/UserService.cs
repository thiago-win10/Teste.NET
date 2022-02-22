using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Teste.NET.CamadaServices.Authorization;
using Teste.NET.CamadaServices.Interfaces;
using Teste.NET.Domain;
using Teste.NET.CamadaServices.Helpers;
using Teste.NET.Domain.Models;
namespace Teste.NET.CamadaServices.Services
{
    public class UserService : IUserService
    {
        private readonly XYZContext _context;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            XYZContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);


            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new Exception("Usuario ou Senha incorretos.");

            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
            
                  
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(RegisterRequest model)
        {

            if (_context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' já existe");

            var user = _mapper.Map<User>(model);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);


            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                throw new AppException("Username '" + model.Username + "' is already taken");


            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);


            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("Usuário nao encontrado.");
            return user;
        }


    }
}


