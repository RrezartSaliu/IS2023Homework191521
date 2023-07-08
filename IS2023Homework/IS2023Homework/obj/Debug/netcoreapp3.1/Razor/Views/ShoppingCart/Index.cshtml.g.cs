#pragma checksum "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3aa33bb090102a045799e9d5d6bb43c99f271585"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCart_Index), @"mvc.1.0.view", @"/Views/ShoppingCart/Index.cshtml")]
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
#line 1 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\_ViewImports.cshtml"
using IS2023Homework;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\_ViewImports.cshtml"
using IS2023Homework.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3aa33bb090102a045799e9d5d6bb43c99f271585", @"/Views/ShoppingCart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d69e53153ec53440b2ea0c69fe2fdb5b559720d6", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ShoppingCart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IS2023Homework.Domain.DTO.ShoppingCartDto>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Shopping cart</h1>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
 if (Model.TicketsInShoppingCart.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<h5>No tickets on shopping cart</h5>\r\n");
#nullable restore
#line 8 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
}
else{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"	<div class=""row"">
		<div class=""form-group"">
			<a href=""/ShoppingCart/OrderNow"" class=""btn btn-warning"">Order Now</a>
		</div>
	</div>
<table class=""table"">
	<thead>
		<tr>
			<th class=""col-md-1"">
				#
			</th>
			<th class=""col"">
				Movie Name
			</th>
			<th class=""col"">
				Quantity
			</th>
			<th class=""col"">
				Ticket price
			</th>
			<th>

			</th>
		</tr>
	</thead>
	<tbody>
");
#nullable restore
#line 36 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
          
			var i = 1;
			foreach (var item in Model.TicketsInShoppingCart)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 42 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
                    Write(i++);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 45 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
                   Write(item.Ticket.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 48 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
                   Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 51 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
                   Write(item.Ticket.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t<a class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 907, "\"", 966, 2);
            WriteAttributeValue("", 914, "/ShoppingCart/DeleteFromShoppingCart/", 914, 37, true);
#nullable restore
#line 54 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
WriteAttributeValue("", 951, item.Ticket.Id, 951, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete </a>\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 57 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
			}
		

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n\t<tfoot>\r\n\t\t<tr>\r\n\t\t\t<th>\r\n\t\t\t\tTotal: \r\n\t\t\t</th>\r\n\t\t\t<th></th>\r\n\t\t\t<th></th>\r\n\t\t\t<th></th>\r\n\t\t\t<th>");
#nullable restore
#line 68 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
           Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\t\t</tr>\r\n\t</tfoot>\r\n</table>\r\n");
#nullable restore
#line 72 "C:\Users\saliu\source\repos\IS2023Homework\IS2023Homework\Views\ShoppingCart\Index.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IS2023Homework.Domain.DTO.ShoppingCartDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591