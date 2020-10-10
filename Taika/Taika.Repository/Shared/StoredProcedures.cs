namespace Taika.Repository.Shared
{
    public struct StoredProcedures
    {
        public const string AddRepository = "[dbo].[AddRepository]";
        public const string DeleteRepository = "[dbo].[DeleteRepository]";
        public const string GetRepository = "[dbo].[GetRepository]";
        public const string GetAllRepositories = "[dbo].[GetAllRepositories]";
        public const string UpdateRepository = "[dbo].[UpdateRepository]";

        public const string AddSetting = "[dbo].[AddSetting]";
        public const string DeleteSetting = "[dbo].[DeleteSetting]";
        public const string GetSetting = "[dbo].[GetSetting]";
        public const string GetAllSettings = "[dbo].[GetAllSettings]";
        public const string UpdateSetting = "[dbo].[UpdateSetting]";
        public const string AddOrUpdateSetting = "[dbo].[AddOrUpdateSetting]";
    }
}
