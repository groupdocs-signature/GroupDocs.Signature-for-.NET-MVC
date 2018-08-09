﻿using System.Xml.Serialization;

namespace GroupDocs.Signature.MVC.Products.Signature.Entity.Xml
{
    /// <summary>
    /// StampXmlEntity
    /// </summary>
    [XmlRoot("StampXmlEntity")]
    public class StampXmlEntity : XmlEntity
    {
        [XmlElement("textExpansion")]
        public string textExpansion { get; set; }

        [XmlElement("font")]
        public string font { get; set; }

        [XmlElement("textColor")]
        public string textColor = "rgb(0,0,0)";

        [XmlElement("strokeColor")]
        public string strokeColor = "rgb(0,0,0)";

        [XmlElement("backgroundColor")]
        public string backgroundColor = "rgb(0,0,0)";

        [XmlElement("radius")]
        public int radius { get; set; }

        [XmlElement("fontSize")]
        public int fontSize { get; set; }

        [XmlElement("textRepeat")]
        public int textRepeat { get; set; }
    }
}