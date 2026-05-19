using SupportTicketSystem.Services;

namespace SupportTicketSystem.Tests;

public class TicketManagerTests
{
    [Fact]
    public void AddTicket_ShouldCreateNewTicket()
    {
        TicketManager manager = new TicketManager();

        var ticket = manager.AddTicket("Printer issue", "Printer not working", "Medium");

        Assert.Equal("Printer issue", ticket.Title);
        Assert.Equal("Printer not working", ticket.Description);
        Assert.Equal("Medium", ticket.Priority);
        Assert.Equal("Open", ticket.Status);
    }

    [Fact]
    public void CloseTicket_ShouldSetStatusToClosed()
    {
        TicketManager manager = new TicketManager();

        var ticket = manager.AddTicket("Network issue", "WiFi down", "High");

        bool result = manager.CloseTicket(ticket.Id);

        Assert.True(result);
        Assert.Equal("Closed", ticket.Status);
    }

    [Fact]
    public void FlagUrgent_ShouldSetUrgentAndHighPriority()
    {
        TicketManager manager = new TicketManager();

        var ticket = manager.AddTicket("Email issue", "Cannot send emails", "Low");

        bool result = manager.FlagUrgent(ticket.Id);

        Assert.True(result);
        Assert.True(ticket.IsUrgent);
        Assert.Equal("High", ticket.Priority);
    }
}
