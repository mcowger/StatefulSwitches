using GameReaderCommon;
using SimHub.Plugins;
using System;
using System.Windows.Media;

namespace User.StatefulSwitches
{
    [PluginDescription("Keeps track of multi-position switches by name for easier dashboard building.")]
    [PluginAuthor("Matt Cowger")]
    [PluginName("Stateful Switches")]
    public class StatefulSwitchesPlugin : IPlugin, IDataPlugin, IWPFSettingsV2
    {
        public StatefulSwitchesSettings Settings;

        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }

        /// <summary>
        /// Gets the left menu icon. Icon must be 24x24 and compatible with black and white display.
        /// </summary>
        public ImageSource PictureIcon => this.ToIcon(Properties.Resources.sdkmenuicon);

        /// <summary>
        /// Gets a short plugin title to show in left menu. Return null if you want to use the title as defined in PluginName attribute.
        /// </summary>
        public string LeftMenuTitle => "Stateful Switches";

        /// <summary>
        /// Called one time per game data update, contains all normalized game data,
        /// raw data are intentionnally "hidden" under a generic object type (A plugin SHOULD NOT USE IT)
        ///
        /// This method is on the critical path, it must execute as fast as possible and avoid throwing any error
        ///
        /// </summary>
        /// <param name="pluginManager"></param>
        /// <param name="data">Current game data, including current and previous data frame.</param>
        public void DataUpdate(PluginManager pluginManager, ref GameData data)
        {
            // Define the value of our property (declared in init)
            if (data.GameRunning)
            {

            }
        }

        /// <summary>
        /// Called at plugin manager stop, close/dispose anything needed here !
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void End(PluginManager pluginManager)
        {
            // Save settings
            this.SaveCommonSettings("GeneralSettings", Settings);
        }

        /// <summary>
        /// Returns the settings control, return null if no settings control is required
        /// </summary>
        /// <param name="pluginManager"></param>
        /// <returns></returns>
        public System.Windows.Controls.Control GetWPFSettingsControl(PluginManager pluginManager)
        {
            return new StatefulSwitchesControl(this);
        }

        /// <summary>
        /// Called once after plugins startup
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void Init(PluginManager pluginManager)
        {
            SimHub.Logging.Current.Info("Starting plugin");

            // Load settings
            Settings = this.ReadCommonSettings<StatefulSwitchesSettings>("GeneralSettings", () => new StatefulSwitchesSettings());
        }
    }
}