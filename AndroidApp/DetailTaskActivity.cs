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
using ToDoListDLL;

namespace AndroidApp
{
    [Activity(Label = "DetailTaskActivity")]
    public class DetailTaskActivity : Activity
    {

        DateTime dl;

        int id;

        EditText taskdetailcontent;

        TextView taskdeadline;

        ProgressBar pgsBar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityDetailTask);

            taskdetailcontent = FindViewById<EditText>(Resource.Id.editTextTaskDetailTitle);

            taskdetailcontent.Text = Intent.Extras.GetString("TaskContent");
            //  taskdetailcontent.Text = Intent.Extras.GetString("TaskID");

            pgsBar = FindViewById<ProgressBar>(Resource.Id.pBarDetails);
            pgsBar.Visibility = ViewStates.Gone;

            var taskdeadline = FindViewById<TextView>(Resource.Id.buttonDatePickerDetailTask);

            var datepicker = FindViewById<Button>(Resource.Id.buttonDatePickerDetailTask);
            datepicker.Click += Datepicker_Click;

            var btn_gotodo = FindViewById<Button>(Resource.Id.buttonBackToMenuToDo);

            var btn_del = FindViewById<Button>(Resource.Id.buttondetailtaskdelete);

            btn_del.Click += Btn_del_Click;

            var btn_edit = FindViewById<Button>(Resource.Id.buttonEditDetailTask);

            btn_edit.Click += Btn_edit_Click;

            taskdeadline.Text = Intent.Extras.GetString("TaskDeadline");

            id = int.Parse(Intent.Extras.GetString("TaskID"));

            dl = DateTime.Parse(Intent.Extras.GetString("TaskDeadline"));

            // Create your application here
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {


            pgsBar.Visibility = ViewStates.Visible;
            TaskDownloader TaskDownloader = new TaskDownloader();
           Tasks s =  TaskDownloader.GetTasks(id);
            s.Note = taskdetailcontent.Text;
            s.DeadLine = dl;
            TaskDownloader.EditTaskAsync(s);

            var intent = new Intent(this, typeof(TaskTodoActivity));
            StartActivity(intent);


        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            TaskDownloader TaskDownloader = new TaskDownloader();

            string id = Intent.Extras.GetString("TaskID");
            TaskDownloader.DeleteTasksAsync(id);
            var intent = new Intent(this, typeof(TaskTodoActivity));
            StartActivity(intent);
        }

        private void Datepicker_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime  dl)
            {
                taskdeadline.Text = dl.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}