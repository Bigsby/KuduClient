using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuduClient.Objects
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("crtime")]
        public DateTime Created { get; set; }

        [JsonProperty("mtime")]
        public DateTime Modified { get; set; }

        [JsonProperty("mime")]
        public string MimeType { get; set; }

        public ItemType Type
        {
            get
            {
                return MimeType == "inode/directory" ? ItemType.Folder : ItemType.File;
            }
        }

        [JsonProperty("href")]
        public string Link { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum ItemType
    {
        Unknown,
        Folder,
        File
    }
}
