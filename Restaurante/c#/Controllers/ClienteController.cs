using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Restaurante.Models;

namespace Restaurante.Controllers
{
    //  api/Client
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ClienteController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        //CONSULTA
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select id,nombre,descripcion, usuario, pass, imagen
                        from 
                        Cliente
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        //ELIMINACION
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from Cliente 
                        where id=@Cliente;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Cliente", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
        //MODIFICAR
        [HttpPut]
        public JsonResult Put(Cliente cli)
        {
            string query = @"
                        update Cliente set 
                        nombre =@ClienteNombre,
                        descripcion =@ClienteApellido , usuario =@ClienteUser,  pass =@ClientePass ,  imagen =@ClienteImagen                 
                        where id =@ClienteId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ClienteId", cli.id);
                    myCommand.Parameters.AddWithValue("@ClienteNombre", cli.nombre);
                    myCommand.Parameters.AddWithValue("@ClienteApellido", cli.apellido);
                    myCommand.Parameters.AddWithValue("@ClienteUser", cli.user);
                    myCommand.Parameters.AddWithValue("@ClientePass", cli.pass);

                    myCommand.Parameters.AddWithValue("@ClienteImagen", cli.imagen);
                    


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

  //AÑEDIR
        [HttpPost]
        public JsonResult Post(Models.Cliente cli)
        {
            string query = @"
                        insert into Cliente 
                        (nombre,descripcion,usuario,pass,imagen) 
                        values
                         (@ClienteNombre,@ClienteApellido,@ClienteUser,@ClientePass,@ClienteImagen) ;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                { 
                    myCommand.Parameters.AddWithValue("@ClienteNombre", cli.nombre);
                    myCommand.Parameters.AddWithValue("@ClienteApellido", cli.apellido);
                    myCommand.Parameters.AddWithValue("@ClienteUser", cli.user);
                    myCommand.Parameters.AddWithValue("@ClientePass", cli.pass);
                    myCommand.Parameters.AddWithValue("@ClienteImagen", cli.imagen);
                    
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

    }

}

