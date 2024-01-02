using Leave.Api.Data;
using Leave.API.Dto;
using Leave.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Leave.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class LeaveController : ControllerBase
{
    private readonly LeaveDbContext _dbContext;

    public LeaveController(LeaveDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(PaginationRequest paginationRequest)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var totalItems = await _dbContext.Leaves
            .LongCountAsync();

        var itemsOnPage = await _dbContext.Leaves
            .OrderBy(c => c.Id)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();
        return Ok(new PaginatedItems<Model.Leave>(pageIndex, pageSize, totalItems, itemsOnPage));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _dbContext.Leaves
            .Include(ci => ci.Attachment)
            .Include(ci => ci.Status)
            .SingleOrDefaultAsync(ci => ci.Id == id);

        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateLeaveRequest request)
    {
        var leaveItems = request.Leaves.Select(l => new LeaveItem
        {
            Quantity = l.Quantity,
            LeaveDate = l.LeaveDate
        }).ToList();
        var item = new Model.Leave
        {
            LeaveType = new LeaveType
            {
                Name = request.LeaveType.Name,
                Total = request.LeaveType.Total
            },
            Attachment = new Attachment
            {
                Comment = request.Attachment.Comment,
                Path = request.Attachment.Path
            },
            Status = new LeaveStatus
            {
                Status = Status.Pending
            },
            Reason = request.Reason,
            MemberId = request.MemberId,
            LeaveItems = leaveItems
        };

        _dbContext.Leaves.Add(item);
        await _dbContext.SaveChangesAsync();

        return Created($"/api/v1/Leave/{item.Id}", item);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Leave.API.Model.Leave leaveToUpdate, Guid id)
    {
        var leave = await _dbContext.Leaves.FirstOrDefaultAsync(l => l.Id == id);
        if (leave is null)
        {
            return NotFound();
        }
        var leaveEntry = _dbContext.Leaves.Entry(leave);
        leaveEntry.CurrentValues.SetValues(leaveToUpdate);
        return Created($"/api/v1/leave/{leaveToUpdate.Id}", leave);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var item = _dbContext.Leaves.SingleOrDefault(x => x.Id == id);

        if (item is null)
        {
            return NotFound();
        }

        _dbContext.Leaves.Remove(item);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}
