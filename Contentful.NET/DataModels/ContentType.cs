using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contentful.NET.DataModels
{
    public class ContentType : ContentfulItemBase, IContentfulItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
