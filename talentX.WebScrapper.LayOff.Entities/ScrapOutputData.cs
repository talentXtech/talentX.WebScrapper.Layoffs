using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace talentX.WebScrapper.LayOff.Entities
{
    public class ScrapOutputData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? CompanyName { get; set; }
        public string? elementName { get; set; }
        public string? numberText { get; set; }

        public string? LocationHQ { get; set; }
        public string? LaidOff { get; set; }
        public string? Date { get; set; }
        public string? Percentage { get; set; }

        public string? Industry { get; set; }
        public string? SourceUrl { get; set; }
        public string? listOfLaidOffEmployeesUrl { get; set; }
        public string? Stage { get; set; }
        public string? Raised { get; set; }
        public string? Country { get; set; }

        public string? DateAdded { get; set; }

    }
}
