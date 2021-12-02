using System;
using System.Threading.Tasks;
using SearchEngine.Models;

namespace SearchEngine.Repositories
{
    public interface IProductRepository
    {
        public  Task<Guid> Save(Product product);

    }
}