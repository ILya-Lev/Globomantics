using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "active-url")]
    public class ActiveTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public string ActiveUrl { get; set; }

        public ActiveTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_contextAccessor.HttpContext.Request.Path.ToString().Contains(ActiveUrl))
            {
                var givenStyle = output.Attributes["class"]?.Value.ToString();
                output.Attributes.SetAttribute("class", $"active {givenStyle}");
            }
        }
    }
}
