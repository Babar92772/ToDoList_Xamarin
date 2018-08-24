using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidApp.Models
{
    class Users
    {
        string mail;
        string password;

        public Users(string mail, string password)
        {
            Mail = mail;
            Password = password;
        }

        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
    }
}