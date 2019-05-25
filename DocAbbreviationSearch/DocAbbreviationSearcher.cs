using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;

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

        public SortedSet<string> GetAbbreviations(byte mimimalUpperCaseLettersCount)
        {
            var result = new SortedSet<string>();

            using (var document = WordprocessingDocument.Open(Filepath, false))
            using (var textElement = OpenXmlReader.Create(document.MainDocumentPart.RootElement))
            {
                while (textElement.Read())
                {
                    result.UnionWith(textElement.GetText()
                        .Split(null)
                        .Select((word) => word.Trim())
                        .Where((word) => word.Count((symbol) => char.IsUpper(symbol)) >= mimimalUpperCaseLettersCount)
                    );
                }
            }

            return result;
        }

        private string filepath;
    }
}
