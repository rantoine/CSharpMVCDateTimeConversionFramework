﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using CustomModelBindingWithDateTime.Enumerations;

namespace CustomModelBindingWithDateTime.Helpers 
{
    public static class UiTimeHelper
    {
        private static readonly Dictionary<UiTimeClientValidationModes, Dictionary<string, string>> _uiTimeValidationModes = new Dictionary<UiTimeClientValidationModes, Dictionary<string, string>>();

        static UiTimeHelper()
        {
            //Define Ui Client Validation for Time
            UiTimeValidationModes();
        }

        public static MvcHtmlString UiTimeBox(this HtmlHelper htmlHelper, string name, string value) 
        {
            var builder = new TagBuilder("input");
            builder.Attributes["type"] = "text";
            builder.Attributes["name"] = name;
            builder.Attributes["value"] = value;
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString UiTimeBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) 
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var markup = UiTimeBox(htmlHelper, name, metadata.Model as string);

            return markup;
        }

        public static MvcHtmlString UiTimeBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes) 
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            MvcHtmlString html = default(MvcHtmlString);
            html = System.Web.Mvc.Html.InputExtensions.TextBoxFor(htmlHelper, expression, attributes);

            return html;
        }

        public static MvcHtmlString UiTimeBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes, UiTimeClientValidationModes[] validators)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);

            if (validators != null)
            {
                foreach (var validator in validators)
                {
                    var dataAnnotations = _uiTimeValidationModes[validator];
                    foreach (var dataAnnotation in dataAnnotations)
                    {
                        attributes.Add(dataAnnotation.Key, dataAnnotation.Value); 
                    }
                }
            }

            MvcHtmlString html = default(MvcHtmlString);
            html = System.Web.Mvc.Html.InputExtensions.TextBoxFor(htmlHelper, expression, attributes);

            return html;
        }

        public static void UiTimeValidationModes() 
        {

            _uiTimeValidationModes.Add(UiTimeClientValidationModes.TimeRequired, new Dictionary<string, string>{
                                                                                                                {"data-val-required", "Time is required"},
                                                                                                            });
            _uiTimeValidationModes.Add(UiTimeClientValidationModes.TimeValidation, new Dictionary<string, string>{
                                                                                                                {"data-val-time", "Date is improperly formated: MM/DD/YYYY."},
                                                                                                            });
            _uiTimeValidationModes.Add(UiTimeClientValidationModes.TimeGreaterThanAttributeValidation, new Dictionary<string, string>{
                                                                                                                {"data-val-timenotinpast", "Time cannot be in the future"},
                                                                                                            });
            _uiTimeValidationModes.Add(UiTimeClientValidationModes.TimeGreaterThanEqualAttributeValidation, new Dictionary<string, string>{
                                                                                                                {"data-val-timenotinfuture", "Time must be greater than or equal to:"},
                                                                                                            });
        }

    }
}
