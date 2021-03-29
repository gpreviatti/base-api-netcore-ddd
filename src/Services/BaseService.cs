using Domain.Entities;
using Domain.Interfaces.Services;

namespace Services
{
    public abstract class BaseService : IBaseService<Entity>
    {
        public BaseService()
        {
        }
    }
}
