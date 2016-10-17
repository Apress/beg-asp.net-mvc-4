using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveYouSeenMe.Models
{
    public enum TypeOfMessage
    {
        Feedback,
        Contact,
        Other
    }
    public class MessageModel
    {
        [Required(ErrorMessage="Please type your name")]
        [StringLength(150, ErrorMessage="You can only add up to 150 characters")]
        [FullName(ErrorMessage="Please type your full name")]
        public string From { get; set; }
        
        [Required(ErrorMessage="Please type your email address")]
        [StringLength(150, ErrorMessage = "You can only add up to 150 characters")]
        [EmailAddress(ErrorMessage="We don't recognize this as a valid email address")]
        public string Email { get; set; }

        [Phone]
        [DisplayFormat(ConvertEmptyStringToNull=true,DataFormatString="(###) ###-####",ApplyFormatInEditMode=true)]
        public string PhoneNumber { get; set; }

        [FileExtensions(Extensions=".jpg,.png,.gif")]
        public string TypeOfEmail { get; set; }

        [StringLength(150, ErrorMessage = "You can only add up to 150 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage="Please type your message")]
        [StringLength(1500, ErrorMessage = "You can only add up to 1500 characters")]
        [AllowHtml]
        public string Message { get; set; }
    }
}
