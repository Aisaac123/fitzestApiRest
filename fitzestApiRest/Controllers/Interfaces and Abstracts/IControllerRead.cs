using Microsoft.AspNetCore.Mvc;

namespace fitzestApiRest.Controllers.Interfaces_and_Abstracts
{
    public interface IControllerRead<IdType>
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetById(IdType id);

    }
}
