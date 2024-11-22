namespace App.Models;

public class ClientSearchViewModel
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AgeBandCode { get; set; }

    public string? GenderCode { get; set; }

    public List<ClientEntity> Results { get; set; } = new();

    public bool SearchPerformed { get; set; }
}

