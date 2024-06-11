using Microsoft.AspNetCore.Mvc;

namespace EDDY202401.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitsController : ControllerBase
    {
        private static int[] data => Enumerable.Range(1, 100).ToArray();

        [HttpGet()]
        public IActionResult Get([FromQuery] bool? filter = false)
        {
            if (filter is null or false) return Ok(new { count = data.Length, data });

            int index = 1;
            List<int> numbers = data.ToList();
            List<int> pickedNumbers = new List<int>();
            Random random = new Random();

            while (index <= 3)
            {
                // Generate a random number between 1 and 100
                int number = random.Next(1, 101);
                // Check if the number has already been picked
                if (pickedNumbers.Any(x => x == number))
                {
                    continue;
                }

                // Add the number to the picked numbers list
                pickedNumbers.Add(number);

                index++;
            }
            numbers.RemoveAll(x => pickedNumbers.Contains(x));

            return Ok(new { count = numbers.Count, data = numbers, removedData = pickedNumbers });
        }
    }
}
