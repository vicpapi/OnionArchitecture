using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Onion.Infrastructure.ApplicationLog.Helper
{
    public class XmlLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            writer.WriteStartElement("LogEntry");

            writer.WriteStartElement("Message");
            if (loggingEvent.Level == Level.Error)
            {
                var array = loggingEvent.RenderedMessage.Split('\n');
                writer.WriteAttributeString("Id", array[0].Replace("ErrorId: ", ""));
            }
            else
            {
                writer.WriteAttributeString("Id", Guid.NewGuid().ToString());
            }

            writer.WriteString(loggingEvent.RenderedMessage);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
