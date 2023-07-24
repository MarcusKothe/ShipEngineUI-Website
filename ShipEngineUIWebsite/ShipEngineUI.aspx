<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipEngineUI.aspx.cs" Inherits="ShipEngineUI.ShipEngineUIWebsite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SHIPENGINE UI</title>
    <style type="text/css">
        .auto-style1 {
            z-index: 154;
            left: 103px;
            top: 267px;
            position: absolute;
        }
        .auto-style2 {
            position: absolute;
            left: 15px;
            top: 96px;
            width: 308px;
            height: 324px;
        }
        .auto-style3 {
            position: absolute;
            left: 356px;
            top: 97px;
            width: 308px;
            height: 324px;
            
        }
        .auto-style4 {
            position: absolute;
            left: 356px;
            top: 440px;
            width: 305px;
            height: 28px;
            margin-top: 0px;
            border: 0;
        }
        .auto-style5 {
            position: absolute;
            left: 13px;
            top: 484px;
            width: 308px;
            height: 191px;
        }
        .auto-style6 {
            position: absolute;
            left: 12px;
            top: 46px;
            width: 654px;
            height: 22px;
             border: 0;
        }
        .auto-style7 {
            margin-top: 0px;
        }
        .auto-style8 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            position: absolute;
            left: 13px;
            top: 444px;
            width: 308px;
            height: 22px;
            }
        .auto-style9 {
            position: absolute;
            left: 697px;
            top: 48px;
            width: 440px;
            height: 705px;
        }
        .auto-style10 {
            position: absolute;
            left: 357px;
            top: 484px;
            width: 305px;
            height: 265px;
            margin-top: 0px;
        }
        .auto-style11 {
            position: absolute;
            left: 15px;
            top: 688px;
            width: 305px;
            height: 65px;
            margin-top: 0px;
        }
        .auto-style12 {
            width: 292px;
            height: 255px;
        }
        .auto-style13 {
            z-index: 138;
            left: 103px;
            top: 23px;
            position: absolute;
        }
        .auto-style14 {
            z-index: 135;
            width: 41px;
        }
        .auto-style15 {
            z-index: 143;
            left: 103px;
            top: 78px;
            position: absolute;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <fieldset id="Fieldset3" runat="server" class="auto-style6">

            <asp:DropDownList ID="carrier_id_ComboBox" runat="server" Height="21px" Width="308px" onselectedindexchanged="carrier_id_ComboBox_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:DropDownList ID="warehouse_id_ComboBox" runat="server" Height="21px" Width="308px" onselectedindexchanged="warehouse_id_ComboBox_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
            <br />
           
        </fieldset>

        <div>
            
        <textarea id="warehouse_id_RichTextBox" runat="server" cols="20" name="S2" rows="2" hidden="hidden" readonly="readonly"></textarea>
        <textarea id="carrier_id_RichTextBox" runat="server" cols="20" name="S1" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="service_code_RichTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="package_code_RichTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>


        </div>
            
        <fieldset id="shipfromgroupBox" runat="server" class="auto-style2">
        <legend style="Z-INDEX: 135; color:black; font-family:'Roboto'; font-size:8pt; width:55px">Ship From</legend>
        <asp:Label id="label37" style="z-index:136; left:14px; top:162px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="79" Height="18">Address Line 3</asp:Label>
        <asp:TextBox id="shipFrom_address_line3_TextBox" style="z-index:137; left:103px; top:159px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="54"> </asp:TextBox>
        <asp:TextBox id="shipFrom_name_TextBox" style="z-index:138; left:103px; top:24px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="17"></asp:TextBox>
        <asp:TextBox id="shipFrom_company_name_TextBox" style="z-index:139; left:103px; top:51px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="18"></asp:TextBox>
        <asp:Label id="label23" style="z-index:140; left:15px; top:270px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="72" Height="18">Country Code</asp:Label>
        <asp:TextBox id="shipFrom_address_line1_TextBox" style="z-index:141; left:103px; top:105px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="19"></asp:TextBox>
        <asp:Label id="label22" style="z-index:142; left:15px; top:297px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="65" Height="18">Residential?</asp:Label>
        <asp:TextBox id="shipFrom_phone_TextBox" style="z-index:143; left:103px; top:78px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="20"> </asp:TextBox>
        <asp:Label id="label21" style="z-index:144; left:15px; top:216px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="77" Height="18">State Province</asp:Label>
        <asp:TextBox id="shipFrom_address_line2_TextBox" style="z-index:145; left:103px; top:132px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="21"> </asp:TextBox>
        <asp:Label id="label20" style="z-index:146; left:16px; top:243px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="65" Height="18">Postal Code</asp:Label>
        <asp:TextBox id="shipFrom_city_locality_TextBox" style="z-index:147; left:103px; top:186px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="22"></asp:TextBox>
        <asp:Label id="label13" style="z-index:148; left:14px; top:135px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="79" Height="18">Address Line 2</asp:Label>
        <asp:TextBox id="shipFrom_postal_code_TextBox" style="z-index:149; left:103px; top:240px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="23"></asp:TextBox>
        <asp:Label id="label12" style="z-index:150; left:16px; top:27px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="34" Height="18">Name</asp:Label>
        <asp:TextBox id="shipFrom_state_province_TextBox" style="z-index:151; left:103px; top:213px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="24"></asp:TextBox>
        <asp:Label id="label10" style="z-index:152; left:16px; top:82px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="80" Height="18">Phone Number</asp:Label>
        <asp:Label id="label9" style="z-index:153; left:16px; top:54px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="85" Height="18">Company Name</asp:Label>
        <asp:TextBox id="shipFrom_country_code_TextBox" style="font-family:'Roboto'; font-size:8pt; " runat="server" Width="195" Height="21" TabIndex="29" CssClass="auto-style1"></asp:TextBox>
        <asp:Label id="label8" style="z-index:155; left:16px; top:108px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="79" Height="18">Address Line 1</asp:Label>
        <asp:Label id="label7" style="z-index:156; left:15px; top:189px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="65" Height="18">City Locality</asp:Label>
        </fieldset>


        <fieldset id="shiptogroupBox" runat="server" class="auto-style3">
        <legend style="color:black; font-family:'Roboto'; font-size:8pt; " class="auto-style14">Ship To</legend>
        <asp:Label id="label1" style="z-index:136; left:14px; top:162px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="79" Height="18">Address Line 3</asp:Label>
        <asp:TextBox id="shipTo_address_line3_TextBox" style="z-index:137; left:103px; top:159px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="54"></asp:TextBox>
        <asp:TextBox id="shipTo_name_TextBox" style="font-family:'Roboto'; font-size:8pt; " runat="server" Width="195" Height="21" TabIndex="17" CssClass="auto-style13"></asp:TextBox>
        <asp:TextBox id="shipTo_company_name_TextBox" style="z-index:139; left:103px; top:51px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="18"></asp:TextBox>
        <asp:Label id="label2" style="z-index:140; left:15px; top:270px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="72" Height="18">Country Code</asp:Label>
        <asp:TextBox id="shipTo_address_line1_TextBox" style="z-index:141; left:103px; top:105px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="19"></asp:TextBox>
        <asp:Label id="label3" style="z-index:142; left:15px; top:297px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="65" Height="18">Residential?</asp:Label>
        <asp:TextBox id="shipTo_phone_TextBox" style="font-family:'Roboto'; font-size:8pt; " runat="server" Width="195" Height="21" TabIndex="20" CssClass="auto-style15"></asp:TextBox>
        <asp:Label id="label4" style="z-index:144; left:15px; top:216px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="77" Height="18">State Province</asp:Label>
        <asp:TextBox id="shipTo_address_line2_TextBox" style="z-index:145; left:103px; top:132px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="21"></asp:TextBox>
        <asp:Label id="label5" style="z-index:146; left:16px; top:243px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="65" Height="18">Postal Code</asp:Label>
        <asp:TextBox id="shipTo_city_locality_TextBox" style="z-index:147; left:103px; top:186px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="22"></asp:TextBox>
        <asp:Label id="label6" style="z-index:148; left:14px; top:135px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="79" Height="18">Address Line 2</asp:Label>
        <asp:TextBox id="shipTo_postal_code_TextBox" style="z-index:149; left:103px; top:240px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="23"></asp:TextBox>
        <asp:Label id="label11" style="z-index:150; left:16px; top:27px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="34" Height="18">Name</asp:Label>
        <asp:TextBox id="shipTo_state_province_TextBox" style="z-index:151; left:103px; top:213px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="195" Height="21" TabIndex="24"></asp:TextBox>
        <asp:Label id="label14" style="z-index:152; left:16px; top:82px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="80" Height="18">Phone Number</asp:Label>
        <asp:Label id="label15" style="z-index:153; left:16px; top:54px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="85" Height="18">Company Name</asp:Label>
        <asp:TextBox id="shipTo_country_code_TextBox" style="font-family:'Roboto'; font-size:8pt; " runat="server" Width="195" Height="21" TabIndex="29" CssClass="auto-style1"></asp:TextBox>
        <asp:Label id="label16" style="z-index:155; left:16px; top:108px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="79" Height="18">Address Line 1</asp:Label>
        <asp:Label id="label17" style="z-index:156; left:15px; top:189px; font-family:'Roboto'; font-size:8pt; position:absolute;" runat="server" Width="65" Height="18">City Locality</asp:Label>
        </fieldset>

        <fieldset id="Fieldset1" runat="server" class="auto-style9">

            <asp:Image ID="Image1" runat="server" Height="64px" Width="53px" />

        </fieldset>


        <fieldset id="Fieldset2" runat="server" class="auto-style5" style="font-family:'Roboto'; font-size:8pt; ">

            
            Package <asp:DropDownList ID="package_code_ComboBox" runat="server" Height="21px" Width="213px" CssClass="auto-style7"></asp:DropDownList>
            <br />
            <br />
            <asp:TextBox ID="packages_dimensions_length_numericUpDown" runat="server" Height="21px" Width="20px"></asp:TextBox> L 
            <asp:TextBox ID="packages_dimensions_width_numericUpDown" runat="server" Height="21px" Width="20px"></asp:TextBox> W 
            <asp:TextBox ID="packages_dimensions_height_numericUpDown" runat="server" Height="21px" Width="20px"></asp:TextBox> H (Inches)
            <asp:TextBox ID="packages_weight_value_numericUpDown" runat="server" Height="21px" Width="20px"></asp:TextBox> Weight (Lbs)
            <br />
            <br />
            Confirmation  <asp:DropDownList ID="delivery_confirmation_ComboBox" runat="server" Height="21px" Width="213px" CssClass="auto-style7">
                <asp:ListItem Selected="True">none</asp:ListItem>
                <asp:ListItem>delivery</asp:ListItem>
                <asp:ListItem>signature</asp:ListItem>
                <asp:ListItem>adult_signature</asp:ListItem>
                <asp:ListItem>adult_signature</asp:ListItem>
                <asp:ListItem>delivery_mailed</asp:ListItem>
                <asp:ListItem Value="verbal_confirmation"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Insurance  <asp:DropDownList ID="insurance_provider_comboBox" runat="server" Height="21px" Width="213px" CssClass="auto-style7">
                <asp:ListItem Selected="True">none</asp:ListItem>
                <asp:ListItem>shipsurance</asp:ListItem>
                <asp:ListItem>carrier</asp:ListItem>
                <asp:ListItem>third_party</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Insured Value <asp:TextBox ID="insured_value_amont_numericUpDown" runat="server" Height="21px" Width="20px"></asp:TextBox>
            <asp:DropDownList ID="Dinsured_value_currency_comboBox" runat="server" Height="21px" Width="100px" CssClass="auto-style7"></asp:DropDownList>

        </fieldset>

        <fieldset id="Fieldset6" runat="server" class="auto-style4" style="font-family:'Roboto'; font-size:8pt; position:absolute;">

            Ship Date <asp:TextBox ID="ship_date_TextBox" runat="server"></asp:TextBox> <asp:Button ID="get_Rates_Button" runat="server" Text="Get Rates" OnClick="get_Rates_Button_Click" />

           </fieldset>

        <fieldset id="Fieldset4" runat="server" class="auto-style8">
            <asp:DropDownList ID="service_code_ComboBox" runat="server" Height="21px" Width="308px" CssClass="auto-style7">
            </asp:DropDownList>
            <br />
           
        </fieldset>

        <fieldset id="Fieldset5" runat="server" class="auto-style11">

            <asp:ListBox ID="sales_order_ListBox" runat="server"></asp:ListBox>

           </fieldset>

        <fieldset id="Fieldset7" runat="server" class="auto-style10">

            <textarea id="rate_response_RichTextBox" runat="server" class="auto-style12"></textarea>

           </fieldset>


    </form>
</body>
</html>
