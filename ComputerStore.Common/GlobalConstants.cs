using System;

namespace ComputerStore.Common
{
    public static class GlobalConstants
    {
        // Web
        public static readonly string SYSTEM_NAME = "ComputerStore.com";
        public static readonly string SYSTEM_BASE_URL = "https://ComputerStore.com";

        public const string DEFAULT_USER_AGENT =
            "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36";

        public static string SYSTEM_VERSION { get; set; }


        // Discounts
        public static readonly decimal DEFAULT_DISCOUNT = (decimal) 0.05;
    }
}
