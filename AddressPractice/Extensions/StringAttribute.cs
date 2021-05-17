using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressPractice.Models
{
    public class StringAttribute : ValidationAttribute, IClientValidatable
    {
        private int length;

        // IEnumerable<ModelClientValidationRule> 検証情報のリスト
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // 検証ルールを準備
            var rule = new ModelClientValidationRule
            {
                // 検証名
                ValidationType = "string",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            // 検証パラメーター
            rule.ValidationParameters["length"] = length;
            yield return rule;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                length = Encoding.GetEncoding("Shift_JIS").GetByteCount(value.ToString());
                if (length <= 10)
                {
                    return true;
                }
                //return Regex.IsMatch(value.ToString(), @"^(\d{4})/(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])$");
            }
            return false;
        }
    }
}