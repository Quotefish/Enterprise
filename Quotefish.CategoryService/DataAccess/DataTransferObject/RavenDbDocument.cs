using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quotefish.CategoryService.DataAccess.DataTransferObject
{
    public abstract class RavenDbDocument
    {
        public string Id { get; private set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                SetId(value);
            }
        }

        private string _name;

        private void SetId(string name)
        {
            string idPrefix = this.GetType().Name;
            Id = string.Format("{0}/{1}", idPrefix, name);
        }
    }
}
