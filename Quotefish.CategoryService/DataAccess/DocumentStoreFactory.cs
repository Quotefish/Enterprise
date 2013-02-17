using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client.Document;

namespace Quotefish.CategoryService.Worker.DataAccess
{
    public class DocumentStoreFactory
    {
        public DocumentStore DocumentStore { get; private set; }

        public static DocumentStoreFactory Instance
        {
            get
            {
                lock (Locker)
                {
                    if (_instance == null)
                    {
                        _instance = new DocumentStoreFactory();
                    }
                }
                return _instance;
            }
        }

        private DocumentStoreFactory()
        {
            DocumentStore = new DocumentStore
            {
                ConnectionStringName = "CategoryService"
            };
            DocumentStore.Initialize();
        }

        private static DocumentStoreFactory _instance = null;
        private static readonly object Locker = new object();

    }
}
