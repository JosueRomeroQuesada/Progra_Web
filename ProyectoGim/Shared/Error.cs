namespace Shared
{
    public sealed record Error(string code, string description)
    {
        /*
        private Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }

        public string Description { get; }

        */
        public static Error None = new Error(string.Empty, string.Empty);
    }
}
