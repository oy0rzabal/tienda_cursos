using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region ensamblado Persistencia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\j0rge\Desktop\Proyecto_core\ProyectoCore\ProyectoCore\Persistencia\bin\Debug\netcoreapp3.1\Persistencia.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System.Collections.Generic;

namespace Persistencia.DapperConexion.Paginacion
{
    public class PaginacionModel
    {
        public List<IDictionary<string, object>> ListaRecords { get; set; }

        public int TotalRecords { get; set; }

        public int NumeroPaginas { get; set; }
    }
}
#if false // Registro de descompilación
"304" elementos en caché
------------------
Resolver: "System.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Runtime.dll"
------------------
Resolver: "System.Diagnostics.Debug, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Diagnostics.Debug, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Diagnostics.Debug.dll"
------------------
Resolver: "Microsoft.AspNetCore.Identity.EntityFrameworkCore, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.AspNetCore.Identity.EntityFrameworkCore, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.aspnetcore.identity.entityframeworkcore\3.1.1\lib\netcoreapp3.1\Microsoft.AspNetCore.Identity.EntityFrameworkCore.dll"
------------------
Resolver: "Dominio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
Se encontró un solo ensamblado: "Dominio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
Cargar desde: "C:\Users\j0rge\Desktop\Proyecto_core\ProyectoCore\ProyectoCore\Dominio\bin\Debug\netcoreapp3.1\Dominio.dll"
------------------
Resolver: "Microsoft.EntityFrameworkCore, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.EntityFrameworkCore, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.entityframeworkcore\3.1.1\lib\netstandard2.0\Microsoft.EntityFrameworkCore.dll"
------------------
Resolver: "System.Linq.Expressions, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Linq.Expressions, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Linq.Expressions.dll"
------------------
Resolver: "Microsoft.Extensions.Identity.Core, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Identity.Core, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.extensions.identity.core\3.1.1\lib\netcoreapp3.1\Microsoft.Extensions.Identity.Core.dll"
------------------
Resolver: "System.Threading.Tasks, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Threading.Tasks, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Threading.Tasks.dll"
------------------
Resolver: "Microsoft.EntityFrameworkCore.Relational, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.EntityFrameworkCore.Relational, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.entityframeworkcore.relational\3.1.1\lib\netstandard2.0\Microsoft.EntityFrameworkCore.Relational.dll"
------------------
Resolver: "System.Data.Common, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Data.Common, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Data.Common.dll"
------------------
Resolver: "Microsoft.Extensions.Options, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Options, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.extensions.options\3.1.1\lib\netcoreapp3.1\Microsoft.Extensions.Options.dll"
------------------
Resolver: "System.Collections, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Collections, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Collections.dll"
------------------
Resolver: "Dapper, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null"
Se encontró un solo ensamblado: "Dapper, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null"
Cargar desde: "C:\Users\j0rge\.nuget\packages\dapper\2.0.4\lib\netstandard2.0\Dapper.dll"
------------------
Resolver: "Microsoft.Extensions.Identity.Stores, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.Extensions.Identity.Stores, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.extensions.identity.stores\3.1.1\lib\netcoreapp3.1\Microsoft.Extensions.Identity.Stores.dll"
------------------
Resolver: "Microsoft.EntityFrameworkCore.SqlServer, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Se encontró un solo ensamblado: "Microsoft.EntityFrameworkCore.SqlServer, Version=3.1.1.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.entityframeworkcore.sqlserver\3.1.1\lib\netstandard2.0\Microsoft.EntityFrameworkCore.SqlServer.dll"
------------------
Resolver: "Microsoft.Data.SqlClient, Version=1.0.19269.1, Culture=neutral, PublicKeyToken=23ec7fc2d6eaa4a5"
Se encontró un solo ensamblado: "Microsoft.Data.SqlClient, Version=1.0.19269.1, Culture=neutral, PublicKeyToken=23ec7fc2d6eaa4a5"
Cargar desde: "C:\Users\j0rge\.nuget\packages\microsoft.data.sqlclient\1.0.19269.1\ref\netcoreapp2.1\Microsoft.Data.SqlClient.dll"
------------------
Resolver: "System.Linq.Queryable, Version=4.0.4.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Linq.Queryable, Version=4.0.4.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Linq.Queryable.dll"
------------------
Resolver: "Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\Microsoft.CSharp.dll"
------------------
Resolver: "System.Linq, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Se encontró un solo ensamblado: "System.Linq, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Cargar desde: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1\System.Linq.dll"
#endif
