<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="estudiante_s.aspx.cs" Inherits="AppEscuela.Vistas.estudiante_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <asp:GridView ID="GridEstudiantes" runat="server" AutoGenerateColumns="False" OnRowCommand="GridEstudiantes_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/images/pencil.png" Height="20px" Width="20px" CommandName="Editar" CommandArgument='<%# Eval("Matricula") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/trash-can.png" Height="20px" Width="20px" CommandName="Eliminar" CommandArgument='<%# Eval("Matricula") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Matrícula" DataField="Matricula" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
            <asp:BoundField HeaderText="Semestre" DataField="Semestre" />
            <asp:BoundField HeaderText="Facultad" DataField="nombreFacultad" />
        </Columns>
    </asp:GridView>
</asp:Content>
