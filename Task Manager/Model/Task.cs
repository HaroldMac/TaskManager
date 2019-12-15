using System;
using System.ComponentModel;

namespace Task_Manager
{
	public class Task : INotifyPropertyChanged
	{
		/*
		 * Class properties
		*/

		private int _Id;
		private String _Name;
		private String _Color;
		private DateTime _DueDate;
		private Boolean _Completed;

		/*
		 * Class getters setters
		*/
		public int Id
		{
			get { return _Id; }
			set {
				_Id = value;
				OnProperyChanged("Id");
			}
		}

		public string Name
		{
			get { return _Name; }
			set
			{
				_Name = value;
				OnProperyChanged("Name");
			}
		}

		public string Color
		{
			get { return _Color; }
			set
			{
				_Color = value;
				OnProperyChanged("Color");
			}
		}

		public DateTime DueDate
		{
			get { return _DueDate; }
			set
			{
				_DueDate = value;
				OnProperyChanged("DueDate");
			}
		}
		public Boolean Completed
		{
			get { return _Completed; }
			set
			{
				_Completed = value;
				OnProperyChanged("Completed");
			}
		}
		
		/*
		 * Constructors
		*/

		public Task() { }
		public Task(String name, DateTime dueDate)
		{
			_Name = name;
			_DueDate = dueDate;
			_Completed = false;
			_Color = "green";
		}
		public Task(int id, String name, DateTime dueDate) {
			_Id = id;
			_Name = name;
			_DueDate = dueDate;
			_Completed = false;
			_Color = "green";
		}


		/*
		 * Property Changed Event Handler
		 */
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnProperyChanged(String propertyName) {
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
	}
}


