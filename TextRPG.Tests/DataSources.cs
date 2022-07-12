using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Tests
{
    public class RegSuccessDataAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "Asad", "Dallah"};
            yield return new object[] { "Das", "Dallah"};
            yield return new object[] { "Ben", "Dallah"};
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class RegFailDataAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "Asad", ""};
            yield return new object[] { "", "Dallah"};
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class AuthSuccessDataAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "Asad", "Dallah", new User("Asad", "Dallah", null) };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class AuthFailExpectedDataAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "Asad", "Dall", new User("Asad", "Dallah", null) };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class AuthExceptionDataAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "Asad", "", new User("Asad", "Dallah", null) };
            yield return new object[] { "", "Dallah", new User("Asad", "Dallah", null) };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class SelectCharacterData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { new Character ("Template", true) };
            yield return new object[] { new Character("TemplateGirl", false) };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class CreateSuccessData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "Template", "1", 1 };
            yield return new object[] { "Template", "0", 1 };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class CreateFailData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "Template", "2" };
            yield return new object[] { "Template", "3" };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class AttackData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { new Character("Template", true), new Character("TemplateForDeath", true), 9 };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class DuelData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { new Character("Template", true), new Character("TemplateForDeath", true), 10, 1 };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class ResponseOKData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "inn", "7708503727" };
            yield return new object[] { "inn", "7736050003" };
            yield return new object[] { "inn", "7452027843" };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class ResponseResultsData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "inn", "7708503727", "РЖД" };
            yield return new object[] { "inn", "7736050003", "ГАЗПРОМ" };
            yield return new object[] { "inn", "7452027843", "ЧТЗ-УРАЛТРАК" };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class GenderizeOkData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "peter" };
            yield return new object[] { "nikita" };
            yield return new object[] { "michael" };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
    public class GenderizeResultsData : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { "peter", "male" };
            yield return new object[] { "john", "male" };
            yield return new object[] { "michael" , "male" };
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }

}
