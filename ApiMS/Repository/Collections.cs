using ApiMS.Model;

namespace ApiMS.Repository
{
    public static class Collections
    {
        public static string GetCollections(object entity)
        {
            switch (entity.GetType().Name)
            {
                case "Product":
                    return "Products";
                default:
                    throw new System.Exception("É preciso informar um nome de coleção válido!");
            }
        }
    }
}
