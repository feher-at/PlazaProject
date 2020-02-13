using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
    class PlazaImpl : IPlaza
    {
        private List<IShop> shops = new List<IShop>();
        public string Name { get; private set; }
        public bool open;

        public PlazaImpl(string Name)
        {
            this.Name = Name;
        }
        public List<IShop> GetShops()
        {
            if(open == false)
            {
                throw new PlazaIsClosedException("The plaza is closed,sorry");
            }
            return shops;
        }
        public void AddShop(IShop shop)
        {
            shops.Add(shop);
        }
        public void RemoveShop(IShop shop)
        {
            shops.Remove(shop);
        }
        public IShop FindShopByName(string name)
        {
            
            if(open == false)
            {
                throw new PlazaIsClosedException("The plaza is closed");
            }
            foreach (IShop shop in shops)
            {
                if (shop.Name == name)
                {
                    return shop;
                }
            }
            throw new NoSuchShopException("There is no such shop");


        }
        public bool IsOpen()
        {
            return open;
        }
        public void Open()
        {
            open = true;
        }
        public void Close()
        {
            open = false;
        }


    }
}
