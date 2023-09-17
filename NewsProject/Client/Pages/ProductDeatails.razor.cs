using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;

namespace NewsProject.Client.Pages
{
    public partial class ProductDeatails
    {
        Product _product = new Product();
        //   private List<Comment> _comments = new List<Comment>();
        // private Comment _newComment = new Comment();
        [Inject]
        IMainService<Product> _service { get; set; }
        [Inject]
        //  public IMainService<Comment> _commentService { get; set; }

        [Parameter]
        public int id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _product = await _service.GetRow($"api/Product/GetProduct/{id}");

            //    _comments = await _commentService.GetAll($"api/Comments/GetAllComments/{id}");
        }
        //private async Task AddComment()
        //{
        //    _newComment.newsListId = int.Parse(id);
        //    await _commentService.AddNewRow(_newComment, "api/Comments/AddComment");
        //    _newComment = new Comment();
        //    _comments = await _commentService.GetAll($"api/Comments/GetAllComments/{id}");
        //}
    }
}
