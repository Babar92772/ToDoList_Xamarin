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
        ProgressBar pgsBar;
        string userid;
        RadioGroup rdgroup;
        RadioButton btodo;
        RadioButton bprogress;
        RadioButton bdone;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.ActivityAddTask);

            userid = Intent.Extras.GetString("UserID");

            _dateDisplay = FindViewById<TextView>(Resource.Id.buttonDatePicker);

            Button datepicker = FindViewById<Button>(Resource.Id.buttonDatePicker);
            datepicker.Click += Datepicker_Click;

            Button button1 = FindViewById<Button>(Resource.Id.buttonAddTask);
            button1.Click += Button1_Click;

            contentTask = FindViewById<EditText>(Resource.Id.editTextTaskTitle);

            pgsBar = FindViewById<ProgressBar>(Resource.Id.pBarAddTask);
            pgsBar.Visibility = ViewStates.Gone;

            rdgroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

            btodo = FindViewById<RadioButton>(Resource.Id.radioButton1);
            bprogress = FindViewById<RadioButton>(Resource.Id.radioButton2);
            bdone = FindViewById<RadioButton>(Resource.Id.radioButton3);

            if(Intent.Extras.GetString("TaskState") == "todo")
            {
                btodo.Checked=true;
            }
            if (Intent.Extras.GetString("TaskState") == "progress")
            {
                bprogress.Checked = true;
            }
            if (Intent.Extras.GetString("TaskState") == "done")
            {
                bdone.Checked = true;
            }


            rdgroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            










            // Create your application here
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TaskTodoActivity));
            intent.PutExtra("addedtaskscontent", contentTask.Text);
            intent.PutExtra("addedtasksdeadline", _dateDisplay.Text);
            intent.PutExtra("UserID", userid);

            TaskDownloader TaskDownloader = new TaskDownloader();

           
            ToDoListDLL.Tasks t = new ToDoListDLL.Tasks();
            t.Note = contentTask.Text;
            RadioButton radioButton = FindViewById<RadioButton>(rdgroup.CheckedRadioButtonId);
            t.TaskState = radioButton.Text;
            t.IDUserCreator = int.Parse(userid);
            
            t.IDUserCreator = int.Parse(userid);
            DateTime date = new DateTime(2011, 2, 19);
            date.ToString("s");
            t.CreateDate = DateTime.Now;
            DateTime test;
            if(DateTime.TryParse( _dateDisplay.Text,out test) )
            {
                t.DeadLine = DateTime.Parse(_dateDisplay.Text);
            }
            else
            {
                t.DeadLine = DateTime.Now;
            }
          
           // t.DeadLine = _dateDisplay.Text;

             TaskDownloader.AddTasksAsync(t);

            intent.PutExtra("UserID", userid);
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

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(TaskMenuActivity));
            intent.PutExtra("UserID", userid);

            StartActivity(intent);
        }
    }
}