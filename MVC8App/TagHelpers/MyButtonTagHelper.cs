using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVC8App.TagHelpers
{
    [HtmlTargetElement("my-button")]
    public class MyButtonTagHelper : TagHelper
    {
        public string Type {  get; set; }

        public string Value { get; set; }
        

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.Add("type", Type);
            output.Attributes.Add("value", Value);
        }
    }
}
