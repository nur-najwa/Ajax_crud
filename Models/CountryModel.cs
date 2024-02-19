using System.ComponentModel.DataAnnotations;

namespace Ajax_crud.Models
{
    public class CountryAddModel
    {
        [Required]
        [Display(Name = "Id Number")]
        public int Id { get; set; }

        [Required]  
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }    
        public string Price {  get; set; }  
    }

    public class CountryEditModel
    {
        [Display(Name = "Id Number")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }
        public string Price { get; set; }
    } 

    public class CountryListingSearchModel
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Price { get; set; }
        public IList<CountryListingModel> CountryList { get; set; }
    }
    public class CountryListingModel
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Price { get; set; }
    }
    public class CountryGetModel
    {
        public int Id { get; set; }
    }
}
