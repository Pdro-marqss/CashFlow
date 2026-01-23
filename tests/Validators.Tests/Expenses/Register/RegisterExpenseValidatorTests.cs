using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CommonTestUtilities.Requests;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Os 3 A's do teste unitario: Arrange, Act e Assert - São etapas padronizadas para estruturar testes unitarios

        // 1. Arrange - Instanciando tudo que for necessario para o teste
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        // 2. Act - Executando a ação que queremos testar
        var result = validator.Validate(request);

        // 3. Assert - Verificando se o resultado da ação está de acordo com o esperado
        Assert.True(result.IsValid);
    }
}
