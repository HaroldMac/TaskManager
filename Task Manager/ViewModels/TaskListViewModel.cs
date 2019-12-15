
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Task_Manager.Command;

namespace Task_Manager.ViewModels

{
	public class TaskListViewModel
	{

		private TaskServiceInterface _TaskServce;

		public ObservableCollection<Task> Tasks { get; set; }

		private Task _SelectedTask;

		public Task SelectedTask
		{
			get { return _SelectedTask; }
			set { _SelectedTask = value; }
		}

		private string _CurrentDate;

		public string CurrentDate
		{
			get { return _CurrentDate; }
			set { _CurrentDate = value; }
		}

		private Task _NewTask;

		public Task NewTask
		{
			get { return _NewTask; }
			set { _NewTask = value; }
		}

		/*
		 * Constructor
		 * Create objects for databinding
		*/

		public TaskListViewModel()
		{
			_TaskServce = new TaskService();
			Tasks = new ObservableCollection<Task>(_TaskServce.GetAllTasks());
			NewTask = new Task();

			AddCommand = new AddCommand(this);
			UpdateCommand = new UpdateCommand(this);
			DeleteCommand = new DeleteCommand(this);
			CurrentDate = DateTime.Today.ToLongDateString();
		}

		/*
		 * ICommand Objects
		*/
		public ICommand AddCommand { get; private set; }
		public ICommand UpdateCommand { get; private set; }
		public ICommand DeleteCommand { get; private set; }

		/*
		 * Checks newTask name value for null or white space
		 * Returns true if not null or no white space
		*/
		public Boolean CanAdd()
		{
			if (NewTask.Name == null)
			{
				return false;
			}
			return !String.IsNullOrWhiteSpace(NewTask.Name);
		}

		/* 
		 * Creates a new Task.
		 * Adds new task to the grid data and the task service.
		 * resets form data.
		*/
		public void OnAdd() {
			//Create Task to add
			Task taskToAdd = new Task(_NewTask.Name, _NewTask.DueDate);
			
			//Add to GridData
			taskToAdd =	_TaskServce.AddNewTask(taskToAdd);
			Tasks.Add(taskToAdd);
			
			//Reset Form Data
			NewTask.Name = "";
			NewTask.DueDate = DateTime.Today;
		}

		/* 
		 * Checks to grid data for a selected value. 
		 * Returns true if a row is selected.
		*/
		public Boolean CanUpdate()
		{
			if (SelectedTask == null)
			{
				return false;
			}
			return true;
		}

		/*
		 * Sends updated values from task to the Task Service to be saved.
		*/
		public void OnUpdate()
		{
			SelectedTask = _TaskServce.UpdateTask(SelectedTask);
		}

		/* 
		 * Checks to grid data for a selected value. 
		 * Returns true if a row is selected.
		*/
		public Boolean CanDelete()
		{
			if (SelectedTask == null)
			{
				return false;
			}
			return true;
		}

		/*
		 * Sends selected task to the Task Service to be deleted.
		 * Removes the task from the d
		*/
		public void OnDelete()
		{
			_TaskServce.RemoveTask(SelectedTask);
			Tasks.Remove(SelectedTask);
		}
	}
}
