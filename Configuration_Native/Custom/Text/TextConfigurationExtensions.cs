using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration_Native.Custom.Text
{
    /// <summary>
    /// 文本文件拓展类
    /// </summary>
    public static class TextConfigurationExtensions
    {
        public static IConfigurationBuilder AddText(this IConfigurationBuilder ConfigurationBuilder, string FilePath)
        {
            TextConfigurationSource CustomSource = new(FilePath);
            return ConfigurationBuilder.Add(CustomSource);
        }
    }
}
