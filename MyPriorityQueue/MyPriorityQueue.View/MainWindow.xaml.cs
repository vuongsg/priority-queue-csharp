using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPriorityQueue.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : BaseWindow
	{
		private PriorityQueue<User> queue = new PriorityQueue<User>();

		private int currentAddedIndex = -1;

		private ObservableCollection<User> _users;
		public ObservableCollection<User> Users
		{
			get
			{
				if (_users == null)
				{
					_users = new ObservableCollection<User>();
				}
				return _users;
			}
			set
			{
				_users = value;
				OnPropertyChange(nameof(this.Users));
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
		}

		private void btnSubmit_Click(object sender, RoutedEventArgs e)
		{
			Submit();
		}

		private void Submit()
		{
			string name = tbxName.Text.Trim();
			if (string.IsNullOrEmpty(name))
			{
				MessageBox.Show("Please provide name");
				return;
			}

			int age;
			if (!int.TryParse(tbxAge.Text.Trim(), out age))
			{
				MessageBox.Show("Please provide correct age");
				ClearText(tbxAge);
				return;
			}

			if (currentAddedIndex != -1)
			{
				Users[currentAddedIndex].AddedNew = false;
			}
			currentAddedIndex = queue.Enqueue(new User { Name = name, Age = age });
			Users = new ObservableCollection<User>(queue.ToList());
			Users[currentAddedIndex].AddedNew = true;
			ClearText(tbxName, tbxAge);
			tbxName.Focus();
		}

		private void wnd_Loaded(object sender, RoutedEventArgs e)
		{
			tbxName.Focus();
		}

		private void ClearText(params TextBox[] tbxs)
		{
			foreach (TextBox tb in tbxs)
			{
				tb.Clear();
			}
		}

		private void tbxName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				tbxAge.Focus();
			}
		}

		private void tbxAge_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Submit();
			}
		}
	}
}
