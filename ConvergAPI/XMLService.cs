using System;
using System.Xml;
using System.Xml.Serialization;

namespace oharkins.ConvergAPI
{
    public class XMLService
    {
		public static string Serialize<T>(T value)
		{
			var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
			var serializer = new XmlSerializer(value.GetType());
			var settings = new XmlWriterSettings();
            settings.Indent = false;
			settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = false;

            var stream = new System.IO.StringWriter();
			using (var writer = XmlWriter.Create(stream, settings))
			{
				serializer.Serialize(writer, value, emptyNamepsaces);
				return stream.ToString();
			}
		}

		public static T Deserialize<T>(string xmlText)
		{      
			try
			{
				var stringReader = new System.IO.StringReader(xmlText);
				var serializer = new XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(stringReader);
			}
			catch (Exception e)
			{
                Console.WriteLine(); 
				throw;
			}
		}
    }
}
