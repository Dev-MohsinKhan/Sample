using InterviewTask.Models;
using System.ComponentModel.DataAnnotations;

namespace InterviewTask.ViewModels
{
    public class Records
    {

        public List<Region> Regions { get; set; }
        public List<Wiliyat> Wiliyats { get; set; }
        public List<Area> Areas { get; set; }
        public List<Village> Villages { get; set; }
        public List<EntityType> EntityType { get; set; }
        public List<Item> Items{ get; set; }

        //[Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter only numbers.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a region.")]
        public int SelectedRegionId { get; set; }

        [Required(ErrorMessage = "Please select a wilaya.")]
        public int SelectedWiliyatId { get; set; }

        [Required(ErrorMessage = "Please select an area.")]
        public int SelectedAreaId { get; set; }

        [Required(ErrorMessage = "Please select a village.")]
        public int SelectedVillageId { get; set; }

        [Required(ErrorMessage = "Please select an entity type.")]
        public int SelectedEntityTypeID { get; set; }

        [Required(ErrorMessage = "Please provide details of your Open Data Experience.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.]*$", ErrorMessage = "Special characters are not allowed except for full stops.")]

        public string DetailsODE { get; set; }

        [Required(ErrorMessage = "Please provide your remarks and suggestions.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.]*$", ErrorMessage = "Special characters are not allowed except for full stops.")]

        public string Remarks { get; set; }

        
    }
}
