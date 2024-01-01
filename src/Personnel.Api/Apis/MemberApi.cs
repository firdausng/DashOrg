using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personnel.Api.Data;
using Personnel.Api.Dto;
using Personnel.Api.Model;

namespace Personnel.Api.Apis;

public static class MemberApi
{
    public static IEndpointRouteBuilder MapMemberApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetAllItems);
        app.MapGet("/items/by", GetItemsByIds);
        app.MapGet("/personal/{id:guid}", GetPersonalItemById);
        app.MapGet("/contact/{id:guid}", GetContactItemById);
        app.MapGet("/emergency/{id:guid}", GetEmergencyContactItemById);
        
        app.MapPost("/", CreateMember);
        app.MapDelete("/{id:guid}", DeleteItemById);
        return app;
    }
    
    public static async Task<Results<Ok<PaginatedItems<Member>>, BadRequest<string>>> GetAllItems(
        [AsParameters] PaginationRequest paginationRequest,
        [FromServices] PersonnelDbContext personnelDbContext)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var totalItems = await personnelDbContext.Members
            .LongCountAsync();

        var itemsOnPage = await personnelDbContext.Members
            .OrderBy(c => c.Id)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        // itemsOnPage = ChangeUriPlaceholder(services.Options.Value, itemsOnPage);

        return TypedResults.Ok(new PaginatedItems<Member>(pageIndex, pageSize, totalItems, itemsOnPage));
    }
    
    public static async Task<Ok<List<Member>>> GetItemsByIds(
        [FromServices] PersonnelDbContext personnelDbContext,
        Guid[] ids)
    {
        var items = await personnelDbContext.Members.Where(item => ids.Contains(item.Id)).ToListAsync();
        // items = ChangeUriPlaceholder(services.Options.Value, items);
        return TypedResults.Ok(items);
    }
    
    public static async Task<Results<Ok<Member>, NotFound, BadRequest<string>>> GetPersonalItemById(
        [FromServices] PersonnelDbContext personnelDbContext,
        Guid id)
    {
        var item = await personnelDbContext.Members
            .Include(ci => ci.PersonalInformation)
            .SingleOrDefaultAsync(ci => ci.Id == id);

        if (item == null)
        {
            return TypedResults.NotFound();
        }

        // item.PictureUri = services.Options.Value.PicBaseUrl.Replace("[0]", item.Id.ToString());
        return TypedResults.Ok(item);
    }
    
    public static async Task<Results<Ok<Member>, NotFound, BadRequest<string>>> GetContactItemById(
        [FromServices] PersonnelDbContext personnelDbContext,
        Guid id)
    {
        var item = await personnelDbContext.Members
            .Include(ci => ci.ContactInformation)
            .SingleOrDefaultAsync(ci => ci.Id == id);

        if (item == null)
        {
            return TypedResults.NotFound();
        }

        // item.PictureUri = services.Options.Value.PicBaseUrl.Replace("[0]", item.Id.ToString());
        return TypedResults.Ok(item);
    }
    
    public static async Task<Results<Ok<Member>, NotFound, BadRequest<string>>> GetEmergencyContactItemById(
        [FromServices] PersonnelDbContext personnelDbContext,
        Guid id)
    {
        var item = await personnelDbContext.Members
            .Include(ci => ci.EmergencyContact)
            .SingleOrDefaultAsync(ci => ci.Id == id);

        if (item == null)
        {
            return TypedResults.NotFound();
        }

        // item.PictureUri = services.Options.Value.PicBaseUrl.Replace("[0]", item.Id.ToString());
        return TypedResults.Ok(item);
    }
    
    public static async Task<Created> CreateMember(
        [FromServices] PersonnelDbContext personnelDbContext,
        AddMemberRequest addMemberRequest)
    {
        var item = new Member
        {
            ContactInformation = new ContactInformation
            {
                Address = addMemberRequest.Address,
                PhoneNumber = addMemberRequest.PhoneNumber,
                Email = addMemberRequest.Email,
                WorkEmail = addMemberRequest.WorkEmail,
                WorkAddress = addMemberRequest.WorkAddress
            },
            LegalName = new LegalName
            {
                FullName = addMemberRequest.FullName,
                GivenName = addMemberRequest.GivenName,
                FamilyName = addMemberRequest.FamilyName
            },
            PersonalInformation = new PersonalInformation
            {
                Gender = addMemberRequest.Gender,
                Dob = addMemberRequest.Dob,
                MaritalStatus = addMemberRequest.MaritalStatus,
                MaritalStatusDate = addMemberRequest.MaritalStatusDate,
                Ethnic = addMemberRequest.Ethnic,
                Religion = addMemberRequest.Religion,
                CitizenshipStatus = addMemberRequest.CitizenshipStatus,
                Nationality = addMemberRequest.Nationality
            }
        };
        // item.Embedding = await services.CatalogAI.GetEmbeddingAsync(item);

        personnelDbContext.Members.Add(item);
        await personnelDbContext.SaveChangesAsync();

        return TypedResults.Created($"/api/v1/member/{item.Id}");
    }
    
    public static async Task<Results<NoContent, NotFound>> DeleteItemById(
        [FromServices] PersonnelDbContext personnelDbContext,
        Guid id)
    {
        var item = personnelDbContext.Members.SingleOrDefault(x => x.Id == id);

        if (item is null)
        {
            return TypedResults.NotFound();
        }

        personnelDbContext.Members.Remove(item);
        await personnelDbContext.SaveChangesAsync();
        return TypedResults.NoContent();
    }

}