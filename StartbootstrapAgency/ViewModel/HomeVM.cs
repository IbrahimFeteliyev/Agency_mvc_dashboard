using StartbootstrapAgency.Models;

namespace StartbootstrapAgency.ViewModel
{
    public class HomeVM
    {
        public Masthead masthead { get; set; }
        public List<Service> Service { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
