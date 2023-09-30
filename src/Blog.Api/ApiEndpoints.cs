namespace Blog.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class V1
    {
        private const string VersionBase = $"{ApiBase}/v1";
        
        public static class Posts
        {
            private const string Base = $"{VersionBase}/posts";

            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
        
            public const string Create = Base;
        
            public const string Update = $"{Base}/{{id:guid}}";
        }
    
        public static class Socials
        {
            private const string Base = $"{VersionBase}/socials";

            public const string GetAll = Base;
        
        }
    }

}