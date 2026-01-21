using ContactWebModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactWebModels
{
    internal class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(ContactManagerConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(ContactManagerConstants.MAX_LAST_NAME_LENGTH)]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(ContactManagerConstants.MAX_EMAIL_LENGTH)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Phone No is required")]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhonePrimary { get; set; }

        [Display(Name = "Home/Office Phone")]
        [Required(ErrorMessage = "Phone No is required")]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneSecondary { get; set; }

        [DataType(DataType.Date)]       //will show date formate type
        public DateTime Birthday { get; set; }

        [Display(Name = "Street Address Line 1")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }

        [Display(Name = "Street Address Line 2")]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [StringLength(ContactManagerConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }       //this is going to be the ID of state in database

        public virtual State State { get; set; }    //virtual means I can override that in another method or extend it.

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        [StringLength(ContactManagerConstants.MAX_ZIP_CODE_LENGTH, MinimumLength = ContactManagerConstants.MIN_ZIP_CODE_LENGTH)]
        [RegularExpression("@\"^(?:\\d{5}(?:-\\d{4})?|[1-9]\\d{5}|[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d)$\"", ErrorMessage = "Zip code is Invalid.")] //US or Canada or India
        public string Zip { get; set; }

        [Required(ErrorMessage = "The User ID is required in order to map the contact to a user correctly")]
        public string UserId { get; set; }

        [Display(Name = "Full Name")]
        public string FriendlyName => $"{FirstName} {LastName}";

        [Display(Name = "Full Address")]
        public string FriendlyAddress => State is null ? "" : string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State.Abbreviation}, {Zip}" :
                                                 string.IsNullOrWhiteSpace(StreetAddress2) 
                                                      ? $"{StreetAddress1}, {City}, {State.Abbreviation}, {Zip}"
                                                      : $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abbreviation}, {Zip}";
    }
}
