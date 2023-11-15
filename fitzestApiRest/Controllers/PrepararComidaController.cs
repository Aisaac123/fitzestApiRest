using fitzestApiRest.Controllers.Interfaces_and_Abstracts;
using fitzestApiRest.Models;
using fitzestApiRest.Models.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestApiRest.Controllers
{
    public class PrepararComidaController : CrudController<PrepararComida, int, FizestDbContext>
    {
        public PrepararComidaController(FizestDbContext context) : base(context)
        {
        }

        protected async override Task<string> DeleteProcedure(int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId) // OldId es el Id que se utilizará en la cláusula WHERE
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_preparar_comida(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(PrepararComida entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id_recetas", entity.IdRecetas),
                    new NpgsqlParameter("p_id_alimentos", entity.IdAlimentos),
                    new NpgsqlParameter("p_numero_ingredientes", entity.NumeroIngredientes),
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_proteinas", entity.Proteinas)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_preparar_comida(@p_id_recetas, @p_id_alimentos, @p_numero_ingredientes, @p_calorias, @p_proteinas)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        protected async override Task<string> UpdateProcedure(PrepararComida entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId), // OldId es el Id antiguo que se usará en la cláusula WHERE
                    new NpgsqlParameter("p_id_recetas", entity.IdRecetas),
                    new NpgsqlParameter("p_id_alimentos", entity.IdAlimentos)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_preparar_comida(@p_id, @p_id_recetas, @p_id_alimentos)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected async override Task<List<PrepararComida>> SetContextList()
        {
            var list = await _context.Set<PrepararComida>().Include(arg => arg.Ingrediente).Include(arg => arg.Receta).ToListAsync();
            return list;
        }

        protected async override Task<PrepararComida> SetContextEntity(int id)
        {
            var entity = await _context.Set<PrepararComida>().Include(arg => arg.Ingrediente).Include(arg => arg.Receta).FirstOrDefaultAsync(arg => arg.Id == id);
            return entity;
        }

    }
}
