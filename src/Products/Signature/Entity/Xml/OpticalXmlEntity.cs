using System.Xml.Serialization;

namespace GroupDocs.Signature.MVC.Products.Signature.Entity.Xml
{
    /// <summary>
    /// OpticalXmlEntity
    /// </summary>
    [XmlRoot("OpticalXmlEntity")]
    public class OpticalXmlEntity : XmlEntity
    {
        [XmlElement("BorderColor")]
        public string borderColor = "rgb(0,0,0)";

        [XmlElement("EncodedImage")]
        public string encodedImage { get; set; }

        [XmlElement("BorderStyle")]
        public int borderStyle { get; set; }

        [XmlElement("BorderWidth")]
        public int borderWidth { get; set; }
    }
}