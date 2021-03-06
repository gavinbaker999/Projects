#pragma checksum "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\Shared\MainApplication.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2e31bad8e8c67107a623a054e38b867f1f66bb7"
// <auto-generated/>
#pragma warning disable 1591
namespace EHSControlPanel.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using GraphQL.Client.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using GraphQL.Client.Serializer.Newtonsoft;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using EHSControlPanel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\_Imports.razor"
using EHSControlPanel.Shared;

#line default
#line hidden
#nullable disable
    public partial class MainApplication : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "alert alert-secondary mt-4");
            __builder.AddAttribute(2, "role", "alert");
            __builder.OpenElement(3, "strong");
            __builder.AddContent(4, 
#nullable restore
#line 2 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\Shared\MainApplication.razor"
             Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 4 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\Shared\MainApplication.razor"
     if (ehsApiVersion == null)
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(5, "<p><em>Loading...</em></p>");
#nullable restore
#line 7 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\Shared\MainApplication.razor"
    } else {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "p");
            __builder.AddContent(7, "EHS API Version:");
            __builder.AddContent(8, 
#nullable restore
#line 8 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\Shared\MainApplication.razor"
                            ehsApiVersion

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 9 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\Shared\MainApplication.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "C:\Users\Gavin\development\publicprojects\Projects\dotNET_Projects\EHSControlPanel\Shared\MainApplication.razor"
       
    // Demonstrates how a parent component can supply parameters
    [Parameter]
    public string Title { get; set; }

    private string ehsApiVersion = null;

    public class ResponseType {
        public string version {get;set;}
    }

    protected override async Task OnInitializedAsync()
    {
        // To use NewtonsoftJsonSerializer, add a reference to NuGet package GraphQL.Client.Serializer.Newtonsoft
        var graphQLClient = new GraphQLHttpClient("https://ehsapi.herokuapp.com/api", new NewtonsoftJsonSerializer());

        var versionRequest = new GraphQL.GraphQLRequest {
            Query = @"
            {
	            version
            }"
        };

        var graphQLResponse = await graphQLClient.SendQueryAsync<ResponseType>(versionRequest);
        ehsApiVersion = graphQLResponse.Data.version;
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
