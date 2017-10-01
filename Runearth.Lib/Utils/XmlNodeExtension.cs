using System.Xml;

namespace Runearth.Lib.Utils
{
    public static class XmlNodeExtension
    {
        public static XmlNode WithXmlns(this XmlNode self, string name, string url)
        {
            (self as XmlElement).SetAttribute("xmlns:" + name, url);
            return self;
        }

        public static XmlDocument GetDocument(this XmlNode self)
        {
            if (self.OwnerDocument != null)
            {
                return self.OwnerDocument;
            }
            if (self is XmlDocument)
            {
                return self as XmlDocument;
            }
            return null;
        }

        public static XmlNode WithText(this XmlNode self, string text)
        {
            var textNode = self.GetDocument().CreateTextNode(text);
            self.AppendChild(textNode);
            return self;
        }

        public static XmlNode AddXmlDeclaration(this XmlNode self, string version, string encoding, string standalone)
        {
            var newNode = self.GetDocument().CreateXmlDeclaration(version, encoding, standalone);
            self.AppendChild(newNode);
            return newNode;
        }

        public static XmlNode AddSubElement(this XmlNode self, string name)
        {
            var newNode = self.GetDocument().CreateElement(name);
            self.AppendChild(newNode);
            return newNode;
        }

        public static XmlNode AddSubElement(this XmlNode self, string qualifiedName, string namespaceURI)
        {
            var newNode = self.GetDocument().CreateElement(qualifiedName, namespaceURI);
            self.AppendChild(newNode);
            return newNode;
        }

        public static XmlNode AddSubElement(this XmlNode self, string prefix, string localName, string namespaceURI)
        {
            var newNode = self.GetDocument().CreateElement(prefix, localName, namespaceURI);
            self.AppendChild(newNode);
            return newNode;
        }
    }
}