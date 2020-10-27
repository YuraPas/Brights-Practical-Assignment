using System.ComponentModel.DataAnnotations;

namespace PageInfoParser.ViewModel
{
    public class PageInfoParserViewModel
    {
        [Required]
        [MaxLength(5000)]
        public string UrlContainer { get; set; }
    }
}
