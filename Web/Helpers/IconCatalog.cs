using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Xml.Linq;

namespace Web
{
    public static class IconCatalog
    {
        public static List<string> FeatureIcons => new List<string>
        {
         // Engineering / Power / Technical
         "fa-solid fa-bolt",
         "fa-solid fa-plug-circle-bolt",
         "fa-solid fa-diagram-project",
         "fa-solid fa-wave-square",
         "fa-solid fa-shield-halved",
         "fa-solid fa-gears",
         "fa-solid fa-industry",
         "fa-solid fa-network-wired",
         "fa-solid fa-tower-broadcast",
         "fa-solid fa-sitemap",
         "fa-solid fa-server",
         "fa-solid fa-database",
         "fa-solid fa-microchip",
         "fa-solid fa-chart-line",
         "fa-solid fa-gauge-high",
         "fa-solid fa-circle-nodes",
        
         // Communication
         "fa-solid fa-envelope",
         "fa-solid fa-envelope-open",
         "fa-solid fa-phone",
         "fa-solid fa-mobile-screen",
         "fa-solid fa-comment",
         "fa-solid fa-comments",
         "fa-solid fa-paper-plane",
        
         // Tools / Settings
         "fa-solid fa-gear",
         "fa-solid fa-wrench",
         "fa-solid fa-screwdriver-wrench",
         "fa-solid fa-toolbox",
         "fa-solid fa-sliders",
         "fa-solid fa-filter",
         "fa-solid fa-magnifying-glass",
        
         // Media / Files
         "fa-solid fa-image",
         "fa-solid fa-images",
         "fa-solid fa-video",
         "fa-solid fa-play",
         "fa-solid fa-file",
         "fa-solid fa-file-lines",
         "fa-solid fa-file-pdf",
         "fa-solid fa-folder",
         "fa-solid fa-folder-open",
        
         // Status / Alerts
         "fa-solid fa-circle-check",
         "fa-solid fa-circle-xmark",
         "fa-solid fa-circle-exclamation",
         "fa-solid fa-triangle-exclamation",
         "fa-solid fa-info-circle",
         "fa-solid fa-bell",
         "fa-solid fa-bell-slash",
         "fa-solid fa-flag",
        
         // CRUD / Actions
         "fa-solid fa-plus",
         "fa-solid fa-minus",
         "fa-solid fa-pen",
         "fa-solid fa-pen-to-square",
         "fa-solid fa-trash",
         "fa-solid fa-eye",
         "fa-solid fa-eye-slash",
         "fa-solid fa-floppy-disk",
         "fa-solid fa-download",
         "fa-solid fa-upload",
         "fa-solid fa-arrows-rotate",
        
         // Admin / Users
         "fa-solid fa-house",
         "fa-solid fa-user",
         "fa-solid fa-users",
         "fa-solid fa-user-gear",
         "fa-solid fa-user-shield",
         "fa-solid fa-lock",
         "fa-solid fa-unlock",
         "fa-solid fa-key",
         "fa-solid fa-shield",
         "fa-solid fa-id-card",
        
         // Buildings / Infrastructure / Energy
         "fa-solid fa-building",
         "fa-solid fa-city",
         "fa-solid fa-hospital",
         "fa-solid fa-school",
         "fa-solid fa-warehouse",
         "fa-solid fa-solar-panel",
         "fa-solid fa-wind",
         "fa-solid fa-charging-station",
         "fa-solid fa-car-battery",
        
         // Features / Modules
         "fa-solid fa-list-check",
         "fa-solid fa-layer-group",
         "fa-solid fa-cubes",
         "fa-solid fa-puzzle-piece",
         "fa-solid fa-clipboard-list",
         "fa-solid fa-table-columns",
         "fa-solid fa-bars-progress",
         "fa-solid fa-code-branch"
        };

    }

}