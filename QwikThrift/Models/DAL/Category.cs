﻿#nullable disable
namespace QwikThrift.Models.DAL
{
    public class Category
    {
        /// <summary>
        ///  Unique ID for category
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Name of category
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Description of category
        /// </summary>
        public string CategoryDescription { get; set; }

        /// <summary>
        /// id of user who created category
        /// </summary>
        public int AuthorizedById { get; set; }

        virtual public User AuthorizedBy { get; set; }

        /// <summary>
        /// listings associated with this category.
        /// </summary>
        virtual public List<Listing> Listings { get; set; }

    }
}
