#pragma checksum "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98dee3b040e1d4d48298a4aafcf7e9c50b80070c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Article__ArticleDetailRightSideBarPartial), @"mvc.1.0.view", @"/Views/Article/_ArticleDetailRightSideBarPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98dee3b040e1d4d48298a4aafcf7e9c50b80070c", @"/Views/Article/_ArticleDetailRightSideBarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Article__ArticleDetailRightSideBarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProgrammersBlog.MVC.Models.ArticleDetailRightSideBarViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top text-center image-thumbnail mt-1 mb-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Article", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("<div class=\"col-md-4\">\n\n    <div class=\"card my-4\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98dee3b040e1d4d48298a4aafcf7e9c50b80070c4170", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 140, "~/img/", 140, 6, true);
#nullable restore
#line 6 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
AddHtmlAttributeValue("", 146, Model.User.Picture, 146, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 6 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
AddHtmlAttributeValue("", 231, Model.User.UserName, 231, 20, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        <h5 class=\"card-header text-center\">");
#nullable restore
#line 7 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                       Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n        <div class=\"card-body\">\n            <p class=\"card-text text-center\">\n                ");
#nullable restore
#line 10 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
           Write(Model.User.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </p>\n            <div class=\"card-footer text-center\">\n                <p>Sosyal Medya Linkleri</p>\n");
#nullable restore
#line 14 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                 if (Model.User.LinkedInLink != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 635, "\"", 666, 1);
#nullable restore
#line 16 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 642, Model.User.LinkedInLink, 642, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-linkedin\"></span></a>");
#nullable restore
#line 16 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
#nullable restore
#line 19 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                 if (Model.User.GitHubLink != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 797, "\"", 826, 1);
#nullable restore
#line 21 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 804, Model.User.GitHubLink, 804, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-github-square\"></span></a>");
#nullable restore
#line 21 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
#nullable restore
#line 24 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                 if (Model.User.InstagramLink != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 965, "\"", 997, 1);
#nullable restore
#line 26 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 972, Model.User.InstagramLink, 972, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-instagram-square\"></span></a>");
#nullable restore
#line 26 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 28 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                 if (Model.User.TwitterLink != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 1136, "\"", 1166, 1);
#nullable restore
#line 30 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
WriteAttributeValue("", 1143, Model.User.TwitterLink, 1143, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"fab fa-twitter-square\"></span></a>");
#nullable restore
#line 30 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n        </div>\n    </div>\n\n    <!-- Side Widget -->\n    <div class=\"card my-4\">\n        <h5 class=\"card-header\">");
#nullable restore
#line 37 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                           Write(Model.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n        <div class=\"card-body\">\n            <div class=\"row\">\n                <div class=\"col-lg-12\">\n                    <ul class=\"list-group\">\n");
#nullable restore
#line 42 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                         for (int i = 0; i < Model.ArticleListDto.Articles.Count; i++)
                        {
                            if (i % 2 == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"list-group-item list-group-item-primary\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98dee3b040e1d4d48298a4aafcf7e9c50b80070c12684", async() => {
#nullable restore
#line 47 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                                                      Write(Model.ArticleListDto.Articles[i].Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-articleıd", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                         WriteLiteral(Model.ArticleListDto.Articles[i].ıd);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleıd"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-articleıd", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleıd"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </li> ");
#nullable restore
#line 48 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                  }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"list-group-item list-group-item-info\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98dee3b040e1d4d48298a4aafcf7e9c50b80070c15917", async() => {
#nullable restore
#line 52 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                                                                      Write(Model.ArticleListDto.Articles[i].Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-articleıd", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                                                                         WriteLiteral(Model.ArticleListDto.Articles[i].ıd);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleıd"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-articleıd", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["articleıd"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </li>");
#nullable restore
#line 53 "C:\Users\cevik\Desktop\.netcore\ProgrammersBlog\ProgrammersBlog.MVC\Views\Article\_ArticleDetailRightSideBarPartial.cshtml"
                 }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </ul>\n                </div>\n            </div>\n        </div>\n    </div>\n\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProgrammersBlog.MVC.Models.ArticleDetailRightSideBarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
