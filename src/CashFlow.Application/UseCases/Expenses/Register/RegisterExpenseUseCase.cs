using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);
        var isValid = result.IsValid;
        
        if(isValid == false)
        {
            /*
            * >> Fazendo a lista de erros usando Loop:
            *
            * var listaDeErros = new List<string>();
            *
            * result.Errors.ForEach(error =>
            * {
            *      listaDeErros.Add(error.ErrorMessage);
            * });
            */

            // >> Fazendo a lista usando LINQ (queries sql para busca no c#):
            var errorMessages = result.Errors
            .Select(validationFailuire => validationFailuire.ErrorMessage)
            .ToList();

            // TODO: Criar uma nova Exception para retornar uma lista de erros ao inves de uma string unica.
            throw new ArgumentException(errorMessages);
        }
    }
}
