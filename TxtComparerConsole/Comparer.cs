using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtComparerConsole
{
    class Comparer
    {
        private FileInfo[] files;
        string[] original;
        string[] changed;
        string[] fieldNames;
        string[] linieNazwy;

        internal List<string[]> Compare(FileInfo[] files)
        {

            original = File.ReadAllLines(files[0].FullName);
            changed = File.ReadAllLines(files[1].FullName);
           

            List<string[]> changes = new List<string[]>();

            fieldNames = original[0].Split('\t');

            linieNazwy = new string[changed.Length];

            for(int i = 0; i < changed.Length; i++)
            {
                if(original[i] != null)
                {
                    changes.Add(CompareLine(i, original[i], changed[i]));
                }
                else changes.Add(new string[] { $"Added line nr {i}: "+ changed[i]} );
            }
            return changes;
        }

        private string[] CompareLine(int nrLinii, string v1, string v2)
        {
            string[] orglinia = v1.Split('\t');
            string[] zmienlinia = v2.Split('\t');

            string[] zmiany = new string[zmienlinia.Length];

            linieNazwy[nrLinii] = zmienlinia[0];

            for(int fieldNr = 0; fieldNr < zmienlinia.Length; fieldNr++)
            {

                if(orglinia[fieldNr] != zmienlinia[fieldNr])
                    zmiany[fieldNr] = $"{linieNazwy[nrLinii]}, (line {nrLinii}), field {fieldNames[fieldNr]}({fieldNr}): \"" + orglinia[fieldNr] + "\" => \"" + zmienlinia[fieldNr] + "\"";
            }
            return zmiany;
        }
    }
}
