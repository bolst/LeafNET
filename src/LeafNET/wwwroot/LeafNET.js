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


export function addGeoPoints(geoPoints) {
    if (!geoPoints)
        return;

    if (!_markerLayer) {
        _markerLayer = L.featureGroup();
        _map.addLayer(_markerLayer);
    }

    for (const geoPoint of geoPoints) {
        try {
            
            if (geoPoint.icon)
                geoPoint.options.icon = geoPoint.icon;
            
            const marker = L.marker([geoPoint.latitude, geoPoint.longitude], geoPoint.options);
            _markerLayer.addLayer(marker);
            _markers.push(marker);
        } catch (error) {
            console.error('Error adding marker:', error);
        }
    }
    
    return _markers.map(x => x.options)
}

export function fitBounds() {
    if (!_map || !_markerLayer) { return; }
    
    _map.fitBounds(_markerLayer.getBounds());
}


export function flyTo(lat, lng, zoom, zoomPanOptions) {
    if (!_map) { return; }
    
    _map.flyTo(L.latLng(lat, lng), zoom, zoomPanOptions);
}