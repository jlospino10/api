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
    public class PlatoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public PlatoController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        //CONSULTA
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select id,nombre,descripcion, imagen, restaurante_id
                        from 
                        Plato
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
                        delete from Plato 
                        where id=@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

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
        public JsonResult Put(Plato pla)
        {
            string query = @"
                        update Plato set 
                        nombre =@PlatoNombre,
                        descripcion =@Platodescripcion , imagen =@PlatoImagen , restaurante_id=@restaurante_id                
                        where id =@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", pla.id);
                    myCommand.Parameters.AddWithValue("@PlatoNombre", pla.nombre);
                    myCommand.Parameters.AddWithValue("@Platodescripcion", pla.descripcion);
                    

                    myCommand.Parameters.AddWithValue("@PlatoImagen", pla.imagen);
                    myCommand.Parameters.AddWithValue("@restaurante_id", pla.restaurante_id);
                    


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
        public JsonResult Post(Models.Plato pla)
        {
            string query = @"
                        insert into Plato 
                        (nombre,descripcion,imagen, restaurante_id) 
                        values
                         (@PlatoNombre,@Platodescripcion,@PlatoImagen, @restaurante_id) ;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                { 
                    
                    myCommand.Parameters.AddWithValue("@PlatoNombre", pla.nombre);
                    myCommand.Parameters.AddWithValue("@Platodescripcion", pla.descripcion);
                    

                    myCommand.Parameters.AddWithValue("@PlatoImagen", pla.imagen);
                    myCommand.Parameters.AddWithValue("@restaurante_id", pla.restaurante_id);
                    

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

