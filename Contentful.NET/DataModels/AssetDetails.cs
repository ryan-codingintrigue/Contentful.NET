using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contentful.NET.DataModels
{
    public class AssetDetails
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public File File { get; set; }
    }
}
