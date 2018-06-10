<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JJ.Framework.Mvc.TestViews.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.ViewModels" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.Views" %>

<li>
    <%: Model.Name %> (<%: Model.ID %>)

    <ul>

        <% foreach (ItemViewModel child in Model.Children) { %>

            <% Html.RenderPartial(ViewNames._DetailsItem, child); %>

        <% } %>

    </ul>
</li>