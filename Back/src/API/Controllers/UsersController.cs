using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Models;
using API.Data;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(e => e.ID == id);
        }
        [HttpPost]
        public User Add(User user)
        {
            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            return user;
        }

        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            User u;
            if (id > -1)
            {

                u = _context.Users.FirstOrDefault(e => e.ID == id);
                _context.Users.Remove(u);
                _context.SaveChanges();
                return u;
            }
            return null;
        }


        [HttpPut("{id}")]
        public User Update(int id, User user)

        {
            if (user.ID != null)
            {
                User u;
                u = _context.Users.FirstOrDefault(e => e.ID == id);
                u.Name = user.Name;
                u.Email = user.Email;
                u.Foto = user.Foto;
                u.Telefone = user.Telefone;
                u.Observacoes = user.Observacoes;
                
                _context.Users.Update(u);
                _context.SaveChanges();

                return u;
            }
            return null;

        }

    }
}
