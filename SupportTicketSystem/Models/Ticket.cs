using System;
using System.Collections.Generic;
using System.Text;

namespace SupportTicketSystem.Models;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Priority { get; set; } = "";
    public string Status { get; set; } = "Open";
    public bool IsUrgent { get; set; } = false;
}