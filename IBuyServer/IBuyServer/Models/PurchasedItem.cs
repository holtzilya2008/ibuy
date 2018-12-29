using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IBuyServer.Models
{
    [Serializable]
    public class PurchasedItem : ISerializable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PurchasedItem(string id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           info.AddValue("id", this.Id, typeof(string));
           info.AddValue("name", this.Name, typeof(string));
           info.AddValue("description", this.Description, typeof(string));
        }
    }
}