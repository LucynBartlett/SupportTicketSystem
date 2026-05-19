using SupportTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportTicketSystem.Services;

public class TicketManager
{
    private readonly List<Ticket> _tickets;
    private readonly FileStorage _fileStorage = new();

    public TicketManager()
    {
        _tickets = _fileStorage.LoadTickets();
    }

    public List<Ticket> GetAllTickets()
    {
        return _tickets;
    }

    public List<Ticket> GetOpenTickets()
    {
        return _tickets.Where(t => t.Status == "Open").ToList();
    }

    public Ticket AddTicket(string title, string description, string priority)
    {
        int newId = _tickets.Count == 0 ? 1 : _tickets.Max(t => t.Id) + 1;

        Ticket ticket = new Ticket
        {
            Id = newId,
            Title = title,
            Description = description,
            Priority = priority,
            Status = "Open"
        };

        _tickets.Add(ticket);
        _fileStorage.SaveTickets(_tickets);

        return ticket;
    }

    public bool CloseTicket(int id)
    {
        Ticket? ticket = _tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
        {
            return false;
        }

        ticket.Status = "Closed";
        _fileStorage.SaveTickets(_tickets);

        return true;
    }

    public bool FlagUrgent(int id)
    {
        Ticket? ticket = _tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
        {
            return false;
        }

        ticket.IsUrgent = true;
        ticket.Priority = "High";
        _fileStorage.SaveTickets(_tickets);

        return true;
    }
}