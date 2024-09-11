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
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Post> posts;

        private ICommand getPostsCommand { get; }

        public PostViewModel()
        {
            getPostsCommand = new Command(getPosts);
        }


        public async void getPosts()
        {
            PostServices postServices = new PostServices();

            Posts = await postServices.getPosts();
        }


    }
}
