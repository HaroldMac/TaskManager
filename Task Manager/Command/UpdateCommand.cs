using System;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Command
{
	class UpdateCommand : ICommand
	{

		public UpdateCommand(TaskListViewModel ViewModel)
		{
			_ViewModel = ViewModel;
		}

		private TaskListViewModel _ViewModel;

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			
			return _ViewModel.CanUpdate();
		}

		public void Execute(object parameter)
		{
			_ViewModel.OnUpdate();
		}
	}

}
