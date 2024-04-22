using System.ComponentModel.DataAnnotations;

namespace EMart.Models.ViewModels
{
    public class UserViewModel
    {

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Contact { get; set; }

        public string UserEmail { get; set; }

        public int ProductId {  get; set; }
        public int count {  get; set; }
        public int SizeId { get; set; }
        public string SelectedSize {  get; set; }




    }
}
