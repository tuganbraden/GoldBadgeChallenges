using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItem_Repository
{
    public class MenuItemRepo
    {
        private List<MenuItem> _listOfItems = new List<MenuItem>();

        // CREATE
        public void CreateNewItem(MenuItem item)
        {
            _listOfItems.Add(item);
        }

        // READ
        public List<MenuItem> GetMenu()
        {
            return _listOfItems;
        }

        // DELETE (update not needed)
        public bool RemoveItem(int num)
        {
            var item = GetItemByNumber(num);

            if (item != null)
            {
                _listOfItems.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }


        public MenuItem GetItemByNumber(int num)
        {
            foreach (MenuItem item in _listOfItems)
            {
                if (item.MealNumber == num)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
