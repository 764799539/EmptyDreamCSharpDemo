﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_NativeDependencyInjection.Inject.Repository
{
    public class Repository : IRepository
    {
        /// <summary>
        /// 列表查询
        /// </summary>
        /// <returns></returns>
        public string ToList() => "Repository列表";
    }
}