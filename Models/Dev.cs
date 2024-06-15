using Microsoft.CodeAnalysis;
using System;

namespace ECommWeb.Models
{
    public class Dev
    {
        public string Name { get; set; }
        public string Experience { get; set; }

        public string Location { get; set; }

        public string Hobbies { get; set; }
        public string Skill { get; set; }
        public string Frontend { get; set; }
        public string Backend { get; set; }
       
        public string API { get; set; }

        public Dev()
        {
            Name = "Swapnil";
            Experience = "2 years of experience at Infobridge Solutions ";
            Location = "Pune";
            Skill = "Web Developer";
            Frontend="HTML, CSS-BootStrap, JavaScript-Jquery, Devexpress";
            Backend = "ASP.NET Core, MVC, AJAX, Web Forms, MS SQL Server";
            API = "Web API";
            Hobbies = "Coding";


        }

    }




}
