using System;
using System.Threading.Tasks;

namespace DiscordChatExporter.Gui.Services;

public class UpdateService : IDisposable
{
    public ValueTask<Version?> CheckForUpdatesAsync() => ValueTask.FromResult<Version?>(null);

    public ValueTask PrepareUpdateAsync(Version version) => ValueTask.CompletedTask;

    public void FinalizeUpdate(bool needRestart) { }

    public void Dispose() { }
}
