#pragma checksum "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4700d70465bdcfca31cfa05c2e8c334fc4ac4275"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\_ViewImports.cshtml"
using Fitness2You;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\_ViewImports.cshtml"
using Fitness2You.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4700d70465bdcfca31cfa05c2e8c334fc4ac4275", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7f0a2757274f67c36ca9b6db8850a0cce333afa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4700d70465bdcfca31cfa05c2e8c334fc4ac42753259", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <title>Fitness 2 You</title>\r\n    <link rel=\"stylesheet\" href=\"/styles/styles.css\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4700d70465bdcfca31cfa05c2e8c334fc4ac42754434", async() => {
                WriteLiteral(@"
    <header class=""site-header"">
        <input type=""checkbox"" name=""main-nav-toggle"" id=""main-nav-toggle"">
        <section class=""site-wrapper"">
            <section class=""site-logo"">
                <a href=""/Home/Index"" class=""logo"">Fitness2You</a>
            </section>

            <label for=""main-nav-toggle"" id=""toggle"">
                <i class=""fas fa-bars""></i>
                <i class=""fas fa-times"" id=""times-icon""></i>
            </label>

            <nav class=""site-nav"">
                <ul>
");
#nullable restore
#line 24 "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\Shared\_Layout.cshtml"
                     if (User == null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <li>
                            <a href=""./subscription.html"">Subscription</a>
                        </li>
                        <li>
                            <a href=""#"">Our Trainers</a>
                        </li>
");
#nullable restore
#line 32 "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\Shared\_Layout.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li>\r\n                            <a href=\"/Users/Register\">Sign up</a>\r\n                        </li>\r\n                        <li>\r\n                            <a href=\"/Users/Login\">Log in</a>\r\n                        </li>\r\n");
#nullable restore
#line 41 "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </ul>\r\n            </nav>\r\n        </section>\r\n    </header>\r\n\r\n    ");
#nullable restore
#line 47 "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\Shared\_Layout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <footer class=""site-footer"">
        <section class=""site-wrapper"">
            <section class=""footer-content"">
                <article>
                    <section class=""site-logo"">
                        <a href=""/Home/Index"" class=""logo"">Fitness2You</a>
                    </section>
                    <p class=""site-slogan"">Proin nunc sapien, gravida ut sapien ut, ultrices faucibus sapien. Proin vehicula varius ex, vel feugiat massa scelerisque id. Nullam vulputate a lectus non molestie. Duis at lobortis neque.</p>
                    <section class=""site-social"">
                        <a href=""#""><i class=""fab fa-pinterest-p""></i></a>
                        <a href=""#""><i class=""fab fa-instagram""></i></a>
                        <a href=""#""><i class=""fab fa-facebook""></i></a>
                        <a href=""#""><i class=""fab fa-twitter""></i></a>
                        <a href=""#""><i class=""fab fa-youtube""></i></a>
                        <a href=""#""><i class=""fab fa-google");
                WriteLiteral(@"-plus-g""></i></a>
                    </section>
                </article>
                <article class=""testimonials"">
                    <h6>Testimonials</h6>
                    <section class=""testimonial"">
                        <p class=""quote"">“ Donec molestie tincidunt tellus sit amet aliquet. Proin auctor nisi ut purus.</p>
                        <p class=""quote-author"">Michael Smith</p>
                    </section>
                    <section class=""testimonial"">
                        <p class=""quote"">“ Molestie tincidunt tellus sit amet aliquet. Proin auctor nisi ut purus.</p>
                        <p class=""quote-author"">Paco Refana</p>
                    </section>
                </article>
                <article class=""classes"">
                    <h6>Classes</h6>
                    <section>
                        <a href=""#"">Bodybuilding Class</a>
                        <a href=""#"">Fitness Class</a>
                        <a href=""#"">Yoga Courses</a>
 ");
                WriteLiteral(@"                       <a href=""#"">Dumbell Class</a>
                        <a href=""#"">Spinning Class</a>
                        <a href=""#"">Kangoo Jump Class</a>
                    </section>
                </article>
                <article class=""contacts"">
                    <h6>Contacts</h6>
                    <section>
                        <p class=""label"">Address</p>
                        <p class=""value"">Berlin Osdorfer Str. 100</p>
                    </section>
                    <section>
                        <p class=""label"">Phone</p>
                        <p class=""value"">+49 123 456 789</p>
                    </section>
                    <section>
                        <p class=""label"">Email</p>
                        <p class=""value"">karadzhov@localhost.com</p>
                    </section>
                </article>
            </section>
            <section class=""site-credentials"">
                &copy; Coded & Designed with <i class=""far fa-");
                WriteLiteral("heart\"></i> by <span class=\"author\">E.Karadzhov</span>\r\n            </section>\r\n        </section>\r\n    </footer>\r\n    ");
#nullable restore
#line 109 "C:\Users\Enes\source\repos\Fitness2You\Fitness2You\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
