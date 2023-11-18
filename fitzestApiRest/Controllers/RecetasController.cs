using fitzestApiRest.Controllers.Interfaces_and_Abstracts;
using fitzestApiRest.Models;
using fitzestApiRest.Models.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace fitzestApiRest.Controllers
{
    public class RecetaController : CrudController<Receta, int, FizestDbContext>
    {
        public RecetaController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_recetas(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        protected async override Task<string> InsertProcedure(Receta entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_calorias", NpgsqlDbType.Numeric) { Value = entity.Calorias },
                    new NpgsqlParameter("p_proteinas", NpgsqlDbType.Numeric) { Value = entity.Proteinas },
                    new NpgsqlParameter("p_id_dieta", NpgsqlDbType.Integer) { Value = entity.IdDieta },
                    new NpgsqlParameter("p_nombre", NpgsqlDbType.Varchar) { Value = entity.Nombre },
                    new NpgsqlParameter("p_img", NpgsqlDbType.Varchar) { Value = entity.Img } // Agregado para la nueva columna img
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_recetas(@p_calorias, @p_proteinas, @p_id_dieta, @p_nombre, @p_img)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        protected async override Task<string> UpdateProcedure(Receta entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId),
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_proteinas", entity.Proteinas),
                    new NpgsqlParameter("p_id_dieta", entity.IdDieta)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_recetas(@p_id, @p_calorias, @p_proteinas, @p_id_dieta)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected async override Task<Receta> SetContextEntity(int id)
        {
            var entity = await _context.Set<Receta>().Include(arg => arg.Prepararcomida)
                .ThenInclude(arg => arg.Ingrediente)
                .FirstOrDefaultAsync(arg => arg.Id == id);

            return entity;
        }

        protected async override Task<List<Receta>> SetContextList()
        {
            var list = await _context.Set<Receta>().Include(arg => arg.Prepararcomida).ThenInclude(arg => arg.Ingrediente).ToListAsync();
            return list;
        }

    }
}
