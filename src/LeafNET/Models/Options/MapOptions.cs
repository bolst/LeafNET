namespace LeafNET;

public sealed record MapOptions
{

    public bool PreferCanvas { get; init; }
    
    
    #region Control

    public bool AttributionControl { get; init; } = true;
    
    public bool ZoomControl { get; init; } = true;

    #endregion
    
    
    #region Interaction
    
    public bool ClosePopupOnClick { get; init; } = true;
    
    public bool BoxZoomControl { get; init; } = true;
    
    public bool DoubleClickZoomControl { get; init; } = true;
    
    public bool Dragging { get; init; } = true;
    
    public double ZoomSnap { get; init; } = 1;
    
    public double ZoomDelta { get; init; } = 1;
    
    public bool TrackResize { get; init; } = true;
    
    #endregion
    
    
    #region Panning Inertia
    
    public bool Inertia { get; init; } = true;

    public double InertiaDeceleration { get; init; } = 3000;
    
    public double InertiaMaxSpeed { get; init; } = double.MaxValue;

    public double EaseLinearity { get; init; } = 0.2;
    
    public bool WorldCopyJump { get; init; }

    public double MaxBoundsViscosity { get; init; }

    #endregion
    
    
    #region Keyboard Navigation
    
    public bool Keyboard { get; init; } = true;
    
    public int KeyboardPanDelta { get; init; } = 80;

    #endregion


    #region Mouse wheel

    public bool ScrollWheelZoom { get; init; } = true;

    public int WheelDebounceTime { get; init; } = 40;

    public int WheelPxPerZoomLevel { get; init; } = 60;

    #endregion


    // TODO:
    #region Touch interaction

    // public bool TapHold { get; init; } = true;

    public int TapTolerance { get; init; } = 15;
    
    // public bool TouchZoom { get; init; } = true;
    
    public bool BounceAtZoomLimits { get; init; } = true;

    #endregion


    // TODO:
    #region Map state

    // public CRS Crs { get; init; } = CRS.EPSG3857;
    
    public LatLng? Center { get; init; } = null;

    public int? Zoom { get; init; } = null;

    public int? MinZoom { get; init; } = null;

    public int? MaxZoom { get; init; } = null;
    
    public Layer[] Layers { get; init; } = [];
    
    // public LatLngBounds? MaxBounds { get; init; }
    
    // public Renderer Renderer { get; init; }
    
    #endregion


    #region Animation

    public bool ZoomAnimation { get; init; } = true;

    public int ZoomAnimationThreshold { get; init; } = 4;
    
    public bool FadeAnimation { get; init; } = true;
    
    public bool MarkerZoomAnimation { get; init; } = true;
    
    public int Transform3DLimit { get; init; } = 8388608; // 2^23

    #endregion

}