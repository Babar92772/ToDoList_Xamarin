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
using AndroidApp.Models;

namespace AndroidApp
{
    [Activity(Label = "AddTaskActivity")]
    public class AddTaskActivity : Activity
    {
        TextView _dateDisplay;
        EditText contentTask;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.ActivityAddTask);

            _dateDisplay = FindViewById<TextView>(Resource.Id.buttonDatePicker);

            Button datepicker = FindViewById<Button>(Resource.Id.buttonDatePicker);
            datepicker.Click += Datepicker_Click;

            Button button1 = FindViewById<Button>(Resource.Id.buttonAddTask);
            button1.Click += Button1_Click;

            contentTask = FindViewById<EditText>(Resource.Id.editTextTaskTitle);
            








            // Create your application here
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TaskTodoActivity));
            intent.PutExtra("addedtaskscontent", contentTask.Text);
            intent.PutExtra("addedtasksdeadline", _dateDisplay.Text);

            StartActivity(intent);
        }

        private void Datepicker_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateDisplay.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}