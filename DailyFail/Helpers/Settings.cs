
// Helpers/Settings.cs This file was automatically added when you installed the Settings Plugin. If you are not using a PCL then comment this file back in to use it.
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace BaitNews.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

	private const string NSFWEnabledKey = "nsfw_enabled_key";
		private static readonly bool NSFWEnabledDefault = false;

    #endregion


    public static string GeneralSettings
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
      }
    }


	public static bool NSFWEnabled
	{
		get
		{
			return AppSettings.GetValueOrDefault<bool>(NSFWEnabledKey, NSFWEnabledDefault);
		}
		set
		{
			AppSettings.AddOrUpdateValue<bool>(NSFWEnabledKey, value);
		}
	}

  }
}
