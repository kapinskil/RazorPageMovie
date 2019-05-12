using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageMovie.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }
        public string EmailAdress{ get; set; }
        public string Name { get; set; }

        public void OnGet()
        {
            Message = "My contact page";
            EmailAdress = "email: kapinski.l @gmail.com";
            Name = "Łukasz Kapiński";
            Name = ShowName("Jan Kowalski");
        }

        public string ShowName(string name)
        {
            return name;
        }

        
    }
}
