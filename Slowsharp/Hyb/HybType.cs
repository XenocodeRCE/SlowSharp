﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Slowsharp
{
    internal class HybType
    {
        public bool isCompiledType => compiledType != null;

        public Type compiledType { get; }
        public Class interpretKlass { get; }

        public HybType(Type type)
        {
            this.compiledType = type;
        }
        public HybType(Class klass)
        {
            this.interpretKlass = klass;
        }

        public HybInstance CreateInstance(object[] args)
        {
            if (isCompiledType)
            {
                return new HybInstance(
                    this,
                    Activator.CreateInstance(compiledType, args));
            }
            else
            {
                var inst = new HybInstance(this, interpretKlass);
                inst.GetMethods("$_ctor")[0].Invoke(inst, args);
                return inst;
            }
        }

        public Invokable[] GetMethods(string id)
        {
            if (isCompiledType)
            {
                return compiledType.GetMethods()
                   .Where(x => x.Name == id)
                   .Select(x => new Invokable(x))
                   .ToArray();
            }
            else
            {
                return interpretKlass.GetMethods(id);
            }
        }
    }
}
