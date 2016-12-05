using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using VsShortcuts.WebApi.Models;

namespace VsShortcuts.WebApi.data
{
    public class ShortcutRepository
    {
        private IEnumerable<ShortcutModel> _allShortcuts;

        public IEnumerable<ShortcutModel> AllShortcuts
        {
            get { return _allShortcuts ?? (_allShortcuts = LoadShortcuts()); }
        }

        private IEnumerable<ShortcutModel> LoadShortcuts()
        {

            var path = HttpContext.Current.Server.MapPath("~/App_Data/2015_shortcuts.xml");
            var xDoc = XDocument.Load(path);
            return xDoc.Root.Elements("command").Select(x => new ShortcutModel
            {
                Name = x.Attribute("name").Value,
                Shortcut = x.Attribute("shortcut").Value,
            });
        }

        public IEnumerable<ShortcutModel> Filter(Func<ShortcutModel, bool> func)
        {
            return AllShortcuts.Where(func);
        }
    }
}