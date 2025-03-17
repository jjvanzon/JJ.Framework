<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<JJ.OneOff.BeginCollectionItemTest.ViewModels.ItemViewModel>" %>
<%@ Import Namespace="JJ.OneOff.BeginCollectionItemTest.Views" %>
<%@ Import Namespace="JJ.OneOff.BeginCollectionItemTest.Controllers" %>

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
