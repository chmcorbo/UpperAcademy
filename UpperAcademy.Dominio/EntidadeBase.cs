﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio
{
    public class EntidadeBase
    {
        public virtual String ID { get; set; }

        public EntidadeBase()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
