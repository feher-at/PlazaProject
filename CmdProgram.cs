using System;
using System.Collections.Generic;
using System.Text;

namespace PlazaProject
{
    class CmdProgram
    {
        private List<Product> cart;
        private List<float> prices;

        public CmdProgram(string[] args)
        { }

        private void ListingMenuPoints(string[] menu)
        {
            foreach(string element in menu)
            {
                Console.WriteLine(element);
            }
        }
        public void run()
        {
            string[] createPlazaimplMenu = { "1) to create a new plaza.",
                                             "2) to exit."};

            string[] plazaImplMenu = { "1) to list all shops.",
                                       "2) to add a new shop.",
                                       "3) to remove an existing shop.",
                                       "4) enter a shop by name.",
                                       "5) to open the plaza.",
                                       "6) to close the plaza.",
                                       "7) to check if the plaza is open or not.",
                                       "8) leave the plaza"};

            string[] shopMenu = {   "1) to list available products.",
                                    "2) to find products by name.",
                                    "3) to display the shop's owner.",
                                    "4) to open the shop.",
                                    "5) to close the shop.",
                                    "6) to add new product to the shop.",
                                    "7) to add existing products to the shop.",
                                    "8) to buy a product by barcode.",
                                    "9) check price by barcode.",
                                    "10) go back to plaza."};

            while (true)
            {
                try
                {
                    Console.WriteLine("There are no plaza created yet! Press");
                    string answ = Console.ReadLine();
                    ListingMenuPoints(createPlazaimplMenu);
                    if(answ == "1")
                    {
                        Console.WriteLine("Give me the plaza name: ");
                        PlazaImpl plaza = new PlazaImpl(Console.ReadLine());
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine($"Welcome to the {plaza.Name}! Press ");
                                string plazansw = Console.ReadLine();
                                ListingMenuPoints(plazaImplMenu);
                                if(plazansw == "1")
                                {
                                    foreach(IShop element in plaza.GetShops())
                                    {
                                        Console.WriteLine(element.ToString());
                                    }
                                }
                                else if(plazansw == "2")
                                {
                                    string[] shopquestions = { "Give me the shop Name: ",
                                                                "Give me the shop Owner: "};
                                    List<string> shopanswer = new List<string>();
                                    foreach(string element in shopquestions)
                                    {
                                        Console.WriteLine(element);
                                        shopanswer.Add(Console.ReadLine());
                                    }
                                    plaza.AddShop(new ShopImpl(shopanswer[0], shopanswer[1]));
                                }
                                else if(plazansw == "3")
                                {
                                    Console.WriteLine("Give me the shop Name what you want to remove: ");
                                    string removingPlaza = Console.ReadLine();
                                    if(plaza.GetShops().Count == 0)
                                    {
                                        Console.WriteLine("Create a shop first please");
                                    }
                                    foreach(IShop element in plaza.GetShops())
                                    {
                                        if(element.Name == removingPlaza)
                                        {
                                            plaza.RemoveShop(element);
                                            break;
                                        }
                                    }
                                }
                                else if(plazansw == "4")
                                {
                                    Console.WriteLine("Give me the sope you want to enter! : ");
                                    string removingPlaza = Console.ReadLine();
                                    if (plaza.GetShops().Count == 0)
                                    {
                                        Console.WriteLine("Create a shop first please");
                                        return;
                                    }
                                    foreach (IShop element in plaza.GetShops())
                                    {
                                        if (element.Name == removingPlaza)
                                        {
                                            while (true)
                                            {
                                                try
                                                {
                                                    Console.WriteLine($"Welcome to the {element.Name} Shop!Press: ");
                                                    string shopansw = Console.ReadLine();
                                                    ListingMenuPoints(shopMenu);
                                                    if(shopansw == "1")
                                                    {
                                                        if (element.GetProducts().Count == 0)
                                                        {
                                                            Console.WriteLine("Create a product first please");
                                                            return;
                                                        }
                                                        foreach(Product product in element.GetProducts())
                                                        {
                                                            Console.WriteLine(product.ToString());
                                                        }
                                                    }
                                                    else if(shopansw == "2")
                                                    {
                                                        Console.WriteLine("Give me the product name what you: ");
                                                        Console.WriteLine(element.FindByName(Console.ReadLine()).ToString());
                                                    }
                                                    else if(shopansw == "3")
                                                    {
                                                       
                                                        Console.WriteLine($"The shop's owner is{element.Owner}");
                                                    }
                                                    else if(shopansw == "4")
                                                    {
                                                        element.Open();
                                                        Console.WriteLine("The shop has been opened");
                                                    }
                                                    else if(shopansw == "5")
                                                    {
                                                        element.Close();
                                                        Console.WriteLine("The shop has been closed");
                                                    }
                                                    else if(shopansw == "6")
                                                    {
                                                        Console.WriteLine("What kind of product you want to create");
                                                        string productType = Console.ReadLine().ToLower();
                                                        if(productType == "foodproduct" || productType == "food product")
                                                        {
                                                            string[] foodData = {"Give me the barcode : ",
                                                                                 "Give me the food name: ",
                                                                                 "Give me the manufacturer: ",
                                                                                 "Give me the food's calories: "};

                                                            string[] Datetime = {"Give me the warranty year: ",
                                                                                 "Give me the warranty month: ",
                                                                                 "Give me the warranty day: "};
                                                            List<string> DatetimeAnsw = new List<string>();
                                                            List<string> foodDataAnsw = new List<string>();
                                                            foreach(string data in foodData)
                                                            {
                                                                Console.WriteLine(data);
                                                                foodDataAnsw.Add(Console.ReadLine());
                                                            }
                                                            foreach (string datatime in Datetime)
                                                            {
                                                                Console.WriteLine(datatime);
                                                                DatetimeAnsw.Add(Console.ReadLine());
                                                            }
                                                            FoodProduct foodProduct = new FoodProduct(Convert.ToInt64(foodDataAnsw[0]),
                                                                                                        foodDataAnsw[1],
                                                                                                        foodDataAnsw[2],
                                                                                                        Convert.ToInt32(foodDataAnsw[3]),
                                                                                                        new DateTime(Convert.ToInt32(DatetimeAnsw[0]),
                                                                                                                     Convert.ToInt32(DatetimeAnsw[1]),
                                                                                                                     Convert.ToInt32(DatetimeAnsw[2])));
                                                            string[] quantityPrice= {"Give me the quantity: ",
                                                                                     "Give me the Price"};
                                                            List<string> quantityPriceansw = new List<string>();
                                                            foreach(string data in quantityPrice)
                                                            {
                                                                Console.WriteLine(data);
                                                                quantityPriceansw.Add(Console.ReadLine());
                                                            }
                                                            element.AddNewProduct(foodProduct, Convert.ToInt32(quantityPriceansw[0]), float.Parse(quantityPriceansw[1]));
                                                        }
                                                        else if(productType == "clothingproduct" || productType == "clothing product")
                                                        {
                                                            string[] clothdata = {"Give me the barcode : ",
                                                                                 "Give me the food name: ",
                                                                                 "Give me the manufacturer: ",
                                                                                 "Give me the material: ",
                                                                                 "Give me the type: " };
                                                            List<string> clothDataAnsw = new List<string>();
                                                            foreach (string data in clothdata)
                                                            {
                                                                Console.WriteLine(data);
                                                                clothDataAnsw.Add(Console.ReadLine());
                                                            }
                                                            ClothingProduct clothing = new ClothingProduct(Convert.ToInt64(clothDataAnsw[0]),
                                                                                                            clothDataAnsw[1],
                                                                                                            clothDataAnsw[2],
                                                                                                            clothDataAnsw[3],
                                                                                                            clothDataAnsw[4]);
                                                            string[] quantityPrice = {"Give me the quantity: ",
                                                                                      "Give me the Price"};
                                                            List<string> quantityPriceansw = new List<string>();
                                                            foreach (string data in quantityPrice)
                                                            {
                                                                Console.WriteLine(data);
                                                                quantityPriceansw.Add(Console.ReadLine());
                                                            }
                                                            element.AddNewProduct(clothing, Convert.ToInt32(quantityPriceansw[0]), float.Parse(quantityPriceansw[1]));

                                                        }
                                                    }
                                                    else if(shopansw == "7")
                                                    {
                                                        Console.WriteLine("Product barcode and name");
                                                        foreach(Product product in element.GetProducts())
                                                        {
                                                            
                                                            Console.WriteLine(product.Barcode + " " + product.Name);

                                                        }
                                                        Console.WriteLine("Give me the barcode");
                                                        long barcodeansw = Convert.ToInt64(Console.ReadLine());
                                                        Console.WriteLine("Give me the quantity");
                                                        int quantityansw = Convert.ToInt32(Console.ReadLine());
                                                        element.AddProduct(barcodeansw, quantityansw);
                                                        
                                                    }
                                                    else if(shopansw == "8")
                                                    {
                                                        Console.WriteLine("Product barcode and name");
                                                        foreach (Product product in element.GetProducts())
                                                        {
                                                            Console.WriteLine(product.Barcode + " " + product.Name);
                                                        }
                                                        Console.WriteLine("Give me the product's barcode which you want to buy: ");
                                                        long barcodeansw = Convert.ToInt64(Console.ReadLine());
                                                        Console.WriteLine($"How many product you want to buy? : ");
                                                        int quantityansw = Convert.ToInt32(Console.ReadLine());
                                                        if(quantityansw == 1)
                                                        {

                                                        }
                                                    }
                                                }
                                                catch(Exception ex)
                                                { }
                                            }
                                    }
                                }

                            }
                            catch(Exception ex)
                            {

                            }
                        }


                    }
                    else if(answ == "2")
                    {
                        Console.WriteLine("Thank you for your visit,bye");
                        break;
                    }
                }
                catch(Exception ex)
                { }
            }
            
        }
    }
}
