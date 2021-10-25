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
#line 1 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Blazor.Extensions.Canvas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Blazored.SessionStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\Calculator.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/calculator")]
    public partial class Calculator : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\Calculator.razor"
       
    private string answer, op;
    private int State;
    private float num1, num2;
    private ElementReference btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, dec;
    private ElementReference add, subtract, multiply, divide, exponent, clear, enter;
    private BindElementAttribute d;

    private Dictionary<ElementReference, string> numberButtons;
    private Dictionary<ElementReference, string> operationButtons;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        answer = "0";
        State = 0;

    }

    /*Initialize dictionaries for numbers and operations*/
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);


        numberButtons = new Dictionary<ElementReference, string>() {

            { btn1, "1" },
            { btn2, "2" },
            { btn3, "3" },
            { btn4, "4" },
            { btn5, "5" },
            { btn6, "6" },
            { btn7, "7" },
            { btn8, "8" },
            { btn9, "9" },
            { btn0, "0" },
            { dec, "." }
        };

        operationButtons = new Dictionary<ElementReference, string>() {

                { add, "+"},
                { subtract, "-"},
                { multiply, "*"},
                { divide, "/"},
                {exponent, "^" },
                {enter, "e" }
        };

    }

    /*State manager for number inputs*/
    private async void inputNum(ElementReference element)
    {
        //first input
        if (State == 0)
        {
            answer = numberButtons[element];
            State = 1;
        }

        //add to first input
        else if (State == 1)
        {
            answer += numberButtons[element];
            State = 1;
        }

        //all input strings following first input
        else if (State == 2)
        {
            answer = numberButtons[element];
            State = 3;
        }

        //add to all input strings following first input
        else if (State == 3)
        {
            answer += numberButtons[element];
            State = 3;
        }


        //await JSRuntime.InvokeVoidAsync("setElementText", element);

    }

    /*State manager for operation inputs*/
    private async void inputOperation(ElementReference element)
    {
        //store operand and save current input in num1
        if (State == 1 || op == "e")
        {
            num1 = float.Parse(answer);
            op = operationButtons[element];
            State = 2;
        }

        //perform operations
        if (State == 3)
        {

            num2 = float.Parse(answer);

            if (op == "+")
                answer = Convert.ToString(num1 + num2);

            else if (op == "-")
                answer = Convert.ToString(num1 - num2);

            else if (op == "*")
                answer = Convert.ToString(num1 * num2);

            else if (op == "/")
                answer = Convert.ToString(num1 / num2);

            else if (op == "^")
                answer = Convert.ToString(Math.Pow(num1, num2));


            op = operationButtons[element];
            num1 = float.Parse(answer);
            State = 2;

        }


    }

    private void clearCalculator()
    {
        answer = "0";
        num1 = num2 = 0;
        op = "";
        State = 0;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591