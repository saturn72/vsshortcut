using System.Collections.Generic;
using System.Web.Http;
using VsShortcuts.WebApi.data;
using VsShortcuts.WebApi.Models;

namespace VsShortcuts.WebApi.Controllers
{

    [RoutePrefix("api/Shortcut")]
    public class ShortcutController: ApiController
    {
        private readonly ShortcutRepository _shortcutrepository;

        public ShortcutController()
        {
            _shortcutrepository = new ShortcutRepository();
        }

        // GET api/values
        public IEnumerable<ShortcutModel> Get()
        {
            return _shortcutrepository.AllShortcuts;
        }

        // GET api/values
        [Route("{startsWith:alpha}")]
        public IEnumerable<ShortcutModel> Get(string startsWith)
        {
            return _shortcutrepository.Filter(x=>x.Name.StartsWith(startsWith));
        }

    }
}