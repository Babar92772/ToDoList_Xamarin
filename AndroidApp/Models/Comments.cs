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
using Java.Sql;

namespace AndroidApp.Models
{
    class Comments
    {

        int IDUser;
        int IDTask;
        DateTime creationDate;
        string content;

        public Comments(int iDUser1, int iDTask1, DateTime creationDate, string content)
        {
            IDUser1 = iDUser1;
            IDTask1 = iDTask1;
            CreationDate = creationDate;
            Content = content;
        }

        public int IDUser1 { get => IDUser; set => IDUser = value; }
        public int IDTask1 { get => IDTask; set => IDTask = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public string Content { get => content; set => content = value; }
    }
}