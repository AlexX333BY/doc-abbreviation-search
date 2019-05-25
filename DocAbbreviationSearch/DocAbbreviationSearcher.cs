using System;
using System.Collections.Generic;
using System.IO;

namespace DocAbbreviationSearch
{
    class DocAbbreviationSearcher
    {
        public DocAbbreviationSearcher()
        {
            filepath = null;
        }

        public string Filepath
        { 
            get => filepath;
            set => filepath = File.Exists(value) ? value : throw new ArgumentException("File doesn't exist", nameof(Filepath));
        }

        public IEnumerable<string> GetAbbreviations()
        {
            if (File.Exists(Filepath))
            {
                var result = new HashSet<string>();

                return result;
            }
            else
            {
                throw new FileNotFoundException("File doesn't exist", filepath);
            }
        }

        private string filepath;
    }
}
