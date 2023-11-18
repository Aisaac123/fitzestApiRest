using fitzestApiRest.Controllers.Interfaces_and_Abstracts;
using fitzestApiRest.Models;
using fitzestApiRest.Models.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

namespace fitzestApiRest.Controllers
{
    public class EjerciciosController : CrudController<Ejercicio, int, FizestDbContext>
    {
        public EjerciciosController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_ejercicio(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Ejercicio entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_nombre", NpgsqlDbType.Varchar) { Value = entity.Nombre },
                    new NpgsqlParameter("p_peso", NpgsqlDbType.Numeric) { Value = entity.Peso },
                    new NpgsqlParameter("p_repeticiones", NpgsqlDbType.Integer) { Value = entity.Repeticiones },
                    new NpgsqlParameter("p_descripcion", NpgsqlDbType.Text) { Value = entity.Descripcion },
                    new NpgsqlParameter("p_tiempodescanso", NpgsqlDbType.Integer) { Value = entity.Tiempodescanso },
                    new NpgsqlParameter("p_consumocalorias", NpgsqlDbType.Numeric) { Value = entity.Consumocalorias },
                    new NpgsqlParameter("p_img", NpgsqlDbType.Varchar) { Value = entity.Img }
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_ejercicio(@p_nombre, @p_peso, @p_repeticiones, @p_descripcion, @p_tiempodescanso, @p_consumocalorias, @p_img)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        protected async override Task<string> UpdateProcedure(Ejercicio entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", OldId),
            new NpgsqlParameter("p_nombre", entity.Nombre),
            new NpgsqlParameter("p_peso", entity.Peso),
            new NpgsqlParameter("p_repeticiones", entity.Repeticiones),
            new NpgsqlParameter("p_descripcion", entity.Descripcion),
            new NpgsqlParameter("p_tiempodescanso", entity.Tiempodescanso),
            new NpgsqlParameter("p_consumocalorias", entity.Consumocalorias)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_ejercicio(@p_id, @p_nombre, @p_peso, @p_repeticiones, @p_descripcion, @p_tiempodescanso, @p_consumocalorias)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        protected async override Task<Ejercicio> SetContextEntity(int id)
        {
            var entity = await _context.Set<Ejercicio>().FirstOrDefaultAsync(arg => arg.Id == id);
            return entity;
        }


        protected async override Task<List<Ejercicio>> SetContextList()
        {
            var list = await _context.Set<Ejercicio>().ToListAsync();
            return list;
        }


    }
}
