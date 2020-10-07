using log4net.Core;
using log4net.Layout;
using System;
using System.Xml;

namespace Onion.Infrastructure.ApplicationLog.Helper
{
    public class XmlLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            string id;

            writer.WriteStartElement("LogEntry");

            writer.WriteStartElement("Message");

            if (loggingEvent.Level == Level.Error)
            {
                var array = loggingEvent.RenderedMessage.Split('\n');
                id = array[0].Replace("ErrorId: ", "");
            }
            else
            {
                id = Guid.NewGuid().ToString();
            }

            writer.WriteAttributeString("Id", id);

            writer.WriteString(loggingEvent.RenderedMessage);
            writer.WriteEndElement();
            writer.WriteEndElement();

            EmailLogger.SendEmail(loggingEvent.RenderedMessage);
        }
    }
}
