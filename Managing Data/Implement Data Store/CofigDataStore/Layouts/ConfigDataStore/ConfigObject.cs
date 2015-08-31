using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using Microsoft.SharePoint.Administration;

namespace CofigDataStore.Layouts.ConfigDataStore
{
    [Guid("78C30092-159F-42FE-AD63-2CEEA1BCBEEA")]
    class ConfigObject : SPPersistedObject
    {

            [Persisted]
            public string connString;

            public ConfigObject()
            { }

            public ConfigObject(string name, SPPersistedObject parent) : base(name, parent)
            { }
        
    }
}
