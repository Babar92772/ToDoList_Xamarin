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
    class TaskAdapter : BaseAdapter<Tasks>
    {
        private List<Tasks> _data;
        private Android.App.Activity _activity;

        public TaskAdapter(List<Tasks> data, Activity activity)
        {
            _data = data;
            _activity = activity;
        }

        public override Tasks this[int position] => _data[position];

        public override int Count => _data.Count;

        public override long GetItemId(int position)
        {
            return 0;
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var tasks = _data[position];

            var view = convertView ?? _activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, parent, false);

            var content = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            content.Text = tasks.Note;

            return view;
        }
    }
}