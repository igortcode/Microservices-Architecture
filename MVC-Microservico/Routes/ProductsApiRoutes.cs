namespace MVC_Microservico.Routes
{
    public static class ProductsApiRoutes
    {
        private const string BASE_URI = @"/api/Product";
        public const string GET_ALL = @$"{BASE_URI}/buscar-todos";
        public const string GET_BY_ID = @$"{BASE_URI}/buscar";
        public const string CREATE = @$"{BASE_URI}/inserir";
        public const string UPDATE = @$"{BASE_URI}/atualizar";
        public const string DELETE = @$"{BASE_URI}/excluir";
    }
}
