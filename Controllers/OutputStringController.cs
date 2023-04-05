using Microsoft.AspNetCore.Mvc;
using TechnologyASP.Models;

namespace TechnologyASP.Controllers
{
    [Route("/api/[controller]")]
    public class OutputStringController : Controller
    {

        [HttpGet("{input}/{sort}")]
        public async Task <ActionResult<ModelsOutputString>> GetResult(string input,string sort)
        {
            Execute execute= new();

            try
            {
                if (input == null || input.Length == 0)
                {
                    throw new Exception("invalid input");
                }
                execute.StringСheck(input);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var isEven = input.Length % 2 == 0;
            var result = isEven ? execute.Even(input) : execute.Inaccurate(input);

            var resultSubstring = execute.SubstringSearch(result);

            var inputChoice = sort;
            string sortdString ="";
            if (inputChoice != null && inputChoice == "q")
            {
                sortdString = execute.QuickSort(result);
            }
            else if (inputChoice != null && inputChoice == "t")
            {
                sortdString = execute.TreeSort(result);
            }

            int number;
            try
            {
                number = execute.GetNumberApi(result);
            }
            catch
            {
                Random random = new();
                number = random.Next(1, 10);
            }
            string removedString=execute.DeleteSymbol(result, number);
            

            return new ModelsOutputString() 
            { Input=input,Result=result,
              SymbolCount=execute.SymbolCount(input),
              FinalSubstring=resultSubstring,
              SortedString=sortdString,
              RemovedString= removedString};
        }

        
    }
}
