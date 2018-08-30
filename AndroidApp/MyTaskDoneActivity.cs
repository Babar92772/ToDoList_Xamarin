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
    [Activity(Label = "MyTaskDoneActivity")]
    public class MyTaskDoneActivity : Activity
    {

        List<Tasks> tasksList = new List<Tasks>();

        string userid;
        string taskstate = "done";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityMyTaskDone);

            userid = Intent.Extras.GetString("UserID");

            var lv_tasks = FindViewById<ListView>(Resource.Id.listViewMyTaskDone);

            var btn_menu = FindViewById<Button>(Resource.Id.buttonBackToMenuMyTaskDone);

            var btn_add = FindViewById<Button>(Resource.Id.buttonMyTaskDoneToAdd);

            btn_menu.Click += Btn_menu_Click;

            btn_add.Click += Btn_add_Click;


            TaskDownloader TaskDownloader = new TaskDownloader();


            tasksList = TaskDownloader.GetAllMyTasksDone(Intent.Extras.GetString("UserID")).ToList();

            var taskAdapter = new TaskAdapter(tasksList, this);
            lv_tasks.Adapter = taskAdapter;


            lv_tasks.ItemClick += (sender, e) =>
            {
                Tasks TasksSelectionned = tasksList[e.Position];




                var intent = new Intent(this, typeof(DetailTaskActivity));


                intent.PutExtra("TaskContent", TasksSelectionned.Note);
                intent.PutExtra("TaskDeadline", TasksSelectionned.DeadLine.ToString());
                intent.PutExtra("TaskID", TasksSelectionned.ID.ToString());
                intent.PutExtra("Task", TasksSelectionned.ID.ToString());
                intent.PutExtra("UserID", userid);
                intent.PutExtra("TaskState", taskstate);

                StartActivity(intent);
            };
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {

            var intent = new Intent(this, typeof(AddTaskActivity));
            intent.PutExtra("UserID", userid);
            intent.PutExtra("TaskState", taskstate);

            StartActivity(intent);
        }

        private void Btn_menu_Click(object sender, EventArgs e)
        {

            var intent = new Intent(this, typeof(TaskMenuActivity));
            intent.PutExtra("UserID", userid);
            intent.PutExtra("TaskState", taskstate);
            StartActivity(intent);
        }

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(TaskMenuActivity));
            intent.PutExtra("UserID", userid);

            StartActivity(intent);
        }
    }
}