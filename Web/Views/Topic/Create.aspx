﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Web.Models.Topic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        $('#Colour').ColorPicker({
            onSubmit: function (hsb, hex, rgb) {
                $('#Colour').val(hex);
            },
            onBeforeShow: function () {
                $(this).ColorPickerSetColor(this.value);
            }
        })
        .bind('keyup', function () {
            $(this).ColorPickerSetColor(this.value);
        });
    });
</script>


	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Colour) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Colour) %>
                <%: Html.ValidationMessageFor(model => model.Colour) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

