namespace Alquiler.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteAlquiler
        {
            // Read
            public const string GetAll = Base + "/Alquiler/all";
            public const string GetById = Base + "/Alquiler/{id}";

            // Write
            public const string Create = Base + "/Alquiler/create";
            public const string Update = Base + "/Alquiler/update";
            public const string Delete = Base + "/Alquiler/delete";
        }

    }
}
