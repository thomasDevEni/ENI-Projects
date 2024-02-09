using System.ComponentModel;

namespace FestivallWeb.ViewModels
{
    public class GroupeViewModel
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        [DisplayName("Date Creation")]
        public DateTime DateCreation { get; set; }
        public string DateCreationn { get; set; }
    }
}
