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
    class Tasks
    {
        int ID;
        string TastState;
        DateTime deadline;
        string note;
        int IDUserCreator;
        List<Users> contributors;

        public Tasks(int iD1, string tastState1, DateTime deadline, string note, int iDUserCreator1)
        {
            ID1 = iD1;
            TastState1 = tastState1;
            Deadline = deadline;
            Note = note;
            IDUserCreator1 = iDUserCreator1;
        }

        public Tasks( string note)
        {
           
            Note = note;
            
        }

        public int ID1 { get => ID; set => ID = value; }
        public string TastState1 { get => TastState; set => TastState = value; }
        public DateTime Deadline { get => deadline; set => deadline = value; }
        public string Note { get => note; set => note = value; }
        public int IDUserCreator1 { get => IDUserCreator; set => IDUserCreator = value; }
        internal List<Users> Contributors { get => contributors; set => contributors = value; }
    }
}