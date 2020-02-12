﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace PlazaProject
{
    public class ShopImpl:IShop
    {
       
        public string Name { get; set; }
        
        public string Owner { get; set; }
        public bool IsOpen { get; set; }
        public List<Product> Products { get; set; }

        private Dictionary<long, ShopImpl.ShopEntryImpl> DictProducts;

        public ShopImpl(string Name,string Owner,bool IsOpen)
        {
            this.Name = Name;
            this.Owner = Owner;
            this.IsOpen = IsOpen;
            Products = new List<Product>();
            DictProducts = new Dictionary<long, ShopImpl.ShopEntryImpl>();
           
        }

        public void Open()
        {
            IsOpen = true;
        }
        public void Close()
        {
            IsOpen = false;
        }
        public Product FindByName(string Name)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count > 1)
            {
                for (int i = 0; i < DictProducts.Count; i++)
                {
                    if (DictProducts.ElementAt(i).Value.Product.Name == Name)
                    {
                        return DictProducts.ElementAt(i).Value.Product;
                    }
                }
                throw new NoSuchProductException("There is no such product in the shop");
            }
            else
                throw new NoSuchProductException("The shop is empty sorry");

        }
        public float GetPrice(long barcode)
        {
            float ez;
            ez = 234.53F;
            return ez;
        }
        public bool HasProduct(long barcode)
        {
            return true;
        }
        public void AddNewProduct(Product product, int quantity, float price)
        {
            if(IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count > 1)
            {
                foreach (long element in DictProducts.Keys)
                {
                    if (element == product.Barcode)
                        throw new ProductAlreadyExistException("This product is already in the shop");
                }
                ShopEntryImpl shopEntry = new ShopEntryImpl(product, quantity, price);
                DictProducts[product.Barcode] = shopEntry;
            }
            else
            {
                ShopEntryImpl shopEntry = new ShopEntryImpl(product, quantity, price);
                DictProducts[product.Barcode] = shopEntry;
            }
            
            

        }
        public void AddProduct(long barcode,int quantity)
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count > 1)
            {
                for (int i = 0; i < DictProducts.Count; i++)
                {
                    if (DictProducts.ElementAt(i).Key == barcode)
                    {
                        DictProducts.ElementAt(i).Value.Quantity += quantity;
                        break;
                    }
                }
                throw new NoSuchProductException("There is no such product in the shop");
            }
            else
            {
                throw new NoSuchProductException("The shop is empty sorry");
            }
        }
        public Product BuyProduct(long barcode)
        {

        }
        public List<Product> BuyProducts(long barcode,int quantity)
        {

        }


        class ShopEntryImpl
        {

            public Product Product { get; set; }

            public int Quantity { get; set; }
            
            public float Price { get; set; }
            public ShopEntryImpl(Product Product, int Quantity, float Price)
            {
                this.Product = Product;
                this.Quantity = Quantity;
                this.Price = Price;

            }
            
            public void IncreaseQuantity(int amount)
            {
                Quantity += amount;
            }
            public void DecraseQuantity(int amount)
            {
                Quantity -= amount;
            }
        }
    }
}