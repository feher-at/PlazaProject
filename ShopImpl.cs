using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace PlazaProject
{
    public class ShopImpl : IShop
    {

        public string Name { get; set; }

        public string Owner { get; set; }
        public bool IsOpen { get; set; }


        private Dictionary<long, ShopImpl.ShopEntryImpl> DictProducts;

        public ShopImpl(string Name, string Owner, bool IsOpen)
        {
            this.Name = Name;
            this.Owner = Owner;
            this.IsOpen = IsOpen;

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
        public List<Product> GetProducts()
        {
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            List<Product> allProduct = new List<Product>();
            for (int i = 0; i < DictProducts.Count; i++)
            {
                allProduct.Add(DictProducts.ElementAt(i).Value.Product);
            }
            return allProduct;


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
                        return DictProducts.ElementAt(i).Value.Price;
                    }
                }
                throw new NoSuchProductException("There is no such product in the shop");
            }
            else
                throw new NoSuchProductException("The shop is empty sorry");
        }
        public bool HasProduct(long barcode)
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
                        return true;
                    }
                }
            }
            return false;
        }
        public void AddNewProduct(Product product, int quantity, float price)
        {
            if (IsOpen == false)
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
        public void AddProduct(long barcode, int quantity)
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
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }
            if (DictProducts.Count > 1)
            {
                for (int i = 0; i < DictProducts.Count; i++)
                {
                    if (DictProducts.ElementAt(i).Key == barcode && DictProducts.ElementAt(i).Value.Quantity == 0)
                    {
                        throw new OutOfStockException("This product run out of the stock");

                    }
                    else if (DictProducts.ElementAt(i).Key == barcode)
                    {
                        return DictProducts.ElementAt(i).Value.Product;
                    }
                }
                throw new NoSuchProductException("There is no such product in the shop");
            }
            else
            {
                throw new NoSuchProductException("The shop is empty sorry");
            }
        }
        public List<Product> BuyProducts(long barcode, int quantity)
        {
            List<Product> BuyedProducts = new List<Product>();
            if (IsOpen == false)
            {
                throw new ShopIsClosedException("The shop is closed sorry");
            }

            for (int i = 0; i < DictProducts.Count; i++)
            {
                if (DictProducts.ElementAt(i).Key == barcode && (DictProducts.ElementAt(i).Value.Quantity == 0 || DictProducts.ElementAt(i).Value.Quantity < quantity))
                {
                    throw new OutOfStockException("This product run out of the stock");
                }
                else if (DictProducts.ElementAt(i).Key == barcode)
                {
                    for (int index = 1; i <= quantity; index++)
                    {
                        BuyedProducts.Add(DictProducts.ElementAt(i).Value.Product);
                    }
                    return BuyedProducts;
                }
            }
            throw new NoSuchProductException("There is no such product in this shop");
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
