#pragma checksum "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef370e0108d78647b2ede5260b00d8081937e486"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductCategory_Index), @"mvc.1.0.view", @"/Views/ProductCategory/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef370e0108d78647b2ede5260b00d8081937e486", @"/Views/ProductCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83f3a71a3d44cc2c333262259035999e9cea4b91", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NXHOANG.ApplicationCore.ViewModel.PaginationSet>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"/css/CustomCss/ProductCategorySection.css\" />\r\n\r\n\r\n");
            WriteLiteral("\r\n<!--Slide -->\r\n<section id=\"home-section\" class=\"hero\">\r\n\r\n    ");
#nullable restore
#line 15 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
Write(await Component.InvokeAsync("SliderOption"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

</section>


<section class=""ftco-section product-category-section"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-md-10 mb-5 text-center"">
                <ul class=""product-category"">

");
#nullable restore
#line 26 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                     foreach (var item in Model.Item.productCategories)
                    {
                        var urlCategory = "danh-muc-" + item.ProductCategoryLink + "/" + item.ProductCategoryId;
                       

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><a");
            BeginWriteAttribute("href", " href=\"", 1175, "\"", 1195, 2);
            WriteAttributeValue("", 1182, "/", 1182, 1, true);
#nullable restore
#line 35 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 1183, urlCategory, 1183, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 35 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                                   Write(item.ProductCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 36 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                        //}

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n\r\n");
#nullable restore
#line 45 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
              

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
                        //Giường
                        urlImage = "/images/ImageProduct/Giuong/" + item.Image;
                    }

                    var urlProductDetail = "/" + "san-pham-chi-tiet" + "/" + item.ProductId + ".html";


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-6 col-lg-3 ftco-animate\">\r\n                        <div class=\"product\">\r\n                            <a href=\"#\" class=\"img-prod\">\r\n                                <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=", 2481, "", 2495, 1);
#nullable restore
#line 72 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 2486, urlImage, 2486, 9, false);

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
            BeginWriteAttribute("title", " title=\"", 2842, "\"", 2867, 1);
#nullable restore
#line 78 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 2850, item.ProductName, 2850, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <div class=\"product-name-text\">");
#nullable restore
#line 79 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
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
#line 85 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                             if (item.PromotionPrice != null && item.PromotionPrice != 0)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"mr-2 price-dc\">");
#nullable restore
#line 87 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                                                        Write((Math.Round((decimal)item.Price, 0, MidpointRounding.AwayFromZero)).ToString("N0").Replace(",", "."));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Vnđ</span><span class=\"price-sale\">");
#nullable restore
#line 87 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                                                                                                                                                                                                   Write((Math.Round((decimal)item.PromotionPrice, 0, MidpointRounding.AwayFromZero)).ToString("N0").Replace(",", "."));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Vnđ</span>\r\n");
#nullable restore
#line 88 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"mr-2 price-sale\">");
#nullable restore
#line 91 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                                                          Write((Math.Round((decimal)item.Price, 0, MidpointRounding.AwayFromZero)).ToString("N0").Replace(",", "."));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Vnđ</span>\r\n");
#nullable restore
#line 92 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </p>
                                    </div>
                                </div>
                                <div class=""bottom-area d-flex px-3"">
                                    <div class=""m-auto d-flex"">
                                        <a");
            BeginWriteAttribute("href", " href=\"", 4407, "\"", 4431, 1);
#nullable restore
#line 98 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 4414, urlProductDetail, 4414, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""add-to-cart d-flex justify-content-center align-items-center text-center"">
                                            <span>
                                                <i class=""fa fa-bars"" aria-hidden=""true""></i>
                                            </span>
                                        </a>
                                        <a href=""#"" class=""buy-now d-flex justify-content-center align-items-center mx-1 btnAddToCart"" data-id=""");
#nullable restore
#line 103 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                                                                                                                           Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                                            <span>
                                                <i class=""fa fa-shopping-cart"" aria-hidden=""true""></i>
                                            </span>
                                        </a>
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
#line 118 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"row mt-5\">\r\n            <div class=\"col text-center\">\r\n                <div class=\"block-27\">\r\n                    <ul>\r\n");
#nullable restore
#line 126 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                         if (Model.TotalPages > 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 6065, "\"", 6093, 2);
            WriteAttributeValue("", 6072, "?page=", 6072, 6, true);
#nullable restore
#line 129 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 6078, Model.Page-1, 6078, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    &lt;\r\n                                </a>\r\n                            </li>\r\n");
#nullable restore
#line 133 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"

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
            BeginWriteAttribute("href", " href=\"", 6772, "\"", 6787, 2);
            WriteAttributeValue("", 6779, "?page=", 6779, 6, true);
#nullable restore
#line 143 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 6785, i, 6785, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 6788, "\"", 6804, 2);
            WriteAttributeValue("", 6796, "trang", 6796, 5, true);
#nullable restore
#line 143 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue(" ", 6801, i, 6802, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 143 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </span>\r\n                                    </li>\r\n");
#nullable restore
#line 146 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 7098, "\"", 7113, 2);
            WriteAttributeValue("", 7105, "?page=", 7105, 6, true);
#nullable restore
#line 150 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 7111, i, 7111, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 7114, "\"", 7130, 2);
            WriteAttributeValue("", 7122, "Trang", 7122, 5, true);
#nullable restore
#line 150 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue(" ", 7127, i, 7128, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 150 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 152 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
                                }
                            }


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 7319, "\"", 7347, 2);
            WriteAttributeValue("", 7326, "?page=", 7326, 6, true);
#nullable restore
#line 156 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"
WriteAttributeValue("", 7332, Model.Page+1, 7332, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    &gt;\r\n                                </a>\r\n                            </li>\r\n");
#nullable restore
#line 160 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\ProductCategory\Index.cshtml"

                        }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
