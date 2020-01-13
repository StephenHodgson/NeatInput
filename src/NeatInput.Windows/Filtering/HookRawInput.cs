namespace NeatInput.Windows.Filtering
{
    public struct HookRawInput
    {
        public WindowMessage Message { get; set; }

        public KBDLLHOOKSTRUCT Struct { get; set; }
    }
}
