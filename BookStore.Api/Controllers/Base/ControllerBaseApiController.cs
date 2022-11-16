using BookStore.Domain.Interfaces.Services.Base;
using BookStore.Domain.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Base;

public class ControllerBaseApiController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private IServiceBase _serviceBase;

    public ControllerBaseApiController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ActionResult<T>> ResponseAsync<T>(object result, IServiceBase serviceBase)
    {
        _serviceBase = serviceBase;

        if (!serviceBase.Notifications.Any())
            try
            {
                _unitOfWork.Commit();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Aqui devo logar o erro
                return NotFound(
                    $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }

        return BadRequest(new { errors = serviceBase.Notifications });
    }

    protected BadRequestObjectResult ResponseExceptionAsync(Exception ex)
    {
        return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
    }

    protected void Dispose(bool disposing)
    {
        //Realiza o dispose no serviço para que possa ser zerada as notificações
        if (_serviceBase != null) _serviceBase.Dispose();
    }
}
