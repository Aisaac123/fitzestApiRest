﻿using Microsoft.AspNetCore.Mvc;

namespace fitzestApiRest.Controllers.Interfaces_and_Abstracts
{
    public interface IControllerCrud<T, Tkey> : IControllerRead<Tkey> where T : class
    {
        Task<IActionResult> Post([FromBody] T entity);
        Task<IActionResult> Delete(Tkey id);
        Task<IActionResult> Put(Tkey id, T entity);
        Task<IActionResult> DeleteAll();
    }
}
