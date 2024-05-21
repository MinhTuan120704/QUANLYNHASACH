using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IConsumerService
    {
        bool AddConsumer(Consumer consumer);
        bool DeleteConsumer(Consumer consumer);
        bool UpdateConsumer(Consumer consumer);
        List<Consumer> GetAllConsumer();
    }
}
