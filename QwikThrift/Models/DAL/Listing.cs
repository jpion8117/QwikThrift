#nullable disable
namespace QwikThrift.Models.DAL
{
    public class Listing
    {
        /// <summary>
        /// Unique Id representing this listing
        /// </summary>
        public int ListingId { get; set; }

        /// <summary>
        /// Text displayed below the listing
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Text displayed in the listing post
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// UserId of the listing owner
        /// </summary>
        public int OwnerId { get; set; }
        virtual public User Owner { get; set; }

        /// <summary>
        /// All images associated with this listing
        /// </summary>
        virtual public List<ImageReference> Images { get; set; }

        /// <summary>
        /// Marked true to signify a listing has sold and should no longer be
        /// listed on the site.
        /// </summary>
        public bool SaleStatus { get; set; }

        /// <summary>
        /// Sale price of this listing
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// CategoryId of the category this listing belongs to.
        /// </summary>
        public int CategoryId {  get; set; }
        virtual public Category Category { get; set; }

        /// <summary>
        /// Timestamp when listing was created
        /// </summary>
        public DateTime ListingTime { get; set; }
                
        /// <summary>
        /// Remove all image files associated with this listing. This method should 
        /// be called when removing a listing
        /// </summary>
        public void DeleteAssociatedImages()
        {
            foreach (ImageReference image in Images)
                image.DeleteImageFromFile();

            var path = Path.Combine(ImageReference.HostPath, "listingsInDev", ListingId.ToString());

            if (Directory.Exists(path))
                Directory.Delete(path);
        }
    }
}
