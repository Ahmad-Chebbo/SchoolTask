#pragma checksum "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\Subject\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "735ee2dce665711bbe1528f10e684a97f58b9e38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subject_Detail), @"mvc.1.0.view", @"/Views/Subject/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\_ViewImports.cshtml"
using SchoolTask;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\_ViewImports.cshtml"
using SchoolTask.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"735ee2dce665711bbe1528f10e684a97f58b9e38", @"/Views/Subject/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03eb6d38278c7088ca5317c1039877b7f19f6df0", @"/Views/_ViewImports.cshtml")]
    public class Views_Subject_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Subject>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\Subject\Detail.cshtml"
  
    ViewData["Title"] = "Show " + @Model.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>");
#nullable restore
#line 7 "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\Subject\Detail.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 7 "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\Subject\Detail.cshtml"
             Write(Model.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<hr />\r\n<label for=\"description\" class=\"font-weight-bold\">Description</label>\r\n<p id=\"description\">");
#nullable restore
#line 10 "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\Subject\Detail.cshtml"
               Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<div class=\"form-group\">\r\n                    <a  href=\"#\" onclick= \"history.go(-1)\"  class=\"btn btn-secondary btn-block\"><i class=\"fa fa-table\"></i> Back to List</a>\r\n                </div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 16 "F:\Asp .Net\Testing\SchoolTask\SchoolTask\Views\Subject\Detail.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Subject> Html { get; private set; }
    }
}
#pragma warning restore 1591
