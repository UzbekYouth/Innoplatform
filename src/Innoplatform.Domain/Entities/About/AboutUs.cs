using Innoplatform.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace Innoplatform.Domain.Entities.About
{
    public class AboutUs : Auditable
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<AboutUsAsset> AboutUsAssets { get; set; }
    }
}
