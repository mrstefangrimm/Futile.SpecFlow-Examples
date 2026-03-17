using Microsoft.AspNetCore.Mvc;

namespace WebCalculatorApi.Controllers;

[Route("api/calculation")]
[ApiController]
public class CalculationController : ControllerBase
{
    [HttpPost]
    public CalculationResponse Post([FromBody] CalcuationRequest value)
    {
        return value.MathOperation switch
        {
            "Add" => new CalculationResponse(value.FirstNumber + value.SecondNumber),
            "Subtract" => new CalculationResponse(value.FirstNumber - value.SecondNumber),
            "Multiply" => new CalculationResponse(value.FirstNumber * value.SecondNumber),
            "Divide" => value.SecondNumber != 0
                                ? new CalculationResponse(value.FirstNumber * 1d / value.SecondNumber)
                                : throw new DivideByZeroException("Cannot divide by zero."),
            _ => throw new ArgumentException($"Unknown operation: {value.MathOperation}"),
        };
    }
}

public record CalcuationRequest(int FirstNumber, int SecondNumber, string MathOperation)
{
}

public record CalculationResponse(double Result)
{
}
