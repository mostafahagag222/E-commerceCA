using APIs.EnpointsHelper;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APIs.EndPoints;

public class Account : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this);
        group.MapGet("emailexists", DoesEmailExist);
    }
    private static async Task<IResult> DoesEmailExist(ISender sender, [FromQuery] string email)
    {
        bool result = await sender.Send(new DoesEmailExitsAsync() { Email = email });
        var rr = TypedResults.Ok(new
        {
            r = result,
        });
        return rr;
    }
}