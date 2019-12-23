using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore
{
    public class VoidAsyncTest
    {
        public async Task A1()
        {
            await B();
        }
        public async void A2()
        {
            await B();
        }
                
        public async void A3()
        {
            try
            {
                await B();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch B");
                throw;
            }
        }
        public Task B()
        {
            throw new NotImplementedException();
        }
    }
}
