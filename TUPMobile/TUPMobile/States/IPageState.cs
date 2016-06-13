namespace TUPMobile.States
{
    public interface IPageState
    {
        string ServerError { get; set; }
        bool ShowNotConnected { get; set; }
    }
}