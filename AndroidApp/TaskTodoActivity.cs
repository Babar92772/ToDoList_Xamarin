using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using ToDoListDLL;

namespace AndroidApp
{
    [Activity(Label = "TaskTodoActivity")]
    public class TaskTodoActivity : Activity
    {
        List<Tasks> tasksList = new List<Tasks>();

        string userid;
        string taskstate = "todo";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityTaskTodo);
            userid = Intent.Extras.GetString("UserID");

            var lv_tasks = FindViewById<ListView>(Resource.Id.listViewTaskTodo);

            var btn_menu = FindViewById<Button>(Resource.Id.buttonBackToMenuToDo);

            var btn_add = FindViewById<Button>(Resource.Id.buttonToDoToAdd);

            btn_menu.Click += Btn_menu_Click;

            btn_add.Click += Btn_add_Click;

            //    var swipeRefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeRefreshLayoutTasks);


            // swipeRefresh.Refresh += async (sender, e) =>
            // {
            //    swipeRefresh.Refreshing = true;

            //var newArticles = await rssDownloader.Get(url);
            // lv_tasks.Adapter = new TaskAdapter( newArticles,this);

            //    swipeRefresh.Refreshing = false;
            //   };

            TaskDownloader TaskDownloader = new TaskDownloader();
          

                 tasksList = TaskDownloader.GetTodoAllTasks().ToList();
               


            //foreach(Tasks s in tall)
            //{
            //    tasksList.Add(s);
            //}

            // progressbar.Visibility = ViewStates.Gone;

            var taskAdapter = new TaskAdapter(tasksList, this);
                lv_tasks.Adapter = taskAdapter;
                // tasksList.Add(new Tasks(Intent.Extras.GetString("addedtaskscontent")));
         


            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));
            //tasksList.Add(new Tasks("hsdlhfklsdhkf"));

           // var taskAdapter = new TaskAdapter( tasksList, this);
            //lv_tasks.Adapter = taskAdapter;


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


            // Create your application here
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