using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestAzureASPNETCore.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var res = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(res.ToString());
            }
                
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var res = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(res.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var res = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(res.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var res = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(res.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult avg(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var res = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(res.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrt/{number}")]
        public IActionResult sqrt(string number)
        {
            if (IsNumeric(number))
            {
                var res = Math.Sqrt((double)ConvertToDecimal(number));
                return Ok(res.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal number;
            if (decimal.TryParse(strNumber, out number))
            {
                return number;
            }
            return 0;
            
        }

        private bool IsNumeric(string strNumber)
        {
            bool isNumber = false;
            double number;
            isNumber = double.TryParse(strNumber,  
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number
                );
            return isNumber;
        }
    }
}
