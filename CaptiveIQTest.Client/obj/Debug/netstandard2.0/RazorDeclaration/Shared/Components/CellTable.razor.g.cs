#pragma checksum "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\Shared\Components\CellTable.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db3918284112591b44908f2b63abf295f23027d7"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CaptiveIQTest.Client.Shared.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 5 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\_Imports.razor"
using CaptiveIQTest.Client;

#line default
#line hidden
#line 6 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\_Imports.razor"
using CaptiveIQTest.Client.Shared;

#line default
#line hidden
#line 1 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\Shared\Components\CellTable.razor"
using CaptiveIQTest.SharedObjs;

#line default
#line hidden
    public class CellTable : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 30 "C:\Users\aearl\source\repos\CaptiveIQTest\CaptiveIQChallenge\CaptiveIQTest.Client\Shared\Components\CellTable.razor"
        
    public List<ColumnData> Columns => this.StateData.User.Columns;

    protected override async Task OnInitializedAsync()
    {
        Console.WriteLine($"Column count: {this.Columns.Count}");
        Console.WriteLine($"First column row count: {this.Columns.Max(x => x.CellDatas.Count)}");
    }


#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DataState StateData { get; set; }
    }
}
#pragma warning restore 1591
