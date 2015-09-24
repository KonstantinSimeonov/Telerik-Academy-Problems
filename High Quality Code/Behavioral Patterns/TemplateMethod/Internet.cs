namespace TemplateMethod
{
    using System;
    using System.Collections.Generic;

    public static class Internet
    {
        public static IDictionary<string, IDomain> Domains { get; private set; }

        static Internet()
        {
            Domains = new Dictionary<string, IDomain>()
            {
                {"github.com", new Domain()},
                {"telerikacademy.com", new Domain()},
                {"piratebay.net", new Domain()},
            };
        }
    }
}