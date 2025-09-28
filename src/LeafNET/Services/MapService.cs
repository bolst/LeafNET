using Microsoft.JSInterop;

namespace LeafNET;


public class MapService : IAsyncDisposable
{
    private const string _jsPath = "./_content/LeafNET/LeafNET.js";

    private readonly DotNetObjectReference<LeafletMap> _dotNetRef;
    private readonly IJSObjectReference _jsRef;
    private readonly string _mapId;
    private readonly MapOptions? _options;
    
    private MapService(DotNetObjectReference<LeafletMap> dotNetRef, IJSObjectReference jsRef, string mapId, MapOptions? options = null)
    {
        _dotNetRef = dotNetRef;
        _jsRef = jsRef;
        _mapId = mapId;
        _options = options;
    }


    public static async Task<MapService?> InitializeAsync(LeafletMap leafletMap, IJSRuntime jsRuntime, string mapId, MapOptions? options = null)
    {
        try
        {
            Console.WriteLine($"Initializing map {mapId}");

            var dotNetRef = DotNetObjectReference.Create(leafletMap);
            var jsRef = await jsRuntime.InvokeAsync<IJSObjectReference>("import", _jsPath);
            
            // initialize map in js
            await jsRef.InvokeVoidAsync("attachDotNet", dotNetRef);
            await jsRef.InvokeVoidAsync("initMap", mapId, options);
            
            return new MapService(dotNetRef, jsRef, mapId, options);
        }
        catch (JSDisconnectedException)
        {
            // TODO: bitch and complain you probably are not in OnAfterRender
            await Console.Error.WriteLineAsync("Could not create MapService: JS Disconnected");
            throw;
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync($"Could not create MapService: {e.Message}");
            throw;
        }
    }

    
    
    #region Map state

    public ValueTask SetView(LatLng center, int zoom)
        => _jsRef.InvokeVoidAsync("setView", center, zoom, new { Animate = true });
    
    #endregion
    
    
    
    public async ValueTask DisposeAsync()
    {
        try
        {
            _dotNetRef?.Dispose();
            await _jsRef.DisposeAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error disposing LeafletMapController: {e.Message}");
        }
    }
}