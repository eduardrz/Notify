using System;
using Android.Webkit;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.App;
using Android.Graphics.Drawables;
using FortySevenDeg.SwipeListView;

namespace DrawerLayout_V7_Tutorial
{
	[Activity(Label = "SwipeList")]
	public class SwipeList : FragmentActivity
	{
		SwipeListView _swipeListView;
		DogsAdapter _adapter;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ListLayout);

			ActionBar.SetIcon(new ColorDrawable(Android.Graphics.Color.Transparent));

			_swipeListView = FindViewById<SwipeListView>(Resource.Id.example_lv_list);

			_adapter = new DogsAdapter(this, ListArchive.GetArchiveData());

			_swipeListView.FrontViewClicked += HandleFrontViewClicked;
			_swipeListView.BackViewClicked += HandleBackViewClicked;
			_swipeListView.Dismissed += HandleDismissed;

			_swipeListView.Adapter = _adapter;
		}
		void HandleFrontViewClicked(object sender, SwipeListViewClickedEventArgs e)
		{
			RunOnUiThread(() => _swipeListView.OpenAnimate(e.Position));
		}

		void HandleBackViewClicked(object sender, SwipeListViewClickedEventArgs e)
		{
			RunOnUiThread(() => _swipeListView.CloseAnimate(e.Position));
		}

		void HandleDismissed(object sender, SwipeListViewDismissedEventArgs e)
		{
			foreach (var i in e.ReverseSortedPositions)
			{
				_adapter.RemoveView(i);
			}
		}
	}
	public class DogsAdapter : BaseAdapter<Archive>
	{
		private readonly List<Archive> data;
		private readonly Activity context;

		public DogsAdapter(Activity activity, IEnumerable<Archive> speakers)
		{
			data = speakers.OrderBy(s => s.Name).ToList();
			context = activity;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override Archive this[int index]
		{
			get { return data[index]; }
		}

		public override int Count
		{
			get { return data.Count; }
		}

		public void RemoveView(int position)
		{
			data.RemoveAt(position);
			NotifyDataSetChanged();
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (view == null)
			{
				// inflate the custom AXML layout
				view = context.LayoutInflater.Inflate(Resource.Layout.package_row, null);
			}

			((SwipeListView)parent).Recycle(view, position);

			var dog = data[position];

			var ivImage = view.FindViewById<ImageView>(Resource.Id.example_row_iv_image);
			var tvTitle = view.FindViewById<TextView>(Resource.Id.example_row_tv_title);

			var image = GetHeadShot(dog.ImageUrl);
			ivImage.SetImageDrawable(image);
			tvTitle.Text = dog.Name;

			view.Click += (sender, e) =>
			{
				((ISwipeListViewListener)parent).OnClickBackView(position);
			};

			return view;
		}

		private Drawable GetHeadShot(string url)
		{
			Drawable headshotDrawable = null;
			try
			{
				headshotDrawable = Drawable.CreateFromStream(context.Assets.Open(url), null);
			}
			catch (Exception ex)
			{
				Android.Util.Log.Debug(GetType().FullName, "Error getting headshot for " + url + ", " + ex.ToString());
				headshotDrawable = null;
			}
			return headshotDrawable;
		}
	}
}
