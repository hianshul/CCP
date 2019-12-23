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
    [Route("api/AsyncTest")]
    [ApiController]
    public class AsyncTestController : ControllerBase
    {
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
        [Route("async")]
        public async Task<IActionResult> BlockAsync()
        {
            //await Task.Delay(100000);
            await Task.Factory.StartNew(() =>
            {
                Task.Yield();
                Thread.Sleep(100000);
            });
            return Ok("BlockAsync completed");
        }

        [Route("sync")]
        public IActionResult Blocksync()
        {
            Thread.Sleep(100000);
            return Ok();
        }
    }
}