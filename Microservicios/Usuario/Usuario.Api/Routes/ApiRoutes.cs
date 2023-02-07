namespace Usuario.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteUsuario
        {
            // Read
            public const string GetAll = Base + "/Usuario/all";
            public const string GetById = Base + "/Usuario/{id}";

            // Write
            public const string Create = Base + "/Usuario/create";
            public const string Update = Base + "/Usuario/update";
            public const string Delete = Base + "/Usuario/delete";
        }

    }
}
