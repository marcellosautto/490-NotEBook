#pragma checksum "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b881301b5608e176d72d1295030995a50df7d48"
// <auto-generated/>
#pragma warning disable 1591
namespace NotEBookWeb.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Blazor.Extensions.Canvas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Blazored.SessionStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
using NotEBookWeb.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
using System.Data.SqlClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
using System.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(CenteredCardLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/register")]
    public partial class UserSignUp : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 11 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
                  user

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 11 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
                                        ValidateUser

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(4, "div");
                __builder2.AddAttribute(5, "id", "username-div");
                __builder2.AddMarkupContent(6, "<h3>Email</h3>\r\n        ");
                __builder2.OpenElement(7, "input");
                __builder2.AddAttribute(8, "type", "text");
                __builder2.AddAttribute(9, "placeholder", "Email");
                __builder2.AddAttribute(10, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 15 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
                                                      user.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(11, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => user.Email = __value, user.Email));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(12, "\r\n\r\n    ");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "id", "password-div");
                __builder2.AddMarkupContent(15, "<h3>Password</h3>\r\n        ");
                __builder2.OpenElement(16, "input");
                __builder2.AddAttribute(17, "type", "password");
                __builder2.AddAttribute(18, "placeholder", "Password");
                __builder2.AddAttribute(19, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 20 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
                                                             user.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => user.Password = __value, user.Password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(21, "\r\n\r\n    ");
                __builder2.OpenElement(22, "div");
                __builder2.AddAttribute(23, "id", "password-div");
                __builder2.AddMarkupContent(24, "<h3>Confirm Password</h3>\r\n        ");
                __builder2.OpenElement(25, "input");
                __builder2.AddAttribute(26, "type", "password");
                __builder2.AddAttribute(27, "placeholder", "Confirm Password");
                __builder2.AddAttribute(28, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 25 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
                                                                     confirmPassword

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(29, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => confirmPassword = __value, confirmPassword));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n\r\n    <input type=\"submit\" class=\"btn-primary rounded\" value=\"Login\">\r\n    <input type=\"submit\" class=\"btn-primary rounded\" value=\"Register\">");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "E:\.NET_Projects\490-NotEBook\NotEBookWeb\NotEBookWeb\Pages\UserSignUp.razor"
       

    private User user;
    private string confirmPassword;
    protected override Task OnInitializedAsync()
    {
        user = new User();
        return base.OnInitializedAsync();
    }

    private async Task<bool> ValidateUser()
    {
        //Temporary until we figure out how to load SQL connection string from appsettings, key vault or secrets
        SqlConnection sqlConnection = new SqlConnection("Server=tcp:notebookwebdbserver.database.windows.net,1433;Initial Catalog=NotEBookWeb_db;Persist Security Info=False;User ID=NotEBookDBAdmin;Password=CSUNSWETeam490;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        try
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            String query = "INSERT INTO Users (Username, Email, Password) VALUES (user.Username, user.Email, user.Password)";
            SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@Email", user.Email);
            sqlCmd.Parameters.AddWithValue("@Password", user.Password);
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            if (count == 1)
            {
                ((CustomAuthenticationStateProvider)AuthenticationStateProvider).FlagUserAsAuthenticated(user.Email); //mark user as authenticated when they log in
                NavigationManager.NavigateTo("/");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        await sessionStorage.SetItemAsync("Username", user.Username);
        return await Task.FromResult(true);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
