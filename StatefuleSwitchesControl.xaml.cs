using System.Windows.Controls;

namespace User.StatefulSwitches
{

    public partial class StatefulSwitchesControl : UserControl
    {
        public StatefulSwitchesPlugin Plugin { get; }

        public StatefulSwitchesControl()
        {
            InitializeComponent();
        }

        public StatefulSwitchesControl(StatefulSwitchesPlugin plugin) : this()
        {
            this.Plugin = plugin;
        }


    }
}
