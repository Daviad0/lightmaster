using System;
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
    }
}
