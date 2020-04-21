using System;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{


        public class User : Model
        {

            [Display(Order = -10, Prompt = "Enter Username", Description = "Username")]
            public string Username { get; set; }
            [Display(Order = -1000, Prompt = "Email Address", Description = "Email Address")]

            public MailAddress Email { get; set; }
            [Display(Order = -9, Prompt = "First Name", Description = "User First Name")]
            public string Fname { get; set; }
            [Display(Order = -8, Prompt = "First Name", Description = "User First Name")]

            public string Lname { get; set; }
            [Display(Order = -7, Prompt = "Active User", Description = "Active User")]
            public bool Active { get; set; }

            public User(string username, string email, string fname, string lname)
            {

                Username = username;
                Email = new MailAddress(email, fname + " " + lname);
                Fname = fname;
                Lname = lname;
            }

            public static User Create(string username, string email, string fname, string lname)
            {

                var _user = new User(username, email, fname, lname);

                _user.NewRecord = true;
                _user.Created = DateTime.UtcNow;
                _user.Updated = DateTime.UtcNow;
                return _user;


            }
        }
    
}
