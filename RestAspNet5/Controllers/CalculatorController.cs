using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace RestAspNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firtsNumber}/{secondNumber}")]
        public IActionResult Sum(string firtsNumber, string secondNumber)
        {
            if (IsNumeric(firtsNumber) && IsNumeric(secondNumber))
            {
                var resultSum = ConvertToDecimal(firtsNumber) + ConvertToDecimal(secondNumber);
                return Ok(resultSum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firtsNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firtsNumber, string secondNumber)
        {
            if (IsNumeric(firtsNumber) && IsNumeric(secondNumber))
            {
                var resultSub = ConvertToDecimal(firtsNumber) - ConvertToDecimal(secondNumber);
                return Ok(resultSub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firtsNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firtsNumber, string secondNumber)
        {
            if (IsNumeric(firtsNumber) && IsNumeric(secondNumber))
            {
                var resultMult = ConvertToDecimal(firtsNumber) * ConvertToDecimal(secondNumber);
                return Ok(resultMult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firtsNumber}/{secondNumber}")]
        public IActionResult Division(string firtsNumber, string secondNumber)
        {
            if (IsNumeric(firtsNumber) && IsNumeric(secondNumber))
            {
                var resultDiv = ConvertToDecimal(firtsNumber) / ConvertToDecimal(secondNumber);
                return Ok(resultDiv.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("average/{firtsNumber}/{secondNumber}/{thirdNumber}")]
        public IActionResult Average(string firtsNumber, string secondNumber, string thirdNumber)
        {
            if (IsNumeric(firtsNumber) && IsNumeric(secondNumber) && IsNumeric(thirdNumber))
            {

                var sumAverage = (ConvertToDecimal(firtsNumber) + ConvertToDecimal(secondNumber) + ConvertToDecimal(thirdNumber));
                var resultAverage = sumAverage / 3;
                return Ok(resultAverage.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("square/{firtsNumber}")]
        public IActionResult Square(double firtsNumber)
        {

            double resultSquare = Convert.ToSingle(Math.Sqrt(firtsNumber));

            return Ok(resultSquare.ToString());
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

    }
}
