#pragma checksum "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d3b428fd714ebbef29d49dcdfefe62d92d7dd2b"
// <auto-generated/>
#pragma warning disable 1591
namespace NotEBookWeb.Controls
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\_Imports.razor"
using NotEBookWeb.Models;

#line default
#line hidden
#nullable disable
    public partial class Calander : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, "ToDo: (");
#nullable restore
#line 1 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
__builder.AddContent(2, todos.Count(todo => !todo.IsDone));

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, ")");
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n\r\n\r\n");
            __builder.OpenElement(5, "label");
            __builder.AddMarkupContent(6, "\r\n    Task\r\n    ");
            __builder.OpenElement(7, "input");
            __builder.AddAttribute(8, "placeholder", "Insert New Task... ");
            __builder.AddAttribute(9, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 6 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                                    newTask

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => newTask = __value, newTask));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n\r\n");
            __builder.OpenElement(12, "label");
            __builder.AddMarkupContent(13, "\r\n    Date\r\n    ");
            __builder.OpenElement(14, "input");
            __builder.AddAttribute(15, "type", "date");
            __builder.AddAttribute(16, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 11 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                     newDate

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(17, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => newDate = __value, newDate, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n\r\n");
            __builder.OpenElement(19, "label");
            __builder.AddMarkupContent(20, "\r\n    Time\r\n    ");
            __builder.OpenElement(21, "input");
            __builder.AddAttribute(22, "type", "time");
            __builder.AddAttribute(23, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 16 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                     newTime

#line default
#line hidden
#nullable disable
            , format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(24, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => newTime = __value, newTime, format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n\r\n\r\n");
            __builder.OpenElement(26, "button");
            __builder.AddAttribute(27, "class", "btn btn-success");
            __builder.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                          AddTodo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(29, "Add Task");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n\r\n<br>\r\n\r\n");
            __builder.AddMarkupContent(31, "<h3>Calendar</h3>\r\n");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "calander");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", " month-year-header");
            __builder.OpenElement(36, "div");
            __builder.AddAttribute(37, "class", "month-header");
            __builder.OpenElement(38, "select");
            __builder.AddAttribute(39, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 29 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                selectMonth

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(40, "value", 
#nullable restore
#line 29 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                                     DateTime.Now.Month

#line default
#line hidden
#nullable disable
            );
            __builder.OpenElement(41, "option");
            __builder.AddAttribute(42, "value", "1");
            __builder.AddContent(43, "January");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n                ");
            __builder.OpenElement(45, "option");
            __builder.AddAttribute(46, "value", "2");
            __builder.AddContent(47, "February");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n                ");
            __builder.OpenElement(49, "option");
            __builder.AddAttribute(50, "value", "3");
            __builder.AddContent(51, "March");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n                ");
            __builder.OpenElement(53, "option");
            __builder.AddAttribute(54, "value", "4");
            __builder.AddContent(55, "April");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n                ");
            __builder.OpenElement(57, "option");
            __builder.AddAttribute(58, "value", "5");
            __builder.AddContent(59, "May");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n                ");
            __builder.OpenElement(61, "option");
            __builder.AddAttribute(62, "value", "6");
            __builder.AddContent(63, "June");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n                ");
            __builder.OpenElement(65, "option");
            __builder.AddAttribute(66, "value", "7");
            __builder.AddContent(67, "July");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n                ");
            __builder.OpenElement(69, "option");
            __builder.AddAttribute(70, "value", "8");
            __builder.AddContent(71, "August");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n                ");
            __builder.OpenElement(73, "option");
            __builder.AddAttribute(74, "value", "9");
            __builder.AddContent(75, "September");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\r\n                ");
            __builder.OpenElement(77, "option");
            __builder.AddAttribute(78, "value", "10");
            __builder.AddContent(79, "October");
            __builder.CloseElement();
            __builder.AddMarkupContent(80, "\r\n                ");
            __builder.OpenElement(81, "option");
            __builder.AddAttribute(82, "value", "11");
            __builder.AddContent(83, "November");
            __builder.CloseElement();
            __builder.AddMarkupContent(84, "\r\n                ");
            __builder.OpenElement(85, "option");
            __builder.AddAttribute(86, "value", "12");
            __builder.AddContent(87, "December");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n\r\n        ");
            __builder.OpenElement(89, "div");
            __builder.AddAttribute(90, "class", "year-header");
            __builder.OpenElement(91, "select");
            __builder.AddAttribute(92, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 46 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                selectYear

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 47 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                 for (int i = DateTime.Today.Year; i < DateTime.Today.Year + 100; i++)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(93, "option");
#nullable restore
#line 49 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
__builder.AddContent(94, i);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 50 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n\r\n    ");
            __builder.OpenElement(96, "div");
            __builder.OpenElement(97, "table");
            __builder.AddAttribute(98, "class", "calander-table");
            __builder.AddAttribute(99, "style", "margin-top: 25px; table-layout:fixed ");
            __builder.AddMarkupContent(100, @"<thead><tr class=""table-primary""><th>Sun</th>
                    <th>Mon</th>
                    <th>Tues</th>
                    <th>Wed</th>
                    <th>Thurs</th>
                    <th>Fri</th>
                    <th>Sat</th></tr></thead>

            ");
            __builder.OpenElement(101, "tbody");
#nullable restore
#line 71 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                 for (int i = 0; i < DateTime.DaysInMonth(currentYear, currentMonth); i++)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(102, "tr");
#nullable restore
#line 74 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                         foreach (var day in days[currentMonth - 1].Skip(i * 7).Take(7))
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(103, "td");
            __builder.AddAttribute(104, "id", "cal-day");
            __builder.AddAttribute(105, "class", "shadow-sm" + " text-center" + " " + (
#nullable restore
#line 76 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                                                            day.Events != null && day.Events.Count != 0 ? "calander-event" : ""

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 76 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
__builder.AddContent(106, DayTemplate(day));

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 77 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"

                        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 80 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(107, "\r\n\r\n");
            __builder.AddMarkupContent(108, "<h2 style=\"font-family: Gabriola; text-decoration: underline;\">Tasks</h2>\r\n");
            __builder.OpenElement(109, "ul");
#nullable restore
#line 89 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
     foreach (var todo in todos)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(110, "li");
            __builder.OpenElement(111, "p");
            __builder.AddAttribute(112, "class", "event");
            __builder.OpenElement(113, "input");
            __builder.AddAttribute(114, "type", "checkbox");
            __builder.AddAttribute(115, "checked", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 94 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                              todo.IsDone

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(116, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => todo.IsDone = __value, todo.IsDone));
            __builder.SetUpdatesAttributeName("checked");
            __builder.CloseElement();
            __builder.AddMarkupContent(117, "\r\n                ");
            __builder.OpenElement(118, "h3");
            __builder.AddAttribute(119, "class", "d-inline-flex");
#nullable restore
#line 95 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
__builder.AddContent(120, todo.Title);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(121, "\r\n                ");
            __builder.OpenElement(122, "input");
            __builder.AddAttribute(123, "type", "date");
            __builder.AddAttribute(124, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 96 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                          todo.Date

#line default
#line hidden
#nullable disable
            , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(125, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => todo.Date = __value, todo.Date, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(126, "\r\n                ");
            __builder.OpenElement(127, "input");
            __builder.AddAttribute(128, "type", "time");
            __builder.AddAttribute(129, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 97 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                          todo.Time

#line default
#line hidden
#nullable disable
            , format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(130, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => todo.Time = __value, todo.Time, format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 101 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"

    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(131, "button");
            __builder.AddAttribute(132, "class", "btn-secondary");
            __builder.AddAttribute(133, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 104 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
                                            updateEvent

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(134, "Update Calander");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 110 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
       
    int currentYear = DateTime.Today.Year;
    int currentMonth = DateTime.Today.Month;
    List<List<CalanderDay>> days;
    int firstWeekDayNum;


    private List<TodoItem> todos = new();
    private string newTask;
    private DateTime newDate = DateTime.Today;
    private DateTime newTime = DateTime.Now;


    protected override void OnInitialized()
    {
        base.OnInitialized();

        days = new List<List<CalanderDay>>(new List<CalanderDay>[12]);

        for (int i = 0; i < 12; i++)
        {
            days[i] = new List<CalanderDay>();

            //days[currentMonth] = new List<CalanderDay>();

            var firstDayDate = new DateTime(currentYear, i + 1, 1);
            firstWeekDayNum = (int)firstDayDate.DayOfWeek;
            int numEmptyDays = 0;
            int numWeekRows = 0;
            int numDaysinMonth = 0;

            if (numEmptyDays == 7)
            {
                numEmptyDays = 0;
            }
            else
            {
                numEmptyDays = firstWeekDayNum;
            }

            for (int j = 0; j < numEmptyDays; j++)
            {
                days[i].Add(new CalanderDay
                {
                    DayNum = 0,
                    isEmpty = true
                });
            }

            numDaysinMonth = DateTime.DaysInMonth(currentYear, i + 1);

            

#line default
#line hidden
#nullable disable
#nullable restore
#line 161 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
             for (int j = 1; j <= numDaysinMonth; j++)
            {
                days[i].Add(
                    new CalanderDay()
                    {
                        DayNum = j,
                        isEmpty = false,
                        Date = new DateTime(currentYear, i + 1, j),
                        Events = new List<TodoItem>()
                    });
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 171 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
             


            numWeekRows = (int)Math.Ceiling(DateTime.DaysInMonth(currentYear, currentMonth) / 7.0);
        }

        updateCalander();
    }

    void selectYear(ChangeEventArgs e)
    {
        currentYear = Convert.ToInt32(e.Value.ToString());

        updateCalander();
    }

    void selectMonth(ChangeEventArgs e)
    {

        currentMonth = Convert.ToInt32(e.Value.ToString());
        newDate = new DateTime(currentYear, currentMonth, 1);


        updateCalander();
    }

    public void updateCalander()
    {

        var firstDayDate = new DateTime(currentYear, currentMonth, 1);
        firstWeekDayNum = (int)firstDayDate.DayOfWeek;
        int numEmptyDays = 0;
        int numWeekRows = 0;
        int numDaysinMonth = 0;

        if (numEmptyDays == 7)
        {
            numEmptyDays = 0;
        }
        else
        {
            numEmptyDays = firstWeekDayNum;
        }


        numDaysinMonth = DateTime.DaysInMonth(currentYear, currentMonth);
        numWeekRows = (int)Math.Ceiling(DateTime.DaysInMonth(currentYear, currentMonth) / 7.0);

    }


    [Parameter]
    public RenderFragment<CalanderDay> DayTemplate { get; set; }


    public void AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(newTask) /*&& newDate.Month == currentMonth*/)
        {
            int calanderEventDayIndex = (newDate.Day + firstWeekDayNum) - 1;
            todos.Add(new TodoItem { Title = newTask, Date = newDate, Time = newTime });
            days[newDate.Month - 1][calanderEventDayIndex].Events.Add(todos[todos.Count - 1]);
            newTask = string.Empty;
            newDate = DateTime.Today;
            newTime = DateTime.Now;

            //Add event to calander UI


        }
    }

    public void updateEvent()
    {
        //updateCalander();

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 247 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
         foreach (var todo in todos)
        {
            int currentIndex1 = (todo.Date.Day + firstWeekDayNum) - 1;
            int currentIndex2 = (todo.Time.Day + firstWeekDayNum) - 1;
            todo.Time = todo.Date;
            days[currentMonth - 1][currentIndex1].Events.Add(todo);
            days[currentMonth - 1][currentIndex2].Events.Clear();

        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 255 "C:\Users\Dudel\Desktop\Code\490\NoteEBook T2\490-NotEBook\NotEBookWeb\NotEBookWeb\Controls\Calander.razor"
         
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
