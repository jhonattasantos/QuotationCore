using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotationCore.Domain;
using QuotationCore.Repository;

namespace QuotationCore.API.Controllers
{
    [ApiController]
    [Route("api/quotations")]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationCoreRepository _quotationCoreRepository;
        public QuotationController(IQuotationCoreRepository quotationCoreRepository)
        {
            _quotationCoreRepository = quotationCoreRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Quotation>> Get()
        {
            var quotations = await _quotationCoreRepository.GetAllQuotationsAsync();
            return quotations;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Quotation quotation)
        {
            _quotationCoreRepository.Add(quotation);
            if(await _quotationCoreRepository.SaveChangesAsync()){
                return Created($"/api/quotations/{quotation.Id}", quotation);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var quotation = await _quotationCoreRepository.GetQuotationAsyncById(id);
            if(quotation == null) return BadRequest();

            return Ok(quotation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Quotation quotation)
        {
            var quotationFound = await _quotationCoreRepository.GetQuotationAsyncById(id);
            if(quotationFound == null) return NotFound();
            
            quotation.Id = quotationFound.Id;

            _quotationCoreRepository.Update(quotation);
            if(await _quotationCoreRepository.SaveChangesAsync()){
                return Created($"/api/quotations/{quotation.Id}", quotation);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var quotationFound = await _quotationCoreRepository.GetQuotationAsyncById(id);
            if(quotationFound == null) return NotFound();
    
            _quotationCoreRepository.Delete(quotationFound);
            if(await _quotationCoreRepository.SaveChangesAsync()){
                return Ok("Quotation removed");
            }

            return BadRequest();
        }
        
       
    }
}