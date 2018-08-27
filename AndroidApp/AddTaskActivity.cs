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

            TaskDownloader TaskDownloader = new TaskDownloader();

           
            ToDoListDLL.Tasks t = new ToDoListDLL.Tasks();
            t.Note = "lol";
            t.IDUserCreator = 14786;
            t.TaskState = "todo";
            DateTime date = new DateTime(2011, 2, 19);
            date.ToString("s");
            t.CreateDate = date;
           // t.DeadLine = DateTime.Now.ToUniversalTime();


             TaskDownloader.AddTasksAsync(t);


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