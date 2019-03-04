﻿
using System.Xml.Serialization;

namespace GroupDocs.Signature.MVC.Products.Signature.Entity.Xml
{
    /// <summary>
    /// TextXmlEntity
    /// </summary>
    [XmlRoot("TextXmlEntity")]
    public class TextXmlEntity : XmlEntity
    {
        [XmlElement("EncodedImage")]
        public string encodedImage{ get; set; }

        [XmlElement("BackgroundColor")]
        public string backgroundColor = "rgb(255,255,255)";

        [XmlElement("FontColor")]
        public string fontColor = "rgb(0,0,0)";

        [XmlElement("Font")]
        public string font{ get; set; }       

        [XmlElement("FontSize")]
        public int fontSize{ get; set; }       

        [XmlElement("isBold")]
        public bool bold{ get; set; }

        [XmlElement("isItalic")]
        public bool italic { get; set; }

        [XmlElement("isUnderline")]
        public bool underline { get; set; }
    }
}