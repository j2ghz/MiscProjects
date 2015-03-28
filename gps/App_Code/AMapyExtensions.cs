/*****************************************************************************
 * Altairis TrackGPS sample application for Microsoft .NET Framework 3.5     *
 * Copyright (c) Michal Altair Valášek - Altairis, s. r. o., 2007            *
 *               http://www.rider.cz/    http://www.altairis.cz/             *
 * This code is licensed under terms of Microsoft Public License (Ms-PL)     *
 *****************************************************************************/

using Altairis.GPS;
using System.Globalization;
using System.Text;

/// <summary>
/// Tato třída obsahuje extension methods pro práci s objekty z namespace 
/// Altairis.GPS v prostředí AMapy API.
/// 
/// Metody je vhodné separovat od tříd samých. Zatímco třídy TrackPoint 
/// a TrackLog jsou univerzální a použitelné v jakémkoliv kontextu, metody
/// v této třídě jsou specifické pro kontext této konkrétní aplikace.
/// </summary>
public static class AMapyExtensions {
    private const string AMarkerScriptSource = "  markers.push(new AMarker(new AGeoPoint({0}, {1}, ACoordinateSystem.Geodetic), {{ label: '{2}', xSpeed: '{3:N1}', xTime: '{4:D} {4:T}', 'onClick': function() {{ MarkerClick({2}); }} }}));";
    private const string AGeoPointScriptSource = "  points.push(new AGeoPoint({0:N6}, {1:N6}, ACoordinateSystem.Geodetic));";

    /// <summary>
    /// Vrátí JavaScript pro vytvoření markeru.
    /// </summary>
    /// <param name="point">TrackPoint, který odpovídá markeru.</param>
    /// <param name="sequenceNumber">Pořadové číslo markeru v rámci trasy.</param>
    /// <returns>JavaScript, který vytvoří instanci třídy <c>AMarker</c> a přidá ji do kolekce <c>markers</c>.</returns>
    public static string ToAMarkerScript(this TrackPoint point, int sequenceNumber) {
        return string.Format(AMarkerScriptSource,
            point.Latitude.ToString("N6", NumberFormatInfo.InvariantInfo),  // V tomto formátovacím řetězci potřebujeme kombinovat místní locale
            point.Longitude.ToString("N6", NumberFormatInfo.InvariantInfo), // s invariant pro čísla, proto tato trochu podivná konstrukce.
            sequenceNumber,
            point.Speed * Utils.KnotsToKMH,
            point.Time);
    }

    /// <summary>
    /// Vrátí JavaScript pro vytvoření geopointu (pro vykreslení trasy).
    /// </summary>
    /// <param name="point">TrackPoint, který odpovídá geopointu.</param>
    /// <returns>JavaScript, který vytvoří instanci třídy <c>AGeoPoint</c> a přidá ji do kolekce <c>points</c>.</returns>
    public static string ToAGeoPointScript(this TrackPoint point) {
        return string.Format(CultureInfo.InvariantCulture, AGeoPointScriptSource,
            point.Latitude,
            point.Longitude);
    }

    /// <summary>
    /// Vrátí JavaScript pro vytvoření všech markerů a geopointů z daného logu.
    /// </summary>
    /// <param name="log">TrackLog, ze kterého se generuje skript.</param>
    /// <returns>JavaScript, který naplní kolekce <c>markers</c> a <c>points</c>.</returns>
    public static string ToAMapyScript(this TrackLog log) {
        // Vygenerovat skript pro vložení markerů
        StringBuilder script = new StringBuilder();
        TrackPoint[] markers = log.Markers;
        for (int i = 0; i < markers.Length; i++) script.AppendLine(markers[i].ToAMarkerScript(i + 1));

        // Vygenerovat skript pro vykreslení trasy
        TrackPoint[] points = log.Points;
        for (int i = 0; i < points.Length; i++) script.AppendLine(points[i].ToAGeoPointScript());

        return script.ToString();
    }

}
