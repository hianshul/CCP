using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebAppCore.Controllers
{
    [Route("api/sqlasynctest")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly string _connectionString = "server=.;uid=sa;pwd=Tpg@123";

        [Route("GetThreads")]
        public IActionResult GetThreads()
        {
            ThreadPool.GetAvailableThreads(out int wt, out int cpt);
            return Ok(new
            { 
             WorkderThreads = wt,
             CompletionPortThreads = cpt
            });

        }
       
        [HttpGet("sqlsync")]
        public IActionResult SqlSync()
        {            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand("WAITFOR DELAY '00:00:20';", connection);
                cmd.ExecuteNonQuery();
            }

            return Ok();
        }

        [HttpGet("sqlasync")]
        public async Task<IActionResult> SqlAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var cmd = new SqlCommand("WAITFOR DELAY '00:00:20';", connection);
                await cmd.ExecuteNonQueryAsync();
            }

            return Ok();
        }

    }
}