using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class ReservationRepository : IReservationRepository
{
    private readonly GraphQlDbContext _context;

    public ReservationRepository(GraphQlDbContext context)
    {
        _context = context;
    }
    public List<Reservation> GetReservations()
    {
        return _context.Reservations.ToList();
    }

    public Reservation AddReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return reservation;
    }
}