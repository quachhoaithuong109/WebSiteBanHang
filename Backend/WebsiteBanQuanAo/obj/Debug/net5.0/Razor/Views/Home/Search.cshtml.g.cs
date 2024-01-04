#pragma checksum "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef2a156ae7cea56345dd7ed026a2267479ecf042"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef2a156ae7cea56345dd7ed026a2267479ecf042", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83f3a71a3d44cc2c333262259035999e9cea4b91", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NXHOANG.ApplicationCore.ViewModel.PaginationSet>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
  
    var keyword = (string)ViewBag.Keyword;
    ViewBag.MetaKeyword = "Kết quả tìm kiếm cho từ khóa " + keyword;
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""/css/CustomCss/ProductCategorySection.css"" />

<section class=""ftco-section product-category-section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-10"">
                <p>Kết quả tìm kiếm ");
#nullable restore
#line 16 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                               Write(ViewBag.keyword);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 16 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                                  Write(Model.Item.TotalProducts);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Sản phẩm  </p>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n\r\n");
#nullable restore
#line 21 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
              

                foreach (var item in Model.Item.products)
                {
                    var urlImage = "";

                    if (item.TypeProduct == 1)
                    {
                        // Bàn Ghế
                        urlImage = "/images/ImageProduct/BanGhe/" + item.Image;
                    }
                    else if (item.TypeProduct == 2)
                    {
                        // Tủ
                        urlImage = "/images/ImageProduct/Tu/" + item.Image;
                    }
                    else if (item.TypeProduct == 3)
                    {
                        // Giường
                        urlImage = "/images/ImageProduct/Giuong/" + item.Image;
                    }


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-6 col-lg-3 ftco-animate\">\r\n                        <div class=\"product\">\r\n                            <a href=\"#\" class=\"img-prod\">\r\n                                <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=", 1607, "", 1621, 1);
#nullable restore
#line 46 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue("", 1612, urlImage, 1612, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""Colorlib Template"">
                                <span class=""status"">30%</span>
                                <div class=""overlay""></div>
                            </a>
                            <div class=""text py-3 pb-4 px-3 text-center"">
                                <h3>
                                    <a href=""#""");
            BeginWriteAttribute("title", " title=\"", 1968, "\"", 1993, 1);
#nullable restore
#line 52 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue("", 1976, item.ProductName, 1976, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <div class=\"product-name-text\">");
#nullable restore
#line 53 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                                                  Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </a>
                                </h3>
                                <div class=""d-flex"">
                                    <div class=""pricing"">
                                        <p class=""price"">
");
#nullable restore
#line 59 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                             if (item.PromotionPrice != null && item.PromotionPrice != 0)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"mr-2 price-dc\">");
#nullable restore
#line 61 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                                                        Write((Math.Round((decimal)item.Price, 0, MidpointRounding.AwayFromZero)).ToString("N0").Replace(",", "."));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Vnđ</span><span class=\"price-sale\">");
#nullable restore
#line 61 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                                                                                                                                                                                                   Write((Math.Round((decimal)item.PromotionPrice, 0, MidpointRounding.AwayFromZero)).ToString("N0").Replace(",", "."));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Vnđ</span>\r\n");
#nullable restore
#line 62 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"mr-2 price-sale\">");
#nullable restore
#line 65 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                                                          Write((Math.Round((decimal)item.Price, 0, MidpointRounding.AwayFromZero)).ToString("N0").Replace(",", "."));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Vnđ</span>\r\n");
#nullable restore
#line 66 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </p>
                                    </div>
                                </div>
                                <div class=""bottom-area d-flex px-3"">
                                    <div class=""m-auto d-flex"">
                                        <a href=""#"" class=""add-to-cart d-flex justify-content-center align-items-center text-center"">
                                            <span>
                                                <i class=""fa fa-bars"" aria-hidden=""true""></i>
                                            </span>
                                        </a>
                                        <a href=""#"" class=""buy-now d-flex justify-content-center align-items-center mx-1"">
                                            <span>
                                                <i class=""fa fa-shopping-cart"" aria-hidden=""true""></i>
                                            </span>
                                        </a>");
            WriteLiteral(@"
                                        <a href=""#"" class=""heart d-flex justify-content-center align-items-center "">
                                            <span>
                                                <i class=""fa fa-heart"" aria-hidden=""true""></i>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 92 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"row mt-5\">\r\n            <div class=\"col text-center\">\r\n                <div class=\"block-27\">\r\n                    <ul>\r\n");
#nullable restore
#line 100 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                         if (Model.TotalPages > 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 5136, "\"", 5164, 2);
            WriteAttributeValue("", 5143, "?page=", 5143, 6, true);
#nullable restore
#line 103 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue("", 5149, Model.Page-1, 5149, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    &lt;\r\n                                </a>\r\n                            </li>\r\n");
#nullable restore
#line 107 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"

                            var startPageIndex = Math.Max(1, Model.Page - Model.MaxPage / 2);
                            var endPageIndex = Math.Min(Model.TotalPages, Model.Page + Model.MaxPage / 2);

                            for (int i = startPageIndex; i <= endPageIndex; i++)
                            {
                                if (Model.Page == i)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"active\">\r\n                                        <span>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 5843, "\"", 5858, 2);
            WriteAttributeValue("", 5850, "?page=", 5850, 6, true);
#nullable restore
#line 117 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue("", 5856, i, 5856, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 5859, "\"", 5875, 2);
            WriteAttributeValue("", 5867, "trang", 5867, 5, true);
#nullable restore
#line 117 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue(" ", 5872, i, 5873, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 117 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </span>\r\n                                    </li>\r\n");
#nullable restore
#line 120 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 6169, "\"", 6184, 2);
            WriteAttributeValue("", 6176, "?page=", 6176, 6, true);
#nullable restore
#line 124 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue("", 6182, i, 6182, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 6185, "\"", 6201, 2);
            WriteAttributeValue("", 6193, "Trang", 6193, 5, true);
#nullable restore
#line 124 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue(" ", 6198, i, 6199, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 124 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 126 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
                                }
                            }


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 6390, "\"", 6418, 2);
            WriteAttributeValue("", 6397, "?page=", 6397, 6, true);
#nullable restore
#line 130 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"
WriteAttributeValue("", 6403, Model.Page+1, 6403, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    &gt;\r\n                                </a>\r\n                            </li>\r\n");
#nullable restore
#line 134 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Search.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                      \r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NXHOANG.ApplicationCore.ViewModel.PaginationSet> Html { get; private set; }
    }
}
#pragma warning restore 1591