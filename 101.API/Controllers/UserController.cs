using Microsoft.AspNetCore.Mvc;
using _101.API.Models;
using Microsoft.Extensions.Hosting;
using _101.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace _101.API.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       
        private readonly _101DbContext _context;
      
        public UserController(_101DbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public List<Users> Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public Users GetById(int id)
        {
            var userFound = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return userFound;
        }

        [HttpPost]
        public List<Users> AddUsuario(Users usuario)
        {
            _context.Users.Add(usuario);
            return _context.Users.ToList();
        }
        
        [HttpPut]
        public List<Users> UpdateUsuario(Users request)
        {
            var dbUsuario = _context.Users.Find(request.Id);
            dbUsuario.UserName = request.UserName;
            dbUsuario.FirstName = request.FirstName;
            dbUsuario.LastName = request.LastName;
            dbUsuario.Country = request.Country;
            dbUsuario.State = request.State;
            dbUsuario.City = request.City;
            return _context.Users.ToList();

        }

        [HttpDelete("{id}")]
        public List<Users> DeleteUsuarioxId(int id)
        {
            var dbBorrarUsuario = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Users.Remove(dbBorrarUsuario);
            return _context.Users.ToList();
        }

    }
}