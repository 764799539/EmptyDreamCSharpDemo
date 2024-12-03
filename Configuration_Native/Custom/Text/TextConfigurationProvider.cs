using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration_Native.Custom.Text
{
    /// <summary>
    /// 文本文件提供者：读取配置文件
    /// </summary>
    public class TextConfigurationProvider : ConfigurationProvider
    {
        public TextConfigurationProvider(TextConfigurationSource textConfigurationSource)
        {
            Source = textConfigurationSource;
        }

        public TextConfigurationSource Source { get; set; }


        public override void Load()
        {
            var ConfigurationDictionary = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);

            if (!File.Exists(Source.FilePath))
            {
                throw new Exception($"Configuation 文件 {Source.FilePath} 不存在");
            }

            var Lines = File.ReadAllLines(Source.FilePath);
            foreach (var Line in Lines)
            {
                var KeyValuePair = Line.Split('=');

                if (KeyValuePair.Length == 2)
                {
                    ConfigurationDictionary.Add(KeyValuePair[0].Trim(), KeyValuePair[1].Trim());
                }
                else if (KeyValuePair.Length == 1)
                {
                    ConfigurationDictionary.Add(KeyValuePair[0].Trim(), null);
                }
            }

            Data = ConfigurationDictionary;
        }
    }
}
