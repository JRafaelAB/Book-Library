using Domain.Exceptions;
using Domain.Extensions;
using Domain.Resources;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base;

public abstract class ValidatorControllerBase : ControllerBase
{
    protected void ValidateRequest<T>(T request)
    {
        if(request == null) throw new InvalidRequestException(Messages.InvalidRequest);
        
        if (!TryValidateModel(request)) throw new InvalidRequestException(ModelState.GetErrorList());
    }
}
