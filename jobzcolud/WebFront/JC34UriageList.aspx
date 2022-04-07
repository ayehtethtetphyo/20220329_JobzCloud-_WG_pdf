﻿<%@ Page Language="C#" MasterPageFile="~/WebFront/JC99NavBar.Master" AutoEventWireup="true" CodeBehind="JC34UriageList.aspx.cs" Inherits="jobzcolud.WebFront.JC34UriageList" ValidateRequest ="False"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        
        <link href="../Content/bootstrap.min.css" rel="stylesheet" />
        <script src="../Scripts/bootstrap.bundle.min.js"></script>

        <%--<script src="../Scripts/colResizable-1.6.min.js"></script>--%>
        <asp:PlaceHolder runat="server">
            <%: Scripts.Render("~/bundles/modernizr") %>
            <%: Styles.Render("~/style/StyleBundle1") %>
            <%: Scripts.Render("~/scripts/ScriptBundle1") %>
            <%: Styles.Render("~/style/UCStyleBundle") %>
        </asp:PlaceHolder>
        <title></title>

       <%-- <script type="text/javascript">
            $(function () {
    </script>--%>
          </head>
    <body>
        
        <%-- <asp:PlaceHolder runat="server">
         <asp:UpdatePanel ID="updBody" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
        <div class="container-fluid">
            <div style="margin-top: 30px;"></div>

            <div class="container-fluid bg-white JC34UriageListDiv" id="Div_UriageList" runat="server">
                <div class="d-flex justify-content-center align-content-center mt-4">
                    <%--<div style="overflow-x: auto;width:auto;overflow:hidden;">--%>
                    <asp:Label ID="lblLoginUserCode" runat="server" Text="" Visible="false"/>
                    <asp:Label ID="lblLoginUserName" runat="server" Text="" Visible="false"/>
                    <div class="JC34UriageKensakuDiv" style="margin-top:20px;">
                         <asp:UpdatePanel ID="updbound" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                       <%-- </div>--%>

                </div>
                
                <div class="row" runat="server" >
                    <div class="col-sm-8"></div>
                    <div class="container-fluid bg-white">
                        
                        <asp:UpdatePanel ID="updJoken" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="JC34KensakuJoken">
                                    <asp:Label ID="LB_Jouken" runat="server" Text="検索条件" Font-Size="15px" Font-Bold="true" ></asp:Label>
                                    
                                    <asp:Table ID="TB_SentakuJouken" runat="server" Style="margin-top: 2px;" >
                                        <asp:TableRow>
                                            <asp:TableCell ID="TC_Jouken" runat="server">  
                                              <%--<asp:Button ID="btnJokenCross" runat="server" Text="Button" OnClick="btnJokenCross_Click" style="display:none;" CssClass="JC12JokenCross"/>--%>

                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                            
                    </div>
                   
                    <div class="container-fluid bg-white" align="right">
                </div>

                
               <%--<div id="LargeImageContainerDiv" style="position: absolute;bottom:30px; z-index:2"></div>--%>
                <div id="Div6" runat="server"  class="d-flex justify-content-center mt-3 mb-3" >
                    <asp:UpdatePanel ID="updUriageSyohinGrid" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                       <%--<div class="d-flex justify-content-center" style="background-color: white; padding: 0px 10px 0px 10px;">--%>
                    <div style="overflow-x: auto;width:auto;" id="Div7" >
                   <%-- <asp:UpdatePanel ID="updUriageSyohinGrid" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                                <asp:GridView runat="server" ID="GV_Uriage" BorderColor="Transparent"  AutoGenerateColumns="false" EmptyDataRowStyle-CssClass="JC10NoDataMessageStyle" AllowPaging="true"  AllowSorting="True" OnSorting="GV_Uriage_Sorting" OnRowCreated="GV_Uriage_RowCreated"
                                    ShowHeader="true" ShowHeaderWhenEmpty="true" RowStyle-CssClass="GridRow"  CellPadding="0" AlternatingRowStyle-Wrap="True" RowStyle-BorderStyle="NotSet" CssClass="GridView1" ClientIDMode="Static"  OnPageIndexChanging="OnPageIndexChanging"  visible="True" OnRowDataBound="GV_Uriage_RowDataBound" OnRowCommand="GV_Uriage_RowCommand" DataKeyNames="売上コード" PagerSettings-Visible="False">
                                   <%--<PagerSettings Position="Bottom" Visible="False" /> 
                                    <PagerStyle horizontalalign="Center" CssClass="JC27gridPager"/>--%>
                                    <%--<PagerStyle CssClass="GridPager1" />--%>
                                    <%--<PagerSettings  Mode="NumericFirstLast" FirstPageText="&lt;"  LastPageText="&gt;" />--%>
                                    <EmptyDataRowStyle CssClass="JC30NoDataMessageStyle" />
                                    <HeaderStyle Height="37px" BackColor="#F2F2F2" />
                                    <RowStyle CssClass="JC34GridItem" Height="37px" />
                                    <EmptyDataTemplate>
                                     該当するデータがありません。
                                   </EmptyDataTemplate>
                                    <%--<SelectedRowStyle BackColor="#EBEBF5" />--%>
                                    
                                    <Columns>
                                         
                                    </Columns>
                                       
                                  <%-- <PagerStyle cssClass="gridpager" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                               </div>
                           <%--</div>--%>
                                <asp:GridView runat="server" ID="GV_Uriage_Original" BorderColor="Transparent" AutoGenerateColumns="false" EmptyDataRowStyle-CssClass="JC10NoDataMessageStyle"
                                    ShowHeader="true" ShowHeaderWhenEmpty="true" CellPadding="0" AllowPaging="True" EnableViewState="false" Visible="false" PageSize="20" >
                                    <EmptyDataRowStyle CssClass="JC10NoDataMessageStyle" />
                                    <HeaderStyle Height="38px" BackColor="#F2F2F2" HorizontalAlign="Left"/>
                                   <%-- <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="<" LastPageText=">"/> 
                                    <PagerStyle horizontalalign="Center" CssClass="gridPager cssPager"/>--%>
                                    <%--<EmptyDataRowStyle CssClass="JC10NoDataMessageStyle" />--%>
                                    <RowStyle CssClass="JC34GridItem" Height="37px" />
                                   <%-- <SelectedRowStyle BackColor="#EBEBF5" />--%>
                                    <Columns>
                                        
                                          <%--<asp:TemplateField HeaderStyle-CssClass="JC28DropDownCol">
                                             <ItemTemplate> 
                                                 <div class="grip" style="display:flex; align-content:center;align-items:center;align-items: center;justify-content: center;min-width:30px; overflow: hidden;">
                                                <div class="dropdown" style="position:absolute;">
                                              <button class="btn dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" 
                                                  aria-haspopup="true" aria-expanded="false" style="border:1px solid gainsboro;width:20px; height:20px;padding:0px 3px 0px 1px;margin:0;">--%>
                                            <asp:TemplateField HeaderStyle-Width="30px">
                                            <ItemTemplate>   
                                                 <div class="grip" style="display:flex; align-content:center;align-items:center;align-items: center;justify-content: center;min-width:30px; overflow: hidden;">
                                              <div class="dropdown" style="position:absolute;">
                                                  <button class="btn dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" 
                                                      aria-haspopup="true" aria-expanded="false" style="border:1px solid gainsboro;width:20px; height:20px;padding:0px 3px 0px 1px;margin:0; z-index:200;">
                                    
                                              </button>
                                                    <asp:Button ID="BT_DeleteOk" runat="server" Text="はい" class="BlueBackgroundButton DisplayNone" Width="100px" Height="36px" OnClick="BT_DeleteOk_Click" />
                                                    <asp:Button ID="BT_DeleteCancel" runat="server" Text="キャンセル" class="JC09GrayButton DisplayNone" Width="100px" Height="36px" />
                    
                                              <div class="dropdown-menu fontcss" aria-labelledby="dropdownMenuButton">
                                                  <asp:LinkButton ID="LKB_UriageEdit" class="dropdown-item" runat="server" Text='編集' style="margin-right:10px" CommandName="Update" CommandArgument="<%# Container.DataItemIndex %>" OnClick="LKB_UriageEdit_Clicked" ></asp:LinkButton>
                                                  <%--<asp:LinkButton ID="LKB_UriageCopy" class="dropdown-item" runat="server" Text='コピーして登録' style="margin-right:10px" CommandName="Copy" CommandArgument="<%# Container.DataItemIndex %>" OnClick="LKB_UriageCopy_Clicked"></asp:LinkButton>--%>
                                                  <asp:LinkButton ID="LKB_UriagePDF" class="dropdown-item" runat="server" Text='兼請求書PDF出力' style="margin-right:10px" CommandName="PDF" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
                                                  <asp:LinkButton ID="lnkbtnMitsuDelete" class="dropdown-item" runat="server" Text='削除' style="margin-right:10px" CommandName="Delete" CommandArgument="<%# Container.DataItemIndex %>" OnClick="LKB_UriageDelete_Clicked" autopostback="true"></asp:LinkButton>                                        
                                              </div>
                                            </div>
                                                     </div>
                                        </ItemTemplate>
                                              <HeaderStyle />
                                             <%-- <ItemStyle Width="25px" />--%>
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28CodeCol" HeaderStyle-CssClass="JC28CodeHeaderCol">
                                            <ItemTemplate>
                                                <%--<asp:TextBox ID="txtcSYOHIN" runat="server" Text=' <%# Bind("cSYOHIN","{0}") %>' Width="91px" Height="25px" MaxLength="10" CssClass="form-control TextboxStyle JC10GridTextBox" autocomplete="off" AutoPostBack="true"></asp:TextBox>--%>
                                                <%--<asp:LinkButton ID="LKB_cUriage" runat="server" Text=' <%# Bind("売上コード","{0}") %>' CssClass="d-inline-block font" Width="89px" Font-Underline="false" OnClick="LKB_uriagecode_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LKB_cUriage1" runat="server" Text="売上コード" CssClass="d-inline-block" ></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />
                                            <ItemStyle CssClass="JC28CodeCol" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="売上コード" SortExpression="売上コード" HeaderStyle-Width="89px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                            <div class="grip" style="min-width: 89px; text-align: left; overflow: hidden; padding-right: 4px; white-space: nowrap; text-overflow: ellipsis; display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:LinkButton ID="LKB_cUriage" runat="server" Text=' <%# Bind("売上コード","{0}") %>' CssClass="d-inline-block font" Width="89px" Font-Underline="false" OnClick="LKB_uriagecode_Click" ></asp:LinkButton>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>

                                         <%--<asp:TemplateField ItemStyle-CssClass="JC28CodeCol" HeaderStyle-CssClass="JC28CodeHeaderCol">
                                            <ItemTemplate>
                                                <asp:Label ID="LB_cMitsumori" runat="server" Text=' <%# Bind("見積コード","{0}") %>' CssClass="d-inline-block" Width="89px"></asp:Label>--%>
                                               <%-- <asp:LinkButton ID="LKB_cMitsumori" runat="server" Text=' <%# Bind("見積コード","{0}") %>' CssClass="d-inline-block font" Width="89px" Font-Underline="false" OnClick="LKB_mitsumoricode_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_cMitsumori1" runat="server" Text="見積コード" CssClass="d-inline-block" ></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />
                                            <ItemStyle CssClass="JC28CodeCol" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="見積コード" SortExpression="見積コード" HeaderStyle-Width="89px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                            <div class="grip" style="min-width: 89px; text-align: left; overflow: hidden; padding-right: 4px; white-space: nowrap; text-overflow: ellipsis; display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:LinkButton ID="LKB_cMitsumori" runat="server" Text=' <%# Bind("見積コード","{0}") %>' CssClass="d-inline-block font" Width="89px" Font-Underline="false" OnClick="LKB_mitsumoricode_Click" ></asp:LinkButton>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28NameCol" HeaderStyle-CssClass="JC28NameHeaderCol">
                                            <ItemTemplate>
                                                <div class="JC12LabelItem" style="width:150px;height:35px; ">
                                                <asp:Label ID="LB_sSeikyusaki" runat="server" Text=' <%# Bind("請求先名","{0}") %>' ToolTip='<%# Bind("請求先名","{0}") %>' style="text-align:left;width:150px;"></asp:Label>
                                             </div>
                                           </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_sSeikyusaki1" runat="server" Text="請求先名" CssClass="d-inline-block" Width="125px"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28NameHeaderCol" />
                                            <ItemStyle CssClass="JC28NameCol" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="請求先名" SortExpression="請求先名" HeaderStyle-Width="150px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:150px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="LB_sSeikyusaki" runat="server" Text=' <%# Bind("請求先名","{0}") %>' ToolTip='<%# Bind("請求先名","{0}") %>' style="text-align:left;"></asp:Label>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>

                                       <%-- <asp:TemplateField ItemStyle-CssClass="JC28NameCol" HeaderStyle-CssClass="JC28NameHeaderCol">
                                            <ItemTemplate>
                                                <div class="JC12LabelItem" style="width:150px;height:35px; ">
                                                 <asp:Label ID="LB_sTokuisaki" runat="server" Text=' <%# Bind("得意先名","{0}") %>' ToolTip='<%# Bind("得意先名","{0}") %>' style="text-align:left;width:150px;"></asp:Label>
                                            </div>
                                             </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_sTokuisaki1" runat="server" Text="得意先名" CssClass="d-inline-block" Width="125px"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28NameHeaderCol" />
                                            <ItemStyle CssClass="JC28NameCol" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="得意先名" SortExpression="得意先名" HeaderStyle-Width="150px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:150px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="LB_sTokuisaki" runat="server" Text=' <%# Bind("得意先名","{0}") %>' ToolTip='<%# Bind("得意先名","{0}") %>' style="text-align:left;"></asp:Label>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28NameCol" HeaderStyle-CssClass="JC28NameHeaderCol">
                                            <ItemTemplate>
                                                <div class="JC12LabelItem" style="width:150px;height:35px;">
                                                <asp:Label ID="lblcSyohin1" runat="server" Text='<%# Server.HtmlEncode((string)Eval("売上件名","{0}"))%>' ToolTip='<%# Bind("売上件名","{0}") %>' style="text-align:left;width:150px;"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblcSyohin" runat="server" Text="売上件名" CssClass="d-inline-block" Width="150px"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28NameHeaderCol" />
                                            <ItemStyle CssClass="JC28NameCol" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="売上件名" SortExpression="売上件名" HeaderStyle-Width="150px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:150px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="lblcSyohin1" runat="server" Text='<%# Server.HtmlEncode((string)Eval("売上件名","{0}"))%>' ToolTip='<%# Bind("売上件名","{0}") %>' style="text-align:left;"></asp:Label>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28NameCol" HeaderStyle-CssClass="JC28NameHeaderCol">
                                            <ItemTemplate>
                                                <div class="JC12LabelItem" style="width:150px;height:35px;">
                                                <asp:Label ID="LB_Eigyoutantousha" runat="server" Text='<%# Server.HtmlEncode((string)Eval("営業担当者","{0}"))%>' ToolTip='<%# Bind("営業担当者","{0}") %>' style="text-align:left;width:150px;"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_Eigyoutantousha1" runat="server" Text="営業担当者" CssClass="d-inline-block"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28NameHeaderCol" />
                                            <ItemStyle CssClass="JC28NameCol" />
                                        </asp:TemplateField>--%>

                                         <asp:TemplateField HeaderText="営業担当者" SortExpression="営業担当者" HeaderStyle-Width="150px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:150px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="LB_Eigyoutantousha" runat="server" Text='<%# Server.HtmlEncode((string)Eval("営業担当者","{0}"))%>' ToolTip='<%# Bind("営業担当者","{0}") %>' style="text-align:left;"></asp:Label>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol"  />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28CodeCol" HeaderStyle-CssClass="JC28CodeHeaderCol">
                                            <ItemTemplate>
                                                <asp:Label ID="Lb_UriageDate" runat="server" Text=' <%# Bind("売上日","{0}") %>' CssClass="d-inline-block" Width="125px"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="Lb_UriageDate1" runat="server" Text="売上日" CssClass="d-inline-block"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />
                                            <ItemStyle CssClass="JC28CodeCol" />
                                        </asp:TemplateField>--%>

                                         <asp:TemplateField HeaderText="売上日" SortExpression="売上日" HeaderStyle-Width="125px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:125px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="Lb_UriageDate" runat="server" Text=' <%# Bind("売上日","{0}") %>' CssClass="d-inline-block"></asp:Label>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28KingakuCol" HeaderStyle-CssClass="JC28KingakuHeaderCol">
                                            <ItemTemplate>
                                                <div class="JC12LabelItem" style="width:110px;height:35px;">
                                                <asp:Label ID="LB_kingaku" runat="server" Text=' <%# Bind("売上金額","{0}") %>' ToolTip='<%# Bind("売上金額","{0}") %>' style="text-align:left;width:110px;"></asp:Label> 
                                                 </div>
                                                    </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_kingaku1" runat="server" Text="売上金額" CssClass="d-inline-block"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28KingakuHeaderCol" />
                                            <ItemStyle CssClass="JC28KingakuCol" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="売上金額" SortExpression="売上金額" HeaderStyle-Width="110px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:110px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="LB_kingaku" runat="server" Text=' <%# Bind("売上金額","{0}") %>' ToolTip='<%# Bind("売上金額","{0}") %>' style="text-align:left;"></asp:Label> 
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol"  />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28JoutaiCol" HeaderStyle-CssClass="JC28JoutaiHeaderCol">
                                            <ItemTemplate>
                                                <asp:Label ID="LB_joutai" runat="server" Text=' <%# Bind("売上状態","{0}") %>' CssClass="d-inline-block"></asp:Label>                                              
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_joutai1" runat="server" Text="売上状態" CssClass="d-inline-block"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28JoutaiHeaderCol" />
                                            <ItemStyle CssClass="JC28JoutaiCol" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="売上状態" SortExpression="売上状態" HeaderStyle-Width="80px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:75px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="LB_joutai" runat="server" Text=' <%# Bind("売上状態","{0}") %>' CssClass="d-inline-block"></asp:Label>  
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>

                                        <%--<asp:TemplateField ItemStyle-CssClass="JC28NameCol" HeaderStyle-CssClass="JC28NameHeaderCol">
                                            <ItemTemplate>
                                             <div class="JC12LabelItem" style="width:125px;height:35px;">
                                                <asp:Label ID="LB_memo" runat="server" Text='<%# Server.HtmlEncode((string)Eval("売上社内メモ","{0}"))%>' ToolTip='<%# Bind("売上社内メモ","{0}") %>' style="text-align:left;width:125px;"></asp:Label>
                                            </div>
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:Label ID="LB_memo1" runat="server" Text="売上社内メモ" CssClass="d-inline-block"></asp:Label>
                                            </HeaderTemplate>
                                            <HeaderStyle CssClass="JC28NameHeaderCol" />
                                            <ItemStyle CssClass="JC28NameCol " />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="売上社内メモ" SortExpression="売上社内メモ" HeaderStyle-Width="125px" HeaderStyle-ForeColor="Black">
                                        <ItemTemplate>
                                              <div class="grip" style="min-width:125px;text-align: left; padding-right: 4px;padding-left:2px;overflow: hidden;  display: -webkit-box;  -webkit-line-clamp: 1; -webkit-box-orient: vertical;word-break: break-all;">
                                                <asp:Label ID="LB_memo" runat="server" Text='<%# Server.HtmlEncode((string)Eval("売上社内メモ","{0}"))%>' ToolTip='<%# Bind("売上社内メモ","{0}") %>' style="text-align:left;"></asp:Label>
                                                
                                            </div>
                                        </ItemTemplate>
                                            <HeaderStyle CssClass="JC28CodeHeaderCol" />

                                        </asp:TemplateField>
                                                  
                                    </Columns>
                                </asp:GridView>
                              <div style="padding-bottom: 12px;">
                                <asp:GridView runat="server" ID="GridView1" BorderColor="Transparent" AutoGenerateColumns="true" EmptyDataRowStyle-CssClass="JC31NoDataMessageStyle"
                                            ShowHeader="false" ShowHeaderWhenEmpty="true" CellPadding="0" AllowPaging="True" PageSize="20" OnPageIndexChanging="OnPageIndexChanging"
                                             OnRowDataBound="GV_UriagePg_Original_RowDataBound" DataKeyNames="売上コード" Visible="True" CssClass="GridView1">
                                             
                                            <RowStyle CssClass="JC34GridItem" Height="37px" />
                                            <PagerStyle Font-Size="14px" HorizontalAlign="Center" CssClass="JC27gridPager" VerticalAlign="Middle" />
                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="&lt;" LastPageText="&gt;" />
                                        </asp:GridView>
                                  </div>
                        
                                 
                            </ContentTemplate>
                       
                        </asp:UpdatePanel>
                        </div>
                                           
                   <%--<asp:TextBox ID="TB_Uriage_Code" runat="server" Value="" style="display:none;"></asp:TextBox>
                    <asp:Button ID="BT_Uriage_Display" runat="server" Text="" style="display:none;" OnClick="BT_Uriage_Display_Click" />--%>
                
                <%--<asp:GridView runat="server" ID="GridView1" BorderColor="Transparent" AutoGenerateColumns="true" EmptyDataRowStyle-CssClass="JC31NoDataMessageStyle"
                                            ShowHeader="false" ShowHeaderWhenEmpty="true" CellPadding="0" AllowPaging="True" PageSize="20" OnPageIndexChanging="OnPageIndexChanging"
                                             OnRowDataBound="GV_UriagePg_Original_RowDataBound" DataKeyNames="売上コード" Visible="True" PagerStyle-VerticalAlign="Middle" PagerStyle-HorizontalAlign="Center">
                                             


                                            <RowStyle Height="0px" />
                                            <PagerStyle Font-Size="14px" HorizontalAlign="Center" CssClass="JC27gridPager" VerticalAlign="Middle" />
                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="&lt;" LastPageText="&gt;" />
                                        </asp:GridView>--%>
                    
                        
               <%-- <div id="grid_container">
    <table id="grid"></table>
    <div id="gridpager"></div>
</div>--%>
        <%-- <tr>
        <td colspan="7">
            <table>
            <tr class="JC27gridPager " >
                <td class="align-content-center"><span>1</span></td><td><a href="javascript:__doPostBack(&#39;ctl00$body$GV_Uriage&#39;,&#39;Page$2&#39;)">2</a></td><td><a href="javascript:__doPostBack(&#39;ctl00$body$GV_Uriage&#39;,&#39;Page$3&#39;)">3</a></td>
           </tr>
        </table>
        </td>
    </tr>--%>
                
                <asp:Button ID="BT_DateChange" runat="server" Text="Button" OnClick="BT_DateChange_Click" style="display:none;"/>
                <asp:Button ID="btnOK" runat="server" Text="OK" class="BlueBackgroundButton DisplayNone" Width="100px" Height="36px" />
                 
                <asp:UpdatePanel ID="upd_Hidden" runat="server" UpdateMode="Conditional" >
                            <Triggers>
                                 <asp:PostBackTrigger ControlID="BT_UriagePDF" />
                            </Triggers>
                             <ContentTemplate>
                         <asp:Button ID="BT_UriagePDF" runat="server" Text="Button" OnClick="BT_UriagePDF_Click" style="display:none;"/>
                        </ContentTemplate>  
                      </asp:UpdatePanel>

            </div>
        </div>
        <asp:HiddenField ID="hdnHome" runat="server" />
        <!--ポップアップ画面-->
        <asp:UpdatePanel ID="updSentakuPopup" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnSentakuPopup" runat="server" Text="Button" CssClass="DisplayNone" />
                <asp:ModalPopupExtender ID="mpeSentakuPopup" runat="server" TargetControlID="btnSentakuPopup"
                    PopupControlID="pnlSentakuPopupScroll" BackgroundCssClass="PopupModalBackground" BehaviorID="pnlSentakuPopupScroll">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlSentakuPopupScroll" runat="server" Style="display: none; overflow-x: hidden; overflow-y: hidden;" CssClass="PopupScrollDiv">
                    <asp:Panel ID="pnlSentakuPopup" runat="server">
                        <iframe id="ifSentakuPopup" runat="server" scrolling="no" class="NyuryokuIframe" style="border-radius: 0px;"></iframe>
                        <asp:Button ID="btnClose" runat="server" Text="Button" Style="display: none" OnClick="btnClose_Click" />
                        <asp:Button ID="btnJishaTantouSelect" runat="server" Text="Button" Style="display: none" OnClick="btnJishaTantouSelect_Click" />
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!--ポップアップ画面-->
                    <asp:UpdatePanel ID="updHyoujiSet" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btnHyoujiSetting" runat="server" Text="Button" style="display:none" />
                            <asp:ModalPopupExtender ID="mpeHyoujiSetPopUp" runat="server" TargetControlID="btnHyoujiSetting"
                                PopupControlID="pnlHyoujiSetPopUpScroll" BehaviorID="pnlHyoujiSetPopUpScroll" BackgroundCssClass="PopupModalBackground"
                                RepositionMode="None">
                            </asp:ModalPopupExtender>
                            <asp:Panel ID="pnlHyoujiSetPopUpScroll" runat="server"  CssClass="n_PopupScrollDiv">
                                <asp:Panel ID="pnlHyoujiSetPopUp" runat="server">
                                    <iframe id="ifpnlHyoujiSetPopUp" runat="server" class="HyoujiSettingIframe"  seamless></iframe>
                                    <asp:Button ID="btnHyoujiClose" runat="server" Text="HyoujiClose" CssClass="DisplayNone" OnClick="btnHyoujiSettingClose_Click" />
                                       <asp:Button ID="btnHyoujiSave" runat="server" Text="HyoujiSave" CssClass="DisplayNone" OnClick="btnHyoujiSettingSave_Click" />
                                </asp:Panel>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

               <!--ポップアップ画面-->

              </ContentTemplate>
         </asp:UpdatePanel>
    </body>
  <link href="../Style/cloudflare-jquery-ui.min.css" rel="stylesheet" />
            function ClickPDFButton()
            {
                document.getElementById("<%=BT_UriagePDF.ClientID %>").click();
            }

            <%--function SetDateFocus() {

            //$(function test() {

            //$(function () {


            //$(function () {
            //    if ($.cookie('colWidthMitsumoriList') != null) {
            //        var columns = $.cookie('colWidthMitsumoriList').split(',');
            //        var i = 0;
            //        $('.GridViewStyle th').each(function () {
            //            $(this).width(columns[i++]);
            //        });
            //    }

            //    $(".GridViewStyle").colResizable({
            //        liveDrag: true,
            //        resizeMode: 'overflow',
            //        postbackSafe: true,
            //        partialRefresh: true,
            //        flush: true,
            //        gripInnerHtml: "<div class='grip'></div>",
            //        draggingClass: "dragging",
            //        onResize: onSampleResized
            //    });

            //});


            //var onSampleResized = function (e) {
            //    var columns = $(e.currentTarget).find("th");
            //    var msg = "";
            //    var date = new Date();
            //    date.setTime(date.getTime() + (60 * 20000));
            //    columns.each(function () {
            //        msg += $(this).width() + ",";
            //    })
            //    $.cookie("colWidthMitsumoriList", msg, { expires: date }); // expires after 20 minutes
            //};

            //var prm = Sys.WebForms.PageRequestManager.getInstance();
            //if (prm != null) {
            //    prm.add_endRequest(function (sender, e) {
            //        if (sender._postBackSettings.panelsToUpdate != null) {
            //            if ($.cookie('colWidthMitsumoriList') != null) {
            //                var columns = $.cookie('colWidthMitsumoriList').split(',');
            //                var i = 0;
            //                $('.GridViewStyle th').each(function () {
            //                    $(this).width(columns[i++]);
            //                });
            //            }


            //            $(".GridViewStyle").colResizable({
            //                liveDrag: true,
            //                resizeMode: 'overflow',
            //                postbackSafe: true,
            //                partialRefresh: true,
            //                flush: true,
            //                gripInnerHtml: "<div class='grip'></div>",
            //                draggingClass: "dragging",
            //                onResize: onSampleResized
            //            });
            //        }
            //    });
            //};

            //$(function () {
            //    if ($.cookie('colWidthUriageList') != null) {
            //        var columns = $.cookie('colWidthUriageList').split(',');
            //        var i = 0;
            //        $('.GridViewStyle th').each(function () {
            //            $(this).width(columns[i++]);
            //        });
            //    }

            //    $(".GridViewStyle").colResizable({
            //        liveDrag: true,
            //        resizeMode: 'overflow',
            //        postbackSafe: true,
            //        partialRefresh: true,
            //        flush: true,
            //        gripInnerHtml: "<div class='grip'></div>",
            //        draggingClass: "dragging",
            //        onResize: onSampleResized
            //    });

            //});


            //var onSampleResized = function (e) {
            //    var columns = $(e.currentTarget).find("th");
            //    var msg = "";
            //    var date = new Date();
            //    //date.setTime(date.getTime() + (60 * 20000));
            //    columns.each(function () {
            //        msg += $(this).width() + ",";
            //    })
            //    $.cookie("colWidthUriageList", msg, { expires: date }); // expires after 20 minutes
            //};


            //var prm = Sys.WebForms.PageRequestManager.getInstance();
            //if (prm != null) {
            //    prm.add_endRequest(function (sender, e) {
            //        if (sender._postBackSettings.panelsToUpdate != null) {
            //            if ($.cookie('colWidthUriageList') != null) {
            //                var columns = $.cookie('colWidthUriageList').split(',');
            //                var i = 0;
            //                $('.GridViewStyle th').each(function () {
            //                    $(this).width(columns[i++]);
            //                });
            //            }


            //            $(".GridViewStyle").colResizable({
            //                liveDrag: true,
            //                resizeMode: 'overflow',
            //                postbackSafe: true,
            //                partialRefresh: true,
            //                flush: true,
            //                gripInnerHtml: "<div class='grip'></div>",
            //                draggingClass: "dragging",
            //                onResize: onSampleResized
            //            });
            //        }
            //    });
            //};

            //$(function () {
            //    if ($.cookie('colWidthUriageList') != null) {
            //        var columns = $.cookie('colWidthUriageList').split(',');
            //        var i = 0;
            //        $('.GridViewStyle th').each(function () {
            //            $(this).width(columns[i++]);
            //        });
            //    }

            //    $(".GridViewStyle").colResizable({
            //        liveDrag: true,
            //        resizeMode: 'overflow',
            //        postbackSafe: true,
            //        partialRefresh: true,
            //        flush: true,
            //        gripInnerHtml: "<div class='grip'></div>",
            //        draggingClass: "dragging",
            //        onResize: onSampleResized
            //    });

            //});


            //var onSampleResized = function (e) {
            //    var columns = $(e.currentTarget).find("th");
            //    var msg = "";
            //    var date = new Date();
            //    date.setTime(date.getTime() + (60 * 20000));
            //    columns.each(function () {
            //        msg += $(this).width() + ",";
            //    })
            //    $.cookie("colWidthUriageList", msg, { expires: date }); // expires after 20 minutes
            //};

            //var prm = Sys.WebForms.PageRequestManager.getInstance();
            //if (prm != null) {
            //    prm.add_endRequest(function (sender, e) {
            //        if (sender._postBackSettings.panelsToUpdate != null) {
            //            if ($.cookie('colWidthUriageList') != null) {
            //                var columns = $.cookie('colWidthUriageList').split(',');
            //                var i = 0;
            //                $('.GridViewStyle th').each(function () {
            //                    $(this).width(columns[i++]);
            //                });
            //            }


            //            $(".GridViewStyle").colResizable({
            //                liveDrag: true,
            //                resizeMode: 'overflow',
            //                postbackSafe: true,
            //                partialRefresh: true,
            //                flush: true,
            //                gripInnerHtml: "<div class='grip'></div>",
            //                draggingClass: "dragging",
            //                onResize: onSampleResized
            //            });
            //        }
            //    });
            //};

          </script>

        $("#GV_Uriage").ejGrid({
            dataSource: window.gridData,
            allowPaging: true,
            pageSettings: { pageSize: 14 }
        });
    });
</html>
</asp:Content>