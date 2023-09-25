#nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QwikThrift.Models.DAL
{
    public class ImageReference
    {
        /// <summary>
        /// Primary key/uniqueId
        /// </summary>
        public int ImageReferenceId { get; set; }

        /// <summary>
        /// Name of the image
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of image (if provided)
        /// </summary>
        [Display(Name = "Description (optional)")]
        public string Description { get; set; }

        /// <summary>
        /// Path to file stored on server
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Name of image file stored on server
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Listing associated with this image.
        /// </summary>
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
