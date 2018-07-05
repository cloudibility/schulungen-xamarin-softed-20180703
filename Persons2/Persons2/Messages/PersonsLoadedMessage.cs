using System;
using System.Collections.Generic;
using System.Text;
using Persons3.Models;
using Prism.Events;

namespace Persons3.Messages
{
    /// <summary>
    /// Shared event / message
    /// </summary>
    public class PersonsLoadedMessage : PubSubEvent<List<Person>>
    {
    }
}
