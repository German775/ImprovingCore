using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "active-url")]
    public class ActiveTagHelper : TagHelper
    {
        public string ActiveUrl { get; set; }
        private IHttpContextAccessor _httpService;

        public ActiveTagHelper(IHttpContextAccessor httpService)
        {
            _httpService = httpService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_httpService.HttpContext.Request.Path.ToString().Contains(ActiveUrl))
            {
                var exsitingAttrs = output.Attributes["class"]?.Value;
                output.Attributes.SetAttribute("class", "active " + exsitingAttrs.ToString());
            }
        }
    }
}
