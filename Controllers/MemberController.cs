using EfCoreDbContext.Contracts.RequestDto;
using EfCoreDbContext.Contracts.ResponseDto;
using EfCoreDbContext.Repository.Interface;
using EfCoreDbContext.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreDbContext.Controllers;

public class MemberController : ControllerBase
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMemberService _memberService;

    public MemberController(IMemberRepository memberRepository, IMemberService memberService)
    {
        _memberRepository = memberRepository;
        _memberService = memberService;
    }
    
    //GET ALL
    [HttpGet]
    public async Task<IActionResult> GetMembers(int id)
    {
        try
        {
            var member = await _memberRepository.GetMembers(id);
            return Ok(member);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    //GET BY ID 
    [HttpGet("/id")]
    public async Task<IActionResult> GetMemberById (int id, MemberResponseDto output)
    {
        try
        {
            var member = await _memberRepository.GetMemberById(id, output);
            return Ok(member);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    //POST
    [HttpPost]
    public async Task<IActionResult> AddMember([FromBody] MemberRequestDto dto)
    {
        try
        {
            var member = await _memberService.CreateMember(dto);
            
            return CreatedAtAction(nameof(GetMemberById), new { id = member.Id }, dto);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    //UPDATE MEMBER 
    [HttpPut("/id")]
    public async Task<IActionResult> UpdateMember(int id, MemberRequestDto dto)
    {
        try
        {
            var member = await _memberService.UpdateMember(id, dto);
            return Ok(member);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    //DELETE
    [HttpDelete("/id")]
    public async Task<IActionResult> DeleteMember(int id)
    {
        try
        {
            await _memberService.DeleteMember(id);
            return Ok();

        }
        catch (Exception e)
        { 
            return BadRequest(e.Message);
        }
    }
}
