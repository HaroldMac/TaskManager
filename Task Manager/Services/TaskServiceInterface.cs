using System.Collections.Generic;

namespace Task_Manager
{
	interface TaskServiceInterface
	{

		//Create Methods
		Task AddNewTask(Task task);

		//Read Methods
		List<Task> GetAllTasks();
		Task GetTaskById(int Id);

		//Update Methods
		Task UpdateTask(Task task);


		//Delete Methods
		void RemoveTask(Task task);
	}
}
