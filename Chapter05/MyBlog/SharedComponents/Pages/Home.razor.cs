
using Data.Models;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace SharedComponents.Pages;

public partial class Home
{
    protected List<BlogPost> posts = new();
    public int totalBlogposts { get; set; }
    private async ValueTask<ItemsProviderResult<BlogPost>> LoadPosts(ItemsProviderRequest request)
    {
        if (totalBlogposts == 0)
        {
            totalBlogposts = await _api.GetBlogPostCountAsync();
        }
        var numblogposts = Math.Min(request.Count, totalBlogposts - request.StartIndex);
        var blogposts = await _api.GetBlogPostsAsync(numblogposts, request.StartIndex);
        return new ItemsProviderResult<BlogPost>(blogposts, totalBlogposts);
    }
}
