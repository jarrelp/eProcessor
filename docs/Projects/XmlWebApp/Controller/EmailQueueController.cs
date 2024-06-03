using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/[controller]")]
public class EmailQueueController : ControllerBase
{
    private readonly XmlReaderService _xmlReaderService;
    private readonly IMapper _mapper;

    public EmailQueueController(XmlReaderService xmlReaderService, IMapper mapper)
    {
        _xmlReaderService = xmlReaderService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EmailQueueDto>> GetEmailQueues()
    {
        var emailQueues = _xmlReaderService.ReadEmailQueues("XmlFiles/emailqueues.xml");
        var emailQueueDtos = _mapper.Map<IEnumerable<EmailQueueDto>>(emailQueues);
        return Ok(emailQueueDtos);
    }
}