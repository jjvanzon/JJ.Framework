<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<JJ.Framework.Mvc.TestViews.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.Controllers" %>
<%@ Import Namespace="JJ.Framework.Mvc.TestViews.Views" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <div>
        <ul>
            <% Html.RenderPartial(ViewNames._DetailsItem); %>
        </ul>
    </div>

    <div>
        <%: Html.ActionLink("Edit", ActionNames.Edit, new { id = Model.ID })%>
    </div>
</body>
</html>
