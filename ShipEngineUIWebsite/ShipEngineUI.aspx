<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipEngineUI.aspx.cs" Inherits="ShipEngineUI.ShipEngineUIWebsite" Async="true" %>  
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
        .auto-styledropdown {
            z-index: 154;
            left: 103px;
            top: 294px;
            position: absolute;
        }
        .auto-style2 {
            position: absolute;
            left: 15px;
            top: 85px;
            width: 308px;
            height: 324px;
        }
        .auto-style3 {
            position: absolute;
            left: 360px;
            top: 85px;
            width: 308px;
            height: 324px;
            
        }
        .auto-style4 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            position: absolute;
            left: 360px;
            top: 430px;
            width: 308px;
            height: 28px;
            margin-top: 0px;
            }
        .auto-style5 {
            position: absolute;
            left: 15px;
            top: 460px;
            width: 315px;
            height: 171px;
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
            height: 28px;
            width: 308px;
        }
        .auto-style8 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            position: absolute;
            left: 15px;
            top: 430px;
            width: 308px;
            height: 22px;
            }
        .auto-style9 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            position: absolute;
            left: 690px;
            top: 45px;
            width: 440px;
            height: 770px;
            margin-left: 0px;
        }
        .auto-style10 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            position: absolute;
            left: 350px;
            top: 460px;
            width: 309px;
            height: 265px;
            margin-top: 0px;
        }
        .auto-style11 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            position: absolute;
            left: 5px;
            top: 645px;
            width: 315px;
            height: 166px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .auto-style12 {
            width: 305px;
            height: 305px;
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
        .auto-style17 {
            position: absolute;
            left: 1153px;
            top: 47px;
            width: 420px;
            height: 715px;
            margin-top: 0px;

        }
        .auto-style18 {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            position: absolute;
            left: 355px;
            top: 750px;
            width: 320px;
            height: 27px;
            margin-top: 0px;
            right: 690px;
        }
        .auto-style19 {
            width: 324px;
            height: 274px;
            margin-top: 0px;
             resize: none;
        }
        .auto-style20 {
            z-index: 135;
            width: 90px;
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <fieldset id="Fieldset3" runat="server" class="auto-style6">

            <asp:DropDownList ID="carrier_id_ComboBox" runat="server" Height="21px" Width="308px" onselectedindexchanged="carrier_id_ComboBox_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:DropDownList ID="warehouse_id_ComboBox" runat="server" Height="21px" Width="308px" onselectedindexchanged="warehouse_id_ComboBox_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
            <br />
           
        </fieldset>

        <div>
            
        <textarea id="rateResponseRawTextBox" runat="server" class="auto-style12" cols="20" name="S3" rows="1" hidden="hidden" readonly="readonly"></textarea>
        <textarea id="warehouse_id_RichTextBox" runat="server" cols="20" name="S2" rows="2" hidden="hidden" readonly="readonly"></textarea>
        <textarea id="carrier_id_RichTextBox" runat="server" cols="20" name="S1" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="service_code_RichTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="package_code_RichTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="label_RichTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="sales_order_RichTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="label_id_richTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>
        <textarea id="void_label_id_RichTextBox" runat="server" cols="20" name="S2" rows="2"  hidden="hidden" readonly="readonly"></textarea>   

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
        <asp:DropDownList ID="shipFrom_address_residential_indicator_comboBox" runat="server" style="font-family:'Roboto'; font-size:8pt; " Width="202" Height="21" TabIndex="29" CssClass="auto-styledropdown">
            <asp:ListItem Selected="True">No</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
            </asp:DropDownList>
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
        <asp:DropDownList ID="shipTo_address_residential_indicator_comboBox" runat="server" style="font-family:'Roboto'; font-size:8pt; " Width="202" Height="21" TabIndex="29" CssClass="auto-styledropdown">
            <asp:ListItem Selected="True">No</asp:ListItem>
            <asp:ListItem>Yes</asp:ListItem>
            </asp:DropDownList>
        </fieldset>

        <fieldset id="Fieldset1" runat="server" class="auto-style9">

            <asp:Image ID="labelImageBox" runat="server" Height="730px" Width="448px" OnClientClick="labelImageBox_Click" BorderStyle="Solid" BorderWidth="1px" />

        </fieldset>


        <fieldset id="Fieldset2" runat="server" class="auto-style5" style="font-family:'Roboto'; font-size:8pt; ">
            <legend style="color:black; font-family:'Roboto'; font-size:8pt; " class="auto-style20">Configure Package</legend>
            
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
            Insured Value <asp:TextBox ID="insured_value_amont_numericUpDown" runat="server" Height="20px" Width="20px">0</asp:TextBox>
            <asp:DropDownList ID="insured_value_currency_comboBox" runat="server" Height="21px" Width="100px" CssClass="auto-style7">
                <asp:ListItem>USD</asp:ListItem>
            </asp:DropDownList>

        </fieldset>

        <fieldset id="Fieldset6" runat="server" class="auto-style4" style="font-family:'Roboto'; font-size:8pt; ">

            Ship Date <asp:TextBox ID="ship_date_TextBox" runat="server"></asp:TextBox> <asp:Button ID="get_Rates_Button" runat="server" Text="Get Rates" OnClick="get_Rates_Button_Click" />

           </fieldset>

        <fieldset id="Fieldset4" runat="server" class="auto-style8">
            <asp:DropDownList ID="service_code_ComboBox" runat="server" Height="21px" Width="308px" CssClass="auto-style7">
            </asp:DropDownList>
            <br />
           
        </fieldset>

        <fieldset id="Fieldset5" runat="server" class="auto-style11">

            <asp:ListBox ID="sales_order_ListBox" runat="server" Height="138px" Width="330px" OnSelectedIndexChanged="sales_order_ListBox_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>

           </fieldset>

        <fieldset id="Fieldset7" runat="server" class="auto-style10">

            <textarea id="rate_response_RichTextBox" runat="server" class="auto-style19" cols="20" name="S4" rows="1" readonly="readonly" draggable="auto"></textarea>

           </fieldset>

        <fieldset id="Fieldset8" runat="server" class="auto-style17 ">

            <asp:ListBox ID="label_history_listbox" runat="server" Height="213px" Width="415px" OnSelectedIndexChanged="label_history_listbox_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            <br />

            <asp:TextBox ID="void_label_id_TextBox" runat="server" Height="16px" Width="315px"></asp:TextBox>
            <asp:Button ID="void_label_id_Button" runat="server" Text="Void Label" OnClick="void_label_id_Button_Click"/>
            <br />

            <asp:TextBox ID="tracking_number_textBox" runat="server" Height="19px" Width="405px"></asp:TextBox>
            <br />

            <asp:Label ID="Label18" runat="server" Text="Labels Selected to Manifest - Please select 'Completed' labels."></asp:Label>
            <br />

            <textarea id="manifest_label_id_richTextBox" runat="server" cols="20" rows="2" ></textarea>
            <br />

            <asp:Button ID="create_manifest_button" runat="server" Text="Create Manifest" />
            <asp:Label ID="Label19" runat="server" Text="Manifest download URL"></asp:Label>
            <asp:Button ID="clear_manifest_textBox_button" runat="server" Text="Clear selections" />
            <br />

            <asp:TextBox ID="manifest_textBox" runat="server"></asp:TextBox>

           </fieldset>

        <fieldset id="Fieldset9" runat="server" class="auto-style18">

            <asp:Button ID="create_label_Button" runat="server" Text="Create Label" OnClick="create_label_Button_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="print_Button" runat="server" Text="Print Label" OnClick="print_Button_Click" Visible="False" />

           </fieldset>

    </form>
</body>
</html>
