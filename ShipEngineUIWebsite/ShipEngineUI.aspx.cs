using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Security.Principal;


namespace ShipEngineUI
{
    public partial class ShipEngineUIWebsite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetWarehouses();

                GetCarrierAccounts();

                GetSalesOrders();

                GetLabelHistory();
            }
           
            ship_date_TextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }


        public class ShipEngineUI
        {

            public static string ImageURL = "";
            public static bool has_error = false;

            public static string label_id = "";
            public static string void_label_id_Response = "";

            public static string Tracking_number = "";

            public static string RATE_AMOUNT = "";

            public static string create_label_error = "";

            //Numbers

            public static string[] Numbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "." };

            //SHIPENGINE GET LABEL URL

            public static string get_label_URL = "";

            //MANIFEST
            public static string manifest_pdf_url = "";

            //GET LABEL IMAGE URL FROM FORM LOAD
            public static string label_url = "";
            public static string label_url_label_id = "";

            //Sales order ID
            public static string external_order_number = "";
            public static string sales_order_id = "";
            public static string fulfillment_status = "";

            //API KEY
            public static string apiKey = "TEST_ih19OEx3wVBhCUjTINHcKUfK4qevhTtSjDqV+T2RaK0";

            //ENDPOINT URL
            public static string urlString = "";

            //SHIP TO
            public static string shipTo_name = ""; //Required
            public static string shipTo_phone = ""; //Required
            public static string shipTo_email = "";
            public static string shipTo_company_name = "";
            public static string shipTo_address_line1 = ""; //Required
            public static string shipTo_address_line2 = "";
            public static string shipTo_address_line3 = "";
            public static string shipTo_city_locality = ""; //Required
            public static string shipTo_state_province = ""; //Required
            public static string shipTo_postal_code = ""; //Required
            public static string shipTo_country_code = ""; //Required
            public static string shipTo_address_residential_indicator = ""; //Required
            public static string shipTo_instructions = "";

            //SHIP FROM
            public static string shipFrom_name = ""; //Required
            public static string shipFrom_phone = ""; //Required
            public static string shipFrom_email = "";
            public static string shipFrom_company_name = "";
            public static string shipFrom_address_line1 = ""; //Required
            public static string shipFrom_address_line2 = "";
            public static string shipFrom_address_line3 = "";
            public static string shipFrom_city_locality = ""; //Required
            public static string shipFrom_state_province = ""; //Required
            public static string shipFrom_postal_code = ""; //Required
            public static string shipFrom_country_code = ""; //Required
            public static string shipFrom_address_residential_indicator = ""; //Required
            public static string shipFrom_instructions = "";

            //RETURNS, BOOL TRUE OR FALSE
            public static string is_return = "false";

            //CONFIRMATION
            public static string[] confirmation = new string[] { "none", "delivery", "signature",
        "adult_signature", "direct_signature", "delivery_mailed", "verbal_confirmation"};

            //CUSTOMS
            public static string[] contents = new string[] { "merchandise", "documents", "gift", "returned_goods", "sample" };
            public static string[] non_delivery = new string[] { "return_to_sender", "treat_as_abandoned" };

            public static string customs_items_description = "";
            public static string customs_items_quantity = "";
            public static string customs_items_value_currency = "";
            public static string customs_items_value_amount = "";
            public static string customs_items_weight_value = "";
            public static string customs_items_weight_unit = "";
            public static string customs_items_harmonized_tariff_code = "";
            public static string customs_items_country_of_origin = "";
            public static string customs_items_unit_of_measure = "";
            public static string customs_items_sku = "";
            public static string customs_items_sku_description = "";

            //ADVANCED OPTIONS
            public static string advanced_options_bill_to_account = "";
            public static string advanced_options_bill_to_country_code = "";
            public static string advanced_options_bill_to_party = null;
            public static string advanced_options_bill_to_postal_code = "";
            public static string advanced_options_contains_alcohol = "";
            public static string advanced_options_delivered_duty_paid = "";
            public static string advanced_options_dry_ice = "";
            public static string advanced_options_dry_ice_weight_value = "";
            public static string advanced_options_dry_ice_weight_unit = "";
            public static string advanced_options_non_machinable = "";
            public static string advanced_options_saturday_delivery = "";
            public static string advanced_options_fedex_freight = "";
            public static string advanced_options_shipper_load_and_count = "";
            public static string advanced_options_booking_confirmation = "";
            public static string advanced_options_use_ups_ground_freight_pricing = "";
            public static string advanced_options_freight_class = "";
            public static string advanced_options_custom_field1 = "";
            public static string advanced_options_custom_field2 = "";
            public static string advanced_options_custom_field3 = "";
            public static string advanced_options_origin_type = "";
            public static string advanced_options_shipper_release = "";
            public static string advanced_options_collect_on_delivery_payment_type = "";
            public static string advanced_options_collect_on_delivery_payment_amount_currency = "";
            public static string advanced_options_collect_on_delivery_payment_amount_amount = "";
            public static string advanced_options_third_party_consignee = "";
            public static string advanced_options_order_source_code = "";

            //PACKAGES
            public static string packages_package_id = "";
            public static string packages_package_code = "";
            public static string packages_content_description = "";
            public static string packages_weight_value = "";
            public static string packages_wieght_unit = "";
            public static string packages_dimensions_unit = "";
            public static string packages_dimensions_length = "";
            public static string packages_dimensions_width = "";
            public static string packages_dimensions_height = "";
            public static string insurance_provider = "";
            public static string packages_insured_value_currency = "";
            public static string packages_insured_value_amount = "";
            public static string packages_label_messages_reference1 = "";
            public static string packages_label_messages_reference2 = "";
            public static string packages_label_messages_reference3 = "";
            public static string packages_external_package_id = "";


            public static string is_return_label = "";
            public static string rma_number = "";
            public static string charge_event = "";
            public static string outbound_label_id = "";
            public static string validate_address = "";
        }

        public void GetCarrierAccounts()
        {

            //GET CARRIER ACCOUNTS
            try
            {

                //URL SOURCE
                ShipEngineUI.urlString = "https://api.shipengine.com/v1/carriers";

                //REQUEST
                WebRequest requestObject = WebRequest.Create(ShipEngineUI.urlString);
                requestObject.Method = "GET";

                //ADD API KEY TO HEADER
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;

                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    using (var reader = new StringReader(streamResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("carrier_id") == true)
                            {

                                string carrier_name1 = currentLine.Replace(" \"carrier_id\": \"", "");
                                string carrier_name = carrier_name1.Replace("\",", "");

                                //add to textbox

                                carrier_id_RichTextBox.Value = carrier_id_RichTextBox.Value.Trim() + "," + Environment.NewLine + carrier_name.Trim() + "|";

                            }
                            else if (currentLine.Contains("carrier_code") == true)
                            {
                                string carrier_code1 = currentLine.Replace("\"carrier_code\": \"", "");
                                string carrier_code = carrier_code1.Replace("\",", "");

                                carrier_id_RichTextBox.Value = carrier_id_RichTextBox.Value + carrier_code.Trim();
                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }
                        }

                        //PARSE AND ADD CARRIER ID's
                        string[] carrier_id_list1 = carrier_id_RichTextBox.Value.Split(',');
                        string[] carrier_id_list = carrier_id_list1.Distinct().ToArray();
                        foreach (string carrier_id in carrier_id_list)
                        {
                            if (carrier_id.Trim() == "")
                                continue;

                            carrier_id_ComboBox.Items.Add(carrier_id.Trim());
                        }
                    }
                }
            }
            catch (Exception HTTPexception)
            {


            }
        }

        public void GetWarehouses()
        {

            //GET WAREHOUSES
            try
            {
                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v1/warehouses";

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET";

                //SE AUTH
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;


                //Get all warehouseId's
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    using (var reader = new StringReader(streamResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("warehouse_id") == true)
                            {

                                string warehouse_id1 = currentLine.Replace(" \"warehouse_id\": \"", "");
                                string warehouse_id = warehouse_id1.Replace("\",", "");

                                //add to textbox
                                warehouse_id_RichTextBox.Value = warehouse_id_RichTextBox.Value.Trim() + "~" + Environment.NewLine + warehouse_id.Trim() + "|";

                            }
                            else if (currentLine.Contains("name") == true)
                            {
                                string warehouse_name1 = currentLine.Replace("\"name\": \"", "");
                                string warehouse_name = warehouse_name1.Replace("\",", "");

                                warehouse_id_RichTextBox.Value = warehouse_id_RichTextBox.Value + warehouse_name.Trim() + "]";
                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }
                        }

                        //PARSE AND ADD CARRIER ID's
                        string[] warehouse_id_list1 = warehouse_id_RichTextBox.Value.Split('~');
                        string[] warehouse_id_list = warehouse_id_list1.Distinct().ToArray();
                        foreach (string warehouse_id in warehouse_id_list)
                        {
                            if (warehouse_id.Trim() == "")
                                continue;

                            string fix = warehouse_id.Substring(0, warehouse_id.IndexOf("]"));
                            warehouse_id_ComboBox.Items.Add(fix.Trim());

                        }
                    }
                }
            }
            catch (Exception HTTPexception)
            {

            }
        }

        public void GetSalesOrders()
        {
            //GET SALES ORDERS
            try
            {
                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v-beta/sales_orders";

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET";

                //SE AUTH
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;


                //Get all sales orders
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    using (var reader = new StringReader(streamResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("sales_order_id") == true)
                            {

                                string sales_order_id1 = currentLine.Replace("\"sales_order_id\": \"", "");
                                string sales_order_id = sales_order_id1.Replace("\",", "");

                                //add to textbox
                                sales_order_RichTextBox.Value += sales_order_id.Trim() + " | ";

                                //ShipEngineUI.sales_order_id = sales_order_id;

                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                            if (currentLine.Contains("external_order_number") == true)
                            {

                                string external_order_number1 = currentLine.Replace("\"external_order_number\": \"", "");
                                string external_order_number = external_order_number1.Replace("\",", "");

                                //add to textbox
                                sales_order_RichTextBox.Value = sales_order_RichTextBox.Value.Trim() + external_order_number.Trim() + " - ";

                                //ShipEngineUI.external_order_number = external_order_number;
                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                            if (currentLine.Contains("fulfillment_status") == true)
                            {

                                string fulfillment_status1 = currentLine.Replace("\"fulfillment_status\": \"", "");
                                string fulfillment_status = fulfillment_status1.Replace("\",", "");

                                //add to textbox
                                sales_order_RichTextBox.Value += fulfillment_status.Trim() + Environment.NewLine + ",";

                                //ShipEngineUI.fulfillment_status = fulfillment_status;
                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                            //string line = ShipEngineUI.external_order_number.Trim() + " - " + ShipEngineUI.fulfillment_status.Trim() + " | " +
                            // ShipEngineUI.sales_order_id.Trim() + Environment.NewLine + ",";

                            // sales_order_RichTextBox.Text += line;

                        }

                        //PARSE AND ADD SALES ORDERS
                        string[] sales_order_list1 = sales_order_RichTextBox.Value.Split(',');
                        string[] sales_order_list = sales_order_list1.Distinct().ToArray();
                        foreach (string sales_order in sales_order_list)
                        {
                            if (sales_order.Trim() == "")
                                continue;

                            sales_order_ListBox.Items.Add(sales_order.Trim());
                        }
                    }
                }
            }
            catch (Exception HTTPexception)
            {
                sales_order_ListBox.Items.Add("ShipEngine found no sales orders to import at this time.");
                sales_order_ListBox.Enabled = false;
                //notify_shipped_checkBox.Enabled = false;
            }
        }

        
        public void GetLabelHistory()
        {
            label_id_richTextBox.Value = string.Empty;

            //GET LABELS
            try
            {
                string todaysDate = DateTime.Today.ToString();

                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v1/labels?created_at_start=" + todaysDate + "&page_size=100";
                ShipEngineUI.get_label_URL = URLstring;

                //REQUEST
                WebRequest requestObject = WebRequest.Create(ShipEngineUI.get_label_URL);
                requestObject.Method = "GET";

                //SE AUTH
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;

                //Get List labels data
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    using (var reader = new StringReader(streamResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("label_id") == true)
                            {

                                string label_id1 = currentLine.Replace("\"label_id\": \"", "");
                                string label_id = label_id1.Replace("\",", "");

                                //add to textbox
                                label_id_richTextBox.Value += label_id.Trim() + " | ";
                                label_id = ShipEngineUI.label_url_label_id.Trim();

                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                            if (currentLine.Contains("\"status\"") == true)
                            {

                                string voided1 = currentLine.Replace("\"", "");
                                string voided = voided1.Replace(",", "");

                                //add to textbox
                                label_id_richTextBox.Value = label_id_richTextBox.Value.Trim() + voided.Trim() + " > ";

                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                            if (currentLine.Contains("\"carrier_code\"") == true)
                            {

                                string carrier_code1 = currentLine.Replace("\"", "");
                                string carrier_code = carrier_code1.Replace(",", "");

                                //add to textbox
                                label_id_richTextBox.Value = label_id_richTextBox.Value.Trim() + " " + carrier_code.Trim() + " < ";

                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                            if (currentLine.Contains(ShipEngineUI.label_url_label_id.Trim() + ".png") == true)
                            {

                                string img_url1 = currentLine.Replace("\"png\": \"", "");
                                string img_url = img_url1.Replace("\",", "");

                                //add to textbox
                                label_id_richTextBox.Value += img_url.Trim() + Environment.NewLine + ",";
                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                            if (currentLine.Contains("\"total\": 543"))
                            {

                                ShipEngineUI.get_label_URL = ShipEngineUI.get_label_URL + "&page=2";

                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }

                        }

                        //PARSE AND ADD LABELS
                        string[] label_id_list1 = label_id_richTextBox.Value.Split(',');
                        string[] label_id_list = label_id_list1.Distinct().ToArray();
                        foreach (string label_id in label_id_list)
                        {
                            if (label_id.Trim() == "")
                                continue;

                            label_history_listbox.Items.Add(label_id.Trim());

                        }

                        if (label_history_listbox.Items.Count == 0)
                        {
                            label_history_listbox.Enabled = false;
                            create_manifest_button.Enabled = false;
                            label_history_listbox.Items.Add("ShipEngine found no label history for today.");
                        }
                        else if (label_history_listbox.Items.Count != 0)
                        {
                            label_history_listbox.Enabled = true;
                            create_manifest_button.Enabled = true;
                            label_history_listbox.Items.Remove("ShipEngine found no label history for today.");
                        }

                        //RemoveURL(label_history_listbox, "http");
                    }
                }
            }
            catch (Exception HTTPexception)
            {

            }

        }

        protected void carrier_id_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            service_code_RichTextBox.Value = string.Empty;
            package_code_RichTextBox.Value = string.Empty;
            service_code_ComboBox.Items.Clear();
            package_code_ComboBox.Items.Clear();

            int selectedIndex = carrier_id_ComboBox.SelectedIndex;


            //GET CARRIER ID
            string carrier_id1 = carrier_id_ComboBox.SelectedItem.Text;
            carrier_id1 = carrier_id1.Remove(carrier_id1.IndexOf("|") + 1);
            string carrier_id = carrier_id1.Replace("|", "");

            //GET CARRIER SERVICES
            try
            {
                //URL SOURCE
                ShipEngineUI.urlString = "https://api.shipengine.com/v1/carriers/" + carrier_id + "/services";

                //REQUEST
                WebRequest requestObject = WebRequest.Create(ShipEngineUI.urlString);
                requestObject.Method = "GET";

                //ADD API KEY TO HEADER
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;


                //GET ALL WAREHOUSE ID's
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();


                    using (var reader = new StringReader(streamResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("service_code") == true)
                            {

                                string service_code1 = currentLine.Replace(" \"service_code\": \"", "");
                                string service_code = service_code1.Replace("\",", "");

                                //add to textbox
                                service_code_RichTextBox.Value = service_code_RichTextBox.Value.Trim() + "," + Environment.NewLine + service_code.Trim() + "|";

                            }
                            else if (currentLine.Contains("name") == true)
                            {
                                string carrier_code1 = currentLine.Replace(" \"name\": \"", "");
                                string carrier_code = carrier_code1.Replace("\",", "");

                                service_code_RichTextBox.Value = service_code_RichTextBox.Value + carrier_code.Trim();
                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }
                        }

                        //PARSE AND ADD CARRIER ID's
                        string[] service_code_list1 = service_code_RichTextBox.Value.Split(',');
                        string[] service_code_list = service_code_list1.Distinct().ToArray();
                        foreach (string service_code in service_code_list)
                        {
                            if (service_code.Trim() == "")
                                continue;

                            service_code_ComboBox.Items.Add(service_code.Trim());
                        }

                        service_code_ComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch
            {

            }

            //GET CARRIER PACKAGES
            try
            {
                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v1/carriers/" + carrier_id + "/packages";

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET";

                //SE AUTH
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;


                //Get all packages
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    using (var reader = new StringReader(streamResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("package_code") == true)
                            {

                                string package_code1 = currentLine.Replace(" \"package_code\": \"", "");
                                string package_code = package_code1.Replace("\",", "");

                                //add to textbox
                                package_code_RichTextBox.Value = package_code_RichTextBox.Value.Trim() + "," + Environment.NewLine + package_code.Trim();

                            }
                            else
                            {
                                currentLine.Replace(currentLine, "");
                            }
                        }

                        //PARSE AND ADD CARRIER ID's
                        string[] package_code_list1 = package_code_RichTextBox.Value.Split(',');
                        string[] package_code_list = package_code_list1.Distinct().ToArray();
                        foreach (string package_code in package_code_list)
                        {
                            if (package_code.Trim() == "")
                                continue;

                            package_code_ComboBox.Items.Add(package_code.Trim());
                        }
                    }
                }
            }
            catch (Exception HTTPexception)
            {

            }

            //ADDED
            package_code_ComboBox.SelectedIndex = 0;
            
            carrier_id_ComboBox.SelectedIndex = selectedIndex;
        }

        protected void warehouse_id_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            //GET WAREHOUSE ID
            string warehouse_id1 = warehouse_id_ComboBox.SelectedItem.Text;
            warehouse_id1 = warehouse_id1.Remove(warehouse_id1.IndexOf("|") + 1);
            string warehouse_id = warehouse_id1.Replace("|", "");

            int WHselectedindex = warehouse_id_ComboBox.SelectedIndex;
            int Cselectedindex = carrier_id_ComboBox.SelectedIndex;


            try
            {
                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v1/warehouses/" + warehouse_id;

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET"; ;

                //SE AUTH
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;

                //Get Address
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    //
                    int originAddress1 = streamResponse.IndexOf(" \"origin_address\": ") + " \"origin_address\": ".Length;
                    int originAddress2 = streamResponse.LastIndexOf(" \"return_address\":");

                    string originAddress = streamResponse.Substring(originAddress1, originAddress2 - originAddress1);

                    using (var reader = new StringReader(originAddress))
                    {
                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            //NAME
                            if (currentLine.Contains(" \"name\": \"") == true)
                            {

                                //Replace "warehouse_id": " ",
                                string Wh_Name1 = currentLine.Replace("\"name\": \"", "");
                                string Wh_Name = Wh_Name1.Replace("\",", "");

                                //add to textbox

                                shipFrom_name_TextBox.Text = Wh_Name;

                            }

                            //PHONE
                            if (currentLine.Contains("\"phone\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_Phone1 = currentLine.Replace("\"phone\": \"", "");
                                string Wh_Phone = Wh_Phone1.Replace("\",", "");

                                //add to textbox

                                shipFrom_phone_TextBox.Text = Wh_Phone;
                            }

                            //Company
                            if (currentLine.Contains("\"company_name\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_CompanyName1 = currentLine.Replace("\"company_name\": \"", "");
                                string Wh_CompanyName = Wh_CompanyName1.Replace("\",", "");

                                //add to textbox

                                shipFrom_company_name_TextBox.Text = Wh_CompanyName;
                            }

                            //AddressLine 1
                            if (currentLine.Contains("\"address_line1\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_AddressL1 = currentLine.Replace("\"address_line1\": \"", "");
                                string Wh_AddressL = Wh_AddressL1.Replace("\",", "");

                                //add to textbox

                                shipFrom_address_line1_TextBox.Text = Wh_AddressL;
                            }

                            //AddressLine 2
                            if (currentLine.Contains("\"address_line2\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_AddressL2 = currentLine.Replace("\"address_line2\": \"", "");
                                string Wh_AddressL3 = Wh_AddressL2.Replace("\",", "");

                                //add to textbox

                                shipFrom_address_line2_TextBox.Text = Wh_AddressL3;
                            }


                            //AddressLine 3
                            if (currentLine.Contains("\"address_line3\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_AddressL4 = currentLine.Replace("\"address_line3\": \"", "");
                                string Wh_AddressL5 = Wh_AddressL4.Replace("\",", "");

                                //add to textbox

                                shipFrom_address_line3_TextBox.Text = Wh_AddressL5;
                            }

                            //City
                            if (currentLine.Contains("\"city_locality\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_City1 = currentLine.Replace("\"city_locality\": \"", "");
                                string Wh_City = Wh_City1.Replace("\",", "");

                                //add to textbox

                                shipFrom_city_locality_TextBox.Text = Wh_City;
                            }

                            //State Province
                            if (currentLine.Contains("\"state_province\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_StateProvince1 = currentLine.Replace("\"state_province\": \"", "");
                                string Wh_StateProvince = Wh_StateProvince1.Replace("\",", "");

                                //add to textbox

                                shipFrom_state_province_TextBox.Text = Wh_StateProvince;
                            }

                            //Postal Code
                            if (currentLine.Contains("\"postal_code\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_PostalCode1 = currentLine.Replace("\"postal_code\": \"", "");
                                string Wh_PostalCode = Wh_PostalCode1.Replace("\",", "");

                                //add to textbox

                                shipFrom_postal_code_TextBox.Text = Wh_PostalCode;
                            }

                            //Country Code
                            if (currentLine.Contains("\"country_code\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",

                                string Wh_CountryCode1 = currentLine.Replace("\"country_code\": \"", "");
                                string Wh_CountryCode = Wh_CountryCode1.Replace("\",", "");


                                //add to textbox

                                shipFrom_country_code_TextBox.Text = Wh_CountryCode;
                                //shipFrmCountryTextBox.Text = shipFrmCountryTextBox.Text.Replace("    ","");

                            }

                            //remove spaces
                            //List Textboxes
                            IList<T> GetAllControls<T>(Control control) where T : Control
                            {
                                var TextBoxes = new List<T>();
                                foreach (Control item in control.Controls)
                                {
                                    var ctr = item as T;
                                    if (ctr != null)
                                        TextBoxes.Add(ctr);
                                    else
                                        TextBoxes.AddRange(GetAllControls<T>(item));
                                }
                                return TextBoxes;
                            }

                            //remove spaces loop
                            var textBoxesList = GetAllControls<TextBox>(this);
                            foreach (TextBox TextBoxes in textBoxesList)
                            {
                                TextBoxes.Text = TextBoxes.Text.Replace("    ", "");
                            }

                            //warehouse_id_ComboBox.Items.Clear();
                            //GetWarehouses();

                            //carrier_id_ComboBox.Items.Clear();
                            //GetCarrierAccounts();

                            carrier_id_ComboBox.SelectedIndex = Cselectedindex;
                            warehouse_id_ComboBox.SelectedIndex = WHselectedindex;
                        }
                    }
                }
            }
            catch (Exception HTTPexception)
            {

            }
        }


        public void ShowMessageBox(Page page, string message)
        {
            Type cstype = page.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            // Find the first unregistered script number
            int ScriptNumber = 0;
            bool ScriptRegistered = false;
            do
            {
                ScriptNumber++;
                ScriptRegistered = cs.IsStartupScriptRegistered(cstype, "PopupScript" + ScriptNumber);
            } while (ScriptRegistered == true);

            //Execute the new script number that we found
            cs.RegisterStartupScript(cstype, "PopupScript" + ScriptNumber, "alert('" + message + "');", true);
        }

        protected void get_Rates_Button_Click(object sender, EventArgs e)
        {
            rate_response_RichTextBox.Value = string.Empty;

            try
            {
                string carrier_id1 = carrier_id_ComboBox.SelectedItem.ToString();
                carrier_id1 = carrier_id1.Remove(carrier_id1.IndexOf("|") + 1);
                string carrier_id = carrier_id1.Replace("|", "");

                string service_code1 = service_code_ComboBox.SelectedItem.ToString();
                service_code1 = service_code1.Remove(service_code1.IndexOf("|") + 1);
                string service_code = service_code1.Replace("|", "");

                Random logID = new Random();
                string rateLogId = logID.Next(0, 1000000).ToString("D6");

                //URI - POST
                WebRequest request = WebRequest.Create("https://api.shipengine.com/v1/rates");
                request.Method = "POST";

                request.Headers.Add("API-key", ShipEngineUI.apiKey);

                string warehouse_id = warehouse_id_ComboBox.SelectedItem.ToString();
                string ship_date = ship_date_TextBox.Text;

                //SHIPENGINE UI VARIABLES
                #region SHIPENGINE UI VARIABLES
                ShipEngineUI.shipTo_name = shipTo_name_TextBox.Text;
                ShipEngineUI.shipTo_phone = shipTo_phone_TextBox.Text;
                ShipEngineUI.shipTo_company_name = shipTo_company_name_TextBox.Text;
                ShipEngineUI.shipTo_address_line1 = shipTo_address_line1_TextBox.Text;
                ShipEngineUI.shipTo_address_line2 = shipTo_address_line2_TextBox.Text;
                ShipEngineUI.shipTo_address_line3 = shipTo_address_line3_TextBox.Text;
                ShipEngineUI.shipTo_city_locality = shipTo_city_locality_TextBox.Text;
                ShipEngineUI.shipTo_state_province = shipTo_state_province_TextBox.Text;
                ShipEngineUI.shipTo_postal_code = shipTo_postal_code_TextBox.Text;
                ShipEngineUI.shipTo_country_code = shipTo_country_code_TextBox.Text;
                ShipEngineUI.shipTo_address_residential_indicator = "no";
                //if (shipTo_address_residential_indicator_comboBox.SelectedItem == "")
                //{
                //    ShipEngineUI.shipTo_address_residential_indicator = "no";
                //}

                ShipEngineUI.shipFrom_name = shipFrom_name_TextBox.Text;
                ShipEngineUI.shipFrom_phone = shipFrom_phone_TextBox.Text;
                ShipEngineUI.shipFrom_company_name = shipFrom_company_name_TextBox.Text;
                ShipEngineUI.shipFrom_address_line1 = shipFrom_address_line1_TextBox.Text;
                ShipEngineUI.shipFrom_address_line2 = shipFrom_address_line2_TextBox.Text;
                ShipEngineUI.shipFrom_address_line3 = shipFrom_address_line3_TextBox.Text;
                ShipEngineUI.shipFrom_city_locality = shipFrom_city_locality_TextBox.Text;
                ShipEngineUI.shipFrom_state_province = shipFrom_state_province_TextBox.Text;
                ShipEngineUI.shipFrom_postal_code = shipFrom_postal_code_TextBox.Text;
                ShipEngineUI.shipFrom_country_code = shipFrom_country_code_TextBox.Text;
                ShipEngineUI.shipFrom_address_residential_indicator = "no";
                //if (shipFrom_address_residential_indicator_comboBox.SelectedItem == "")
                //{
                //    ShipEngineUI.shipFrom_address_residential_indicator = "no";
                //}

                ShipEngineUI.packages_dimensions_length = packages_dimensions_length_numericUpDown.Text;
                ShipEngineUI.packages_dimensions_width = packages_dimensions_width_numericUpDown.Text;
                ShipEngineUI.packages_dimensions_height = packages_dimensions_height_numericUpDown.Text;

                ShipEngineUI.packages_weight_value = packages_weight_value_numericUpDown.Text;

                //SHIPENGINE UI ADVANCED OPTIONS
                //ShipEngineUI.advanced_options_bill_to_account = bill_to_account_textBox.Text;
                //ShipEngineUI.advanced_options_bill_to_country_code = bill_to_country_code_textBox.Text;
                //ShipEngineUI.advanced_options_bill_to_party = bill_to_party_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_bill_to_postal_code = bill_to_postal_code_textBox.Text;

                //ShipEngineUI.advanced_options_contains_alcohol = contains_alcohol_comboBox.SelectedItem.ToString();
                //ShipEngineUI.advanced_options_delivered_duty_paid = delivered_duty_paid_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_dry_ice = dry_ice_comboBox.SelectedItem.ToString();
                //ShipEngineUI.advanced_options_dry_ice_weight_value = dry_ice_weight_numericUpDown.Value.ToString();
                //ShipEngineUI.advanced_options_dry_ice_weight_unit = dry_ice_weight_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_non_machinable = non_machinable_comboBox.SelectedItem.ToString();
                //ShipEngineUI.advanced_options_saturday_delivery = saturday_delivery_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_origin_type = origin_type_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_custom_field1 = custom_field1_textBox.Text;
                //ShipEngineUI.advanced_options_custom_field2 = custom_field2_textBox.Text;
                //ShipEngineUI.advanced_options_custom_field3 = custom_field3_textBox.Text;

                //ShipEngineUI.insurance_provider = insurance_provider_comboBox.SelectedItem.ToString();
                //ShipEngineUI.packages_insured_value_amount = insured_value_amont_numericUpDown.Value.ToString();
                //ShipEngineUI.packages_insured_value_currency = insured_value_currency_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_third_party_consignee = third_party_consignee_comboBox.SelectedItem.ToString();
                #endregion

                //RATE REQUEST
                #region  Rate Request
                //POST REQUEST
                string rateRequestBody = "" +
                    "{\r\n    \"rate_options\": {" +
                    "\r\n        \"carrier_ids\": [" +
                    "\r\n            \"" + carrier_id + "\"" +
                    "\r\n        ]" +
                    "\r\n    }," +
                    "\r\n    \"shipment\": {" +
                    "\r\n        \"validate_address\": \"no_validation\"," +
                    "\r\n        \"carrier_id\": \"" + carrier_id + "\"," +
                    "\r\n        \"warehouse_id\": \"\"," +
                    "\r\n        \"service_code\": \"" + service_code + "\"," +
                    "\r\n        \"external_order_id\": null," +
                    "\r\n        \"ship_date\": \"" + ship_date + "\"," +
                    "\r\n        \"is_return_label\": false," +
                    "\r\n        \"items\": []," +
                    "\r\n        \"ship_to\": {" +
                    "\r\n            \"name\": \"" + ShipEngineUI.shipTo_name + "\"," +
                    "\r\n            \"phone\": \"" + ShipEngineUI.shipTo_phone + "\"," +
                    "\r\n            \"company_name\": \"" + ShipEngineUI.shipTo_company_name + "\"," +
                    "\r\n            \"address_line1\": \"" + ShipEngineUI.shipTo_address_line1 + "\"," +
                    "\r\n            \"address_line2\": \"" + ShipEngineUI.shipTo_address_line2 + "\"," +
                    "\r\n            \"address_line3\": \"" + ShipEngineUI.shipTo_address_line3 + "\"," +
                    "\r\n            \"city_locality\": \"" + ShipEngineUI.shipTo_city_locality + "\"," +
                    "\r\n            \"state_province\": \"" + ShipEngineUI.shipTo_state_province + "\"," +
                    "\r\n            \"postal_code\": \"" + ShipEngineUI.shipTo_postal_code + "\"," +
                    "\r\n            \"country_code\": \"" + ShipEngineUI.shipTo_country_code + "\"," +
                    "\r\n            \"address_residential_indicator\": \"" + ShipEngineUI.shipTo_address_residential_indicator + "\"" +
                    "\r\n        }," +
                    "\r\n        \"ship_from\": {" +
                    "\r\n            \"name\": \"" + ShipEngineUI.shipFrom_name + "\"," +
                    "\r\n            \"phone\": \"" + ShipEngineUI.shipFrom_phone + "\"," +
                    "\r\n            \"company_name\": \"" + ShipEngineUI.shipFrom_company_name + "\"," +
                    "\r\n            \"address_line1\": \"" + ShipEngineUI.shipFrom_address_line1 + "\"," +
                    "\r\n            \"address_line2\": \"" + ShipEngineUI.shipFrom_address_line2 + "\"," +
                    "\r\n            \"address_line3\": \"" + ShipEngineUI.shipFrom_address_line3 + "\"," +
                    "\r\n            \"city_locality\": \"" + ShipEngineUI.shipFrom_city_locality + "\"," +
                    "\r\n            \"state_province\": \"" + ShipEngineUI.shipFrom_state_province + "\"," +
                    "\r\n            \"postal_code\": \"" + ShipEngineUI.shipFrom_postal_code + "\"," +
                    "\r\n            \"country_code\": \"" + ShipEngineUI.shipFrom_country_code + "\"," +
                    "\r\n            \"address_residential_indicator\": \"" + ShipEngineUI.shipFrom_address_residential_indicator + "\"" +
                    "\r\n        }," +
                    "\r\n        \"confirmation\": \"" + delivery_confirmation_ComboBox.SelectedItem.ToString() + "\"," +
                    "\r\n        \"origin_type\": \"\"," +
                    "\r\n        \"insurance_provider\": \"" + insurance_provider_comboBox.SelectedItem.ToString() + "\"," +
                    "\r\n        \"packages\": [" +
                    "\r\n            {" +
                    "\r\n                \"package_code\": \"" + package_code_ComboBox.SelectedItem.ToString() + "\"," +
                    "\r\n                \"weight\": {" +
                    "\r\n                    \"value\": " + ShipEngineUI.packages_weight_value + "," +
                    "\r\n                    \"unit\": \"pound\"" +
                    "\r\n                }," +
                    "\r\n                \"dimensions\": {" +
                    "\r\n                    \"unit\": \"inch\"," +
                    "\r\n                    \"length\": " + ShipEngineUI.packages_dimensions_length + "," +
                    "\r\n                    \"width\": " + ShipEngineUI.packages_dimensions_width + "," +
                    "\r\n                    \"height\": " + ShipEngineUI.packages_dimensions_height + "" +
                    "\r\n                }," +
                    "\r\n                \"insured_value\": {" +
                    "\r\n                    \"currency\": \"" + insured_value_currency_comboBox.SelectedItem.ToString() + "\"," +
                    "\r\n                    \"amount\": \"" + insured_value_amont_numericUpDown.Text + "\"," +
                    "\r\n                }," +
                    "\r\n                \"label_messages\": {" +
                    "\r\n                    \"reference1\": null," +
                    "\r\n                    \"reference2\": null," +
                    "\r\n                    \"reference3\": null" +
                    "\r\n                }," +
                    "\r\n                \"external_package_id\": \"" + rateLogId + "\"" +
                    "\r\n            }" +
                    "\r\n        ]" +
                    "\r\n    }" +
                    "\r\n}";

                #endregion

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(rateRequestBody);

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                Stream stream = request.GetRequestStream();

                stream.Write(data, 0, data.Length);
                stream.Close();


                //Documents path REQUEST LOG
                //string docPath = @"..\..\Resources\Logs";
                //File.WriteAllText(Path.Combine(docPath, "RateRequest - " + rateLogId + ".txt"), rateRequestBody);


                WebResponse requestResponse = request.GetResponse();
                stream = requestResponse.GetResponseStream();

                StreamReader parseResponse = new StreamReader(stream);
                rate_response_RichTextBox.Value = parseResponse.ReadToEnd();

                string responseBodyText = rate_response_RichTextBox.Value;
                //File.WriteAllText(Path.Combine(docPath, "RateResponse - " + rateLogId + ".txt"), responseBodyText);

                stream.Close();

                
                //LOAD LISTBOX
                using (var reader = new StringReader(responseBodyText))
                {

                    string ratesResponse = "";

                    for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                    {


                        if (currentLine.Contains("\"amount\"") == true)
                        {

                            ratesResponse += currentLine;
                            //ratesResponse = ratesResponse.Remove(ratesResponse.IndexOf("~") + 1);
                        }
                        else
                        {
                            currentLine.Replace(currentLine, "");
                        }

                        if (currentLine.Contains("\"package_type\"") == true)
                        {

                            ratesResponse += Environment.NewLine + currentLine + Environment.NewLine;

                        }
                        else
                        {
                            currentLine.Replace(currentLine, "");
                        }

                        if (currentLine.Contains("\"service_code\"") == true)
                        {

                            ratesResponse += currentLine + Environment.NewLine + Environment.NewLine;

                        }
                        else
                        {
                            currentLine.Replace(currentLine, "");
                        }

                    }

                    rate_response_RichTextBox.Value = ratesResponse;

                    rate_response_RichTextBox.Value = rate_response_RichTextBox.Value.Replace("\"amount\": 0.0", "");
                    rate_response_RichTextBox.Value = rate_response_RichTextBox.Value.Replace(" ", "");
                    rate_response_RichTextBox.Value = rate_response_RichTextBox.Value.Replace("\"", "");
                    rateResponseRawTextBox.Value = rateRequestBody;

                }

                stream.Close();

            }
            catch (WebException Exception)
            {

                using (WebResponse ShipEngineErrorResponse = Exception.Response)
                {
                    HttpWebResponse ShipEngineResponse = (HttpWebResponse)ShipEngineErrorResponse;
                    Console.WriteLine("Error code: {0}", ShipEngineResponse.StatusCode);
                    using (Stream parseResponse = ShipEngineErrorResponse.GetResponseStream())

                    using (var reader = new StreamReader(parseResponse))
                    {
                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("message") == true)
                            {

                                string ShipEngineErrorBody1 = currentLine.Replace("\"message\": \"", "");
                                string ShipEngineErrorBody = ShipEngineErrorBody1.Replace("\",", "");

                                rate_response_RichTextBox.Value = ShipEngineErrorBody;

                                ShowMessageBox(this, Exception.ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception exeption)
            {
                ShowMessageBox(this, exeption.ToString());
            }
        }

        protected void create_label_Button_Click(object sender, EventArgs e)
        {

            label_RichTextBox.Value = string.Empty;
            void_label_id_TextBox.Text = string.Empty;
            this.AsyncMode = true;

            try
            {
                string carrier_id1 = carrier_id_ComboBox.SelectedItem.ToString();
                carrier_id1 = carrier_id1.Remove(carrier_id1.IndexOf("|") + 1);
                string carrier_id = carrier_id1.Replace("|", "");

                string service_code1 = service_code_ComboBox.SelectedItem.ToString();
                service_code1 = service_code1.Remove(service_code1.IndexOf("|") + 1);
                string service_code = service_code1.Replace("|", "");

                //LOGID
                Random logID = new Random();
                string labelLogId = logID.Next(0, 1000000).ToString("D6");

                //SHIP DATE
                string ship_date = ship_date_TextBox.Text;


                //SHIPENGINE UI VARIABLES
                #region SHIPENGINE UI VARIABLES
                ShipEngineUI.shipTo_name = shipTo_name_TextBox.Text;
                ShipEngineUI.shipTo_phone = shipTo_phone_TextBox.Text;
                ShipEngineUI.shipTo_company_name = shipTo_company_name_TextBox.Text;
                ShipEngineUI.shipTo_address_line1 = shipTo_address_line1_TextBox.Text;
                ShipEngineUI.shipTo_address_line2 = shipTo_address_line2_TextBox.Text;
                ShipEngineUI.shipTo_address_line3 = shipTo_address_line3_TextBox.Text;
                ShipEngineUI.shipTo_city_locality = shipTo_city_locality_TextBox.Text;
                ShipEngineUI.shipTo_state_province = shipTo_state_province_TextBox.Text;
                ShipEngineUI.shipTo_postal_code = shipTo_postal_code_TextBox.Text;
                ShipEngineUI.shipTo_country_code = shipTo_country_code_TextBox.Text;
                ShipEngineUI.shipTo_address_residential_indicator = shipTo_address_residential_indicator_comboBox.SelectedItem.Text;
                //if (shipTo_address_residential_indicator_comboBox.SelectedItem == "")
                //{
                //    ShipEngineUI.shipTo_address_residential_indicator = "no";
                //}

                ShipEngineUI.shipFrom_name = shipFrom_name_TextBox.Text;
                ShipEngineUI.shipFrom_phone = shipFrom_phone_TextBox.Text;
                ShipEngineUI.shipFrom_company_name = shipFrom_company_name_TextBox.Text;
                ShipEngineUI.shipFrom_address_line1 = shipFrom_address_line1_TextBox.Text;
                ShipEngineUI.shipFrom_address_line2 = shipFrom_address_line2_TextBox.Text;
                ShipEngineUI.shipFrom_address_line3 = shipFrom_address_line3_TextBox.Text;
                ShipEngineUI.shipFrom_city_locality = shipFrom_city_locality_TextBox.Text;
                ShipEngineUI.shipFrom_state_province = shipFrom_state_province_TextBox.Text;
                ShipEngineUI.shipFrom_postal_code = shipFrom_postal_code_TextBox.Text;
                ShipEngineUI.shipFrom_country_code = shipFrom_country_code_TextBox.Text;
                ShipEngineUI.shipFrom_address_residential_indicator = shipFrom_address_residential_indicator_comboBox.SelectedItem.Text;
                //if (shipFrom_address_residential_indicator_comboBox.SelectedItem == "")
                //{
                //    ShipEngineUI.shipFrom_address_residential_indicator = "no";
                //}

                ShipEngineUI.packages_dimensions_length = packages_dimensions_length_numericUpDown.Text;
                ShipEngineUI.packages_dimensions_width = packages_dimensions_width_numericUpDown.Text;
                ShipEngineUI.packages_dimensions_height = packages_dimensions_height_numericUpDown.Text;

                ShipEngineUI.packages_weight_value = packages_weight_value_numericUpDown.Text;

                //SHIPENGINE UI ADVANCED OPTIONS
                //ShipEngineUI.advanced_options_bill_to_account = bill_to_account_textBox.Text;
                //ShipEngineUI.advanced_options_bill_to_country_code = bill_to_country_code_textBox.Text;
                //ShipEngineUI.advanced_options_bill_to_party = bill_to_party_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_bill_to_postal_code = bill_to_postal_code_textBox.Text;

                //ShipEngineUI.advanced_options_contains_alcohol = contains_alcohol_comboBox.SelectedItem.ToString();
                //ShipEngineUI.advanced_options_delivered_duty_paid = delivered_duty_paid_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_dry_ice = dry_ice_comboBox.SelectedItem.ToString();
                //ShipEngineUI.advanced_options_dry_ice_weight_value = dry_ice_weight_numericUpDown.Value.ToString();
                //ShipEngineUI.advanced_options_dry_ice_weight_unit = dry_ice_weight_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_non_machinable = non_machinable_comboBox.SelectedItem.ToString();
                //ShipEngineUI.advanced_options_saturday_delivery = saturday_delivery_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_origin_type = origin_type_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_custom_field1 = custom_field1_textBox.Text;
                //ShipEngineUI.advanced_options_custom_field2 = custom_field2_textBox.Text;
                //ShipEngineUI.advanced_options_custom_field3 = custom_field3_textBox.Text;

                //ShipEngineUI.insurance_provider = insurance_provider_comboBox.SelectedItem.ToString();
                //ShipEngineUI.packages_insured_value_amount = insured_value_amont_numericUpDown.Value.ToString();
                //ShipEngineUI.packages_insured_value_currency = insured_value_currency_comboBox.SelectedItem.ToString();

                //ShipEngineUI.advanced_options_third_party_consignee = third_party_consignee_comboBox.SelectedItem.ToString();
                #endregion

                //URI - POST
                WebRequest request = WebRequest.Create("https://api.shipengine.com/v1/labels");
                request.Method = "POST";

                //API Key
                request.Headers.Add("API-key", ShipEngineUI.apiKey);

                //POST REQUEST
                #region REQUEST BODY
                string createLabelrequestBody = "" +
                    "{\r\n    \"rate_options\": {" +
                    "\r\n        \"carrier_ids\": [" +
                    "\r\n            \"" + carrier_id + "\"" +
                    "\r\n        ]" +
                    "\r\n    }," +
                    "\r\n    \"shipment\": {" +
                    "\r\n        \"validate_address\": \"no_validation\"," +
                    "\r\n        \"carrier_id\": \"" + carrier_id + "\"," +
                    "\r\n        \"warehouse_id\": \"\"," +
                    "\r\n        \"service_code\": \"" + service_code + "\"," +
                    "\r\n        \"external_order_id\": null," +
                    "\r\n        \"ship_date\": \"" + ship_date + "\"," +
                    "\r\n        \"is_return_label\": false," +
                    "\r\n        \"items\": []," +
                    "\r\n        \"ship_to\": {" +
                    "\r\n            \"name\": \"" + ShipEngineUI.shipTo_name + "\"," +
                    "\r\n            \"phone\": \"" + ShipEngineUI.shipTo_phone + "\"," +
                    "\r\n            \"company_name\": \"" + ShipEngineUI.shipTo_company_name + "\"," +
                    "\r\n            \"address_line1\": \"" + ShipEngineUI.shipTo_address_line1 + "\"," +
                    "\r\n            \"address_line2\": \"" + ShipEngineUI.shipTo_address_line2 + "\"," +
                    "\r\n            \"address_line3\": \"" + ShipEngineUI.shipTo_address_line3 + "\"," +
                    "\r\n            \"city_locality\": \"" + ShipEngineUI.shipTo_city_locality + "\"," +
                    "\r\n            \"state_province\": \"" + ShipEngineUI.shipTo_state_province + "\"," +
                    "\r\n            \"postal_code\": \"" + ShipEngineUI.shipTo_postal_code + "\"," +
                    "\r\n            \"country_code\": \"" + ShipEngineUI.shipTo_country_code + "\"," +
                    "\r\n            \"address_residential_indicator\": \"" + ShipEngineUI.shipTo_address_residential_indicator + "\"" +
                    "\r\n        }," +
                    "\r\n        \"ship_from\": {" +
                    "\r\n            \"name\": \"" + ShipEngineUI.shipFrom_name + "\"," +
                    "\r\n            \"phone\": \"" + ShipEngineUI.shipFrom_phone + "\"," +
                    "\r\n            \"company_name\": \"" + ShipEngineUI.shipFrom_company_name + "\"," +
                    "\r\n            \"address_line1\": \"" + ShipEngineUI.shipFrom_address_line1 + "\"," +
                    "\r\n            \"address_line2\": \"" + ShipEngineUI.shipFrom_address_line2 + "\"," +
                    "\r\n            \"address_line3\": \"" + ShipEngineUI.shipFrom_address_line3 + "\"," +
                    "\r\n            \"city_locality\": \"" + ShipEngineUI.shipFrom_city_locality + "\"," +
                    "\r\n            \"state_province\": \"" + ShipEngineUI.shipFrom_state_province + "\"," +
                    "\r\n            \"postal_code\": \"" + ShipEngineUI.shipFrom_postal_code + "\"," +
                    "\r\n            \"country_code\": \"" + ShipEngineUI.shipFrom_country_code + "\"," +
                    "\r\n            \"address_residential_indicator\": \"" + ShipEngineUI.shipFrom_address_residential_indicator + "\"" +
                    "\r\n        }," +
                    "\r\n        \"confirmation\": \"" + delivery_confirmation_ComboBox.SelectedItem.ToString() + "\"," +
                    "\r\n        \"origin_type\": \"\"," +
                    "\r\n        \"insurance_provider\": \"" + insurance_provider_comboBox.SelectedItem.ToString() + "\"," +
                    "\r\n        \"packages\": [" +
                    "\r\n            {" +
                    "\r\n                \"package_code\": \"" + package_code_ComboBox.SelectedItem.ToString() + "\"," +
                    "\r\n                \"weight\": {" +
                    "\r\n                    \"value\": " + ShipEngineUI.packages_weight_value + "," +
                    "\r\n                    \"unit\": \"pound\"" +
                    "\r\n                }," +
                    "\r\n                \"dimensions\": {" +
                    "\r\n                    \"unit\": \"inch\"," +
                    "\r\n                    \"length\": " + ShipEngineUI.packages_dimensions_length + "," +
                    "\r\n                    \"width\": " + ShipEngineUI.packages_dimensions_width + "," +
                    "\r\n                    \"height\": " + ShipEngineUI.packages_dimensions_height + "" +
                    "\r\n                }," +
                    "\r\n                \"insured_value\": {" +
                    "\r\n                    \"currency\": \"" + insured_value_currency_comboBox.SelectedItem.ToString() + "\"," +
                    "\r\n                    \"amount\": \"" + insured_value_amont_numericUpDown.Text + "\"," +
                    "\r\n                }," +
                    "\r\n                \"label_messages\": {" +
                    "\r\n                    \"reference1\": null," +
                    "\r\n                    \"reference2\": null," +
                    "\r\n                    \"reference3\": null" +
                    "\r\n                }," +
                    "\r\n                \"external_package_id\": \"" + labelLogId + "\"" +
                    "\r\n            }" +
                    "\r\n        ]" +
                    "\r\n    }" +
                    "\r\n}";
                #endregion

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(createLabelrequestBody);

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                Stream stream = request.GetRequestStream();

                //Documents path REQUEST LOG
                //string docPath = @"..\..\Resources\Labels";
                //File.WriteAllText(Path.Combine(docPath, "LabelRequest - " + labelLogId + ".txt"), createLabelrequestBody);

                stream.Write(data, 0, data.Length);
                stream.Close();

                WebResponse requestResponse = request.GetResponse();
                stream = requestResponse.GetResponseStream();


                StreamReader parseResponse = new StreamReader(stream);
                label_RichTextBox.Value = parseResponse.ReadToEnd();
                string responseBodyText = label_RichTextBox.Value;

                //Documents path RESPONSE LOG
                //File.WriteAllText(Path.Combine(docPath, "LabelResponse - " + labelLogId + ".txt"), responseBodyText);

                //GET LABELID
                using (var reader = new StringReader(responseBodyText))
                {

                    for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                    {

                        if (currentLine.Contains("label_id") == true)
                        {

                            string label_id1 = currentLine.Replace("\"label_id\": \"", "");
                            string label_id = label_id1.Replace("\",", "");

                            //DECLARE VARIABLE
                            ShipEngineUI.label_id = label_id.Trim();

                        }
                    }
                }

                // GET LABEL IMAGE
                //LABEL_DOWNLOAD OBJECT
                int labelDownloadOBJ1 = responseBodyText.IndexOf("\"label_download\"") + "\"label_download\"".Length;
                int labelDownloadOBJ2 = responseBodyText.LastIndexOf("\"form_download\"");
                stream.Close();

                string labelDownloadOBJ3 = responseBodyText.Substring(labelDownloadOBJ1, labelDownloadOBJ2 - labelDownloadOBJ1);
                //Needed to specify as UPS contains two Label download objects

                int imgURL1 = labelDownloadOBJ3.IndexOf("\"png\": \"") + "\"png\": \"".Length;
                int imgURL2 = labelDownloadOBJ3.LastIndexOf(".png");
                stream.Close();

                string imgURL3 = labelDownloadOBJ3.Substring(imgURL1, imgURL2 - imgURL1);
                ShipEngineUI.ImageURL = imgURL3;

                //Save image in logging
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(imgURL3 + ".png"), @"..\..\Resources\Labels\Label-" + labelLogId + ".png");
                }

                labelImageBox.ImageUrl = (imgURL3 + ".png");

                void_label_id_TextBox.Text = ShipEngineUI.label_id;

                //CLOSE STREAM
                parseResponse.Close();
                stream.Close();

                //label_history_listbox.Items.Clear();
                //GetCurrentTrackingNumber();
                //GetLabelHistory();
            }
            catch (WebException Exception)
            {

                using (WebResponse ShipEngineErrorResponse = Exception.Response)
                {
                    HttpWebResponse ShipEngineResponse = (HttpWebResponse)ShipEngineErrorResponse;
                    Console.WriteLine("Error code: {0}", ShipEngineResponse.StatusCode);
                    using (Stream parseResponse = ShipEngineErrorResponse.GetResponseStream())

                    using (var reader = new StreamReader(parseResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("message") == true)
                            {

                                string ShipEngineErrorBody1 = currentLine.Replace("\"message\": \"", "");
                                string ShipEngineErrorBody = ShipEngineErrorBody1.Replace("\",", "");

                                ShowMessageBox(this, ShipEngineErrorBody);

                            }
                        }
                    }
                }
            }
            catch (Exception Exception)
            {
                ShowMessageBox(this, Exception.Message);
            }

            GetLabelHistory();
        }

        protected void labelImageBox_Click(object sender, EventArgs e)
        {

            void_label_id_TextBox.Text = "clicked";

        }

        
        protected void print_Button_Click(object sender, EventArgs e)
        {

            PrintDocument pd = new PrintDocument();
            //pd.PrintPage += PrintPage;
            //pd.Print();
        }

        protected void sales_order_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //create_label_from_Order_Button.Enabled = true;

            try
            {
                //GET SALES ORDER ID
                string sales_order_id1 = sales_order_ListBox.SelectedItem.ToString();
                sales_order_id1 = sales_order_id1.Remove(sales_order_id1.IndexOf("|") + 1);
                string sales_order_id = sales_order_id1.Replace("|", "");

                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v-beta/sales_orders/" + sales_order_id;

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET"; ;

                //SE AUTH
                requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;

                //Get Address
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    //
                    int originAddress1 = streamResponse.IndexOf("\"ship_to\": {") + "\"ship_to\": {".Length;
                    int originAddress2 = streamResponse.LastIndexOf("\"sales_order_items\": ");

                    string originAddress = streamResponse.Substring(originAddress1, originAddress2 - originAddress1);

                    using (var reader = new StringReader(originAddress))
                    {
                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            //NAME
                            if (currentLine.Contains(" \"name\": \"") == true)
                            {


                                string sales_order_Name1 = currentLine.Replace("\"name\": \"", "");
                                string sales_order_Name = sales_order_Name1.Replace("\",", "");

                                //add to textbox

                                shipTo_name_TextBox.Text = sales_order_Name;

                            }

                            //PHONE
                            if (currentLine.Contains("\"phone\": \"") == true)
                            {

                                string sales_order_Phone1 = currentLine.Replace("\"phone\": \"", "");
                                string sales_order_Phone = sales_order_Phone1.Replace("\",", "");

                                //add to textbox

                                shipTo_phone_TextBox.Text = sales_order_Phone;
                            }

                            //Company
                            if (currentLine.Contains("\"company_name\": \"") == true)
                            {

                                string sales_order_CompanyName1 = currentLine.Replace("\"company_name\": \"", "");
                                string sales_order_CompanyName = sales_order_CompanyName1.Replace("\",", "");

                                //add to textbox

                                shipTo_company_name_TextBox.Text = sales_order_CompanyName;
                            }

                            //AddressLine 1
                            if (currentLine.Contains("\"address_line1\": \"") == true)
                            {

                                string sales_order_AddressL1 = currentLine.Replace("\"address_line1\": \"", "");
                                string sales_order_AddressL = sales_order_AddressL1.Replace("\",", "");

                                //add to textbox

                                shipTo_address_line1_TextBox.Text = sales_order_AddressL;
                            }

                            //AddressLine 2
                            if (currentLine.Contains("\"address_line2\": \"") == true)
                            {

                                string sales_order_AddressL2 = currentLine.Replace("\"address_line2\": \"", "");
                                string sales_order_AddressL3 = sales_order_AddressL2.Replace("\",", "");

                                //add to textbox

                                shipTo_address_line2_TextBox.Text = sales_order_AddressL3;
                            }


                            //AddressLine 3
                            if (currentLine.Contains("\"address_line3\": \"") == true)
                            {

                                string sales_order_AddressL4 = currentLine.Replace("\"address_line3\": \"", "");
                                string sales_order_AddressL5 = sales_order_AddressL4.Replace("\",", "");

                                //add to textbox

                                shipTo_address_line3_TextBox.Text = sales_order_AddressL5;
                            }

                            //City
                            if (currentLine.Contains("\"city_locality\": \"") == true)
                            {

                                string sales_order_City1 = currentLine.Replace("\"city_locality\": \"", "");
                                string sales_order_City = sales_order_City1.Replace("\",", "");

                                //add to textbox

                                shipTo_city_locality_TextBox.Text = sales_order_City;
                            }

                            //State Province
                            if (currentLine.Contains("\"state_province\": \"") == true)
                            {

                                string sales_order_StateProvince1 = currentLine.Replace("\"state_province\": \"", "");
                                string sales_order_StateProvince = sales_order_StateProvince1.Replace("\",", "");

                                //add to textbox

                                shipTo_state_province_TextBox.Text = sales_order_StateProvince;
                            }

                            //Postal Code
                            if (currentLine.Contains("\"postal_code\": \"") == true)
                            {

                                string sales_order_PostalCode1 = currentLine.Replace("\"postal_code\": \"", "");
                                string sales_order_PostalCode = sales_order_PostalCode1.Replace("\",", "");

                                //add to textbox

                                shipTo_postal_code_TextBox.Text = sales_order_PostalCode;
                            }

                            //Country Code
                            if (currentLine.Contains("\"country_code\": \"") == true)
                            {

                                string sales_order_CountryCode1 = currentLine.Replace("\"country_code\": \"", "");
                                string sales_order_CountryCode = sales_order_CountryCode1.Replace("\",", "");

                                //add to textbox

                                shipTo_country_code_TextBox.Text = sales_order_CountryCode;

                            }

                            //remove spaces
                            //List Textboxes
                            IList<T> GetAllControls<T>(Control control) where T : Control
                            {
                                var TextBoxes = new List<T>();
                                foreach (Control item in control.Controls)
                                {
                                    var ctr = item as T;
                                    if (ctr != null)
                                        TextBoxes.Add(ctr);
                                    else
                                        TextBoxes.AddRange(GetAllControls<T>(item));
                                }
                                return TextBoxes;
                            }

                            //remove spaces loop
                            var textBoxesList = GetAllControls<TextBox>(this);
                            foreach (TextBox TextBoxes in textBoxesList)
                            {
                                TextBoxes.Text = TextBoxes.Text.Replace("    ", "");
                            }


                        }
                    }
                }

            }
            catch (Exception HTTPexception)
            {

            }

        }

        public void GetCurrentTrackingNumber()
        {
            string input = label_RichTextBox.Value;

            using (var reader = new StringReader(input))
            {

                for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                {

                    if (currentLine.Contains("tracking_number") == true)
                    {

                        string tracking_number1 = currentLine.Replace("\"tracking_number\": \"", "");
                        string tracking_number = tracking_number1.Replace("\",", "");

                        ShipEngineUI.Tracking_number = tracking_number.Trim();

                        tracking_number_textBox.Text = "Tracking Number: " + ShipEngineUI.Tracking_number;

                    }

                }
            }
        }

        protected void label_history_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //GET SELECTED LabelID ID
                string label_id1 = label_history_listbox.SelectedItem.ToString();
                label_id1 = label_id1.Remove(label_id1.IndexOf("|") + 1);
                string label_id = label_id1.Replace("|", "");

                //GET LABEL URL
                string label_url1 = label_history_listbox.SelectedItem.ToString();
                //label_url1 = label_url1.Remove(label_url1.LastIndexOf("<") + 1);
                string label_url = label_url1.Substring(label_url1.LastIndexOf('<') + 1);

                void_label_id_TextBox.Text = label_id.Trim();
                labelImageBox.ImageUrl = (label_url);

                if (label_history_listbox.Text.Contains("completed"))
                {
                    //Select labels to void
                    if (!manifest_label_id_richTextBox.Value.Contains(label_id.Trim()))
                    {
                        
                        manifest_label_id_richTextBox.Value += "\"" + label_id.Trim() + "\"" + ",";
                    }
                    else if (manifest_label_id_richTextBox.Value.Contains(label_id.Trim()))
                    {
                        string currentSelection = "\"" + label_id.Trim() + "\",";

                        manifest_label_id_richTextBox.Value = manifest_label_id_richTextBox.Value.Replace(currentSelection, "");
                    }
                }
                else
                {

                }

                //GET LABELS
                try
                {

                    //URL SOURCE
                    string URLstring = "https://api.shipengine.com/v1/labels/" + label_id.Trim();

                    //REQUEST
                    WebRequest requestObject = WebRequest.Create(URLstring);
                    requestObject.Method = "GET";

                    //SE AUTH
                    requestObject.Headers.Add("API-key", ShipEngineUI.apiKey);

                    //RESPONSE
                    HttpWebResponse responseObjectGet = null;
                    responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                    string streamResponse = null;

                    //Get List labels data
                    using (Stream stream = responseObjectGet.GetResponseStream())
                    {
                        StreamReader responseRead = new StreamReader(stream);
                        streamResponse = responseRead.ReadToEnd();

                        label_RichTextBox.Value = streamResponse;

                        using (var reader = new StringReader(streamResponse))
                        {

                            for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                            {



                            }
                        }
                    }

                    GetCurrentTrackingNumber();
                }
                catch (Exception HTTPexception)
                {

                }
            }
            catch (Exception HTTPexception)
            {

            }

        }

        protected void void_label_id_Button_Click(object sender, EventArgs e)
        {



        }
    }
}