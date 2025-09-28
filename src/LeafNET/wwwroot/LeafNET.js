let _map;
let _markers = [];
let _markerLayer = null;
let _dotnet = null;

export function attachDotNet(dotnet) {
    _dotnet = dotnet;
}

export async function initMap(mapDivId, options) {

    // convert nulls to undefined
    console.log(options);
    options.center = options.center ?? undefined;
    options.zoom = options.zoom ?? undefined;
    options.minZoom = options.minZoom ?? undefined;
    options.maxZoom = options.maxZoom ?? undefined;
    
    _map = L.map(mapDivId, options);
    
    L.tileLayer(
        "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
        {maxZoom: 20, attribution: "&copy; OpenStreetMap contributors"}
    ).addTo(_map);
}


export function setView(center, zoom, options) {
    _map.setView(center, zoom, options);
}