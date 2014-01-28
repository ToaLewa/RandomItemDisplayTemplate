using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RandomItemDisplayTemplate
{
    

    class ItemListFiller
    {

        //This method reads the XML file and creates a list of the items within it

        public List<string> ListFiller()
        {


         List<string> itemsList = new List<string>();

            XmlReader reader = XmlReader.Create(@"Common/ItemList.xml");


            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element)
                {

                    if (reader.Name == "item")
                    {

                        reader.Read();

                        string item = reader.Value;
                        itemsList.Add(item);
                    }

                }

            }

            return itemsList;

        }
    }
}
