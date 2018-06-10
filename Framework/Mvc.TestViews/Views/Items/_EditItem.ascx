<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<JJ.Framework.Mvc.TestViews.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.Helpers" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.ViewModels" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.Views" %>

<li>
    <%: Html.TextBoxFor(x => x.Name) %> (<%: Model.ID %>)

    <ul>

        <% foreach (ItemViewModel child in Model.Children) { %>

            <% using (Html.BeginCollectionItem(PropertyNames.Children)) { %>

                <% Html.RenderPartial(ViewNames._EditItem, child); %>

            <% } %>

        <% } %>

    </ul>
</li>