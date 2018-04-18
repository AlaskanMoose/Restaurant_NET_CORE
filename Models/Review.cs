using System;
using System.ComponentModel.DataAnnotations;
namespace restaurant.Models
{
    public class Review : BaseEntity
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string ReviewerName { get; set; }

        [Required]
        public string RestaurantName { get; set; }

        [Required]
        [MinLength(10)]
        public string ReviewContent { get; set; }
        public DateTime DateOfVisit { get; set; }
        public int Stars {get; set; }
        public bool OnTime {
            get{
                
                if(DateTime.Now < DateOfVisit){
                    return false;
                }else {
                    return true;
                }
            }
        }
    }
}
