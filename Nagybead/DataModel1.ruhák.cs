﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2022. 04. 28. 19:22:40
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace beadando
{
    public partial class ruhák {

        public ruhák()
        {
            OnCreated();
        }

        public virtual string ruha { get; set; }

        public virtual int jelleg { get; set; }

        public virtual tipus tipus { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
