using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using SupportTicketSystem.Models;

namespace SupportTicketSystem.Services;

public class FileStorage
{
    private readonly string _filePath = "tickets.json";

    public List<Ticket> LoadTickets()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Ticket>();
        }

        string json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Ticket>();
        }

        return JsonSerializer.Deserialize<List<Ticket>>(json) ?? new List<Ticket>();
    }

    public void SaveTickets(List<Ticket> tickets)
    {
        string json = JsonSerializer.Serialize(tickets, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }
}