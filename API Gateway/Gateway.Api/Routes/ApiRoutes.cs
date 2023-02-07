namespace Gateway.Api.Routes
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RoutePelicula
        {
            // Read
            public const string GetAll = Base + "/pelicula/all";
            public const string GetById = Base + "/pelicula/{id}";

            // Write
            public const string Create = Base + "/pelicula/create";
            public const string Update = Base + "/pelicula/update";
            public const string Delete = Base + "/pelicula/delete";
        }




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

