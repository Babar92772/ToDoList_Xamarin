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

        RadioGroup rdgroup;
        RadioButton btodo;
        RadioButton bprogress;
        RadioButton bdone;


        ProgressBar pgsBar;

        string userid;

        string taskstate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityDetailTask);

            taskdetailcontent = FindViewById<EditText>(Resource.Id.editTextTaskDetailTitle);

            taskdetailcontent.Text = Intent.Extras.GetString("TaskContent");

            userid = Intent.Extras.GetString("UserID");


            taskstate  = Intent.Extras.GetString("TaskTaste");
            //  taskdetailcontent.Text = Intent.Extras.GetString("TaskID");

            pgsBar = FindViewById<ProgressBar>(Resource.Id.pBarDetails);
            pgsBar.Visibility = ViewStates.Gone;

            rdgroup = FindViewById<RadioGroup>(Resource.Id.radioGroupDetail);

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

            rdgroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

            btodo = FindViewById<RadioButton>(Resource.Id.radioButtonDetail1);
            bprogress = FindViewById<RadioButton>(Resource.Id.radioButtonDetail2);
            bdone = FindViewById<RadioButton>(Resource.Id.radioButtonDetail3);

            if (Intent.Extras.GetString("TaskState") == "todo")
            {
                btodo.Checked = true;
            }
            if (Intent.Extras.GetString("TaskState") == "progress")
            {
                bprogress.Checked = true;
            }
            if (Intent.Extras.GetString("TaskState") == "done")
            {
                bdone.Checked = true;
            }

            // Create your application here
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {


            pgsBar.Visibility = ViewStates.Visible;
            TaskDownloader TaskDownloader = new TaskDownloader();
           Tasks s =  TaskDownloader.GetTasks(id);
            s.Note = taskdetailcontent.Text;
            s.DeadLine = dl;
            RadioButton radioButton = FindViewById<RadioButton>(rdgroup.CheckedRadioButtonId);
           
           s.TaskState = radioButton.Text;
            TaskDownloader.EditTaskAsync(s);

            var intent = new Intent(this, typeof(TaskTodoActivity));
            intent.PutExtra("UserID", userid);
            StartActivity(intent);


        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            TaskDownloader TaskDownloader = new TaskDownloader();

            string id = Intent.Extras.GetString("TaskID");
            TaskDownloader.DeleteTasksAsync(id);
            var intent = new Intent(this, typeof(TaskTodoActivity));
            intent.PutExtra("UserID", userid);
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