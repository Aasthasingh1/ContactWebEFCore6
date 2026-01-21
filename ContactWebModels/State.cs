using System.ComponentModel.DataAnnotations;
//use "alt + enter" to remove unnecessary usings

namespace ContactWebModels
{
    internal class State
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "State")]      //to display State writen in UI when we didn't fill anything
        [Required(ErrorMessage ="Name of State is required")]
        [StringLength(ContactManagerConstants.MAX_STATE_NAME_LENGTH)]     //to limit character
        public string Name { get; set; }
        [Required(ErrorMessage = "State Abbreviation is required")]    //require annotation/comment for Abbreviation
        [StringLength(ContactManagerConstants.MAX_STATE_ABBR_LENGTH)]
        public string Abbreviation { get; set; }
    }
}
