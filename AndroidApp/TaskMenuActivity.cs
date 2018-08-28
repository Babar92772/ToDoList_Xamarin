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

namespace AndroidApp
{
    [Activity(Label = "TaskMenuActivity")]
    public class TaskMenuActivity : Activity
    {

        ProgressBar pgsBar;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityTaskMenu);

            Button button1 = FindViewById<Button>(Resource.Id.buttonMenu1);
            Button button2 = FindViewById<Button>(Resource.Id.buttonMenu2);
            Button button3 = FindViewById<Button>(Resource.Id.buttonMenu3);
            Button button4 = FindViewById<Button>(Resource.Id.buttonMenu4);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;

             pgsBar = FindViewById<ProgressBar>(Resource.Id.pBarMenu);
            pgsBar.Visibility = ViewStates.Gone;



            
            // Create your application here
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            pgsBar.Visibility = ViewStates.Visible;
            var intent = new Intent(this, typeof(AddTaskActivity));


            StartActivity(intent);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            pgsBar.Visibility = ViewStates.Visible;
            var intent = new Intent(this, typeof(TaskMenuActivity));


            StartActivity(intent);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            pgsBar.Visibility = ViewStates.Visible;
            var intent = new Intent(this, typeof(TaskMenuActivity));


            StartActivity(intent);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pgsBar.Visibility = ViewStates.Visible;

            var intent = new Intent(this, typeof(TaskTodoActivity));
           

            StartActivity(intent);
            //Finish();
            //  pgsBar.Visibility = ViewStates.Gone;
        }
    }
}