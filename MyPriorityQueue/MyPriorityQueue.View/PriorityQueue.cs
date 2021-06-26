using System;
using System.Collections.Generic;

namespace MyPriorityQueue.View
{
	public class PriorityQueue<T> where T : IComparable
	{
		private List<T> array;
		private bool isAscending;

		public PriorityQueue(bool isAscending = true)
		{
			array = new List<T>();
			this.isAscending = isAscending;
		}

		public int Enqueue(T item)
		{
			int index = FindCompatiblePlace(item);
			array.Insert(index, item);
			return index;
		}

		public T Dequeue()
		{
			if (array.Count > 0)
			{
				T item = array[0];
				array.RemoveAt(0);
				return item;
			}

			throw new Exception("Queue null");
		}

		public T Peek()
		{
			if (array.Count > 0)
			{
				return array[0];
			}

			throw new Exception("Queue null");
		}

		public bool IsEmpty()
		{
			return array.Count == 0;
		}

		public List<T> ToList()
		{
			return array;
		}

		private int FindCompatiblePlace(T item)
		{
			int left = 0;
			int right = array.Count - 1;
			int? accept = null;

			if (isAscending)
			{
				while (left <= right)
				{
					int mid = left + (right - left) / 2;
					int compareTo = array[mid].CompareTo(item);
					switch (compareTo)
					{
						case 0:
							accept = mid;
							left = mid + 1;
							break;
						case 1:
							right = mid - 1;
							break;
						case -1:
							left = mid + 1;
							break;
					}
				}
			}
			else
			{
				while (left <= right)
				{
					int mid = left + (right - left) / 2;
					int compareTo = array[mid].CompareTo(item);
					switch (compareTo)
					{
						case 0:
							accept = mid;
							right = mid - 1;
							break;
						case -1:
							right = mid - 1;
							break;
						case 1:
							left = mid + 1;
							break;
					}
				}
			}

			return accept ?? left;
		}
	}
}
