//The following sample code is generated as an illustration of 
//Creating requests and parsing responses ONLY
//This code is NOT intended to show best practices or ideal code
//Use at your most careful discretion

using System;
using System.Xml;

namespace com.intuit.idn.samples
{
    public class Sample
    {
        private XmlElement MakeSimpleElem(XmlDocument doc, string tagName, string tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

        public void DoInvoiceQuery()
        {
            bool sessionBegun = false;
            bool connectionOpen = false;
            RequestProcessor2 rp = null;

            try
            {
                //Create the Request Processor object
                rp = new RequestProcessor2();

                //Create the XML document to hold our request
                XmlDocument requestXmlDoc = new XmlDocument();
                //Add the prolog processing instructions
                requestXmlDoc.AppendChild(requestXmlDoc.CreateXmlDeclaration("1.0", null, null));
                requestXmlDoc.AppendChild(requestXmlDoc.CreateProcessingInstruction("qbxml", "version=\"13.0\""));

                //Create the outer request envelope tag
                XmlElement outer = requestXmlDoc.CreateElement("QBXML");
                requestXmlDoc.AppendChild(outer);

                //Create the inner request envelope & any needed attributes
                XmlElement inner = requestXmlDoc.CreateElement("QBXMLMsgsRq");
                outer.AppendChild(inner);
                inner.SetAttribute("onError", "stopOnError");
                BuildInvoiceQueryRq(requestXmlDoc, inner);

                //Connect to QuickBooks and begin a session
                rp.OpenConnection2("", "Sample Code from OSR", localQBD);
                connectionOpen = true;
                string ticket = rp.BeginSession("", QBFileMode.qbFileOpenDoNotCare);
                sessionBegun = true;

                //Send the request and get the response from QuickBooks
                string responseStr = rp.ProcessRequest(ticket, requestXmlDoc.OuterXml);

                //End the session and close the connection to QuickBooks
                rp.EndSession(ticket);
                sessionBegun = false;
                rp.CloseConnection();
                connectionOpen = false;

                WalkInvoiceQueryRs(responseStr);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                if (sessionBegun)
                {
                    sessionManager.EndSession();
                }
                if (connectionOpen)
                {
                    sessionManager.CloseConnection();
                }
            }
        }


        void BuildInvoiceQueryRq(XmlDocument doc, XmlElement parent)
        {

            //Create InvoiceQueryRq aggregate and fill in field values for it
            XmlElement InvoiceQueryRq = doc.CreateElement("InvoiceQueryRq");
            parent.AppendChild(InvoiceQueryRq);
            //Begin OR
            string ORElementType = "TxnID";
            if (ORElementType == "TxnID")
            {
                //Set field value for TxnID <!-- optional, may repeat -->
                InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "TxnID", "200000-1011023419"));
            }
            if (ORElementType == "RefNumber")
            {
                //Set field value for RefNumber <!-- optional, may repeat -->
                InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "RefNumber", "ab"));
            }
            if (ORElementType == "RefNumberCaseSensitive")
            {
                //Set field value for RefNumberCaseSensitive <!-- optional, may repeat -->
                InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "RefNumberCaseSensitive", "ab"));
            }
            if (ORElementType == "nothing")
            {
                //Set field value for MaxReturned <!-- optional -->
                InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "MaxReturned", "6"));
                //Begin OR
                string ORElementType = "ModifiedDateRangeFilter";
                if (ORElementType == "ModifiedDateRangeFilter")
                {

                    //Create ModifiedDateRangeFilter aggregate and fill in field values for it
                    XmlElement ModifiedDateRangeFilter = doc.CreateElement("ModifiedDateRangeFilter");
                    InvoiceQueryRq.AppendChild(ModifiedDateRangeFilter);
                    //Set field value for FromModifiedDate <!-- optional -->
                    ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromModifiedDate", "2007-12-15T12:15:12-08:00"));
                    //Set field value for ToModifiedDate <!-- optional -->
                    ModifiedDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToModifiedDate", "2007-12-15T12:15:12-08:00"));
                    //Done creating ModifiedDateRangeFilter aggregate

                }
                if (ORElementType == "TxnDateRangeFilter")
                {

                    //Create TxnDateRangeFilter aggregate and fill in field values for it
                    XmlElement TxnDateRangeFilter = doc.CreateElement("TxnDateRangeFilter");
                    InvoiceQueryRq.AppendChild(TxnDateRangeFilter);
                    //Begin OR
                    string ORElementType = "nothing";
                    if (ORElementType == "nothing")
                    {
                        //Set field value for FromTxnDate <!-- optional -->
                        TxnDateRangeFilter.AppendChild(MakeSimpleElem(doc, "FromTxnDate", "2007-12-15"));
                        //Set field value for ToTxnDate <!-- optional -->
                        TxnDateRangeFilter.AppendChild(MakeSimpleElem(doc, "ToTxnDate", "2007-12-15"));
                    }
                    if (ORElementType == "DateMacro")
                    {
                        //Set field value for DateMacro <!-- optional -->
                        TxnDateRangeFilter.AppendChild(MakeSimpleElem(doc, "DateMacro", "All"));
                    }
                    //Done creating TxnDateRangeFilter aggregate

                }

                //Create EntityFilter aggregate and fill in field values for it
                XmlElement EntityFilter = doc.CreateElement("EntityFilter");
                InvoiceQueryRq.AppendChild(EntityFilter);
                //Begin OR
                string ORElementType = "ListID";
                if (ORElementType == "ListID")
                {
                    //Set field value for ListID <!-- optional, may repeat -->
                    EntityFilter.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
                }
                if (ORElementType == "FullName")
                {
                    //Set field value for FullName <!-- optional, may repeat -->
                    EntityFilter.AppendChild(MakeSimpleElem(doc, "FullName", "ab"));
                }
                if (ORElementType == "ListIDWithChildren")
                {
                    //Set field value for ListIDWithChildren <!-- optional -->
                    EntityFilter.AppendChild(MakeSimpleElem(doc, "ListIDWithChildren", "200000-1011023419"));
                }
                if (ORElementType == "FullNameWithChildren")
                {
                    //Set field value for FullNameWithChildren <!-- optional -->
                    EntityFilter.AppendChild(MakeSimpleElem(doc, "FullNameWithChildren", "ab"));
                }
                //Done creating EntityFilter aggregate


                //Create AccountFilter aggregate and fill in field values for it
                XmlElement AccountFilter = doc.CreateElement("AccountFilter");
                InvoiceQueryRq.AppendChild(AccountFilter);
                //Begin OR
                string ORElementType = "ListID";
                if (ORElementType == "ListID")
                {
                    //Set field value for ListID <!-- optional, may repeat -->
                    AccountFilter.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
                }
                if (ORElementType == "FullName")
                {
                    //Set field value for FullName <!-- optional, may repeat -->
                    AccountFilter.AppendChild(MakeSimpleElem(doc, "FullName", "ab"));
                }
                if (ORElementType == "ListIDWithChildren")
                {
                    //Set field value for ListIDWithChildren <!-- optional -->
                    AccountFilter.AppendChild(MakeSimpleElem(doc, "ListIDWithChildren", "200000-1011023419"));
                }
                if (ORElementType == "FullNameWithChildren")
                {
                    //Set field value for FullNameWithChildren <!-- optional -->
                    AccountFilter.AppendChild(MakeSimpleElem(doc, "FullNameWithChildren", "ab"));
                }
                //Done creating AccountFilter aggregate

                //Begin OR
                string ORElementType = "RefNumberFilter";
                if (ORElementType == "RefNumberFilter")
                {

                    //Create RefNumberFilter aggregate and fill in field values for it
                    XmlElement RefNumberFilter = doc.CreateElement("RefNumberFilter");
                    InvoiceQueryRq.AppendChild(RefNumberFilter);
                    //Set field value for MatchCriterion <!-- required -->
                    RefNumberFilter.AppendChild(MakeSimpleElem(doc, "MatchCriterion", "StartsWith"));
                    //Set field value for RefNumber <!-- required -->
                    RefNumberFilter.AppendChild(MakeSimpleElem(doc, "RefNumber", "ab"));
                    //Done creating RefNumberFilter aggregate

                }
                if (ORElementType == "RefNumberRangeFilter")
                {

                    //Create RefNumberRangeFilter aggregate and fill in field values for it
                    XmlElement RefNumberRangeFilter = doc.CreateElement("RefNumberRangeFilter");
                    InvoiceQueryRq.AppendChild(RefNumberRangeFilter);
                    //Set field value for FromRefNumber <!-- optional -->
                    RefNumberRangeFilter.AppendChild(MakeSimpleElem(doc, "FromRefNumber", "ab"));
                    //Set field value for ToRefNumber <!-- optional -->
                    RefNumberRangeFilter.AppendChild(MakeSimpleElem(doc, "ToRefNumber", "ab"));
                    //Done creating RefNumberRangeFilter aggregate

                }

                //Create CurrencyFilter aggregate and fill in field values for it
                XmlElement CurrencyFilter = doc.CreateElement("CurrencyFilter");
                InvoiceQueryRq.AppendChild(CurrencyFilter);
                //Begin OR
                string ORElementType = "ListID";
                if (ORElementType == "ListID")
                {
                    //Set field value for ListID <!-- optional, may repeat -->
                    CurrencyFilter.AppendChild(MakeSimpleElem(doc, "ListID", "200000-1011023419"));
                }
                if (ORElementType == "FullName")
                {
                    //Set field value for FullName <!-- optional, may repeat -->
                    CurrencyFilter.AppendChild(MakeSimpleElem(doc, "FullName", "ab"));
                }
                //Done creating CurrencyFilter aggregate

                //Set field value for PaidStatus <!-- optional -->
                InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "PaidStatus", "All [DEFAULT]"));
            }
            //Set field value for IncludeLineItems <!-- optional -->
            InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLineItems", "1"));
            //Set field value for IncludeLinkedTxns <!-- optional -->
            InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeLinkedTxns", "1"));
            //Set field value for IncludeRetElement <!-- optional, may repeat -->
            InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "IncludeRetElement", "ab"));
            //Set field value for OwnerID <!-- optional, may repeat -->
            InvoiceQueryRq.AppendChild(MakeSimpleElem(doc, "OwnerID", "Guid.NewGuid().ToString()"));
            //Done creating InvoiceQueryRq aggregate

        }




        void WalkInvoiceQueryRs(string response)
        {
            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(response);

            //Get the response for our request
            XmlNodeList InvoiceQueryRsList = responseXmlDoc.GetElementsByTagName("InvoiceQueryRs");
            if (InvoiceQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = InvoiceQueryRsList.Item(0);
                //Check the status code, info, and severity
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;
                string statusSeverity = rsAttributes.GetNamedItem("statusSeverity").Value;
                string statusMessage = rsAttributes.GetNamedItem("statusMessage").Value;

                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList InvoiceRetList = responseNode.SelectNodes("//InvoiceRet");//XPath Query
                    for (int i = 0; i < InvoiceRetList.Count; i++)
                    {
                        XmlNode InvoiceRet = InvoiceRetList.Item(i);
                        WalkInvoiceRet(InvoiceRet);
                    }
                }
            }
        }



        void WalkInvoiceRet(XmlNode InvoiceRet)
        {
            if (InvoiceRet == null) return;

            //Go through all the elements of InvoiceRet
            //Get value of TxnID
            string TxnID = InvoiceRet.SelectSingleNode("./TxnID").InnerText;
            //Get value of TimeCreated
            string TimeCreated = InvoiceRet.SelectSingleNode("./TimeCreated").InnerText;
            //Get value of TimeModified
            string TimeModified = InvoiceRet.SelectSingleNode("./TimeModified").InnerText;
            //Get value of EditSequence
            string EditSequence = InvoiceRet.SelectSingleNode("./EditSequence").InnerText;
            //Get value of TxnNumber
            if (InvoiceRet.SelectSingleNode("./TxnNumber") != null)
            {
                string TxnNumber = InvoiceRet.SelectSingleNode("./TxnNumber").InnerText;
            }
            //Get all field values for CustomerRef aggregate 
            //Get value of ListID
            if (InvoiceRet.SelectSingleNode("./CustomerRef/ListID") != null)
            {
                string ListID = InvoiceRet.SelectSingleNode("./CustomerRef/ListID").InnerText;
            }
            //Get value of FullName
            if (InvoiceRet.SelectSingleNode("./CustomerRef/FullName") != null)
            {
                string FullName = InvoiceRet.SelectSingleNode("./CustomerRef/FullName").InnerText;
            }
            //Done with field values for CustomerRef aggregate

            //Get all field values for ClassRef aggregate 
            XmlNode ClassRef = InvoiceRet.SelectSingleNode("./ClassRef");
            if (ClassRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./ClassRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./ClassRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./ClassRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./ClassRef/FullName").InnerText;
                }
            }
            //Done with field values for ClassRef aggregate

            //Get all field values for ARAccountRef aggregate 
            XmlNode ARAccountRef = InvoiceRet.SelectSingleNode("./ARAccountRef");
            if (ARAccountRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./ARAccountRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./ARAccountRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./ARAccountRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./ARAccountRef/FullName").InnerText;
                }
            }
            //Done with field values for ARAccountRef aggregate

            //Get all field values for TemplateRef aggregate 
            XmlNode TemplateRef = InvoiceRet.SelectSingleNode("./TemplateRef");
            if (TemplateRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./TemplateRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./TemplateRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./TemplateRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./TemplateRef/FullName").InnerText;
                }
            }
            //Done with field values for TemplateRef aggregate

            //Get value of TxnDate
            string TxnDate = InvoiceRet.SelectSingleNode("./TxnDate").InnerText;
            //Get value of RefNumber
            if (InvoiceRet.SelectSingleNode("./RefNumber") != null)
            {
                string RefNumber = InvoiceRet.SelectSingleNode("./RefNumber").InnerText;
            }
            //Get all field values for BillAddress aggregate 
            XmlNode BillAddress = InvoiceRet.SelectSingleNode("./BillAddress");
            if (BillAddress != null)
            {
                //Get value of Addr1
                if (InvoiceRet.SelectSingleNode("./BillAddress/Addr1") != null)
                {
                    string Addr1 = InvoiceRet.SelectSingleNode("./BillAddress/Addr1").InnerText;
                }
                //Get value of Addr2
                if (InvoiceRet.SelectSingleNode("./BillAddress/Addr2") != null)
                {
                    string Addr2 = InvoiceRet.SelectSingleNode("./BillAddress/Addr2").InnerText;
                }
                //Get value of Addr3
                if (InvoiceRet.SelectSingleNode("./BillAddress/Addr3") != null)
                {
                    string Addr3 = InvoiceRet.SelectSingleNode("./BillAddress/Addr3").InnerText;
                }
                //Get value of Addr4
                if (InvoiceRet.SelectSingleNode("./BillAddress/Addr4") != null)
                {
                    string Addr4 = InvoiceRet.SelectSingleNode("./BillAddress/Addr4").InnerText;
                }
                //Get value of Addr5
                if (InvoiceRet.SelectSingleNode("./BillAddress/Addr5") != null)
                {
                    string Addr5 = InvoiceRet.SelectSingleNode("./BillAddress/Addr5").InnerText;
                }
                //Get value of City
                if (InvoiceRet.SelectSingleNode("./BillAddress/City") != null)
                {
                    string City = InvoiceRet.SelectSingleNode("./BillAddress/City").InnerText;
                }
                //Get value of State
                if (InvoiceRet.SelectSingleNode("./BillAddress/State") != null)
                {
                    string State = InvoiceRet.SelectSingleNode("./BillAddress/State").InnerText;
                }
                //Get value of PostalCode
                if (InvoiceRet.SelectSingleNode("./BillAddress/PostalCode") != null)
                {
                    string PostalCode = InvoiceRet.SelectSingleNode("./BillAddress/PostalCode").InnerText;
                }
                //Get value of Country
                if (InvoiceRet.SelectSingleNode("./BillAddress/Country") != null)
                {
                    string Country = InvoiceRet.SelectSingleNode("./BillAddress/Country").InnerText;
                }
                //Get value of Note
                if (InvoiceRet.SelectSingleNode("./BillAddress/Note") != null)
                {
                    string Note = InvoiceRet.SelectSingleNode("./BillAddress/Note").InnerText;
                }
            }
            //Done with field values for BillAddress aggregate

            //Get all field values for BillAddressBlock aggregate 
            XmlNode BillAddressBlock = InvoiceRet.SelectSingleNode("./BillAddressBlock");
            if (BillAddressBlock != null)
            {
                //Get value of Addr1
                if (InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr1") != null)
                {
                    string Addr1 = InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr1").InnerText;
                }
                //Get value of Addr2
                if (InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr2") != null)
                {
                    string Addr2 = InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr2").InnerText;
                }
                //Get value of Addr3
                if (InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr3") != null)
                {
                    string Addr3 = InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr3").InnerText;
                }
                //Get value of Addr4
                if (InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr4") != null)
                {
                    string Addr4 = InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr4").InnerText;
                }
                //Get value of Addr5
                if (InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr5") != null)
                {
                    string Addr5 = InvoiceRet.SelectSingleNode("./BillAddressBlock/Addr5").InnerText;
                }
            }
            //Done with field values for BillAddressBlock aggregate

            //Get all field values for ShipAddress aggregate 
            XmlNode ShipAddress = InvoiceRet.SelectSingleNode("./ShipAddress");
            if (ShipAddress != null)
            {
                //Get value of Addr1
                if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr1") != null)
                {
                    string Addr1 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr1").InnerText;
                }
                //Get value of Addr2
                if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr2") != null)
                {
                    string Addr2 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr2").InnerText;
                }
                //Get value of Addr3
                if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr3") != null)
                {
                    string Addr3 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr3").InnerText;
                }
                //Get value of Addr4
                if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr4") != null)
                {
                    string Addr4 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr4").InnerText;
                }
                //Get value of Addr5
                if (InvoiceRet.SelectSingleNode("./ShipAddress/Addr5") != null)
                {
                    string Addr5 = InvoiceRet.SelectSingleNode("./ShipAddress/Addr5").InnerText;
                }
                //Get value of City
                if (InvoiceRet.SelectSingleNode("./ShipAddress/City") != null)
                {
                    string City = InvoiceRet.SelectSingleNode("./ShipAddress/City").InnerText;
                }
                //Get value of State
                if (InvoiceRet.SelectSingleNode("./ShipAddress/State") != null)
                {
                    string State = InvoiceRet.SelectSingleNode("./ShipAddress/State").InnerText;
                }
                //Get value of PostalCode
                if (InvoiceRet.SelectSingleNode("./ShipAddress/PostalCode") != null)
                {
                    string PostalCode = InvoiceRet.SelectSingleNode("./ShipAddress/PostalCode").InnerText;
                }
                //Get value of Country
                if (InvoiceRet.SelectSingleNode("./ShipAddress/Country") != null)
                {
                    string Country = InvoiceRet.SelectSingleNode("./ShipAddress/Country").InnerText;
                }
                //Get value of Note
                if (InvoiceRet.SelectSingleNode("./ShipAddress/Note") != null)
                {
                    string Note = InvoiceRet.SelectSingleNode("./ShipAddress/Note").InnerText;
                }
            }
            //Done with field values for ShipAddress aggregate

            //Get all field values for ShipAddressBlock aggregate 
            XmlNode ShipAddressBlock = InvoiceRet.SelectSingleNode("./ShipAddressBlock");
            if (ShipAddressBlock != null)
            {
                //Get value of Addr1
                if (InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr1") != null)
                {
                    string Addr1 = InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr1").InnerText;
                }
                //Get value of Addr2
                if (InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr2") != null)
                {
                    string Addr2 = InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr2").InnerText;
                }
                //Get value of Addr3
                if (InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr3") != null)
                {
                    string Addr3 = InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr3").InnerText;
                }
                //Get value of Addr4
                if (InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr4") != null)
                {
                    string Addr4 = InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr4").InnerText;
                }
                //Get value of Addr5
                if (InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr5") != null)
                {
                    string Addr5 = InvoiceRet.SelectSingleNode("./ShipAddressBlock/Addr5").InnerText;
                }
            }
            //Done with field values for ShipAddressBlock aggregate

            //Get value of IsPending
            if (InvoiceRet.SelectSingleNode("./IsPending") != null)
            {
                string IsPending = InvoiceRet.SelectSingleNode("./IsPending").InnerText;
            }
            //Get value of IsFinanceCharge
            if (InvoiceRet.SelectSingleNode("./IsFinanceCharge") != null)
            {
                string IsFinanceCharge = InvoiceRet.SelectSingleNode("./IsFinanceCharge").InnerText;
            }
            //Get value of PONumber
            if (InvoiceRet.SelectSingleNode("./PONumber") != null)
            {
                string PONumber = InvoiceRet.SelectSingleNode("./PONumber").InnerText;
            }
            //Get all field values for TermsRef aggregate 
            XmlNode TermsRef = InvoiceRet.SelectSingleNode("./TermsRef");
            if (TermsRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./TermsRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./TermsRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./TermsRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./TermsRef/FullName").InnerText;
                }
            }
            //Done with field values for TermsRef aggregate

            //Get value of DueDate
            if (InvoiceRet.SelectSingleNode("./DueDate") != null)
            {
                string DueDate = InvoiceRet.SelectSingleNode("./DueDate").InnerText;
            }
            //Get all field values for SalesRepRef aggregate 
            XmlNode SalesRepRef = InvoiceRet.SelectSingleNode("./SalesRepRef");
            if (SalesRepRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./SalesRepRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./SalesRepRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./SalesRepRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./SalesRepRef/FullName").InnerText;
                }
            }
            //Done with field values for SalesRepRef aggregate

            //Get value of FOB
            if (InvoiceRet.SelectSingleNode("./FOB") != null)
            {
                string FOB = InvoiceRet.SelectSingleNode("./FOB").InnerText;
            }
            //Get value of ShipDate
            if (InvoiceRet.SelectSingleNode("./ShipDate") != null)
            {
                string ShipDate = InvoiceRet.SelectSingleNode("./ShipDate").InnerText;
            }
            //Get all field values for ShipMethodRef aggregate 
            XmlNode ShipMethodRef = InvoiceRet.SelectSingleNode("./ShipMethodRef");
            if (ShipMethodRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./ShipMethodRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./ShipMethodRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./ShipMethodRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./ShipMethodRef/FullName").InnerText;
                }
            }
            //Done with field values for ShipMethodRef aggregate

            //Get value of Subtotal
            if (InvoiceRet.SelectSingleNode("./Subtotal") != null)
            {
                string Subtotal = InvoiceRet.SelectSingleNode("./Subtotal").InnerText;
            }
            //Get all field values for ItemSalesTaxRef aggregate 
            XmlNode ItemSalesTaxRef = InvoiceRet.SelectSingleNode("./ItemSalesTaxRef");
            if (ItemSalesTaxRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./ItemSalesTaxRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./ItemSalesTaxRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./ItemSalesTaxRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./ItemSalesTaxRef/FullName").InnerText;
                }
            }
            //Done with field values for ItemSalesTaxRef aggregate

            //Get value of SalesTaxPercentage
            if (InvoiceRet.SelectSingleNode("./SalesTaxPercentage") != null)
            {
                string SalesTaxPercentage = InvoiceRet.SelectSingleNode("./SalesTaxPercentage").InnerText;
            }
            //Get value of SalesTaxTotal
            if (InvoiceRet.SelectSingleNode("./SalesTaxTotal") != null)
            {
                string SalesTaxTotal = InvoiceRet.SelectSingleNode("./SalesTaxTotal").InnerText;
            }
            //Get value of AppliedAmount
            if (InvoiceRet.SelectSingleNode("./AppliedAmount") != null)
            {
                string AppliedAmount = InvoiceRet.SelectSingleNode("./AppliedAmount").InnerText;
            }
            //Get value of BalanceRemaining
            if (InvoiceRet.SelectSingleNode("./BalanceRemaining") != null)
            {
                string BalanceRemaining = InvoiceRet.SelectSingleNode("./BalanceRemaining").InnerText;
            }
            //Get all field values for CurrencyRef aggregate 
            XmlNode CurrencyRef = InvoiceRet.SelectSingleNode("./CurrencyRef");
            if (CurrencyRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./CurrencyRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./CurrencyRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./CurrencyRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./CurrencyRef/FullName").InnerText;
                }
            }
            //Done with field values for CurrencyRef aggregate

            //Get value of ExchangeRate
            if (InvoiceRet.SelectSingleNode("./ExchangeRate") != null)
            {
                string ExchangeRate = InvoiceRet.SelectSingleNode("./ExchangeRate").InnerText;
            }
            //Get value of BalanceRemainingInHomeCurrency
            if (InvoiceRet.SelectSingleNode("./BalanceRemainingInHomeCurrency") != null)
            {
                string BalanceRemainingInHomeCurrency = InvoiceRet.SelectSingleNode("./BalanceRemainingInHomeCurrency").InnerText;
            }
            //Get value of Memo
            if (InvoiceRet.SelectSingleNode("./Memo") != null)
            {
                string Memo = InvoiceRet.SelectSingleNode("./Memo").InnerText;
            }
            //Get value of IsPaid
            if (InvoiceRet.SelectSingleNode("./IsPaid") != null)
            {
                string IsPaid = InvoiceRet.SelectSingleNode("./IsPaid").InnerText;
            }
            //Get all field values for CustomerMsgRef aggregate 
            XmlNode CustomerMsgRef = InvoiceRet.SelectSingleNode("./CustomerMsgRef");
            if (CustomerMsgRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./CustomerMsgRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./CustomerMsgRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./CustomerMsgRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./CustomerMsgRef/FullName").InnerText;
                }
            }
            //Done with field values for CustomerMsgRef aggregate

            //Get value of IsToBePrinted
            if (InvoiceRet.SelectSingleNode("./IsToBePrinted") != null)
            {
                string IsToBePrinted = InvoiceRet.SelectSingleNode("./IsToBePrinted").InnerText;
            }
            //Get value of IsToBeEmailed
            if (InvoiceRet.SelectSingleNode("./IsToBeEmailed") != null)
            {
                string IsToBeEmailed = InvoiceRet.SelectSingleNode("./IsToBeEmailed").InnerText;
            }
            //Get all field values for CustomerSalesTaxCodeRef aggregate 
            XmlNode CustomerSalesTaxCodeRef = InvoiceRet.SelectSingleNode("./CustomerSalesTaxCodeRef");
            if (CustomerSalesTaxCodeRef != null)
            {
                //Get value of ListID
                if (InvoiceRet.SelectSingleNode("./CustomerSalesTaxCodeRef/ListID") != null)
                {
                    string ListID = InvoiceRet.SelectSingleNode("./CustomerSalesTaxCodeRef/ListID").InnerText;
                }
                //Get value of FullName
                if (InvoiceRet.SelectSingleNode("./CustomerSalesTaxCodeRef/FullName") != null)
                {
                    string FullName = InvoiceRet.SelectSingleNode("./CustomerSalesTaxCodeRef/FullName").InnerText;
                }
            }
            //Done with field values for CustomerSalesTaxCodeRef aggregate

            //Get value of SuggestedDiscountAmount
            if (InvoiceRet.SelectSingleNode("./SuggestedDiscountAmount") != null)
            {
                string SuggestedDiscountAmount = InvoiceRet.SelectSingleNode("./SuggestedDiscountAmount").InnerText;
            }
            //Get value of SuggestedDiscountDate
            if (InvoiceRet.SelectSingleNode("./SuggestedDiscountDate") != null)
            {
                string SuggestedDiscountDate = InvoiceRet.SelectSingleNode("./SuggestedDiscountDate").InnerText;
            }
            //Get value of Other
            if (InvoiceRet.SelectSingleNode("./Other") != null)
            {
                string Other = InvoiceRet.SelectSingleNode("./Other").InnerText;
            }
            //Get value of ExternalGUID
            if (InvoiceRet.SelectSingleNode("./ExternalGUID") != null)
            {
                string ExternalGUID = InvoiceRet.SelectSingleNode("./ExternalGUID").InnerText;
            }
            //Walk list of LinkedTxn aggregates
            XmlNodeList LinkedTxnList = InvoiceRet.SelectNodes("./LinkedTxn");
            if (LinkedTxnList != null)
            {
                for (int i = 0; i < LinkedTxnList.Count; i++)
                {
                    XmlNode LinkedTxn = LinkedTxnList.Item(i);
                    //Get value of TxnID
                    string TxnID = LinkedTxn.SelectSingleNode("./TxnID").InnerText;
                    //Get value of TxnType
                    string TxnType = LinkedTxn.SelectSingleNode("./TxnType").InnerText;
                    //Get value of TxnDate
                    string TxnDate = LinkedTxn.SelectSingleNode("./TxnDate").InnerText;
                    //Get value of RefNumber
                    if (LinkedTxn.SelectSingleNode("./RefNumber") != null)
                    {
                        string RefNumber = LinkedTxn.SelectSingleNode("./RefNumber").InnerText;
                    }
                    //Get value of LinkType
                    if (LinkedTxn.SelectSingleNode("./LinkType") != null)
                    {
                        string LinkType = LinkedTxn.SelectSingleNode("./LinkType").InnerText;
                    }
                    //Get value of Amount
                    string Amount = LinkedTxn.SelectSingleNode("./Amount").InnerText;
                }
            }

            XmlNodeList ORInvoiceLineRetListChildren = InvoiceRet.SelectNodes("./*");
            for (int i = 0; i < ORInvoiceLineRetListChildren.Count; i++)
            {
                XmlNode Child = ORInvoiceLineRetListChildren.Item(i);
                if (Child.Name == "InvoiceLineRet")
                {
                    //Get value of TxnLineID
                    string TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;
                    //Get all field values for ItemRef aggregate 
                    XmlNode ItemRef = Child.SelectSingleNode("./ItemRef");
                    if (ItemRef != null)
                    {
                        //Get value of ListID
                        if (Child.SelectSingleNode("./ItemRef/ListID") != null)
                        {
                            string ListID = Child.SelectSingleNode("./ItemRef/ListID").InnerText;
                        }
                        //Get value of FullName
                        if (Child.SelectSingleNode("./ItemRef/FullName") != null)
                        {
                            string FullName = Child.SelectSingleNode("./ItemRef/FullName").InnerText;
                        }
                    }
                    //Done with field values for ItemRef aggregate

                    //Get value of Desc
                    if (Child.SelectSingleNode("./Desc") != null)
                    {
                        string Desc = Child.SelectSingleNode("./Desc").InnerText;
                    }
                    //Get value of Quantity
                    if (Child.SelectSingleNode("./Quantity") != null)
                    {
                        string Quantity = Child.SelectSingleNode("./Quantity").InnerText;
                    }
                    //Get value of UnitOfMeasure
                    if (Child.SelectSingleNode("./UnitOfMeasure") != null)
                    {
                        string UnitOfMeasure = Child.SelectSingleNode("./UnitOfMeasure").InnerText;
                    }
                    //Get all field values for OverrideUOMSetRef aggregate 
                    XmlNode OverrideUOMSetRef = Child.SelectSingleNode("./OverrideUOMSetRef");
                    if (OverrideUOMSetRef != null)
                    {
                        //Get value of ListID
                        if (Child.SelectSingleNode("./OverrideUOMSetRef/ListID") != null)
                        {
                            string ListID = Child.SelectSingleNode("./OverrideUOMSetRef/ListID").InnerText;
                        }
                        //Get value of FullName
                        if (Child.SelectSingleNode("./OverrideUOMSetRef/FullName") != null)
                        {
                            string FullName = Child.SelectSingleNode("./OverrideUOMSetRef/FullName").InnerText;
                        }
                    }
                    //Done with field values for OverrideUOMSetRef aggregate

                    XmlNodeList ORRateChildren = Child.SelectNodes("./*");
                    for (int i = 0; i < ORRateChildren.Count; i++)
                    {
                        XmlNode Child = ORRateChildren.Item(i);
                        if (Child.Name == "Rate")
                        {
                        }

                        if (Child.Name == "RatePercent")
                        {
                        }

                    }

                    //Get all field values for ClassRef aggregate 
                    XmlNode ClassRef = Child.SelectSingleNode("./ClassRef");
                    if (ClassRef != null)
                    {
                        //Get value of ListID
                        if (Child.SelectSingleNode("./ClassRef/ListID") != null)
                        {
                            string ListID = Child.SelectSingleNode("./ClassRef/ListID").InnerText;
                        }
                        //Get value of FullName
                        if (Child.SelectSingleNode("./ClassRef/FullName") != null)
                        {
                            string FullName = Child.SelectSingleNode("./ClassRef/FullName").InnerText;
                        }
                    }
                    //Done with field values for ClassRef aggregate

                    //Get value of Amount
                    if (Child.SelectSingleNode("./Amount") != null)
                    {
                        string Amount = Child.SelectSingleNode("./Amount").InnerText;
                    }
                    //Get all field values for InventorySiteRef aggregate 
                    XmlNode InventorySiteRef = Child.SelectSingleNode("./InventorySiteRef");
                    if (InventorySiteRef != null)
                    {
                        //Get value of ListID
                        if (Child.SelectSingleNode("./InventorySiteRef/ListID") != null)
                        {
                            string ListID = Child.SelectSingleNode("./InventorySiteRef/ListID").InnerText;
                        }
                        //Get value of FullName
                        if (Child.SelectSingleNode("./InventorySiteRef/FullName") != null)
                        {
                            string FullName = Child.SelectSingleNode("./InventorySiteRef/FullName").InnerText;
                        }
                    }
                    //Done with field values for InventorySiteRef aggregate

                    //Get all field values for InventorySiteLocationRef aggregate 
                    XmlNode InventorySiteLocationRef = Child.SelectSingleNode("./InventorySiteLocationRef");
                    if (InventorySiteLocationRef != null)
                    {
                        //Get value of ListID
                        if (Child.SelectSingleNode("./InventorySiteLocationRef/ListID") != null)
                        {
                            string ListID = Child.SelectSingleNode("./InventorySiteLocationRef/ListID").InnerText;
                        }
                        //Get value of FullName
                        if (Child.SelectSingleNode("./InventorySiteLocationRef/FullName") != null)
                        {
                            string FullName = Child.SelectSingleNode("./InventorySiteLocationRef/FullName").InnerText;
                        }
                    }
                    //Done with field values for InventorySiteLocationRef aggregate

                    XmlNodeList ORSerialLotNumberChildren = Child.SelectNodes("./*");
                    for (int i = 0; i < ORSerialLotNumberChildren.Count; i++)
                    {
                        XmlNode Child = ORSerialLotNumberChildren.Item(i);
                        if (Child.Name == "SerialNumber")
                        {
                        }

                        if (Child.Name == "LotNumber")
                        {
                        }

                    }

                    //Get value of ServiceDate
                    if (Child.SelectSingleNode("./ServiceDate") != null)
                    {
                        string ServiceDate = Child.SelectSingleNode("./ServiceDate").InnerText;
                    }
                    //Get all field values for SalesTaxCodeRef aggregate 
                    XmlNode SalesTaxCodeRef = Child.SelectSingleNode("./SalesTaxCodeRef");
                    if (SalesTaxCodeRef != null)
                    {
                        //Get value of ListID
                        if (Child.SelectSingleNode("./SalesTaxCodeRef/ListID") != null)
                        {
                            string ListID = Child.SelectSingleNode("./SalesTaxCodeRef/ListID").InnerText;
                        }
                        //Get value of FullName
                        if (Child.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                        {
                            string FullName = Child.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                        }
                    }
                    //Done with field values for SalesTaxCodeRef aggregate

                    //Get value of Other1
                    if (Child.SelectSingleNode("./Other1") != null)
                    {
                        string Other1 = Child.SelectSingleNode("./Other1").InnerText;
                    }
                    //Get value of Other2
                    if (Child.SelectSingleNode("./Other2") != null)
                    {
                        string Other2 = Child.SelectSingleNode("./Other2").InnerText;
                    }
                    //Walk list of DataExtRet aggregates
                    XmlNodeList DataExtRetList = Child.SelectNodes("./DataExtRet");
                    if (DataExtRetList != null)
                    {
                        for (int i = 0; i < DataExtRetList.Count; i++)
                        {
                            XmlNode DataExtRet = DataExtRetList.Item(i);
                            //Get value of OwnerID
                            if (DataExtRet.SelectSingleNode("./OwnerID") != null)
                            {
                                string OwnerID = DataExtRet.SelectSingleNode("./OwnerID").InnerText;
                            }
                            //Get value of DataExtName
                            string DataExtName = DataExtRet.SelectSingleNode("./DataExtName").InnerText;
                            //Get value of DataExtType
                            string DataExtType = DataExtRet.SelectSingleNode("./DataExtType").InnerText;
                            //Get value of DataExtValue
                            string DataExtValue = DataExtRet.SelectSingleNode("./DataExtValue").InnerText;
                        }
                    }

                }

                if (Child.Name == "InvoiceLineGroupRet")
                {
                    //Get value of TxnLineID
                    string TxnLineID = Child.SelectSingleNode("./TxnLineID").InnerText;
                    //Get all field values for ItemGroupRef aggregate 
                    //Get value of ListID
                    if (Child.SelectSingleNode("./ItemGroupRef/ListID") != null)
                    {
                        string ListID = Child.SelectSingleNode("./ItemGroupRef/ListID").InnerText;
                    }
                    //Get value of FullName
                    if (Child.SelectSingleNode("./ItemGroupRef/FullName") != null)
                    {
                        string FullName = Child.SelectSingleNode("./ItemGroupRef/FullName").InnerText;
                    }
                    //Done with field values for ItemGroupRef aggregate

                    //Get value of Desc
                    if (Child.SelectSingleNode("./Desc") != null)
                    {
                        string Desc = Child.SelectSingleNode("./Desc").InnerText;
                    }
                    //Get value of Quantity
                    if (Child.SelectSingleNode("./Quantity") != null)
                    {
                        string Quantity = Child.SelectSingleNode("./Quantity").InnerText;
                    }
                    //Get value of UnitOfMeasure
                    if (Child.SelectSingleNode("./UnitOfMeasure") != null)
                    {
                        string UnitOfMeasure = Child.SelectSingleNode("./UnitOfMeasure").InnerText;
                    }
                    //Get all field values for OverrideUOMSetRef aggregate 
                    XmlNode OverrideUOMSetRef = Child.SelectSingleNode("./OverrideUOMSetRef");
                    if (OverrideUOMSetRef != null)
                    {
                        //Get value of ListID
                        if (Child.SelectSingleNode("./OverrideUOMSetRef/ListID") != null)
                        {
                            string ListID = Child.SelectSingleNode("./OverrideUOMSetRef/ListID").InnerText;
                        }
                        //Get value of FullName
                        if (Child.SelectSingleNode("./OverrideUOMSetRef/FullName") != null)
                        {
                            string FullName = Child.SelectSingleNode("./OverrideUOMSetRef/FullName").InnerText;
                        }
                    }
                    //Done with field values for OverrideUOMSetRef aggregate

                    //Get value of IsPrintItemsInGroup
                    string IsPrintItemsInGroup = Child.SelectSingleNode("./IsPrintItemsInGroup").InnerText;
                    //Get value of TotalAmount
                    string TotalAmount = Child.SelectSingleNode("./TotalAmount").InnerText;
                    //Walk list of InvoiceLineRet aggregates
                    XmlNodeList InvoiceLineRetList = Child.SelectNodes("./InvoiceLineRet");
                    if (InvoiceLineRetList != null)
                    {
                        for (int i = 0; i < InvoiceLineRetList.Count; i++)
                        {
                            XmlNode InvoiceLineRet = InvoiceLineRetList.Item(i);
                            //Get value of TxnLineID
                            string TxnLineID = InvoiceLineRet.SelectSingleNode("./TxnLineID").InnerText;
                            //Get all field values for ItemRef aggregate 
                            XmlNode ItemRef = InvoiceLineRet.SelectSingleNode("./ItemRef");
                            if (ItemRef != null)
                            {
                                //Get value of ListID
                                if (InvoiceLineRet.SelectSingleNode("./ItemRef/ListID") != null)
                                {
                                    string ListID = InvoiceLineRet.SelectSingleNode("./ItemRef/ListID").InnerText;
                                }
                                //Get value of FullName
                                if (InvoiceLineRet.SelectSingleNode("./ItemRef/FullName") != null)
                                {
                                    string FullName = InvoiceLineRet.SelectSingleNode("./ItemRef/FullName").InnerText;
                                }
                            }
                            //Done with field values for ItemRef aggregate

                            //Get value of Desc
                            if (InvoiceLineRet.SelectSingleNode("./Desc") != null)
                            {
                                string Desc = InvoiceLineRet.SelectSingleNode("./Desc").InnerText;
                            }
                            //Get value of Quantity
                            if (InvoiceLineRet.SelectSingleNode("./Quantity") != null)
                            {
                                string Quantity = InvoiceLineRet.SelectSingleNode("./Quantity").InnerText;
                            }
                            //Get value of UnitOfMeasure
                            if (InvoiceLineRet.SelectSingleNode("./UnitOfMeasure") != null)
                            {
                                string UnitOfMeasure = InvoiceLineRet.SelectSingleNode("./UnitOfMeasure").InnerText;
                            }
                            //Get all field values for OverrideUOMSetRef aggregate 
                            XmlNode OverrideUOMSetRef = InvoiceLineRet.SelectSingleNode("./OverrideUOMSetRef");
                            if (OverrideUOMSetRef != null)
                            {
                                //Get value of ListID
                                if (InvoiceLineRet.SelectSingleNode("./OverrideUOMSetRef/ListID") != null)
                                {
                                    string ListID = InvoiceLineRet.SelectSingleNode("./OverrideUOMSetRef/ListID").InnerText;
                                }
                                //Get value of FullName
                                if (InvoiceLineRet.SelectSingleNode("./OverrideUOMSetRef/FullName") != null)
                                {
                                    string FullName = InvoiceLineRet.SelectSingleNode("./OverrideUOMSetRef/FullName").InnerText;
                                }
                            }
                            //Done with field values for OverrideUOMSetRef aggregate

                            XmlNodeList ORRateChildren = InvoiceLineRet.SelectNodes("./*");
                            for (int i = 0; i < ORRateChildren.Count; i++)
                            {
                                XmlNode Child = ORRateChildren.Item(i);
                                if (Child.Name == "Rate")
                                {
                                }

                                if (Child.Name == "RatePercent")
                                {
                                }

                            }

                            //Get all field values for ClassRef aggregate 
                            XmlNode ClassRef = InvoiceLineRet.SelectSingleNode("./ClassRef");
                            if (ClassRef != null)
                            {
                                //Get value of ListID
                                if (InvoiceLineRet.SelectSingleNode("./ClassRef/ListID") != null)
                                {
                                    string ListID = InvoiceLineRet.SelectSingleNode("./ClassRef/ListID").InnerText;
                                }
                                //Get value of FullName
                                if (InvoiceLineRet.SelectSingleNode("./ClassRef/FullName") != null)
                                {
                                    string FullName = InvoiceLineRet.SelectSingleNode("./ClassRef/FullName").InnerText;
                                }
                            }
                            //Done with field values for ClassRef aggregate

                            //Get value of Amount
                            if (InvoiceLineRet.SelectSingleNode("./Amount") != null)
                            {
                                string Amount = InvoiceLineRet.SelectSingleNode("./Amount").InnerText;
                            }
                            //Get all field values for InventorySiteRef aggregate 
                            XmlNode InventorySiteRef = InvoiceLineRet.SelectSingleNode("./InventorySiteRef");
                            if (InventorySiteRef != null)
                            {
                                //Get value of ListID
                                if (InvoiceLineRet.SelectSingleNode("./InventorySiteRef/ListID") != null)
                                {
                                    string ListID = InvoiceLineRet.SelectSingleNode("./InventorySiteRef/ListID").InnerText;
                                }
                                //Get value of FullName
                                if (InvoiceLineRet.SelectSingleNode("./InventorySiteRef/FullName") != null)
                                {
                                    string FullName = InvoiceLineRet.SelectSingleNode("./InventorySiteRef/FullName").InnerText;
                                }
                            }
                            //Done with field values for InventorySiteRef aggregate

                            //Get all field values for InventorySiteLocationRef aggregate 
                            XmlNode InventorySiteLocationRef = InvoiceLineRet.SelectSingleNode("./InventorySiteLocationRef");
                            if (InventorySiteLocationRef != null)
                            {
                                //Get value of ListID
                                if (InvoiceLineRet.SelectSingleNode("./InventorySiteLocationRef/ListID") != null)
                                {
                                    string ListID = InvoiceLineRet.SelectSingleNode("./InventorySiteLocationRef/ListID").InnerText;
                                }
                                //Get value of FullName
                                if (InvoiceLineRet.SelectSingleNode("./InventorySiteLocationRef/FullName") != null)
                                {
                                    string FullName = InvoiceLineRet.SelectSingleNode("./InventorySiteLocationRef/FullName").InnerText;
                                }
                            }
                            //Done with field values for InventorySiteLocationRef aggregate

                            XmlNodeList ORSerialLotNumberChildren = InvoiceLineRet.SelectNodes("./*");
                            for (int i = 0; i < ORSerialLotNumberChildren.Count; i++)
                            {
                                XmlNode Child = ORSerialLotNumberChildren.Item(i);
                                if (Child.Name == "SerialNumber")
                                {
                                }

                                if (Child.Name == "LotNumber")
                                {
                                }

                            }

                            //Get value of ServiceDate
                            if (InvoiceLineRet.SelectSingleNode("./ServiceDate") != null)
                            {
                                string ServiceDate = InvoiceLineRet.SelectSingleNode("./ServiceDate").InnerText;
                            }
                            //Get all field values for SalesTaxCodeRef aggregate 
                            XmlNode SalesTaxCodeRef = InvoiceLineRet.SelectSingleNode("./SalesTaxCodeRef");
                            if (SalesTaxCodeRef != null)
                            {
                                //Get value of ListID
                                if (InvoiceLineRet.SelectSingleNode("./SalesTaxCodeRef/ListID") != null)
                                {
                                    string ListID = InvoiceLineRet.SelectSingleNode("./SalesTaxCodeRef/ListID").InnerText;
                                }
                                //Get value of FullName
                                if (InvoiceLineRet.SelectSingleNode("./SalesTaxCodeRef/FullName") != null)
                                {
                                    string FullName = InvoiceLineRet.SelectSingleNode("./SalesTaxCodeRef/FullName").InnerText;
                                }
                            }
                            //Done with field values for SalesTaxCodeRef aggregate

                            //Get value of Other1
                            if (InvoiceLineRet.SelectSingleNode("./Other1") != null)
                            {
                                string Other1 = InvoiceLineRet.SelectSingleNode("./Other1").InnerText;
                            }
                            //Get value of Other2
                            if (InvoiceLineRet.SelectSingleNode("./Other2") != null)
                            {
                                string Other2 = InvoiceLineRet.SelectSingleNode("./Other2").InnerText;
                            }
                            //Walk list of DataExtRet aggregates
                            XmlNodeList DataExtRetList = InvoiceLineRet.SelectNodes("./DataExtRet");
                            if (DataExtRetList != null)
                            {
                                for (int i = 0; i < DataExtRetList.Count; i++)
                                {
                                    XmlNode DataExtRet = DataExtRetList.Item(i);
                                    //Get value of OwnerID
                                    if (DataExtRet.SelectSingleNode("./OwnerID") != null)
                                    {
                                        string OwnerID = DataExtRet.SelectSingleNode("./OwnerID").InnerText;
                                    }
                                    //Get value of DataExtName
                                    string DataExtName = DataExtRet.SelectSingleNode("./DataExtName").InnerText;
                                    //Get value of DataExtType
                                    string DataExtType = DataExtRet.SelectSingleNode("./DataExtType").InnerText;
                                    //Get value of DataExtValue
                                    string DataExtValue = DataExtRet.SelectSingleNode("./DataExtValue").InnerText;
                                }
                            }

                        }
                    }

                    //Walk list of DataExtRet aggregates
                    XmlNodeList DataExtRetList = Child.SelectNodes("./DataExtRet");
                    if (DataExtRetList != null)
                    {
                        for (int i = 0; i < DataExtRetList.Count; i++)
                        {
                            XmlNode DataExtRet = DataExtRetList.Item(i);
                            //Get value of OwnerID
                            if (DataExtRet.SelectSingleNode("./OwnerID") != null)
                            {
                                string OwnerID = DataExtRet.SelectSingleNode("./OwnerID").InnerText;
                            }
                            //Get value of DataExtName
                            string DataExtName = DataExtRet.SelectSingleNode("./DataExtName").InnerText;
                            //Get value of DataExtType
                            string DataExtType = DataExtRet.SelectSingleNode("./DataExtType").InnerText;
                            //Get value of DataExtValue
                            string DataExtValue = DataExtRet.SelectSingleNode("./DataExtValue").InnerText;
                        }
                    }

                }

            }

            //Walk list of DataExtRet aggregates
            XmlNodeList DataExtRetList = InvoiceRet.SelectNodes("./DataExtRet");
            if (DataExtRetList != null)
            {
                for (int i = 0; i < DataExtRetList.Count; i++)
                {
                    XmlNode DataExtRet = DataExtRetList.Item(i);
                    //Get value of OwnerID
                    if (DataExtRet.SelectSingleNode("./OwnerID") != null)
                    {
                        string OwnerID = DataExtRet.SelectSingleNode("./OwnerID").InnerText;
                    }
                    //Get value of DataExtName
                    string DataExtName = DataExtRet.SelectSingleNode("./DataExtName").InnerText;
                    //Get value of DataExtType
                    string DataExtType = DataExtRet.SelectSingleNode("./DataExtType").InnerText;
                    //Get value of DataExtValue
                    string DataExtValue = DataExtRet.SelectSingleNode("./DataExtValue").InnerText;
                }
            }

        }



    }
}