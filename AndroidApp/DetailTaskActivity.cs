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
    [Activity(Label = "DetailTaskActivity")]
    public class DetailTaskActivity : Activity
    {

        TextView taskdeadline;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityDetailTask);

            var taskdetailcontent = FindViewById<EditText>(Resource.Id.editTextTaskDetailTitle);

            taskdetailcontent.Text = Intent.Extras.GetString("TaskContent");

            var taskdeadline = FindViewById<TextView>(Resource.Id.buttonDatePickerDetailTask);

            var datepicker = FindViewById<Button>(Resource.Id.buttonDatePickerDetailTask);
            datepicker.Click += Datepicker_Click;

            var btn_gotodo = FindViewById<Button>(Resource.Id.buttonBackToMenuToDo);

            // Create your application here
        }

        private void Datepicker_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                taskdeadline.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}