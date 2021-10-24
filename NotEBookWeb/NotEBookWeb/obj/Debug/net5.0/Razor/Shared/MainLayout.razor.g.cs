#pragma checksum "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f039bae4eb04efccad768a524ba2df19a49fc0de"
// <auto-generated/>
#pragma warning disable 1591
namespace NotEBookWeb.Shared
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
#line 8 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.JSInterop;

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
#line 1 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Shared\MainLayout.razor"
using NotEBookWeb.Data;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-eumjqe51rn");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-eumjqe51rn");
            __builder.OpenComponent<NotEBookWeb.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-eumjqe51rn");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "top-row px-4");
            __builder.AddAttribute(13, "b-eumjqe51rn");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "col-1");
            __builder.AddAttribute(16, "b-eumjqe51rn");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(17);
            __builder.AddAttribute(18, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(19, "a");
                __builder2.AddAttribute(20, "class", "login-header");
                __builder2.AddAttribute(21, "href", "/login");
                __builder2.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Shared\MainLayout.razor"
                                                                        ()=>Logout()

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "b-eumjqe51rn");
                __builder2.AddContent(24, "Logout");
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(25, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(26, "<a class=\"login-header\" href=\"/login\" b-eumjqe51rn>Login</a>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n            ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "b-eumjqe51rn");
            __builder.OpenComponent<NotEBookWeb.Controls.DateComponent>(30);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n\r\n\r\n        ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "content px-4");
            __builder.AddAttribute(34, "b-eumjqe51rn");
            __builder.AddContent(35, 
#nullable restore
#line 30 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 35 "D:\.NET Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Shared\MainLayout.razor"
      
    public void Logout()
    {
        ((CustomAuthenticationStateProvider)AuthenticationStateProvider).FlagUserAsLoggedOut();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
