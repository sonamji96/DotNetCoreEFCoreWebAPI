using EFWEBAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFWEBAPI.Controllers
{
    [Route("api/Currency")]
    [ApiController]
    public class CurrencyTypeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyTypeController(AppDbContext appDbContext) {

            this._appDbContext = appDbContext;
        }
        //[HttpGet("")]
        //public IActionResult getWholeCurrency()       // Synchronous Approach
        //{
        //    // var result = this._appDbContext.CurrencyTypes.ToList();    // method 1 

        //    var result = (from currency in _appDbContext.CurrencyTypes select currency).ToList();   // method 2
        //    return Ok(result);
        //}

        [HttpGet("")]
        public async Task<IActionResult> getWholeCurrency()        // Async Approach
        {
            //var result = await _appDbContext.CurrencyTypes.ToListAsync();

            var result = await (from currency in _appDbContext.CurrencyTypes select currency).ToListAsync();
            return Ok(result);
        }

        [HttpGet("test")]                                        //  api/currency/test
        public async Task<IActionResult> GetCurrencyById()        // Async Approach for getting detail from primary key 
        {
            var result = await _appDbContext.CurrencyTypes.FindAsync(2);

            // var result = await (from currency in _appDbContext.CurrencyTypes select currency).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]                                 //  [HttpGet("{id}")]     to take arguement as id  
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)        // Async Approach for getting detail from primary key 
        {
            var result = await _appDbContext.CurrencyTypes.FindAsync(id);
            // var result = await (from currency in _appDbContext.CurrencyTypes select currency).ToListAsync();
            return Ok(result);
        }

        //[HttpGet("{name}")]                                 //  [HttpGet("{name}")]     to take arguement as id  
        //public async Task<IActionResult> GetCurrencyByName([FromRoute] string name)        // Async Approach for getting detail from primary key 
        //{
        //    // var result = await _appDbContext.CurrencyTypes.Where(x => x.Currency == name).FirstOrDefaultAsync();   //  To get first record having same name 
        //     // var result = await _appDbContext.CurrencyTypes.Where(x => x.Currency == name).ToListAsync();   //  To get all record having same name 


        //    // var result = await _appDbContext.CurrencyTypes.Where(x => x.Currency == name).SingleAsync();

        //    var result = await _appDbContext.CurrencyTypes.SingleAsync(x => x.Currency == name);  // to process fast
        //    return Ok(result);
        //}

        //[HttpGet("{name}/{desc}")]                                 //  [HttpGet("{name}")]     to take arguement as name  taking arguement from url   
        //public async Task<IActionResult> GetCurrencyByProperties([FromRoute] string name , [FromRoute] string desc)        // Async Approach for getting detail from primary key 
        //{

        //    var result = await _appDbContext.CurrencyTypes.FirstOrDefaultAsync(x => x.Currency == name && x.Description==desc);  // to process fast
        //    return Ok(result);
        //}

        [HttpGet("{name}")]                                 //    
        public async Task<IActionResult> GetCurrencyByProperties([FromRoute] string name, [FromQuery] string? desc)   // name is must and desc can be null or an value      // Async Approach for getting detail from primary key 
        {

            var result = await _appDbContext.CurrencyTypes.FirstOrDefaultAsync(x => x.Currency == name
            && (string.IsNullOrEmpty(desc) || x.Description == desc));
            return Ok(result);
        }

        [HttpPost("All")]
        public async Task<IActionResult> GetCurrecncyDetail([FromBody] List<int> ids)
        {
            var result = await _appDbContext.CurrencyTypes.Where(x => ids.Contains(x.id)).ToListAsync();
            return Ok(result);
        
        }

        [HttpPost("selectedData")]
        public async Task<IActionResult> GetSelectedCurrecncyDetail([FromBody] List<int> ids)
        {
            //var result = await _appDbContext.CurrencyTypes
            //    .Where(x => ids.Contains(x.id))
            //    .Select(x => new CurrencyType()
            //    { id = x.id , Currency = x.Currency })
            //    .ToListAsync();


            var result = await (from currency in _appDbContext.CurrencyTypes
                                select new CurrencyType()
                                {
                                    id = currency.id,
                                    Currency = currency.Currency

                                }
            ).ToListAsync();



            return Ok(result);

        }





    }
}
