using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVC8App.TagHelpers
{
    [HtmlTargetElement("*", Attributes ="Highlight")]
    public class HighlightTagHelper : TagHelper
    {
        public string Highlight {  get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            TagHelperAttribute existingStyle;
            if(output.Attributes.TryGetAttribute("style", out existingStyle))
            {
                string newStyle = existingStyle?.Value?.ToString();
                newStyle += $"background-color:{Highlight}";
                output.Attributes.Add("style", $"{newStyle}");
            }
            else
            {
                output.Attributes.Add("style", $"background-color:{Highlight}");
            }
        }
    }
}
