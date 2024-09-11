using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using HTTPClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HTTPClient.ViewsModels
{
    public partial class TodosViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection <Todos> todos;

        private ICommand getPostsCommand { get; }

        public TodosViewModel()
        {
            getTodosCommand = new Command(getTodos);
        }


        public async void getTodos()
        {
            TodosServices todosServices = new TodosServices();

            Todos = await todosServices.getTodos();
        }


    }
}
