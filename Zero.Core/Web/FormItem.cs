using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Zero.Core.Web
{
    public partial class FormItem<T>
    {
        public enum ItemType
        {
            Form,
            Query,
            All,
            Cookie,
        }

        private string _name;
        private string _cnName;
        private int _minLenght;
        private int _maxLenght;
        private T _defaultValue;
        private bool _haveDefaultValue = false;
        private ValidateType _validateType = ValidateType.Undefine;
        private int _errorMsg;


        public FormItem(string name, string cnName, int min, int max)
        {
            this._name = name;
            this._cnName = cnName;
            this._minLenght = min;
            this._maxLenght = max;
        }

        public FormItem(string name, string cnName, int min, int max, T defaultValue)
        {
            this._name = name;
            this._cnName = cnName;
            this._minLenght = min;
            this._maxLenght = max;
            this._defaultValue = defaultValue;
            this._haveDefaultValue = true;
        }

        public FormItem(string name, string cnName, int min, int max, ValidateType validateType)
        {
            this._name = name;
            this._cnName = cnName;
            this._minLenght = min;
            this._maxLenght = max;
            this._validateType = validateType;
        }

        public FormItem(string name, string cnName, int min, int max, T defaultValue, ValidateType validateType)
        {
            this._name = name;
            this._cnName = cnName;
            this._minLenght = min;
            this._maxLenght = max;
            this._defaultValue = defaultValue;
            this._validateType = validateType;
            this._haveDefaultValue = true;
        }

        public T GetQueryValue(StringBuilder sb)
        {
            T s = GetValue(ItemType.Query);
            sb.Append(GetErrorMsg());
            return s;
        }

        public T GetFormValue(StringBuilder sb)
        {
            T s = GetValue(ItemType.Form);
            sb.Append(GetErrorMsg());
            return s;
        }

        public T GetAllValue(StringBuilder sb)
        {
            T s = GetValue(ItemType.All);
            sb.Append(GetErrorMsg());
            return s;
        }

        public T GetCookieValue(StringBuilder sb)
        {
            T s = GetValue(ItemType.Cookie);
            sb.Append(GetErrorMsg());
            return s;
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private string GetErrorMsg()
        {
            switch (_errorMsg)
            {
                case 1:
                    return string.Format("{0}不能放空，请填写!", _cnName);//All
                case 2:
                    return string.Format("{0}不能小于{1}字符或大于{2}字符,请重新填写！", _cnName, _minLenght, _maxLenght);//String
                case 3:
                    return string.Format("{0}填写的格式不正确,请重新填写！", _cnName);//String
                case 4:
                    return string.Format("{0}填写的格式不正确,请重新填写正确的整数！", _cnName);//Int
                case 5:
                    return string.Format("{0}不能小于{1}或大于{2}！", _cnName, _minLenght, _maxLenght);//Int
                case 6:
                    return string.Format("{0}填写的格式不正确,请重新填写正确的数字！", _cnName);//Decimal
                case 7:
                    return string.Format("{0}不能小于{0}或大于{1}！", _cnName, _minLenght, _maxLenght);//Decimal
                case 8:
                    return string.Format("{0}填写的格式不正确,请重新填写正确的布尔值！", _cnName);//Boolean
                case 9:
                    return string.Format("{0}填写的格式不正确,请重新填写正确的格式！", _cnName);//DateTime
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// string转化为T类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private T ObjectToT(string s)
        {
            TypeCode type = System.Type.GetTypeCode(typeof(T));

            switch (type)
            {
                case TypeCode.Int32:
                    return (T)(this.GetInt(s));

                case TypeCode.String:
                    return (T)(this.GetString(s));

                case TypeCode.Decimal:
                    return (T)(this.GetDecimal(s));

                case TypeCode.Boolean:
                    return (T)(this.GetBoolean(s));

                case TypeCode.DateTime:
                    return (T)(this.GetDateTime(s));
            }



            throw new FormException("No find data type");
        }

        /// <summary>
        /// 验证字段是否为空
        /// </summary>
        private T GetValue(ItemType type)
        {
            string s = RetriveValue(_name, type);

            if (string.IsNullOrEmpty(s))
            {
                if (_haveDefaultValue == false)
                {
                    _errorMsg = 1;
                    return default(T);
                }

                return _defaultValue;
            }

            return ObjectToT(s.Trim());
        }

        /// <summary>
        /// 转换为字符类型
        /// </summary>
        private object GetString(string s)
        {
            string result = s;

            if (result.Length < _minLenght || result.Length > _maxLenght)
            {
                _errorMsg = 2;
                return default(T);
            }

            if (_validateType != ValidateType.Undefine && !FormValidate.Validate(s, _validateType))
            {
                _errorMsg = 3;
                return default(T);
            }

            return result;
        }

        /// <summary>
        /// 转换为整数类型
        /// </summary>
        private object GetInt(string s)
        {
            int result = 0;

            if (!int.TryParse(s, out result))
            {
                _errorMsg = 4;
                return default(T);
            }

            if (result < _minLenght || result > _maxLenght)
            {
                _errorMsg = 5;
                return default(T);
            }

            return result;
        }

        /// <summary>
        /// 转化为Decimal小数格式
        /// </summary>
        private object GetDecimal(string s)
        {
            decimal result = 0;

            if (!decimal.TryParse(s, out result))
            {
                _errorMsg = 6;
                return default(T);
            }

            if (result < _minLenght || result > _maxLenght)
            {
                _errorMsg = 7;
                return default(T);
            }

            return result;
        }

        /// <summary>
        /// 转换bool类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private object GetBoolean(string s)
        {
            bool result = false;

            if (!Boolean.TryParse(s, out result))
            {
                _errorMsg = 8;
                return default(T);
            }

            return result;
        }

        /// <summary>
        /// 转换成DataTime
        /// </summary>
        private object GetDateTime(string s)
        {
            DateTime result = DateTime.MinValue;

            if (!DateTime.TryParse(s, out result))
            {
                _errorMsg = 9;
                return default(T);
            }

            return result;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        private string RetriveValue(string name, ItemType type)
        {
            HttpRequest request = HttpContext.Current.Request;

            switch (type)
            {
                case ItemType.Query:
                    return request.QueryString[_name];

                case ItemType.Form:
                    return request.Form[_name];

                case ItemType.All:
                    if (!string.IsNullOrEmpty(request.QueryString[_name])) return request.QueryString[_name].Trim();
                    return request.Form[_name];

                case ItemType.Cookie:
                    HttpCookie cookie = request.Cookies[_name];
                    if (cookie == null) return string.Empty;
                    return cookie.Value;
            }

            throw new FormException("No Find Controll");
        }
    }
}
