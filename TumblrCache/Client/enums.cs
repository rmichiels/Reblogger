namespace TumblrCache.Client
{
    public enum FlowState
    {
        Landing,
        Selection,
        Archive,
        Manage,
        Upload,
        Restore
    }

    public enum ComponentState
    {
        Loading,
        Interactive
    }

    public enum Variant
    {
        Navigation,
        Action,
        Danger
    }
}
