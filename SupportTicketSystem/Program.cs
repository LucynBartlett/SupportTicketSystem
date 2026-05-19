using SupportTicketSystem.Services;

TicketManager ticketManager = new TicketManager();

bool running = true;

while (running)
{
    Console.WriteLine("\nSupport Ticket System");
    Console.WriteLine("1. Log new support ticket");
    Console.WriteLine("2. View open tickets");
    Console.WriteLine("3. Close ticket by ID");
    Console.WriteLine("4. Flag ticket as urgent");
    Console.WriteLine("5. View all tickets summary");
    Console.WriteLine("6. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter ticket title: ");
            string title = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be blank.");
                break;
            }

            Console.Write("Enter ticket description: ");
            string description = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description cannot be blank.");
                break;
            }

            Console.Write("Enter priority Low, Medium, or High: ");
            string priority = Console.ReadLine() ?? "";

            if (priority != "Low" && priority != "Medium" && priority != "High")
            {
                Console.WriteLine("Priority must be Low, Medium, or High.");
                break;
            }

            var ticket = ticketManager.AddTicket(title, description, priority);
            Console.WriteLine($"Ticket created with ID: {ticket.Id}");
            break;

        case "2":
            var openTickets = ticketManager.GetOpenTickets();

            Console.WriteLine("\nOpen Tickets:");
            foreach (var t in openTickets)
            {
                Console.WriteLine($"ID: {t.Id} | {t.Title} | Priority: {t.Priority}");
            }
            break;

        case "3":
            Console.Write("Enter ticket ID to close: ");
            if (int.TryParse(Console.ReadLine(), out int closeId))
            {
                Console.WriteLine(ticketManager.CloseTicket(closeId)
                    ? "Ticket closed."
                    : "Ticket not found.");
            }
            else
            {
                Console.WriteLine("Invalid ticket ID.");
            }
            break;

        case "4":
            Console.Write("Enter ticket ID to flag as urgent: ");
            if (int.TryParse(Console.ReadLine(), out int urgentId))
            {
                Console.WriteLine(ticketManager.FlagUrgent(urgentId)
                    ? "Ticket flagged as urgent and priority set to High."
                    : "Ticket not found.");
            }
            else
            {
                Console.WriteLine("Invalid ticket ID.");
            }
            break;

        case "5":
            var allTickets = ticketManager.GetAllTickets();

            Console.WriteLine("\nAll Tickets:");
            foreach (var t in allTickets)
            {
                Console.WriteLine($"ID: {t.Id} | {t.Title} | Priority: {t.Priority} | Status: {t.Status} | Urgent: {t.IsUrgent}");
            }
            break;

        case "6":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}