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
    public class ReservasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ReservasController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        //CONSULTA
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select i.id,c.nombre, s.nombre, i.fecha
                        from 
                        Reserva i join Cliente  c on i.cliente=c.id join Servicio s on i.servicio=s.id
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
                        delete from Reserva 
                        where id=@Reservaid;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Reservaid", id);

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
        public JsonResult Put(Reservas reserva)
        {
            string query = @"
                        update Reserva set 
                        cliente =@Reservacliente,
                        servicio =@Reservaservicio , fecha =@Reservafecha            
                        where id =@Reservaid;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Reservaid", reserva.id);
                    myCommand.Parameters.AddWithValue("@Reservacliente", reserva.cliente);
                    myCommand.Parameters.AddWithValue("@Reservaservicio", reserva.servicio);
                    myCommand.Parameters.AddWithValue("@Reservafecha", reserva.fecha); 


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
        public JsonResult Post(Models.Reservas reservas)
        {
            string query = @"
                        insert into Reserva
                        (cliente,servicio, fecha) 
                        values
                         (@Reservacliente,@Reservaservicio,@Reservafecha);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                { 
                    myCommand.Parameters.AddWithValue("@Reservacliente", reservas.cliente);
                    myCommand.Parameters.AddWithValue("@Reservaservicio", reservas.servicio);
                    myCommand.Parameters.AddWithValue("@Reservafecha", reservas.fecha);
                     

                    
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

