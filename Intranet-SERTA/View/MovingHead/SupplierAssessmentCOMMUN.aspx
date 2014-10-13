<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/View/Shared/SertaIntra.Master" MaintainScrollPositionOnPostback="true" CodeBehind="SupplierAssessmentCOMMUN.aspx.vb" Inherits="IntranetSerta.SupplierAssessmentCOMMUN" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../App_Themes/Theme/Formulaire.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../../App_Themes/Theme/ModalPopup.css" rel="stylesheet" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- *************** Mise ne place de la ListBox ****************************** --%>
    <div id="CollapseAnimation">
    <div id="ListBox" class="container">
        <%--Gestion des boutons et de la fenetre Modal de confirmation--%>
        <asp:Button ID="btSave" runat="server" CssClass="myButton" Text="Save" />
        <asp:Button ID="btDelete" runat="server" CssClass="myButton" Text="Delete" />
        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" DisplayModalPopupID="ModalPopupExtender1" TargetControlID="btDelete" ></asp:ConfirmButtonExtender>
        <abbr title="Show the report of Supplier">
            <a href="/View/MovingHead/RapportAnalyseRetard.aspx?Supplier=<%= DropDownListSupplier.SelectedValue%>&Quarter=<%= DropDownListTrimestre.SelectedValue%>" target="_blank" class="myButton" ><img src="../../img/ReportIcon.png" style="width:20px"/> Show report</a>     
        </abbr>
        <%----------- START MODAL POPUP CONFIRM DELETE -------------%>
        <div id="ModalPopupDelete">
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlPopup" TargetControlID="btDelete" OkControlID="btnYes"
                CancelControlID="btnNo" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                <div class="header">
                    Confirmation
                </div>
                <div class="body">
                    Do you want delete this Supplier?
                </div>
                <div class="footer">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CausesValidation="false" />
                    <asp:Button ID="btnNo" runat="server" Text="No" />
                </div>
            </asp:Panel>
        </div>
        <%----------- END MODAL POPUP CONFIRM DELETE -------------%>
        <table>
            <thead>
                <tr>
                    <td>Select a supplier
                            <asp:DropDownList ID="DropDownListSupplier" runat="server" AutoPostBack="true" Font-Names="Verdana">
                            </asp:DropDownList>
                    </td>
                    <td>Select a quarter
                            <asp:DropDownList ID="DropDownListTrimestre" runat="server" AutoPostBack="true" Font-Names="Verdana">
                                <asp:ListItem Value="121" Text="2012 Q1" />
                                <asp:ListItem Value="122" Text="2012 Q2" />
                                <asp:ListItem Value="123" Text="2012 Q3" />
                                <asp:ListItem Value="124" Text="2012 Q4" />
                                <asp:ListItem Value="131" Text="2013 Q1" />
                                <asp:ListItem Value="132" Text="2013 Q2" />
                                <asp:ListItem Value="133" Text="2013 Q3" />
                                <asp:ListItem Value="134" Text="2013 Q4" />
                                <asp:ListItem Value="141" Text="2014 Q1" />
                                <asp:ListItem Value="142" Text="2014 Q2" />
                                <asp:ListItem Value="143" Text="2014 Q3" />
                                <asp:ListItem Value="144" Text="2014 Q4" />
                                <asp:ListItem Value="151" Text="2015 Q1" />
                                <asp:ListItem Value="152" Text="2015 Q2" />
                                <asp:ListItem Value="153" Text="2015 Q3" />
                                <asp:ListItem Value="154" Text="2015 Q4" />
                            </asp:DropDownList>
                    </td>
                </tr>
            </thead>
        </table>
        <br />
    </div>
        <%-- **************** Mise en place du formulaire Qualité************************ --%>
        <div>
        <fieldset>
            <legend>Quality</legend>
            <table>
                <thead>
                    <tr>
                        <td></td>
                            <td colspan="2" class="cellule">
                                GROUP

                            </td>
                            <td colspan="2" class="cellule"">
                                PNS
                            </td>
                        <td colspan="2">
                            SERTA

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Value</td>
                        <td class="cellule" style="height: 26px">Point</td>
                        <td>Value</td>
                        <td class="cellule" style="height: 26px">Point</td>
                        <td>Values</td>
                        <td>Point</td>
                    </tr>
                </thead>
                <tr>
                    <td>
                        <span class="Label">PPM level : maximun objective</span>
                        <span class="labelInfo">-2 points per ever 1000PPM</span>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxIndicePPMvalue" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelPPM" runat="server" CssClass="precalcul">N/A</asp:Label>
                    </td>
                    <td class="cellule">
                        <asp:TextBox runat="server" ID="textBoxIndicePPMNote" CssClass="NumberBox"></asp:TextBox>/20<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textBoxIndicePPMvalue" CssClass="Validator" Display="None" ErrorMessage="Champ incorrect :<br /> La valeur doit être un nombre positif." ValidationExpression="^(?=.*[0-9].*$)\d*$"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator1"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxIndicePPMvaluePNS" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelPPMPNS" runat="server" CssClass="precalcul">N/A</asp:Label>

                    </td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxIndicePPMNotePNS" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        /20</td>
                    <td>
                        <asp:TextBox ID="textBoxIndicePPMvalueSERTA" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelPPMSERTA" runat="server" CssClass="precalcul">N/A</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxIndicePPMNoteSERTA" runat="server"  CausesValidation="True" CssClass="NumberBox" Enabled="false"></asp:TextBox>
                        /20</td>
                </tr>
                <tr>
                    <td>
                        <span class="Label">Number of quality problems</span>
                        <span class="labelInfo">5 points per incident</span>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxSinNBValue" runat="server" CssClass="NumberBox" CausesValidation="True"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelQncCount" runat="server" Text="N/A" CssClass="precalcul"></asp:Label>
                    </td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxSinNBPoint" runat="server" CssClass="NumberBox"></asp:TextBox>/20
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="textBoxSinNBValue" CssClass="Validator" Display="None" ErrorMessage="Champ incorrect :<br /> La valeur doit être un nombre positif." ValidationExpression="^(?=.*[0-9].*$)\d*$"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator4"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxSinNBValuePNS" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelQncCountPNS" runat="server" CssClass="precalcul">N/A</asp:Label>
                    </td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxSinNBPointPNS" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        /20</td>
                    <td>
                        <asp:TextBox ID="textBoxSinNBValueSERTA" runat="server" Enabled="false" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelQncCountSERTA" runat="server" CssClass="precalcul">N/A</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxSinNBPointSERTA" runat="server" CausesValidation="True" Enabled="false" CssClass="NumberBox"></asp:TextBox>
                        /20</td>
                </tr>
                <tr>
                    <td>
                        <span class="Label">Number of client returns</span>
                        <span class="labelInfo">-15 points per incident</span>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxCustomerClaimNBValue" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCustomerClaimCount" runat="server" Text="N/A" CssClass="precalcul"></asp:Label>
                    </td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxCustomerClaimNBPoint" runat="server" CssClass="NumberBox"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="None" ControlToValidate="textBoxCustomerClaimNBValue" CssClass="Validator" ErrorMessage="Champ incorrect :<br /> La valeur doit être un nombre positif." ValidationExpression="^(?=.*[0-9].*$)\d*$"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator5"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxCustomerClaimNBValuePNS" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCustomerClaimCountPNS" runat="server" CssClass="precalcul">N/A</asp:Label>
                    </td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxCustomerClaimNBPointPNS" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxCustomerClaimNBValueSERTA" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCustomerClaimCountSERTA" runat="server" CssClass="precalcul">N/A</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textBoxCustomerClaimNBPointSERTA" runat="server" Enabled="false" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="Label">Reactivity and efficiency of curative and corrective action plans</span>
                    </td>
                    <td></td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxActionPlanReactivity" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>/5
                                <asp:RangeValidator ID="RangeValidator12" runat="server" Display="None" ControlToValidate="textBoxActionPlanReactivity" CssClass="Validator" MaximumValue="5" MinimumValue="0" Type="Integer" ErrorMessage="Please enter number between 1 and 20"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RangeValidator12"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>&nbsp;</td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxActionPlanReactivityPNS" Enabled="false" runat="server" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        /5</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="textBoxActionPlanReactivitySERTA" runat="server" Enabled="false" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                        /5</td>
                </tr>
                <tr class="odd">
                    <td>
                        <span class="Label">Bonus</span>
                        <span class="labelInfo">2 points per 100ppm<500 PPM</span>
                    </td>
                    <td></td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxBonusPPM"  runat="server" CssClass="NumberBox"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxBonusPPMPNS" runat="server" Enabled="false" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="textBoxBonusPPMSERTA" runat="server" Enabled="false" CausesValidation="True" CssClass="NumberBox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="Label">Improvement plan</span>
                    </td>
                    <td>&nbsp;</td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxQualityImprovementPlan" runat="server" CssClass="NumberBox" AutoPostBack="false"></asp:TextBox>/10
                        <asp:RangeValidator CssClass="Validator" ID="RangeValidator1" ControlToValidate="textBoxQualityImprovementPlan" MinimumValue="0" MaximumValue="10" Type="Integer" runat="server" ErrorMessage="Please enter a number" Display="None"></asp:RangeValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="RangeValidator13"></asp:ValidatorCalloutExtender>
                    </td>
                    <td>&nbsp;</td>
                    <td class="cellule">
                        <asp:TextBox ID="textBoxQualityImprovementPlanPNS" runat="server" CssClass="NumberBox" AutoPostBack="false" Enabled="false"></asp:TextBox>/10    
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="textBoxQualityImprovementPlanSERTA" runat="server" CssClass="NumberBox" AutoPostBack="false" Enabled="false"></asp:TextBox>/10
                    </td>
                </tr>
                <tfoot>
                    <tr>
                        <td colspan="2">
                            <span class="Label">Total Quality </span>
                        </td>
                        <td class="cellule">
                            <asp:Label ID="LabelTotalQualite" runat="server"></asp:Label>
                            /45</td>
                        <td colspan="2" class="cellule">
                            <asp:Label ID="LabelTotalQualitePNS" runat="server"></asp:Label>
                            /45</td>
                        <td colspan="2">
                            <asp:Label ID="LabelTotalQualiteSERTA" runat="server"></asp:Label>
                            /45</td>
                    </tr>
                </tfoot>
            </table>
        </fieldset>
            <%-- *********************** Mise en place de la logistique ******************************--%>
            <fieldset>
                <legend>Logistic</legend>
                <table>
                    <thead>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="2">Group</td>
                            <td colspan="2">PNS</td>
                            <td colspan="2">SERTA</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Value</td>
                            <td>Point</td>
                            <td>Value</td>
                            <td>Point</td>
                            <td>Value</td>
                            <td>Point</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>
                            <span class="Label">Service rate : Objectif 95% on time</span>
                            <span class="labelInfo">50% = 0 point</span>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxLogisticRateValue" runat="server" CssClass="NumberBox" CausesValidation="True"></asp:TextBox>
                            <br />
                            <asp:Label ID="LabelDelaysUpTo10DaysRate" runat="server" CssClass="precalcul">N/A</asp:Label>
                        </td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxLogisticRatePoint" runat="server" CssClass="NumberBox"></asp:TextBox>/25<br />
                                <asp:RangeValidator CssClass="Validator" ID="RangeValidator13" ControlToValidate="textboxLogisticRateValue" MinimumValue="0" MaximumValue="100" Type="Integer" runat="server" Display="None" ErrorMessage="Please enter number between 0 and 100"></asp:RangeValidator>
                            <asp:ValidatorCalloutExtender ID="RangeValidator13_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator13"></asp:ValidatorCalloutExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxLogisticRateValuePNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False" Height="22px"></asp:TextBox>
                            <br />
                            <asp:Label ID="LabelDelaysUpTo10DaysRatePNS" runat="server" CssClass="precalcul">N/A</asp:Label>
                        </td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxLogisticRatePointPNS" runat="server" CssClass="NumberBox" Enabled="false"></asp:TextBox>
                            /25
                        </td>
                        <td>
                            <asp:TextBox ID="textboxLogisticRateValueSERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                            <br />
                            <asp:Label ID="LabelDelaysUpTo10DaysRateSERTA" runat="server" CssClass="precalcul">N/A</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxLogisticRatePointSERTA" runat="server" CssClass="NumberBox" Enabled="false"></asp:TextBox>
                            /25
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="Label">Delays penalty</span>
                            <span class="labelInfo">2pts per day % of rate lines beyond 5 days</span>

                        </td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryDelaysLevelValue" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                            %
                                <br />
                            <asp:Label ID="LabelLogisticRate" runat="server" Text="N/A" CssClass="precalcul"></asp:Label>
                        </td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxDeliveryDelaysLevelPoint" runat="server" CssClass="NumberBox"></asp:TextBox>
                            <asp:RangeValidator CssClass="Validator" ID="RangeValidator14" ControlToValidate="textboxDeliveryDelaysLevelValue" MinimumValue="0" MaximumValue="100" Type="Integer" runat="server" ErrorMessage="Please enter number between 0 and 100" Display="None"></asp:RangeValidator>
                            <asp:ValidatorCalloutExtender ID="RangeValidator14_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator14"></asp:ValidatorCalloutExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryDelaysLevelValuePNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                            %&nbsp;<br />
                            <asp:Label ID="LabelLogisticRatePNS" runat="server" CssClass="precalcul" Text="N/A"></asp:Label>
                        </td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxDeliveryDelaysLevelPointPNS" runat="server" CssClass="NumberBox" Enabled="false"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryDelaysLevelValueSERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                            %&nbsp;<br />
                            <asp:Label ID="LabelLogisticRateSERTA" runat="server" CssClass="precalcul" Text="N/A"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryDelaysLevelPointSERTA" runat="server" CssClass="NumberBox" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="Label">Flexibility</span>
                            <span class="labelInfo">-On firm orders<br />
                                -On forecasts<br />
                                -On emergencies
                            </span>
                        </td>
                        <td></td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxFlexibilityPoint" runat="server" CssClass="NumberBox" CausesValidation="True"></asp:TextBox>
                            /8
                                 <asp:RangeValidator CssClass="Validator" ID="RangeValidator3" ControlToValidate="textboxFlexibilityPoint" MinimumValue="0" MaximumValue="8" Type="Integer" ErrorMessage="Please enter number between 0 and 8" Display="None" runat="server"></asp:RangeValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RangeValidator3"></asp:ValidatorCalloutExtender>
                        </td>
                        <td>&nbsp;</td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxFlexibilityPointPNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                            /8&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="textboxFlexibilityPointSERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                            /8&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Chart ID="ChartHorizonOrderCommun" runat="server" CssClass="graphique" Width="477px">
                                <Legends>
                                    <asp:Legend Name="legend"></asp:Legend>
                                </Legends>
                                <Titles>
                                    <asp:Title Name="Titre" Text="Horizon Order"></asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series ChartType="StackedBar" Name="SeriesHorizonOrderOnTime" IsValueShownAsLabel="true" LegendText="On time" Color="LimeGreen"></asp:Series>
                                    <asp:Series ChartType="StackedBar" Name="SeriesHorizonOrderNotOnTime" IsValueShownAsLabel="true" LegendText ="Not on time" Color="Orange"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BorderWidth="10">
                                        <AxisX>
                                            <MajorGrid Enabled="false" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>

                        </td>
                        <td colspan="2">
                            <asp:Chart ID="ChartHorizonOrderPNS" runat="server" CssClass="graphique">
                                <Titles>
                                    <asp:Title Name="Titre" Text="Horizon Order"></asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series ChartType="StackedBar" Name="SeriesHorizonOrderOnTime" IsValueShownAsLabel="true" LegendText="On time" Color="LimeGreen"></asp:Series>
                                    <asp:Series ChartType="StackedBar" Name="SeriesHorizonOrderNotOnTime" IsValueShownAsLabel="true" LegendText="Not on time" Color="Orange"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BorderWidth="10">
                                        <AxisX>
                                            <MajorGrid Enabled="false" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                        <td colspan="2">
                            <asp:Chart ID="ChartHorizonOrderSERTA" runat="server" CssClass="graphique">
                                <Titles>
                                    <asp:Title Name="Titre" Text="Horizon Order"></asp:Title>
                                </Titles>
                                <Series>
                                    <asp:Series ChartType="StackedBar" Name="SeriesHorizonOrderOnTime" IsValueShownAsLabel="true" LegendText="On time" Color="LimeGreen"></asp:Series>
                                    <asp:Series ChartType="StackedBar" Name="SeriesHorizonOrderNotOnTime" IsValueShownAsLabel="true" LegendText="Not on time" Color="Orange"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BorderWidth="10">
                                        <AxisX>
                                            <MajorGrid Enabled="false" />
                                        </AxisX>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="Label">Delivery quality</span>
                            <span class="labelInfo">2pts if no incident</span>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryQualityValue" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                            <br />
                            <asp:Label ID="LabelLNCCount" runat="server" CssClass="precalcul">N/A</asp:Label>
                        </td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxDeliveryQualityPoint" runat="server" CssClass="NumberBox"></asp:TextBox>/2
                                <asp:RangeValidator CssClass="Validator" ID="RangeValidator15" ControlToValidate="textboxDeliveryQualityValue" MinimumValue="0" MaximumValue="1000" Type="Integer" runat="server" ErrorMessage="Please enter a number" Display="None"></asp:RangeValidator>
                            <asp:ValidatorCalloutExtender ID="RangeValidator15_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator15"></asp:ValidatorCalloutExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryQualityValuePNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                            <br />
                            <asp:Label ID="LabelLNCCountPNS" runat="server" CssClass="precalcul">N/A</asp:Label>
                        </td>
                        <td class="cellule">
                            <asp:TextBox ID="textboxDeliveryQualityPointPNS" runat="server" CssClass="NumberBox" Enabled="false"></asp:TextBox>
                            /2&nbsp;</td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryQualityValueSERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                            <br />
                            <asp:Label ID="LabelLNCCountSERTA" runat="server" CssClass="precalcul">N/A</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="textboxDeliveryQualityPointSERTA" runat="server" CssClass="NumberBox" Enabled="false"></asp:TextBox>
                            /2&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <span class="Label">Improvement plan</span>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="cellule">
                            <asp:TextBox ID="textBoxLogisticImprovementPlan" runat="server" CssClass="NumberBox"  AutoPostBack="false"></asp:TextBox>/10
                            <asp:RangeValidator CssClass="Validator" ID="RangeValidator2" ControlToValidate="textBoxLogisticImprovementPlan" MinimumValue="0" MaximumValue="10" Type="Integer" runat="server" ErrorMessage="Please enter a number" Display="None"></asp:RangeValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="RangeValidator1"></asp:ValidatorCalloutExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="cellule">
                            <asp:TextBox ID="textBoxLogisticImprovementPlanPNS" runat="server" CssClass="NumberBox"  AutoPostBack="false" Enabled="false"></asp:TextBox>/10    
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                             <asp:TextBox ID="textBoxLogisticImprovementPlanSERTA" runat="server" CssClass="NumberBox"  AutoPostBack="false" Enabled="false"></asp:TextBox>/10
                        </td>
                    </tr>
                    <tfoot>
                        <tr>
                            <td colspan="2">
                                <span class="Label">Total logistic</span>
                            </td>
                            <td>
                                <asp:Label ID="labelTotalLogistique" runat="server"></asp:Label>
                                /35</td>
                            <td colspan="2">
                                <asp:Label ID="labelTotalLogistiquePNS" runat="server"></asp:Label>
                                /35</td>
                            <td colspan="2">
                                <asp:Label ID="labelTotalLogistiqueSERTA" runat="server"></asp:Label>
                                /35</td>
                        </tr>
                    </tfoot>
                </table>
            </fieldset>
            <fieldset>
                <legend>Purchasing</legend>
                <table>
                    <thead>
                        <tr>
                            <td>&nbsp;</td>
                            <td>Group</td>
                            <td>PNS</td>
                            <td>SERTA</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>Point</td>
                            <td>Point</td>
                            <td>Point</td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <span class="Label">Improvement plan</span>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxImprovmentPlan" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                                /5 
                                <asp:RangeValidator CssClass="Validator" ID="RangeValidator16" ControlToValidate="TextBoxImprovmentPlan" MinimumValue="0" MaximumValue="5" Type="Integer" runat="server" ErrorMessage="Please enter number between 0 and 5" Display="None"></asp:RangeValidator>
                                <asp:ValidatorCalloutExtender ID="RangeValidator16_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator16"></asp:ValidatorCalloutExtender>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxImprovmentPlanPNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /5&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBoxImprovmentPlanSERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /5&nbsp;</td>
                        </tr>

                        <tr>
                            <td>
                                <span class="Label">Business relationship</span>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxBusinessRelationship" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                                /4
                                <asp:RangeValidator CssClass="Validator" ID="RangeValidator17" ControlToValidate="TextBoxBusinessRelationship" MinimumValue="0" MaximumValue="4" Type="Integer" runat="server" ErrorMessage="Please enter number between 0 and 4" Display="None"></asp:RangeValidator>
                                <asp:ValidatorCalloutExtender ID="RangeValidator17_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator17"></asp:ValidatorCalloutExtender>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxBusinessRelationshipPNS" runat="server" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /4&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBoxBusinessRelationshipSERTA" runat="server" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /4&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <span class="Label">Financial supplier health</span>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxFinancialSituation" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                                /5 
                                <asp:RangeValidator CssClass="Validator" ID="RangeValidator18" ControlToValidate="TextBoxFinancialSituation" MinimumValue="0" MaximumValue="5" Type="Integer" runat="server" ErrorMessage="Please enter number between 0 and 5" Display="None"></asp:RangeValidator>
                                <asp:ValidatorCalloutExtender ID="RangeValidator18_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator18"></asp:ValidatorCalloutExtender>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxFinancialSituationPNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /5&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBoxFinancialSituationSERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /5&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <span class="Label">Reactivity on commercial offers</span>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxOffersReactivity" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                                /2
                                 <asp:RangeValidator CssClass="Validator" ID="RangeValidator19" ControlToValidate="TextBoxOffersReactivity" MinimumValue="0" MaximumValue="2" Type="Integer" runat="server" ErrorMessage="Please enter number between 0 and 2" Display="None"></asp:RangeValidator>
                                <asp:ValidatorCalloutExtender ID="RangeValidator19_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator19"></asp:ValidatorCalloutExtender>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxOffersReactivityPNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /2&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBoxOffersReactivitySERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /2&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <span class="Label">Quality of technical answer</span>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxTechnicalAnswerQuality" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                                /2
                                 <asp:RangeValidator CssClass="Validator" ID="RangeValidator20" ControlToValidate="TextBoxTechnicalAnswerQuality" MinimumValue="0" MaximumValue="2" Type="Integer" runat="server" Display="None" ErrorMessage="Please enter number between 0 and 2"></asp:RangeValidator>
                                <asp:ValidatorCalloutExtender ID="RangeValidator20_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator20"></asp:ValidatorCalloutExtender>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxTechnicalAnswerQualityPNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /2&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBoxTechnicalAnswerQualitySERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /2&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <span class="Label">ISO certification</span>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxIsoCertification" CausesValidation="True" runat="server" CssClass="NumberBox"></asp:TextBox>
                                /2
                                 <asp:RangeValidator CssClass="Validator" ID="RangeValidator21" ControlToValidate="TextBoxIsoCertification" MinimumValue="0" MaximumValue="2" Type="Integer" runat="server" ErrorMessage="Please enter number between 0 and 2" Display="None"></asp:RangeValidator>
                                <asp:ValidatorCalloutExtender ID="RangeValidator21_ValidatorCalloutExtender" runat="server" TargetControlID="RangeValidator21"></asp:ValidatorCalloutExtender>
                            </td>
                            <td class="cellule">
                                <asp:TextBox ID="TextBoxIsoCertificationPNS" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /2&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBoxIsoCertificationSERTA" runat="server" CausesValidation="True" CssClass="NumberBox" Enabled="False"></asp:TextBox>
                                /2&nbsp;</td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>
                                <span class="Label">Total competitiveness</span>
                            </td>
                            <td>
                                <asp:Label ID="LabelTatalCompetitiveness" runat="server" CssClass="NumberBox"></asp:Label>
                                /20
                            </td>
                            <td>
                                <asp:Label ID="LabelTatalCompetitivenessPNS" runat="server" CssClass="NumberBox"></asp:Label>
                                /20</td>
                            <td>
                                <asp:Label ID="LabelTatalCompetitivenessSERTA" runat="server" CssClass="NumberBox"></asp:Label>
                                /20</td>
                        </tr>
                    </tfoot>
                </table>
            </fieldset>
        </div>
    </div>
    <%-- *********************** Mise en place de la cotation total ******************************--%>
    <div>
        <fieldset>
            <legend>Notation</legend>
            <table>
                <thead>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Group</td>
                        <td>PNS</td>
                        <td>SERTA</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><span class="Label">Total score</span></td>
                        <td class="cellule">
                            <asp:Label ID="LabelTotal" runat="server"></asp:Label>
                            /100</td>
                        <td class="cellule">
                            <asp:Label ID="LabelTotalPNS" runat="server"></asp:Label>
                            /100</td>
                        <td>
                            <asp:Label ID="LabelTotalSERTA" runat="server"></asp:Label>
                            /100</td>
                    </tr>
                
                    <tr>
                        <td colspan="2" class="cellule">
                            <fieldset>
                                <legend>Trend :</legend>
                                <div>
                                    <asp:RadioButtonList ID="RadioButtonListTrend" runat="server" RepeatDirection="Horizontal" Width="360px">
                                        <asp:ListItem Value="1"><img src="../../img/ua.png" alt="Up" /></asp:ListItem>
                                        <asp:ListItem Value="2"><img src="../../img/ca.png" alt="Constant" /></asp:ListItem>
                                        <asp:ListItem Value="3"><img src="../../img/da.png" alt="Down" /></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </fieldset>
                        </td>
                        <td class="cellule">
                            <fieldset>
                                <legend>Trend :</legend>
                                <div>
                                    <asp:RadioButtonList ID="RadioButtonListTrendPNS" Enabled="false" runat="server" RepeatDirection="Horizontal" Width="360px">
                                        <asp:ListItem Value="1"><img src="../../img/ua.png" alt="Up" /></asp:ListItem>
                                        <asp:ListItem Value="2"><img src="../../img/ca.png" alt="Constant" /></asp:ListItem>
                                        <asp:ListItem Value="3"><img src="../../img/da.png" alt="Down" /></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </fieldset>
                        </td>
                        <td>
                            <fieldset>
                                <legend>Trend :</legend>
                                <div>
                                    <asp:RadioButtonList ID="RadioButtonListTrendSERTA" Enabled="false" runat="server" RepeatDirection="Horizontal" Width="360px">
                                        <asp:ListItem Value="1"><img src="../../img/ua.png" alt="Up" /></asp:ListItem>
                                        <asp:ListItem Value="2"><img src="../../img/ca.png" alt="Constant" /></asp:ListItem>
                                        <asp:ListItem Value="3"><img src="../../img/da.png" alt="Down" /></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="cellule">Detail comment :<br />
                            <asp:TextBox ID="TextBoxCommentDetail" runat="server" Width="360px" Height="350px" TextMode="MultiLine"></asp:TextBox>
                            <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="TextBoxCommentDetail" EnableSanitization="false"></asp:HtmlEditorExtender>
                            <br />
                            Ranking:
                                    <br />
                            <asp:TextBox ID="TextBoxCommentClassification" runat="server" Width="360px" Height="350px" Font-Names="Verdana" TextMode="MultiLine"></asp:TextBox>
                            <asp:HtmlEditorExtender ID="HtmlEditorExtender2" runat="server" TargetControlID="TextBoxCommentClassification" EnableSanitization="false"></asp:HtmlEditorExtender>
                            <br />
                            Global comment:
                                    <br />
                            <asp:TextBox ID="TextBoxCommentGlobal" runat="server" Width="360px" Font-Names="Verdana" Height="350px" TextMode="MultiLine"></asp:TextBox>
                            <asp:HtmlEditorExtender ID="HtmlEditorExtender3" runat="server" TargetControlID="TextBoxCommentGlobal" EnableSanitization="false"></asp:HtmlEditorExtender>
                        </td>
                        <td class="cellule">
                            <fieldset>
                                <legend>Detail comment :</legend>
                                <asp:Label ID="TextBoxCommentDetailPNS" runat="server"></asp:Label>
                            </fieldset>
                            <fieldset>
                                <legend>Ranking:</legend>
                                <asp:Label ID="TextBoxCommentClassificationPNS" runat="server"></asp:Label>
                            </fieldset>
                            <fieldset>
                                <legend>Global comment:</legend>
                                <asp:Label ID="TextBoxCommentGlobalPNS" runat="server"></asp:Label>
                            </fieldset>
                        </td>
                        <td>
                            <fieldset>
                                <legend>Detail comment :</legend>
                                <asp:Label ID="TextBoxCommentDetailSERTA" runat="server"></asp:Label>
                            </fieldset>
                            <fieldset>
                                <legend>Ranking:</legend>
                                <asp:Label ID="TextBoxCommentClassificationSERTA" runat="server"></asp:Label>
                            </fieldset>
                            <fieldset>
                                <legend>Global comment:</legend>
                                <asp:Label ID="TextBoxCommentGlobalSERTA" runat="server"></asp:Label>
                            </fieldset>
                        </td>
                    </tr>
                </tbody>
            </table>

            <br />
        </fieldset>
    </div>
     
    <%----------- START JAVASCRIPT ---------%>
    <div id="JavaScript">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

        <script type="text/javascript" src="../../Script/jquery-2.0.3.js"></script>
        <script type="text/javascript" src="SupplierAssessment.js"></script>
        <script type="text/javascript">
            //Evenement au moment de la fin du chargement
            $(window).bind("load", function () {
                TotalQuality();
                TotalLogistique();
                Totalcompetitiveness();
            });

            //Gestion des evenements sur chaque champs modifié//
            //Changement Indice PPM
            $('#<%=textBoxIndicePPMvalue.ClientID%>').change(function () {
                $('#<%=textBoxIndicePPMNote.ClientID%>').val(calculePPM($('#<%=textBoxIndicePPMvalue.ClientID%>').val()));
                $('#<%=textBoxBonusPPM.ClientID%>').val(BonusPPM($('#<%=textBoxIndicePPMvalue.ClientID%>').val(), $('#<%=textBoxCustomerClaimNBValue.ClientID%>').val())); //calcule Bonus
                TotalQuality();//recalcule le total
            });

            //Changement Nombre de probleme qualité
            $('#<%=textBoxSinNBValue.ClientID%>').change(function () {
                $('#<%=textBoxSinNBPoint.ClientID%>').val(qualityProblemes($('#<%=textBoxSinNBValue.ClientID%>').val()));
                TotalQuality();//recalcule le total
            });

            //Changement nombre retour client
            $('#<%=textBoxCustomerClaimNBValue.ClientID%>').change(function () {
                $('#<%=textBoxCustomerClaimNBPoint.ClientID%>').val(retourClient($('#<%=textBoxCustomerClaimNBValue.ClientID%>').val()));
                $('#<%=textBoxBonusPPM.ClientID%>').val(BonusPPM($('#<%=textBoxIndicePPMvalue.ClientID%>').val(), $('#<%=textBoxCustomerClaimNBValue.ClientID%>').val()));//calcule Bonus
                TotalQuality();//recalcule le total
            });

            //Changement Nombre de probleme qualité
            $('#<%=textBoxQualityImprovementPlan.ClientID%>').change(function () {
                TotalQuality();//recalcule le total
            });

            //Réactivité 
            $('#<%=textBoxActionPlanReactivity.ClientID%>').change(function () {
                TotalQuality();//recalcule le total
            });

            //Taux de service
            $('#<%=textboxLogisticRateValue.ClientID%>').change(function () {
                $('#<%=textboxLogisticRatePoint.ClientID%>').val(tauxService($('#<%=textboxLogisticRateValue.ClientID%>').val()));
                TotalLogistique();//recalcule le total
            });

            //Flexibilité
            $('#<%=textboxFlexibilityPoint.ClientID%>').change(function () {
                TotalLogistique();//recalcule le total
            });

            //Pénalité de livraison
            $('#<%=textboxDeliveryDelaysLevelValue.ClientID%>').change(function () {
                $('#<%=textboxDeliveryDelaysLevelPoint.ClientID%>').val(delaysPenalty($('#<%=textboxDeliveryDelaysLevelValue.ClientID%>').val()));
                TotalLogistique();//recalcule le total
            });

            //Qualité de livraison
            $('#<%=textboxDeliveryQualityValue.ClientID%>').change(function () {
                $('#<%=textboxDeliveryQualityPoint.ClientID%>').val(deliveryQuality($('#<%=textboxDeliveryQualityValue.ClientID%>').val()));
                TotalLogistique();//recalcule le total
            });

            //Plan de progres logistique
            $('#<%=textBoxLogisticImprovementPlan.ClientID%>').change(function () {
                TotalLogistique();//recalcule le total
            });

            //calcule reactivite 
            $('#<%=TextBoxImprovmentPlan.ClientID%>').change(function () {
                Totalcompetitiveness();//recalcule le total
            });

            //Calcule relation commercial
            $('#<%=TextBoxBusinessRelationship.ClientID%>').change(function () {
                Totalcompetitiveness();//recalcule le total
            });

            //Calcule santé financiere
            $('#<%=TextBoxFinancialSituation.ClientID%>').change(function () {
                Totalcompetitiveness();//recalcule le total
            });

            //Calcule Reactivite sur l'offre commercial
            $('#<%=TextBoxOffersReactivity.ClientID%>').change(function () {
                Totalcompetitiveness();//recalcule le total
            });

            //Calcule qualité des réponse technique
            $('#<%=TextBoxTechnicalAnswerQuality.ClientID%>').change(function () {
                Totalcompetitiveness();//recalcule le total
            });

            //Calcule Certification ISO
            $('#<%=TextBoxIsoCertification.ClientID%>').change(function () {
                Totalcompetitiveness();//recalcule le total
            });

            //Calcule le Sous total et total de la partie Quality
            TotalQuality = function () {
                var PPMNote = parseInt($('#<%=textBoxIndicePPMNote.ClientID%>').val());
                var CustomerNBPoint = parseInt($('#<%=textBoxCustomerClaimNBPoint.ClientID%>').val());
                var SinNBPoint = parseInt($('#<%=textBoxSinNBPoint.ClientID%>').val());
                var BonusPPM = parseInt($('#<%=textBoxBonusPPM.ClientID%>').val());
                var ActionPlanReactivity = parseInt($('#<%=textBoxActionPlanReactivity.ClientID%>').val());
                var TmpTotalQuality = PPMNote + CustomerNBPoint + SinNBPoint + BonusPPM + ActionPlanReactivity;
                if (TmpTotalQuality < 0) {
                    TmpTotalQuality = 0;
                }

                if ((TmpTotalQuality + parseInt($('#<%=textBoxQualityImprovementPlan.ClientID%>').val())) > 45) {
                    $('#<%=LabelTotalQualite.ClientID%>').html(45);
                }
                else if ((TmpTotalQuality + parseInt($('#<%=textBoxQualityImprovementPlan.ClientID%>').val())) < 0) {
                    $('#<%=LabelTotalQualite.ClientID%>').html(0);
                }
                else {
                    $('#<%=LabelTotalQualite.ClientID%>').html(TmpTotalQuality + parseInt($('#<%=textBoxQualityImprovementPlan.ClientID%>').val()));
                }
                //Appel Score total
                TotalScore();//Appel le calcule du score total
            };


        //Calcule le total du score Logistique
        TotalLogistique = function () {
            var ServiceRate = parseInt(($('#<%=textboxLogisticRatePoint.ClientID%>').val()));
                var flexibility = parseInt(($('#<%=textboxFlexibilityPoint.ClientID%>').val()));
                var delaysPenality = parseInt(($('#<%=textboxDeliveryDelaysLevelPoint.ClientID%>').val()));
                var deliveryQuality = parseInt(($('#<%=textboxDeliveryQualityPoint.ClientID%>').val()));
                var ImprovementPlan = parseInt(($('#<%=textBoxLogisticImprovementPlan.ClientID%>').val()));

                var TmpTotalLogistique = ServiceRate + delaysPenality
                if (TmpTotalLogistique < 0) {
                    TmpTotalLogistique = 0
                }
                TmpTotalLogistique = TmpTotalLogistique + flexibility + deliveryQuality + ImprovementPlan
                if (TmpTotalLogistique > 35) {
                    TmpTotalLogistique = 35
                }
                $('#<%=labelTotalLogistique.ClientID%>').html(TmpTotalLogistique)
            TotalScore();//Appel le calcule du score total
            };
        //Calcule le total du score competitivité
        Totalcompetitiveness = function () {
            var Improvementplan = parseInt(($('#<%=TextBoxImprovmentPlan.ClientID%>').val()));
    var BusinessRelationship = parseInt(($('#<%=TextBoxBusinessRelationship.ClientID%>').val()));
    var ReactivityOnCommercial = parseInt(($('#<%=TextBoxOffersReactivity.ClientID%>').val()));
    var QualityOfTechnical = parseInt(($('#<%=TextBoxTechnicalAnswerQuality.ClientID%>').val()));
    var ISOCertification = parseInt(($('#<%=TextBoxIsoCertification.ClientID%>').val()));
    var FinancialSupplierHealth = parseInt(($('#<%=TextBoxFinancialSituation.ClientID%>').val()));

    var TmpTotalcompetiviveness = Improvementplan + BusinessRelationship + ReactivityOnCommercial + QualityOfTechnical + ISOCertification + FinancialSupplierHealth;
    if (TmpTotalcompetiviveness < 0) {
        $('#<%=LabelTatalCompetitiveness.ClientID%>').html(0)
    }
    else if (TmpTotalcompetiviveness > 20) {
        $('#<%=LabelTatalCompetitiveness.ClientID%>').html(20)
        }
        else {
            $('#<%=LabelTatalCompetitiveness.ClientID%>').html(TmpTotalcompetiviveness)
        }

    TotalScore();//Appel le calcule du score total
};

//Calcule La somme Total de tout les scores      

TotalScore = function () {
    var totalQuality = parseInt(($('#<%=LabelTotalQualite.ClientID%>').html()));
    var totalLogistic = parseInt($('#<%=labelTotalLogistique.ClientID%>').html());
    var totalcompetitiness = parseInt($('#<%=LabelTatalCompetitiveness.ClientID%>').html());

    var TmpTotalscore = totalQuality + totalLogistic + totalcompetitiness;
    if (TmpTotalscore < 0) {
        $('#<%=LabelTotal.ClientID%>').html(0)
    }
    else if (TmpTotalscore > 100) {
        $('#<%=LabelTotal.ClientID%>').html(100)
        }
        else {
            $('#<%=LabelTotal.ClientID%>').html(TmpTotalscore)
        }
};
$(document).ready(TotalLogistique)
        </script>
    </div>
    <%----------- END JAVASCRIPT ----------%>
    </asp:Content>