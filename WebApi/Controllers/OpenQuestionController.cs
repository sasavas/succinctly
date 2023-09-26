using Application.UseCases;
using Domain.Features.QuestionFeature;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenQuestionController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly ILogger<OpenQuestionController> _logger;

    public OpenQuestionController(
        ISender mediator, ILogger<OpenQuestionController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("info")]
    public async Task<ActionResult<OpenQuestionInfoDto>> GetOpenQuestionInfo()
    {
        var result = _mediator.Send(new GetOpenQuestionInfoRequest());
        return await result;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<OpenQuestion>> GetById(long id)
    {
        return await _mediator.Send(new GetOpenQuestionRequest(id));
    }
}