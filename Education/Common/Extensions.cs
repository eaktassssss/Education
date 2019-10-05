using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Education.Common
{
    public static class Extensions
    {
        public static MvcHtmlString Button1(this HtmlHelper helper , ButtonOptions options)
        {
            try
            {
                var button = string.Format("<button id='{0}' name='{1}' type='{2}' class='{3}'>{4}</button>",options.Id,options.Name,options.Type.ToString(),options.Class,options.Text);
                return  MvcHtmlString.Create(button);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public static MvcHtmlString Button2(this HtmlHelper helper, ButtonOptions options)
        {
            var builder = new TagBuilder("button");
            builder.Attributes.Add(new KeyValuePair<string, string>("name",options.Name));
            builder.GenerateId(options.Id);
            builder.SetInnerText(options.Text);
            builder.AddCssClass(options.Class);
            builder.Attributes.Add(new KeyValuePair<string, string>("type",options.Type.ToString()));
            return MvcHtmlString.Create(builder.ToString());
        }
    }


    public class ButtonOptions
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ButtonType Type { get; set; }
        public string Class { get; set; }
        public string Text { get; set; }
        public ButtonOptions()
        {
            Type = ButtonType.button;
            Id = "btnDefaultSend";
            Name = "btnDefaultSend";
            Text = "Button";
            Class = "btn btn-default";
        }
    }
    public enum ButtonType
    {
        button=0,submit=1,reset=2
    }

}