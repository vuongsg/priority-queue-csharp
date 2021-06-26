using System;

namespace MyPriorityQueue.View
{
	public class User : BaseModel, IComparable
	{
		public Guid Id { get; set; }

		private string _name;
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				OnPropertyChanged(nameof(this.Name));
			}
		}

		private int _age;
		public int Age
		{
			get => _age;
			set
			{
				_age = value;
				OnPropertyChanged(nameof(this.Age));
			}
		}

		private bool _addedNew;
		public bool AddedNew
		{
			get => _addedNew;
			set
			{
				_addedNew = value;
				OnPropertyChanged(nameof(this.AddedNew));
			}
		}

		public User()
		{
			Id = Guid.NewGuid();
		}

		public int CompareTo(object obj)
		{
			int compareAge = this.Age.CompareTo((obj as User).Age);
			if (compareAge != 0)
			{
				return compareAge;
			}

			return this.Name.CompareTo((obj as User).Name);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is User))
			{
				return false;
			}
			return this.CompareTo(obj) == 0;
		}

		public static bool operator ==(User a, User b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(User a, User b)
		{
			return a.Equals(b);
		}

		public static bool operator <(User a, User b)
		{
			return a.CompareTo(b) < 0;
		}

		public static bool operator >(User a, User b)
		{
			return a.CompareTo(b) > 0;
		}

		public static bool operator <=(User a, User b)
		{
			return a.CompareTo(b) <= 0;
		}

		public static bool operator >=(User a, User b)
		{
			return a.CompareTo(b) >= 0;
		}
	}
}
