using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_24.PL.Helpers {
    public static class FormHelpers {

        public static MvcHtmlString CreateCheckboxList(this HtmlHelper html, string name, List<string> values,
            string checkedItemValue = "") {

            var list = new TagBuilder("ul");
            list.AddCssClass("check-list");
            foreach (var value in values) {
                var listItem = new TagBuilder("li");
                listItem.AddCssClass("form-check");

                var checkbox = new TagBuilder("input");

                checkbox.AddCssClass("form-check-input");

                checkbox.MergeAttribute("id", name + value);
                checkbox.MergeAttribute("value", value);
                checkbox.MergeAttribute("name", name);
                checkbox.MergeAttribute("type", "checkbox");

                if (value == checkedItemValue) {
                    checkbox.MergeAttribute("checked", "checked");
                }

                listItem.InnerHtml += checkbox.ToString(TagRenderMode.SelfClosing);

                var label = new TagBuilder("label");
                label.MergeAttribute("for", name + value);
                label.SetInnerText(value);

                listItem.InnerHtml += label.ToString();

                list.InnerHtml += listItem.ToString();
            }

            return new MvcHtmlString(list.ToString());
        }

        public static MvcHtmlString CreateRadioButtonList(this HtmlHelper html, string name, List<string> values,
            string checkedItemValue = "") {
            var list = new TagBuilder("ul");
            list.AddCssClass("check-list");
            foreach (var value in values) {
                var listItem = new TagBuilder("li");
                listItem.AddCssClass("form-check");

                var checkbox = new TagBuilder("input");

                checkbox.AddCssClass("form-check-input");

                checkbox.MergeAttribute("id", name + value);
                checkbox.MergeAttribute("value", value);
                checkbox.MergeAttribute("name", name);
                checkbox.MergeAttribute("type", "radio");

                if (value == checkedItemValue) {
                    checkbox.MergeAttribute("checked", "checked");
                }

                listItem.InnerHtml += checkbox.ToString(TagRenderMode.SelfClosing);

                var label = new TagBuilder("label");
                label.MergeAttribute("for", name + value);
                label.SetInnerText(value);

                listItem.InnerHtml += label.ToString();

                list.InnerHtml += listItem.ToString();
            }

            return new MvcHtmlString(list.ToString());
        }

    }
}