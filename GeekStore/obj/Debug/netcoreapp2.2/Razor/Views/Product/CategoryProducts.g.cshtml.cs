#pragma checksum "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0be8a670029a0627fc4baae29872f0db305211af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_CategoryProducts), @"mvc.1.0.view", @"/Views/Product/CategoryProducts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/CategoryProducts.cshtml", typeof(AspNetCore.Views_Product_CategoryProducts))]
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
#line 1 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\_ViewImports.cshtml"
using GeekStore;

#line default
#line hidden
#line 2 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\_ViewImports.cshtml"
using GeekStore.Models;

#line default
#line hidden
#line 3 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\_ViewImports.cshtml"
using GeekStore.Data.Tables;

#line default
#line hidden
#line 4 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\_ViewImports.cshtml"
using GeekStore.Data.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\_ViewImports.cshtml"
using System.Text.Encodings.Web;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0be8a670029a0627fc4baae29872f0db305211af", @"/Views/Product/CategoryProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12e88e7114a52b1816d86d77c80d4c57a475ff67", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_CategoryProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SeeProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration: inherit;color:inherit; position: inherit; "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
  
    ViewData["Title"] = "CategoryProducts";

#line default
#line hidden
            BeginContext(54, 105, true);
            WriteLiteral("    <div class=\"flex-row con\">\r\n\r\n        <div class=\"bar\" id=\"bar\">\r\n            <ul class=\"side-bar\">\r\n");
            EndContext();
#line 9 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                  
                        foreach (CategoryViewModel category in Model.Categories)
                        {
                    

#line default
#line hidden
            BeginContext(309, 44, false);
#line 12 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
               Write(await Html.PartialAsync("SideBar", category));

#line default
#line hidden
            EndContext();
#line 12 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                                                 ;
                        }
                

#line default
#line hidden
            BeginContext(402, 318, true);
            WriteLiteral(@"                <hr />
                <div class=""ml-2"">
                    <p class=""text-muted"" style=""font-size:18px;"">Call-centre</p>
                    <p>+38 044 537-02-22<br />+38 044 537-02-22</p>
                </div>
            </ul>

        </div>
        <div class=""container"">
            ");
            EndContext();
            BeginContext(721, 37, false);
#line 24 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
       Write(await Component.InvokeAsync("Search"));

#line default
#line hidden
            EndContext();
            BeginContext(758, 33, true);
            WriteLiteral("\r\n            <div class=\"row\">\r\n");
            EndContext();
#line 26 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                  
                    foreach (var pr in Model.Products)
                    {


#line default
#line hidden
            BeginContext(892, 90, true);
            WriteLiteral("                        <div class=\"card col-lg-2 col-sm-4\">\r\n                            ");
            EndContext();
            BeginContext(982, 1304, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0be8a670029a0627fc4baae29872f0db305211af7109", async() => {
                BeginContext(1124, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 32 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                 if (pr.Discount != 0)
                                {

#line default
#line hidden
                BeginContext(1217, 85, true);
                WriteLiteral("                                    <span class=\"badge badge-secondary badge-danger\">");
                EndContext();
                BeginContext(1303, 11, false);
#line 34 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                                                                Write(pr.Discount);

#line default
#line hidden
                EndContext();
                BeginContext(1314, 11, true);
                WriteLiteral(" %</span>\r\n");
                EndContext();
#line 35 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                }

#line default
#line hidden
                BeginContext(1360, 36, true);
                WriteLiteral("                                <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 1396, "\"", 1411, 1);
#line 36 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
WriteAttributeValue("", 1402, pr.Image, 1402, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1412, 146, true);
                WriteLiteral(" class=\"card-img-top img\" />\r\n                                <div class=\"card-body\">\r\n                                    <h5 class=\"card-title\">");
                EndContext();
                BeginContext(1559, 7, false);
#line 38 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                                      Write(pr.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1566, 7, true);
                WriteLiteral("</h5>\r\n");
                EndContext();
#line 39 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                      
                                        if (pr.Discount != 0)
                                        {

#line default
#line hidden
                BeginContext(1719, 74, true);
                WriteLiteral("                                            <p class=\"card-text discount\">");
                EndContext();
                BeginContext(1795, 41, false);
#line 42 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                                                      Write(pr.Price - (pr.Price / 100 * pr.Discount));

#line default
#line hidden
                EndContext();
                BeginContext(1837, 67, true);
                WriteLiteral("</p>\r\n                                            <p class=\"muted\">");
                EndContext();
                BeginContext(1905, 8, false);
#line 43 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                                        Write(pr.Price);

#line default
#line hidden
                EndContext();
                BeginContext(1913, 6, true);
                WriteLiteral("</p>\r\n");
                EndContext();
#line 44 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
                BeginContext(2051, 66, true);
                WriteLiteral("                                            <p class=\"card-text \">");
                EndContext();
                BeginContext(2118, 8, false);
#line 47 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                                             Write(pr.Price);

#line default
#line hidden
                EndContext();
                BeginContext(2126, 6, true);
                WriteLiteral("</p>\r\n");
                EndContext();
#line 48 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                        }
                                    

#line default
#line hidden
                BeginContext(2214, 68, true);
                WriteLiteral("                                </div>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 31 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"
                                                                                  WriteLiteral(pr.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2286, 36, true);
            WriteLiteral("\r\n\r\n                        </div>\r\n");
            EndContext();
#line 54 "C:\Users\Dan\source\repos\GeekStore\GeekStore\Views\Product\CategoryProducts.cshtml"

                    }
                

#line default
#line hidden
            BeginContext(2366, 48, true);
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n    </div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
