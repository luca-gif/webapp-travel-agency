namespace webapp_travel_agency.Models
{
    public class Wrapper
    {
        public PacchettoViaggio? PacchettoViaggio { set; get; }
        public List<Categoria>? Categoria { set; get; }

        public Wrapper()
        {
            PacchettoViaggio = new PacchettoViaggio();
            Categoria = new List<Categoria>();
        }
    }
}
