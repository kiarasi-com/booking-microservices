namespace Flight.Seats.Features.CreatingSeat.V1;

using System;
using BuildingBlocks.Core.Event;

public record SeatCreatedDomainEvent(Guid Id, string SeatNumber, Enums.SeatType Type, Enums.SeatClass Class, Guid FlightId, bool IsDeleted) : IDomainEvent;