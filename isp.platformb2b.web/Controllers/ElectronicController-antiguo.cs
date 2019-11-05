using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.UnitOfWork;
using isp.platformb2b.web.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using isp.platformb2b.models.DTOs.documents;

namespace isp.platformb2b.web.Controllers
{
    [Route("[controller]")]
    public class ElectronicXController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;

        private readonly IServiceMasterTables _iServiceMasterTables;

        private readonly IServiceDocument _iserviceDocument;
        private readonly IServicePurcharseOrder _iservicePurcharseOrder;

        private readonly IServiceEnterprise _iServiceEnterprise;
        private readonly Verify _verify;

        private static class urlXmlSunat
        {
            public static string ruc_empresa_cliente 
                    => "/ns:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyIdentification/cbc:ID";
            public static string ruc_empresa_proveedor
                    => "/ns:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID";
            public static string id_factura 
                    => "/ns:Invoice/cbc:ID";
            public static string dia_emision
                    => "/ns:Invoice/cbc:IssueDate";
            public static string hora_emision
                    => "/ns:Invoice/cbc:IssueTime";
            public static string monto_subtotal_afecto
                    => "/ns:Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxableAmount"; 
            public static string monto_igv
                    => "/ns:Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount";
            public static string monto_total
                    => "/ns:Invoice/cac:LegalMonetaryTotal/cbc:PrepaidAmount";

        }
        public ElectronicXController(IHostingEnvironment hostingEnvironment,
            IServiceDocument iserviceDocument,
            IServicePurcharseOrder iservicePurcharseOrder,
            IServiceMasterTables iServiceMasterTables,
            IServiceEnterprise iServiceEnterprise)
        {
            _iServiceMasterTables = iServiceMasterTables;
            _hostingEnvironment = hostingEnvironment;
            _iserviceDocument = iserviceDocument;
            _iservicePurcharseOrder = iservicePurcharseOrder;
            _iServiceMasterTables = iServiceMasterTables;
            _iServiceEnterprise = iServiceEnterprise;

            _verify = new Verify(_iserviceDocument, _iservicePurcharseOrder, _iServiceMasterTables, _iServiceEnterprise);
        }

        [HttpPost("xml")]
        [DisableRequestSizeLimit]

