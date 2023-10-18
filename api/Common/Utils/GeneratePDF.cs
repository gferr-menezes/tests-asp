using PuppeteerSharp;

public static class GeneratePDF
{
    public static async Task<MemoryStream> Execute(string html)
    {
        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });
        using (var page = await browser.NewPageAsync())
        {

            await page.SetContentAsync(html);

            await page.AddStyleTagAsync(new AddTagOptions
            {
                Content = @"@import url(https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css);"
            });

            var pdf = await page.PdfStreamAsync();
            MemoryStream ms = new MemoryStream();
            await pdf.CopyToAsync(ms);
            ms.Position = 0;
            return ms;
        }

    }

}