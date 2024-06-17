using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Mjml.Net;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.Helpers;

public class UserTemplate
{
    public static string CreateEmailBody(UserDto data)
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
                        <mj-text font-size=""20px"">User</mj-text>
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
                                <td class=""ecm-tablecell nowrap bold"">Image Header:</td>
                                <td class=""ecm-tablecell bold"">{data.ImageHeader}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Email:</td>
                                <td class=""ecm-tablecell"">{data.Email}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Full Name:</td>
                                <td class=""ecm-tablecell"">{data.FullName}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">User Name:</td>
                                <td class=""ecm-tablecell"">{data.UserName}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Password:</td>
                                <td class=""ecm-tablecell"">{data.Password}</td>
                            </tr>
                            <tr>
                                <td class=""ecm-tablecell nowrap bold"">Company:</td>
                                <td class=""ecm-tablecell"">{data.Company}</td>
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


        return html;
    }
}