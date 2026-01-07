using CashFlow.Communication.Enums;
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
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if(titleIsEmpty)
        {
            throw new ArgumentException("Title value is required.");
        }

        var amountIsZeroOrNegative = request.Amount <= 0;
        if(amountIsZeroOrNegative)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        var dateCompareResult = DateTime.Compare(request.Date, DateTime.UtcNow);
        var dateIsInFuture = dateCompareResult > 0;
        if (dateIsInFuture)
        {
            throw new ArgumentException("Expenses cannot be for the future.");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if(paymentTypeIsValid == false)
        {
            throw new ArgumentException("Payment Type is not valid.");
        }
    }
}
