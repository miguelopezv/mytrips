using System;
using System.Collections.Generic;

namespace MyTrips.Classes
{
    public class Categories
    {
        public Meta meta { get; set; }
        public Response response { get; set; }

        public class Meta
        {
            public int code { get; set; }
            public string requestId { get; set; }
        }

        public class Response
        {
            public List<Category> categories { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }

            public override string ToString()
            {
                return name;
            }
        }

        public class Icon
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }
	}
}