using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;
using Mjml.Net;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.Helpers;

public class ReportTemplate
{
    public static string CreateEmailBody(Report data)
    {
        var mjmlRenderer = new MjmlRenderer();

        string text = $@"
        <mjml>
            <mj-head>
                <!-- MJML styling en attributen -->
            </mj-head>

            <mj-body>
                <mj-section css-class=""ecm-bgcolor"" full-width=""full-width"">
                    <mj-column css-class=""ecm-bgcolor"">
                        <mj-image width=""200px"" src=""https://angelair.ecmanage.eu/Portals/FASHIONFABRIEK/ANGELAIR/_portal_logo_1687501962551.png?ver=XdNQkxEBBrDZ8CwGlJZHcg%3d%3d""></mj-image>
                    </mj-column>
                </mj-section>

                <mj-section>
                    <mj-column>
                        <mj-text font-size=""20px"">Report</mj-text>
                    </mj-column>
                </mj-section>
                <mj-section>
                    <mj-column>
                        <mj-divider />
                    </mj-column>
                </mj-section>

                <mj-section>
                    <mj-column>
                        <mj-table>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Portal Name:</td>
                                <td class=""ecm-tablecell bold"">{data.PortalName}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Report Name:</td>
                                <td class=""ecm-tablecell"">{data.ReportName}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">URL:</td>
                                <td class=""ecm-tablecell"">{data.Url}</td>
                            </tr>
                        </mj-table>
                    </mj-column>
                </mj-section>
                <mj-section>
                    <mj-column>
                        <mj-divider />
                    </mj-column>
                </mj-section>

                <mj-section>
                    <mj-column>
                        <mj-text font-size=""10px"">Dit is een automatisch verstuurde e-mail. Hierop kan niet gereageerd worden.</mj-text>
                    </mj-column>
                </mj-section>
            </mj-body>
        </mjml>";

        var options = new MjmlOptions
        {
            Beautify = false
        };

        var (html, errors) = mjmlRenderer.Render(text, options);

        // Retourneer de HTML-body
        return html;
    }
}