using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkOrder
{
    class DDrinkFactory
    {
        DDrink[] drinks = new DDrink[14];
        int position = 0;
        public DDrinkFactory()
        {
            loadData();
        }

        private void loadData()
        {
            drinks[0] = new DDrink() { id = 1, name = "泡沫紅茶", price = "80"};
            drinks[1] = new DDrink() { id = 2, name = "阿薩姆紅茶", price = "20"};
            drinks[2] = new DDrink() { id = 3, name = "茉香綠茶", price = "35"};
            drinks[3] = new DDrink() { id = 4, name = "文山青茶", price = "40"};
            drinks[4] = new DDrink() { id = 5, name = "布丁奶茶", price = "25"};
            drinks[5] = new DDrink() { id = 6, name = "仙草凍奶茶", price = "30"};
            drinks[6] = new DDrink() { id = 7, name = "珍珠青茶", price = "20"};
            drinks[7] = new DDrink() { id = 8, name = "珍珠綠茶", price = "50"};
            drinks[8] = new DDrink() { id = 9, name = "珍珠奶綠", price = "55"};
            drinks[9] = new DDrink() { id = 10, name = "珍珠奶茶", price = "30" };
            drinks[10] = new DDrink() { id = 11, name = "洛神花茶", price = "15"  };
            drinks[11] = new DDrink() { id = 12, name = "凍頂烏龍茶", price = "50"};
            drinks[12] = new DDrink() { id = 13, name = "珍珠桂花茶", price = "35" };
            drinks[13] = new DDrink() { id = 14, name = "仙草甘茶", price = "44" };

        }

        public DDrink[] getAll()
        {
            return drinks;
        }
        public DDrink getname(string p)
        {
            try
            {
                string intId = p;
                for (int i = 0; i < drinks.Length; i++)
                {
                    if (drinks[i].name == intId)
                    {
                        position = i;
                        return drinks[i];
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
