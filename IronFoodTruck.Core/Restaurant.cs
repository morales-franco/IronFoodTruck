using System.ComponentModel.DataAnnotations;

namespace IronFoodTruck.Core
{
    public class Restaurant//: IValidatableObject for Complex validation
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
