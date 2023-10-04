#nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QwikThrift.Models.DAL
{
    public class ImageReference
    {
        private bool _readyToUpload = false;
        private IFormFile _formFile;

        /// <summary>
        /// Contains the path to the wwwroot folder of the project. *** Must be set during program startup sequence ***
        /// </summary>
        [NotMapped]
        public static string HostPath { get; set; } 

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

        [NotMapped]
        public string FullPath 
        {
            get =>  Path + '\\' + Filename;
            
        }

        /// <summary>
        /// Stores the image file uploaded to the server
        /// </summary>
        [NotMapped]
        public IFormFile ImageFile 
        {
            get => _formFile; 
            set
            {
                _formFile = value;
                _readyToUpload = true;
            }
        }

        /// <summary>
        /// Listing associated with this image.
        /// </summary>
        public int ListingId { get; set; }
        virtual public Listing Listing { get; set; }

        /// <summary>
        /// Upload the image to the the server
        /// </summary>
        /// <returns>true if upload was successfull</returns>
        public bool SaveImageToFile()
        {
            if (!_readyToUpload) return false;

            var path = HostPath + '\\' + Path;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (var filestream = new FileStream(System.IO.Path.Combine(path, Filename), FileMode.Create))
            {
                ImageFile.CopyTo(filestream);
            }

            return File.Exists(System.IO.Path.Combine(path, Filename));
        }
    }
}
