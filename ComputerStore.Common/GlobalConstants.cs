using System;

namespace ComputerStore.Common
{
    public static class GlobalConstants
    {
        #region Web
        public static readonly string SYSTEM_NAME = "ComputerStore.com";
        public static readonly string SYSTEM_BASE_URL = "https://ComputerStore.com";
        public static readonly string API_BASE_URL = "https://localhost:44389/api/";

        public static readonly string DEFAULT_USER_AGENT =
            "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36";
        #endregion

        #region DB
        public static readonly string DB_ENTITY_ADD_SUCCESS = "Entity has been saved to DB";
        public static readonly string DB_ENTITY_ADD_FAIL = "Entity could not be saved to DB, Stack Trace: ";
        
        public static readonly string DB_ENTITY_UPDATE_SUCCESS = "Entity has been successfully updated";
        public static readonly string DB_ENTITY_UPDATE_FAIL = "Entity could not be updated, Stack Trace: ";

        public static readonly string DB_ENTITY_REMOVE_SUCCESS = "Entity has been successfully removed";
        public static readonly string DB_ENTITY_REMOVE_FAIL = "Entity could not be removed, Stack Trace: ";
        #endregion

        #region Discounts
        public static readonly decimal DEFAULT_DISCOUNT = (decimal) 0.05;
        #endregion
    }
}
