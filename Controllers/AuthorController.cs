using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Data;
using EfCoreDbContext.Repository.Interface;
using EfCoreDbContext.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EfCoreDbContext.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly EfCoreDbcontext _context;
    private readonly IAuthorRepository _authorRepository;
    private readonly IAuthorService _authorService;

    public AuthorController(EfCoreDbcontext context, IAuthorRepository repository, IAuthorService service,
        IAuthorRepository authorRepository, IAuthorService authorService)
    {
        _context = context;
        _authorRepository = authorRepository;
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors(int id )
    {
        try
        {
            var author = await _authorRepository.GetAuthors(id);
            return Ok(author);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById(int id, AuthorResponseDto output)
    {
        try
        {
            var author = await _authorRepository.GetAuthorById(id, output);
            return Ok(author);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor ([FromBody] AuthorRequestDto dto)
    {
        try
        {
            var author = await _authorService.CreateAuthor(dto);

            return CreatedAtAction("GetAuthorById", new { id = author.Id }, author);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //Update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, AuthorRequestDto dto)
    {
        try
        {
            var author = await _authorService.UpdateAuthor(id, dto);
            return Ok(author);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    //Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        try
        {
            await _authorService.DeleteAuthor(id);
            return Ok("Author deleted");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}