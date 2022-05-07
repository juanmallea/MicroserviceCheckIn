using Microsoft.EntityFrameworkCore;
using CheckIn.Domain.Model.Productos;
using CheckIn.Domain.Repositories;
using CheckIn.Infraestructure.EF.Contexts;
using System;
using System.Threading.Tasks;

namespace CheckIn.Infraestructure.EF.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        public readonly DbSet<Producto> _productos;

        public ProductoRepository(WriteDbContext context)
        {
            _productos = context.Producto;
        }
        public async Task CreateAsync(Producto obj)
        {
            await _productos.AddAsync(obj);
        }

        public async Task<Producto> FindByIdAsync(Guid id)
        {
            return await _productos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Producto obj)
        {
            _productos.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Producto obj)
        {
            _productos.Update(obj);
            return Task.CompletedTask;
        }
    }
}
