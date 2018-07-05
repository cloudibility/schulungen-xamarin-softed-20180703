using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;

namespace Persons3.Messages
{
    /// <summary>
    /// Represents a message forcing the persons handler to load data
    /// </summary>
    public class LoadPersonsMessage : PubSubEvent
    {
    }
}
