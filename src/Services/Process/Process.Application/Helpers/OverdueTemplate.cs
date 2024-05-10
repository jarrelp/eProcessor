using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Mjml.Net;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.Helpers;

public class OverdueTemplate
{
    public static string CreateEmailBody(OverdueDto data)
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
                        <mj-text font-size=""20px"">Overdue</mj-text>
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
                                <td class=""ecm-tablecell nowrap bold"">Naam:</td>
                                <td class=""ecm-tablecell bold"">{data.FullName}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">E-mailadres:</td>
                                <td class=""ecm-tablecell"">{data.Email}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Productnummer:</td>
                                <td class=""ecm-tablecell"">{data.ProductNumber}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Productnaam:</td>
                                <td class=""ecm-tablecell"">{data.ProductName}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Ordercode:</td>
                                <td class=""ecm-tablecell"">{data.OrderCode}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Orderdatum:</td>
                                <td class=""ecm-tablecell"">{data.OrderDate}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Overdue datum:</td>
                                <td class=""ecm-tablecell"">{data.OverdueDate}</td>
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