using fitzestApiRest.Controllers.Interfaces_and_Abstracts;
using fitzestApiRest.Models;
using fitzestApiRest.Models.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace fitzestApiRest.Controllers
{
    public class EstadoController : CrudController<Estado, int, FizestDbContext>
    {
        public EstadoController(FizestDbContext context) : base(context)
        {
        }

        protected async override Task<string> DeleteProcedure(int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_estado(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Estado entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {

            new NpgsqlParameter("p_limite_proteina", NpgsqlDbType.Numeric) { Value = entity.LimiteProteina },
            new NpgsqlParameter("p_limite_calorias", NpgsqlDbType.Numeric) { Value = entity.LimiteCalorias },
            new NpgsqlParameter("p_ultima_modificacion", NpgsqlDbType.Date) { Value = entity.UltimaModificacion }
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_estado( @p_limite_proteina, @p_limite_calorias, @p_ultima_modificacion)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        protected async override Task<string> UpdateProcedure(Estado entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", NpgsqlDbType.Integer) { Value = OldId },
            new NpgsqlParameter("p_limite_proteina", NpgsqlDbType.Numeric) { Value = entity.LimiteProteina },
            new NpgsqlParameter("p_limite_calorias", NpgsqlDbType.Numeric) { Value = entity.LimiteCalorias },
            new NpgsqlParameter("p_ultima_modificacion", NpgsqlDbType.Date) { Value = entity.UltimaModificacion }
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_estado(@p_id, @p_limite_proteina, @p_limite_calorias, @p_ultima_modificacion)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<Estado> SetContextEntity(int id)
        {
            var entity = await _context.Set<Estado>().FirstOrDefaultAsync(arg => arg.Id == id);

            return entity;
        }

        protected async override Task<List<Estado>> SetContextList()
        {
            var list = await _context.Set<Estado>().ToListAsync();
            return list;
        }

    }
}
