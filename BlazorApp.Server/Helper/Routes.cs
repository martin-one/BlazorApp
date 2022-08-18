namespace BlazorApp.Server.Helper
{
    public static class Routes
    {
        public const string Home = "/";
        public const string Counter = "/counter";
        public const string FetchData = "/fetchdata";
        public static class Category
        {
            public const string Main = "/category";
            public const string Create = "/category/create";
            public const string Edit = "/category/edit/{id:int}";
            public static string EditById(int id) => $"/category/edit/{id}";
        }

        public static class Product
        {
            public const string Main = "/product";
            public const string Create = "/product/create";
            public const string Edit = "/product/edit/{id:int}";
            public static string EditById(int id) => $"/product/edit/{id}";
        }

        public static class LearnBlazor
        {
            public const string BindProperties = "/learnblazor/bindprop";
            public const string DemoProduct = "/learnblazor/demoproduct";
            public const string ParentChildRelation = "/learnblazor/parentcomponent";
            public const string LearnRouting = "/learnblazor/routing/123/456";
            public const string BlazorJS = "/learnblazor/blazorjs";
            public const string LifeCycle = "/learnblazor/lifecycle";
        }
    }
}
