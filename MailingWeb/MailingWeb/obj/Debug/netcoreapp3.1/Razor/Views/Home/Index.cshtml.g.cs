#pragma checksum "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72827d077c55dd762d03f36325d685e609a8a773"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\_ViewImports.cshtml"
using MailingWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\_ViewImports.cshtml"
using MailingWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72827d077c55dd762d03f36325d685e609a8a773", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c45161a41d6070b1a88aea1a50b96d77a606d79", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MailingWeb.Models.ViewModels.MessagesViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/mdbootstrap/js/mdb.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/mdbootstrap/js/addons/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Главная";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"" style=""margin: 50px 0"">
    <div class=""col-md-12"">
        <table id=""dtMessages"" class=""table table-striped table-bordered table-sm"">
            <thead>
                <tr>
                    <th>
                        #
                    </th>
                    <th>
                        ФИО студента
                    </th>
                    <th>
                        Порт
                    </th>
                    <th>
                        Сообщение
                    </th>
                    <th>
                        Статус
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 29 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                 foreach (var row in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 33 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                       Write(row.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 36 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                       Write(row.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 36 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                                    Write(row.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 36 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                                              Write(row.Patronymic);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 39 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                       Write(row.PortName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            \"");
#nullable restore
#line 42 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                        Write(row.Template);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 45 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                       Write(row.StatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 48 "D:\stud\_ДИМПЛОМ\MailingService\MailingWeb\MailingWeb\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<script type=""text/javascript"">
    $(document).ready(function () {
        $('#dtMessages').DataTable({
            ""language"": {
                ""lengthMenu"": ""Показать _MENU_"",
                ""zeroRecords"": ""Не найдено"",
                ""info"": ""Страница _PAGE_ из _PAGES_"",
                ""infoEmpty"": ""По Вашему запросу не найдено соответствий"",
                ""infoFiltered"": ""(из _MAX_)"",
                ""search"": ""Поиск:"",
                ""paginate"": {
                    ""first"": ""В начало"",
                    ""last"": ""В конец"",
                    ""next"": ""Следующая"",
                    ""previous"": ""Предыдущая""
                },
                ""loadingRecords"": ""Loading..."",
                ""processing"": ""Processing..."",
                ""aria"": {
                    ""sortAscending"": "": по возрастанию"",
                    ""sortDescending"": "": по убыванию""
                }
            }
        });
        $('.da");
            WriteLiteral("taTables_length\').addClass(\'bs-select\');\r\n    });\r\n</script>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72827d077c55dd762d03f36325d685e609a8a7739123", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72827d077c55dd762d03f36325d685e609a8a77310309", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MailingWeb.Models.ViewModels.MessagesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
