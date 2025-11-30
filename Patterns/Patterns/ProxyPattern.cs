using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IService
    {
        string GetData();
    }

    public class RealService : IService
    {
        public string GetData()
        {
            Console.WriteLine("RealService: Выполнение запроса к серверу...");
            Thread.Sleep(3000);
            return $"Данные с сервера (время: {DateTime.Now:HH:mm:ss})";
        }
    }

    public class ProxyService : IService
    {
        private RealService _realService;
        private string _cachedData;
        private DateTime _lastAccessTime;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(5);

        public ProxyService() => _realService = new RealService();

        public string GetData()
        {
            if (_cachedData == null || DateTime.Now - _lastAccessTime > _cacheDuration)
            {
                Console.WriteLine("ProxyService: данные устарели, запрашиваем у RealService...");
                _cachedData = _realService.GetData();
                _lastAccessTime = DateTime.Now;
                return _cachedData;
            }
            else
            {
                Console.WriteLine("ProxyService: возвращаем кэшированные данные...");
                return _cachedData;
            }
        }
    }
}
