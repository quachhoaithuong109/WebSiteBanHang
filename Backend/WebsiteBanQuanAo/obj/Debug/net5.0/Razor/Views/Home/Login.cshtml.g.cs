#pragma checksum "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c88b0445419a9530c980441f714474f70f6e7ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c88b0445419a9530c980441f714474f70f6e7ed", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83f3a71a3d44cc2c333262259035999e9cea4b91", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmPayment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Xây dựng Website\DoAnTotNghiep\DoAnTotNghiep\Backend\NXHOANG.DoAnTotNghiep\Views\Home\Login.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<link rel=""stylesheet"" href=""/css/CustomCss/login.css"" />

<section class=""ftco-section ftco-cart section-login"">
    <div class=""container"">
        <div class=""row row-margin-top"">
            <div class=""col-6"">
                <div>
                    <div class=""reservation_top"">
                        <div class=""contact_right"">
                            <h4 class=""text-center"">Đăng nhập</h4>
                            <div class=""contact-form"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c88b0445419a9530c980441f714474f70f6e7ed4727", async() => {
                WriteLiteral(@"

                                    <div class=""form-group"">
                                        <input type=""text"" class=""textbox form-control"" id=""txtUserEmail"" name=""name"" placeholder=""Email (*)"">
                                        <span class=""error-validate validate-email""></span>
                                    </div>

                                    <div class=""form-group"">
                                        <input type=""password"" class=""textbox form-control"" id=""txtPassWord"" name=""passWord"" placeholder=""Mật khẩu (*)"">
                                        <span class=""error-validate validate-password""></span>
                                    </div>

                                    <div class=""form-group"">
                                        <button type=""button"" class=""btn btn-confirm"" id=""btnLogin"">
                                            <i class=""fa fa-sign-in"" aria-hidden=""true""></i>
                                            <span>Đăng nhập");
                WriteLiteral("</span>\r\n                                        </button>\r\n                                    </div>\r\n\r\n                                    <div class=\"clearfix\"> </div>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-6"">
                <div>
                    <div class=""reservation_top"">
                        <div class=""contact_right"">
                            <h4 class=""text-center"">Đăng nhập với mạng xã hội</h4>
                            <div class=""contact-form"">
                                <div class=""social-login text-center"">
                                    <a href=""#"" class=""facebook btn btn-block"" id=""facebook"">
                                        <span class=""mr-3"">
                                            <i class=""fa fa-facebook"" aria-hidden=""true""></i>
                                        </span>
                                    </a>
                                    <a href=""#"" class=""google btn btn-block"" id=""google"">
                                        <span class=""mr-3"">
              ");
            WriteLiteral(@"                              <i class=""fa fa-google"" aria-hidden=""true""></i>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-6"">
                <div class=""login-left"">
                    <h4>Chưa có tài khoản</h4>
                    <p>Nếu bạn chưa có tài khoản vui lòng đăng ký tại link dưới đây:</p>
                    <a class=""acount-btn"" href=""/dang-ky.html"">Đăng ký thành viên</a>
                </div>
                <div class=""clearfix""> </div>
            </div>
        </div>

    </div>
</section>


<style>

    #facebook {
        width: 100%;
        color: white;
        background-color: #4267B2;
        height: 40px;
        line-height: 26px;
        font-size: 19px;
      ");
            WriteLiteral(@"  border-radius: 6px;
    }

    #google {
        border-radius: 5px;
        background: #db4437;
        color: white;
        width: 100%;
        line-height: 26px;
        height: 40px;
        font-size: 21px;
    }

</style>
























");
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
