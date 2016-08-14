using Sitecore.Diagnostics;
using Sitecore.Configuration;
using ExCSS;
using System;
using System.Text;
using System.Web.Optimization;

namespace Sitecore.Feature.Fxm.Bundle
{
    public class PrependCssSelectorTransform : IBundleTransform
    {
        private string _selector;

        public void Process(BundleContext context, BundleResponse response)
        {
            _selector = Settings.GetSetting("Bundle.PrependCssSelectorProcessor.Selector");

            try
            {
                StyleSheet styleSheet = new Parser().Parse(response.Content);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (RuleSet sheetRule in styleSheet.Rules)
                {
                    try
                    {
                        stringBuilder.AppendLine(this.FormatRuleSet(sheetRule));
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Exception occured", ex, (object)this);
                    }
                }
                response.Content = stringBuilder.ToString();
                response.ContentType = "text/css";
            }
            catch (Exception ex)
            {
                Log.Error("Exception occured in FxmTransform method", ex, this);
                throw;
            }
        }

        private string FormatRuleSet(RuleSet sheetRule)
        {
            string str1 = string.Empty;
            if (!(sheetRule is AggregateRule))
                return this.FormatRule(sheetRule);

            foreach (RuleSet rule in (sheetRule as AggregateRule).RuleSets)
            {
                string str2 = this.FormatRule(rule);
                if (str1 != string.Empty)
                    str1 += Environment.NewLine;
                str1 += str2;
            }

            if (!(sheetRule is MediaRule))
                return str1;

            return "@media " + (sheetRule as MediaRule).Media.MediaType + "{" + Environment.NewLine + str1 + Environment.NewLine + "}";
        }

        private string FormatRule(RuleSet rule)
        {
            string str2;
            if (rule is StyleRule)
            {
                StyleRule styleRule = rule as StyleRule;
                str2 = this.ModifySelector(styleRule.Selector.ToString()) + " {" + Environment.NewLine + this.FormatDeclarations(styleRule.Declarations.ToString()) + "}";
            }
            else
                str2 = rule.ToString();

            return str2;
        }

        private string FormatDeclarations(string declarations)
        {
            string str1 = string.Empty;
            string str2 = declarations.Trim();
            foreach (string str3 in str2.Split(';'))
            {
                if (!string.IsNullOrEmpty(str3.Trim()))
                    str1 = str1 + str3 + ";" + Environment.NewLine;
            }
            return str1;
        }

        private string ModifySelector(string selector)
        {
            string[] strArray = selector.Split(',');
            StringBuilder stringBuilder = new StringBuilder();
            int index = 0;
            while (index < strArray.Length)
            {
                string item = strArray[index];

                if (!item.Trim().Equals(_selector, StringComparison.InvariantCultureIgnoreCase))
                {
                    stringBuilder.Append(_selector + " " + item);
                    if (index < checked(strArray.Length - 1))
                        stringBuilder.Append("," + Environment.NewLine);
                }
                else
                {
                    stringBuilder.Append(item);
                    if (index < checked(strArray.Length - 1))
                        stringBuilder.Append("," + Environment.NewLine);
                }

                checked { ++index; }
            }
            return stringBuilder.ToString();
        }
    }
}
