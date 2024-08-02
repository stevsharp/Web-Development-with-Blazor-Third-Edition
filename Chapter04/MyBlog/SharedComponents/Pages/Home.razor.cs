using Data.Models;


namespace SharedComponents.Pages;

public partial class Home
{
    protected List<BlogPost> posts = new();

    protected override async Task OnInitializedAsync()
    {
        posts = await _api.GetBlogPostsAsync(10, 0);
        await base.OnInitializedAsync();
    }
}
