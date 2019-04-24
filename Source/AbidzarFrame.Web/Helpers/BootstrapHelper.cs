using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebGrease.Css.Extensions;

namespace AbidzarFrame.Web.Helpers
{
    public static class BootstrapHelper
    {
        #region Html Label
        // overide controll labelfor dengan menambahkan class col-md-2 control-label
        public static IHtmlString BootstrapLabelFor<TModel, TProp>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProp>> property)
        {
            return helper.LabelFor(property, new
            {
                @class = "col-md-2 control-label"
            });
        }
        // overide controll label dengan menambahkan class col-md-2 control-label
        public static IHtmlString BootstrapLabel(this HtmlHelper helper,
            string propertyName)
        {
            return helper.Label(propertyName, new
            {
                @class = "col-md-2 control-label"
            });
        }
        #endregion

        #region Html Checkbox
        //public static MvcHtmlString CheckBoxFor<T>(this HtmlHelper<T> htmlHelper, Expression<Func<T, bool?>> expression, IDictionary<string, object> htmlAttributes)
        //{

        //    ModelMetadata modelMeta = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        //    bool? value = (modelMeta.Model as bool?);

        //    string name = ExpressionHelper.GetExpressionText(expression);

        //    return htmlHelper.CheckBox(name, value ?? false, htmlAttributes);
        //}
        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool?>> expression)
        {
            return htmlHelper.CheckBoxFor<TModel>(expression, null);
        }
        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool?>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            bool? isChecked = null;
            if (metadata.Model != null)
            {
                bool modelChecked;
                if (Boolean.TryParse(metadata.Model.ToString(), out modelChecked))
                {
                    isChecked = modelChecked;
                }
            }
            return htmlHelper.CheckBox(ExpressionHelper.GetExpressionText(expression), isChecked ?? false, htmlAttributes);
        }
        #endregion

        //   public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
        //Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        //where TModel : class
        //   {
        //       TProperty value = htmlHelper.ViewData.Model == null
        //           ? default(TProperty)
        //           : expression.Compile()(htmlHelper.ViewData.Model);
        //       string selected = value == null ? String.Empty : value.ToString();
        //       return htmlHelper.DropDownListFor(expression, createSelectList(expression.ReturnType, selected), null, htmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        //   }


        //public static MvcHtmlString Dropdown(string id, List<SelectListItem> selectListItems, string label)
        //{
        //    var button = new TagBuilder("button")
        //    {
        //        Attributes =
        //    {
        //        {"id", id},
        //        {"type", "button"},
        //        {"data-toggle", "dropdown"}
        //    }
        //    };

        //    button.AddCssClass("btn");
        //    button.AddCssClass("btn-default");
        //    button.AddCssClass("dropdown-toggle");

        //    button.SetInnerText(label);
        //    button.InnerHtml += " " + BuildCaret();

        //    var wrapper = new TagBuilder("div");
        //    wrapper.AddCssClass("dropdown");

        //    wrapper.InnerHtml += button;
        //    wrapper.InnerHtml += BuildDropdown(id, selectListItems);

        //    return new MvcHtmlString(wrapper.ToString());
        //}

        //private static string BuildCaret()
        //{
        //    var caret = new TagBuilder("span");
        //    caret.AddCssClass("caret");

        //    return caret.ToString();
        //}

        //private static string BuildDropdown(string id, IEnumerable<SelectListItem> items)
        //{
        //    var list = new TagBuilder("ul")
        //    {
        //        Attributes =
        //    {
        //        {"class", "dropdown-menu"},
        //        {"role", "menu"},
        //        {"aria-labelledby", id}
        //    }
        //    };

        //    var listItem = new TagBuilder("li");
        //    listItem.Attributes.Add("role", "presentation");

        //    items.ForEach(x => list.InnerHtml += "<li role=\"presentation\">" + BuildListRow(x) + "</li>");

        //    return list.ToString();
        //}

        //private static string BuildListRow(SelectListItem item)
        //{
        //    var anchor = new TagBuilder("a")
        //    {
        //        Attributes =
        //    {
        //        {"role", "menuitem"},
        //        {"tabindex", "-1"},
        //        {"href", item.Value}
        //    }
        //    };

        //    anchor.SetInnerText(item.Text);

        //    return anchor.ToString();
        //}


    }

}