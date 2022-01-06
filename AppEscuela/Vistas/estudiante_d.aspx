﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="estudiante_d.aspx.cs" Inherits="AppEscuela.Vistas.estudiante_d" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <table>
        <tr>
            <td>Matricula::</td>
            <td>
                <asp:Label ID="lblMatricula" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>Nombre:</td>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>Fecha de Nacimiento:</td>
            <td>
                <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>Semestre:</td>
            <td>
                <asp:Label ID="lblSemestre" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>Facultad:</td>
            <td>
                <asp:DropDownList ID="ddlFacultad" runat="server" Enabled="false"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
