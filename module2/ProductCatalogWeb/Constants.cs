using System.Collections.Generic;

namespace Constants
{
    public static class ProductCatalogAPI
    {
        public const string CategoryUrl = "https://localhost:5050/api/Categories";
        public const string ProductUrl = "https://localhost:5050/api/Products";
        public const string ProductReadScope = "api://cfa98752-d098-4288-b13c-6282f807fc6c/Product.Read";
        public const string ProductWriteScope = "api://cfa98752-d098-4288-b13c-6282f807fc6c/Product.Write";
        public const string CategoryReadScope = "api://cfa98752-d098-4288-b13c-6282f807fc6c/Category.Read";
        public const string CategoryWriteScope = "api://cfa98752-d098-4288-b13c-6282f807fc6c/Category.Write";

        public static List<string> SCOPES = new List<string>()
    {
      ProductReadScope, ProductWriteScope, CategoryReadScope, CategoryWriteScope
    };
    }

    public static class ClaimIds
    {
        public const string UserObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        public const string TenantId = "http://schemas.microsoft.com/identity/claims/tenantid";
    }
}