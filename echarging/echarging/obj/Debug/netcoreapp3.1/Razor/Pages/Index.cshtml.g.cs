#pragma checksum "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f46c9b5411a7d6d0885fef45a34389394d029506"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(echarging.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace echarging.Pages
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
#line 1 "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\_ViewImports.cshtml"
using echarging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f46c9b5411a7d6d0885fef45a34389394d029506", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77de4dcc947245d66daa5472654ada23538eb281", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Win", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\Index.cshtml"
   ViewData["Title"] = "Home page"; 

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f46c9b5411a7d6d0885fef45a34389394d0295065079", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n");
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
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://unpkg.com/leaflet@1.7.1/dist/leaflet.css\"\r\n      integrity=\"sha512-xodZBNTC5n17Xt2atTPuE1HxjVMSvLVW9ocqUKLsCC5CXdbqCmblAshOMAS6/keqq/sMZMZ19scR4PsZChSR7A==\"");
            BeginWriteAttribute("crossorigin", "\r\n      crossorigin=\"", 303, "\"", 324, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n<script src=\"https://unpkg.com/leaflet@1.7.1/dist/leaflet.js\"\r\n        integrity=\"sha512-XQoYMqMTK8LvdxXYG3nZ448hOEQiglfqkJs1NOQV44cWnUrBc8PkAOcXy20w0vlaXaVUearIOBhiXZ5V3ynxwA==\"");
            BeginWriteAttribute("crossorigin", "\r\n        crossorigin=\"", 510, "\"", 533, 0);
            EndWriteAttribute();
            WriteLiteral(@"></script>

<!-- vi kalder scriptet her. Det er placeret i wwwroot/js/location.js, for at asp.net kan finde ud af det.-->
<script src=""/js/location.js""></script>
<script src=""/js/requeststart.js""></script>
<script src=""/js/requestdest.js""></script>

<style>

    #mapid {
        width: 100vw;
        height: 100vh;
        position: relative;
    }

    .formBlock {
        max-width: 300px;
        background-color: #fff;
        border: 1px solid #ddd;
        position: absolute;
        top: 10px;
        left: 10px;
        padding: 10px;
        z-index: 999;
        box-shadow: 0 1px 5px rgba(0,0,0,0.65);
        border-radius: 5px;
        width: 100%;
    }

    .input {
        padding: 10px;
        margin-bottom: 5px;
        width: 100%;
        border: 1px solid #ddd;
        font-size: 15px;
        border-radius: 3px;
    }

    .leaflet-top .leaflet-control {
        margin-top: 175px;
    }
</style>


<div class=""col-6"">
    <div class=""formBlock"">");
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f46c9b5411a7d6d0885fef45a34389394d0295067875", async() => {
                WriteLiteral("\r\n            <input type=\"text\" name=\"startposition\" class=\"input\" id=\"startposition\" placeholder=\"Startposition\" />\r\n            <input type=\"text\" name=\"destination\" class=\"input\" id=\"destination\" placeholder=\"Destination\" />\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f46c9b5411a7d6d0885fef45a34389394d0295068397", async() => {
                    WriteLiteral("Find rute ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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




<div class=""embed-responsive embed-responsive"">

    <!-- div ""kontrollerer"" vores kort-->
    <div id=""mapid""> </div>

    <!-- Dette script laver vores kort.-->
    <script>
        var mymap = L.map('mapid').setView([55.6760968, 12.5683371], 13);
        L.tileLayer('https://api.mapbox.com/styles/v1/mapbox/emerald-v8/tiles/{z}/{x}/{y}?access_token=pk.eyJ1Ijoia2FzcGVybW0iLCJhIjoiY2tscjN4NzBvMTh6YzJwcW1seXF3bThzdSJ9.UZQ-RnJeT5bZhmA10CsQJQ', {
            attribution: '© <a href=""https://www.mapbox.com/map-feedback/"">Mapbox</a> © <a href=""http://www.openstreetmap.org/copyright"">OpenStreetMap</a>'
        }).addTo(mymap);
        // vi laver et layer, som er baseret på vores punkter i .js filen. chargers er variablen for alle punkterne
        L.geoJson(chargers, {
                style: function (feature) {
                    return {color: feature.properties.color};
                },
                onEachFeature: function (feature, layer) {
                  ");
            WriteLiteral(@"  layer.bindPopup(""<b>"" + ""Adresse: "" + ""</b>"" + feature.properties.vejnavn + "" "" + feature.properties.husnr + ""<br>"" + ""<b>"" + ""Udbyder: "" + ""</b>""
                    + feature.properties.operator + ""<br>"" + ""<b>"" + ""Effekt: "" + ""</b>"" + feature.properties.ladestandertype);
                },
        }).addTo(mymap);
");
#nullable restore
#line 91 "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\Index.cshtml"
         if(ViewData.ContainsKey("destination") && ViewData.ContainsKey("startposition"))
        {
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                console.log(\'set\');\r\n                getCoordinates(\'");
#nullable restore
#line 95 "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\Index.cshtml"
                           Write(ViewData["startposition"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').then(coordinates => L.marker(coordinates).addTo(mymap));\r\n                getCoordinates(\'");
#nullable restore
#line 96 "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\Index.cshtml"
                           Write(ViewData["destination"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').then(coordinates => L.marker(coordinates).addTo(mymap));\r\n            ");
#nullable restore
#line 97 "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\Index.cshtml"
                   
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        var routeDatter = JSON.parse(");
#nullable restore
#line 99 "C:\Users\Kasper\Desktop\echarging\echarging\echarging\Pages\Index.cshtml"
                                Write(Json.Serialize(ViewData["route"]));

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n        if (routeDatter) {\r\n            // tegn routeDatter her\r\n            L.geoJSON(routeDatter).addTo(mymap);\r\n\r\n            console.log();\r\n\r\n\r\n        }\r\n    </script>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
