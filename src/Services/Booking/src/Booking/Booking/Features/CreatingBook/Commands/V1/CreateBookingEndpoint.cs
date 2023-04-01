namespace Booking.Booking.Features.CreatingBook.Commands.V1;

using BuildingBlocks.Web;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

public record CreateBookingRequestDto(Guid PassengerId, Guid FlightId, string Description);
public record CreateBookingResponseDto(ulong Id);

public class CreateBookingEndpoint : IMinimalEndpoint
{
    public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost($"{EndpointConfig.BaseApiPath}/booking", CreateBooking)
            .RequireAuthorization()
            .WithName("CreateBooking")
            .WithMetadata(new SwaggerOperationAttribute("Create Booking", "Create Booking"))
            .WithApiVersionSet(builder.NewApiVersionSet("Booking").Build())
            .Produces<CreateBookingResponseDto>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .HasApiVersion(1.0);

        return builder;
    }

    private async Task<IResult> CreateBooking(CreateBookingRequestDto request, IMediator mediator, IMapper mapper,
        CancellationToken cancellationToken)
    {
        var command = mapper.Map<CreateBooking>(request);

        var result = await mediator.Send(command, cancellationToken);

        var response = new CreateBookingResponseDto(result.Id);

        return Results.Ok(response);
    }
}