// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace NotEBookWeb.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\Counter.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "E:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\Counter.razor"
       
    private int answer = 0;
    private ElementReference btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, dec;
    private ElementReference plus, minus, add, subtract, clear, enter;

    private List<ElementReference> numberButtons;
    private List<ElementReference> operationButtons;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        numberButtons = new List<ElementReference>()
{
            btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, dec
        };

        operationButtons = new List<ElementReference>()
{
            plus, minus, add, subtract, clear, enter
        };
    }

    [Parameter]
    public int IncrementAmount { get; set; } = 1;

    private void IncrementCount()
    {
        answer += IncrementAmount;
    }

    private async void inputNum(ElementReference element)
    {
        //Console.Write(element.GetType());
        answer = Convert.ToInt32(element);
        await JSRuntime.InvokeVoidAsync("setElementText", element);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
