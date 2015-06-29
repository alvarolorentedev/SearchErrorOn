using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;

namespace soft.Hati.ErrorListSearchOn.Services.Options
{
    class SettingStoreProvider
    {
        private readonly WritableSettingsStore userSettingsStore;
        private readonly string collection;

        public SettingStoreProvider(string collection)
        {
            this.collection = collection;
            SettingsManager settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);
        }

        public string GetValue(string propertyName)
        {
            return userSettingsStore.PropertyExists(collection, propertyName) 
                ? userSettingsStore.GetString(collection, propertyName) 
                : null;
        }

        public void SetValue(string propertyName, string propertyValue)
        {
            userSettingsStore.SetString(collection, propertyName, propertyValue);
        }
    }
}
