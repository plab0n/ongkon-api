using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Contracts.Models
{
    public class WhiteBoard : ICommon, IRepository
    {
        public string Title { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Connector> Connectors { get; set; }
        public List<string> Participants { get; set; }

        public WhiteBoard()
        {
            Nodes = new List<Node>();
            Connectors = new List<Connector>();
            Participants = new List<string>();
            CreatedAt = DateTime.Now;
        }

        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public string GetId()
        {
            return Id;
        }

        public void AddNode(Node whiteBoardElement)
        {
            Nodes.Add(whiteBoardElement);
        }

        public void AddConnector(Connector connector)
        {
            if (Connectors == null)
            {
                Connectors = new List<Connector>();
            }
            Connectors.Add(connector);
        }

        public Node GetNode(string nodeId)
        {
            return Nodes.FirstOrDefault(o => o.Id.Equals(nodeId));
        }
    }
}
