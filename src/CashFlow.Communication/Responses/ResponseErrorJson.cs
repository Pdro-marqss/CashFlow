namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; }

    // Construtor da classe
    public ResponseErrorJson(string errorMessage)
    {
        // Cria uma lista com uma única mensagem de erro
        var singleErrorMessage = new List<string> { errorMessage };
        ErrorMessages = singleErrorMessage;
    }

    public ResponseErrorJson(List<string> errorMessages)
    {
        // Atribui a lista de mensagens de erro ao atributo ErrorMessages
        ErrorMessages = errorMessages;
    }
}
