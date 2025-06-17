using FeedCord.Common;

namespace FeedCord.Services.Helpers;

public static class FilterConfigs
{
    public static bool GetFilterSuccess(Post post, string[] filterWords)
    {
        var titleLower = post.Title.ToLower();
        var descLower = post.Description.ToLower();

        // Check title and description
        var foundInTitleOrDesc = filterWords.Any(word => post.Title.Contains(word, StringComparison.OrdinalIgnoreCase))
                                || filterWords.Any(word => post.Description.Contains(word, StringComparison.OrdinalIgnoreCase));
        
        // Check labels (if they exist)
        var foundInLabels = post.Labels != null && post.Labels.Length > 0 &&
                           filterWords.Any(word => post.Labels.Any(label => 
                               label.Contains(word, StringComparison.OrdinalIgnoreCase)));

        return foundInTitleOrDesc || foundInLabels;
    }
}