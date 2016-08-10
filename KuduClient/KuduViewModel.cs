using KuduClient.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KuduClient
{
    public class KuduViewModel : ObservableObject
    {
        private readonly KuduClient _client;
        private readonly Stack<Item> _breadcrumb = new Stack<Item>();
        private readonly string _baseUrl;
        public KuduViewModel(string baseUrl, string username, string password)
        {
            _baseUrl = baseUrl;
            _client = new KuduClient(baseUrl, username, password);
        }

        private IEnumerable<Item> _items;
        public IEnumerable<Item> Items
        {
            get { return _items; }
            set { SetAndRaise(ref _items, value); }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { SetAndRaise(ref _path, value); }
        }

        public ICommand Back
        {
            get
            {
                return new ActionCommand(async p =>
                {
                    if (_breadcrumb.Count == 0)
                        return;

                    _breadcrumb.Pop();
                    await SetItems(_breadcrumb.Count == 0 ? null : _breadcrumb.Peek());
                });
            }
        }

        public ICommand Select
        {
            get
            {
                return new ActionCommand(async p =>
                {
                    var item = p as Item;

                    if (null != item && item.Type != ItemType.Folder)
                        return;

                    await SetItems(item);
                    _breadcrumb.Push(item);
                });
            }
        }

        private async Task SetItems(Item currentItem)
        {
            Items = await _client.GetItems(currentItem);
            Path = null == currentItem ? _baseUrl : currentItem.Link;
        }
    }
}
