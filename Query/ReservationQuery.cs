using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query;

public sealed class ReservationQuery : ObjectGraphType
{
    public ReservationQuery(IReservationRepository reservationRepository)
    {
        Field<ListGraphType<ReservationType>>("Reservations")
            .Resolve(context =>
            {
                return reservationRepository.GetReservations();
            });
    }
}