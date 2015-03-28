/*****************************************************************************
 * Altairis TrackGPS sample application for Microsoft .NET Framework 3.5     *
 * Copyright (c) Michal Altair Valášek - Altairis, s. r. o., 2007            *
 *               http://www.rider.cz/    http://www.altairis.cz/             *
 * This code is licensed under terms of Microsoft Public License (Ms-PL)     *
 *****************************************************************************/

using System;
using System.Configuration;
using System.Linq;
using Altairis.GPS;

public partial class _Default : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        // Načíst skript AMapy API
        this.ClientScript.RegisterClientScriptInclude("AtlasAPI", "http://amapy.atlas.cz/api/api.ashx?guid=" + ConfigurationManager.AppSettings["AGuid"]);
    }

    protected void ButtonShowMap_Click(object sender, EventArgs e) {
        if (!this.IsValid) return;

        // Zjistit, zda byl vůbec poslán nějaký soubor
        if (this.FileUploadLogFile.PostedFile == null || this.FileUploadLogFile.PostedFile.ContentLength == 0) {
            this.LabelErrorMessage.Text = "Nebyl nahrán žádný soubor nebo je tento soubor prázdný.";
            this.MultiViewPage.SetActiveView(this.ViewError);
            return;
        }

        // Připravit parametry pro načtení logu
        TrackLog log = new TrackLog {
            IgnoreNoFix = this.CheckBoxIgnoreNoFix.Checked,
            ConvertFromUTC = this.CheckBoxConvertFromUTC.Checked,
            MarkerInterval = TimeSpan.FromMinutes(double.Parse(this.TextBoxMarkerInterval.Text)),
            PointDistance = int.Parse(this.TextBoxPointDistance.Text)
        };

        // Zvolit typ komprese
        TrackLogCompressionMethod compression;
        switch (this.RadioButtonListCompression.SelectedValue) {
            case "df":
                compression = TrackLogCompressionMethod.Deflate;
                break;
            case "gz":
                compression = TrackLogCompressionMethod.GZip;
                break;
            case "na":
                compression = TrackLogCompressionMethod.None;
                break;
            default:
                compression = TrackLogCompressionMethod.Auto;
                break;
        }

        // Naimportovat log ze zaslaného souboru
        log.Import(this.FileUploadLogFile.PostedFile.InputStream, compression);

        // Zjistit, zda se vůbec něco naimportovalo
        if (log.Points.Count() == 0 || log.Markers.Count() == 0) {
            this.LabelErrorMessage.Text = "Soubor neobsahuje žádné platné záznamy.";
            this.MultiViewPage.SetActiveView(this.ViewError);
            return;
        }

        // Vložit do stránky skript s vygenerovanou trasou
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "DynamicData", log.ToAMapyScript(), true);

        // Zobrazit statistiky
        this.LabelTotalTime.Text = string.Format(this.LabelTotalTime.Text, log.TotalTime);
        this.LabelTotalDistance.Text = string.Format(this.LabelTotalDistance.Text, log.TotalDistance / 1000.0);
        this.LabelAverageSpeed.Text = string.Format(this.LabelAverageSpeed.Text, log.TotalDistance / 1000.0 / log.TotalTime.TotalHours);

        // Zobrazit výsledek
        this.MultiViewPage.SetActiveView(this.ViewResult);
    }

}
