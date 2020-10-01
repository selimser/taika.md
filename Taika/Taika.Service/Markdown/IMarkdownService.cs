using System.Threading.Tasks;

namespace Taika.Service.Markdown
{
    public interface IMarkdownService
    {
        Task<string> ParseMarkdown(string input);
    }
}
