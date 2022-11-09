namespace webapp_travel_agency.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<PacchettoViaggio>? PacchettoViaggio { get; set; }

    public Categoria()
    {

    }
}

