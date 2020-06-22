using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuotationCore.API.Dtos;
using QuotationCore.Domain;
using QuotationCore.Repository;

namespace QuotationCore.API.Controllers
{
    [ApiController]
    [Route("api/quotations")]
    public class QuotationController : ControllerBase
    {
        private readonly IQuotationCoreRepository _quotationCoreRepository;
        private readonly IMapper _mapper;
        public QuotationController(IQuotationCoreRepository quotationCoreRepository, IMapper mapper)
        {
            _quotationCoreRepository = quotationCoreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var quotations = await _quotationCoreRepository.GetAllQuotationsAsync();
            var results = _mapper.Map<QuotationDto[]>(quotations);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuotationDto quotationDto)
        {
            var quotation = _mapper.Map<Quotation>(quotationDto);
            _quotationCoreRepository.Add(quotation);
            if (await _quotationCoreRepository.SaveChangesAsync())
            {
                return Created($"/api/quotations/{quotation.Id}", quotation);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var quotation = await _quotationCoreRepository.GetQuotationAsyncById(id);
            if (quotation == null) return BadRequest();
            var result = _mapper.Map<QuotationDto>(quotation);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, QuotationDto quotationDto)
        {
            var quotation = await _quotationCoreRepository.GetQuotationAsyncById(id);
            if (quotation == null) return NotFound();

            _mapper.Map(quotationDto, quotation);
            //quotation.Id = quotationFound.Id;

            _quotationCoreRepository.Update(quotation);
            if (await _quotationCoreRepository.SaveChangesAsync())
            {
                return Created($"/api/quotations/{quotation.Id}", quotation);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var quotationFound = await _quotationCoreRepository.GetQuotationAsyncById(id);
            if (quotationFound == null) return NotFound();

            _quotationCoreRepository.Delete(quotationFound);
            if (await _quotationCoreRepository.SaveChangesAsync())
            {
                return Ok("Quotation removed");
            }

            return BadRequest();
        }


    }
}