using System;
using System.Windows.Forms.VisualStyles;
using static LightMasterMVVM.ViewModels.NotificationViewModel;

namespace LightMasterMVVM.Models
{
    public enum OriginalPage
    {
        TeamList,
        StatsView
    }
    public static class NavMessenger
    {
        public static event Action<int, OriginalPage> ShowTeamDetails;
        public static void OnShowTeamDetails(int arg, OriginalPage calledPage) => ShowTeamDetails?.Invoke(arg, calledPage);

        public static event Action<int, OriginalPage> ShowMatchDetails;
        public static void OnShowMatchDetails(int arg, OriginalPage calledPage) => ShowMatchDetails?.Invoke(arg, calledPage);

        public static event Action<OriginalPage> FromMatchDetails;
        public static void OnFromMatchDetails(OriginalPage page) => FromMatchDetails?.Invoke(page);

        public static event Action<OriginalPage> FromTeamDetails;
        public static void OnFromTeamDetails(OriginalPage page) => FromTeamDetails?.Invoke(page);

        public static event Action<TrackedProperty[], TrackedProperty[]> CreateNewGraph;
        public static void OnCreateNewGraph(TrackedProperty[] trackingBy, TrackedProperty[] orderBy) => CreateNewGraph?.Invoke(trackingBy,orderBy);
        public static event Action<TabletRequestArgs> NotificationEventAcceptance;
        public static void OnNotificationEventAcceptance(TabletRequestArgs args) => NotificationEventAcceptance?.Invoke(args);
        public static event Action<int, int> NotificationSeconds;
        public static void OnNotificationSeconds(int seconds, int notifid) => NotificationSeconds?.Invoke(seconds, notifid);
    }
}
