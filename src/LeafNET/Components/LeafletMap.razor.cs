using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LeafNET;

public partial class LeafletMap : ComponentBase, IAsyncDisposable
{

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = null!;
    
    [Parameter]
    public string MapId { get; set; } = Guid.NewGuid().ToString();

    [Parameter]
    public MapService? Map { get; set; }
    
    [Parameter]
    public EventCallback<MapService?> MapChanged { get; set; }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (Map is null)
            {
                Map = await MapService.InitializeAsync(this, JSRuntime, MapId);
                await MapChanged.InvokeAsync(Map);
            }
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync($"Error creating LeafletMap: {e.Message}");
        }
    }


    public async ValueTask DisposeAsync()
    {
        try
        {
            if (Map != null)
                await Map.DisposeAsync();
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync($"Error during dispose of LeafletMap: {e.Message}");
        }
    }
}