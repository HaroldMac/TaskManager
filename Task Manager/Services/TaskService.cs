using System;
using System.Collections.Generic;

namespace Task_Manager
{
	class TaskService : TaskServiceInterface
	{
		public List<Task> Tasks { get; set; }

		public TaskService() {
			Tasks = new List<Task>();
		}

		/*
		 *	Create Methods
		*/

		public Task AddNewTask(Task Task)
		{
			Task.Id = (Tasks.Count + 1);
			Task.Color = GetTaskColor(Task);
			Tasks.Add(Task);
			return Task;
		}

		/*
		 *	Read Methods
		*/

		public List<Task> GetAllTasks()
		{
			return Tasks;
		}

		public Task GetTaskById(int Id)
		{
			return Tasks.Find(task => task.Id == Id);
		}


		/*
		 *	Update Methods
		*/

		public Task UpdateTask(Task TaskToUpdate)
		{
			foreach (Task Task in Tasks)
			{
				if (Task.Id == TaskToUpdate.Id)
				{
					Task.Name = TaskToUpdate.Name;
					Task.DueDate = TaskToUpdate.DueDate;
					Task.Completed = TaskToUpdate.Completed;
					Task.Color = GetTaskColor(TaskToUpdate);
				}
			}
			return TaskToUpdate;
		}
		
		/*
		 *	Delete Methods
		*/

		public void RemoveTask(Task removalTask)
		{
			Tasks.RemoveAll(task => task.Id == removalTask.Id);
		}


		/*
		 *	Helper Methods
		*/


		/*
		 *	Calls a check on each color to set the correct task color
		*/
		private void UpdateColors()
		{
			Tasks.ForEach(task => task.Color = GetTaskColor(task));
		}

		/*
		 * Sets the color based the task state. 
		 * If the task has been completed, return gray.
		 * If the task is past due, return red
		 * If the task is  not past due, return green.
		*/
		private string GetTaskColor(Task Task) {
			if (Task.Completed)
			{
				return "gray";
			}

			if (IsPastDue(Task))
			{
				return "red";
			}
			else
			{
				return "green";
			}	
		}

		/*
		 * Compares to DateTime objects. Returns true if taskDueDate is less than to the current dateTime
		*/
		private bool IsPastDue(Task Task)
		{
			if (Task.DueDate.CompareTo(DateTime.Today) < 0)
			{
				return true;
			}
			return false;
		}

	}
}