        public ActionResult OnPostImport(IFormFile xmlFile)
        {
            var uploads = _hostingEnvironment.WebRootPath;
            var filePath = Path.Combine(uploads, xmlFile.FileName).ToString();

            if (xmlFile.ContentType.Equals("application/xml") || xmlFile.ContentType.Equals("text/xml"))
            {
                using (XmlReader xmlReader = XmlReader.Create(xmlFile.OpenReadStream()))
                {
                    var doc = new XmlDocument();
                    doc.Load(xmlReader);
                    var nsmgr = new XmlNamespaceManager(doc.NameTable);
                    XPathNavigator nav = doc.CreateNavigator();

                    nsmgr.AddNamespace("cac", @"urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                    nsmgr.AddNamespace("cbc", @"urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                    nsmgr.AddNamespace("ccts", @"urn:un:unece:uncefact:documentation:2");
                    nsmgr.AddNamespace("ds ", @"http://www.w3.org/2000/09/xmldsig#");
                    nsmgr.AddNamespace("ext", @"urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                    nsmgr.AddNamespace("qdt", @"urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                    nsmgr.AddNamespace("udt", @"urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                    nsmgr.AddNamespace("xsi", @"http://www.w3.org/2001/XMLSchema-instance");
                    nsmgr.AddNamespace("ns", @"urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");

                    GetTextFromXML getXml = new GetTextFromXML(nav, nsmgr);

                    documentDTO newDocument = new documentDTO()
                    {
                        ruc_empresa_cliente = getXml.GetString(urlXmlSunat.ruc_empresa_cliente),
                        ruc_empresa_proveedor = getXml.GetString(urlXmlSunat.ruc_empresa_proveedor),
                        num_correlativo = getXml.GetString(urlXmlSunat.id_factura).Contains("-") ? getXml.GetString(urlXmlSunat.id_factura).Split("-")[1] : "",
                        num_serie = getXml.GetString(urlXmlSunat.id_factura).Contains("-") ? getXml.GetString(urlXmlSunat.id_factura).Split("-")[0] : "",
                        fis_elec = false,
                        fecha_emision = getXml.GetDateHour(urlXmlSunat.dia_emision, urlXmlSunat.hora_emision),
                        
                        monto_subtotal_afecto = getXml.GetAmount(urlXmlSunat.monto_subtotal_afecto),
                        monto_igv = getXml.GetAmount(urlXmlSunat.monto_igv),
                        monto_total = getXml.GetAmount(urlXmlSunat.monto_total),

                        monto_subtotal_inafecto = 0,
                        


                    };


                    

                    return Ok(newDocument);
                    string a = "";

                    /*
                    XmlDocument doc = new XmlDocument();

                    doc.Load(xmlReader);

                    //XPathDocument doc = new XPathDocument(xmlReader);
                    
                    XPathNavigator nav = doc.CreateNavigator();
                    //object xx = nav.GetAttribute(@"/Invoice");

                    XmlNamespaceManager nsmgr =
                             new XmlNamespaceManager(doc.NameTable);

                    


                    //nsmgr.AddNamespace("xmlns", @"urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"); ;
                    nsmgr.AddNamespace("cac" , @"urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                     nsmgr.AddNamespace("cbc" , @"urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                     nsmgr.AddNamespace("ccts" , @"urn:un:unece:uncefact:documentation:2");
                     nsmgr.AddNamespace("ds ", @"http://www.w3.org/2000/09/xmldsig#");
                     nsmgr.AddNamespace("ext" , @"urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                     nsmgr.AddNamespace("qdt" , @"urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                     nsmgr.AddNamespace("udt" , @"urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                    nsmgr.AddNamespace("xsi", @"http://www.w3.org/2001/XMLSchema-instance");

                    string xpath = @"/invoice/cac:PrepaidPayment";
                    string xxx = @"/invoice/cac:InvoiceLine/cac:DocumentReference/cbc:ID";

                    string pochito = @"cac:PrepaidPayment";
                    string xxx2 = @"cac:InvoiceLine/cac:DocumentReference/cbc:ID";

                    XPathNavigator element = nav.SelectSingleNode(xpath, nsmgr);
                    XPathNavigator element2 = nav.SelectSingleNode(xxx, nsmgr);
                    XPathNavigator element3 = nav.SelectSingleNode(pochito, nsmgr);
                    XPathNavigator element4 = nav.SelectSingleNode(xxx2, nsmgr);

                    XmlNodeList list = doc.SelectNodes(xpath, nsmgr);
                    XmlNodeList list2 = doc.SelectNodes(xxx, nsmgr);
                    XmlNodeList list3 = doc.SelectNodes(pochito, nsmgr);
                    XmlNodeList list4 = doc.SelectNodes(xxx2, nsmgr);

                    return Ok(list);

                    /*
                    var list = doc.XPathSelectElement(xpath, nsmgr);
                    var list1 = doc.XPathSelectElement(xxx, nsmgr);
                    var list2 = doc.XPathSelectElement(pochito, nsmgr);
                    var list3 = doc.XPathSelectElement(xxx2, nsmgr);


                    //XmlNodeList list = doc.Root.SetValue("//cbc:ID", manager);

                    var id = doc.Root.XPathSelectElement("cbc:ID", nsmgr).Value;


                    object o = nav.GetNamespace(xxx);
                    //XmlNodeList xnl = root.SelectNodes(xpath, nsmgr);

                    var x = doc.Root.XPathEvaluate(xxx, nsmgr);

                    return Ok(element);
                     
                    Console.WriteLine("Element Prefix:" + element.Prefix +
                               " Local name:" + element.LocalName);
                    Console.WriteLine("Namespace URI: " +
                                element.NamespaceURI);
*/
                }
            }
            return BadRequest();
        }

        private class GetTextFromXML
        {
            private XPathNavigator _nav;
            private XmlNamespaceManager _nsmgr;
            public GetTextFromXML(XPathNavigator nav, XmlNamespaceManager nsmgr)
            {
                _nav = nav;
                _nsmgr = nsmgr;
            }

            public string GetString (string url)
            {
                var temp = _nav.SelectSingleNode(url, _nsmgr);
                if (temp != null)
                {
                    return (!string.IsNullOrEmpty(temp.InnerXml)) ? temp.InnerXml : "";
                }
                else
                {
                    return "";
                }
                
            }

            public DateTime GetDateHour (string date,string hour)
            {
                try
                {
                    string[] cadDate = GetString(date).Split("-");
                    string[] cadHour = GetString(hour).Split(":");
                    return new DateTime(int.Parse(cadDate[0]), int.Parse(cadDate[1]), int.Parse(cadDate[2]),
                                        int.Parse(cadHour[0]), int.Parse(cadHour[1]), int.Parse(cadHour[2].Replace(".0Z","")));
                }
                catch(Exception err)
                {
                    return new DateTime();
                }
            }

            public DateTime GetDate(string date)
            {
                 try
                 {
                    string[] cadDate = GetString(date).Split("-");
                    return new DateTime(int.Parse(cadDate[0]), int.Parse(cadDate[1]), int.Parse(cadDate[2]));
                }
                catch (Exception err)
                {
                    return new DateTime();
                }
            }

            public decimal GetAmount (string url)
            {
                string temp = GetString(url);
                if (temp.Equals("")) return 0;

                decimal test;
                if (decimal.TryParse(temp, out test)) return test;
                return 0;

            }


        }
    }
}