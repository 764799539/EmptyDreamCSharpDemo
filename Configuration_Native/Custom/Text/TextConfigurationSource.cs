using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration_Native.Custom.Text
{
    /// <summary>
    /// 
    /// </summary>
    public class TextConfigurationSource : IConfigurationSource
    {
        public TextConfigurationSource(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new TextConfigurationProvider(this);
        }
    }
}
