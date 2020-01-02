using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // Can be called from anywhere

        private Timer timer;

        public WeatherForecastService()
        {


           timer = new Timer(async o => await Update(Guid.NewGuid().ToString(), 1), null, 100,
                100);
        }
        
        
        public async Task Update(string key, int value)
        {
            if (Notify != null)
            {
                await Notify.Invoke(key, value);
            }
        }

        public event Func<string, int, Task> Notify;
    }
}
