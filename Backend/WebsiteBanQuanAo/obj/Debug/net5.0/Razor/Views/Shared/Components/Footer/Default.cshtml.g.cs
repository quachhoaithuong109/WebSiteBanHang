#pragma checksum "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c2f4e18a32bb04ae5489c7281afcb585dfc5330"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Footer_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Footer/Default.cshtml")]
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
#line 1 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\_ViewImports.cshtml"
using NXHOANG.DoAnTotNghiep;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\_ViewImports.cshtml"
using NXHOANG.DoAnTotNghiep.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c2f4e18a32bb04ae5489c7281afcb585dfc5330", @"/Views/Shared/Components/Footer/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83f3a71a3d44cc2c333262259035999e9cea4b91", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Footer_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NXHOANG.ApplicationCore.ViewModel.FooterViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""container"">
    <div class=""row"">
        <div class=""mouse"">
            <a href=""#"" class=""mouse-icon"">
                <div class=""mouse-wheel"">
                    <span>
                        <i class=""fa fa-arrow-up"" aria-hidden=""true""></i>
                    </span>
                </div>
            </a>
        </div>
    </div>
    <div class=""row mb-5"">
        <div class=""col-md"">
            <div class=""ftco-footer-widget mb-4"">
                <h2 class=""ftco-heading-2"">NXHOANG</h2>
                <p>");
#nullable restore
#line 20 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml"
              Write(Model.FooterInfo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                <ul class=""ftco-footer-social list-unstyled float-md-left float-lft mt-5"">
                    <li class=""ftco-animate"">
                        <a href=""#"">
                            <span>
                                <i class=""fa fa-twitter"" aria-hidden=""true""></i>
                            </span>
                        </a>
                    </li>
                    <li class=""ftco-animate"">
                        <a href=""#"">
                            <span>
                                <i class=""fa fa-facebook-official"" aria-hidden=""true""></i>
                            </span>
                        </a>
                    </li>
                    <li class=""ftco-animate"">
                        <a href=""#"">
                            <span>
                                <i class=""fa fa-instagram"" aria-hidden=""true""></i>
                            </span>
                        </a>
                    </li>
                </ul>
");
            WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"col-md\">\r\n            <div class=\"ftco-footer-widget mb-4 ml-md-5\">\r\n                <h2 class=\"ftco-heading-2\">Danh Mục</h2>\r\n                <ul class=\"list-unstyled\">\r\n");
#nullable restore
#line 50 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml"
                     foreach (var item in Model.Menus)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <a href=\"#\" class=\"py-2 d-block\">\r\n                                ");
#nullable restore
#line 54 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml"
                           Write(item.ProductCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n");
#nullable restore
#line 57 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    \r\n                </ul>\r\n            </div>\r\n        </div>\r\n");
            WriteLiteral(@"        <div class=""col-md"">
            <div class=""ftco-footer-widget mb-4"">
                <h2 class=""ftco-heading-2"">Thông Tin Liên Hệ</h2>
                <div class=""block-23 mb-3"">
                    <ul>
                        <li class=""icon-footer-info-contact"">
                            <span>
                                <i class=""fa fa-map-marker"" aria-hidden=""true""></i>
                            </span>
                            <span class=""text"">");
#nullable restore
#line 88 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml"
                                          Write(Model.Infos[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </li>

                        <li class=""icon-footer-info-contact"">
                            <span>
                                <i class=""fa fa-Phone"" aria-hidden=""true""></i>
                           </span>
                            <span class=""text"">");
#nullable restore
#line 95 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml"
                                          Write(Model.Infos[1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </li>\r\n                        <li class=\"icon-footer-info-contact\">\r\n                            <span><i class=\"fa fa-envelope\" aria-hidden=\"true\"></i></span>\r\n                            <span class=\"text\">");
#nullable restore
#line 99 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Shared\Components\Footer\Default.cshtml"
                                          Write(Model.Infos[2]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NXHOANG.ApplicationCore.ViewModel.FooterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591