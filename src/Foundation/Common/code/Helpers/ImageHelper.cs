using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links.UrlBuilders;
using Sitecore.Resources.Media;

namespace CarLease.Foundation.Common.Helpers
{
    public static class ImageHelper
    {
        public static string GetImageUrl(ImageField imageField)
        {
            
                var image = new MediaItem(imageField?.MediaItem);
                MediaUrlBuilderOptions mediaUrlOptions = new MediaUrlBuilderOptions
                {
                    AlwaysIncludeServerUrl = true
                };
            
            return MediaManager.GetMediaUrl(image, mediaUrlOptions);

        }
    }
}