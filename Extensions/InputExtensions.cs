using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Transfer.City.Extensions
{
    public static class InputExtensions
    {
        public static HtmlString InputForString<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, out string script)
        {
            int? maxLength = null;
            string desc = "";
            bool isrequired = false;

            string expModel = "";
            if (expression.Parameters.Count > 0)
                expModel = expression.Parameters[0].Name;

            var valObject = ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model;
            string textvalue = "";
            if (valObject != null)
                textvalue = valObject.ToString();
            textvalue = textvalue.Replace("\"", "\\\"");

            string propertyname = expression.Body.ToString().Substring(expModel.Length + 1);
            PropertyInfo property = html.ViewData.Model.GetType().GetProperties().Where(a => a.Name.Equals(propertyname)).First();
            List<object> attributes = property.GetCustomAttributes(true).ToList();
            foreach (object attribute in attributes)
            {
                if (attribute is MaxLengthAttribute maxLengthAttr)
                    maxLength = maxLengthAttr.Length;
                else
                {
                    if (attribute is DescriptionSiteTextAttribute descAttr)
                        desc = descAttr.Description;
                    else
                    {
                        if (attribute is RequiredAttribute reqAttr)
                        {
                            isrequired = true;
                        }
                    }
                }
            }
            string displaytext = DisplayNameExtensions.DisplayNameFor(html, expression).ToString();
            string mylabel = "<label class=\"";
            if (isrequired)
                mylabel += "required ";
            mylabel += "fs-6 fw-bold mb-2\">";
            mylabel += displaytext;
            mylabel += "</label>";

            string input = "<input type=\"text\" class=\"form-control form-control-solid ";
            input += propertyname;
            input += "\" placeholder=\"";
            input += displaytext;
            input += "\" id=\"";
            input += propertyname;
            input += "\" name=\"";
            input += propertyname;
            input += "\" ";
            if (maxLength != null)
            {
                input += "maxlength=\"" + maxLength.ToString() + "\" ";
            }
            if (isrequired)
            {
                input += "required=\"required\" ";
            }
            input += " /><span class=\"form-text text-muted\">" + desc + "</span>";
            //string validationtext = ValidationExtensions.ValidationMessageFor(html, expression).ToString();
            //string input = "<input id=\"" + propertyname + "\" name=\"" + propertyname + "\" type=\"text\" class=\"form-control\" placeholder=\"" + displaytext + "\" value=\"" + textvalue + "\" ";
            //input += "/>";
            //if (inputGroup && !string.IsNullOrEmpty(inputIcon))
            //{
            //    input = "<div class=\"input-group input-group-lg input-group-solid\"><div class=\"input-group-prepend\"><span class=\"input-group-text\"><i class=\"" + inputIcon + "\"></i></span></div>" + input;
            //    input += "</div>";
            //}
            //input += "<span class=\"form-text text-muted\">" + desc + "</span>" + validationtext;
            //string result = "";
            //if (singlerow)
            //{
            //    if (label)
            //    {
            //        result = "<div class=\"form-group row\"><label class=\"col-form-label col-lg-3 col-sm-12\">" + displaytext;
            //        if (isrequired)
            //            result += "<span class=\"text-danger\">*</span>";
            //        result += "</label><div class=\"col-9\">" + input + "</div></div>";
            //    }
            //    else
            //    {
            //        result = "<div class=\"form-group row\"><div class=\"col-12\">" + input + "</div></div>";
            //    }
            //}
            //else
            //{
            //    if (label)
            //    {
            //        result = "<div class=\"form-group\"><label>" + displaytext;
            //        if (isrequired)
            //            result += "<span class=\"text-danger\">*</span>";
            //        result += "</label>" + input + "</div>";
            //    }
            //    else
            //    {
            //        result = "<div class=\"form-group\">" + input + "</div>";
            //    }
            //}
            script = "";
            if (maxLength != null)
            {
                script = "var KTBootstrapMaxlength" + propertyname + " = function () {var demos = function () {$('#" + propertyname + "').maxlength({warningClass: \"label label-warning label-rounded label-inline\",limitReachedClass: \"label label-success label-rounded label-inline\"});return {init: function() {demos();}};}();";
                script += "jQuery(document).ready(function() { KTBootstrapMaxlength" + propertyname + ".init();});";
            }
            return new HtmlString(mylabel + input);
        }
    }
}