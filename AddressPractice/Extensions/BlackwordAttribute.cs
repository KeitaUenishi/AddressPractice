using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace AddressPractice.Extensions
{
    public class BlackwordAttribute : ValidationAttribute, IClientValidatable
    {
        // 禁止ワードを示すプライベート変数
        private string _opts;

        // コンストラクタ
        public BlackwordAttribute(string opts)
        {
            this._opts = opts;
            this.ErrorMessage = "{0}には{1}を含むことはできません。";
        }

        // プロパティの表示名と値リストでエラーメッセージを整形
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
                                 ErrorMessageString, name, this._opts);
        }

        // 検証の実処理（入力値に禁止ワードが含まれていないかチェック）
        public override bool IsValid(object value)
        {
            if (value == null) { return true; }

            string[] list = this._opts.Split(',');
            foreach (var data in list)
            {
                if (((string)value).Contains(data))
                {
                    return false;
                }
            }
            return true;
        }

        // クライアントに送信する検証情報の生成
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                // 検証名
                ValidationType = "blackword",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            // 検証パラメーター
            rule.ValidationParameters["opts"] = _opts;
            yield return rule;
        }
    }
}