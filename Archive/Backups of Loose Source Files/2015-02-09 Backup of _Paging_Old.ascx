<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PagingViewModel>" %>

<%--<table>
    <tr>

        <% if (Model.CanGoToFirstPage) { %>
            <td>&lt;&lt;</td>
        <% } %>

        <% if (Model.CanGoToPreviousPage) { %>
            <td>&lt;</td>
        <% } %>

        <% for (int i = 0; i < Model.PageIndex - 1; i++) { %>
           <td><%=i%></td>    
        <% } %>

        <td><strong><%=Model.PageIndex%></strong> </td>

        <% for (int i = Model.PageIndex + 1; i <= Model.PageCount; i++) { %>
           <td><%=i%></td>
        <% } %>

        <% if (Model.CanGoToNextPage) { %>
            <td>&gt;</td>
        <% } %>

        <% if (Model.CanGoToLastPage) { %>
            <td>&gt;&gt;</td>
        <% } %>

    </tr>
</table>--%>
