namespace NeatInput.Windows.Filtering
{
    public interface IPreProcessingFilter
    {
        bool PreFilterMessage(HookRawInput hookRawInput);
    }
}
