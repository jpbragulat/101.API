using Microsoft.AspNetCore.Mvc;
using _101.API.Models;
using Microsoft.Extensions.Hosting;
using _101.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Components.Forms;

namespace _101.API.Controllers
{
    [ApiController] 
    [Route("api")]
    public class UserController : ControllerBase
    {
       
        private readonly _101DbContext _context;
      
        public UserController(_101DbContext context)
        {
            _context = context;
        }
        
        [HttpGet("GetAllUsers")]
        public List<Users> Get()
        {
            return _context.Users.ToList();
        }

        [HttpGet("GetAllCars")]
        public List<Cars> GetCars()
        {
            return _context.Cars.ToList();
        }

        [HttpGet("GetUserBy{id}")]
        public Users GetById(int id)
        {
            var userFound = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return userFound;
        }

        [HttpGet("GetCarBy{id}")]
        public Cars GetCarById(int id)
        {
            var carFound = _context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            return carFound;
        }

        [HttpPost("AddUser")]
        public List<Users> AddUsuario(Users usuario)
        {
            _context.Users.Add(usuario);
            _context.SaveChanges();
            return _context.Users.ToList(); //post puede ser void
        }

        [HttpPost("AddCar")]
        public List<Cars> AddCar(Cars usuarioCar)
        {
            _context.Cars.Add(usuarioCar);
            _context.SaveChanges();
            return _context.Cars.ToList();
        }


        [HttpPut("UpdateUser")]
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

        [HttpPut("UpdateCar")]
        public List<Cars> UpdateCar(Cars requestCar)
        {
            var dbCar = _context.Cars.Find(requestCar.CarId);
            dbCar.Modelo = requestCar.Modelo;
            dbCar.CarId = requestCar.CarId;
            dbCar.Age = requestCar.Age;
            dbCar.ColorAuto = requestCar.ColorAuto;
            dbCar.Modelo = requestCar.Modelo;
            return _context.Cars.ToList();
        }

        [HttpDelete("DeleteUser{id}")]
        public List<Users> DeleteUsuarioxId(int id)
        {
            var dbBorrarUsuario = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Users.Remove(dbBorrarUsuario);
            return _context.Users.ToList();
        }

        [HttpDelete("DeleteCar{id}")]
        public List<Cars> DeleteCarxCarId(int id)
        {
            var dbBorrarCar = _context.Cars.Where(x => x.CarId == id).FirstOrDefault();
            _context.Cars.Remove(dbBorrarCar);

            return _context.Cars.ToList();
        }

    }
}