<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="cs">
<head runat="server">
    <title>Altairis NMEA log vizualizer</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta http-equiv="content-language" content="cs" />
    <meta name="author" content="Michal Altair Valášek - Altairis, s. r. o." />
    <link rel="stylesheet" type="text/css" href="gfx/TraceGPS.css" />
    <script type="text/javascript">
        var mapa;
        var points = [];
        var markers = [];
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="menu">
        <div>
            <img src="gfx/AppLogo.png" alt="Altairis NMEA log vizualizer" width="250" height="50" title="" />
        </div>
        <asp:MultiView ID="MultiViewPage" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewForm" runat="server">
                <div class="box">
                    <p class="strong j">
                        Nahrajte soubor se záznamem trasy v NMEA formátu. Aplikace zobrazí vaši trasu na mapě.
                    </p>
                    <asp:Label ID="Label1" runat="server" Text="Log soubor v NMEA formátu:" ToolTip="Soubor se záznamem cesty. Obvykle má příponu *.nmea, *.log, *.nmea.gz nebo *.log.gz." AssociatedControlID="FileUploadLogFile" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Není zadán soubor s NMEA logem" ControlToValidate="FileUploadLogFile" Text="*" Display="Dynamic" /><br />
                    <asp:FileUpload ID="FileUploadLogFile" runat="server" Width="230px" /><br />
                    <table style="width: 230px;">
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Vzdálenost bodů v metrech:" ToolTip="Interval vzdáleností, v nichž se bude vykreslovat trasa. Kraší interval znamená plynulejší křivku, ale větší zátěž." AssociatedControlID="TextBoxPointDistance" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPointDistance" ErrorMessage="Není zadána vzdálenost bodů" Text="*" Display="None" />
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBoxPointDistance" ErrorMessage="Vzdálenost bodů není není celé číslo mezi 1 a 10000" Text="*" Type="Integer" MinimumValue="1" MaximumValue="10000" />
                            </td>
                            <td align="right">
                                <asp:TextBox ID="TextBoxPointDistance" runat="server" Width="40px" Text="50" Style="text-align: right;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Interval značek v minutách:" ToolTip="Časový interval (vzhledem k rychlosti pohybu), v němž se bude zobrazovat na mapě značka s informacemi." AssociatedControlID="TextBoxMarkerInterval" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxMarkerInterval" ErrorMessage="Není zadán interval značek" Text="*" Display="None" />
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBoxMarkerInterval" ErrorMessage="Interval značek není celé číslo mezi 1 a 1440" Text="*" Type="Integer" MinimumValue="1" MaximumValue="1440" />
                            </td>
                            <td align="right">
                                <asp:TextBox ID="TextBoxMarkerInterval" runat="server" Width="40px" Text="5" Style="text-align: right;" />
                            </td>
                        </tr>
                    </table>
                    <fieldset>
                        <legend>Pokročilá nastavení zpracování</legend>
                        <asp:CheckBox ID="CheckBoxIgnoreNoFix" runat="server" Text="ignorovat nejisté body" ToolTip="Ignorovat záznamy s nejistou polohou (no fix)." Checked="true" /><br />
                        <asp:CheckBox ID="CheckBoxConvertFromUTC" runat="server" Text="čas v logu je v UTC" ToolTip="Převést časové údaje z UTC do místního času." Checked="true" /><br />
                        <asp:RadioButtonList ID="RadioButtonListCompression" runat="server" RepeatColumns="2" ToolTip="Volba komprese log souboru. Autodetekce umí poznat GZIP formát, vše ostatní bere jako nekomprimovaná data.">
                            <asp:ListItem Value="na" Text="bez komprese" />
                            <asp:ListItem Value="ad" Text="autodetekce" Selected="true" />
                            <asp:ListItem Value="gz" Text="GZIP" />
                            <asp:ListItem Value="df" Text="deflate" />
                        </asp:RadioButtonList>
                        <p class="small j">
                            Tato nastavení by za normálních okolností nemělo být nutné měnit, automatika si s nimi obvykle poradí.
                        </p>
                    </fieldset>
                    <div class="footer">
                        <asp:Button ID="ButtonShowMap" runat="server" Text="Zobrazit trasu" OnClick="ButtonShowMap_Click" />
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Zadání obsahuje následující chyby:" ShowMessageBox="true" ShowSummary="false" />
                </div>
            </asp:View>
            <asp:View ID="ViewError" runat="server">
                <div class="box">
                    <p>
                        <strong>Chyba při zpracování:</strong><br />
                        <asp:Label ID="LabelErrorMessage" runat="server" />
                    </p>
                    <div class="footer">
                        <button onclick="history.back(-1); return false;" style="width: 100px;">
                            Zpět
                        </button>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="ViewResult" runat="server">
                <div class="box">
                    <fieldset>
                        <legend>Trasa</legend>
                        <table>
                            <tr>
                                <th>
                                    Celkový čas:
                                </th>
                                <td>
                                    <asp:Label ID="LabelTotalTime" runat="server" Text="{0:HH:mm}" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Celková délka:
                                </th>
                                <td>
                                    <asp:Label ID="LabelTotalDistance" runat="server" Text="{0:N1} km" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Průměrná rychlost:
                                </th>
                                <td>
                                    <asp:Label ID="LabelAverageSpeed" runat="server" Text="{0:N1} km/h" />
                                </td>
                            </tr>
                        </table>
                        <p class="small j">
                            <em>Poznámka:</em> celková délka trasy a&nbsp;rychlost je pouze přibližná, protože algoritmus musí generovat náhodné chyby přesnosti GPS. Závisí na skutečné rychlosti pohybu a&nbsp;přesnosti GPS přístroje.
                        </p>
                    </fieldset>
                    <fieldset>
                        <legend>Mapa:</legend>
                        <table width="210px;">
                            <tr>
                                <th>
                                    Měřítko:
                                </th>
                                <td>
                                    <span id="LabelScaleInfo">?</span> <span class="textbutton" title="Automatické nastavení měřítka" onclick="mapa.setBestZoomAndCenter(mapa.overlays);">AUTO</span>
                                </td>
                            </tr>
                            <tr>
                                <th style="vertical-align: top;">
                                    Pozice kurzoru:
                                </th>
                                <td>
                                    <span id="LabelCursorPosition">?<br />
                                        ?</span>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <div class="footer">
                        <button onclick="history.back(-1); return false;" style="width: 100px;">
                            Nová trasa
                        </button>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <div class="box warning j">
            <p>
                <strong><em>Upozornění:</em> Aplikace je ve zkušebním provozu.</strong> Pokud nastanou při jejím použití nějaké problémy, kontaktujte jejího autora <a href="mailto:michal.valasek@altairis.cz">e-mailem</a>. Při hlášení chyb přiložte i soubor, který chybu způsobil.
            </p>
            <p>
                Pokud si chcete aplikaci jen vyzkoušet, zde je <a href="gfx/sample.nmea.gz">ukázkový log</a>.
            </p>
        </div>
    </div>
    <div id="mapa">
    </div>
    <div id="footer">
        <strong>&copy; <a href="http://www.rider.cz/">Michal A. Valášek</a> - <a href="http://www.altairis.cz">Altairis</a>, 2007</strong><br />
        <em>Powered by Microsoft .NET 3.5</em>
    </div>
    </form>
    <script type="text/javascript">
        function InitializeMap() {
            // Inicializovat mapu
            mapa = new AMap('mapa');
            mapa.loadMaps();
            mapa.addMapPart(new AMapControl());
            mapa.addMapPart(new AMapTypeControl());
            mapa.addEvent('onUpdateEnd', function() { 
                // Zobrazit měřítko
                l = document.getElementById('LabelScaleInfo'); 
                if(l != null) l.innerText = '1:' + mapa.getCurrentScale();
            } );
            mapa.addEvent('onMouseMove', function(point, e) {
                // Zobrazit aktuální pozici
                l = document.getElementById('LabelCursorPosition'); 
                if(l != null) l.innerText = point.toDisplayGPS().replace('; ', '\n');
            });
            
            // Vykreslit trasu
            mapa.addOverlay(new APolyline(points, { color: '#ff6633', weight: '3px', opacity: 1}));
            
            // Vytvořit ikonky pro značky
            var styleText = 'position: absolute; width: 20px; text-align: center; left: 0; top: 3px; color: white; font: bold 10px Arial; cursor: pointer;';
            var IconDefault = new AIcon({ fastRollover: false, fixPng: false, imageSrc: 'gfx/IconDefault.png', imageSize: new ASize(20, 20), shadowSrc: null, iconOffset: new APoint(10, 10), labelStyle: styleText});
            var IconStart = new AIcon({ fastRollover: false, fixPng: false, imageSrc: 'gfx/IconStart.png', imageSize: new ASize(20, 20), shadowSrc: null, iconOffset: new APoint(10, 10), labelStyle: styleText});
            var IconEnd = new AIcon({ fastRollover: false, fixPng: false, imageSrc: 'gfx/IconEnd.png', imageSize: new ASize(20, 20), shadowSrc: null, iconOffset: new APoint(10, 10), labelStyle: styleText});
            
            // Nastavit vlastnosti značek
            for(i = 0; i < markers.length; i++){
                if(i == 0) markers[i].options.icon = IconStart;                     // Začátek trasy
                else if(i == markers.length - 1) markers[i].options.icon = IconEnd; // Konec trasy
                else markers[i].options.icon = IconDefault;                         // Běžný bod
            }

            // Přidat značky
            mapa.addMarkers(markers);
            
            // Zobrazit ideální výřez a zoom
            mapa.setBestZoomAndCenter(mapa.overlays);   
        }

        // Zobrazí bublinu nad markerem
        function MarkerClick(sequenceNumber) {
            var marker = markers[sequenceNumber - 1];
            var html = '<table>';
            html = html + '<tr><th>Čas:</th><td>' + marker.options.xTime+ '</td></tr>';
            html = html + '<tr><th>Poloha:</th><td>' + marker.getGeoPoint().toDisplayGPS() + '</td></tr>';
            html = html + '<tr><th>Rychlost:</th><td>' + marker.options.xSpeed + ' km/h</td></tr>';
            html = html + '</table>';
            marker.showBubble(html);
        }

        window.addEvent('domready', InitializeMap);
    </script>
</body>
</html>
