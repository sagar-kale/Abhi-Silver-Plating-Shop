using Abhi_Silver_Plating_Shop.Model;
using Abhi_Silver_Plating_Shop.Utils;
using RazorEngineCore;
using System.IO;

namespace Abhi_Silver_Plating_Shop.TemplateEngine
{
    public class Engine
    {
        public Engine()
        {
        }
        public string RenderHtmlTemplate<T>(ReportViewModel<T> reportViewModel, string type = "DEFAULT")
        {
            string path = null;
            if (type == "DEFAULT")
            {
                path = string.Format("{0}\\templates\\default-report.cshtml", Directory.GetCurrentDirectory());
            } else
            {
                path = string.Format("{0}\\templates\\single-order-report.cshtml", Directory.GetCurrentDirectory());
            }
            string razorHtml = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(path));
            IRazorEngine razorEngine = new RazorEngine();
            IRazorEngineCompiledTemplate template = razorEngine.Compile(razorHtml, builder =>
               {
                   builder.AddAssemblyReference(typeof(Utility));
                   builder.AddAssemblyReference(typeof(Stat));
                   builder.AddAssemblyReference(typeof(ReportViewModel<T>));
                   builder.AddAssemblyReference(typeof(System.DateTime));
               });
            string generatedHtml = template.Run(reportViewModel);
            return generatedHtml;
        }
    }
}
