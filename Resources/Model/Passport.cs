﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Resources.Model
{
    internal class Passport
    {
        public long? id { get; set; }
        public string series { get; set; }
        public string number { get; set; }
        public string imageURL { get; set; }
        public Student student { get; set; }
    }
}
