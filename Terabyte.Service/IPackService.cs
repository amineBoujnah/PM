using SERVICE.PATTERN;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
    public interface IPackService : IService<Pack>
    {

        void CreatePack(Pack p);
        void Commit();
        void Dispose();

    }
}
