using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Views;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {


        EditText login;
        EditText pwd;
        ProgressBar pgsBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            login = FindViewById<EditText>(Resource.Id.editTextmail);
            pwd = FindViewById<EditText>(Resource.Id.editTextpwd);



            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;

            pgsBar = FindViewById<ProgressBar>(Resource.Id.pBarLogin);
            pgsBar.Visibility = ViewStates.Gone;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            pgsBar.Visibility = ViewStates.Visible;
            var intent = new Intent(this, typeof(TaskMenuActivity));


            TaskDownloader TaskDownloader = new TaskDownloader();
            ToDoListDLL.Users Current = TaskDownloader.GetCurrentUserAsync(login.Text, pwd.Text);

            if (Current ==null)
            {
                pgsBar.Visibility = ViewStates.Gone;
                Toast.MakeText(this, "Wrong login or password ", ToastLength.Short).Show();
                
            }
            else
            {
                

                intent.PutExtra("UserID", Current.ID.ToString());
               // intent.PutExtra("Task", TasksSelectionned.ID.ToString());
                StartActivity(intent);
                Finish();
            }



            

           // StartActivity(intent);
        }
    }
}

